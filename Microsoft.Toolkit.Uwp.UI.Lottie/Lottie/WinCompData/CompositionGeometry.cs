namespace WinCompData
{
#if !WINDOWS_UWP
    public
#endif
    abstract class CompositionGeometry : CompositionObject
    {
        internal CompositionGeometry() { }
        public float? TrimStart { get; set; }
        public float? TrimEnd { get; set; } = 1;
        public float? TrimOffset { get; set; }

    }
}