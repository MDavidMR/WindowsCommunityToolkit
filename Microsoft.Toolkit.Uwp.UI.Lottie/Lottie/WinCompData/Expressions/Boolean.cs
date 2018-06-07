// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

namespace WinCompData.Expressions
{
    /// <summary>
    /// A literal boolean, i.e. "true" or "false".
    /// </summary>
#if !WINDOWS_UWP
    public
#endif
    sealed class Boolean : Expression
    {
        public bool Value { get; }
        public Boolean(bool value)
        {
            Value = value;
        }

        public override string ToString() => Value ? "true" : "false";

        internal override bool IsAtomic => true;

        public override Expression Simplified => this;

        public override ExpressionType InferredType => new ExpressionType(TypeConstraint.Boolean);
    }
}
