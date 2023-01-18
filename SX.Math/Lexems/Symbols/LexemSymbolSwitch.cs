using SX.Math.Enums;
using System;

namespace SX.Math.Lexems.Symbols
{
    public class LexemSymbolSwitch : LexemSymbol
    {
        public override LexemSymbolType SymbolType { get => LexemSymbolType.Switch; }

        private LexemSymbolSwitch? _simetric = null;
        public LexemSymbolSwitch? Simetric
        {
            get { return _simetric; }
            set
            {
                _simetric = value;
                if (_simetric != null && _simetric.Simetric != this)
                    _simetric.Simetric = this;
            }
        }

        private Lexem? _end = null;
        public Lexem? End
        {
            get { return _end; }
            set
            {
                _end = value;
                if (this.Simetric != null && this.Simetric.End != value)
                    this.Simetric.End = value;
            }
        }

        public LexemSymbolSwitch(string text)
                : base(text)
        {
            if (this.Text != "?" && this.Text != ":")
                throw new FormatException("Unknown Switch input");
        }

        //static public LexemSwitch? ParseSymbolSwitch(ref string? text)
        //{
        //    if (String.IsNullOrEmpty(text))
        //        return null;

        //    text = text.Trim();
        //    if (!text.StartsWith("?") && !text.StartsWith(":"))
        //        return null;

        //    var result = new LexemSwitch(text[0].ToString());

        //    text = text.Crop(1);

        //    return result;
        //}
    }
}
