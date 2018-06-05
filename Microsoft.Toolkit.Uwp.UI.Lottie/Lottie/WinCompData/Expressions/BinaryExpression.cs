namespace WinCompData.Expressions
{
#if !WINDOWS_UWP
    public
#endif
    abstract class BinaryExpression : Expression
    {
        public Expression Left { get; }
        public Expression Right { get; }
        internal BinaryExpression(Expression left, Expression right)
        {
            Left = left;
            Right = right;
        }
    }
}
