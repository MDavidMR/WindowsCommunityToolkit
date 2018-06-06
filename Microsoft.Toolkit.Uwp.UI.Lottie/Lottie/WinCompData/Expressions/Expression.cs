// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

namespace WinCompData.Expressions
{
#if !WINDOWS_UWP
    public
#endif
    abstract class Expression
    {
        protected Expression() { }

        /// <summary>
        /// A simplified form of the expression. May be the same as this.
        /// </summary>
        public virtual Expression Simplified => this;

        public virtual ExpressionType InferredType { get; } = new ExpressionType(TypeConstraint.NoType);

        public static Number Scalar(double value) => new Number(value);

        public static Divide Divide(Expression x, Expression y) => new Divide(x, y);

        public static Vector2 Constant(WinCompData.Sn.Vector2 value) => new Vector2(Scalar(value.X), Scalar(value.Y));

        public static TypeAssert Scalar(string name) => Name(name, TypeConstraint.Scalar);

        public static Max Max(Expression x, Expression y) => new Max(x, y);
        public static Min Min(Expression x, Expression y) => new Min(x, y);

        static TypeAssert Name(string name, TypeConstraint typeConstraint) => new TypeAssert(new Name(name), typeConstraint);

        public static TypeAssert Vector2(string name) => Name(name, TypeConstraint.Vector2);
        public static Vector2 Vector2(Expression x, Expression y) => new Vector2(x, y);

        public static Vector3 Vector3(Expression x, Expression y, Expression z) => new Vector3(x, y, z);

        protected static Squared Squared(Expression expression) => new Squared(expression);

        protected static Cubed Cubed(Expression expression) => new Cubed(expression);

        public static Sum Sum(Expression a, Expression b) => new Sum(a, b);
        public static Sum Sum(Expression a, Expression b, params Expression[] parameters)
        {
            var result = new Sum(a, b);
            foreach (var parameter in parameters)
            {
                result = new Sum(result, parameter);
            }
            return result;
        }
        public static Number Sum(Number a, Number b) => Scalar(a.Value + b.Value);

        public static Subtract Subtract(Expression a, Expression b) => new Subtract(a, b);

        public static Multiply Multiply(Expression a, Expression b) => new Multiply(a, b);

        public static Matrix3x2 Matrix3x2Zero => Matrix3x2.Zero;
        public static Matrix3x2 Matrix3x2Identity => Matrix3x2.Identity;

        protected static Multiply Multiply(Expression a, Expression b, params Expression[] parameters)
        {
            var result = new Multiply(a, b);
            foreach (var parameter in parameters)
            {
                result = new Multiply(result, parameter);
            }
            return result;
        }

        /// <summary>
        /// True iff the string form of the expression can be unambigiously
        /// parsed without parentheses.
        /// </summary>
        internal virtual bool IsAtomic => false;

        protected static string Parenthesize(Expression expression) =>
            expression.IsAtomic ? expression.ToString() : $"({expression})";

        protected static bool IsZero(Expression expression)
        {
            if (expression is Number numberExpression)
            {
                return numberExpression.Value == 0;
            }
            else if (expression is Vector2 vector2Expression)
            {
                return IsZero(vector2Expression.X) && IsZero(vector2Expression.Y);
            }
            else
            {
                return false;
            }
        }

        protected static bool IsOne(Expression expression)
        {
            if (expression is Number numberExpression)
            {
                return numberExpression.Value == 1;
            }
            else if (expression is Vector2 vector2Expression)
            {
                return IsOne(vector2Expression.X) && IsOne(vector2Expression.Y);
            }
            else
            {
                return false;
            }
        }

    }

}
