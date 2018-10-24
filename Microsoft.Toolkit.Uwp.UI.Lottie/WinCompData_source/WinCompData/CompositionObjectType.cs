// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

namespace WinCompData
{
#if !WINDOWS_UWP
    public
#endif
    enum CompositionObjectType
    {
        AnimationController,
        ColorKeyFrameAnimation,
        CompositionColorBrush,
        CompositionContainerShape,
        CompositionEllipseGeometry,
        CompositionGeometricClip,
        CompositionPathGeometry,
        CompositionPropertySet,
        CompositionRectangleGeometry,
        CompositionRoundedRectangleGeometry,
        CompositionSpriteShape,
        CompositionViewBox,
        ContainerVisual,
        CubicBezierEasingFunction,
        ExpressionAnimation,
        InsetClip,
        LinearEasingFunction,
        PathKeyFrameAnimation,
        ScalarKeyFrameAnimation,
        ShapeVisual,
        StepEasingFunction,
        Vector2KeyFrameAnimation,
        Vector3KeyFrameAnimation,
    }
}
