using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lottie.Data
{
    public sealed class LottieComposition
    {
        readonly LayerContainer _layers;

        /// <summary>
        /// Creates a Lottie Composition object. 
        /// </summary>
        /// <param name="width">Width of animation canvas as specified in AfterEffects.</param>
        /// <param name="height">Height of animation canvas as specified in AfterEffects.</param>
        /// <param name="startFrame">Frame ID at which animation begins as specified in AfterEffects.</param>
        /// <param name="endFrame">Frame ID at which animation ends as specified in AfterEffects.</param>
        /// <param name="framesPerSecond">FrameRate (frames per second) at which animation data was generated in AfterEffects.</param>
        public LottieComposition(
            float width,
            float height,
            float startFrame,
            float endFrame,
            float framesPerSecond,
            Version version,
            LayerContainer layers)
        {
            Width = width;
            Height = height;
            StartFrame = startFrame;
            EndFrame = endFrame;
            FramesPerSecond = framesPerSecond;
            Duration = TimeSpan.FromSeconds(((endFrame - startFrame) / framesPerSecond));

            Version = version;

            _layers = layers;
        }

        public float FramesPerSecond { get; }
        public float Width { get; }
        public float Height { get; }
        public float StartFrame { get; }
        public float EndFrame { get; }
        public LayerContainer Layers => _layers;
        public TimeSpan Duration { get; }

        /// <summary>
        /// Lottie version.
        /// </summary>
        internal Version Version { get; }
    }
}