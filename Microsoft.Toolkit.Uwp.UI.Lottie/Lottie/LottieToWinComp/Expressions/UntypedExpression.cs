using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottieToWinComp.Expressions
{
    sealed class UntypedExpression : Expression
    {
        readonly string _value;
        public UntypedExpression(string value)
        {
            _value = value;
        }

        public override string ToString() => _value;
    }
}
