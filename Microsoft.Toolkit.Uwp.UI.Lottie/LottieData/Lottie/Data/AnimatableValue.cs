using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lottie.Data
{
    /// <summary>
    /// A property value that may be animated.
    /// </summary>
    /// <typeparam name="T">The type of the property.</typeparam>
    public class AnimatableValue<T>
    {
        internal static readonly IEnumerable<KeyFrame<T>> s_emptyKeyFrames = new KeyFrame<T>[0];

        public AnimatableValue()
            : this(default(T))
        { }

        public AnimatableValue(T value)
            : this(s_emptyKeyFrames, value)
        { }

        public AnimatableValue(IEnumerable<KeyFrame<T>> keyframes, T initialValue)
        {
            KeyFrames = keyframes;
            InitialValue = initialValue;

            Debug.Assert(keyframes.All(kf => kf != null));
        }

        public T InitialValue { get; }

        public IEnumerable<KeyFrame<T>> KeyFrames { get; }

        /// <summary>
        /// Returns true iff this value has any key frames.
        /// </summary>
        public bool HasAnimation => KeyFrames.Any();
    }
}