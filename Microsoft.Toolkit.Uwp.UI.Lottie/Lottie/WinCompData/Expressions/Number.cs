// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using System;

namespace WinCompData.Expressions
{
    /// <summary>
    /// A literal number.
    /// </summary>
#if !WINDOWS_UWP
    public
#endif
    sealed class Number : Expression
    {
        public double Value { get; }
        public Number(double value)
        {
            Value = value;
        }

        public override string ToString() => ToString(Value);

        internal override bool IsAtomic => Value >= 0;

        public override Expression Simplified => this;

        internal static string ToString(double value)
        {
            // Do not use "G9" here - Composition expressions do not understand
            // scientific notation (e.g. 1.2E06)
            var fValue = (float)value;
            return Math.Floor(fValue) == fValue
                ? fValue.ToString("0")
                : fValue.ToString("0.0####################");
        }

        public override ExpressionType InferredType => new ExpressionType(TypeConstraint.Scalar);
    }
}
