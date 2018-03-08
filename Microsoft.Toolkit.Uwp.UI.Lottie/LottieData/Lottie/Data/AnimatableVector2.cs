using System.Collections.Generic;
using System.Numerics;

namespace Lottie.Data
{
    public sealed class AnimatableVector2 : AnimatableValue<Vector2>
    {
            
        public AnimatableVector2() : this(s_emptyKeyFrames, new Vector2())
        {
        }

        public AnimatableVector2(IEnumerable<KeyFrame<Vector2>> keyframes, Vector2 initialValue) 
            : base(keyframes, initialValue)
        {
            IsSplitDimension = false;
        }

        public AnimatableVector2(AnimatableValue<float> xDimension, AnimatableValue<float> yDimension) 
            : base(s_emptyKeyFrames, new Vector2(xDimension.InitialValue, yDimension.InitialValue))
        {
            XDimension = xDimension;
            YDimension = yDimension;

            IsSplitDimension = true;
        }

        public bool IsSplitDimension { get; }
        public AnimatableValue<float> XDimension { get; }
        public AnimatableValue<float> YDimension { get; }
    }
}


