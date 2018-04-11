using System;
using System.Collections.Generic;

namespace LottieData
{
#if !WINDOWS_UWP
    public
#endif
    sealed class LottieComposition : LottieObject
    {
        /// <summary>
        /// Creates a Lottie Composition object. 
        /// </summary>
        /// <param name="name">The name of the composition</param>
        /// <param name="width">Width of animation canvas as specified in AfterEffects.</param>
        /// <param name="height">Height of animation canvas as specified in AfterEffects.</param>
        /// <param name="inPoint">Frame at which animation begins as specified in AfterEffects.</param>
        /// <param name="outPoint">Frame at which animation ends as specified in AfterEffects.</param>
        /// <param name="framesPerSecond">FrameRate (frames per second) at which animation data was generated in AfterEffects.</param>
        public LottieComposition(
            string name,
            double width,
            double height,
            double inPoint,
            double outPoint,
            double framesPerSecond,
            bool is3d,
            Version version,
            AssetCollection assets,
            LayerCollection layers,
            IEnumerable<Marker> markers) : base(name)
        {
            Is3d = is3d;
            Width = width;
            Height = height;
            InPoint = inPoint;
            OutPoint = outPoint;
            FramesPerSecond = framesPerSecond;
            Duration = TimeSpan.FromSeconds(((outPoint - inPoint) / framesPerSecond));
            Version = version;
            Layers = layers;
            Assets = assets;
        }

        public bool Is3d { get; }
        public double FramesPerSecond { get; }
        public double Width { get; }
        public double Height { get; }

        /// <summary>
        /// The frame at which the animation begins.
        /// </summary>
        public double InPoint { get; }

        /// <summary>
        /// The frame at which the animation ends.
        /// </summary>
        public double OutPoint { get; }
        public IEnumerable<Marker> Markers { get; }
        public TimeSpan Duration { get; }
        public AssetCollection Assets { get; }
        public LayerCollection Layers { get; }

        public override LottieObjectType ObjectType => LottieObjectType.LottieComposition;
        /// <summary>
        /// Lottie version.
        /// </summary>
        internal Version Version { get; }
    }
}