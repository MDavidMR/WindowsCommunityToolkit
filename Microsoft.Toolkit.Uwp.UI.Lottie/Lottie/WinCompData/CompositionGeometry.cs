namespace WinCompData
{
#if !WINDOWS_UWP
    public
#endif
    abstract class CompositionGeometry : CompositionObject
    {
        internal CompositionGeometry() { }
        public float? TrimEnd { get; set; } = 1;
        public float? TrimOffset { get; set; }
        public float? TrimStart { get; set; }

    }
}