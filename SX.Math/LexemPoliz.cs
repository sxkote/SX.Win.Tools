using SX.Math.Lexems.Values;
using SX.Math.Lexems;
using System;
using System.Collections.Generic;
using SX.Math.Interfaces;
using SX.Math.Lexems.Symbols;
using SX.Math.Enums;

namespace SX.Math
{
    internal class LexemPoliz : LexemAnalyser
    {
        protected LexemSequence _lexems;

        protected LexemPoliz()
        {
            _lexems = new LexemSequence();
        }

        protected LexemPoliz(LexemSequence lexems)
        {
            _lexems = lexems;
        }

        public override string ToString() => _lexems?.ToString() ?? "";

        public LexemVariable Calculate(ILexemEnvironment? environment = null)
        {
            var stack = new Stack<Lexem>();

            for (int i = 0; i < _lexems.Count; i++)
            {
                if (_lexems[i] is LexemValue)
                {
                    stack.Push(_lexems[i]);
                }
                else if (_lexems[i] is LexemFunction lexemFunction)
                {
                    var prev = stack.Count <= 0 ? null : stack.Peek(); //i - 1 >= 0 ? _lexems[i - 1] : null;
                    var next = i + 1 < _lexems.Count ? _lexems[i + 1] : null;

                    if (prev != null && (prev is LexemValue || prev is LexemVariable) && next != null && next is LexemSymbolOperator nextOperator && nextOperator.Operation == LexemOperationType.Code)
                        stack.Push(_lexems[i]);
                    else
                        stack.Push(lexemFunction.Calculate(environment));
                }
                else if (_lexems[i] is LexemVariable lexemVariable)
                {
                    var variable = environment?.Get(lexemVariable.Name);
                    stack.Push(variable == null ? _lexems[i] : variable);
                }
                else if (_lexems[i] is LexemSymbolOperator lexemOperator)
                {
                    var argument2 = stack.Pop();
                    var argument1 = stack.Pop();

                    stack.Push(lexemOperator.Compute(argument1, argument2, environment));
                }
                else if (_lexems[i] is LexemSymbolSwitch lexemSwitch && _lexems[i].ToString() == "?")
                {
                    var condition = LexemValue.GetValue(stack.Pop()) as LexemValueBool;
                    if (condition == null)
                        throw new InvalidOperationException("Conditional expression should return boolean value");

                    var separatorIndex = _lexems.Find(lexemSwitch.Simetric);
                    var endIndex = _lexems.Find(lexemSwitch.End);

                    if (condition.Value)
                        stack.Push(new LexemPoliz(_lexems.Range(i + 1, separatorIndex - i - 1)).Calculate(environment));
                    else
                        stack.Push(new LexemPoliz(_lexems.Range(separatorIndex + 1, endIndex - separatorIndex)).Calculate(environment));

                    i = endIndex;
                }
                else
                    stack.Push(_lexems[i]);
            }

            if (stack.Count != 1)
                throw new InvalidOperationException("Resulting lexem should be a single one");

            Lexem result = stack.Pop();
            if (result is LexemVariable resultVariable)
                return resultVariable;
            else if (result is LexemValue resultValue)
                return resultValue;

            throw new InvalidOperationException("Resulting lexem should be Variable or Value type");
        }

        #region Analys
        protected override void Analyze(LexemSequence lexems) => this.AnalyzeExpression(lexems);

        protected override void AnalyzeSwitch(LexemSymbolSwitch lexem, LexemSequence condition, LexemSequence then, LexemSequence other)
        {
            this.AnalyzeLogical(condition);

            _lexems.Add(lexem);

            this.AnalyzeExpression(then);

            _lexems.Add(lexem.Simetric);

            this.AnalyzeExpression(other);

            lexem.End = _lexems[_lexems.Count - 1];
        }

        protected override void AnalyzeOperator(LexemSymbolOperator op, LexemSequence left, LexemSequence right)
        {
            switch (op.Operator)
            {
                case LexemOperatorType.Or:
                    {
                        this.AnalyzeLogicalOr(left);
                        this.AnalyzeLogicalAnd(right);
                        _lexems.Add(op);
                        return;
                    }
                case LexemOperatorType.And:
                    {
                        this.AnalyzeLogicalAnd(left);
                        this.AnalyzeComparison(right);
                        _lexems.Add(op);
                        return;
                    }
                case LexemOperatorType.Less:
                case LexemOperatorType.LessEq:
                case LexemOperatorType.More:
                case LexemOperatorType.MoreEq:
                case LexemOperatorType.Equal:
                case LexemOperatorType.NotEqual:
                    {
                        this.AnalyzeArithmetic(left);
                        this.AnalyzeArithmetic(right);
                        _lexems.Add(op);
                        return;
                    }
                case LexemOperatorType.Plus:
                case LexemOperatorType.Minus:
                    {
                        this.AnalyzeArithmeticAddition(left);
                        this.AnalyzeArithmeticMultiplication(right);
                        _lexems.Add(op);
                        return;
                    }
                case LexemOperatorType.Multiply:
                case LexemOperatorType.Divide:
                    {
                        this.AnalyzeArithmeticMultiplication(left);
                        this.AnalyzeElement(right);
                        _lexems.Add(op);
                        return;
                    }
                case LexemOperatorType.Pointer:
                case LexemOperatorType.Property:
                    {
                        this.AnalyzeElement(left);
                        this.AnalyzeElement(right);
                        _lexems.Add(op);
                        return;
                    }
            }
        }

        protected override void AnalyzeLexem(Lexem lexem)
        {
            if (lexem is LexemValue)
                _lexems.Add(lexem);
            else if (lexem is LexemVariable)
                _lexems.Add(lexem);
            else if (lexem is LexemFunction)
                _lexems.Add(lexem);
            else
                throw new FormatException($"Expression Element not recognized: {lexem.ToString()}");
        }

        protected override void AnalyzeSequence(LexemSequence lexems)
        {
            this.AnalyzeExpression(lexems.Range(1, lexems.Count - 2));
        }
        #endregion

        static public LexemPoliz Create(LexemSequence lexems)
        {
            var result = new LexemPoliz();
            result.Analyze(lexems);
            return result;
        }
    }
}
