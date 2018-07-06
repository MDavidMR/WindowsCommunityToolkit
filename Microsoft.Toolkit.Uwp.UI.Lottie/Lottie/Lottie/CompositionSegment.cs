// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

namespace Lottie
{
    /// <summary>
    /// Defines a segment of a composition that can be played by the <see cref="CompositionPlayer"/>.
    /// </summary>
    public sealed class CompositionSegment
    {
        public double FromProgress { get; }
        public double ToProgress { get; }
        public double PlaybackRate { get; }
        public bool IsLoopingEnabled { get; }

        public string Name { get; }
        public CompositionSegment(string name, double fromProgress, double toProgress, double playbackRate, bool isLoopingEnabled)
        {
            Name = name;
            FromProgress = fromProgress;
            ToProgress = toProgress;
            PlaybackRate = playbackRate;
            IsLoopingEnabled = isLoopingEnabled;
        }

        /// <summary>
        /// Defines a segment that plays from <paramref name="fromProgress"/> to <paramref name="toProgress"/>
        /// without looping or repeating.
        /// </summary>
        public CompositionSegment(string name, double fromProgress, double toProgress)
            : this(name, fromProgress, toProgress, playbackRate:1, isLoopingEnabled: false)
        {
        }
    }
}
