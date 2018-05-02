using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottieToWinComp.Expressions
{
    sealed class Number : Expression
    {
        public double Value { get; }
        public Number(double value)
        {
            Value = value;
        }
        public override string ToString() => Value.ToString();
    }
}
