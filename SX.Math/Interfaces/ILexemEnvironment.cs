using SX.Math.Lexems.Values;
using SX.Math.Lexems;
using System.Collections.Generic;

namespace SX.Math.Interfaces
{
    public interface ILexemEnvironment
    {
        ICollection<LexemVariable> Variables { get; }

        void Clear();

        LexemVariable? Get(string name);
        LexemVariable Set(string name, LexemValue value);

        LexemVariable Calculate(LexemFunction function);
        LexemVariable Execute(LexemValue argument, Lexem lexem);
    }

}
