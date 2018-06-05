namespace WinCompData.Expressions
{
#if !WINDOWS_UWP
    public
#endif
    sealed class LessThen : BinaryExpression
    {
        public LessThen(Expression left, Expression right) : base(left, right)
        {
        }

        // TODO - could be simplified to a constant bool in some circumstances.
        public override Expression Simplified => this;

        public override string ToString() => $"{Parenthesize(Left.Simplified)} < {Parenthesize(Right.Simplified)}";

        public override ExpressionType InferredType => 
            ExpressionType.AssertMatchingTypes(TypeConstraint.Scalar, Left.InferredType, Right.InferredType, TypeConstraint.Boolean);
    }
}
