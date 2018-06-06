// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

namespace WinCompData.Expressions
{
    /// <summary>
    /// Raises a value to the power of 3. 
    /// </summary>
#if !WINDOWS_UWP
    public
#endif
    sealed class Cubed : Expression
    {
        public Cubed(Expression value)
        {
            Value = value;
        }

        public Expression Value { get; }

        public override Expression Simplified
        {
            get
            {
                var simplifiedValue = Value.Simplified;
                var numberValue = simplifiedValue as Number;
                return (numberValue != null)
                    ? new Number(numberValue.Value * numberValue.Value * numberValue.Value)
                    : (Expression)this;
            }
        }

        internal override bool IsAtomic => true;

        public override string ToString()
        {
            var simplifiedValue = Value.Simplified;

            return $"Pow({simplifiedValue}, 3)";
        }

        public override ExpressionType InferredType => new ExpressionType(TypeConstraint.Scalar);
    }
}
