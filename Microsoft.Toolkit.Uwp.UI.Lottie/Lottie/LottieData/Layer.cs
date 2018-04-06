namespace LottieData
{
    /// <summary>
    /// Base class for layer objects. 
    /// </summary>
    /// <remarks>
    /// Each <see cref="Layer"/>, apart from the root <see cref="PreCompLayer"/> belongs to a <see cref="PreCompLayer"/> and has 
    /// an index that determines its rendering order, and is also used to identify it as the owner of a set of transforms that
    /// can be inherited by other <see cref="Layer"/>s.</remarks>
#if !WINDOWS_UWP
    public
#endif
    abstract class Layer
    {
        protected Layer(
            string name,
            int layerId,
            int? parentId,
            bool isHidden,
            Transform transform,
            double timeStretch,
            double startFrame,
            double inFrame,
            double outFrame,
            BlendMode blendMode,
            bool is3d,
            bool autoOrient)
        {
            Name = name;
            Id = layerId;
            ParentId = parentId;
            IsHidden = isHidden;
            Transform = transform;
            TimeStretch = timeStretch;
            StartFrame = startFrame;
            InFrame = inFrame;
            OutFrame = outFrame;
            BlendMode = blendMode;
            Is3d = is3d;
            AutoOrient = autoOrient;
        }

        public bool AutoOrient { get; }

        public bool IsHidden { get; }
        public BlendMode BlendMode { get; }
        public double InFrame { get; }
        public double OutFrame { get; }

        internal double TimeStretch { get; }

        internal double StartFrame { get; }

        public string Name { get; }

        public abstract LayerType Type { get; }

        public Transform Transform { get; }

        public bool Is3d { get; }
        /// <summary>
        /// Used to uniquely identify a <see cref="Layer"/> within the owning <see cref="LayerContainer"/>.
        /// </summary>
        internal int Id { get; }

        /// <summary>
        /// Identifies the <see cref="Layer"/> from which transforms are inherited,
        /// or null if no transforms are inherited.
        /// </summary>
        public int? ParentId { get; }

        public enum LayerType
        {
            PreComp,
            Solid,
            Image,
            Null,
            Shape,
            Text,
        }
    }
}