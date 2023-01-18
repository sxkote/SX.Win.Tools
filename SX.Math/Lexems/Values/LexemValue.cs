using SX.Math.Interfaces;
using System;

namespace SX.Math.Lexems.Values
{
    public abstract class LexemValue : Lexem
    {
        public virtual LexemVariable Execute(Lexem lexem, ILexemEnvironment? environment = null)
        {
            if (lexem == null)
                throw new InvalidOperationException("Can't execute null Lexem");

            return environment?.Execute(this, lexem);
        }

        public static LexemValue? GetValue(Lexem lexem)
        {
            if (lexem is LexemValue lexemValue)
                return lexemValue;

            if (lexem is LexemVariable lexemVariable)
                return lexemVariable.Value;

            return null;
        }

        public static LexemValue? ParseValue(ref string? text)
        {
            if (String.IsNullOrEmpty(text))
                return null;

            LexemValue? result = null;
            if ((result = LexemValuePointer.ParseValuePointer(ref text)) != null)
                return result;
            if ((result = LexemValueBool.ParseValueBool(ref text)) != null)
                return result;
            if ((result = LexemValueDate.ParseValueDate(ref text)) != null)
                return result;
            if ((result = LexemValueSpan.ParseValueSpan(ref text)) != null)
                return result;
            if ((result = LexemValueText.ParseValueText(ref text)) != null)
                return result;
            if ((result = LexemValueNumber.ParseValueNumber(ref text)) != null)
                return result;
            if ((result = LexemValueComplex.ParseValueComplex(ref text)) != null)
                return result;
            if ((result = LexemValueStruct.ParseValueStruct(ref text)) != null)
                return result;

            return null;
        }

        public static LexemValue? ParseExact(string text)
        {
            var temp = text;

            var result = ParseValue(ref temp);
            if (String.IsNullOrEmpty(temp))
                return result;

            return null;
        }

        #region Operators
        public static implicit operator LexemValue(decimal value) => (LexemValueNumber)value;

        public static implicit operator LexemValue(double value) => (LexemValueNumber)value;

        public static implicit operator LexemValue(int value) => (LexemValueNumber)value;

        public static implicit operator LexemValue(bool value) => (LexemValueBool)value;

        public static implicit operator LexemValue(DateTime value) => (LexemValueDate)value;

        public static implicit operator LexemValue(TimeSpan value) => (LexemValueSpan)value;

        public static implicit operator LexemValue(string value) => (LexemValueText)value;
        #endregion
    }
}
