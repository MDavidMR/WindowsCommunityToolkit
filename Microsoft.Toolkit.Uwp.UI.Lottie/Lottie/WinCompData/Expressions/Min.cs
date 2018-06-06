// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

namespace WinCompData.Expressions
{
#if !WINDOWS_UWP
    public
#endif
    sealed class Min : BinaryExpression
    {
        public Min(Expression left, Expression right) : base(left, right)
        {
        }

        // TODO - could be simplified to a constant bool in some circumstances.
        public override Expression Simplified => this;

        public override string ToString() => $"Min({Parenthesize(Left.Simplified)}, {Parenthesize(Right.Simplified)})";

        public override ExpressionType InferredType =>
            ExpressionType.ConstrainToTypes(
                TypeConstraint.Scalar | TypeConstraint.Vector2 | TypeConstraint.Vector3 | TypeConstraint.Vector4,
                Left.InferredType, Right.InferredType);
    }
}
