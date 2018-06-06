// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

namespace WinCompData.Expressions
{
    /// <summary>
    /// Constraints its child <see cref="Expression"/> to a given set of types.
    /// </summary>
#if !WINDOWS_UWP
    public
#endif
    sealed class TypeAssert : Expression
    {
        readonly Expression _child;
        readonly TypeConstraint _constraints;

        public TypeAssert(Expression child, TypeConstraint constraints)
        {
            _child = child;
            _constraints = constraints;
        }

        public override Expression Simplified => this;

        // There is no syntax for a type assert, so just return the child syntax.
        public override string ToString() => _child.ToString();

        public override ExpressionType InferredType => ExpressionType.ConstrainToType(_constraints, _child.InferredType);

        internal override bool IsAtomic => _child.IsAtomic;
    }
}
