namespace WinCompData.Expressions
{
    /// <summary>
    /// Raises a value to the power of 2. 
    /// </summary>
#if !WINDOWS_UWP
    public
#endif
    sealed class Squared : Expression
    {
        public Squared(Expression value)
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
                    ? new Number(numberValue.Value * numberValue.Value)
                    : (Expression)this;
            }
        }

        public override string ToString() => $"Square({Value.Simplified})";

        internal override bool IsAtomic => true;

        public override ExpressionType InferredType
        {
            get
            {
                return new ExpressionType(TypeConstraint.AllValidTypes);
            }
        }


    }
}
