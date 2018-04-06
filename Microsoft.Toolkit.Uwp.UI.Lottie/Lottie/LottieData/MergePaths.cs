namespace LottieData
{
#if !WINDOWS_UWP
    public
#endif
    sealed class MergePaths : ShapeLayerContent
    {
        public MergePaths(
            string name,
            string matchName,
            MergeMode mergeMode)
            : base(name, matchName)
        {
            Mode = mergeMode;
        }

        public MergeMode Mode { get; }
        public override ShapeContentType ContentType => ShapeContentType.MergePaths;

        public enum MergeMode
        {
            Merge,
            Add,
            Subtract,
            Intersect,
            ExcludeIntersections,
        }
    }
}
