namespace Lottie.Data
{
    public abstract class ShapeLayerContent
    {
        internal ShapeLayerContent(string name)
        {
            Name = name;
        }
        /// <summary>
        /// Gets the <see cref="ShapeContentType"/> of the <see cref="ShapeLayerContent"/> object.
        /// </summary>
        public abstract ShapeContentType ContentType { get; }

        public string Name { get; }

        /// <summary>
        /// Types of <see cref="ShapeLayerContent"/> objects.
        /// </summary>
        public enum ShapeContentType
        {
            Group,
            SolidColorStroke,
            GradientStroke,
            SolidColorFill,
            GradientFill,
            Transform,
            Path,
            Ellipse,
            Rectangle,
            Polystar,
            TrimPath,
            MergePaths,
            Repeater
        }
    }
}
