namespace WinCompData.Expressions
{
#if !WINDOWS_UWP
    public
#endif
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

        // TODO - can be simplified if the condition is a constant.
        public override Expression Simplified => this;
        public override string ToString()
            => $"{Parenthesize(Condition)} ? {Parenthesize(TrueValue)} : {Parenthesize(FalseValue)}";

        public override ExpressionType InferredType
        {
            get
            {
                return Condition.InferredType.Constraints.HasFlag(TypeConstraint.Boolean)
                    ? ExpressionType.ConstrainToTypes(TypeConstraint.AllValidTypes, TrueValue.InferredType, FalseValue.InferredType)
                    : new ExpressionType(TypeConstraint.NoType);
            }
        }

    }
}
