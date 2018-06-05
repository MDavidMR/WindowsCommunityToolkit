namespace WinCompData.Expressions
{
#if !WINDOWS_UWP
    public
#endif
    sealed class Matrix3x2 : Expression
    {
        readonly string _representation;

        Matrix3x2(string representation)
        {
            _representation = representation;
        }

        public static Matrix3x2 Zero { get; } =  new Matrix3x2("Matrix3x2(0,0,0,0,0,0)");
        public static Matrix3x2 Identity { get; } = new Matrix3x2("Matrix3x2(1,0,0,1,0,0)");

        public override Expression Simplified => this;

        public override string ToString() => _representation;

        internal override bool IsAtomic => true;

        public override ExpressionType InferredType => new ExpressionType(TypeConstraint.Matrix3x2);
    }
}
