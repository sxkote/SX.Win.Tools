using SX.Math.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace SX.Math.Lexems.Values
{
    public class LexemValueSpan : LexemValue
    {
        public const string PATTERN = @"\'(((?<days>\d+)[ \.\:])?(?<hours>\d+)\:(?<minutes>\d+)\:(?<seconds>\d+)|(?<days>\d*)\;(?<hours>\d*)\;(?<minutes>\d*)\;(?<seconds>\d*))\'";

        public TimeSpan Value { get; private set; }

        public LexemValueSpan(string text)
        {
            Match match = Regex.Match(text, $"^{PATTERN}$");
            if (!match.Success)
                throw new FormatException("Span format is wrong");

            this.Value = CreateSpanFromRegexMatch(match);
        }

        public LexemValueSpan(TimeSpan span)
        {
            this.Value = span;
        }

        public override string ToString() => $"'{this.Value.Days}:{this.Value.Hours}:{this.Value.Minutes}:{this.Value.Seconds}'";

        public override bool Equals(object obj)
        {
            if (obj is LexemValueSpan)
                return this.Value == ((LexemValueSpan)obj).Value;

            if (obj is TimeSpan)
                return this.Value == (TimeSpan)obj;

            return false;
        }
        public override int GetHashCode() => this.Value.GetHashCode();

        public override LexemVariable Execute(Lexem lexem, ILexemEnvironment? environment = null)
        {
            if (lexem == null)
                throw new InvalidOperationException("Can't execute null lexem on Value");

            var function = lexem as LexemFunction;
            if (function != null)
            {
                switch (function.Name.ToLower())
                {
                    case "tostring":
                        return this.Value.ToString();
                }
            }

            return base.Execute(lexem, environment);
        }

        static private TimeSpan CreateSpanFromRegexMatch(Match match)
        {
            // check the regex match
            if (match == null || !match.Success)
                throw new FormatException("Span has a wrong format");

            try
            {
                Func<string, int> getPart = name => String.IsNullOrEmpty(match.Groups[name].Value) ? 0 : Convert.ToInt32(match.Groups[name].Value);

                return new TimeSpan(getPart("days"), getPart("hours"), getPart("minutes"), getPart("seconds"));
            }
            catch
            {
                throw new FormatException("Number has a wrong format");
            }
        }

        public static LexemValueSpan? ParseValueSpan(ref string? text)
        {
            if (String.IsNullOrEmpty(text))
                return null;

            text = text.Trim();

            Match match = Regex.Match(text, $"^{PATTERN}");
            if (!match.Success)
                return null;

            text = text.Crop(match.Value.Length);

            return new LexemValueSpan(match.Value);
        }

        #region Operators
        public static implicit operator LexemValueSpan(TimeSpan span) => new LexemValueSpan(span);
        public static implicit operator TimeSpan(LexemValueSpan span) => span.Value;

        public static bool operator ==(LexemValueSpan argument, LexemValueSpan span)
        {
            if (ReferenceEquals(argument, null) || ReferenceEquals(span, null))
                return false;

            return argument.Value == span.Value;
        }

        public static bool operator !=(LexemValueSpan argument, LexemValueSpan span) => !(argument == span);
        public static bool operator >(LexemValueSpan argument, LexemValueSpan span)
        {
            if (argument == null || span == null)
                return false;

            return argument.Value > span.Value;
        }
        public static bool operator <(LexemValueSpan argument, LexemValueSpan span) => span > argument;
        public static bool operator >=(LexemValueSpan argument, LexemValueSpan span)
        {
            if (argument == null || span == null)
                return false;

            return argument.Value >= span.Value;
        }
        public static bool operator <=(LexemValueSpan argument, LexemValueSpan span) => span >= argument;
        #endregion
    }
}
