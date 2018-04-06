namespace LottieData
{
#if !WINDOWS_UWP
    public
#endif
    abstract class ShapeLayerContent
    {
        internal ShapeLayerContent(string name, string matchName)
        {
            Name = name;
            MatchName = matchName;
        }
        /// <summary>
        /// Gets the <see cref="ShapeContentType"/> of the <see cref="ShapeLayerContent"/> object.
        /// </summary>
        public abstract ShapeContentType ContentType { get; }

        public string Name { get; }
        public string MatchName { get; }

        /// <summary>
        /// Types of <see cref="ShapeLayerContent"/> objects.
        /// </summary>
        public enum ShapeContentType
        {
            Group,
            SolidColorStroke,
            LinearGradientStroke,
            RadialGradientStroke,
            SolidColorFill,
            LinearGradientFill,
            RadialGradientFill,
            Transform,
            Path,
            Ellipse,
            Rectangle,
            Polystar,
            TrimPath,
            MergePaths,
            Repeater,
            RoundedCorner,
        }
    }
}
