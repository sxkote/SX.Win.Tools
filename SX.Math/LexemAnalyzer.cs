using SX.Math.Enums;
using SX.Math.Lexems;
using SX.Math.Lexems.Symbols;
using System;
using System.Linq;

namespace SX.Math
{
    public abstract class LexemAnalyser
    {
        #region Analys
        protected abstract void Analyze(LexemSequence lexems);

        protected virtual void AnalyzeExpression(LexemSequence lexems)
        {
            if (lexems == null)
                throw new ArgumentException("Lexems should be provided to analyze expression");

            // if the first operator is '-' then insert leading 0 to be: 0 - ...
            var firstOperator = lexems.FirstOrDefault() as LexemSymbolOperator;
            if (firstOperator != null && firstOperator.Operator == LexemOperatorType.Minus)
                lexems.Insert(0, 0);

            for (int i = 0; i < lexems.Count; i++)
            {
                var lexem = lexems[i];

                if (lexem is LexemSymbolBracket)
                {
                    i = this.SkipBrackets(lexems, i);
                }
                else if (lexem is LexemSymbolSwitch lexemSwitch && lexem.ToString() == "?")
                {
                    var lexemElse = lexemSwitch.Simetric ?? throw new FormatException("Switch syntax should have simetric Else path");

                    int elseIndex = lexems.Find(lexemElse);
                    if (elseIndex <= i)
                        throw new FormatException("Switch syntax balance is incorrect");

                    var switchCondition = lexems.Range(0, i);
                    var switchThenStatement = lexems.Range(i + 1, elseIndex - i - 1);
                    var switchElseStatement = lexems.Range(elseIndex + 1, lexems.Count - elseIndex - 1);

                    this.AnalyzeSwitch(lexemSwitch, switchCondition, switchThenStatement, switchElseStatement);

                    return;
                }
            }

            this.AnalyzeLogical(lexems);
        }

        protected void AnalyzeLogical(LexemSequence lexems) => this.AnalyzeLogicalOr(lexems);

        protected virtual void AnalyzeLogicalOr(LexemSequence lexems)
        {
            this.Scan(lexems, LexemOperationType.Logical, new LexemOperatorType[] { LexemOperatorType.Or }, this.AnalyzeLogicalAnd);
        }

        protected virtual void AnalyzeLogicalAnd(LexemSequence lexems)
        {
            this.Scan(lexems, LexemOperationType.Logical, new LexemOperatorType[] { LexemOperatorType.And }, this.AnalyzeComparison);
        }

        protected virtual void AnalyzeComparison(LexemSequence lexems)
        {
            this.Scan(lexems, LexemOperationType.Comparison, null, this.AnalyzeArithmetic);
        }

        protected void AnalyzeArithmetic(LexemSequence lexems) => this.AnalyzeArithmeticAddition(lexems);

        protected virtual void AnalyzeArithmeticAddition(LexemSequence lexems)
        {
            this.Scan(lexems, LexemOperationType.Arithmetic, new LexemOperatorType[] { LexemOperatorType.Plus, LexemOperatorType.Minus }, this.AnalyzeArithmeticMultiplication);
        }

        protected virtual void AnalyzeArithmeticMultiplication(LexemSequence lexems)
        {
            this.Scan(lexems, LexemOperationType.Arithmetic, new LexemOperatorType[] { LexemOperatorType.Multiply, LexemOperatorType.Divide }, this.AnalyzeElement);
        }

        protected virtual void AnalyzeElement(LexemSequence lexems)
        {
            if (lexems == null || lexems.Count <= 0)
                throw new FormatException("Analys Element is empty");

            // if the only one lexem 
            if (lexems.Count == 1)
            {
                this.AnalyzeLexem(lexems[0]);
            }
            // if sequence in balanced brackets
            else if (lexems[0] is LexemSymbolBracket lexemBracket && lexems.Find(lexemBracket.Simetric) == lexems.Count - 1)
            {
                this.AnalyzeSequence(lexems);
            }
            // code operation
            else
            {
                this.Scan(lexems, LexemOperationType.Code, new LexemOperatorType[] { LexemOperatorType.Pointer, LexemOperatorType.Property }, this.Error);
            }
        }

        protected abstract void AnalyzeSwitch(LexemSymbolSwitch lexem, LexemSequence condition, LexemSequence then, LexemSequence other);

        protected abstract void AnalyzeOperator(LexemSymbolOperator op, LexemSequence left, LexemSequence right);

        protected abstract void AnalyzeLexem(Lexem lexem);

        protected abstract void AnalyzeSequence(LexemSequence lexems);
        #endregion

        #region Functions
        protected void Scan(LexemSequence lexems, LexemOperationType type, LexemOperatorType[]? operators, Action<LexemSequence> action, bool parseFromLeftToRight = false)
        {
            //обычный разбор выражения должен идти справа налево (<-)
            //например, попробуйте построить полиз для выражения: a-b+c или a/b*c
            //только разбирая одноуровневые операции справа налево получится корректный полиз!!!

            for (int i = parseFromLeftToRight ? 0 : lexems.Count - 1; 0 <= i && i < lexems.Count; i += (parseFromLeftToRight ? 1 : -1))
            {
                var lexem = lexems[i];

                if (lexem is LexemSymbolBracket)
                {
                    i = this.SkipBrackets(lexems, i, parseFromLeftToRight);
                }
                else if (lexem is LexemSymbolOperator lexemOperator && lexemOperator.Operation == type)
                {
                    if (operators == null || operators.Contains(lexemOperator.Operator))
                    {
                        this.AnalyzeOperator(lexemOperator, lexems.Range(0, i), lexems.Range(i + 1, lexems.Count - i - 1));
                        return;
                    }
                }
            }

            if (action != null)
                action(lexems);
        }

        protected void Error(LexemSequence lexems)
        {
            throw new FormatException($"Expression syntax not recognized: {lexems}");
        }

        protected int SkipBrackets(LexemSequence lexems, int index, bool forward = true)
        {
            var bracket = lexems[index] as LexemSymbolBracket;
            if (bracket == null)
                return index;

            var result = index;

            if (bracket.Simetric != null)
                result = lexems.Find(bracket.Simetric);

            if (forward && result <= index || !forward && result >= index)
                throw new FormatException($"Brackets balance is incorrect: {lexems}");

            return result;
        }
        #endregion
    }
}
