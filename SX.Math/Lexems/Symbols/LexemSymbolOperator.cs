using SX.Math.Enums;
using SX.Math.Interfaces;
using SX.Math.Lexems.Values;
using System;
using System.Linq;

namespace SX.Math.Lexems.Symbols
{
    public class LexemSymbolOperator : LexemSymbol
    {

        static public readonly string[] OPERATORS = { "+", "-", "*", "/", "<=", ">=", "<", ">", "==", "!=", "||", "&&", "=", "->", "." };

        public override LexemSymbolType SymbolType { get => LexemSymbolType.Operator; }
        public LexemOperationType Operation { get; private set; }
        public LexemOperatorType Operator { get; private set; }

        public LexemSymbolOperator(string text)
            : base(text)
        {
            if (!OPERATORS.Contains(this.Text))
                throw new FormatException($"Unknown Operator input: {this.Text}");

            this.Operation = DefineOperationType(this.Text);
            this.Operator = DefineOperatorType(this.Text);
        }

        public LexemVariable? Compute(Lexem argument1, Lexem argument2, ILexemEnvironment? environment = null)
        {
            LexemValue? result = null;

            switch (this.Operation)
            {
                case LexemOperationType.Arithmetic:
                    {
                        var arg1 = LexemValue.GetValue(argument1);
                        var arg2 = LexemValue.GetValue(argument2);
                        if (arg1 == null || arg2 == null) return null;

                        if (arg1 is LexemValueNumber mathNumber1 && arg2 is LexemValueNumber mathNumber2)
                        {
                            switch (this.Operator)
                            {
                                case LexemOperatorType.Plus: return mathNumber1 + mathNumber2;
                                case LexemOperatorType.Minus: return mathNumber1 - mathNumber2;
                                case LexemOperatorType.Multiply: return mathNumber1 * mathNumber2;
                                case LexemOperatorType.Divide: return mathNumber1 / mathNumber2;
                            }
                        }
                        else if (arg1 is LexemValueComplex mathComplex1 && arg2 is LexemValueComplex mathComplex2)
                        {
                            if (this.Text == "+") result = mathComplex1 + mathComplex2;
                            else if (this.Text == "-") result = mathComplex1 - mathComplex2;
                            else if (this.Text == "*") result = mathComplex1 * mathComplex2;
                            else if (this.Text == "/") result = mathComplex1 / mathComplex2;

                            if (result != null && result is LexemValueComplex mathComplexResult && mathComplexResult.Im == 0)
                                result = mathComplexResult.Re;
                        }
                        else if (arg1 is LexemValueDate mathDate1 && arg2 is LexemValueSpan mathSpan2)
                        {
                            switch (this.Operator)
                            {
                                case LexemOperatorType.Plus: return mathDate1.Value + mathSpan2.Value;
                                case LexemOperatorType.Minus: return mathDate1.Value - mathSpan2.Value;
                            }
                        }
                        else if (arg1 is LexemValueSpan mathSpan1 && arg2 is LexemValueDate mathDate2)
                        {
                            if (this.Operator == LexemOperatorType.Plus)
                                return mathDate2.Value + mathSpan1.Value;
                        }
                        else if (arg1 is LexemValueDate mathD1 && arg2 is LexemValueDate mathD2)
                        {
                            if (this.Operator == LexemOperatorType.Minus)
                                return mathD1 - mathD2;
                        }
                        else if (arg1 is LexemValueText mathText1 && arg2 is LexemValueText mathText2)
                        {
                            if (this.Operator == LexemOperatorType.Plus)
                                return mathText1 + mathText2;
                        }

                        break;
                    }
                case LexemOperationType.Logical:
                    {
                        var arg1 = LexemValue.GetValue(argument1);
                        var arg2 = LexemValue.GetValue(argument2);
                        if (arg1 == null || arg2 == null) return null;

                        if (arg1 is LexemValueBool logicalBool1 && arg2 is LexemValueBool logicalBool2)
                        {
                            switch (this.Operator)
                            {
                                case LexemOperatorType.Or: return logicalBool1 || logicalBool2;
                                case LexemOperatorType.And: return logicalBool1 && logicalBool2;
                                default: throw new InvalidOperationException($"Invalid operation {this.Text} between booleans");
                            }
                        }

                        break;
                    }
                case LexemOperationType.Comparison:
                    {
                        var arg1 = LexemValue.GetValue(argument1);
                        var arg2 = LexemValue.GetValue(argument2);
                        if (arg1 == null || arg2 == null)
                            return null;

                        if (arg1 is LexemValueNumber comparisonNumber1 && arg2 is LexemValueNumber comparisonNumber2)
                        {
                            switch (this.Operator)
                            {
                                case LexemOperatorType.More: return comparisonNumber1 > comparisonNumber2;
                                case LexemOperatorType.MoreEq: return comparisonNumber1 >= comparisonNumber2;
                                case LexemOperatorType.Less: return comparisonNumber1 < comparisonNumber2;
                                case LexemOperatorType.LessEq: return comparisonNumber1 <= comparisonNumber2;
                                case LexemOperatorType.Equal: return comparisonNumber1 == comparisonNumber2;
                                case LexemOperatorType.NotEqual: return comparisonNumber1 != comparisonNumber2;
                            }
                        }
                        else if (arg1 is LexemValueComplex comparisonComplex1 && arg2 is LexemValueComplex comparisonComplex2)
                        {
                            switch (this.Operator)
                            {
                                case LexemOperatorType.More: return comparisonComplex1 > comparisonComplex2;
                                case LexemOperatorType.MoreEq: return comparisonComplex1 >= comparisonComplex2;
                                case LexemOperatorType.Less: return comparisonComplex1 < comparisonComplex2;
                                case LexemOperatorType.LessEq: return comparisonComplex1 <= comparisonComplex2;
                                case LexemOperatorType.Equal: return comparisonComplex1 == comparisonComplex2;
                                case LexemOperatorType.NotEqual: return comparisonComplex1 != comparisonComplex2;
                            }
                        }
                        else if (arg1 is LexemValueText comparisonText1 && arg2 is LexemValueText comparisonText2)
                        {
                            switch (this.Operator)
                            {
                                case LexemOperatorType.More: return comparisonText1 > comparisonText2;
                                case LexemOperatorType.MoreEq: return comparisonText1 >= comparisonText2;
                                case LexemOperatorType.Less: return comparisonText1 < comparisonText2;
                                case LexemOperatorType.LessEq: return comparisonText1 <= comparisonText2;
                                case LexemOperatorType.Equal: return comparisonText1 == comparisonText2;
                                case LexemOperatorType.NotEqual: return comparisonText1 != comparisonText2;
                            }
                        }
                        else if (arg1 is LexemValueDate comparisonDate1 && arg2 is LexemValueDate comparisonDate2)
                        {
                            switch (this.Operator)
                            {
                                case LexemOperatorType.More: return comparisonDate1 > comparisonDate2;
                                case LexemOperatorType.MoreEq: return comparisonDate1 >= comparisonDate2;
                                case LexemOperatorType.Less: return comparisonDate1 < comparisonDate2;
                                case LexemOperatorType.LessEq: return comparisonDate1 <= comparisonDate2;
                                case LexemOperatorType.Equal: return comparisonDate1 == comparisonDate2;
                                case LexemOperatorType.NotEqual: return comparisonDate1 != comparisonDate2;
                            }
                        }
                        else if (arg1 is LexemValueSpan comparisonSpan1 && arg2 is LexemValueSpan comparisonSpan2)
                        {
                            switch (this.Operator)
                            {
                                case LexemOperatorType.More: return comparisonSpan1 > comparisonSpan2;
                                case LexemOperatorType.MoreEq: return comparisonSpan1 >= comparisonSpan2;
                                case LexemOperatorType.Less: return comparisonSpan1 < comparisonSpan2;
                                case LexemOperatorType.LessEq: return comparisonSpan1 <= comparisonSpan2;
                                case LexemOperatorType.Equal: return comparisonSpan1 == comparisonSpan2;
                                case LexemOperatorType.NotEqual: return comparisonSpan1 != comparisonSpan2;
                            }
                        }

                        break;
                    }
                case LexemOperationType.Code:
                    {
                        if (this.Operator != LexemOperatorType.Pointer && this.Operator != LexemOperatorType.Property)
                            return null;

                        if (argument1 is LexemVariable codeVariable)
                            return codeVariable.Execute(argument2, environment);
                        else if (argument1 is LexemValue codeValue)
                            return codeValue.Execute(argument2, environment);
                        else
                            return null;
                    }
            }

            return result;
        }

        static public LexemSymbolOperator? ParseSymbolOperator(ref string? text)
        {
            if (String.IsNullOrEmpty(text))
                return null;

            text = text.Trim();

            var input = text;
            var item = OPERATORS.OrderByDescending(op => op.Length).FirstOrDefault(o => input.StartsWith(o));
            if (String.IsNullOrEmpty(item))
                return null;

            text = text.Crop(item.Length);

            return new LexemSymbolOperator(item);
        }

        static public LexemOperationType DefineOperationType(string text)
        {
            if (String.IsNullOrEmpty(text))
                return LexemOperationType.Code;

            switch (text)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                    return LexemOperationType.Arithmetic;

                case "<=":
                case ">=":
                case "<":
                case ">":
                case "==":
                case "!=":
                    return LexemOperationType.Comparison;

                case "||":
                case "&&":
                    return LexemOperationType.Logical;

                case "=":
                case "->":
                case ".":
                    return LexemOperationType.Code;

                default:
                    return LexemOperationType.Code;
            }
        }
        static public LexemOperatorType DefineOperatorType(string text)
        {
            if (String.IsNullOrEmpty(text))
                throw new ArgumentException($"Operator is empty!");

            switch (text)
            {
                case "+": return LexemOperatorType.Plus;
                case "-": return LexemOperatorType.Minus;
                case "*": return LexemOperatorType.Multiply;
                case "/": return LexemOperatorType.Divide;

                case "<=": return LexemOperatorType.LessEq;
                case ">=": return LexemOperatorType.MoreEq;
                case "<": return LexemOperatorType.Less;
                case ">": return LexemOperatorType.More;
                case "==": return LexemOperatorType.Equal;
                case "!=": return LexemOperatorType.NotEqual;

                case "||": return LexemOperatorType.Or;
                case "&&": return LexemOperatorType.And;

                case "=": return LexemOperatorType.Assign;
                case "->": return LexemOperatorType.Pointer;
                case ".": return LexemOperatorType.Property;

                default:
                    throw new ArgumentException($"Unrecognized Operator {text}!");
            }
        }
    }
}
