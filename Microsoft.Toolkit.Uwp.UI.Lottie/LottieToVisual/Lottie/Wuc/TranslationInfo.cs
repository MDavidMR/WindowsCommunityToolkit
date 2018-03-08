using System;

namespace Lottie.Wuc
{
    // Contains information about the translation.
    public sealed class TranslationInfo
    {
        internal int _containerShapeCount;
        internal int _spriteShapeCount;
        internal int _expressionAnimationCount;
        internal int _linearEasingFunctionCount;
        internal int _stepEasingFunctionCount;
        internal int _cubicBezierEasingFunctionCount;
        internal int _scalarKeyFrameAnimationCount;
        internal TimeSpan _translationTime;

        internal TranslationInfo() { }

        public override string ToString() =>
            $"Translation time: {_translationTime}, " +
            $"Linear easing functions: {_linearEasingFunctionCount}, " +
            $"Step easing functions: {_stepEasingFunctionCount}, " +
            $"Cubic bezier easing functions: {_cubicBezierEasingFunctionCount}, " +
            $"Container shapes: {_containerShapeCount}, " +
            $"Sprite shapes: {_spriteShapeCount}, " +
            $"Expression animations: {_expressionAnimationCount}, " +
            $"ScalarKeyFrame animations: {_scalarKeyFrameAnimationCount}";
    }
}
