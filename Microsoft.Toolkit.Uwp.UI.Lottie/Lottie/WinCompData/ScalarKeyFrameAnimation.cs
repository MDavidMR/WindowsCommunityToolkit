namespace WinCompData
{
#if !WINDOWS_UWP
    public
#endif
    sealed class ScalarKeyFrameAnimation : KeyFrameAnimation<float>
    {     
        internal ScalarKeyFrameAnimation() : base(null) { }
        ScalarKeyFrameAnimation(ScalarKeyFrameAnimation other) : base(other) { }

        public override ConcreteClassType Type => ConcreteClassType.ScalarKeyFrameAnimation;
        internal override CompositionAnimation Clone() => new ScalarKeyFrameAnimation(this);
    }
}
