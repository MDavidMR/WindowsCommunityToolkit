using System;
using System.Collections.Generic;
using System.Linq;

namespace WinCompData
{
#if !WINDOWS_UWP
    public
#endif
    abstract class KeyFrameAnimation_ : CompositionAnimation
    {
        public TimeSpan Duration { get; set; }

        internal KeyFrameAnimation_(KeyFrameAnimation_ other) : base(other) { }
    }

#if !WINDOWS_UWP
    public
#endif
    abstract class KeyFrameAnimation<T> : KeyFrameAnimation_
    {
        readonly Dictionary<float, KeyFrame> _keyFrames = new Dictionary<float, KeyFrame>();

        protected KeyFrameAnimation(KeyFrameAnimation<T> other) : base(other)
        {
            if (other != null)
            {
                CopyStateFrom(other);
            }
        }

        public void InsertKeyFrame(float progress, T value, CompositionEasingFunction easing)
        {
            if (progress < 0 || progress > 1)
            {
                throw new ArgumentException($"Progress must be >=0 and <=1. Value: {progress}");
            }

            _keyFrames.Add(progress, new KeyFrame { Progress = progress, Value = value, Easing = easing });
        }

        public IEnumerable<KeyFrame> KeyFrames => _keyFrames.Values.OrderBy(kf => kf.Progress);

        void CopyStateFrom(KeyFrameAnimation<T> other)
        {
            _keyFrames.Clear();
            foreach (var pair in other._keyFrames)
            {
                _keyFrames.Add(pair.Key, pair.Value);
            }
            Duration = other.Duration;
            Target = other.Target;
        }

        public sealed class KeyFrame
        {
            public float Progress { get; internal set; }
            public T Value { get; internal set; }
            public CompositionEasingFunction Easing { get; internal set; }
        }
    }
}
