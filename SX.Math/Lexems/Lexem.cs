using SX.Math.Lexems.Symbols;
using SX.Math.Lexems.Values;
using System;

namespace SX.Math.Lexems
{
    public abstract class Lexem
    {
        static public Lexem? Parse(ref string? text)
        {
            Lexem? result;

            if ((result = LexemKeyword.ParseKeyword(ref text)) != null)
                return result;

            if ((result = LexemValue.ParseValue(ref text)) != null)
                return result;

            if ((result = LexemSymbol.ParseSymbol(ref text)) != null)
                return result;

            if ((result = LexemFunction.ParseFunction(ref text)) != null)
                return result;

            if ((result = LexemVariable.ParseVariable(ref text)) != null)
                return result;

            return null;
        }

        #region Operators
        public static implicit operator Lexem(decimal value) => (LexemValueNumber)value;
        public static implicit operator Lexem(double value) => (LexemValueNumber)value;
        public static implicit operator Lexem(int value) => (LexemValueNumber)value;
        public static implicit operator Lexem(bool value) => (LexemValueBool)value;
        public static implicit operator Lexem(DateTime value) => (LexemValueDate)value;
        public static implicit operator Lexem(TimeSpan value) => (LexemValueSpan)value;
        public static implicit operator Lexem(string value) => (LexemValueText)value;
        #endregion
    }
}
