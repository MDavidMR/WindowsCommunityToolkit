using System;
using System.Collections.Generic;

namespace LottieData
{
#if !WINDOWS_UWP
    public
#endif
    sealed class LottieComposition
    {
        /// <summary>
        /// Creates a Lottie Composition object. 
        /// </summary>
        /// <param name="name">The name of the composition</param>
        /// <param name="width">Width of animation canvas as specified in AfterEffects.</param>
        /// <param name="height">Height of animation canvas as specified in AfterEffects.</param>
        /// <param name="startFrame">Frame at which animation begins as specified in AfterEffects.</param>
        /// <param name="endFrame">Frame at which animation ends as specified in AfterEffects.</param>
        /// <param name="framesPerSecond">FrameRate (frames per second) at which animation data was generated in AfterEffects.</param>
        public LottieComposition(
            string name,
            double width,
            double height,
            double startFrame,
            double endFrame,
            double framesPerSecond,
            bool is3d,
            Version version,
            AssetCollection assets,
            LayerCollection layers,
            IEnumerable<Marker> markers)
        {
            Name = name;
            Is3d = is3d;
            Width = width;
            Height = height;
            StartFrame = startFrame;
            EndFrame = endFrame;
            FramesPerSecond = framesPerSecond;
            Duration = TimeSpan.FromSeconds(((endFrame - startFrame) / framesPerSecond));
            Version = version;
            Layers = layers;
            Assets = assets;
        }

        public string Name { get; }
        public bool Is3d { get; }
        public double FramesPerSecond { get; }
        public double Width { get; }
        public double Height { get; }
        public double StartFrame { get; }
        public double EndFrame { get; }
        public IEnumerable<Marker> Markers { get; }
        public TimeSpan Duration { get; }
        public AssetCollection Assets { get; }
        public LayerCollection Layers { get; }
 
        /// <summary>
        /// Lottie version.
        /// </summary>
        internal Version Version { get; }
    }
}