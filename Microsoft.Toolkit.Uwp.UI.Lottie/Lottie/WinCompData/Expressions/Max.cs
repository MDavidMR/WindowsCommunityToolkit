namespace WinCompData.Expressions
{
#if !WINDOWS_UWP
    public
#endif
    sealed class Max : BinaryExpression
    {
        public Max(Expression left, Expression right) : base(left, right)
        {
        }

        // TODO - could be simplified to a constant in some circumstances.
        public override Expression Simplified => this;

        public override string ToString() => $"Max({Parenthesize(Left.Simplified)}, {Parenthesize(Right.Simplified)}";

        public override ExpressionType InferredType =>
            ExpressionType.ConstrainToTypes(
                TypeConstraint.Scalar | TypeConstraint.Vector2 | TypeConstraint.Vector3 | TypeConstraint.Vector4, 
                Left.InferredType, Right.InferredType);
    }
}
