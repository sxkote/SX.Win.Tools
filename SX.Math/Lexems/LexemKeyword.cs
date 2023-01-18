using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace SX.Math.Lexems
{
    public class LexemKeyword : Lexem
    {
        static public readonly string[] KEYWORDS =
        {
            "text", "string",
            "number", "double", "decimal", "float", "money",
            "int","bigint", "long",
            "bit", "bool", "boolean",
            "date","datetime", "time",
            "span", "timespan",
            "complex","void",
            "public", "protected", "private",
            "if", "else", "for", "while", "do", "begin", "end", "return", "command", "//",
            "class", "variable", "var", "function", "func"
        };

        public string Text { get; private set; }

        public LexemKeyword(string text)
        {
            if (String.IsNullOrEmpty(text))
                throw new ArgumentException("Keyword can't be null or empty");

            this.Text = text.Trim().ToLower();

            if (!KEYWORDS.Contains(this.Text))
                throw new FormatException("Unknown Keyword");
        }

        public override string ToString() => this.Text;

        static public LexemKeyword? ParseKeyword(ref string? text)
        {
            if (String.IsNullOrEmpty(text))
                return null;

            text = text.Trim();

            Match match = Regex.Match(text, @"^(\w+|\/\/)");
            if (!match.Success || !KEYWORDS.Any(k => k.Equals(match.Value, StringComparison.InvariantCultureIgnoreCase)))
                return null;

            text = text.Crop(match.Value.Length);

            return new LexemKeyword(match.Value);
        }
    }
}
