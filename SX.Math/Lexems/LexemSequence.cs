using SX.Math.Lexems.Symbols;
using SX.Math.Lexems.Values;
using SX.Math.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SX.Math.Lexems
{
    public class LexemSequence : List<Lexem>
    {
        public LexemSequence() { }
        public LexemSequence(ICollection<Lexem> collecion) : base(collecion) { }
        public LexemSequence(string text) { this.Parse(text); }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i] is LexemValueNumber lexemValueNumber && lexemValueNumber.Value < 0)
                    result += "(" + this[i].ToString() + ") ";
                else
                    result += this[i].ToString() + " ";
            }

            return result.Trim();
        }

        public void Parse(string text)
        {
            if (String.IsNullOrWhiteSpace(text))
                return;

            string? input = text.Trim();

            var pairs = LexemSymbolBracket.BRACKETS.ToList();
            pairs.Add(new SymbolPair('?', ':'));

            var balancer = new BracketsBalanceLexemValidator(pairs.ToArray());

            while (!String.IsNullOrWhiteSpace(input))
            {
                var lexem = Lexem.Parse(ref input);

                if (lexem == null)
                    throw new FormatException($"Input string '{input ?? ""}' can't be recognized as Lexems Sequence");

                if (lexem is LexemSymbolBracket || lexem is LexemSymbolSwitch)
                    balancer.Push(lexem);

                this.Add(lexem);

                input = String.IsNullOrWhiteSpace(input) ? null : input.Trim();
            }

            if (!balancer.IsBalanced)
                throw new FormatException($"Lexem Sequence '{text}' is not balanced");
        }

        public LexemSequence Range(int index, int count) => new LexemSequence(this.GetRange(index, count));

        public int Find(Lexem lexem) => this.FindIndex(lex => ReferenceEquals(lexem, lex));
    }
}
