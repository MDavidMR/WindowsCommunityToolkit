using Lottie;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Geometry;
using System;
using System.Numerics;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;

namespace Compositions
{
    sealed class LoadingAnimation : Lottie.ICompositionSource
    {
        void ICompositionSource.ConnectSink(ICompositionSink sink)
        {
            var visual = new Instantiator(Window.Current.Compositor).CreateRootVisual();
            sink.SetContent(
                visual,
                new Vector2(200.0F, 200.0F),
                visual.Properties,
                "AnimationProgress",
                TimeSpan.FromTicks(6000000),
                null);
        }

        void ICompositionSource.DisconnectSink(ICompositionSink sink) { }

        sealed class Instantiator
        {
            readonly Compositor _c;
            CompositionColorBrush _CompositionColorBrush_0000;
            CompositionColorBrush _CompositionColorBrush_0001;
            CompositionColorBrush _CompositionColorBrush_0002;
            CompositionContainerShape _CompositionContainerShape_0000;
            CompositionContainerShape _CompositionContainerShape_0001;
            CompositionContainerShape _CompositionContainerShape_0002;
            CompositionContainerShape _CompositionContainerShape_0003;
            CompositionContainerShape _CompositionContainerShape_0004;
            CompositionContainerShape _CompositionContainerShape_0005;
            CompositionEllipseGeometry _CompositionEllipseGeometry_0000;
            CompositionEllipseGeometry _CompositionEllipseGeometry_0001;
            CompositionEllipseGeometry _CompositionEllipseGeometry_0002;
            CompositionSpriteShape _CompositionSpriteShape_0000;
            CompositionSpriteShape _CompositionSpriteShape_0001;
            CompositionSpriteShape _CompositionSpriteShape_0002;
            ContainerVisual _ContainerVisual_0000;
            CubicBezierEasingFunction _CubicBezierEasingFunction_0000;
            LinearEasingFunction _LinearEasingFunction_0000;
            ShapeVisual _ShapeVisual_0000;

            internal Instantiator(Compositor compositor)
            {
                _c = compositor;
            }

            ColorKeyFrameAnimation ColorKeyFrameAnimation_0000()
            {
                var result = _c.CreateColorKeyFrameAnimation();
                result.Target = "Color";
                result.Duration = TimeSpan.FromTicks(6000000);
                result.InsertKeyFrame(0, Color.FromArgb(0, 202, 208, 212), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2F, Color.FromArgb(255, 202, 208, 212), CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.4F, Color.FromArgb(255, 202, 208, 212), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6F, Color.FromArgb(0, 202, 208, 212), CubicBezierEasingFunction_0000());
                return result;
            }

            ColorKeyFrameAnimation ColorKeyFrameAnimation_0001()
            {
                var result = _c.CreateColorKeyFrameAnimation();
                result.Target = "Color";
                result.Duration = TimeSpan.FromTicks(6000000);
                result.InsertKeyFrame(0, Color.FromArgb(0, 202, 208, 212), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2F, Color.FromArgb(0, 202, 208, 212), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4F, Color.FromArgb(255, 202, 208, 212), CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.6F, Color.FromArgb(255, 202, 208, 212), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8F, Color.FromArgb(0, 202, 208, 212), CubicBezierEasingFunction_0000());
                return result;
            }

            ColorKeyFrameAnimation ColorKeyFrameAnimation_0002()
            {
                var result = _c.CreateColorKeyFrameAnimation();
                result.Target = "Color";
                result.Duration = TimeSpan.FromTicks(6000000);
                result.InsertKeyFrame(0, Color.FromArgb(0, 202, 208, 212), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4F, Color.FromArgb(0, 202, 208, 212), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6F, Color.FromArgb(255, 202, 208, 212), CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.8F, Color.FromArgb(255, 202, 208, 212), LinearEasingFunction_0000());
                result.InsertKeyFrame(1.0F, Color.FromArgb(0, 202, 208, 212), CubicBezierEasingFunction_0000());
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0000()
            {
                if (_CompositionColorBrush_0000 != null)
                {
                    return _CompositionColorBrush_0000;
                }
                var result = _c.CreateColorBrush(Color.FromArgb(0, 202, 208, 212));
                _CompositionColorBrush_0000 = result;
                {
                    var animation = ColorKeyFrameAnimation_0000();
                    result.StartAnimation("Color", animation);
                    {
                        var controller = result.TryGetAnimationController("Color");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0001()
            {
                if (_CompositionColorBrush_0001 != null)
                {
                    return _CompositionColorBrush_0001;
                }
                var result = _c.CreateColorBrush(Color.FromArgb(0, 202, 208, 212));
                _CompositionColorBrush_0001 = result;
                {
                    var animation = ColorKeyFrameAnimation_0001();
                    result.StartAnimation("Color", animation);
                    {
                        var controller = result.TryGetAnimationController("Color");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0001();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0002()
            {
                if (_CompositionColorBrush_0002 != null)
                {
                    return _CompositionColorBrush_0002;
                }
                var result = _c.CreateColorBrush(Color.FromArgb(0, 202, 208, 212));
                _CompositionColorBrush_0002 = result;
                {
                    var animation = ColorKeyFrameAnimation_0002();
                    result.StartAnimation("Color", animation);
                    {
                        var controller = result.TryGetAnimationController("Color");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0002();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0000()
            {
                if (_CompositionContainerShape_0000 != null)
                {
                    return _CompositionContainerShape_0000;
                }
                var result = _c.CreateContainerShape();
                _CompositionContainerShape_0000 = result;
                result.Comment = "ShapeLayer:'Shape Layer 2'";
                result.CenterPoint = new Vector2(3.481F, -1.019F);
                result.Offset = new Vector2(68.269F, 101.019F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0001());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0001()
            {
                if (_CompositionContainerShape_0001 != null)
                {
                    return _CompositionContainerShape_0001;
                }
                var result = _c.CreateContainerShape();
                _CompositionContainerShape_0001 = result;
                result.Comment = "Ellipse 1";
                result.Offset = new Vector2(3.481F, -1.019F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0000());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0002()
            {
                if (_CompositionContainerShape_0002 != null)
                {
                    return _CompositionContainerShape_0002;
                }
                var result = _c.CreateContainerShape();
                _CompositionContainerShape_0002 = result;
                result.Comment = "ShapeLayer:'Shape Layer 1'";
                result.CenterPoint = new Vector2(3.481F, -1.019F);
                result.Offset = new Vector2(96.394F, 101.019F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0003());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0003()
            {
                if (_CompositionContainerShape_0003 != null)
                {
                    return _CompositionContainerShape_0003;
                }
                var result = _c.CreateContainerShape();
                _CompositionContainerShape_0003 = result;
                result.Comment = "Ellipse 1";
                result.Offset = new Vector2(3.481F, -1.019F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0001());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0004()
            {
                if (_CompositionContainerShape_0004 != null)
                {
                    return _CompositionContainerShape_0004;
                }
                var result = _c.CreateContainerShape();
                _CompositionContainerShape_0004 = result;
                result.Comment = "ShapeLayer:'Shape Layer 3'";
                result.CenterPoint = new Vector2(3.481F, -1.019F);
                result.Offset = new Vector2(124.519F, 101.019F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0005());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0005()
            {
                if (_CompositionContainerShape_0005 != null)
                {
                    return _CompositionContainerShape_0005;
                }
                var result = _c.CreateContainerShape();
                _CompositionContainerShape_0005 = result;
                result.Comment = "Ellipse 1";
                result.Offset = new Vector2(3.481F, -1.019F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0002());
                return result;
            }

            CompositionEllipseGeometry CompositionEllipseGeometry_0000()
            {
                if (_CompositionEllipseGeometry_0000 != null)
                {
                    return _CompositionEllipseGeometry_0000;
                }
                var result = _c.CreateEllipseGeometry();
                _CompositionEllipseGeometry_0000 = result;
                result.Comment = "Ellipse Path 1.EllipseGeometry";
                result.TrimEnd = 1.0F;
                result.Center = new Vector2(0, 0);
                result.Radius = new Vector2(7.4815F, 7.4815F);
                return result;
            }

            CompositionEllipseGeometry CompositionEllipseGeometry_0001()
            {
                if (_CompositionEllipseGeometry_0001 != null)
                {
                    return _CompositionEllipseGeometry_0001;
                }
                var result = _c.CreateEllipseGeometry();
                _CompositionEllipseGeometry_0001 = result;
                result.Comment = "Ellipse Path 1.EllipseGeometry";
                result.TrimEnd = 1.0F;
                result.Center = new Vector2(0, 0);
                result.Radius = new Vector2(7.4815F, 7.4815F);
                return result;
            }

            CompositionEllipseGeometry CompositionEllipseGeometry_0002()
            {
                if (_CompositionEllipseGeometry_0002 != null)
                {
                    return _CompositionEllipseGeometry_0002;
                }
                var result = _c.CreateEllipseGeometry();
                _CompositionEllipseGeometry_0002 = result;
                result.Comment = "Ellipse Path 1.EllipseGeometry";
                result.TrimEnd = 1.0F;
                result.Center = new Vector2(0, 0);
                result.Radius = new Vector2(7.4815F, 7.4815F);
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0000()
            {
                if (_CompositionSpriteShape_0000 != null)
                {
                    return _CompositionSpriteShape_0000;
                }
                var result = _c.CreateSpriteShape();
                _CompositionSpriteShape_0000 = result;
                result.Comment = "Ellipse Path 1";
                result.FillBrush = CompositionColorBrush_0000();
                result.Geometry = CompositionEllipseGeometry_0000();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0001()
            {
                if (_CompositionSpriteShape_0001 != null)
                {
                    return _CompositionSpriteShape_0001;
                }
                var result = _c.CreateSpriteShape();
                _CompositionSpriteShape_0001 = result;
                result.Comment = "Ellipse Path 1";
                result.FillBrush = CompositionColorBrush_0001();
                result.Geometry = CompositionEllipseGeometry_0001();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0002()
            {
                if (_CompositionSpriteShape_0002 != null)
                {
                    return _CompositionSpriteShape_0002;
                }
                var result = _c.CreateSpriteShape();
                _CompositionSpriteShape_0002 = result;
                result.Comment = "Ellipse Path 1";
                result.FillBrush = CompositionColorBrush_0002();
                result.Geometry = CompositionEllipseGeometry_0002();
                return result;
            }

            ContainerVisual ContainerVisual_0000()
            {
                if (_ContainerVisual_0000 != null)
                {
                    return _ContainerVisual_0000;
                }
                var result = _c.CreateContainerVisual();
                _ContainerVisual_0000 = result;
                result.Comment = "Lottie";
                var propertySet = result.Properties;
                propertySet.InsertScalar("AnimationProgress", 0);
                var children = result.Children;
                children.InsertAtTop(ShapeVisual_0000());
                return result;
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0000()
            {
                if (_CubicBezierEasingFunction_0000 != null)
                {
                    return _CubicBezierEasingFunction_0000;
                }
                var result = _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0.833F, 0.833F));
                _CubicBezierEasingFunction_0000 = result;
                return result;
            }

            ExpressionAnimation ExpressionAnimation_0000()
            {
                var result = _c.CreateExpressionAnimation("root.AnimationProgress");
                result.SetReferenceParameter("root", ContainerVisual_0000());
                return result;
            }

            ExpressionAnimation ExpressionAnimation_0001()
            {
                var result = _c.CreateExpressionAnimation("root.AnimationProgress");
                result.SetReferenceParameter("root", ContainerVisual_0000());
                return result;
            }

            ExpressionAnimation ExpressionAnimation_0002()
            {
                var result = _c.CreateExpressionAnimation("root.AnimationProgress");
                result.SetReferenceParameter("root", ContainerVisual_0000());
                return result;
            }

            LinearEasingFunction LinearEasingFunction_0000()
            {
                if (_LinearEasingFunction_0000 != null)
                {
                    return _LinearEasingFunction_0000;
                }
                var result = _c.CreateLinearEasingFunction();
                _LinearEasingFunction_0000 = result;
                return result;
            }

            ShapeVisual ShapeVisual_0000()
            {
                if (_ShapeVisual_0000 != null)
                {
                    return _ShapeVisual_0000;
                }
                var result = _c.CreateShapeVisual();
                _ShapeVisual_0000 = result;
                result.Size = new Vector2(200.0F, 200.0F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0000());
                shapes.Add(CompositionContainerShape_0002());
                shapes.Add(CompositionContainerShape_0004());
                return result;
            }

            internal Visual CreateRootVisual() => ContainerVisual_0000();
        }
    }
}
