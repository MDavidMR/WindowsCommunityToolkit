using System;

namespace LottieToWinComp
{
#if PUBLIC
    public
#endif
    static class TranslationIssues
    {
        public enum Id
        {
            AnimatedRectangleWithTrimPath,
            AnimatedTrimOffsetWithStaticTrimOffset,
            AnimationMultiplication,
            BlendModeColor,
            BlendModeColorBurn,
            BlendModeColorDodge,
            BlendModeDarken,
            BlendModeDifference,
            BlendModeExclusion,
            BlendModeHardLight,
            BlendModeHue,
            BlendModeLighten,
            BlendModeLuminosity,
            BlendModeMultiply,
            BlendModeOverlay,
            BlendModeSaturation,
            BlendModeScreen,
            BlendModeSoftLight,
            CombiningAnimatedShapes,
            GradientFill,
            GradientStroke,
            ImageAssets,
            ImageLayer,
            MergingALargeNumberOfShapes,
            MultipleAnimatedRoundedCorners,
            MultipleFills,
            MultipleStrokes,
            MultipleTrimPaths,
            OpacityAndColorAnimatedTogether,
            PathWithRoundedCorners,
            Polystar,
            Repeater,
            TextLayer,
            ThreeD,
            ThreeDLayer,
            TimeStretch,
        }

        /// <summary>
        /// Get the code and description for the given id.
        /// </summary>
        public static (string Code, string Description) GetIssueById(Id id)
        {
            switch (id)
            {
                case Id.AnimatedRectangleWithTrimPath:
                    return ("LT0001", "Rectangle with animated size and TrimPath");
                case Id.AnimatedTrimOffsetWithStaticTrimOffset:
                    return ("LT0002", "Animated trim offset with static trim offset");
                case Id.AnimationMultiplication:
                    return ("LT0003", "Multiplication of two or more animated values");
                case Id.BlendModeColor:
                    return ("LT0004", "Blend mode color");
                case Id.BlendModeColorBurn:
                    return ("LT0005", "Blend mode color burn");
                case Id.BlendModeColorDodge:
                    return ("LT0006", "Blend mode color dodge");
                case Id.BlendModeDarken:
                    return ("LT0007", "Blend mode darken");
                case Id.BlendModeDifference:
                    return ("LT0008", "Blend mode difference");
                case Id.BlendModeExclusion:
                    return ("LT0009", "Blend mode exclusion");
                case Id.BlendModeHardLight:
                    return ("LT0010", "Blend mode hard light");
                case Id.BlendModeHue:
                    return ("LT0011", "Blend mode hue");
                case Id.BlendModeLighten:
                    return ("LT0012", "Blend mode lighten");
                case Id.BlendModeLuminosity:
                    return ("LT0013", "Blend mode luminosity");
                case Id.BlendModeMultiply:
                    return ("LT0014", "Blend mode multiply");
                case Id.BlendModeOverlay:
                    return ("LT0015", "Blend mode overlay");
                case Id.BlendModeSaturation:
                    return ("LT0016", "Blend mode saturation");
                case Id.BlendModeScreen:
                    return ("LT0017", "Blend mode screen");
                case Id.BlendModeSoftLight:
                    return ("LT0018", "Blend mode soft light");
                case Id.CombiningAnimatedShapes:
                    return ("LT0019", "Combining animated shapes");
                case Id.GradientFill:
                    return ("LT0020", "Gradient fill");
                case Id.GradientStroke:
                    return ("LT0021", "Gradient stroke");
                case Id.ImageAssets:
                    return ("LT0022", "Image assets");
                case Id.ImageLayer:
                    return ("LT0023", "Image layers");
                case Id.MergingALargeNumberOfShapes:
                    return ("LT0024", "Merging a large number of shapes");
                case Id.MultipleAnimatedRoundedCorners:
                    return ("LT0025", "Multiple animated rounded corners");
                case Id.MultipleFills:
                    return ("LT0026", "Multiple fills");
                case Id.MultipleStrokes:
                    return ("LT0027", "Multiple strokes");
                case Id.MultipleTrimPaths:
                    return ("LT0028", "Multiple trim paths");
                case Id.OpacityAndColorAnimatedTogether:
                    return ("LT0029","Opacity and color animated at the same time");
                case Id.PathWithRoundedCorners:
                    return ("LT0030", "Path with rounded corners");
                case Id.Polystar:
                    return ("LT0031", "Polystar");
                case Id.Repeater:
                    return ("LT0032", "Repeater");
                case Id.TextLayer:
                    return ("LT0033", "Text layer");
                case Id.ThreeD:
                    return ("LT0034", "3d Composition");
                case Id.ThreeDLayer:
                    return ("LT0035", "3d layer");
                case Id.TimeStretch:
                    return ("LT0036", "Time stretch");
                default:
                    throw new ArgumentException();
            }
        }
    }
}
