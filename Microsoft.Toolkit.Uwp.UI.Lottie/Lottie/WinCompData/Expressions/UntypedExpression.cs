// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

namespace WinCompData.Expressions
{
#if !WINDOWS_UWP
    public
#endif
    sealed class UntypedExpression : Expression
    {
        readonly string _value;
        public UntypedExpression(string value)
        {
            _value = value;
        }

        public override Expression Simplified => this;

        public override string ToString() => _value;

        public override ExpressionType InferredType => new ExpressionType(TypeConstraint.AllValidTypes);
    }
}
