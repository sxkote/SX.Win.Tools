using SX.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SX.Shared
{
    public static class Helpers
    {
        public const StringComparison STRING_COMPARE = StringComparison.OrdinalIgnoreCase;

        public const int MAX_ENTITIES_TO_QUERY = 1000;

        public static DateTime GetDateTime() => DateTime.Now;
        public static DateTime GetDateTimeUTC() => GetDateTime().SetKindUtc();
        public static DateTimeOffset GetDateTimeOffset() => DateTimeOffset.Now;
        public static DateTimeOffset GetDateTimeOffsetUTC() => DateTimeOffset.UtcNow;

        public static byte[] ReadFully(this Stream input)
        {
            input.Position = 0;
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public static DateTime? SetKindUtc(this DateTime? dateTime)
        {
            if (dateTime.HasValue)
            {
                return dateTime.Value.SetKindUtc();
            }
            else
            {
                return null;
            }
        }
        public static DateTime SetKindUtc(this DateTime dateTime)
        {
            if (dateTime.Kind == DateTimeKind.Utc) { return dateTime; }
            return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
        }
        public static DateTimeOffset? SetKindUtc(this DateTimeOffset? dateTime)
        {
            if (dateTime.HasValue)
            {
                return dateTime.Value.SetKindUtc();
            }
            else
            {
                return null;
            }
        }
        public static DateTimeOffset SetKindUtc(this DateTimeOffset dateTime)
        {
            return dateTime.ToUniversalTime();
        }

        public static IEnumerable<string> SplitFormatted(this string input, params char[] separators)
        {
            var sb = new StringBuilder();
            bool quoted = false;
            bool apostrophed = false;

            foreach (char c in input)
            {
                if (quoted || apostrophed)
                {
                    if (quoted && c == '"')
                        quoted = false;
                    else if (apostrophed && c == '\'')
                        apostrophed = false;

                    sb.Append(c);
                }
                else
                {
                    if (separators.Contains(c))
                    {
                        yield return sb.ToString();
                        sb.Length = 0;
                        continue;
                    }

                    if (c == '"')
                        quoted = true;
                    else if (c == '\'')
                        apostrophed = true;

                    sb.Append(c);
                }
            }

            if (quoted || apostrophed)
                throw new CustomArgumentException("Unterminated quotation mark");

            yield return sb.ToString();
        }

        public static bool Contains<T>(this List<KeyValuePair<string, T>> parametres, string name)
        {
            foreach (var value in parametres)
                if (value.Key.Equals(name, STRING_COMPARE))
                    return true;
            return false;
        }
        public static T GetValue<T>(this List<KeyValuePair<string, T>> parametres, string name)
        {
            foreach (var value in parametres)
                if (value.Key.Equals(name, STRING_COMPARE))
                    return value.Value;
            return default(T);
        }

        public static string GetErrorMessage(this Exception ex, int innerLevel = 10, bool appendStackTrace = true, bool openAggregateExceptions = true)
        {
            if (ex == null)
                return "";

            var agrEx = ex as AggregateException;

            // обработка AggregateException
            if (openAggregateExceptions && agrEx != null && agrEx.InnerExceptions.Count > 0)
            {
                var sb = new StringBuilder();
                foreach (var innerEx in agrEx.InnerExceptions)
                    sb.AppendLine(GetErrorMessage(innerEx, innerLevel, appendStackTrace, openAggregateExceptions));
                return sb.ToString();
            }

            var result = (ex.Message ?? "");
            if (appendStackTrace)
                result += Environment.NewLine + (ex.StackTrace ?? "");

            try
            {
                if (innerLevel > 0)
                {
                    if (agrEx != null)
                    {
                        agrEx.InnerExceptions.ToList()
                            .ForEach(e => result += Environment.NewLine + Environment.NewLine + GetErrorMessage(e, innerLevel - 1, appendStackTrace));
                    }
                    else
                    {
                        if (ex.InnerException != null)
                            result += Environment.NewLine + Environment.NewLine + GetErrorMessage(ex.InnerException, innerLevel - 1, appendStackTrace);
                    }
                }
            }
            catch { }

            return result;
        }

        public static bool IsPhoneNumber(string text, int length = 11) => Regex.IsMatch(text, @$"[\+\-\d\s\(\)]{{{length},}}", RegexOptions.IgnoreCase);

        public static string GetPhoneNumber(string text, int length = 11, string prefix = "7")
        {
            if (!IsPhoneNumber(text))
                throw new CustomFormatException("Wrong phone number format");

            var phone = Regex.Replace(text, @"[^\d]", "").Trim();

            if (phone.StartsWith("8") && phone.Length == length)
                phone = prefix + phone.Substring(1);
            else if (phone.Length == length - 1)
                phone = String.Concat(prefix, phone);

            return phone;
        }

        //public static string GetMimeMapping(string filename) => MimeMappingsService.GetMimeMapping(filename);
    }
}
