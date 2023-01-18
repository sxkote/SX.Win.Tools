using SX.Math.Enums;
using System;
using System.Linq;

namespace SX.Math.Lexems.Symbols
{
    public class LexemSymbolComma : LexemSymbol
    {
        static public string[] COMMAS = { ",", ";" };

        public override LexemSymbolType SymbolType { get => LexemSymbolType.Comma; }

        public LexemSymbolComma(string text)
            : base(text)
        {
            if (!COMMAS.Contains(this.Text))
                throw new FormatException("Unknown Comma input");
        }

        //static public LexemComma? ParseSymbolComma(ref string? text)
        //{
        //    if (String.IsNullOrEmpty(text))
        //        return null;

        //    text = text.Trim();

        //    var input = text;
        //    var item = COMMAS.FirstOrDefault(o => input.StartsWith(o));
        //    if (String.IsNullOrEmpty(item))
        //        return null;

        //    text = text.Crop(item.Length);

        //    return new LexemComma(item);
        //}
    }
}
