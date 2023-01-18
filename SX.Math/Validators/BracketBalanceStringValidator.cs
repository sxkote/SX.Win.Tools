using SX.Math.Interfaces;
using SX.Math.Lexems.Values;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SX.Math.Validators
{
    internal class BracketsBalanceStringValidator : IBracketsBalanceValidator<string>
    {
        /// <summary>
        /// Collection of Brackets Pairs used in validation
        /// </summary>
        public List<SymbolPair> Pairs { get; private set; }

        /// <summary>
        /// Collection of Quotes used in validation
        /// </summary>
        public List<string> Quotes { get; private set; }

        /// <summary>
        /// Current Quote in the input
        /// </summary>
        protected string _currentQuote = "";

        /// <summary>
        /// Stack of Brackets in the input
        /// </summary>
        protected Stack<string> _balance;

        /// <summary>
        /// Is the input is balanced
        /// </summary>
        public bool IsBalanced { get => _balance.Count <= 0 && String.IsNullOrEmpty(_currentQuote); }

        public BracketsBalanceStringValidator(SymbolPair[] pairs, string[] quotes)
        {
            this.Pairs = pairs == null ? new List<SymbolPair>() : new List<SymbolPair>(pairs);
            this.Quotes = quotes == null ? new List<string>() : new List<string>(quotes);

            _currentQuote = "";
            _balance = new Stack<string>();
        }

        public BracketsBalanceStringValidator(params SymbolPair[] pairs)
            : this(pairs, LexemValueText.QUOTES) { }

        /// <summary>
        /// Push next item of the input
        /// </summary>
        /// <param name="value">Next item</param>
        public void Push(string value)
        {
            // we are already in the quoted text part
            if (!String.IsNullOrEmpty(_currentQuote))
            {
                if (value == _currentQuote)
                    _currentQuote = "";

                return;
            }

            // begin of the quoted text part
            if (this.Quotes.Contains(value))
            {
                _currentQuote = value;
                return;
            }

            // if the bracket is pushed
            var pair = this.Pairs.FirstOrDefault(p => p.Contains(value));
            if (pair == null)
                return;

            // try to close open bracket
            if (value == pair.Close && _balance.Count > 0 && _balance.Peek() == pair.Open)
                _balance.Pop();
            else
                _balance.Push(value);
        }
    }
}
