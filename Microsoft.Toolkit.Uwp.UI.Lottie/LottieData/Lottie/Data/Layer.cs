namespace Lottie.Data
{
    /// <summary>
    /// Base class for layer objects. 
    /// </summary>
    /// <remarks>
    /// Each <see cref="Layer"/>, apart from the root <see cref="PreCompLayer"/> belongs to a <see cref="PreCompLayer"/> and has 
    /// an index that determines its rendering order, and is also used to identify it as the owner of a set of transforms that
    /// can be inherited by other <see cref="Layer"/>s.</remarks>
    public abstract class Layer
    {
        protected Layer(
            string name,
            int layerId,
            int? parentId,
            string refId,
            AnimatableTransform transform,
            float timeStretch,
            float startProgress,
            float inFrame,
            float outFrame)
        {
            Name = name;
            Id = layerId;
            ParentId = parentId;
            RefId = refId;
            Transform = transform;
            TimeStretch = timeStretch;
            StartProgress = startProgress;
            InFrame = inFrame;
            OutFrame = outFrame;
        }

        public float InFrame { get; }
        public float OutFrame { get; }

        internal float TimeStretch { get; }

        internal float StartProgress { get; }

        public string Name { get; }

        public abstract LayerType Type { get; }

        public AnimatableTransform Transform { get; }

        /// <summary>
        /// Used to uniquely identify a <see cref="Layer"/> within the owning <see cref="LayerContainer"/>.
        /// </summary>
        internal int Id { get; }

        /// <summary>
        /// Identifies the <see cref="Layer"/> from which transforms are inherited,
        /// or null if no transforms are inherited.
        /// </summary>
        public int? ParentId { get; }

        /// <summary>
        /// The name of a <see cref="PreCompLayer"/> that contains this <see cref="Layer"/>.
        /// </summary>
        internal string RefId { get; }

        // These values must be kept in sync with the JSON format.
        // TODO - remove the dependency of the values on the JSON format.
        public enum LayerType
        {
            PreComp = 0,
            Solid = 1,
            Image = 2,
            Null = 3,
            Shape = 4,
            Text = 5,
        }
    }
}