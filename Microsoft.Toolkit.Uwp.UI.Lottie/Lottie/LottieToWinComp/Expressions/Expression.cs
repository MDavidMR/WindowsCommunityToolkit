namespace LottieToWinComp.Expressions
{

    abstract class Expression
    {
        internal Expression() { }
        public static implicit operator Expression(double value)
            => new Number(value);
        public static implicit operator Expression(string value)
            => new UntypedExpression(value);
    }

}