using Lottie;
using System;
using System.Numerics;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;

namespace Compositions
{
    sealed class LoadingAnimation : ICompositionSource
    {
        public void CreateInstance(
            Compositor compositor,
            out Visual rootVisual,
            out Vector2 size,
            out CompositionPropertySet progressPropertySet,
            out string progressPropertyName,
            out TimeSpan duration)
        {
            rootVisual = Instantiator.InstantiateComposition(compositor);
            size = new Vector2(200, 200);
            progressPropertySet = rootVisual.Properties;
            progressPropertyName = "AnimationProgress";
            duration = TimeSpan.FromTicks(6000000);
        }

        void ICompositionSource.ConnectSink(ICompositionSink sink)
        {
            CreateInstance(
                Window.Current.Compositor,
                out var rootVisual,
                out var size,
                out var progressPropertySet,
                out var progressPropertyName,
                out var duration);

            sink.SetContent(
                rootVisual,
                size,
                progressPropertySet,
                progressPropertyName,
                duration,
                null);
        }

        void ICompositionSource.DisconnectSink(ICompositionSink sink) { }

        sealed class Instantiator
        {
            readonly Compositor _c;
            readonly ExpressionAnimation _expressionAnimation;
            CompositionEllipseGeometry _compositionEllipseGeometry_0000;
            ContainerVisual _containerVisual_0000;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0000;
            LinearEasingFunction _linearEasingFunction_0000;

            internal static Visual InstantiateComposition(Compositor compositor)
                => new Instantiator(compositor).ContainerVisual_0000();

            Instantiator(Compositor compositor)
            {
                _c = compositor;
                _expressionAnimation = compositor.CreateExpressionAnimation();
            }

            ColorKeyFrameAnimation ColorKeyFrameAnimation_0000()
            {
                var result = _c.CreateColorKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(6000000);
                result.InsertKeyFrame(0, Color.FromArgb(0x00, 0xCA, 0xD0, 0xD4), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2F, Color.FromArgb(0xFF, 0xCA, 0xD0, 0xD4), CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.4F, Color.FromArgb(0xFF, 0xCA, 0xD0, 0xD4), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6F, Color.FromArgb(0x00, 0xCA, 0xD0, 0xD4), CubicBezierEasingFunction_0000());
                return result;
            }

            ColorKeyFrameAnimation ColorKeyFrameAnimation_0001()
            {
                var result = _c.CreateColorKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(6000000);
                result.InsertKeyFrame(0, Color.FromArgb(0x00, 0xCA, 0xD0, 0xD4), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2F, Color.FromArgb(0x00, 0xCA, 0xD0, 0xD4), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4F, Color.FromArgb(0xFF, 0xCA, 0xD0, 0xD4), CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.6F, Color.FromArgb(0xFF, 0xCA, 0xD0, 0xD4), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8F, Color.FromArgb(0x00, 0xCA, 0xD0, 0xD4), CubicBezierEasingFunction_0000());
                return result;
            }

            ColorKeyFrameAnimation ColorKeyFrameAnimation_0002()
            {
                var result = _c.CreateColorKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(6000000);
                result.InsertKeyFrame(0, Color.FromArgb(0x00, 0xCA, 0xD0, 0xD4), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4F, Color.FromArgb(0x00, 0xCA, 0xD0, 0xD4), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6F, Color.FromArgb(0xFF, 0xCA, 0xD0, 0xD4), CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.8F, Color.FromArgb(0xFF, 0xCA, 0xD0, 0xD4), LinearEasingFunction_0000());
                result.InsertKeyFrame(1, Color.FromArgb(0x00, 0xCA, 0xD0, 0xD4), CubicBezierEasingFunction_0000());
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0000()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0x00, 0xCA, 0xD0, 0xD4));
                result.StartAnimation("Color", ColorKeyFrameAnimation_0000());
                AnimationController controller;
                controller = result.TryGetAnimationController("Color");
                controller.Pause();
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "root.AnimationProgress";
                _expressionAnimation.SetReferenceParameter("root", ContainerVisual_0000());
                controller.StartAnimation("Progress", _expressionAnimation);
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0001()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0x00, 0xCA, 0xD0, 0xD4));
                result.StartAnimation("Color", ColorKeyFrameAnimation_0001());
                AnimationController controller;
                controller = result.TryGetAnimationController("Color");
                controller.Pause();
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "root.AnimationProgress";
                _expressionAnimation.SetReferenceParameter("root", ContainerVisual_0000());
                controller.StartAnimation("Progress", _expressionAnimation);
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0002()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0x00, 0xCA, 0xD0, 0xD4));
                result.StartAnimation("Color", ColorKeyFrameAnimation_0002());
                AnimationController controller;
                controller = result.TryGetAnimationController("Color");
                controller.Pause();
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "root.AnimationProgress";
                _expressionAnimation.SetReferenceParameter("root", ContainerVisual_0000());
                controller.StartAnimation("Progress", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0000()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(3.481F, -1.019F);
                result.Offset = new Vector2(68.269F, 101.019F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0001());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0001()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(3.481F, -1.019F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0000());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0002()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(3.481F, -1.019F);
                result.Offset = new Vector2(96.394F, 101.019F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0003());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0003()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(3.481F, -1.019F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0001());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0004()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(3.481F, -1.019F);
                result.Offset = new Vector2(124.519F, 101.019F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0005());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0005()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(3.481F, -1.019F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0002());
                return result;
            }

            CompositionEllipseGeometry CompositionEllipseGeometry_0000()
            {
                if (_compositionEllipseGeometry_0000 != null)
                {
                    return _compositionEllipseGeometry_0000;
                }
                var result = _compositionEllipseGeometry_0000 = _c.CreateEllipseGeometry();
                result.Center = new Vector2(0, 0);
                result.Radius = new Vector2(7.4815F, 7.4815F);
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0000()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0000();
                result.Geometry = CompositionEllipseGeometry_0000();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0001()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0001();
                result.Geometry = CompositionEllipseGeometry_0000();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0002()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0002();
                result.Geometry = CompositionEllipseGeometry_0000();
                return result;
            }

            ContainerVisual ContainerVisual_0000()
            {
                if (_containerVisual_0000 != null)
                {
                    return _containerVisual_0000;
                }
                var result = _containerVisual_0000 = _c.CreateContainerVisual();
                var propertySet = result.Properties;
                propertySet.InsertScalar("AnimationProgress", 0);
                var children = result.Children;
                children.InsertAtTop(ShapeVisual_0000());
                return result;
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0000()
            {
                if (_cubicBezierEasingFunction_0000 != null)
                {
                    return _cubicBezierEasingFunction_0000;
                }
                var result = _cubicBezierEasingFunction_0000 = _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0.833F, 0.833F));
                return result;
            }

            LinearEasingFunction LinearEasingFunction_0000()
            {
                if (_linearEasingFunction_0000 != null)
                {
                    return _linearEasingFunction_0000;
                }
                var result = _linearEasingFunction_0000 = _c.CreateLinearEasingFunction();
                return result;
            }

            ShapeVisual ShapeVisual_0000()
            {
                var result = _c.CreateShapeVisual();
                result.Size = new Vector2(200, 200);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0000());
                shapes.Add(CompositionContainerShape_0002());
                shapes.Add(CompositionContainerShape_0004());
                return result;
            }

        }
    }
}
