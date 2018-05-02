namespace LottieToWinComp.Expressions
{
    sealed class LessThen : Expression
    {
        public Expression Left { get; }
        public Expression Right { get; }

        public LessThen(Expression left, Expression right)
        {
            Left = left;
            Right = right;
        }

        public override string ToString() => $"{Left} < {Right}";
    }
}
