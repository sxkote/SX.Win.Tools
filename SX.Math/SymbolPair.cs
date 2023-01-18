using System;

namespace SX.Math
{
    public struct Symbol
    {
        public string Text { get; private set; }

        public Symbol(string text)
        {
            if (String.IsNullOrEmpty(text))
                throw new ArgumentException("Symbol can't be null or empty");

            this.Text = text;
        }

        public override string ToString() => this.Text;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;

            if (obj is Symbol)
                return this.Text.Equals(((Symbol)obj).Text);

            return this.Text.Equals(obj.ToString());
        }

        public override int GetHashCode() => this.Text.GetHashCode();

        static public implicit operator string(Symbol symbol) => symbol.Text;

        static public implicit operator Symbol(string str) => new Symbol(str);

        static public implicit operator Symbol(char ch) => new Symbol(ch.ToString());
    }

    public class SymbolPair
    {
        public Symbol Open { get; private set; }
        public Symbol Close { get; private set; }

        public SymbolPair(Symbol open, Symbol close)
        {
            this.Open = open;
            this.Close = close;
        }

        public bool Contains(Symbol symbol) => this.Open == symbol || this.Close == symbol;
    }
}
