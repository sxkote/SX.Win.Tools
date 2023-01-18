using SX.Math.Enums;
using SX.Math.Interfaces;
using SX.Math.Lexems;
using SX.Math.Lexems.Symbols;
using SX.Math.Lexems.Values;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SX.Math
{
    public class LexemExpression : LexemAnalyser
    {
        protected LexemVariable _variable = null;
        protected LexemSequence _lexems = new LexemSequence();
        
        public LexemExpression(string text)
        {
            this.Analyze(new LexemSequence(text));
        }

        public LexemExpression(ICollection<Lexem> collection)
        {
            this.Analyze(new LexemSequence(collection));
        }

        public override string ToString()
        {
            return _lexems.ToString();
        }

        public LexemVariable Calculate(ILexemEnvironment? environment = null)
        {
            var result = LexemPoliz.Create(_lexems).Calculate(environment);

            if (_variable != null && !String.IsNullOrEmpty(_variable.Name) && environment != null && result != null)
                environment.Set(_variable.Name, result.Value);

            return result;
        }

        #region Analys
        protected override void Analyze(LexemSequence lexems)
        {
            if (lexems.Count > 2 && lexems[0] is LexemVariable lexemVariable && lexems[1] is LexemSymbolOperator lexemOperator && lexemOperator.Operator == LexemOperatorType.Assign)
            {
                _variable = lexemVariable;

                if (String.IsNullOrEmpty(_variable.Name))
                    throw new FormatException("Assignable Variable Name is empty");

                this.AnalyzeExpression(lexems.Range(2, lexems.Count - 2));
            }
            else
                this.AnalyzeExpression(lexems);
        }

        protected override void AnalyzeSwitch(LexemSymbolSwitch lexem, LexemSequence condition, LexemSequence then, LexemSequence other)
        {
            this.AnalyzeLogical(condition);

            _lexems.Add(lexem);

            this.AnalyzeExpression(then);

            _lexems.Add(lexem.Simetric);

            this.AnalyzeExpression(other);
        }

        protected override void AnalyzeOperator(LexemSymbolOperator op, LexemSequence left, LexemSequence right)
        {
            switch (op.Operator)
            {
                case LexemOperatorType.Or:
                    {
                        this.AnalyzeLogicalOr(left);
                        _lexems.Add(op);
                        this.AnalyzeLogicalAnd(right);
                        return;
                    }
                case LexemOperatorType.And:
                    {
                        this.AnalyzeLogicalAnd(left);
                        _lexems.Add(op);
                        this.AnalyzeComparison(right);
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
                        _lexems.Add(op);
                        this.AnalyzeArithmetic(right);
                        return;
                    }
                case LexemOperatorType.Plus:
                case LexemOperatorType.Minus:
                    {
                        this.AnalyzeArithmeticAddition(left);
                        _lexems.Add(op);
                        this.AnalyzeArithmeticMultiplication(right);
                        return;
                    }
                case LexemOperatorType.Multiply:
                case LexemOperatorType.Divide:
                    {
                        this.AnalyzeArithmeticMultiplication(left);
                        _lexems.Add(op);
                        this.AnalyzeElement(right);
                        return;
                    }
                case LexemOperatorType.Pointer:
                case LexemOperatorType.Property:
                    {
                        this.AnalyzeElement(left);
                        _lexems.Add(op);
                        this.AnalyzeElement(right);
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
                throw new FormatException(String.Format("Expression Element not recognized: {0}", lexem.ToString()));
        }

        protected override void AnalyzeSequence(LexemSequence lexems)
        {
            _lexems.Add(lexems[0]);
            this.AnalyzeExpression(lexems.Range(1, lexems.Count - 2));
            _lexems.Add(lexems[lexems.Count - 1]);
        }
        #endregion

        #region Differentiating
        //public SXExpression Diff(string variable_name)
        //{ return new SXExpression(this.DiffExpression(this.lexems, variable_name)); }

        //protected SXLexemList DiffExpression(SXLexemList lexem_list, string variable_name)
        //{
        //    for (int i = 0; i < lexem_list.Count; i++)
        //    {
        //        if (lexem_list[i].Text == "(")
        //            if (((SXLexemBracket)lexem_list[i]).Simetric == null) return null;
        //            else i = lexem_list.IndexOf(((SXLexemBracket)lexem_list[i]).Simetric);
        //        else if (lexem_list[i].Text == "?")
        //        {
        //            if (((SXLexemSwitch)lexem_list[i]).Simetric == null) return null;
        //            int simetric_index = lexem_list.IndexOf(((SXLexemSwitch)lexem_list[i]).Simetric);

        //            SXLexemList result = new SXLexemList();

        //            SXLexemSwitch sw_q = new SXLexemSwitch("?");
        //            SXLexemSwitch sw_e = new SXLexemSwitch(":");
        //            sw_q.Simetric = sw_e;

        //            //result.AddRange(SXLexem.GetLexemList(SXLexem.ToString(lexem_list.GetRange(0, i))));
        //            result.AddRange(lexem_list.GetRange(0, i));
        //            result.Add(sw_q);
        //            sw_e.Start = sw_q.Start = result[0];

        //            SXLexemList result_part = this.DiffLogical(new SXLexemList(lexem_list.GetRange(i + 1, simetric_index - i - 1)), variable_name);
        //            if (result_part == null) return null;
        //            result.AddRange(result_part);
        //            result.Add(sw_e);

        //            result_part = this.DiffLogical(new SXLexemList(lexem_list.GetRange(simetric_index + 1, lexem_list.Count - simetric_index - 1)), variable_name);
        //            if (result_part == null) return null;
        //            result.AddRange(result_part);
        //            sw_q.End = sw_e.End = result_part[result_part.Count - 1];

        //            return result;
        //        }
        //    }

        //    return this.DiffLogical(lexem_list, variable_name);
        //}

        //protected SXLexemList DiffLogical(SXLexemList lexem_list, string variable_name)
        //{ return this.DiffLogical(lexem_list, variable_name, true); }

        //protected SXLexemList DiffLogical(SXLexemList lexem_list, string variable_name, bool addition)
        //{
        //    for (int i = lexem_list.Count - 1; i >= 0; i--)
        //    {
        //        if (lexem_list[i].Text == ")")
        //            if (((SXLexemBracket)lexem_list[i]).Simetric == null) return null;
        //            else i = lexem_list.IndexOf(((SXLexemBracket)lexem_list[i]).Simetric);
        //        else if ((addition && lexem_list[i].Text == "||") || (!addition && lexem_list[i].Text == "&&"))
        //        {
        //            SXLexemList result = this.DiffLogical(new SXLexemList(lexem_list.GetRange(0, i)), variable_name, addition);

        //            result.Add(new SXLexemOperator(lexem_list[i].Text));

        //            if (addition) result.AddRange(this.DiffLogical(new SXLexemList(lexem_list.GetRange(i + 1, lexem_list.Count - i - 1)), variable_name, false));
        //            else result.AddRange(this.DiffComparison(new SXLexemList(lexem_list.GetRange(i + 1, lexem_list.Count - i - 1)), variable_name));

        //            return result;
        //        }
        //    }
        //    return (addition) ? this.DiffLogical(lexem_list, variable_name, false) : this.DiffComparison(lexem_list, variable_name);
        //}

        //protected SXLexemList DiffComparison(SXLexemList lexem_list, string variable_name)
        //{
        //    for (int i = lexem_list.Count - 1; i >= 0; i--)
        //    {
        //        if (lexem_list[i].Text == ")")
        //            if (((SXLexemBracket)lexem_list[i]).Simetric == null) return null;
        //            else i = lexem_list.IndexOf(((SXLexemBracket)lexem_list[i]).Simetric);
        //        else if (lexem_list[i] is SXLexemOperator && ((SXLexemOperator)lexem_list[i]).TypeOperator == SXLexemOperator.SXLexemOperatorType.Comparison)
        //        {
        //            SXLexemList result = this.DiffArithmetic(new SXLexemList(lexem_list.GetRange(0, i)), variable_name);
        //            result.Add(new SXLexemOperator(lexem_list[i].Text));
        //            result.AddRange(this.DiffArithmetic(new SXLexemList(lexem_list.GetRange(i + 1, lexem_list.Count - i - 1)), variable_name));
        //            return result;
        //        }
        //    }
        //    return this.DiffArithmetic(lexem_list, variable_name);
        //}

        //protected SXLexemList DiffArithmetic(SXLexemList lexem_list, string variable_name)
        //{ return this.DiffArithmetic(lexem_list, variable_name, true); }

        //protected SXLexemList DiffArithmetic(SXLexemList lexem_list, string variable_name, bool addition)
        //{
        //    for (int i = lexem_list.Count - 1; i >= 0; i--)
        //    {
        //        if (lexem_list[i].Text == ")")
        //            if (((SXLexemBracket)lexem_list[i]).Simetric == null) return null;
        //            else i = lexem_list.IndexOf(((SXLexemBracket)lexem_list[i]).Simetric);
        //        else if (addition && (lexem_list[i].Text == "+" || lexem_list[i].Text == "-"))
        //        {
        //            SXLexemList result = this.DiffArithmetic(new SXLexemList(lexem_list.GetRange(0, i)), variable_name, true);
        //            result.Add(new SXLexemOperator(lexem_list[i].Text));
        //            result.AddRange(this.DiffArithmetic(new SXLexemList(lexem_list.GetRange(i + 1, lexem_list.Count - i - 1)), variable_name, false));
        //            return result;
        //        }
        //        else if (!addition && lexem_list[i].Text == "*")
        //        {
        //            SXLexemList left_hand = new SXLexemList(lexem_list.GetRange(0, i));
        //            SXLexemList right_hand = new SXLexemList(lexem_list.GetRange(i + 1, lexem_list.Count - i - 1));

        //            string result_string = "";
        //            result_string += "(";
        //            result_string += "(" + this.DiffArithmetic(left_hand, variable_name, addition).ToString() + ")";
        //            result_string += " * (" + right_hand.ToString() + ") + (" + left_hand.ToString() + ") * ";
        //            result_string += "(" + this.DiffElement(right_hand, variable_name).ToString() + ")";
        //            result_string += ")";

        //            return new SXLexemList(result_string);
        //        }
        //        else if (!addition && lexem_list[i].Text == "/")
        //        {
        //           SXLexemList left_hand = new SXLexemList(lexem_list.GetRange(0, i));
        //            SXLexemList right_hand = new SXLexemList(lexem_list.GetRange(i + 1, lexem_list.Count - i - 1));

        //            string result_string = "";
        //            result_string += "((";
        //            result_string += "(" + this.DiffArithmetic(left_hand, variable_name, addition).ToString() + ")";
        //            result_string += " * (" + right_hand.ToString() + ") - (" + left_hand.ToString() + ") * ";
        //            result_string += "(" + this.DiffElement(right_hand, variable_name) + ")";
        //            result_string += ") / (" + "pow(" + "(" + right_hand.ToString() + ")" + "; 2)" + "))";

        //            return new SXLexemList(result_string);
        //        }
        //    }
        //    return (addition) ? this.DiffArithmetic(lexem_list, variable_name, false) : this.DiffElement(lexem_list, variable_name);
        //}

        //protected SXLexemList DiffElement(SXLexemList lexem_list, string variable_name)
        //{
        //    if (lexem_list.Count == 1 && lexem_list[0] is SXLexemValue)
        //    { return new SXLexemList("0"); }

        //    if (lexem_list.Count == 1 && lexem_list[0] is SXLexemFunction)
        //    { return ((SXLexemFunction)lexem_list[0]).Diff(variable_name); }

        //    if (lexem_list.Count == 1 && lexem_list[0] is SXLexemVariable)
        //    { return (((SXLexemVariable)lexem_list[0]).Name == variable_name) ? new SXLexemList("1") : new SXLexemList("0"); }


        //    if (lexem_list.Count >= 2 && lexem_list[0].Text == "(" && lexem_list.IndexOf(((SXLexemBracket)lexem_list[0]).Simetric) == lexem_list.Count - 1)
        //    {
        //        SXLexemList result = new SXLexemList();
        //        SXLexemBracket br_opened = new SXLexemBracket("(");
        //        SXLexemBracket br_closed = new SXLexemBracket(")");
        //        br_opened.Simetric = br_closed;
        //        result.Add(br_opened);
        //        result.AddRange(this.DiffExpression(new SXLexemList(lexem_list.GetRange(1, lexem_list.Count - 2)), variable_name));
        //        result.Add(br_closed);
        //        return result;
        //    }

        //    return null;
        //}
        #endregion

        static public LexemVariable Calculate(string text, ILexemEnvironment environment = null)
        {
            return new LexemExpression(text).Calculate(environment);
        }
    }
}
