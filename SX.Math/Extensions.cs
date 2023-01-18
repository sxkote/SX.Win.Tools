using SX.Math.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SX.Math
{
    static internal class Extensions
    {
        static public string? Crop(this string text, int length)
        {
            return (String.IsNullOrEmpty(text) || text.Length <= length) ? null : text.Substring(length);
        }

        static public bool Like(this string text, string pattern)
        {
            pattern = System.Text.RegularExpressions.Regex.Escape(pattern);

            pattern = pattern.Replace("%", ".*?").Replace("_", ".");
            pattern = pattern.Replace(@"\[", "[").Replace(@"\]", "]").Replace(@"\^", "^");

            return System.Text.RegularExpressions.Regex.IsMatch(text, pattern);
        }

        static public List<string> Split(this string text, char[] separators, SymbolPair[] brackets = null)
        {
            if (String.IsNullOrWhiteSpace(text))
                return null;

            var result = new List<string>();

            var input = text;
            while (!String.IsNullOrWhiteSpace(input))
            {
                var index = input.Find(separators, 0, brackets);

                var value = (index < 0) ? input : input.Substring(0, index);

                result.Add(value);

                input = input.Crop(value.Length + 1);
            }

            return result;
        }

        static public int Find(this string text, char[] find, int index = 0, SymbolPair[] brackets = null)
        {
            if (String.IsNullOrWhiteSpace(text))
                return -1;

            var balancer = new BracketsBalanceStringValidator(brackets);
            for (int i = index; i < text.Length; i++)
            {
                if (find.Contains(text[i]) && balancer.IsBalanced)
                    return i;

                balancer.Push(text[i].ToString());
            }

            return -1;
        }
    }
}
