using SX.Math.Interfaces;
using System;

namespace SX.Math.Lexems.Values
{
    public class LexemValuePointer : LexemValue
    {
        public static LexemValuePointer NULL { get => new LexemValuePointer(null); }

        public object? Value { get; private set; }

        public LexemValuePointer(object? pointer)
        {
            this.Value = pointer;
        }

        public override string ToString()
        {
            return (this.Value == null) ? "null" : this.Value.ToString();
        }

        public static LexemValuePointer? ParseValuePointer(ref string? text)
        {
            if (String.IsNullOrEmpty(text))
                return null;

            text = text.Trim();

            if (!text.StartsWith("null", StringComparison.InvariantCultureIgnoreCase))
                return null;

            text = text.Crop(4);

            return LexemValuePointer.NULL;
        }

        public override LexemVariable Execute(Lexem lexem, ILexemEnvironment? environment = null)
        {
            return base.Execute(lexem, environment);
        }
    }
}
