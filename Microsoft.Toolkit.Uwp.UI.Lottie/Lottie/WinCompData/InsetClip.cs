namespace WinCompData
{
#if !WINDOWS_UWP
    public
#endif
    sealed class InsetClip : CompositionClip
    {
        internal InsetClip() { }

        public float? LeftInset { get; set; }
        public float? RightInset { get; set; }
        public float? BottomInset { get; set; }
        public float? TopInset { get; set; }

        public override ConcreteClassType Type => ConcreteClassType.InsetClip;
    }

}
