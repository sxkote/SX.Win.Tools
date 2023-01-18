using SX.Math.Enums;
using System;

namespace SX.Math.Lexems.Symbols
{
    public abstract class LexemSymbol : Lexem
    {
        public string Text { get; protected set; }
        public abstract LexemSymbolType SymbolType { get; }

        public LexemSymbol(string text)
        {
            if (String.IsNullOrEmpty(text))
                throw new ArgumentException("Symbol can't be null or empty");

            this.Text = text.Trim();
        }

        public override string ToString() => this.Text ?? "";

        static public LexemSymbol? ParseSymbol(ref string? text)
        {
            if (String.IsNullOrEmpty(text))
                return null;

            text = text.Trim();

            char ch = text[0];

            switch (ch)
            {
                // Switch
                case '?':
                case ':':
                    {
                        text = text.Crop(1);
                        return new LexemSymbolSwitch(ch.ToString());
                    }

                // Brackets
                case '(':
                case ')':
                case '{':
                case '}':
                case '[':
                case ']':
                    {
                        text = text!.Crop(1);
                        return new LexemSymbolBracket(ch.ToString());
                    }

                // Commas
                case ',':
                case ';':
                    {
                        text = text.Crop(1);
                        return new LexemSymbolComma(ch.ToString());
                    }

                // Operators
                case '+':
                case '-':
                case '*':
                case '/':
                case '<':
                case '>':
                case '=':
                case '!':
                case '&':
                case '|':
                case '.':
                    {
                        return LexemSymbolOperator.ParseSymbolOperator(ref text);
                    }

                // Invalid Symbol
                default: return null;
            }
        }
    }
}
