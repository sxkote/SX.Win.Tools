using SX.Math.Interfaces;
using SX.Math.Lexems.Values;
using System;
using System.Text.RegularExpressions;

namespace SX.Math.Lexems
{
    public class LexemVariable : Lexem
    {
        public const string PATTERN = @"[\@\$]?\w+";

        public string Name { get; private set; } = "";
        public LexemValue? Value { get; set; }

        private LexemVariable() { }

        public LexemVariable(string name, LexemValue? value = null)
            : this()
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentException("Variable Name can't be null or empty");

            this.Name = name;

            if (!CheckVariableName(this.Name))
                throw new FormatException(String.Format($"Variable Name {this.Name} is incorrect"));

            this.Value = value;
        }

        public override string ToString() => this.Name;

        public override bool Equals(object obj)
        {
            if (this.Value == null)
                return false;

            if (obj is LexemValue)
            {
                return this.Value.Equals(obj);
            }

            if (obj is LexemVariable objVariable)
            {
                return this.Value.Equals(objVariable.Value);
            }

            return false;
        }
        public override int GetHashCode() => this.Value?.GetHashCode() ?? 0;

        public LexemVariable Execute(Lexem lexem, ILexemEnvironment? environment = null)
        {
            if (lexem == null)
                throw new InvalidOperationException("Can't execute null lexem on Variable");

            if (this.Value == null)
                throw new InvalidOperationException("Can't execute Lexem on empty Value");

            return this.Value.Execute(lexem, environment);
        }

        static public bool CheckVariableName(string name)
        {
            if (String.IsNullOrEmpty(name))
                return false;

            return Regex.IsMatch(name, $"^({PATTERN})$");
        }

        public static LexemVariable? ParseVariable(ref string? text)
        {
            if (String.IsNullOrEmpty(text))
                return null;

            text = text.Trim();

            Match? match = Regex.Match(text, $"^{PATTERN}");
            if (!match.Success || String.IsNullOrEmpty(match.Value))
                return null;

            text = text.Crop(match.Value.Length);

            return new LexemVariable(match.Value);
        }

        #region Operators
        public static implicit operator LexemVariable(LexemValue value) => new LexemVariable() { Value = value };
        public static implicit operator LexemVariable(decimal value) => new LexemVariable() { Value = value };
        public static implicit operator LexemVariable(double value) => new LexemVariable() { Value = value };
        public static implicit operator LexemVariable(int value) => new LexemVariable() { Value = value };
        public static implicit operator LexemVariable(bool value) => new LexemVariable() { Value = value };
        public static implicit operator LexemVariable(DateTime value) => new LexemVariable() { Value = value };
        public static implicit operator LexemVariable(TimeSpan value) => new LexemVariable() { Value = value };
        public static implicit operator LexemVariable(string value) => new LexemVariable() { Value = value };
        #endregion
    }
}
