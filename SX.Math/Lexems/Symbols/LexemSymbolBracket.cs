using SX.Math.Enums;
using System;
using System.Linq;

namespace SX.Math.Lexems.Symbols
{
    public class LexemSymbolBracket : LexemSymbol
    {
        static public SymbolPair[] BRACKETS = { new SymbolPair('(', ')'), new SymbolPair('{', '}'), new SymbolPair('[', ']') };

        public override LexemSymbolType SymbolType { get => LexemSymbolType.Bracket; }

        private LexemSymbolBracket? _simetric = null;
        public LexemSymbolBracket? Simetric
        {
            get { return _simetric; }
            set
            {
                _simetric = value;
                if (_simetric != null && _simetric.Simetric != this)
                    _simetric.Simetric = this;
            }
        }

        public LexemSymbolBracket(string text)
            : base(text)
        {
            if (!BRACKETS.Any(br => br.Contains(this.Text)))
                throw new FormatException("Unknown Bracket input");
        }

        //static public LexemBracket? ParseSymbolBracket(ref string? text)
        //{
        //    if (String.IsNullOrEmpty(text))
        //        return null;

        //    text = text.Trim();

        //    var input = text;
        //    var item = BRACKETS.SelectMany(p => new string[] { p.Open, p.Close }).FirstOrDefault(symb => input.StartsWith(symb));
        //    if (String.IsNullOrEmpty(item))
        //        return null;

        //    text = text.Crop(item.Length);

        //    return new LexemBracket(item);
        //}
    }
}
