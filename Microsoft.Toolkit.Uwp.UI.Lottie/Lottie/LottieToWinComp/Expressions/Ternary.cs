using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottieToWinComp.Expressions
{
    sealed class Ternary : Expression
    {
        public Ternary(Expression condition, Expression trueValue, Expression falseValue)
        {
            Condition = condition;
            TrueValue = trueValue;
            FalseValue = falseValue;

        }
        public Expression Condition;
        public Expression TrueValue;
        public Expression FalseValue;

        public override string ToString()
            => $"({Condition}) ? ({TrueValue}) : ({FalseValue})";
    }
}
