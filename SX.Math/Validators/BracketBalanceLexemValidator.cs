using SX.Math.Interfaces;
using SX.Math.Lexems.Symbols;
using SX.Math.Lexems;
using System.Collections.Generic;
using System.Linq;

namespace SX.Math.Validators
{
    internal class BracketsBalanceLexemValidator : IBracketsBalanceValidator<Lexem>
    {
        /// <summary>
        /// Collection of Brackets Pairs used in validation
        /// </summary>
        public List<SymbolPair> Pairs { get; private set; }

        /// <summary>
        /// Stack of Brackets in the input
        /// </summary>
        protected Stack<Lexem> _balance;

        /// <summary>
        /// Is the input is balanced
        /// </summary>
        public bool IsBalanced { get => _balance.Count <= 0; }

        public BracketsBalanceLexemValidator(params SymbolPair[] pairs)
        {
            this.Pairs = pairs == null ? new List<SymbolPair>() : new List<SymbolPair>(pairs);

            _balance = new Stack<Lexem>();
        }


        /// <summary>
        /// Push next item of the input
        /// </summary>
        /// <param name="value">Next item</param>
        public void Push(Lexem value)
        {
            if (value == null)
                return;

            // if the bracket is pushed
            var pair = this.Pairs.FirstOrDefault(p => p.Contains(value.ToString()));
            if (pair == null)
                return;

            // try to close open bracket
            if (value.ToString() == pair.Close && _balance.Count > 0 && _balance.Peek().ToString() == pair.Open)
            {
                var open = _balance.Pop();

                if (open is LexemSymbolBracket openBracket1 && value is LexemSymbolBracket valueBracket1)
                    openBracket1.Simetric = valueBracket1;

                if (open is LexemSymbolSwitch openBracket2 && value is LexemSymbolSwitch valueBracket2)
                    openBracket2.Simetric = valueBracket2;
            }
            else
                _balance.Push(value);
        }
    }
}
