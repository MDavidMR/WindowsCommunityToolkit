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
    sealed class MyComposition : Lottie.ICompositionSource
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
            size = new Vector2(300, 300);
            progressPropertySet = rootVisual.Properties;
            progressPropertyName = "AnimationProgress";
            duration = TimeSpan.FromTicks(20000000);
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
            CompositionColorBrush _compositionColorBrush_0000;
            CompositionColorBrush _compositionColorBrush_0003;
            CompositionColorBrush _compositionColorBrush_0005;
            CompositionColorBrush _compositionColorBrush_0006;
            CompositionColorBrush _compositionColorBrush_0008;
            CompositionColorBrush _compositionColorBrush_0012;
            CompositionColorBrush _compositionColorBrush_0013;
            CompositionColorBrush _compositionColorBrush_0014;
            CompositionColorBrush _compositionColorBrush_0015;
            CompositionColorBrush _compositionColorBrush_0016;
            CompositionColorBrush _compositionColorBrush_0019;
            CompositionColorBrush _compositionColorBrush_0020;
            ContainerVisual _containerVisual_0000;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0000;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0001;
            ExpressionAnimation _expressionAnimation_0000;
            ExpressionAnimation _expressionAnimation_0003;
            LinearEasingFunction _linearEasingFunction_0000;
            StepEasingFunction _stepEasingFunction_0000;

            internal static Visual InstantiateComposition(Compositor compositor)
                => new Instantiator(compositor).ContainerVisual_0000();

            Instantiator(Compositor compositor)
            {
                _c = compositor;
            }

            CompositionColorBrush CompositionColorBrush_0000()
            {
                if (_compositionColorBrush_0000 != null)
                {
                    return _compositionColorBrush_0000;
                }
                var result = _compositionColorBrush_0000 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x1F, 0x1F, 0x1F));
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0001()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x1E, 0x1E, 0x1E));
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0002()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x37, 0x37, 0x37));
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0003()
            {
                if (_compositionColorBrush_0003 != null)
                {
                    return _compositionColorBrush_0003;
                }
                var result = _compositionColorBrush_0003 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x38, 0x38, 0x38));
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0004()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x31, 0xD2, 0xF7));
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0005()
            {
                if (_compositionColorBrush_0005 != null)
                {
                    return _compositionColorBrush_0005;
                }
                var result = _compositionColorBrush_0005 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xEC, 0xB9, 0x30));
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0006()
            {
                if (_compositionColorBrush_0006 != null)
                {
                    return _compositionColorBrush_0006;
                }
                var result = _compositionColorBrush_0006 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xFF, 0xE5, 0x00));
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0007()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x31, 0xD1, 0xF7));
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0008()
            {
                if (_compositionColorBrush_0008 != null)
                {
                    return _compositionColorBrush_0008;
                }
                var result = _compositionColorBrush_0008 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xFD, 0x8B, 0x00));
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0009()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xFF, 0xB9, 0x02));
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0010()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x10, 0x87, 0x3D));
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0011()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x01, 0xCC, 0x69));
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0012()
            {
                if (_compositionColorBrush_0012 != null)
                {
                    return _compositionColorBrush_0012;
                }
                var result = _compositionColorBrush_0012 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xE4, 0xE4, 0xE4));
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0013()
            {
                if (_compositionColorBrush_0013 != null)
                {
                    return _compositionColorBrush_0013;
                }
                var result = _compositionColorBrush_0013 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xF1, 0xF1, 0xF1));
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0014()
            {
                if (_compositionColorBrush_0014 != null)
                {
                    return _compositionColorBrush_0014;
                }
                var result = _compositionColorBrush_0014 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xBA, 0x91, 0x67));
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0015()
            {
                if (_compositionColorBrush_0015 != null)
                {
                    return _compositionColorBrush_0015;
                }
                var result = _compositionColorBrush_0015 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x8E, 0x55, 0x2D));
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0016()
            {
                if (_compositionColorBrush_0016 != null)
                {
                    return _compositionColorBrush_0016;
                }
                var result = _compositionColorBrush_0016 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xCC, 0xCC, 0xCC));
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0017()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x00, 0x63, 0xB0));
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0018()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x01, 0x77, 0xD9));
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0019()
            {
                if (_compositionColorBrush_0019 != null)
                {
                    return _compositionColorBrush_0019;
                }
                var result = _compositionColorBrush_0019 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x10, 0x87, 0x3E));
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0020()
            {
                if (_compositionColorBrush_0020 != null)
                {
                    return _compositionColorBrush_0020;
                }
                var result = _compositionColorBrush_0020 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xF1, 0xF1, 0xF1));
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0000()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(150, 150);
                result.Scale = new Vector2(3, 3);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0001());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0001()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(48.166F, 70.722F);
                result.Offset = new Vector2(-48.082F, -36.251F);
                result.Scale = new Vector2(0.9F, 0.9F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0002());
                shapes.Add(CompositionContainerShape_0003());
                shapes.Add(CompositionContainerShape_0004());
                shapes.Add(CompositionContainerShape_0005());
                shapes.Add(CompositionContainerShape_0006());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0002()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(48.25F, 64.016F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0000());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0003()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(48.166F, 30.28F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0001());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0004()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(48.25F, 29.281F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0002());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0005()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(48.25F, 69.222F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0003());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0006()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(48.25F, 70.347F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0004());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0007()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(37.5F, 21.5F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0008());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0008()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0005());
                {
                    var animation = ScalarKeyFrameAnimation_0001();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0002(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0009()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(-8.516F, -19.891F);
                result.Offset = new Vector2(18.625F, 29.875F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0010());
                {
                    var animation = ScalarKeyFrameAnimation_0003();
                    result.StartAnimation("RotationAngleInDegrees", animation);
                    {
                        var controller = result.TryGetAnimationController("RotationAngleInDegrees");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0003();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0010()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0011());
                {
                    var animation = ScalarKeyFrameAnimation_0004();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0002(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0011()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(-8.516F, -19.891F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0006());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0012()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(-8.516F, -19.891F);
                result.Offset = new Vector2(18.625F, 29.875F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0013());
                {
                    var animation = ScalarKeyFrameAnimation_0005();
                    result.StartAnimation("RotationAngleInDegrees", animation);
                    {
                        var controller = result.TryGetAnimationController("RotationAngleInDegrees");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0003();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0013()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(-12.438F, -21.875F);
                result.Offset = new Vector2(3.875999F, 1.875F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0014());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0014()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0015());
                {
                    var animation = ScalarKeyFrameAnimation_0006();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0002(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0015()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0007());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0016()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(-8.516F, -19.891F);
                result.Offset = new Vector2(18.625F, 29.875F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0017());
                {
                    var animation = ScalarKeyFrameAnimation_0007();
                    result.StartAnimation("RotationAngleInDegrees", animation);
                    {
                        var controller = result.TryGetAnimationController("RotationAngleInDegrees");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0003();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0017()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(-12.438F, -21.875F);
                result.Offset = new Vector2(3.875999F, 1.875F);
                result.RotationAngleInDegrees = 405;
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0018());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0018()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0019());
                {
                    var animation = ScalarKeyFrameAnimation_0008();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0002(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0019()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0008());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0020()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(-8.516F, -19.891F);
                result.Offset = new Vector2(18.625F, 29.875F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0021());
                {
                    var animation = ScalarKeyFrameAnimation_0009();
                    result.StartAnimation("RotationAngleInDegrees", animation);
                    {
                        var controller = result.TryGetAnimationController("RotationAngleInDegrees");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0003();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0021()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(-12.438F, -21.875F);
                result.Offset = new Vector2(3.875999F, 1.875F);
                result.RotationAngleInDegrees = 450;
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0022());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0022()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0023());
                {
                    var animation = ScalarKeyFrameAnimation_0010();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0002(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0023()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0009());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0024()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(-8.516F, -19.891F);
                result.Offset = new Vector2(18.625F, 29.875F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0025());
                {
                    var animation = ScalarKeyFrameAnimation_0011();
                    result.StartAnimation("RotationAngleInDegrees", animation);
                    {
                        var controller = result.TryGetAnimationController("RotationAngleInDegrees");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0003();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0025()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(-12.438F, -21.875F);
                result.Offset = new Vector2(3.875999F, 1.875F);
                result.RotationAngleInDegrees = 495;
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0026());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0026()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0027());
                {
                    var animation = ScalarKeyFrameAnimation_0012();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0002(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0027()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0010());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0028()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(-8.516F, -19.891F);
                result.Offset = new Vector2(18.625F, 29.875F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0029());
                {
                    var animation = ScalarKeyFrameAnimation_0013();
                    result.StartAnimation("RotationAngleInDegrees", animation);
                    {
                        var controller = result.TryGetAnimationController("RotationAngleInDegrees");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0003();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0029()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(-12.438F, -21.875F);
                result.Offset = new Vector2(3.875999F, 1.875F);
                result.RotationAngleInDegrees = 540;
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0030());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0030()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0031());
                {
                    var animation = ScalarKeyFrameAnimation_0014();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0002(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0031()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0011());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0032()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(-8.516F, -19.891F);
                result.Offset = new Vector2(18.625F, 29.875F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0033());
                {
                    var animation = ScalarKeyFrameAnimation_0015();
                    result.StartAnimation("RotationAngleInDegrees", animation);
                    {
                        var controller = result.TryGetAnimationController("RotationAngleInDegrees");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0003();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0033()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(-12.438F, -21.875F);
                result.Offset = new Vector2(3.875999F, 1.875F);
                result.RotationAngleInDegrees = 585;
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0034());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0034()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0035());
                {
                    var animation = ScalarKeyFrameAnimation_0016();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0002(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0035()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0012());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0036()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(-8.516F, -19.891F);
                result.Offset = new Vector2(18.625F, 29.875F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0037());
                {
                    var animation = ScalarKeyFrameAnimation_0017();
                    result.StartAnimation("RotationAngleInDegrees", animation);
                    {
                        var controller = result.TryGetAnimationController("RotationAngleInDegrees");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0003();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0037()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(-12.438F, -21.875F);
                result.Offset = new Vector2(3.875999F, 1.875F);
                result.RotationAngleInDegrees = 630;
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0038());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0038()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0039());
                {
                    var animation = ScalarKeyFrameAnimation_0018();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0002(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0039()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0013());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0040()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(-8.516F, -19.891F);
                result.Offset = new Vector2(18.625F, 29.875F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0041());
                {
                    var animation = ScalarKeyFrameAnimation_0019();
                    result.StartAnimation("RotationAngleInDegrees", animation);
                    {
                        var controller = result.TryGetAnimationController("RotationAngleInDegrees");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0003();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0041()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(-12.438F, -21.875F);
                result.Offset = new Vector2(3.875999F, 1.875F);
                result.RotationAngleInDegrees = 675;
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0042());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0042()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0043());
                {
                    var animation = ScalarKeyFrameAnimation_0020();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0002(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0043()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0014());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0044()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(44.25F, 25.28F);
                result.Offset = new Vector2(106.226F, 115.484F);
                result.Scale = new Vector2(2.67F, 2.67F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0045());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0045()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0046());
                {
                    var animation = ScalarKeyFrameAnimation_0021();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0002(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0046()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(44.25F, 25.279F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0015());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0047()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(75.733F, 26.379F));
                propertySet.InsertVector2("Position", new Vector2(20.155F, 22.121F));
                result.CenterPoint = new Vector2(75.733F, 26.379F);
                result.Scale = new Vector2(0.3F, 0.3F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0048());
                {
                    var animation = ExpressionAnimation_0004(result);
                    result.StartAnimation("Offset", animation);
                }
                {
                    var animation = Vector2KeyFrameAnimation_0000();
                    result.StartAnimation("Position", animation);
                    {
                        var controller = result.TryGetAnimationController("Position");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0003();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0048()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0049());
                {
                    var animation = ScalarKeyFrameAnimation_0022();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0002(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0049()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(75.733F, 26.379F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0050());
                shapes.Add(CompositionSpriteShape_0017());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0050()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(104.183F, -9.661F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0016());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0051()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(127.992F, 27.83F));
                propertySet.InsertVector2("Position", new Vector2(37.655F, 24.246F));
                result.CenterPoint = new Vector2(127.992F, 27.83F);
                result.Scale = new Vector2(0.33F, 0.33F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0052());
                {
                    var animation = ExpressionAnimation_0004(result);
                    result.StartAnimation("Offset", animation);
                }
                {
                    var animation = Vector2KeyFrameAnimation_0001();
                    result.StartAnimation("Position", animation);
                    {
                        var controller = result.TryGetAnimationController("Position");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0003();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0052()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0053());
                {
                    var animation = ScalarKeyFrameAnimation_0023();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0002(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0053()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(127.992F, 27.83F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0018());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0054()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(127.992F, 16.218F));
                propertySet.InsertVector2("Position", new Vector2(37.655F, 27.646F));
                result.CenterPoint = new Vector2(127.992F, 16.218F);
                result.Scale = new Vector2(0.374F, 0.374F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0055());
                {
                    var animation = ExpressionAnimation_0004(result);
                    result.StartAnimation("Offset", animation);
                }
                {
                    var animation = Vector2KeyFrameAnimation_0002();
                    result.StartAnimation("Position", animation);
                    {
                        var controller = result.TryGetAnimationController("Position");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0003();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0055()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0056());
                {
                    var animation = ScalarKeyFrameAnimation_0024();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0002(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0056()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(127.992F, 16.218F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0019());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0057()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(127.992F, 22.025F));
                propertySet.InsertVector2("Position", new Vector2(37.655F, 36.446F));
                result.CenterPoint = new Vector2(127.992F, 22.025F);
                result.Scale = new Vector2(0.374F, 0.374F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0058());
                {
                    var animation = ExpressionAnimation_0004(result);
                    result.StartAnimation("Offset", animation);
                }
                {
                    var animation = Vector2KeyFrameAnimation_0003();
                    result.StartAnimation("Position", animation);
                    {
                        var controller = result.TryGetAnimationController("Position");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0003();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0058()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0059());
                {
                    var animation = ScalarKeyFrameAnimation_0025();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0002(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0059()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(127.992F, 22.025F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0020());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0060()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(36.008F, 4.75F));
                propertySet.InsertVector2("Position", new Vector2(45.709F, 11.496F));
                result.CenterPoint = new Vector2(36.008F, 4.75F);
                result.Scale = new Vector2(0.65F, 0.65F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0061());
                {
                    var animation = ExpressionAnimation_0004(result);
                    result.StartAnimation("Offset", animation);
                }
                {
                    var animation = Vector2KeyFrameAnimation_0004();
                    result.StartAnimation("Position", animation);
                    {
                        var controller = result.TryGetAnimationController("Position");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0003();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0061()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0062());
                {
                    var animation = ScalarKeyFrameAnimation_0026();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0002(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0062()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(64.091F, 4.25F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0021());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0063()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(36.008F, 4.75F));
                propertySet.InsertVector2("Position", new Vector2(23.209F, 11.496F));
                result.CenterPoint = new Vector2(36.008F, 4.75F);
                result.Scale = new Vector2(0.5F, 0.5F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0064());
                {
                    var animation = ExpressionAnimation_0004(result);
                    result.StartAnimation("Offset", animation);
                }
                {
                    var animation = Vector2KeyFrameAnimation_0005();
                    result.StartAnimation("Position", animation);
                    {
                        var controller = result.TryGetAnimationController("Position");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0003();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0064()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0065());
                {
                    var animation = ScalarKeyFrameAnimation_0027();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0002(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0065()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(5.508F, 6.25F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0022());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0066()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(10.701F, 5.75F));
                propertySet.InsertVector2("Position", new Vector2(38.023F, 8.946F));
                result.CenterPoint = new Vector2(10.701F, 5.75F);
                result.Scale = new Vector2(0.75F, 0.75F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0067());
                {
                    var animation = ExpressionAnimation_0004(result);
                    result.StartAnimation("Offset", animation);
                }
                {
                    var animation = Vector2KeyFrameAnimation_0006();
                    result.StartAnimation("Position", animation);
                    {
                        var controller = result.TryGetAnimationController("Position");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0003();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0067()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0068());
                {
                    var animation = ScalarKeyFrameAnimation_0028();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0002(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0068()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(10.701F, 5.75F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0023());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0069()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(162.658F, 151.648F);
                result.Offset = new Vector2(840.058F, 589.33F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0070());
                shapes.Add(CompositionContainerShape_0071());
                shapes.Add(CompositionContainerShape_0072());
                shapes.Add(CompositionContainerShape_0073());
                shapes.Add(CompositionContainerShape_0074());
                shapes.Add(CompositionContainerShape_0075());
                shapes.Add(CompositionContainerShape_0076());
                shapes.Add(CompositionContainerShape_0077());
                shapes.Add(CompositionContainerShape_0078());
                shapes.Add(CompositionContainerShape_0079());
                shapes.Add(CompositionContainerShape_0080());
                shapes.Add(CompositionContainerShape_0081());
                shapes.Add(CompositionContainerShape_0082());
                shapes.Add(CompositionContainerShape_0083());
                shapes.Add(CompositionContainerShape_0084());
                shapes.Add(CompositionContainerShape_0085());
                shapes.Add(CompositionContainerShape_0086());
                shapes.Add(CompositionContainerShape_0087());
                shapes.Add(CompositionContainerShape_0088());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0070()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(41.79F, 150.404F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0024());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0071()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(38.787F, 148.895F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0025());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0072()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(184.68F, 42.917F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0026());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0073()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(289.282F, 42.917F);
                result.RotationAngleInDegrees = -0.413F;
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0027());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0074()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(-11.872F, 0.044F);
                result.Offset = new Vector2(266.923F, 74.647F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0028());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0075()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(12.026F, 5.617F);
                result.Offset = new Vector2(205.949F, 74.57301F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0029());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0076()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(55.304F, 247.991F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0030());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0077()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(203.949F, 225.97F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0031());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0078()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(129.935F, 176.894F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0032());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0079()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(236.981F, 99.347F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0033());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0080()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(220.212F, 85.583F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0034());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0081()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(236.981F, 99.346F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0035());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0082()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(60.809F, 297.54F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0036());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0083()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(11.26F, 297.54F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0037());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0084()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(198.443F, 297.54F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0038());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0085()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(165.411F, 297.54F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0039());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0086()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(253.749F, 85.583F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0040());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0087()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(170.916F, 225.97F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0041());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0088()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(236.981F, 122.946F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0042());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0089()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(162.658F, 151.648F);
                result.Offset = new Vector2(840.058F, 589.33F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0090());
                shapes.Add(CompositionContainerShape_0091());
                shapes.Add(CompositionContainerShape_0092());
                shapes.Add(CompositionContainerShape_0093());
                shapes.Add(CompositionContainerShape_0094());
                shapes.Add(CompositionContainerShape_0095());
                shapes.Add(CompositionContainerShape_0096());
                shapes.Add(CompositionContainerShape_0097());
                shapes.Add(CompositionContainerShape_0098());
                shapes.Add(CompositionContainerShape_0099());
                shapes.Add(CompositionContainerShape_0100());
                shapes.Add(CompositionContainerShape_0101());
                shapes.Add(CompositionContainerShape_0102());
                shapes.Add(CompositionContainerShape_0103());
                shapes.Add(CompositionContainerShape_0104());
                shapes.Add(CompositionContainerShape_0105());
                shapes.Add(CompositionContainerShape_0106());
                shapes.Add(CompositionContainerShape_0107());
                shapes.Add(CompositionContainerShape_0108());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0090()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(41.79F, 150.404F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0043());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0091()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(38.787F, 148.895F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0044());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0092()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(184.68F, 42.917F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0045());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0093()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(289.282F, 42.917F);
                result.RotationAngleInDegrees = -0.413F;
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0046());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0094()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(-11.872F, 0.044F);
                result.Offset = new Vector2(266.923F, 74.647F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0047());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0095()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(12.026F, 5.617F);
                result.Offset = new Vector2(205.949F, 74.57301F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0048());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0096()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(55.304F, 247.991F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0049());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0097()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(203.949F, 225.97F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0050());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0098()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(129.935F, 176.894F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0051());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0099()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(236.981F, 99.347F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0052());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0100()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(220.212F, 85.583F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0053());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0101()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(236.981F, 99.346F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0054());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0102()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(60.809F, 297.54F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0055());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0103()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(11.26F, 297.54F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0056());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0104()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(198.443F, 297.54F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0057());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0105()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(165.411F, 297.54F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0058());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0106()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(253.749F, 85.583F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0059());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0107()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(170.916F, 225.97F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0060());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0108()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(236.981F, 122.946F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0061());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0109()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(640.25F, 110.75F);
                result.Offset = new Vector2(-0.25F, 802.75F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0110());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0110()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0111());
                {
                    var animation = ScalarKeyFrameAnimation_0033();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0002(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0111()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(640.25F, 110.75F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0062());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0112()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(672.486F, 110.75F);
                result.Offset = new Vector2(-70.56702F, 833.961F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0113());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0113()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0114());
                {
                    var animation = ScalarKeyFrameAnimation_0034();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0002(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0114()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(707.644F, 95.145F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0063());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0115()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(48.812F, 20.39F);
                result.Offset = new Vector2(1053.274F, 815.75F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0116());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0116()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0117());
                {
                    var animation = ScalarKeyFrameAnimation_0037();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0002(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0117()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(48.812F, 20.39F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0064());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0118()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(95.25F, 28.513F);
                result.Offset = new Vector2(817.75F, 801.225F);
                result.Scale = new Vector2(1.66F, 1.66F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0119());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0119()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0120());
                {
                    var animation = ScalarKeyFrameAnimation_0038();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0002(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0120()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(95.25F, 28.513F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0065());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0121()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(48.812F, 20.39F);
                result.Offset = new Vector2(633.274F, 725.75F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0122());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0122()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0123());
                {
                    var animation = ScalarKeyFrameAnimation_0039();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0002(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0123()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(48.812F, 20.39F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0066());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0124()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(48.812F, 20.39F);
                result.Offset = new Vector2(463.274F, 767.75F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0125());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0125()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0126());
                {
                    var animation = ScalarKeyFrameAnimation_0040();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0002(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0126()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(48.812F, 20.39F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0067());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0127()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(48.812F, 20.39F);
                result.Offset = new Vector2(1053.274F, 815.75F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0128());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0128()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0129());
                {
                    var animation = ScalarKeyFrameAnimation_0042();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0002(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0129()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(48.812F, 20.39F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0068());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0130()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(95.25F, 28.513F);
                result.Offset = new Vector2(817.75F, 801.225F);
                result.Scale = new Vector2(1.66F, 1.66F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0131());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0131()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0132());
                {
                    var animation = ScalarKeyFrameAnimation_0043();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0002(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0132()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(95.25F, 28.513F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0069());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0133()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(48.812F, 20.39F);
                result.Offset = new Vector2(633.274F, 725.75F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0134());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0134()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0135());
                {
                    var animation = ScalarKeyFrameAnimation_0044();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0002(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0135()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(48.812F, 20.39F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0070());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0136()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(48.812F, 20.39F);
                result.Offset = new Vector2(463.274F, 767.75F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0137());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0137()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0138());
                {
                    var animation = ScalarKeyFrameAnimation_0045();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0002(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0138()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(48.812F, 20.39F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0071());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0139()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(162.658F, 151.648F);
                result.Offset = new Vector2(840.058F, 589.33F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0140());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0140()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0141());
                shapes.Add(CompositionContainerShape_0142());
                shapes.Add(CompositionContainerShape_0143());
                shapes.Add(CompositionContainerShape_0144());
                shapes.Add(CompositionContainerShape_0145());
                shapes.Add(CompositionContainerShape_0146());
                shapes.Add(CompositionContainerShape_0147());
                shapes.Add(CompositionContainerShape_0148());
                shapes.Add(CompositionContainerShape_0149());
                shapes.Add(CompositionContainerShape_0150());
                shapes.Add(CompositionContainerShape_0151());
                shapes.Add(CompositionContainerShape_0152());
                shapes.Add(CompositionContainerShape_0153());
                shapes.Add(CompositionContainerShape_0154());
                shapes.Add(CompositionContainerShape_0155());
                shapes.Add(CompositionContainerShape_0156());
                shapes.Add(CompositionContainerShape_0157());
                shapes.Add(CompositionContainerShape_0158());
                shapes.Add(CompositionContainerShape_0159());
                {
                    var animation = ScalarKeyFrameAnimation_0047();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0002(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0141()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(41.79F, 150.404F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0072());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0142()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(38.787F, 148.895F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0073());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0143()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(184.68F, 42.917F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0074());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0144()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(289.282F, 42.917F);
                result.RotationAngleInDegrees = -0.413F;
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0075());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0145()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(-11.872F, 0.044F);
                result.Offset = new Vector2(266.923F, 74.647F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0076());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0146()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(12.026F, 5.617F);
                result.Offset = new Vector2(205.949F, 74.57301F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0077());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0147()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(55.304F, 247.991F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0078());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0148()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(203.949F, 225.97F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0079());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0149()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(129.935F, 176.894F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0080());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0150()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(236.981F, 99.347F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0081());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0151()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(220.212F, 85.583F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0082());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0152()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(236.981F, 99.346F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0083());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0153()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(60.809F, 297.54F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0084());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0154()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(11.26F, 297.54F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0085());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0155()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(198.443F, 297.54F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0086());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0156()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(165.411F, 297.54F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0087());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0157()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(253.749F, 85.583F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0088());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0158()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(170.916F, 225.97F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0089());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0159()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(236.981F, 122.946F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0090());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0160()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(95.25F, 28.513F);
                result.Offset = new Vector2(1281.75F, 897.225F);
                result.Scale = new Vector2(5.61F, 5.61F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0161());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0161()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0162());
                {
                    var animation = ScalarKeyFrameAnimation_0048();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0002(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0162()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(95.25F, 28.513F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0091());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0163()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(150, 150);
                result.Scale = new Vector2(3, 3);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0164());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0164()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(48.166F, 70.722F);
                result.Offset = new Vector2(-48.082F, -36.251F);
                result.Scale = new Vector2(0.9F, 0.9F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0165());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0165()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(44.25F, 25.28F);
                result.Offset = new Vector2(4, 4.000999F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0166());
                {
                    var animation = Vector2KeyFrameAnimation_0007();
                    result.StartAnimation("Scale", animation);
                    {
                        var controller = result.TryGetAnimationController("Scale");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0166()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0167());
                {
                    var animation = ScalarKeyFrameAnimation_0049();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0002(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0167()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(44.25F, 25.279F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0092());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0168()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(0, 0));
                propertySet.InsertVector2("Position", new Vector2(-67.5F, 38));
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0169());
                {
                    var animation = ExpressionAnimation_0004(result);
                    result.StartAnimation("Offset", animation);
                }
                {
                    var animation = Vector2KeyFrameAnimation_0008();
                    result.StartAnimation("Position", animation);
                    {
                        var controller = result.TryGetAnimationController("Position");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0169()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(-96.562F, 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0093());
                return result;
            }

            CompositionEllipseGeometry CompositionEllipseGeometry_0000()
            {
                var result = _c.CreateEllipseGeometry();
                result.TrimEnd = 1;
                result.Center = new Vector2(0, 0);
                result.Radius = new Vector2(3.609F, 3.609F);
                return result;
            }

            CompositionPath CompositionPath_0000()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(3, -5.6F));
                    builder.AddCubicBezier(new Vector2(3, -5.6F), new Vector2(0.009F, -5.581F), new Vector2(0.009F, -5.581F));
                    builder.AddCubicBezier(new Vector2(0.009F, -5.581F), new Vector2(-3, -5.6F), new Vector2(-3, -5.6F));
                    builder.AddCubicBezier(new Vector2(-3, -5.6F), new Vector2(-3, -0.082F), new Vector2(-3, -0.082F));
                    builder.AddCubicBezier(new Vector2(-3, -0.082F), new Vector2(0.009F, 0.016F), new Vector2(0.009F, 0.016F));
                    builder.AddCubicBezier(new Vector2(0.009F, 0.016F), new Vector2(3, -0.082F), new Vector2(3, -0.082F));
                    builder.AddCubicBezier(new Vector2(3, -0.082F), new Vector2(3, -5.6F), new Vector2(3, -5.6F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0001()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-46.969F, 28.136F));
                    builder.AddCubicBezier(new Vector2(-46.969F, 28.136F), new Vector2(46.969F, 28.136F), new Vector2(46.969F, 28.136F));
                    builder.AddCubicBezier(new Vector2(46.969F, 28.136F), new Vector2(46.969F, -29.083F), new Vector2(46.969F, -29.083F));
                    builder.AddCubicBezier(new Vector2(46.969F, -29.083F), new Vector2(-46.969F, -29.083F), new Vector2(-46.969F, -29.083F));
                    builder.AddCubicBezier(new Vector2(-46.969F, -29.083F), new Vector2(-46.969F, 28.136F), new Vector2(-46.969F, 28.136F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0002()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(45, 26.029F));
                    builder.AddCubicBezier(new Vector2(45, 26.029F), new Vector2(-45, 26.029F), new Vector2(-45, 26.029F));
                    builder.AddCubicBezier(new Vector2(-45, 26.029F), new Vector2(-45, -26.029F), new Vector2(-45, -26.029F));
                    builder.AddCubicBezier(new Vector2(-45, -26.029F), new Vector2(45, -26.029F), new Vector2(45, -26.029F));
                    builder.AddCubicBezier(new Vector2(45, -26.029F), new Vector2(45, 26.029F), new Vector2(45, 26.029F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0003()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(16, -5.288F));
                    builder.AddCubicBezier(new Vector2(16, -5.288F), new Vector2(-16, -5.288F), new Vector2(-16, -5.288F));
                    builder.AddCubicBezier(new Vector2(-16, -5.288F), new Vector2(-16, -3.268F), new Vector2(-16, -3.268F));
                    builder.AddCubicBezier(new Vector2(-16, -3.268F), new Vector2(16, -3.268F), new Vector2(16, -3.268F));
                    builder.AddCubicBezier(new Vector2(16, -3.268F), new Vector2(16, -5.288F), new Vector2(16, -5.288F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0004()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(16, -4.393F));
                    builder.AddCubicBezier(new Vector2(16, -4.393F), new Vector2(-16, -4.393F), new Vector2(-16, -4.393F));
                    builder.AddCubicBezier(new Vector2(-16, -4.393F), new Vector2(-16, -5.143F), new Vector2(-16, -5.143F));
                    builder.AddCubicBezier(new Vector2(-16, -5.143F), new Vector2(16, -5.143F), new Vector2(16, -5.143F));
                    builder.AddCubicBezier(new Vector2(16, -5.143F), new Vector2(16, -4.393F), new Vector2(16, -4.393F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0005()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-12.438F, -28.5F));
                    builder.AddCubicBezier(new Vector2(-12.438F, -28.5F), new Vector2(-12.438F, -29.719F), new Vector2(-12.438F, -29.719F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0006()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-12.438F, -28.5F));
                    builder.AddCubicBezier(new Vector2(-12.438F, -28.5F), new Vector2(-12.438F, -29.719F), new Vector2(-12.438F, -29.719F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0007()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-12.438F, -28.5F));
                    builder.AddCubicBezier(new Vector2(-12.438F, -28.5F), new Vector2(-12.438F, -29.719F), new Vector2(-12.438F, -29.719F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0008()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-12.438F, -28.5F));
                    builder.AddCubicBezier(new Vector2(-12.438F, -28.5F), new Vector2(-12.438F, -29.719F), new Vector2(-12.438F, -29.719F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0009()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-12.438F, -28.5F));
                    builder.AddCubicBezier(new Vector2(-12.438F, -28.5F), new Vector2(-12.438F, -29.719F), new Vector2(-12.438F, -29.719F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0010()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-12.438F, -28.5F));
                    builder.AddCubicBezier(new Vector2(-12.438F, -28.5F), new Vector2(-12.438F, -29.719F), new Vector2(-12.438F, -29.719F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0011()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-12.438F, -28.5F));
                    builder.AddCubicBezier(new Vector2(-12.438F, -28.5F), new Vector2(-12.438F, -29.719F), new Vector2(-12.438F, -29.719F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0012()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-12.438F, -28.5F));
                    builder.AddCubicBezier(new Vector2(-12.438F, -28.5F), new Vector2(-12.438F, -29.719F), new Vector2(-12.438F, -29.719F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0013()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(44, 25.029F));
                    builder.AddCubicBezier(new Vector2(44, 25.029F), new Vector2(-44, 25.029F), new Vector2(-44, 25.029F));
                    builder.AddCubicBezier(new Vector2(-44, 25.029F), new Vector2(-44, -25.029F), new Vector2(-44, -25.029F));
                    builder.AddCubicBezier(new Vector2(-44, -25.029F), new Vector2(44, -25.029F), new Vector2(44, -25.029F));
                    builder.AddCubicBezier(new Vector2(44, -25.029F), new Vector2(44, 25.029F), new Vector2(44, 25.029F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0014()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-75.484F, 34.839F));
                    builder.AddCubicBezier(new Vector2(-75.484F, 34.839F), new Vector2(72.151F, 34.95F), new Vector2(72.151F, 34.95F));
                    builder.AddCubicBezier(new Vector2(72.151F, 34.95F), new Vector2(11.613F, -23.225F), new Vector2(11.613F, -23.225F));
                    builder.AddCubicBezier(new Vector2(11.613F, -23.225F), new Vector2(-20.323F, -34.839F), new Vector2(-20.323F, -34.839F));
                    builder.AddCubicBezier(new Vector2(-20.323F, -34.839F), new Vector2(-75.484F, 34.839F), new Vector2(-75.484F, 34.839F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0015()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-58.4F, 26.281F));
                    builder.AddCubicBezier(new Vector2(-58.4F, 26.281F), new Vector2(49.65F, 26.281F), new Vector2(49.65F, 26.281F));
                    builder.AddCubicBezier(new Vector2(49.65F, 26.281F), new Vector2(-2.581F, -16.129F), new Vector2(-2.581F, -16.129F));
                    builder.AddCubicBezier(new Vector2(-2.581F, -16.129F), new Vector2(-25.808F, -4.516F), new Vector2(-25.808F, -4.516F));
                    builder.AddCubicBezier(new Vector2(-25.808F, -4.516F), new Vector2(-58.4F, 26.281F), new Vector2(-58.4F, 26.281F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0016()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(104.516F, -7.258F));
                    builder.AddCubicBezier(new Vector2(104.516F, -7.258F), new Vector2(67.189F, 14.072F), new Vector2(67.189F, 14.072F));
                    builder.AddCubicBezier(new Vector2(67.189F, 14.072F), new Vector2(5.807F, -27.58F), new Vector2(5.807F, -27.58F));
                    builder.AddCubicBezier(new Vector2(5.807F, -27.58F), new Vector2(-10.258F, -14.863F), new Vector2(-10.258F, -14.863F));
                    builder.AddCubicBezier(new Vector2(-10.258F, -14.863F), new Vector2(-14.516F, -18.871F), new Vector2(-14.516F, -18.871F));
                    builder.AddCubicBezier(new Vector2(-14.516F, -18.871F), new Vector2(-43.669F, 1.409F), new Vector2(-43.669F, 1.409F));
                    builder.AddCubicBezier(new Vector2(-43.669F, 1.409F), new Vector2(-101.613F, -18.871F), new Vector2(-101.613F, -18.871F));
                    builder.AddCubicBezier(new Vector2(-101.613F, -18.871F), new Vector2(-115.221F, -11.31F), new Vector2(-115.221F, -11.31F));
                    builder.AddCubicBezier(new Vector2(-115.221F, -11.31F), new Vector2(-115.622F, 27.58F), new Vector2(-115.622F, 27.58F));
                    builder.AddCubicBezier(new Vector2(-115.622F, 27.58F), new Vector2(-81.29F, 27.58F), new Vector2(-81.29F, 27.58F));
                    builder.AddCubicBezier(new Vector2(-81.29F, 27.58F), new Vector2(-63.871F, 27.58F), new Vector2(-63.871F, 27.58F));
                    builder.AddCubicBezier(new Vector2(-63.871F, 27.58F), new Vector2(-43.548F, 27.58F), new Vector2(-43.548F, 27.58F));
                    builder.AddCubicBezier(new Vector2(-43.548F, 27.58F), new Vector2(34.839F, 27.58F), new Vector2(34.839F, 27.58F));
                    builder.AddCubicBezier(new Vector2(34.839F, 27.58F), new Vector2(43.549F, 27.58F), new Vector2(43.549F, 27.58F));
                    builder.AddCubicBezier(new Vector2(43.549F, 27.58F), new Vector2(87.097F, 27.58F), new Vector2(87.097F, 27.58F));
                    builder.AddCubicBezier(new Vector2(87.097F, 27.58F), new Vector2(119.788F, 27.696F), new Vector2(119.788F, 27.696F));
                    builder.AddCubicBezier(new Vector2(119.788F, 27.696F), new Vector2(119.788F, -1.335F), new Vector2(119.788F, -1.335F));
                    builder.AddCubicBezier(new Vector2(119.788F, -1.335F), new Vector2(104.516F, -7.258F), new Vector2(104.516F, -7.258F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0017()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(101.05F, -7.283F));
                    builder.AddCubicBezier(new Vector2(101.05F, -7.283F), new Vector2(83.238F, -2.674F), new Vector2(83.238F, -2.674F));
                    builder.AddCubicBezier(new Vector2(83.238F, -2.674F), new Vector2(60.276F, -15.967F), new Vector2(60.276F, -15.967F));
                    builder.AddCubicBezier(new Vector2(60.276F, -15.967F), new Vector2(-2.542F, 13.705F), new Vector2(-2.542F, 13.705F));
                    builder.AddCubicBezier(new Vector2(-2.542F, 13.705F), new Vector2(-60.968F, -10.161F), new Vector2(-60.968F, -10.161F));
                    builder.AddCubicBezier(new Vector2(-60.968F, -10.161F), new Vector2(-80.062F, -1.116F), new Vector2(-80.062F, -1.116F));
                    builder.AddCubicBezier(new Vector2(-80.062F, -1.116F), new Vector2(-115.9F, -10.081F), new Vector2(-115.9F, -10.081F));
                    builder.AddCubicBezier(new Vector2(-115.9F, -10.081F), new Vector2(-116.129F, 15.968F), new Vector2(-116.129F, 15.968F));
                    builder.AddCubicBezier(new Vector2(-116.129F, 15.968F), new Vector2(-78.387F, 15.968F), new Vector2(-78.387F, 15.968F));
                    builder.AddCubicBezier(new Vector2(-78.387F, 15.968F), new Vector2(-17.419F, 15.968F), new Vector2(-17.419F, 15.968F));
                    builder.AddCubicBezier(new Vector2(-17.419F, 15.968F), new Vector2(20.322F, 15.968F), new Vector2(20.322F, 15.968F));
                    builder.AddCubicBezier(new Vector2(20.322F, 15.968F), new Vector2(22.534F, 15.968F), new Vector2(22.534F, 15.968F));
                    builder.AddCubicBezier(new Vector2(22.534F, 15.968F), new Vector2(35.14F, 30.005F), new Vector2(35.14F, 30.005F));
                    builder.AddCubicBezier(new Vector2(35.14F, 30.005F), new Vector2(100.859F, 31.099F), new Vector2(100.859F, 31.099F));
                    builder.AddCubicBezier(new Vector2(100.859F, 31.099F), new Vector2(101.05F, -7.283F), new Vector2(101.05F, -7.283F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0018()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(41.294F, -24.448F));
                    builder.AddCubicBezier(new Vector2(41.294F, -24.448F), new Vector2(-102.076F, -13.895F), new Vector2(-102.076F, -13.895F));
                    builder.AddCubicBezier(new Vector2(-102.076F, -13.895F), new Vector2(-102.103F, 17.761F), new Vector2(-102.103F, 17.761F));
                    builder.AddCubicBezier(new Vector2(-102.103F, 17.761F), new Vector2(114.558F, 17.984F), new Vector2(114.558F, 17.984F));
                    builder.AddCubicBezier(new Vector2(114.558F, 17.984F), new Vector2(114.499F, -6.961F), new Vector2(114.499F, -6.961F));
                    builder.AddCubicBezier(new Vector2(114.499F, -6.961F), new Vector2(41.294F, -24.448F), new Vector2(41.294F, -24.448F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0019()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-5.144F, -0.67F));
                    builder.AddCubicBezier(new Vector2(-5.077F, -0.67F), new Vector2(-4.975F, -0.67F), new Vector2(-4.873F, -0.638F));
                    builder.AddCubicBezier(new Vector2(-5.042F, -0.949F), new Vector2(-5.144F, -1.323F), new Vector2(-5.144F, -1.697F));
                    builder.AddCubicBezier(new Vector2(-5.144F, -2.972F), new Vector2(-4.032F, -4), new Vector2(-2.616F, -4));
                    builder.AddCubicBezier(new Vector2(-1.331F, -4), new Vector2(-0.254F, -3.128F), new Vector2(-0.12F, -1.947F));
                    builder.AddCubicBezier(new Vector2(0.355F, -2.443F), new Vector2(1.028F, -2.723F), new Vector2(1.77F, -2.723F));
                    builder.AddCubicBezier(new Vector2(3.119F, -2.723F), new Vector2(4.201F, -1.76F), new Vector2(4.268F, -0.514F));
                    builder.AddCubicBezier(new Vector2(4.537F, -0.608F), new Vector2(4.84F, -0.67F), new Vector2(5.144F, -0.67F));
                    builder.AddCubicBezier(new Vector2(6.561F, -0.67F), new Vector2(7.675F, 0.39F), new Vector2(7.675F, 1.663F));
                    builder.AddCubicBezier(new Vector2(7.675F, 2.941F), new Vector2(6.561F, 4), new Vector2(5.144F, 4));
                    builder.AddCubicBezier(new Vector2(5.144F, 4), new Vector2(-5.144F, 4), new Vector2(-5.144F, 4));
                    builder.AddCubicBezier(new Vector2(-6.561F, 4), new Vector2(-7.675F, 2.941F), new Vector2(-7.675F, 1.663F));
                    builder.AddCubicBezier(new Vector2(-7.675F, 0.39F), new Vector2(-6.561F, -0.67F), new Vector2(-5.144F, -0.67F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0020()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(3.524F, -0.502F));
                    builder.AddCubicBezier(new Vector2(3.478F, -0.502F), new Vector2(3.409F, -0.502F), new Vector2(3.338F, -0.479F));
                    builder.AddCubicBezier(new Vector2(3.455F, -0.711F), new Vector2(3.524F, -0.991F), new Vector2(3.524F, -1.273F));
                    builder.AddCubicBezier(new Vector2(3.524F, -2.229F), new Vector2(2.762F, -3), new Vector2(1.792F, -3));
                    builder.AddCubicBezier(new Vector2(0.913F, -3), new Vector2(0.174F, -2.345F), new Vector2(0.082F, -1.46F));
                    builder.AddCubicBezier(new Vector2(-0.244F, -1.832F), new Vector2(-0.705F, -2.042F), new Vector2(-1.212F, -2.042F));
                    builder.AddCubicBezier(new Vector2(-2.137F, -2.042F), new Vector2(-2.877F, -1.32F), new Vector2(-2.924F, -0.385F));
                    builder.AddCubicBezier(new Vector2(-3.108F, -0.456F), new Vector2(-3.316F, -0.502F), new Vector2(-3.524F, -0.502F));
                    builder.AddCubicBezier(new Vector2(-4.495F, -0.502F), new Vector2(-5.258F, 0.293F), new Vector2(-5.258F, 1.248F));
                    builder.AddCubicBezier(new Vector2(-5.258F, 2.206F), new Vector2(-4.495F, 3), new Vector2(-3.524F, 3));
                    builder.AddCubicBezier(new Vector2(-3.524F, 3), new Vector2(3.524F, 3), new Vector2(3.524F, 3));
                    builder.AddCubicBezier(new Vector2(4.495F, 3), new Vector2(5.258F, 2.206F), new Vector2(5.258F, 1.248F));
                    builder.AddCubicBezier(new Vector2(5.258F, 0.293F), new Vector2(4.495F, -0.502F), new Vector2(3.524F, -0.502F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0021()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(7.641F, -0.06F));
                    builder.AddCubicBezier(new Vector2(7.641F, -0.06F), new Vector2(7.57F, -0.06F), new Vector2(7.57F, -0.06F));
                    builder.AddCubicBezier(new Vector2(7.521F, -3.067F), new Vector2(5.05F, -5.5F), new Vector2(1.975F, -5.5F));
                    builder.AddCubicBezier(new Vector2(-0.882F, -5.5F), new Vector2(-3.231F, -3.402F), new Vector2(-3.546F, -0.682F));
                    builder.AddCubicBezier(new Vector2(-4.273F, -1.563F), new Vector2(-5.365F, -2.137F), new Vector2(-6.6F, -2.137F));
                    builder.AddCubicBezier(new Vector2(-8.73F, -2.137F), new Vector2(-10.451F, -0.417F), new Vector2(-10.451F, 1.682F));
                    builder.AddCubicBezier(new Vector2(-10.451F, 3.782F), new Vector2(-8.73F, 5.5F), new Vector2(-6.6F, 5.5F));
                    builder.AddCubicBezier(new Vector2(-6.6F, 5.5F), new Vector2(7.641F, 5.5F), new Vector2(7.641F, 5.5F));
                    builder.AddCubicBezier(new Vector2(9.192F, 5.5F), new Vector2(10.451F, 4.259F), new Vector2(10.451F, 2.708F));
                    builder.AddCubicBezier(new Vector2(10.451F, 1.181F), new Vector2(9.192F, -0.06F), new Vector2(7.641F, -0.06F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0022()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-22.976F, 111.469F));
                    builder.AddCubicBezier(new Vector2(-22.976F, 111.469F), new Vector2(-22.976F, 150.007F), new Vector2(-22.976F, 150.007F));
                    builder.AddCubicBezier(new Vector2(-22.976F, 150.007F), new Vector2(-57.019F, 150.007F), new Vector2(-57.019F, 150.007F));
                    builder.AddCubicBezier(new Vector2(-57.019F, 153.746F), new Vector2(-69.177F, 156.541F), new Vector2(-72.024F, 158.531F));
                    builder.AddCubicBezier(new Vector2(-70.659F, 132.367F), new Vector2(-49.481F, 111.469F), new Vector2(-22.976F, 111.469F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0023()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-19.973F, 107.473F));
                    builder.AddCubicBezier(new Vector2(-19.973F, 107.473F), new Vector2(-19.973F, 112.978F), new Vector2(-19.973F, 112.978F));
                    builder.AddCubicBezier(new Vector2(-46.478F, 112.978F), new Vector2(-67.656F, 133.876F), new Vector2(-69.021F, 160.039F));
                    builder.AddCubicBezier(new Vector2(-70.806F, 161.289F), new Vector2(-75.18F, 162.527F), new Vector2(-77.527F, 162.527F));
                    builder.AddCubicBezier(new Vector2(-77.527F, 132.096F), new Vector2(-50.403F, 107.473F), new Vector2(-19.973F, 107.473F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0024()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-57.779F, 37.838F));
                    builder.AddCubicBezier(new Vector2(-57.779F, 57.685F), new Vector2(-43.433F, 73.516F), new Vector2(-24.745F, 77.456F));
                    builder.AddCubicBezier(new Vector2(-35.272F, 66.126F), new Vector2(-41.263F, 52.443F), new Vector2(-41.263F, 37.838F));
                    builder.AddCubicBezier(new Vector2(-41.263F, 37.838F), new Vector2(-41.263F, 32.334F), new Vector2(-41.263F, 32.334F));
                    builder.AddCubicBezier(new Vector2(-38.22F, 32.334F), new Vector2(-35.758F, 34.795F), new Vector2(-35.758F, 37.838F));
                    builder.AddCubicBezier(new Vector2(-35.758F, 43.234F), new Vector2(-34.584F, 48.443F), new Vector2(-32.898F, 53.519F));
                    builder.AddCubicBezier(new Vector2(-32.898F, 53.519F), new Vector2(-26.896F, 41.511F), new Vector2(-26.896F, 41.511F));
                    builder.AddCubicBezier(new Vector2(-25.543F, 38.807F), new Vector2(-22.253F, 37.71F), new Vector2(-19.546F, 39.063F));
                    builder.AddCubicBezier(new Vector2(-19.546F, 39.063F), new Vector2(-19.543F, 39.066F), new Vector2(-19.543F, 39.066F));
                    builder.AddCubicBezier(new Vector2(-19.543F, 39.066F), new Vector2(-30.299F, 60.572F), new Vector2(-30.299F, 60.572F));
                    builder.AddCubicBezier(new Vector2(-27.632F, 65.873F), new Vector2(-23.729F, 70.698F), new Vector2(-19.242F, 75.215F));
                    builder.AddCubicBezier(new Vector2(-19.242F, 75.215F), new Vector2(-19.242F, 59.86F), new Vector2(-19.242F, 59.86F));
                    builder.AddCubicBezier(new Vector2(-19.242F, 59.86F), new Vector2(-19.242F, 54.356F), new Vector2(-19.242F, 54.356F));
                    builder.AddCubicBezier(new Vector2(-16.199F, 54.356F), new Vector2(-13.737F, 56.818F), new Vector2(-13.737F, 59.86F));
                    builder.AddCubicBezier(new Vector2(-13.737F, 59.86F), new Vector2(-13.737F, 79.13F), new Vector2(-13.737F, 79.13F));
                    builder.AddCubicBezier(new Vector2(-13.737F, 79.13F), new Vector2(-5.479F, 79.13F), new Vector2(-5.479F, 79.13F));
                    builder.AddCubicBezier(new Vector2(-0.92F, 79.13F), new Vector2(2.779F, 75.43F), new Vector2(2.779F, 70.87F));
                    builder.AddCubicBezier(new Vector2(2.779F, 67.827F), new Vector2(5.241F, 65.365F), new Vector2(8.284F, 65.365F));
                    builder.AddCubicBezier(new Vector2(8.284F, 65.365F), new Vector2(8.284F, 70.87F), new Vector2(8.284F, 70.87F));
                    builder.AddCubicBezier(new Vector2(8.284F, 77.524F), new Vector2(3.213F, 82.362F), new Vector2(-3.07F, 83.637F));
                    builder.AddCubicBezier(new Vector2(3.605F, 88.08F), new Vector2(8.284F, 95.304F), new Vector2(8.284F, 103.903F));
                    builder.AddCubicBezier(new Vector2(8.284F, 103.903F), new Vector2(8.284F, 117.666F), new Vector2(8.284F, 117.666F));
                    builder.AddCubicBezier(new Vector2(8.284F, 117.666F), new Vector2(2.779F, 117.666F), new Vector2(2.779F, 117.666F));
                    builder.AddCubicBezier(new Vector2(2.779F, 117.666F), new Vector2(2.779F, 103.903F), new Vector2(2.779F, 103.903F));
                    builder.AddCubicBezier(new Vector2(2.779F, 93.28F), new Vector2(-5.866F, 84.635F), new Vector2(-16.489F, 84.635F));
                    builder.AddCubicBezier(new Vector2(-42.296F, 84.635F), new Vector2(-63.284F, 63.645F), new Vector2(-63.284F, 37.838F));
                    builder.AddCubicBezier(new Vector2(-63.284F, 37.838F), new Vector2(-63.284F, 32.334F), new Vector2(-63.284F, 32.334F));
                    builder.AddCubicBezier(new Vector2(-60.241F, 32.334F), new Vector2(-57.779F, 34.795F), new Vector2(-57.779F, 37.838F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0025()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-57.779F, 70.87F));
                    builder.AddCubicBezier(new Vector2(-57.779F, 75.43F), new Vector2(-54.081F, 79.129F), new Vector2(-49.522F, 79.129F));
                    builder.AddCubicBezier(new Vector2(-49.522F, 79.129F), new Vector2(-41.263F, 79.129F), new Vector2(-41.263F, 79.129F));
                    builder.AddCubicBezier(new Vector2(-41.263F, 79.129F), new Vector2(-41.263F, 59.859F), new Vector2(-41.263F, 59.859F));
                    builder.AddCubicBezier(new Vector2(-41.263F, 56.816F), new Vector2(-38.8F, 54.354F), new Vector2(-35.758F, 54.354F));
                    builder.AddCubicBezier(new Vector2(-35.758F, 54.354F), new Vector2(-35.758F, 59.859F), new Vector2(-35.758F, 59.859F));
                    builder.AddCubicBezier(new Vector2(-35.758F, 59.859F), new Vector2(-35.758F, 75.215F), new Vector2(-35.758F, 75.215F));
                    builder.AddCubicBezier(new Vector2(-31.271F, 70.698F), new Vector2(-27.369F, 65.874F), new Vector2(-24.702F, 60.573F));
                    builder.AddCubicBezier(new Vector2(-24.702F, 60.573F), new Vector2(-35.456F, 39.064F), new Vector2(-35.456F, 39.064F));
                    builder.AddCubicBezier(new Vector2(-35.456F, 39.064F), new Vector2(-35.455F, 39.061F), new Vector2(-35.455F, 39.061F));
                    builder.AddCubicBezier(new Vector2(-32.748F, 37.709F), new Vector2(-29.457F, 38.806F), new Vector2(-28.105F, 41.51F));
                    builder.AddCubicBezier(new Vector2(-28.105F, 41.51F), new Vector2(-22.103F, 53.518F), new Vector2(-22.103F, 53.518F));
                    builder.AddCubicBezier(new Vector2(-20.417F, 48.443F), new Vector2(-19.242F, 43.234F), new Vector2(-19.242F, 37.839F));
                    builder.AddCubicBezier(new Vector2(-19.242F, 34.796F), new Vector2(-16.78F, 32.333F), new Vector2(-13.737F, 32.333F));
                    builder.AddCubicBezier(new Vector2(-13.737F, 32.333F), new Vector2(-13.737F, 37.839F), new Vector2(-13.737F, 37.839F));
                    builder.AddCubicBezier(new Vector2(-13.737F, 52.444F), new Vector2(-19.729F, 66.127F), new Vector2(-30.256F, 77.457F));
                    builder.AddCubicBezier(new Vector2(-11.568F, 73.517F), new Vector2(2.779F, 57.685F), new Vector2(2.779F, 37.839F));
                    builder.AddCubicBezier(new Vector2(2.779F, 34.796F), new Vector2(5.241F, 32.333F), new Vector2(8.284F, 32.333F));
                    builder.AddCubicBezier(new Vector2(8.284F, 32.333F), new Vector2(8.284F, 37.839F), new Vector2(8.284F, 37.839F));
                    builder.AddCubicBezier(new Vector2(8.284F, 63.645F), new Vector2(-12.705F, 84.634F), new Vector2(-38.511F, 84.634F));
                    builder.AddCubicBezier(new Vector2(-49.135F, 84.634F), new Vector2(-57.779F, 93.279F), new Vector2(-57.779F, 103.902F));
                    builder.AddCubicBezier(new Vector2(-57.779F, 103.902F), new Vector2(-57.779F, 117.667F), new Vector2(-57.779F, 117.667F));
                    builder.AddCubicBezier(new Vector2(-57.779F, 117.667F), new Vector2(-63.284F, 117.667F), new Vector2(-63.284F, 117.667F));
                    builder.AddCubicBezier(new Vector2(-63.284F, 117.667F), new Vector2(-63.284F, 103.902F), new Vector2(-63.284F, 103.902F));
                    builder.AddCubicBezier(new Vector2(-63.284F, 95.303F), new Vector2(-58.605F, 88.081F), new Vector2(-51.93F, 83.638F));
                    builder.AddCubicBezier(new Vector2(-58.213F, 82.363F), new Vector2(-63.284F, 77.523F), new Vector2(-63.284F, 70.87F));
                    builder.AddCubicBezier(new Vector2(-63.284F, 70.87F), new Vector2(-63.284F, 65.366F), new Vector2(-63.284F, 65.366F));
                    builder.AddCubicBezier(new Vector2(-60.241F, 65.366F), new Vector2(-57.779F, 67.827F), new Vector2(-57.779F, 70.87F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0026()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-38.51F, 88.763F));
                    builder.AddCubicBezier(new Vector2(-38.51F, 85.72F), new Vector2(-36.049F, 83.258F), new Vector2(-33.006F, 83.258F));
                    builder.AddCubicBezier(new Vector2(-23.877F, 83.258F), new Vector2(-16.49F, 75.87F), new Vector2(-16.49F, 66.742F));
                    builder.AddCubicBezier(new Vector2(-16.49F, 66.742F), new Vector2(-16.49F, 61.237F), new Vector2(-16.49F, 61.237F));
                    builder.AddCubicBezier(new Vector2(-16.49F, 61.237F), new Vector2(-21.995F, 61.237F), new Vector2(-21.995F, 61.237F));
                    builder.AddCubicBezier(new Vector2(-31.124F, 61.237F), new Vector2(-38.51F, 68.624F), new Vector2(-38.51F, 77.753F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0027()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-16.489F, 88.763F));
                    builder.AddCubicBezier(new Vector2(-16.489F, 85.72F), new Vector2(-18.951F, 83.258F), new Vector2(-21.994F, 83.258F));
                    builder.AddCubicBezier(new Vector2(-31.123F, 83.258F), new Vector2(-38.511F, 75.87F), new Vector2(-38.511F, 66.742F));
                    builder.AddCubicBezier(new Vector2(-38.511F, 66.742F), new Vector2(-38.511F, 61.237F), new Vector2(-38.511F, 61.237F));
                    builder.AddCubicBezier(new Vector2(-38.511F, 61.237F), new Vector2(-33.006F, 61.237F), new Vector2(-33.006F, 61.237F));
                    builder.AddCubicBezier(new Vector2(-23.877F, 61.237F), new Vector2(-16.489F, 68.624F), new Vector2(-16.489F, 77.753F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0028()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(6.522F, 17.457F));
                    builder.AddCubicBezier(new Vector2(6.522F, 17.457F), new Vector2(5.677F, 37.602F), new Vector2(5.677F, 37.602F));
                    builder.AddCubicBezier(new Vector2(5.677F, 37.602F), new Vector2(47.01F, 43.543F), new Vector2(47.01F, 43.543F));
                    builder.AddCubicBezier(new Vector2(47.01F, 43.543F), new Vector2(31.494F, 45.043F), new Vector2(31.494F, 45.043F));
                    builder.AddCubicBezier(new Vector2(31.494F, 45.043F), new Vector2(-5.839F, 51.852F), new Vector2(-5.839F, 51.852F));
                    builder.AddCubicBezier(new Vector2(-5.839F, 51.852F), new Vector2(-26.522F, 28.457F), new Vector2(-26.522F, 28.457F));
                    builder.AddCubicBezier(new Vector2(-26.522F, 28.457F), new Vector2(6.522F, 17.457F), new Vector2(6.522F, 17.457F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0029()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-50.942F, 59.485F));
                    builder.AddCubicBezier(new Vector2(-50.942F, 53.035F), new Vector2(-24.344F, 46.194F), new Vector2(-19.242F, 41.967F));
                    builder.AddCubicBezier(new Vector2(-14.14F, 37.741F), new Vector2(-10.984F, 31.902F), new Vector2(-10.984F, 25.452F));
                    builder.AddCubicBezier(new Vector2(-10.984F, 16.33F), new Vector2(-18.378F, 8.936F), new Vector2(-27.5F, 8.936F));
                    builder.AddCubicBezier(new Vector2(-36.622F, 8.936F), new Vector2(-44.016F, 16.33F), new Vector2(-44.016F, 25.452F));
                    builder.AddCubicBezier(new Vector2(-44.016F, 25.452F), new Vector2(-79.016F, 62.355F), new Vector2(-79.016F, 62.355F));
                    builder.AddCubicBezier(new Vector2(-79.016F, 62.355F), new Vector2(-17.016F, 68.064F), new Vector2(-17.016F, 68.064F));
                    builder.AddCubicBezier(new Vector2(-17.016F, 68.064F), new Vector2(-4.5F, 65.064F), new Vector2(-4.5F, 65.064F));
                    builder.AddCubicBezier(new Vector2(-4.5F, 65.064F), new Vector2(-50.942F, 59.485F), new Vector2(-50.942F, 59.485F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0030()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(101.876F, 14.441F));
                    builder.AddCubicBezier(new Vector2(101.876F, 47.093F), new Vector2(84.11F, 75.596F), new Vector2(57.716F, 90.81F));
                    builder.AddCubicBezier(new Vector2(44.786F, 98.263F), new Vector2(29.786F, 102.527F), new Vector2(13.79F, 102.527F));
                    builder.AddCubicBezier(new Vector2(13.79F, 102.527F), new Vector2(-95.146F, 127.777F), new Vector2(-95.146F, 127.777F));
                    builder.AddCubicBezier(new Vector2(-90.685F, 127.499F), new Vector2(-129.428F, 106.162F), new Vector2(-129.428F, 106.162F));
                    builder.AddCubicBezier(new Vector2(-129.428F, 106.162F), new Vector2(-110.875F, 96.074F), new Vector2(-110.875F, 96.074F));
                    builder.AddCubicBezier(new Vector2(-110.875F, 96.074F), new Vector2(-92.766F, 116.449F), new Vector2(-92.766F, 116.449F));
                    builder.AddCubicBezier(new Vector2(-92.766F, 116.449F), new Vector2(-134.329F, 127.298F), new Vector2(-134.329F, 127.298F));
                    builder.AddCubicBezier(new Vector2(-134.329F, 127.298F), new Vector2(-134.87F, 110.152F), new Vector2(-134.87F, 110.152F));
                    builder.AddCubicBezier(new Vector2(-134.87F, 110.152F), new Vector2(-134.855F, 88.484F), new Vector2(-134.855F, 88.484F));
                    builder.AddCubicBezier(new Vector2(-134.855F, 64.16F), new Vector2(-115.136F, 44.441F), new Vector2(-90.812F, 44.441F));
                    builder.AddCubicBezier(new Vector2(-90.812F, 44.441F), new Vector2(35.812F, 14.441F), new Vector2(35.812F, 14.441F));
                    builder.AddCubicBezier(new Vector2(47.983F, 14.441F), new Vector2(57.833F, 4.591F), new Vector2(57.833F, -7.58F));
                    builder.AddCubicBezier(new Vector2(57.833F, -7.58F), new Vector2(57.833F, -24.096F), new Vector2(57.833F, -24.096F));
                    builder.AddCubicBezier(new Vector2(57.833F, -33.225F), new Vector2(65.22F, -40.613F), new Vector2(74.349F, -40.613F));
                    builder.AddCubicBezier(new Vector2(74.349F, -40.613F), new Vector2(85.36F, -40.613F), new Vector2(85.36F, -40.613F));
                    builder.AddCubicBezier(new Vector2(94.489F, -40.613F), new Vector2(101.876F, -33.225F), new Vector2(101.876F, -24.096F));
                    builder.AddCubicBezier(new Vector2(101.876F, -24.096F), new Vector2(101.876F, 14.441F), new Vector2(101.876F, 14.441F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0031()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-16.489F, 75));
                    builder.AddCubicBezier(new Vector2(-16.489F, 81.086F), new Vector2(-21.415F, 86.011F), new Vector2(-27.501F, 86.011F));
                    builder.AddCubicBezier(new Vector2(-33.587F, 86.011F), new Vector2(-38.511F, 81.086F), new Vector2(-38.511F, 75));
                    builder.AddCubicBezier(new Vector2(-38.511F, 75), new Vector2(-38.511F, 69.494F), new Vector2(-38.511F, 69.494F));
                    builder.AddCubicBezier(new Vector2(-38.511F, 66.451F), new Vector2(-36.049F, 63.989F), new Vector2(-33.006F, 63.989F));
                    builder.AddCubicBezier(new Vector2(-33.006F, 63.989F), new Vector2(-21.994F, 63.989F), new Vector2(-21.994F, 63.989F));
                    builder.AddCubicBezier(new Vector2(-18.951F, 63.989F), new Vector2(-16.489F, 66.451F), new Vector2(-16.489F, 69.494F));
                    builder.AddCubicBezier(new Vector2(-16.489F, 69.494F), new Vector2(-16.489F, 75), new Vector2(-16.489F, 75));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0032()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-30.252F, 75));
                    builder.AddCubicBezier(new Vector2(-30.252F, 76.521F), new Vector2(-29.021F, 77.753F), new Vector2(-27.5F, 77.753F));
                    builder.AddCubicBezier(new Vector2(-25.98F, 77.753F), new Vector2(-24.748F, 76.521F), new Vector2(-24.748F, 75));
                    builder.AddCubicBezier(new Vector2(-24.748F, 73.479F), new Vector2(-25.98F, 72.247F), new Vector2(-27.5F, 72.247F));
                    builder.AddCubicBezier(new Vector2(-29.021F, 72.247F), new Vector2(-30.252F, 73.479F), new Vector2(-30.252F, 75));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0033()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-21.994F, 72.247F));
                    builder.AddCubicBezier(new Vector2(-21.994F, 70.726F), new Vector2(-23.226F, 69.494F), new Vector2(-24.747F, 69.494F));
                    builder.AddCubicBezier(new Vector2(-24.747F, 69.494F), new Vector2(-30.253F, 69.494F), new Vector2(-30.253F, 69.494F));
                    builder.AddCubicBezier(new Vector2(-31.774F, 69.494F), new Vector2(-33.006F, 70.726F), new Vector2(-33.006F, 72.247F));
                    builder.AddCubicBezier(new Vector2(-33.006F, 72.247F), new Vector2(-33.006F, 75.001F), new Vector2(-33.006F, 75.001F));
                    builder.AddCubicBezier(new Vector2(-33.006F, 78.041F), new Vector2(-30.54F, 80.506F), new Vector2(-27.499F, 80.506F));
                    builder.AddCubicBezier(new Vector2(-24.459F, 80.506F), new Vector2(-21.994F, 78.041F), new Vector2(-21.994F, 75.001F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0034()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(42.506F, -6.505F));
                    builder.AddCubicBezier(new Vector2(42.506F, -6.505F), new Vector2(48.01F, 6.505F), new Vector2(48.01F, 6.505F));
                    builder.AddCubicBezier(new Vector2(48.01F, 6.505F), new Vector2(25.99F, 6.505F), new Vector2(25.99F, 6.505F));
                    builder.AddCubicBezier(new Vector2(25.99F, 6.505F), new Vector2(25.99F, -4.505F), new Vector2(25.99F, -4.505F));
                    builder.AddCubicBezier(new Vector2(25.99F, -4.505F), new Vector2(42.506F, -6.505F), new Vector2(42.506F, -6.505F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0035()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(42.116F, -4.67F));
                    builder.AddCubicBezier(new Vector2(42.116F, -4.67F), new Vector2(47.621F, 6.341F), new Vector2(47.621F, 6.341F));
                    builder.AddCubicBezier(new Vector2(47.621F, 6.341F), new Vector2(25.6F, 6.341F), new Vector2(25.6F, 6.341F));
                    builder.AddCubicBezier(new Vector2(25.6F, 6.341F), new Vector2(25.6F, -4.67F), new Vector2(25.6F, -4.67F));
                    builder.AddCubicBezier(new Vector2(25.6F, -4.67F), new Vector2(42.116F, -4.67F), new Vector2(42.116F, -4.67F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0036()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(1.006F, -6.505F));
                    builder.AddCubicBezier(new Vector2(1.006F, -6.505F), new Vector2(12.51F, 5.005F), new Vector2(12.51F, 5.005F));
                    builder.AddCubicBezier(new Vector2(12.51F, 5.005F), new Vector2(-10.01F, 5.505F), new Vector2(-10.01F, 5.505F));
                    builder.AddCubicBezier(new Vector2(-10.01F, 5.505F), new Vector2(-11.51F, -3.505F), new Vector2(-11.51F, -3.505F));
                    builder.AddCubicBezier(new Vector2(-11.51F, -3.505F), new Vector2(1.006F, -6.505F), new Vector2(1.006F, -6.505F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0037()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(4.006F, -8.505F));
                    builder.AddCubicBezier(new Vector2(4.006F, -8.505F), new Vector2(11.01F, 5.341F), new Vector2(11.01F, 5.341F));
                    builder.AddCubicBezier(new Vector2(11.01F, 5.341F), new Vector2(-12.51F, 6.005F), new Vector2(-12.51F, 6.005F));
                    builder.AddCubicBezier(new Vector2(-12.51F, 6.005F), new Vector2(-13.51F, -4.005F), new Vector2(-13.51F, -4.005F));
                    builder.AddCubicBezier(new Vector2(-13.51F, -4.005F), new Vector2(4.006F, -8.505F), new Vector2(4.006F, -8.505F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0038()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-30.252F, 75));
                    builder.AddCubicBezier(new Vector2(-30.252F, 75.396F), new Vector2(-30.169F, 75.774F), new Vector2(-30.018F, 76.114F));
                    builder.AddCubicBezier(new Vector2(-29.591F, 77.08F), new Vector2(-28.625F, 77.753F), new Vector2(-27.5F, 77.753F));
                    builder.AddCubicBezier(new Vector2(-25.98F, 77.753F), new Vector2(-24.748F, 76.521F), new Vector2(-24.748F, 75));
                    builder.AddCubicBezier(new Vector2(-24.748F, 73.479F), new Vector2(-25.98F, 72.247F), new Vector2(-27.5F, 72.247F));
                    builder.AddCubicBezier(new Vector2(-29.021F, 72.247F), new Vector2(-30.252F, 73.479F), new Vector2(-30.252F, 75));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0039()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-26.942F, 58.844F));
                    builder.AddCubicBezier(new Vector2(-26.942F, 57.733F), new Vector2(-23.465F, 45.466F), new Vector2(-19.242F, 41.967F));
                    builder.AddCubicBezier(new Vector2(-14.14F, 37.741F), new Vector2(-10.984F, 31.902F), new Vector2(-10.984F, 25.452F));
                    builder.AddCubicBezier(new Vector2(-10.984F, 16.33F), new Vector2(-18.378F, 8.936F), new Vector2(-27.5F, 8.936F));
                    builder.AddCubicBezier(new Vector2(-36.622F, 8.936F), new Vector2(-44.016F, 16.33F), new Vector2(-44.016F, 25.452F));
                    builder.AddCubicBezier(new Vector2(-44.016F, 25.452F), new Vector2(-59.016F, 72.759F), new Vector2(-59.016F, 72.759F));
                    builder.AddCubicBezier(new Vector2(-59.016F, 72.759F), new Vector2(-19.016F, 67.564F), new Vector2(-19.016F, 67.564F));
                    builder.AddCubicBezier(new Vector2(-19.016F, 67.564F), new Vector2(-1.5F, 63.064F), new Vector2(-1.5F, 63.064F));
                    builder.AddCubicBezier(new Vector2(-1.5F, 63.064F), new Vector2(-26.942F, 58.844F), new Vector2(-26.942F, 58.844F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0040()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-27.5F, 67.916F));
                    builder.AddCubicBezier(new Vector2(-20.812F, 67.916F), new Vector2(-15.021F, 64.771F), new Vector2(-10.984F, 60.062F));
                    builder.AddCubicBezier(new Vector2(-10.984F, 60.062F), new Vector2(-10.984F, 68.341F), new Vector2(-10.984F, 68.341F));
                    builder.AddCubicBezier(new Vector2(-10.984F, 68.341F), new Vector2(-10.984F, 78.927F), new Vector2(-10.984F, 78.927F));
                    builder.AddCubicBezier(new Vector2(-10.984F, 85.013F), new Vector2(-15.909F, 89.938F), new Vector2(-21.995F, 89.938F));
                    builder.AddCubicBezier(new Vector2(-21.995F, 89.938F), new Vector2(-33.005F, 89.938F), new Vector2(-33.005F, 89.938F));
                    builder.AddCubicBezier(new Vector2(-39.091F, 89.938F), new Vector2(-44.016F, 85.013F), new Vector2(-44.016F, 78.927F));
                    builder.AddCubicBezier(new Vector2(-44.016F, 78.927F), new Vector2(-44.016F, 62.411F), new Vector2(-44.016F, 62.411F));
                    builder.AddCubicBezier(new Vector2(-44.016F, 62.411F), new Vector2(-44.016F, 60.064F), new Vector2(-44.016F, 60.064F));
                    builder.AddCubicBezier(new Vector2(-39.973F, 64.771F), new Vector2(-34.188F, 67.916F), new Vector2(-27.5F, 67.916F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0041()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-22.976F, 111.469F));
                    builder.AddCubicBezier(new Vector2(-22.976F, 111.469F), new Vector2(-22.976F, 150.007F), new Vector2(-22.976F, 150.007F));
                    builder.AddCubicBezier(new Vector2(-22.976F, 150.007F), new Vector2(-57.019F, 150.007F), new Vector2(-57.019F, 150.007F));
                    builder.AddCubicBezier(new Vector2(-57.019F, 153.746F), new Vector2(-69.177F, 156.541F), new Vector2(-72.024F, 158.531F));
                    builder.AddCubicBezier(new Vector2(-70.659F, 132.367F), new Vector2(-49.481F, 111.469F), new Vector2(-22.976F, 111.469F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0042()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-19.973F, 107.473F));
                    builder.AddCubicBezier(new Vector2(-19.973F, 107.473F), new Vector2(-19.973F, 112.978F), new Vector2(-19.973F, 112.978F));
                    builder.AddCubicBezier(new Vector2(-46.478F, 112.978F), new Vector2(-67.656F, 133.876F), new Vector2(-69.021F, 160.039F));
                    builder.AddCubicBezier(new Vector2(-70.806F, 161.289F), new Vector2(-75.18F, 162.527F), new Vector2(-77.527F, 162.527F));
                    builder.AddCubicBezier(new Vector2(-77.527F, 132.096F), new Vector2(-50.403F, 107.473F), new Vector2(-19.973F, 107.473F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0043()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-57.779F, 37.838F));
                    builder.AddCubicBezier(new Vector2(-57.779F, 57.685F), new Vector2(-43.433F, 73.516F), new Vector2(-24.745F, 77.456F));
                    builder.AddCubicBezier(new Vector2(-35.272F, 66.126F), new Vector2(-41.263F, 52.443F), new Vector2(-41.263F, 37.838F));
                    builder.AddCubicBezier(new Vector2(-41.263F, 37.838F), new Vector2(-41.263F, 32.334F), new Vector2(-41.263F, 32.334F));
                    builder.AddCubicBezier(new Vector2(-38.22F, 32.334F), new Vector2(-35.758F, 34.795F), new Vector2(-35.758F, 37.838F));
                    builder.AddCubicBezier(new Vector2(-35.758F, 43.234F), new Vector2(-34.584F, 48.443F), new Vector2(-32.898F, 53.519F));
                    builder.AddCubicBezier(new Vector2(-32.898F, 53.519F), new Vector2(-26.896F, 41.511F), new Vector2(-26.896F, 41.511F));
                    builder.AddCubicBezier(new Vector2(-25.543F, 38.807F), new Vector2(-22.253F, 37.71F), new Vector2(-19.546F, 39.063F));
                    builder.AddCubicBezier(new Vector2(-19.546F, 39.063F), new Vector2(-19.543F, 39.066F), new Vector2(-19.543F, 39.066F));
                    builder.AddCubicBezier(new Vector2(-19.543F, 39.066F), new Vector2(-30.299F, 60.572F), new Vector2(-30.299F, 60.572F));
                    builder.AddCubicBezier(new Vector2(-27.632F, 65.873F), new Vector2(-23.729F, 70.698F), new Vector2(-19.242F, 75.215F));
                    builder.AddCubicBezier(new Vector2(-19.242F, 75.215F), new Vector2(-19.242F, 59.86F), new Vector2(-19.242F, 59.86F));
                    builder.AddCubicBezier(new Vector2(-19.242F, 59.86F), new Vector2(-19.242F, 54.356F), new Vector2(-19.242F, 54.356F));
                    builder.AddCubicBezier(new Vector2(-16.199F, 54.356F), new Vector2(-13.737F, 56.818F), new Vector2(-13.737F, 59.86F));
                    builder.AddCubicBezier(new Vector2(-13.737F, 59.86F), new Vector2(-13.737F, 79.13F), new Vector2(-13.737F, 79.13F));
                    builder.AddCubicBezier(new Vector2(-13.737F, 79.13F), new Vector2(-5.479F, 79.13F), new Vector2(-5.479F, 79.13F));
                    builder.AddCubicBezier(new Vector2(-0.92F, 79.13F), new Vector2(2.779F, 75.43F), new Vector2(2.779F, 70.87F));
                    builder.AddCubicBezier(new Vector2(2.779F, 67.827F), new Vector2(5.241F, 65.365F), new Vector2(8.284F, 65.365F));
                    builder.AddCubicBezier(new Vector2(8.284F, 65.365F), new Vector2(8.284F, 70.87F), new Vector2(8.284F, 70.87F));
                    builder.AddCubicBezier(new Vector2(8.284F, 77.524F), new Vector2(3.213F, 82.362F), new Vector2(-3.07F, 83.637F));
                    builder.AddCubicBezier(new Vector2(3.605F, 88.08F), new Vector2(8.284F, 95.304F), new Vector2(8.284F, 103.903F));
                    builder.AddCubicBezier(new Vector2(8.284F, 103.903F), new Vector2(8.284F, 117.666F), new Vector2(8.284F, 117.666F));
                    builder.AddCubicBezier(new Vector2(8.284F, 117.666F), new Vector2(2.779F, 117.666F), new Vector2(2.779F, 117.666F));
                    builder.AddCubicBezier(new Vector2(2.779F, 117.666F), new Vector2(2.779F, 103.903F), new Vector2(2.779F, 103.903F));
                    builder.AddCubicBezier(new Vector2(2.779F, 93.28F), new Vector2(-5.866F, 84.635F), new Vector2(-16.489F, 84.635F));
                    builder.AddCubicBezier(new Vector2(-42.296F, 84.635F), new Vector2(-63.284F, 63.645F), new Vector2(-63.284F, 37.838F));
                    builder.AddCubicBezier(new Vector2(-63.284F, 37.838F), new Vector2(-63.284F, 32.334F), new Vector2(-63.284F, 32.334F));
                    builder.AddCubicBezier(new Vector2(-60.241F, 32.334F), new Vector2(-57.779F, 34.795F), new Vector2(-57.779F, 37.838F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0044()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-57.779F, 70.87F));
                    builder.AddCubicBezier(new Vector2(-57.779F, 75.43F), new Vector2(-54.081F, 79.129F), new Vector2(-49.522F, 79.129F));
                    builder.AddCubicBezier(new Vector2(-49.522F, 79.129F), new Vector2(-41.263F, 79.129F), new Vector2(-41.263F, 79.129F));
                    builder.AddCubicBezier(new Vector2(-41.263F, 79.129F), new Vector2(-41.263F, 59.859F), new Vector2(-41.263F, 59.859F));
                    builder.AddCubicBezier(new Vector2(-41.263F, 56.816F), new Vector2(-38.8F, 54.354F), new Vector2(-35.758F, 54.354F));
                    builder.AddCubicBezier(new Vector2(-35.758F, 54.354F), new Vector2(-35.758F, 59.859F), new Vector2(-35.758F, 59.859F));
                    builder.AddCubicBezier(new Vector2(-35.758F, 59.859F), new Vector2(-35.758F, 75.215F), new Vector2(-35.758F, 75.215F));
                    builder.AddCubicBezier(new Vector2(-31.271F, 70.698F), new Vector2(-27.369F, 65.874F), new Vector2(-24.702F, 60.573F));
                    builder.AddCubicBezier(new Vector2(-24.702F, 60.573F), new Vector2(-35.456F, 39.064F), new Vector2(-35.456F, 39.064F));
                    builder.AddCubicBezier(new Vector2(-35.456F, 39.064F), new Vector2(-35.455F, 39.061F), new Vector2(-35.455F, 39.061F));
                    builder.AddCubicBezier(new Vector2(-32.748F, 37.709F), new Vector2(-29.457F, 38.806F), new Vector2(-28.105F, 41.51F));
                    builder.AddCubicBezier(new Vector2(-28.105F, 41.51F), new Vector2(-22.103F, 53.518F), new Vector2(-22.103F, 53.518F));
                    builder.AddCubicBezier(new Vector2(-20.417F, 48.443F), new Vector2(-19.242F, 43.234F), new Vector2(-19.242F, 37.839F));
                    builder.AddCubicBezier(new Vector2(-19.242F, 34.796F), new Vector2(-16.78F, 32.333F), new Vector2(-13.737F, 32.333F));
                    builder.AddCubicBezier(new Vector2(-13.737F, 32.333F), new Vector2(-13.737F, 37.839F), new Vector2(-13.737F, 37.839F));
                    builder.AddCubicBezier(new Vector2(-13.737F, 52.444F), new Vector2(-19.729F, 66.127F), new Vector2(-30.256F, 77.457F));
                    builder.AddCubicBezier(new Vector2(-11.568F, 73.517F), new Vector2(2.779F, 57.685F), new Vector2(2.779F, 37.839F));
                    builder.AddCubicBezier(new Vector2(2.779F, 34.796F), new Vector2(5.241F, 32.333F), new Vector2(8.284F, 32.333F));
                    builder.AddCubicBezier(new Vector2(8.284F, 32.333F), new Vector2(8.284F, 37.839F), new Vector2(8.284F, 37.839F));
                    builder.AddCubicBezier(new Vector2(8.284F, 63.645F), new Vector2(-12.705F, 84.634F), new Vector2(-38.511F, 84.634F));
                    builder.AddCubicBezier(new Vector2(-49.135F, 84.634F), new Vector2(-57.779F, 93.279F), new Vector2(-57.779F, 103.902F));
                    builder.AddCubicBezier(new Vector2(-57.779F, 103.902F), new Vector2(-57.779F, 117.667F), new Vector2(-57.779F, 117.667F));
                    builder.AddCubicBezier(new Vector2(-57.779F, 117.667F), new Vector2(-63.284F, 117.667F), new Vector2(-63.284F, 117.667F));
                    builder.AddCubicBezier(new Vector2(-63.284F, 117.667F), new Vector2(-63.284F, 103.902F), new Vector2(-63.284F, 103.902F));
                    builder.AddCubicBezier(new Vector2(-63.284F, 95.303F), new Vector2(-58.605F, 88.081F), new Vector2(-51.93F, 83.638F));
                    builder.AddCubicBezier(new Vector2(-58.213F, 82.363F), new Vector2(-63.284F, 77.523F), new Vector2(-63.284F, 70.87F));
                    builder.AddCubicBezier(new Vector2(-63.284F, 70.87F), new Vector2(-63.284F, 65.366F), new Vector2(-63.284F, 65.366F));
                    builder.AddCubicBezier(new Vector2(-60.241F, 65.366F), new Vector2(-57.779F, 67.827F), new Vector2(-57.779F, 70.87F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0045()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-38.51F, 88.763F));
                    builder.AddCubicBezier(new Vector2(-38.51F, 85.72F), new Vector2(-36.049F, 83.258F), new Vector2(-33.006F, 83.258F));
                    builder.AddCubicBezier(new Vector2(-23.877F, 83.258F), new Vector2(-16.49F, 75.87F), new Vector2(-16.49F, 66.742F));
                    builder.AddCubicBezier(new Vector2(-16.49F, 66.742F), new Vector2(-16.49F, 61.237F), new Vector2(-16.49F, 61.237F));
                    builder.AddCubicBezier(new Vector2(-16.49F, 61.237F), new Vector2(-21.995F, 61.237F), new Vector2(-21.995F, 61.237F));
                    builder.AddCubicBezier(new Vector2(-31.124F, 61.237F), new Vector2(-38.51F, 68.624F), new Vector2(-38.51F, 77.753F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0046()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-16.489F, 88.763F));
                    builder.AddCubicBezier(new Vector2(-16.489F, 85.72F), new Vector2(-18.951F, 83.258F), new Vector2(-21.994F, 83.258F));
                    builder.AddCubicBezier(new Vector2(-31.123F, 83.258F), new Vector2(-38.511F, 75.87F), new Vector2(-38.511F, 66.742F));
                    builder.AddCubicBezier(new Vector2(-38.511F, 66.742F), new Vector2(-38.511F, 61.237F), new Vector2(-38.511F, 61.237F));
                    builder.AddCubicBezier(new Vector2(-38.511F, 61.237F), new Vector2(-33.006F, 61.237F), new Vector2(-33.006F, 61.237F));
                    builder.AddCubicBezier(new Vector2(-23.877F, 61.237F), new Vector2(-16.489F, 68.624F), new Vector2(-16.489F, 77.753F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0047()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(6.522F, 17.457F));
                    builder.AddCubicBezier(new Vector2(6.522F, 17.457F), new Vector2(5.677F, 37.602F), new Vector2(5.677F, 37.602F));
                    builder.AddCubicBezier(new Vector2(5.677F, 37.602F), new Vector2(47.01F, 43.543F), new Vector2(47.01F, 43.543F));
                    builder.AddCubicBezier(new Vector2(47.01F, 43.543F), new Vector2(31.494F, 45.043F), new Vector2(31.494F, 45.043F));
                    builder.AddCubicBezier(new Vector2(31.494F, 45.043F), new Vector2(-5.839F, 51.852F), new Vector2(-5.839F, 51.852F));
                    builder.AddCubicBezier(new Vector2(-5.839F, 51.852F), new Vector2(-26.522F, 28.457F), new Vector2(-26.522F, 28.457F));
                    builder.AddCubicBezier(new Vector2(-26.522F, 28.457F), new Vector2(6.522F, 17.457F), new Vector2(6.522F, 17.457F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0048()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-50.942F, 59.485F));
                    builder.AddCubicBezier(new Vector2(-50.942F, 53.035F), new Vector2(-24.344F, 46.194F), new Vector2(-19.242F, 41.967F));
                    builder.AddCubicBezier(new Vector2(-14.14F, 37.741F), new Vector2(-10.984F, 31.902F), new Vector2(-10.984F, 25.452F));
                    builder.AddCubicBezier(new Vector2(-10.984F, 16.33F), new Vector2(-18.378F, 8.936F), new Vector2(-27.5F, 8.936F));
                    builder.AddCubicBezier(new Vector2(-36.622F, 8.936F), new Vector2(-44.016F, 16.33F), new Vector2(-44.016F, 25.452F));
                    builder.AddCubicBezier(new Vector2(-44.016F, 25.452F), new Vector2(-79.016F, 62.355F), new Vector2(-79.016F, 62.355F));
                    builder.AddCubicBezier(new Vector2(-79.016F, 62.355F), new Vector2(-17.016F, 68.064F), new Vector2(-17.016F, 68.064F));
                    builder.AddCubicBezier(new Vector2(-17.016F, 68.064F), new Vector2(-4.5F, 65.064F), new Vector2(-4.5F, 65.064F));
                    builder.AddCubicBezier(new Vector2(-4.5F, 65.064F), new Vector2(-50.942F, 59.485F), new Vector2(-50.942F, 59.485F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0049()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(101.876F, 14.441F));
                    builder.AddCubicBezier(new Vector2(101.876F, 47.093F), new Vector2(84.11F, 75.596F), new Vector2(57.716F, 90.81F));
                    builder.AddCubicBezier(new Vector2(44.786F, 98.263F), new Vector2(29.786F, 102.527F), new Vector2(13.79F, 102.527F));
                    builder.AddCubicBezier(new Vector2(13.79F, 102.527F), new Vector2(-95.146F, 127.777F), new Vector2(-95.146F, 127.777F));
                    builder.AddCubicBezier(new Vector2(-90.685F, 127.499F), new Vector2(-129.428F, 106.162F), new Vector2(-129.428F, 106.162F));
                    builder.AddCubicBezier(new Vector2(-129.428F, 106.162F), new Vector2(-110.875F, 96.074F), new Vector2(-110.875F, 96.074F));
                    builder.AddCubicBezier(new Vector2(-110.875F, 96.074F), new Vector2(-92.766F, 116.449F), new Vector2(-92.766F, 116.449F));
                    builder.AddCubicBezier(new Vector2(-92.766F, 116.449F), new Vector2(-134.329F, 127.298F), new Vector2(-134.329F, 127.298F));
                    builder.AddCubicBezier(new Vector2(-134.329F, 127.298F), new Vector2(-134.87F, 110.152F), new Vector2(-134.87F, 110.152F));
                    builder.AddCubicBezier(new Vector2(-134.87F, 110.152F), new Vector2(-134.855F, 88.484F), new Vector2(-134.855F, 88.484F));
                    builder.AddCubicBezier(new Vector2(-134.855F, 64.16F), new Vector2(-115.136F, 44.441F), new Vector2(-90.812F, 44.441F));
                    builder.AddCubicBezier(new Vector2(-90.812F, 44.441F), new Vector2(35.812F, 14.441F), new Vector2(35.812F, 14.441F));
                    builder.AddCubicBezier(new Vector2(47.983F, 14.441F), new Vector2(57.833F, 4.591F), new Vector2(57.833F, -7.58F));
                    builder.AddCubicBezier(new Vector2(57.833F, -7.58F), new Vector2(57.833F, -24.096F), new Vector2(57.833F, -24.096F));
                    builder.AddCubicBezier(new Vector2(57.833F, -33.225F), new Vector2(65.22F, -40.613F), new Vector2(74.349F, -40.613F));
                    builder.AddCubicBezier(new Vector2(74.349F, -40.613F), new Vector2(85.36F, -40.613F), new Vector2(85.36F, -40.613F));
                    builder.AddCubicBezier(new Vector2(94.489F, -40.613F), new Vector2(101.876F, -33.225F), new Vector2(101.876F, -24.096F));
                    builder.AddCubicBezier(new Vector2(101.876F, -24.096F), new Vector2(101.876F, 14.441F), new Vector2(101.876F, 14.441F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0050()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-16.489F, 75));
                    builder.AddCubicBezier(new Vector2(-16.489F, 81.086F), new Vector2(-21.415F, 86.011F), new Vector2(-27.501F, 86.011F));
                    builder.AddCubicBezier(new Vector2(-33.587F, 86.011F), new Vector2(-38.511F, 81.086F), new Vector2(-38.511F, 75));
                    builder.AddCubicBezier(new Vector2(-38.511F, 75), new Vector2(-38.511F, 69.494F), new Vector2(-38.511F, 69.494F));
                    builder.AddCubicBezier(new Vector2(-38.511F, 66.451F), new Vector2(-36.049F, 63.989F), new Vector2(-33.006F, 63.989F));
                    builder.AddCubicBezier(new Vector2(-33.006F, 63.989F), new Vector2(-21.994F, 63.989F), new Vector2(-21.994F, 63.989F));
                    builder.AddCubicBezier(new Vector2(-18.951F, 63.989F), new Vector2(-16.489F, 66.451F), new Vector2(-16.489F, 69.494F));
                    builder.AddCubicBezier(new Vector2(-16.489F, 69.494F), new Vector2(-16.489F, 75), new Vector2(-16.489F, 75));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0051()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-30.252F, 75));
                    builder.AddCubicBezier(new Vector2(-30.252F, 76.521F), new Vector2(-29.021F, 77.753F), new Vector2(-27.5F, 77.753F));
                    builder.AddCubicBezier(new Vector2(-25.98F, 77.753F), new Vector2(-24.748F, 76.521F), new Vector2(-24.748F, 75));
                    builder.AddCubicBezier(new Vector2(-24.748F, 73.479F), new Vector2(-25.98F, 72.247F), new Vector2(-27.5F, 72.247F));
                    builder.AddCubicBezier(new Vector2(-29.021F, 72.247F), new Vector2(-30.252F, 73.479F), new Vector2(-30.252F, 75));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0052()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-21.994F, 72.247F));
                    builder.AddCubicBezier(new Vector2(-21.994F, 70.726F), new Vector2(-23.226F, 69.494F), new Vector2(-24.747F, 69.494F));
                    builder.AddCubicBezier(new Vector2(-24.747F, 69.494F), new Vector2(-30.253F, 69.494F), new Vector2(-30.253F, 69.494F));
                    builder.AddCubicBezier(new Vector2(-31.774F, 69.494F), new Vector2(-33.006F, 70.726F), new Vector2(-33.006F, 72.247F));
                    builder.AddCubicBezier(new Vector2(-33.006F, 72.247F), new Vector2(-33.006F, 75.001F), new Vector2(-33.006F, 75.001F));
                    builder.AddCubicBezier(new Vector2(-33.006F, 78.041F), new Vector2(-30.54F, 80.506F), new Vector2(-27.499F, 80.506F));
                    builder.AddCubicBezier(new Vector2(-24.459F, 80.506F), new Vector2(-21.994F, 78.041F), new Vector2(-21.994F, 75.001F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0053()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(42.506F, -6.505F));
                    builder.AddCubicBezier(new Vector2(42.506F, -6.505F), new Vector2(48.01F, 6.505F), new Vector2(48.01F, 6.505F));
                    builder.AddCubicBezier(new Vector2(48.01F, 6.505F), new Vector2(25.99F, 6.505F), new Vector2(25.99F, 6.505F));
                    builder.AddCubicBezier(new Vector2(25.99F, 6.505F), new Vector2(25.99F, -4.505F), new Vector2(25.99F, -4.505F));
                    builder.AddCubicBezier(new Vector2(25.99F, -4.505F), new Vector2(42.506F, -6.505F), new Vector2(42.506F, -6.505F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0054()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(42.116F, -4.67F));
                    builder.AddCubicBezier(new Vector2(42.116F, -4.67F), new Vector2(47.621F, 6.341F), new Vector2(47.621F, 6.341F));
                    builder.AddCubicBezier(new Vector2(47.621F, 6.341F), new Vector2(25.6F, 6.341F), new Vector2(25.6F, 6.341F));
                    builder.AddCubicBezier(new Vector2(25.6F, 6.341F), new Vector2(25.6F, -4.67F), new Vector2(25.6F, -4.67F));
                    builder.AddCubicBezier(new Vector2(25.6F, -4.67F), new Vector2(42.116F, -4.67F), new Vector2(42.116F, -4.67F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0055()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(1.006F, -6.505F));
                    builder.AddCubicBezier(new Vector2(1.006F, -6.505F), new Vector2(12.51F, 5.005F), new Vector2(12.51F, 5.005F));
                    builder.AddCubicBezier(new Vector2(12.51F, 5.005F), new Vector2(-10.01F, 5.505F), new Vector2(-10.01F, 5.505F));
                    builder.AddCubicBezier(new Vector2(-10.01F, 5.505F), new Vector2(-11.51F, -3.505F), new Vector2(-11.51F, -3.505F));
                    builder.AddCubicBezier(new Vector2(-11.51F, -3.505F), new Vector2(1.006F, -6.505F), new Vector2(1.006F, -6.505F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0056()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(4.006F, -8.505F));
                    builder.AddCubicBezier(new Vector2(4.006F, -8.505F), new Vector2(11.01F, 5.341F), new Vector2(11.01F, 5.341F));
                    builder.AddCubicBezier(new Vector2(11.01F, 5.341F), new Vector2(-12.51F, 6.005F), new Vector2(-12.51F, 6.005F));
                    builder.AddCubicBezier(new Vector2(-12.51F, 6.005F), new Vector2(-13.51F, -4.005F), new Vector2(-13.51F, -4.005F));
                    builder.AddCubicBezier(new Vector2(-13.51F, -4.005F), new Vector2(4.006F, -8.505F), new Vector2(4.006F, -8.505F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0057()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-30.252F, 75));
                    builder.AddCubicBezier(new Vector2(-30.252F, 75.396F), new Vector2(-30.169F, 75.774F), new Vector2(-30.018F, 76.114F));
                    builder.AddCubicBezier(new Vector2(-29.591F, 77.08F), new Vector2(-28.625F, 77.753F), new Vector2(-27.5F, 77.753F));
                    builder.AddCubicBezier(new Vector2(-25.98F, 77.753F), new Vector2(-24.748F, 76.521F), new Vector2(-24.748F, 75));
                    builder.AddCubicBezier(new Vector2(-24.748F, 73.479F), new Vector2(-25.98F, 72.247F), new Vector2(-27.5F, 72.247F));
                    builder.AddCubicBezier(new Vector2(-29.021F, 72.247F), new Vector2(-30.252F, 73.479F), new Vector2(-30.252F, 75));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0058()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-26.942F, 58.844F));
                    builder.AddCubicBezier(new Vector2(-26.942F, 57.733F), new Vector2(-23.465F, 45.466F), new Vector2(-19.242F, 41.967F));
                    builder.AddCubicBezier(new Vector2(-14.14F, 37.741F), new Vector2(-10.984F, 31.902F), new Vector2(-10.984F, 25.452F));
                    builder.AddCubicBezier(new Vector2(-10.984F, 16.33F), new Vector2(-18.378F, 8.936F), new Vector2(-27.5F, 8.936F));
                    builder.AddCubicBezier(new Vector2(-36.622F, 8.936F), new Vector2(-44.016F, 16.33F), new Vector2(-44.016F, 25.452F));
                    builder.AddCubicBezier(new Vector2(-44.016F, 25.452F), new Vector2(-59.016F, 72.759F), new Vector2(-59.016F, 72.759F));
                    builder.AddCubicBezier(new Vector2(-59.016F, 72.759F), new Vector2(-19.016F, 67.564F), new Vector2(-19.016F, 67.564F));
                    builder.AddCubicBezier(new Vector2(-19.016F, 67.564F), new Vector2(-1.5F, 63.064F), new Vector2(-1.5F, 63.064F));
                    builder.AddCubicBezier(new Vector2(-1.5F, 63.064F), new Vector2(-26.942F, 58.844F), new Vector2(-26.942F, 58.844F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0059()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-27.5F, 67.916F));
                    builder.AddCubicBezier(new Vector2(-20.812F, 67.916F), new Vector2(-15.021F, 64.771F), new Vector2(-10.984F, 60.062F));
                    builder.AddCubicBezier(new Vector2(-10.984F, 60.062F), new Vector2(-10.984F, 68.341F), new Vector2(-10.984F, 68.341F));
                    builder.AddCubicBezier(new Vector2(-10.984F, 68.341F), new Vector2(-10.984F, 78.927F), new Vector2(-10.984F, 78.927F));
                    builder.AddCubicBezier(new Vector2(-10.984F, 85.013F), new Vector2(-15.909F, 89.938F), new Vector2(-21.995F, 89.938F));
                    builder.AddCubicBezier(new Vector2(-21.995F, 89.938F), new Vector2(-33.005F, 89.938F), new Vector2(-33.005F, 89.938F));
                    builder.AddCubicBezier(new Vector2(-39.091F, 89.938F), new Vector2(-44.016F, 85.013F), new Vector2(-44.016F, 78.927F));
                    builder.AddCubicBezier(new Vector2(-44.016F, 78.927F), new Vector2(-44.016F, 62.411F), new Vector2(-44.016F, 62.411F));
                    builder.AddCubicBezier(new Vector2(-44.016F, 62.411F), new Vector2(-44.016F, 60.064F), new Vector2(-44.016F, 60.064F));
                    builder.AddCubicBezier(new Vector2(-39.973F, 64.771F), new Vector2(-34.188F, 67.916F), new Vector2(-27.5F, 67.916F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0060()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-103.183F, -74.128F));
                    builder.AddCubicBezier(new Vector2(-229.696F, -10.015F), new Vector2(634.746F, 32.324F), new Vector2(640, 110.5F));
                    builder.AddCubicBezier(new Vector2(640, 110.5F), new Vector2(-640, 110.5F), new Vector2(-640, 110.5F));
                    builder.AddCubicBezier(new Vector2(-640, 110.5F), new Vector2(-640, -110.5F), new Vector2(-640, -110.5F));
                    builder.AddCubicBezier(new Vector2(-640, -110.5F), new Vector2(-45, -103.613F), new Vector2(-103.183F, -74.128F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0061()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-143.538F, -58.523F));
                    builder.AddCubicBezier(new Vector2(-276.423F, 5.59F), new Vector2(631.56F, 47.929F), new Vector2(637.078F, 126.105F));
                    builder.AddCubicBezier(new Vector2(637.078F, 126.105F), new Vector2(-707.394F, 126.105F), new Vector2(-707.394F, 126.105F));
                    builder.AddCubicBezier(new Vector2(-707.394F, 126.105F), new Vector2(-707.394F, -94.895F), new Vector2(-707.394F, -94.895F));
                    builder.AddCubicBezier(new Vector2(-707.394F, -94.895F), new Vector2(-82.425F, -88.008F), new Vector2(-143.538F, -58.523F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0062()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(20.975F, -12.342F));
                    builder.AddCubicBezier(new Vector2(18.112F, -12.342F), new Vector2(15.353F, -11.801F), new Vector2(12.757F, -10.806F));
                    builder.AddCubicBezier(new Vector2(6.288F, -16.642F), new Vector2(-1.937F, -20.14F), new Vector2(-10.897F, -20.14F));
                    builder.AddCubicBezier(new Vector2(-31.157F, -20.14F), new Vector2(-47.682F, -2.271F), new Vector2(-48.561F, 20.14F));
                    builder.AddCubicBezier(new Vector2(-48.561F, 20.14F), new Vector2(-6.613F, 20.14F), new Vector2(-6.613F, 20.14F));
                    builder.AddCubicBezier(new Vector2(-6.613F, 20.14F), new Vector2(26.767F, 20.14F), new Vector2(26.767F, 20.14F));
                    builder.AddCubicBezier(new Vector2(26.767F, 20.14F), new Vector2(48.561F, 20.14F), new Vector2(48.561F, 20.14F));
                    builder.AddCubicBezier(new Vector2(47.917F, 2.067F), new Vector2(35.814F, -12.342F), new Vector2(20.975F, -12.342F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0063()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(47.609F, -17.383F));
                    builder.AddCubicBezier(new Vector2(41.805F, -17.383F), new Vector2(36.25F, -16.323F), new Vector2(31.11F, -14.403F));
                    builder.AddCubicBezier(new Vector2(22.864F, -23.044F), new Vector2(12.233F, -28.262F), new Vector2(0.618F, -28.262F));
                    builder.AddCubicBezier(new Vector2(-11.154F, -28.262F), new Vector2(-21.917F, -22.907F), new Vector2(-30.209F, -14.055F));
                    builder.AddCubicBezier(new Vector2(-35.598F, -16.196F), new Vector2(-41.465F, -17.383F), new Vector2(-47.609F, -17.383F));
                    builder.AddCubicBezier(new Vector2(-73.101F, -17.383F), new Vector2(-93.895F, 2.865F), new Vector2(-95, 28.262F));
                    builder.AddCubicBezier(new Vector2(-95, 28.262F), new Vector2(-46.773F, 28.262F), new Vector2(-46.773F, 28.262F));
                    builder.AddCubicBezier(new Vector2(-46.773F, 28.262F), new Vector2(-0.219F, 28.262F), new Vector2(-0.219F, 28.262F));
                    builder.AddCubicBezier(new Vector2(-0.219F, 28.262F), new Vector2(0.218F, 28.262F), new Vector2(0.218F, 28.262F));
                    builder.AddCubicBezier(new Vector2(0.218F, 28.262F), new Vector2(48.009F, 28.262F), new Vector2(48.009F, 28.262F));
                    builder.AddCubicBezier(new Vector2(48.009F, 28.262F), new Vector2(95, 28.262F), new Vector2(95, 28.262F));
                    builder.AddCubicBezier(new Vector2(93.894F, 2.865F), new Vector2(73.101F, -17.383F), new Vector2(47.609F, -17.383F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0064()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(20.975F, -12.342F));
                    builder.AddCubicBezier(new Vector2(18.112F, -12.342F), new Vector2(15.353F, -11.801F), new Vector2(12.757F, -10.806F));
                    builder.AddCubicBezier(new Vector2(6.288F, -16.642F), new Vector2(-1.937F, -20.14F), new Vector2(-10.897F, -20.14F));
                    builder.AddCubicBezier(new Vector2(-31.157F, -20.14F), new Vector2(-47.682F, -2.271F), new Vector2(-48.561F, 20.14F));
                    builder.AddCubicBezier(new Vector2(-48.561F, 20.14F), new Vector2(-6.613F, 20.14F), new Vector2(-6.613F, 20.14F));
                    builder.AddCubicBezier(new Vector2(-6.613F, 20.14F), new Vector2(26.767F, 20.14F), new Vector2(26.767F, 20.14F));
                    builder.AddCubicBezier(new Vector2(26.767F, 20.14F), new Vector2(48.561F, 20.14F), new Vector2(48.561F, 20.14F));
                    builder.AddCubicBezier(new Vector2(47.917F, 2.067F), new Vector2(35.814F, -12.342F), new Vector2(20.975F, -12.342F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0065()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(20.975F, -12.342F));
                    builder.AddCubicBezier(new Vector2(18.112F, -12.342F), new Vector2(15.353F, -11.801F), new Vector2(12.757F, -10.806F));
                    builder.AddCubicBezier(new Vector2(6.288F, -16.642F), new Vector2(-1.937F, -20.14F), new Vector2(-10.897F, -20.14F));
                    builder.AddCubicBezier(new Vector2(-31.157F, -20.14F), new Vector2(-47.682F, -2.271F), new Vector2(-48.561F, 20.14F));
                    builder.AddCubicBezier(new Vector2(-48.561F, 20.14F), new Vector2(-6.613F, 20.14F), new Vector2(-6.613F, 20.14F));
                    builder.AddCubicBezier(new Vector2(-6.613F, 20.14F), new Vector2(26.767F, 20.14F), new Vector2(26.767F, 20.14F));
                    builder.AddCubicBezier(new Vector2(26.767F, 20.14F), new Vector2(48.561F, 20.14F), new Vector2(48.561F, 20.14F));
                    builder.AddCubicBezier(new Vector2(47.917F, 2.067F), new Vector2(35.814F, -12.342F), new Vector2(20.975F, -12.342F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0066()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(20.975F, -12.342F));
                    builder.AddCubicBezier(new Vector2(18.112F, -12.342F), new Vector2(15.353F, -11.801F), new Vector2(12.757F, -10.806F));
                    builder.AddCubicBezier(new Vector2(6.288F, -16.642F), new Vector2(-1.937F, -20.14F), new Vector2(-10.897F, -20.14F));
                    builder.AddCubicBezier(new Vector2(-31.157F, -20.14F), new Vector2(-47.682F, -2.271F), new Vector2(-48.561F, 20.14F));
                    builder.AddCubicBezier(new Vector2(-48.561F, 20.14F), new Vector2(-6.613F, 20.14F), new Vector2(-6.613F, 20.14F));
                    builder.AddCubicBezier(new Vector2(-6.613F, 20.14F), new Vector2(26.767F, 20.14F), new Vector2(26.767F, 20.14F));
                    builder.AddCubicBezier(new Vector2(26.767F, 20.14F), new Vector2(48.561F, 20.14F), new Vector2(48.561F, 20.14F));
                    builder.AddCubicBezier(new Vector2(47.917F, 2.067F), new Vector2(35.814F, -12.342F), new Vector2(20.975F, -12.342F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0067()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(47.609F, -17.383F));
                    builder.AddCubicBezier(new Vector2(41.805F, -17.383F), new Vector2(36.25F, -16.323F), new Vector2(31.11F, -14.403F));
                    builder.AddCubicBezier(new Vector2(22.864F, -23.044F), new Vector2(12.233F, -28.262F), new Vector2(0.618F, -28.262F));
                    builder.AddCubicBezier(new Vector2(-11.154F, -28.262F), new Vector2(-21.917F, -22.907F), new Vector2(-30.209F, -14.055F));
                    builder.AddCubicBezier(new Vector2(-35.598F, -16.196F), new Vector2(-41.465F, -17.383F), new Vector2(-47.609F, -17.383F));
                    builder.AddCubicBezier(new Vector2(-73.101F, -17.383F), new Vector2(-93.895F, 2.865F), new Vector2(-95, 28.262F));
                    builder.AddCubicBezier(new Vector2(-95, 28.262F), new Vector2(-46.773F, 28.262F), new Vector2(-46.773F, 28.262F));
                    builder.AddCubicBezier(new Vector2(-46.773F, 28.262F), new Vector2(-0.219F, 28.262F), new Vector2(-0.219F, 28.262F));
                    builder.AddCubicBezier(new Vector2(-0.219F, 28.262F), new Vector2(0.218F, 28.262F), new Vector2(0.218F, 28.262F));
                    builder.AddCubicBezier(new Vector2(0.218F, 28.262F), new Vector2(48.009F, 28.262F), new Vector2(48.009F, 28.262F));
                    builder.AddCubicBezier(new Vector2(48.009F, 28.262F), new Vector2(95, 28.262F), new Vector2(95, 28.262F));
                    builder.AddCubicBezier(new Vector2(93.894F, 2.865F), new Vector2(73.101F, -17.383F), new Vector2(47.609F, -17.383F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0068()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(20.975F, -12.342F));
                    builder.AddCubicBezier(new Vector2(18.112F, -12.342F), new Vector2(15.353F, -11.801F), new Vector2(12.757F, -10.806F));
                    builder.AddCubicBezier(new Vector2(6.288F, -16.642F), new Vector2(-1.937F, -20.14F), new Vector2(-10.897F, -20.14F));
                    builder.AddCubicBezier(new Vector2(-31.157F, -20.14F), new Vector2(-47.682F, -2.271F), new Vector2(-48.561F, 20.14F));
                    builder.AddCubicBezier(new Vector2(-48.561F, 20.14F), new Vector2(-6.613F, 20.14F), new Vector2(-6.613F, 20.14F));
                    builder.AddCubicBezier(new Vector2(-6.613F, 20.14F), new Vector2(26.767F, 20.14F), new Vector2(26.767F, 20.14F));
                    builder.AddCubicBezier(new Vector2(26.767F, 20.14F), new Vector2(48.561F, 20.14F), new Vector2(48.561F, 20.14F));
                    builder.AddCubicBezier(new Vector2(47.917F, 2.067F), new Vector2(35.814F, -12.342F), new Vector2(20.975F, -12.342F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0069()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(20.975F, -12.342F));
                    builder.AddCubicBezier(new Vector2(18.112F, -12.342F), new Vector2(15.353F, -11.801F), new Vector2(12.757F, -10.806F));
                    builder.AddCubicBezier(new Vector2(6.288F, -16.642F), new Vector2(-1.937F, -20.14F), new Vector2(-10.897F, -20.14F));
                    builder.AddCubicBezier(new Vector2(-31.157F, -20.14F), new Vector2(-47.682F, -2.271F), new Vector2(-48.561F, 20.14F));
                    builder.AddCubicBezier(new Vector2(-48.561F, 20.14F), new Vector2(-6.613F, 20.14F), new Vector2(-6.613F, 20.14F));
                    builder.AddCubicBezier(new Vector2(-6.613F, 20.14F), new Vector2(26.767F, 20.14F), new Vector2(26.767F, 20.14F));
                    builder.AddCubicBezier(new Vector2(26.767F, 20.14F), new Vector2(48.561F, 20.14F), new Vector2(48.561F, 20.14F));
                    builder.AddCubicBezier(new Vector2(47.917F, 2.067F), new Vector2(35.814F, -12.342F), new Vector2(20.975F, -12.342F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0070()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-22.976F, 111.469F));
                    builder.AddCubicBezier(new Vector2(-22.976F, 111.469F), new Vector2(-22.976F, 150.007F), new Vector2(-22.976F, 150.007F));
                    builder.AddCubicBezier(new Vector2(-22.976F, 150.007F), new Vector2(-57.019F, 150.007F), new Vector2(-57.019F, 150.007F));
                    builder.AddCubicBezier(new Vector2(-57.019F, 153.746F), new Vector2(-69.177F, 156.541F), new Vector2(-72.024F, 158.531F));
                    builder.AddCubicBezier(new Vector2(-70.659F, 132.367F), new Vector2(-49.481F, 111.469F), new Vector2(-22.976F, 111.469F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0071()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-19.973F, 107.473F));
                    builder.AddCubicBezier(new Vector2(-19.973F, 107.473F), new Vector2(-19.973F, 112.978F), new Vector2(-19.973F, 112.978F));
                    builder.AddCubicBezier(new Vector2(-46.478F, 112.978F), new Vector2(-67.656F, 133.876F), new Vector2(-69.021F, 160.039F));
                    builder.AddCubicBezier(new Vector2(-70.806F, 161.289F), new Vector2(-75.18F, 162.527F), new Vector2(-77.527F, 162.527F));
                    builder.AddCubicBezier(new Vector2(-77.527F, 132.096F), new Vector2(-50.403F, 107.473F), new Vector2(-19.973F, 107.473F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0072()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-57.779F, 37.838F));
                    builder.AddCubicBezier(new Vector2(-57.779F, 57.685F), new Vector2(-43.433F, 73.516F), new Vector2(-24.745F, 77.456F));
                    builder.AddCubicBezier(new Vector2(-35.272F, 66.126F), new Vector2(-41.263F, 52.443F), new Vector2(-41.263F, 37.838F));
                    builder.AddCubicBezier(new Vector2(-41.263F, 37.838F), new Vector2(-41.263F, 32.334F), new Vector2(-41.263F, 32.334F));
                    builder.AddCubicBezier(new Vector2(-38.22F, 32.334F), new Vector2(-35.758F, 34.795F), new Vector2(-35.758F, 37.838F));
                    builder.AddCubicBezier(new Vector2(-35.758F, 43.234F), new Vector2(-34.584F, 48.443F), new Vector2(-32.898F, 53.519F));
                    builder.AddCubicBezier(new Vector2(-32.898F, 53.519F), new Vector2(-26.896F, 41.511F), new Vector2(-26.896F, 41.511F));
                    builder.AddCubicBezier(new Vector2(-25.543F, 38.807F), new Vector2(-22.253F, 37.71F), new Vector2(-19.546F, 39.063F));
                    builder.AddCubicBezier(new Vector2(-19.546F, 39.063F), new Vector2(-19.543F, 39.066F), new Vector2(-19.543F, 39.066F));
                    builder.AddCubicBezier(new Vector2(-19.543F, 39.066F), new Vector2(-30.299F, 60.572F), new Vector2(-30.299F, 60.572F));
                    builder.AddCubicBezier(new Vector2(-27.632F, 65.873F), new Vector2(-23.729F, 70.698F), new Vector2(-19.242F, 75.215F));
                    builder.AddCubicBezier(new Vector2(-19.242F, 75.215F), new Vector2(-19.242F, 59.86F), new Vector2(-19.242F, 59.86F));
                    builder.AddCubicBezier(new Vector2(-19.242F, 59.86F), new Vector2(-19.242F, 54.356F), new Vector2(-19.242F, 54.356F));
                    builder.AddCubicBezier(new Vector2(-16.199F, 54.356F), new Vector2(-13.737F, 56.818F), new Vector2(-13.737F, 59.86F));
                    builder.AddCubicBezier(new Vector2(-13.737F, 59.86F), new Vector2(-13.737F, 79.13F), new Vector2(-13.737F, 79.13F));
                    builder.AddCubicBezier(new Vector2(-13.737F, 79.13F), new Vector2(-5.479F, 79.13F), new Vector2(-5.479F, 79.13F));
                    builder.AddCubicBezier(new Vector2(-0.92F, 79.13F), new Vector2(2.779F, 75.43F), new Vector2(2.779F, 70.87F));
                    builder.AddCubicBezier(new Vector2(2.779F, 67.827F), new Vector2(5.241F, 65.365F), new Vector2(8.284F, 65.365F));
                    builder.AddCubicBezier(new Vector2(8.284F, 65.365F), new Vector2(8.284F, 70.87F), new Vector2(8.284F, 70.87F));
                    builder.AddCubicBezier(new Vector2(8.284F, 77.524F), new Vector2(3.213F, 82.362F), new Vector2(-3.07F, 83.637F));
                    builder.AddCubicBezier(new Vector2(3.605F, 88.08F), new Vector2(8.284F, 95.304F), new Vector2(8.284F, 103.903F));
                    builder.AddCubicBezier(new Vector2(8.284F, 103.903F), new Vector2(8.284F, 117.666F), new Vector2(8.284F, 117.666F));
                    builder.AddCubicBezier(new Vector2(8.284F, 117.666F), new Vector2(2.779F, 117.666F), new Vector2(2.779F, 117.666F));
                    builder.AddCubicBezier(new Vector2(2.779F, 117.666F), new Vector2(2.779F, 103.903F), new Vector2(2.779F, 103.903F));
                    builder.AddCubicBezier(new Vector2(2.779F, 93.28F), new Vector2(-5.866F, 84.635F), new Vector2(-16.489F, 84.635F));
                    builder.AddCubicBezier(new Vector2(-42.296F, 84.635F), new Vector2(-63.284F, 63.645F), new Vector2(-63.284F, 37.838F));
                    builder.AddCubicBezier(new Vector2(-63.284F, 37.838F), new Vector2(-63.284F, 32.334F), new Vector2(-63.284F, 32.334F));
                    builder.AddCubicBezier(new Vector2(-60.241F, 32.334F), new Vector2(-57.779F, 34.795F), new Vector2(-57.779F, 37.838F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0073()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-57.779F, 70.87F));
                    builder.AddCubicBezier(new Vector2(-57.779F, 75.43F), new Vector2(-54.081F, 79.129F), new Vector2(-49.522F, 79.129F));
                    builder.AddCubicBezier(new Vector2(-49.522F, 79.129F), new Vector2(-41.263F, 79.129F), new Vector2(-41.263F, 79.129F));
                    builder.AddCubicBezier(new Vector2(-41.263F, 79.129F), new Vector2(-41.263F, 59.859F), new Vector2(-41.263F, 59.859F));
                    builder.AddCubicBezier(new Vector2(-41.263F, 56.816F), new Vector2(-38.8F, 54.354F), new Vector2(-35.758F, 54.354F));
                    builder.AddCubicBezier(new Vector2(-35.758F, 54.354F), new Vector2(-35.758F, 59.859F), new Vector2(-35.758F, 59.859F));
                    builder.AddCubicBezier(new Vector2(-35.758F, 59.859F), new Vector2(-35.758F, 75.215F), new Vector2(-35.758F, 75.215F));
                    builder.AddCubicBezier(new Vector2(-31.271F, 70.698F), new Vector2(-27.369F, 65.874F), new Vector2(-24.702F, 60.573F));
                    builder.AddCubicBezier(new Vector2(-24.702F, 60.573F), new Vector2(-35.456F, 39.064F), new Vector2(-35.456F, 39.064F));
                    builder.AddCubicBezier(new Vector2(-35.456F, 39.064F), new Vector2(-35.455F, 39.061F), new Vector2(-35.455F, 39.061F));
                    builder.AddCubicBezier(new Vector2(-32.748F, 37.709F), new Vector2(-29.457F, 38.806F), new Vector2(-28.105F, 41.51F));
                    builder.AddCubicBezier(new Vector2(-28.105F, 41.51F), new Vector2(-22.103F, 53.518F), new Vector2(-22.103F, 53.518F));
                    builder.AddCubicBezier(new Vector2(-20.417F, 48.443F), new Vector2(-19.242F, 43.234F), new Vector2(-19.242F, 37.839F));
                    builder.AddCubicBezier(new Vector2(-19.242F, 34.796F), new Vector2(-16.78F, 32.333F), new Vector2(-13.737F, 32.333F));
                    builder.AddCubicBezier(new Vector2(-13.737F, 32.333F), new Vector2(-13.737F, 37.839F), new Vector2(-13.737F, 37.839F));
                    builder.AddCubicBezier(new Vector2(-13.737F, 52.444F), new Vector2(-19.729F, 66.127F), new Vector2(-30.256F, 77.457F));
                    builder.AddCubicBezier(new Vector2(-11.568F, 73.517F), new Vector2(2.779F, 57.685F), new Vector2(2.779F, 37.839F));
                    builder.AddCubicBezier(new Vector2(2.779F, 34.796F), new Vector2(5.241F, 32.333F), new Vector2(8.284F, 32.333F));
                    builder.AddCubicBezier(new Vector2(8.284F, 32.333F), new Vector2(8.284F, 37.839F), new Vector2(8.284F, 37.839F));
                    builder.AddCubicBezier(new Vector2(8.284F, 63.645F), new Vector2(-12.705F, 84.634F), new Vector2(-38.511F, 84.634F));
                    builder.AddCubicBezier(new Vector2(-49.135F, 84.634F), new Vector2(-57.779F, 93.279F), new Vector2(-57.779F, 103.902F));
                    builder.AddCubicBezier(new Vector2(-57.779F, 103.902F), new Vector2(-57.779F, 117.667F), new Vector2(-57.779F, 117.667F));
                    builder.AddCubicBezier(new Vector2(-57.779F, 117.667F), new Vector2(-63.284F, 117.667F), new Vector2(-63.284F, 117.667F));
                    builder.AddCubicBezier(new Vector2(-63.284F, 117.667F), new Vector2(-63.284F, 103.902F), new Vector2(-63.284F, 103.902F));
                    builder.AddCubicBezier(new Vector2(-63.284F, 95.303F), new Vector2(-58.605F, 88.081F), new Vector2(-51.93F, 83.638F));
                    builder.AddCubicBezier(new Vector2(-58.213F, 82.363F), new Vector2(-63.284F, 77.523F), new Vector2(-63.284F, 70.87F));
                    builder.AddCubicBezier(new Vector2(-63.284F, 70.87F), new Vector2(-63.284F, 65.366F), new Vector2(-63.284F, 65.366F));
                    builder.AddCubicBezier(new Vector2(-60.241F, 65.366F), new Vector2(-57.779F, 67.827F), new Vector2(-57.779F, 70.87F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0074()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-38.51F, 88.763F));
                    builder.AddCubicBezier(new Vector2(-38.51F, 85.72F), new Vector2(-36.049F, 83.258F), new Vector2(-33.006F, 83.258F));
                    builder.AddCubicBezier(new Vector2(-23.877F, 83.258F), new Vector2(-16.49F, 75.87F), new Vector2(-16.49F, 66.742F));
                    builder.AddCubicBezier(new Vector2(-16.49F, 66.742F), new Vector2(-16.49F, 61.237F), new Vector2(-16.49F, 61.237F));
                    builder.AddCubicBezier(new Vector2(-16.49F, 61.237F), new Vector2(-21.995F, 61.237F), new Vector2(-21.995F, 61.237F));
                    builder.AddCubicBezier(new Vector2(-31.124F, 61.237F), new Vector2(-38.51F, 68.624F), new Vector2(-38.51F, 77.753F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0075()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-16.489F, 88.763F));
                    builder.AddCubicBezier(new Vector2(-16.489F, 85.72F), new Vector2(-18.951F, 83.258F), new Vector2(-21.994F, 83.258F));
                    builder.AddCubicBezier(new Vector2(-31.123F, 83.258F), new Vector2(-38.511F, 75.87F), new Vector2(-38.511F, 66.742F));
                    builder.AddCubicBezier(new Vector2(-38.511F, 66.742F), new Vector2(-38.511F, 61.237F), new Vector2(-38.511F, 61.237F));
                    builder.AddCubicBezier(new Vector2(-38.511F, 61.237F), new Vector2(-33.006F, 61.237F), new Vector2(-33.006F, 61.237F));
                    builder.AddCubicBezier(new Vector2(-23.877F, 61.237F), new Vector2(-16.489F, 68.624F), new Vector2(-16.489F, 77.753F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0076()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(6.522F, 17.457F));
                    builder.AddCubicBezier(new Vector2(6.522F, 17.457F), new Vector2(5.677F, 37.602F), new Vector2(5.677F, 37.602F));
                    builder.AddCubicBezier(new Vector2(5.677F, 37.602F), new Vector2(47.01F, 43.543F), new Vector2(47.01F, 43.543F));
                    builder.AddCubicBezier(new Vector2(47.01F, 43.543F), new Vector2(31.494F, 45.043F), new Vector2(31.494F, 45.043F));
                    builder.AddCubicBezier(new Vector2(31.494F, 45.043F), new Vector2(-5.839F, 51.852F), new Vector2(-5.839F, 51.852F));
                    builder.AddCubicBezier(new Vector2(-5.839F, 51.852F), new Vector2(-26.522F, 28.457F), new Vector2(-26.522F, 28.457F));
                    builder.AddCubicBezier(new Vector2(-26.522F, 28.457F), new Vector2(6.522F, 17.457F), new Vector2(6.522F, 17.457F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0077()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-50.942F, 59.485F));
                    builder.AddCubicBezier(new Vector2(-50.942F, 53.035F), new Vector2(-24.344F, 46.194F), new Vector2(-19.242F, 41.967F));
                    builder.AddCubicBezier(new Vector2(-14.14F, 37.741F), new Vector2(-10.984F, 31.902F), new Vector2(-10.984F, 25.452F));
                    builder.AddCubicBezier(new Vector2(-10.984F, 16.33F), new Vector2(-18.378F, 8.936F), new Vector2(-27.5F, 8.936F));
                    builder.AddCubicBezier(new Vector2(-36.622F, 8.936F), new Vector2(-44.016F, 16.33F), new Vector2(-44.016F, 25.452F));
                    builder.AddCubicBezier(new Vector2(-44.016F, 25.452F), new Vector2(-79.016F, 62.355F), new Vector2(-79.016F, 62.355F));
                    builder.AddCubicBezier(new Vector2(-79.016F, 62.355F), new Vector2(-17.016F, 68.064F), new Vector2(-17.016F, 68.064F));
                    builder.AddCubicBezier(new Vector2(-17.016F, 68.064F), new Vector2(-4.5F, 65.064F), new Vector2(-4.5F, 65.064F));
                    builder.AddCubicBezier(new Vector2(-4.5F, 65.064F), new Vector2(-50.942F, 59.485F), new Vector2(-50.942F, 59.485F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0078()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(101.876F, 14.441F));
                    builder.AddCubicBezier(new Vector2(101.876F, 47.093F), new Vector2(84.11F, 75.596F), new Vector2(57.716F, 90.81F));
                    builder.AddCubicBezier(new Vector2(44.786F, 98.263F), new Vector2(29.786F, 102.527F), new Vector2(13.79F, 102.527F));
                    builder.AddCubicBezier(new Vector2(13.79F, 102.527F), new Vector2(-95.146F, 127.777F), new Vector2(-95.146F, 127.777F));
                    builder.AddCubicBezier(new Vector2(-90.685F, 127.499F), new Vector2(-129.428F, 106.162F), new Vector2(-129.428F, 106.162F));
                    builder.AddCubicBezier(new Vector2(-129.428F, 106.162F), new Vector2(-110.875F, 96.074F), new Vector2(-110.875F, 96.074F));
                    builder.AddCubicBezier(new Vector2(-110.875F, 96.074F), new Vector2(-92.766F, 116.449F), new Vector2(-92.766F, 116.449F));
                    builder.AddCubicBezier(new Vector2(-92.766F, 116.449F), new Vector2(-134.329F, 127.298F), new Vector2(-134.329F, 127.298F));
                    builder.AddCubicBezier(new Vector2(-134.329F, 127.298F), new Vector2(-134.87F, 110.152F), new Vector2(-134.87F, 110.152F));
                    builder.AddCubicBezier(new Vector2(-134.87F, 110.152F), new Vector2(-134.855F, 88.484F), new Vector2(-134.855F, 88.484F));
                    builder.AddCubicBezier(new Vector2(-134.855F, 64.16F), new Vector2(-115.136F, 44.441F), new Vector2(-90.812F, 44.441F));
                    builder.AddCubicBezier(new Vector2(-90.812F, 44.441F), new Vector2(35.812F, 14.441F), new Vector2(35.812F, 14.441F));
                    builder.AddCubicBezier(new Vector2(47.983F, 14.441F), new Vector2(57.833F, 4.591F), new Vector2(57.833F, -7.58F));
                    builder.AddCubicBezier(new Vector2(57.833F, -7.58F), new Vector2(57.833F, -24.096F), new Vector2(57.833F, -24.096F));
                    builder.AddCubicBezier(new Vector2(57.833F, -33.225F), new Vector2(65.22F, -40.613F), new Vector2(74.349F, -40.613F));
                    builder.AddCubicBezier(new Vector2(74.349F, -40.613F), new Vector2(85.36F, -40.613F), new Vector2(85.36F, -40.613F));
                    builder.AddCubicBezier(new Vector2(94.489F, -40.613F), new Vector2(101.876F, -33.225F), new Vector2(101.876F, -24.096F));
                    builder.AddCubicBezier(new Vector2(101.876F, -24.096F), new Vector2(101.876F, 14.441F), new Vector2(101.876F, 14.441F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0079()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-16.489F, 75));
                    builder.AddCubicBezier(new Vector2(-16.489F, 81.086F), new Vector2(-21.415F, 86.011F), new Vector2(-27.501F, 86.011F));
                    builder.AddCubicBezier(new Vector2(-33.587F, 86.011F), new Vector2(-38.511F, 81.086F), new Vector2(-38.511F, 75));
                    builder.AddCubicBezier(new Vector2(-38.511F, 75), new Vector2(-38.511F, 69.494F), new Vector2(-38.511F, 69.494F));
                    builder.AddCubicBezier(new Vector2(-38.511F, 66.451F), new Vector2(-36.049F, 63.989F), new Vector2(-33.006F, 63.989F));
                    builder.AddCubicBezier(new Vector2(-33.006F, 63.989F), new Vector2(-21.994F, 63.989F), new Vector2(-21.994F, 63.989F));
                    builder.AddCubicBezier(new Vector2(-18.951F, 63.989F), new Vector2(-16.489F, 66.451F), new Vector2(-16.489F, 69.494F));
                    builder.AddCubicBezier(new Vector2(-16.489F, 69.494F), new Vector2(-16.489F, 75), new Vector2(-16.489F, 75));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0080()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-30.252F, 75));
                    builder.AddCubicBezier(new Vector2(-30.252F, 76.521F), new Vector2(-29.021F, 77.753F), new Vector2(-27.5F, 77.753F));
                    builder.AddCubicBezier(new Vector2(-25.98F, 77.753F), new Vector2(-24.748F, 76.521F), new Vector2(-24.748F, 75));
                    builder.AddCubicBezier(new Vector2(-24.748F, 73.479F), new Vector2(-25.98F, 72.247F), new Vector2(-27.5F, 72.247F));
                    builder.AddCubicBezier(new Vector2(-29.021F, 72.247F), new Vector2(-30.252F, 73.479F), new Vector2(-30.252F, 75));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0081()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-21.994F, 72.247F));
                    builder.AddCubicBezier(new Vector2(-21.994F, 70.726F), new Vector2(-23.226F, 69.494F), new Vector2(-24.747F, 69.494F));
                    builder.AddCubicBezier(new Vector2(-24.747F, 69.494F), new Vector2(-30.253F, 69.494F), new Vector2(-30.253F, 69.494F));
                    builder.AddCubicBezier(new Vector2(-31.774F, 69.494F), new Vector2(-33.006F, 70.726F), new Vector2(-33.006F, 72.247F));
                    builder.AddCubicBezier(new Vector2(-33.006F, 72.247F), new Vector2(-33.006F, 75.001F), new Vector2(-33.006F, 75.001F));
                    builder.AddCubicBezier(new Vector2(-33.006F, 78.041F), new Vector2(-30.54F, 80.506F), new Vector2(-27.499F, 80.506F));
                    builder.AddCubicBezier(new Vector2(-24.459F, 80.506F), new Vector2(-21.994F, 78.041F), new Vector2(-21.994F, 75.001F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0082()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(42.506F, -6.505F));
                    builder.AddCubicBezier(new Vector2(42.506F, -6.505F), new Vector2(48.01F, 6.505F), new Vector2(48.01F, 6.505F));
                    builder.AddCubicBezier(new Vector2(48.01F, 6.505F), new Vector2(25.99F, 6.505F), new Vector2(25.99F, 6.505F));
                    builder.AddCubicBezier(new Vector2(25.99F, 6.505F), new Vector2(25.99F, -4.505F), new Vector2(25.99F, -4.505F));
                    builder.AddCubicBezier(new Vector2(25.99F, -4.505F), new Vector2(42.506F, -6.505F), new Vector2(42.506F, -6.505F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0083()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(42.116F, -4.67F));
                    builder.AddCubicBezier(new Vector2(42.116F, -4.67F), new Vector2(47.621F, 6.341F), new Vector2(47.621F, 6.341F));
                    builder.AddCubicBezier(new Vector2(47.621F, 6.341F), new Vector2(25.6F, 6.341F), new Vector2(25.6F, 6.341F));
                    builder.AddCubicBezier(new Vector2(25.6F, 6.341F), new Vector2(25.6F, -4.67F), new Vector2(25.6F, -4.67F));
                    builder.AddCubicBezier(new Vector2(25.6F, -4.67F), new Vector2(42.116F, -4.67F), new Vector2(42.116F, -4.67F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0084()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(1.006F, -6.505F));
                    builder.AddCubicBezier(new Vector2(1.006F, -6.505F), new Vector2(12.51F, 5.005F), new Vector2(12.51F, 5.005F));
                    builder.AddCubicBezier(new Vector2(12.51F, 5.005F), new Vector2(-10.01F, 5.505F), new Vector2(-10.01F, 5.505F));
                    builder.AddCubicBezier(new Vector2(-10.01F, 5.505F), new Vector2(-11.51F, -3.505F), new Vector2(-11.51F, -3.505F));
                    builder.AddCubicBezier(new Vector2(-11.51F, -3.505F), new Vector2(1.006F, -6.505F), new Vector2(1.006F, -6.505F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0085()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(4.006F, -8.505F));
                    builder.AddCubicBezier(new Vector2(4.006F, -8.505F), new Vector2(11.01F, 5.341F), new Vector2(11.01F, 5.341F));
                    builder.AddCubicBezier(new Vector2(11.01F, 5.341F), new Vector2(-12.51F, 6.005F), new Vector2(-12.51F, 6.005F));
                    builder.AddCubicBezier(new Vector2(-12.51F, 6.005F), new Vector2(-13.51F, -4.005F), new Vector2(-13.51F, -4.005F));
                    builder.AddCubicBezier(new Vector2(-13.51F, -4.005F), new Vector2(4.006F, -8.505F), new Vector2(4.006F, -8.505F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0086()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-30.252F, 75));
                    builder.AddCubicBezier(new Vector2(-30.252F, 75.396F), new Vector2(-30.169F, 75.774F), new Vector2(-30.018F, 76.114F));
                    builder.AddCubicBezier(new Vector2(-29.591F, 77.08F), new Vector2(-28.625F, 77.753F), new Vector2(-27.5F, 77.753F));
                    builder.AddCubicBezier(new Vector2(-25.98F, 77.753F), new Vector2(-24.748F, 76.521F), new Vector2(-24.748F, 75));
                    builder.AddCubicBezier(new Vector2(-24.748F, 73.479F), new Vector2(-25.98F, 72.247F), new Vector2(-27.5F, 72.247F));
                    builder.AddCubicBezier(new Vector2(-29.021F, 72.247F), new Vector2(-30.252F, 73.479F), new Vector2(-30.252F, 75));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0087()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-26.942F, 58.844F));
                    builder.AddCubicBezier(new Vector2(-26.942F, 57.733F), new Vector2(-23.465F, 45.466F), new Vector2(-19.242F, 41.967F));
                    builder.AddCubicBezier(new Vector2(-14.14F, 37.741F), new Vector2(-10.984F, 31.902F), new Vector2(-10.984F, 25.452F));
                    builder.AddCubicBezier(new Vector2(-10.984F, 16.33F), new Vector2(-18.378F, 8.936F), new Vector2(-27.5F, 8.936F));
                    builder.AddCubicBezier(new Vector2(-36.622F, 8.936F), new Vector2(-44.016F, 16.33F), new Vector2(-44.016F, 25.452F));
                    builder.AddCubicBezier(new Vector2(-44.016F, 25.452F), new Vector2(-59.016F, 72.759F), new Vector2(-59.016F, 72.759F));
                    builder.AddCubicBezier(new Vector2(-59.016F, 72.759F), new Vector2(-19.016F, 67.564F), new Vector2(-19.016F, 67.564F));
                    builder.AddCubicBezier(new Vector2(-19.016F, 67.564F), new Vector2(-1.5F, 63.064F), new Vector2(-1.5F, 63.064F));
                    builder.AddCubicBezier(new Vector2(-1.5F, 63.064F), new Vector2(-26.942F, 58.844F), new Vector2(-26.942F, 58.844F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0088()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-27.5F, 67.916F));
                    builder.AddCubicBezier(new Vector2(-20.812F, 67.916F), new Vector2(-15.021F, 64.771F), new Vector2(-10.984F, 60.062F));
                    builder.AddCubicBezier(new Vector2(-10.984F, 60.062F), new Vector2(-10.984F, 68.341F), new Vector2(-10.984F, 68.341F));
                    builder.AddCubicBezier(new Vector2(-10.984F, 68.341F), new Vector2(-10.984F, 78.927F), new Vector2(-10.984F, 78.927F));
                    builder.AddCubicBezier(new Vector2(-10.984F, 85.013F), new Vector2(-15.909F, 89.938F), new Vector2(-21.995F, 89.938F));
                    builder.AddCubicBezier(new Vector2(-21.995F, 89.938F), new Vector2(-33.005F, 89.938F), new Vector2(-33.005F, 89.938F));
                    builder.AddCubicBezier(new Vector2(-39.091F, 89.938F), new Vector2(-44.016F, 85.013F), new Vector2(-44.016F, 78.927F));
                    builder.AddCubicBezier(new Vector2(-44.016F, 78.927F), new Vector2(-44.016F, 62.411F), new Vector2(-44.016F, 62.411F));
                    builder.AddCubicBezier(new Vector2(-44.016F, 62.411F), new Vector2(-44.016F, 60.064F), new Vector2(-44.016F, 60.064F));
                    builder.AddCubicBezier(new Vector2(-39.973F, 64.771F), new Vector2(-34.188F, 67.916F), new Vector2(-27.5F, 67.916F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0089()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(47.609F, -17.383F));
                    builder.AddCubicBezier(new Vector2(41.805F, -17.383F), new Vector2(36.25F, -16.323F), new Vector2(31.11F, -14.403F));
                    builder.AddCubicBezier(new Vector2(22.864F, -23.044F), new Vector2(12.233F, -28.262F), new Vector2(0.618F, -28.262F));
                    builder.AddCubicBezier(new Vector2(-11.154F, -28.262F), new Vector2(-21.917F, -22.907F), new Vector2(-30.209F, -14.055F));
                    builder.AddCubicBezier(new Vector2(-35.598F, -16.196F), new Vector2(-41.465F, -17.383F), new Vector2(-47.609F, -17.383F));
                    builder.AddCubicBezier(new Vector2(-73.101F, -17.383F), new Vector2(-93.895F, 2.865F), new Vector2(-95, 28.262F));
                    builder.AddCubicBezier(new Vector2(-95, 28.262F), new Vector2(-46.773F, 28.262F), new Vector2(-46.773F, 28.262F));
                    builder.AddCubicBezier(new Vector2(-46.773F, 28.262F), new Vector2(-0.219F, 28.262F), new Vector2(-0.219F, 28.262F));
                    builder.AddCubicBezier(new Vector2(-0.219F, 28.262F), new Vector2(0.218F, 28.262F), new Vector2(0.218F, 28.262F));
                    builder.AddCubicBezier(new Vector2(0.218F, 28.262F), new Vector2(48.009F, 28.262F), new Vector2(48.009F, 28.262F));
                    builder.AddCubicBezier(new Vector2(48.009F, 28.262F), new Vector2(95, 28.262F), new Vector2(95, 28.262F));
                    builder.AddCubicBezier(new Vector2(93.894F, 2.865F), new Vector2(73.101F, -17.383F), new Vector2(47.609F, -17.383F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0090()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(44, 25.029F));
                    builder.AddCubicBezier(new Vector2(44, 25.029F), new Vector2(-44, 25.029F), new Vector2(-44, 25.029F));
                    builder.AddCubicBezier(new Vector2(-44, 25.029F), new Vector2(-44, -25.029F), new Vector2(-44, -25.029F));
                    builder.AddCubicBezier(new Vector2(-44, -25.029F), new Vector2(44, -25.029F), new Vector2(44, -25.029F));
                    builder.AddCubicBezier(new Vector2(44, -25.029F), new Vector2(44, 25.029F), new Vector2(44, 25.029F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPath CompositionPath_0091()
            {
                CanvasGeometry geometry;
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-7.995F, -38.745F));
                    builder.AddCubicBezier(new Vector2(-7.995F, -38.745F), new Vector2(-75.432F, 28.568F), new Vector2(-75.432F, 28.568F));
                    builder.AddCubicBezier(new Vector2(-75.432F, 28.568F), new Vector2(91.318F, 28.193F), new Vector2(91.318F, 28.193F));
                    builder.AddCubicBezier(new Vector2(91.318F, 28.193F), new Vector2(158.63F, -39.245F), new Vector2(158.63F, -39.245F));
                    builder.AddCubicBezier(new Vector2(158.63F, -39.245F), new Vector2(-7.995F, -38.745F), new Vector2(-7.995F, -38.745F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    geometry = CanvasGeometry.CreatePath(builder);
                }
                var result = new CompositionPath(geometry);
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0000()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0000());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0001()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0001());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0002()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0002());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0003()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0003());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0004()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0004());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0005()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0005());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0006()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0006());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0007()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0007());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0008()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0008());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0009()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0009());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0010()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0010());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0011()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0011());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0012()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0012());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0013()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0013());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0014()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0014());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0015()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0015());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0016()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0016());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0017()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0017());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0018()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0018());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0019()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0019());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0020()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0020());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0021()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0021());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0022()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0022());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0023()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0023());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0024()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0024());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0025()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0025());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0026()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0026());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0027()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0027());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0028()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0028());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0029()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0029());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0030()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0030());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0031()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0031());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0032()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0032());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0033()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0033());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0034()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0034());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0035()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0035());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0036()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0036());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0037()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0037());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0038()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0038());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0039()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0039());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0040()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0040());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0041()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0041());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0042()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0042());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0043()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0043());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0044()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0044());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0045()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0045());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0046()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0046());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0047()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0047());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0048()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0048());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0049()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0049());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0050()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0050());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0051()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0051());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0052()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0052());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0053()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0053());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0054()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0054());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0055()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0055());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0056()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0056());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0057()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0057());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0058()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0058());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0059()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0059());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0060()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0060());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0061()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0061());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0062()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0062());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0063()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0063());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0064()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0064());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0065()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0065());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0066()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0066());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0067()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0067());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0068()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0068());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0069()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0069());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0070()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0070());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0071()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0071());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0072()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0072());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0073()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0073());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0074()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0074());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0075()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0075());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0076()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0076());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0077()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0077());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0078()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0078());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0079()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0079());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0080()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0080());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0081()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0081());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0082()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0082());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0083()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0083());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0084()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0084());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0085()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0085());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0086()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0086());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0087()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0087());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0088()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0088());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0089()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0089());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0090()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0090());
                result.TrimEnd = 1;
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0091()
            {
                var result = _c.CreatePathGeometry(CompositionPath_0091());
                result.TrimEnd = 1;
                return result;
            }

            CompositionRectangleGeometry CompositionRectangleGeometry_0000()
            {
                var result = _c.CreateRectangleGeometry();
                result.TrimEnd = 1;
                result.Size = new Vector2(75, 43);
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0000()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0000();
                result.Geometry = CompositionPathGeometry_0000();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0001()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0001();
                result.Geometry = CompositionPathGeometry_0001();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0002()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0002();
                result.Geometry = CompositionPathGeometry_0002();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0003()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0003();
                result.Geometry = CompositionPathGeometry_0003();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0004()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0000();
                result.Geometry = CompositionPathGeometry_0004();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0005()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0004();
                result.Geometry = CompositionRectangleGeometry_0000();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0006()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0005();
                result.Geometry = CompositionEllipseGeometry_0000();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0007()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0006();
                result.Geometry = CompositionPathGeometry_0005();
                result.StrokeBrush = CompositionColorBrush_0005();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 2;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0008()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0006();
                result.Geometry = CompositionPathGeometry_0006();
                result.StrokeBrush = CompositionColorBrush_0005();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 2;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0009()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0006();
                result.Geometry = CompositionPathGeometry_0007();
                result.StrokeBrush = CompositionColorBrush_0005();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 2;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0010()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0006();
                result.Geometry = CompositionPathGeometry_0008();
                result.StrokeBrush = CompositionColorBrush_0005();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 2;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0011()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0006();
                result.Geometry = CompositionPathGeometry_0009();
                result.StrokeBrush = CompositionColorBrush_0005();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 2;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0012()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0006();
                result.Geometry = CompositionPathGeometry_0010();
                result.StrokeBrush = CompositionColorBrush_0005();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 2;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0013()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0006();
                result.Geometry = CompositionPathGeometry_0011();
                result.StrokeBrush = CompositionColorBrush_0005();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 2;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0014()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0006();
                result.Geometry = CompositionPathGeometry_0012();
                result.StrokeBrush = CompositionColorBrush_0005();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 2;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0015()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0007();
                result.Geometry = CompositionPathGeometry_0013();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0016()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0008();
                result.Geometry = CompositionPathGeometry_0014();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0017()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0008();
                result.Geometry = CompositionPathGeometry_0015();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0018()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0009();
                result.Geometry = CompositionPathGeometry_0016();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0019()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0010();
                result.Geometry = CompositionPathGeometry_0017();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0020()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0011();
                result.Geometry = CompositionPathGeometry_0018();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0021()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0012();
                result.Geometry = CompositionPathGeometry_0019();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0022()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0012();
                result.Geometry = CompositionPathGeometry_0020();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0023()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0013();
                result.Geometry = CompositionPathGeometry_0021();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0024()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0014();
                result.Geometry = CompositionPathGeometry_0022();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0025()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0015();
                result.Geometry = CompositionPathGeometry_0023();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0026()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0014();
                result.Geometry = CompositionPathGeometry_0024();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0027()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0014();
                result.Geometry = CompositionPathGeometry_0025();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0028()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0015();
                result.Geometry = CompositionPathGeometry_0026();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0029()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0015();
                result.Geometry = CompositionPathGeometry_0027();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0030()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0014();
                result.Geometry = CompositionPathGeometry_0028();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0031()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0014();
                result.Geometry = CompositionPathGeometry_0029();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0032()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0015();
                result.Geometry = CompositionPathGeometry_0030();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0033()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0013();
                result.Geometry = CompositionPathGeometry_0031();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0034()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0003();
                result.Geometry = CompositionPathGeometry_0032();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0035()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0003();
                result.Geometry = CompositionPathGeometry_0033();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0036()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0003();
                result.Geometry = CompositionPathGeometry_0034();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0037()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0003();
                result.Geometry = CompositionPathGeometry_0035();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0038()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0003();
                result.Geometry = CompositionPathGeometry_0036();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0039()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0003();
                result.Geometry = CompositionPathGeometry_0037();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0040()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0003();
                result.Geometry = CompositionPathGeometry_0038();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0041()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0015();
                result.Geometry = CompositionPathGeometry_0039();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0042()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0016();
                result.Geometry = CompositionPathGeometry_0040();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0043()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0014();
                result.Geometry = CompositionPathGeometry_0041();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0044()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0015();
                result.Geometry = CompositionPathGeometry_0042();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0045()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0014();
                result.Geometry = CompositionPathGeometry_0043();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0046()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0014();
                result.Geometry = CompositionPathGeometry_0044();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0047()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0015();
                result.Geometry = CompositionPathGeometry_0045();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0048()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0015();
                result.Geometry = CompositionPathGeometry_0046();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0049()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0014();
                result.Geometry = CompositionPathGeometry_0047();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0050()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0014();
                result.Geometry = CompositionPathGeometry_0048();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0051()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0015();
                result.Geometry = CompositionPathGeometry_0049();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0052()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0013();
                result.Geometry = CompositionPathGeometry_0050();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0053()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0003();
                result.Geometry = CompositionPathGeometry_0051();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0054()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0003();
                result.Geometry = CompositionPathGeometry_0052();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0055()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0003();
                result.Geometry = CompositionPathGeometry_0053();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0056()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0003();
                result.Geometry = CompositionPathGeometry_0054();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0057()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0003();
                result.Geometry = CompositionPathGeometry_0055();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0058()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0003();
                result.Geometry = CompositionPathGeometry_0056();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0059()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0003();
                result.Geometry = CompositionPathGeometry_0057();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0060()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0015();
                result.Geometry = CompositionPathGeometry_0058();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0061()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0016();
                result.Geometry = CompositionPathGeometry_0059();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0062()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0017();
                result.Geometry = CompositionPathGeometry_0060();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0063()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0018();
                result.Geometry = CompositionPathGeometry_0061();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0064()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0019();
                result.Geometry = CompositionPathGeometry_0062();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0065()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0019();
                result.Geometry = CompositionPathGeometry_0063();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0066()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0019();
                result.Geometry = CompositionPathGeometry_0064();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0067()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0019();
                result.Geometry = CompositionPathGeometry_0065();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0068()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0019();
                result.Geometry = CompositionPathGeometry_0066();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0069()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0019();
                result.Geometry = CompositionPathGeometry_0067();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0070()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0019();
                result.Geometry = CompositionPathGeometry_0068();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0071()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0019();
                result.Geometry = CompositionPathGeometry_0069();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0072()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0014();
                result.Geometry = CompositionPathGeometry_0070();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0073()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0015();
                result.Geometry = CompositionPathGeometry_0071();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0074()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0014();
                result.Geometry = CompositionPathGeometry_0072();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0075()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0014();
                result.Geometry = CompositionPathGeometry_0073();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0076()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0015();
                result.Geometry = CompositionPathGeometry_0074();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0077()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0015();
                result.Geometry = CompositionPathGeometry_0075();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0078()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0014();
                result.Geometry = CompositionPathGeometry_0076();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0079()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0014();
                result.Geometry = CompositionPathGeometry_0077();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0080()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0015();
                result.Geometry = CompositionPathGeometry_0078();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0081()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0013();
                result.Geometry = CompositionPathGeometry_0079();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0082()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0003();
                result.Geometry = CompositionPathGeometry_0080();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0083()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0003();
                result.Geometry = CompositionPathGeometry_0081();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0084()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0003();
                result.Geometry = CompositionPathGeometry_0082();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0085()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0003();
                result.Geometry = CompositionPathGeometry_0083();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0086()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0003();
                result.Geometry = CompositionPathGeometry_0084();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0087()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0003();
                result.Geometry = CompositionPathGeometry_0085();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0088()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0003();
                result.Geometry = CompositionPathGeometry_0086();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0089()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0015();
                result.Geometry = CompositionPathGeometry_0087();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0090()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0016();
                result.Geometry = CompositionPathGeometry_0088();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0091()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0019();
                result.Geometry = CompositionPathGeometry_0089();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0092()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0020();
                result.Geometry = CompositionPathGeometry_0090();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0093()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0020();
                result.Geometry = CompositionPathGeometry_0091();
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
                children.InsertAtTop(ContainerVisual_0001());
                children.InsertAtTop(ShapeVisual_0011());
                children.InsertAtTop(ContainerVisual_0037());
                return result;
            }

            ContainerVisual ContainerVisual_0001()
            {
                var result = _c.CreateContainerVisual();
                result.Clip = InsetClip_0000();
                result.Size = new Vector2(300, 300);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0002());
                return result;
            }

            ContainerVisual ContainerVisual_0002()
            {
                var result = _c.CreateContainerVisual();
                result.Offset = new Vector3(150, 150, 0);
                result.Scale = new Vector3(3, 3, 1);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0003());
                return result;
            }

            ContainerVisual ContainerVisual_0003()
            {
                var result = _c.CreateContainerVisual();
                result.CenterPoint = new Vector3(48.166F, 70.722F, 0);
                result.Offset = new Vector3(-48.082F, -36.251F, 0);
                result.Scale = new Vector3(0.9F, 0.9F, 1);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0004());
                return result;
            }

            ContainerVisual ContainerVisual_0004()
            {
                var result = _c.CreateContainerVisual();
                result.CenterPoint = new Vector3(37.5F, 21.5F, 0);
                result.Offset = new Vector3(10.576F, 8.044001F, 0);
                result.Scale = new Vector3(1.17F, 1.17647F, 1);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0005());
                return result;
            }

            ContainerVisual ContainerVisual_0005()
            {
                var result = _c.CreateContainerVisual();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var children = result.Children;
                children.InsertAtTop(ShapeVisual_0001());
                children.InsertAtTop(ContainerVisual_0006());
                children.InsertAtTop(ShapeVisual_0003());
                children.InsertAtTop(ContainerVisual_0009());
                {
                    var animation = ScalarKeyFrameAnimation_0000();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0001(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            ContainerVisual ContainerVisual_0006()
            {
                var result = _c.CreateContainerVisual();
                result.Clip = InsetClip_0001();
                result.Size = new Vector2(75, 43);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0007());
                return result;
            }

            ContainerVisual ContainerVisual_0007()
            {
                var result = _c.CreateContainerVisual();
                result.CenterPoint = new Vector3(10, 10, 0);
                result.Offset = new Vector3(12.5F, -0.75F, 0);
                result.Scale = new Vector3(0.65F, 0.65F, 1);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0008());
                return result;
            }

            ContainerVisual ContainerVisual_0008()
            {
                var result = _c.CreateContainerVisual();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var children = result.Children;
                children.InsertAtTop(ShapeVisual_0002());
                {
                    var animation = ScalarKeyFrameAnimation_0002();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0001(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            ContainerVisual ContainerVisual_0009()
            {
                var result = _c.CreateContainerVisual();
                result.Clip = InsetClip_0002();
                result.Size = new Vector2(75, 43);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0010());
                return result;
            }

            ContainerVisual ContainerVisual_0010()
            {
                var result = _c.CreateContainerVisual();
                result.CenterPoint = new Vector3(640, 250, 0);
                result.Offset = new Vector3(-602.125F, -221.875F, 0);
                result.Scale = new Vector3(0.06F, 0.06F, 1);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0011());
                return result;
            }

            ContainerVisual ContainerVisual_0011()
            {
                var result = _c.CreateContainerVisual();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0012());
                {
                    var animation = ScalarKeyFrameAnimation_0029();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0001(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            ContainerVisual ContainerVisual_0012()
            {
                var result = _c.CreateContainerVisual();
                result.Clip = InsetClip_0003();
                result.Size = new Vector2(1280, 500);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0013());
                return result;
            }

            ContainerVisual ContainerVisual_0013()
            {
                var result = _c.CreateContainerVisual();
                result.CenterPoint = new Vector3(640, 512, 0);
                result.Offset = new Vector3(0, -487, 0);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0014());
                return result;
            }

            ContainerVisual ContainerVisual_0014()
            {
                var result = _c.CreateContainerVisual();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0015());
                children.InsertAtTop(ContainerVisual_0017());
                children.InsertAtTop(ContainerVisual_0019());
                children.InsertAtTop(ContainerVisual_0025());
                children.InsertAtTop(ContainerVisual_0034());
                children.InsertAtTop(ShapeVisual_0010());
                {
                    var animation = ScalarKeyFrameAnimation_0030();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0001(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            ContainerVisual ContainerVisual_0015()
            {
                var result = _c.CreateContainerVisual();
                result.Clip = InsetClip_0004();
                result.Size = new Vector2(1280, 1024);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0016());
                return result;
            }

            ContainerVisual ContainerVisual_0016()
            {
                var result = _c.CreateContainerVisual();
                result.CenterPoint = new Vector3(989.895F, 919.523F, 0);
                result.Offset = new Vector3(-320, -150, 0);
                result.Scale = new Vector3(-0.25F, 0.25F, 1);
                var children = result.Children;
                children.InsertAtTop(ShapeVisual_0004());
                return result;
            }

            ContainerVisual ContainerVisual_0017()
            {
                var result = _c.CreateContainerVisual();
                result.Clip = InsetClip_0005();
                result.Size = new Vector2(1280, 1024);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0018());
                return result;
            }

            ContainerVisual ContainerVisual_0018()
            {
                var result = _c.CreateContainerVisual();
                result.CenterPoint = new Vector3(989.895F, 919.523F, 0);
                result.Offset = new Vector3(-448, -106, 0);
                result.Scale = new Vector3(0.4F, 0.4F, 1);
                var children = result.Children;
                children.InsertAtTop(ShapeVisual_0005());
                return result;
            }

            ContainerVisual ContainerVisual_0019()
            {
                var result = _c.CreateContainerVisual();
                result.Clip = InsetClip_0006();
                result.Size = new Vector2(1280, 1024);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0020());
                return result;
            }

            ContainerVisual ContainerVisual_0020()
            {
                var result = _c.CreateContainerVisual();
                result.CenterPoint = new Vector3(0, 1024, 0);
                result.Scale = new Vector3(0.9F, 0.9F, 1);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0021());
                return result;
            }

            ContainerVisual ContainerVisual_0021()
            {
                var result = _c.CreateContainerVisual();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0022());
                {
                    var animation = ScalarKeyFrameAnimation_0031();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0001(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            ContainerVisual ContainerVisual_0022()
            {
                var result = _c.CreateContainerVisual();
                result.Clip = InsetClip_0007();
                result.Size = new Vector2(1280, 1024);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0023());
                return result;
            }

            ContainerVisual ContainerVisual_0023()
            {
                var result = _c.CreateContainerVisual();
                result.CenterPoint = new Vector3(641.648F, 888.996F, 0);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0024());
                return result;
            }

            ContainerVisual ContainerVisual_0024()
            {
                var result = _c.CreateContainerVisual();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var children = result.Children;
                children.InsertAtTop(ShapeVisual_0006());
                {
                    var animation = ScalarKeyFrameAnimation_0032();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0001(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            ContainerVisual ContainerVisual_0025()
            {
                var result = _c.CreateContainerVisual();
                result.Clip = InsetClip_0008();
                result.Size = new Vector2(1280, 1024);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0026());
                return result;
            }

            ContainerVisual ContainerVisual_0026()
            {
                var result = _c.CreateContainerVisual();
                result.CenterPoint = new Vector3(990.746F, 871.215F, 0);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0027());
                return result;
            }

            ContainerVisual ContainerVisual_0027()
            {
                var result = _c.CreateContainerVisual();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0028());
                children.InsertAtTop(ContainerVisual_0031());
                {
                    var animation = ScalarKeyFrameAnimation_0035();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0001(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            ContainerVisual ContainerVisual_0028()
            {
                var result = _c.CreateContainerVisual();
                result.Clip = InsetClip_0009();
                result.Size = new Vector2(1280, 1024);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0029());
                return result;
            }

            ContainerVisual ContainerVisual_0029()
            {
                var result = _c.CreateContainerVisual();
                result.CenterPoint = new Vector3(640, 512, 0);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0030());
                return result;
            }

            ContainerVisual ContainerVisual_0030()
            {
                var result = _c.CreateContainerVisual();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var children = result.Children;
                children.InsertAtTop(ShapeVisual_0007());
                {
                    var animation = ScalarKeyFrameAnimation_0036();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0001(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            ContainerVisual ContainerVisual_0031()
            {
                var result = _c.CreateContainerVisual();
                result.Clip = InsetClip_0010();
                result.Size = new Vector2(1280, 1024);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0032());
                return result;
            }

            ContainerVisual ContainerVisual_0032()
            {
                var result = _c.CreateContainerVisual();
                result.CenterPoint = new Vector3(640, 512, 0);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0033());
                return result;
            }

            ContainerVisual ContainerVisual_0033()
            {
                var result = _c.CreateContainerVisual();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var children = result.Children;
                children.InsertAtTop(ShapeVisual_0008());
                {
                    var animation = ScalarKeyFrameAnimation_0041();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0001(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            ContainerVisual ContainerVisual_0034()
            {
                var result = _c.CreateContainerVisual();
                result.Clip = InsetClip_0011();
                result.Size = new Vector2(1280, 1024);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0035());
                return result;
            }

            ContainerVisual ContainerVisual_0035()
            {
                var result = _c.CreateContainerVisual();
                result.CenterPoint = new Vector3(989.895F, 919.523F, 0);
                result.Offset = new Vector3(42, 201.9999F, 0);
                result.Scale = new Vector3(-2, 2, 1);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0036());
                return result;
            }

            ContainerVisual ContainerVisual_0036()
            {
                var result = _c.CreateContainerVisual();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var children = result.Children;
                children.InsertAtTop(ShapeVisual_0009());
                {
                    var animation = ScalarKeyFrameAnimation_0046();
                    result.StartAnimation("Visibility", animation);
                    {
                        var controller = result.TryGetAnimationController("Visibility");
                        controller.Pause();
                        {
                            var controlleranimation = ExpressionAnimation_0000();
                            controller.StartAnimation("Progress", controlleranimation);
                        }
                    }
                }
                {
                    var animation = ExpressionAnimation_0001(result);
                    result.StartAnimation("TransformMatrix", animation);
                }
                return result;
            }

            ContainerVisual ContainerVisual_0037()
            {
                var result = _c.CreateContainerVisual();
                result.Clip = InsetClip_0012();
                result.Size = new Vector2(300, 300);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0038());
                return result;
            }

            ContainerVisual ContainerVisual_0038()
            {
                var result = _c.CreateContainerVisual();
                result.Offset = new Vector3(150, 150, 0);
                result.Scale = new Vector3(3, 3, 1);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0039());
                return result;
            }

            ContainerVisual ContainerVisual_0039()
            {
                var result = _c.CreateContainerVisual();
                result.CenterPoint = new Vector3(48.166F, 70.722F, 0);
                result.Offset = new Vector3(-48.082F, -36.251F, 0);
                result.Scale = new Vector3(0.9F, 0.9F, 1);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0040());
                return result;
            }

            ContainerVisual ContainerVisual_0040()
            {
                var result = _c.CreateContainerVisual();
                result.CenterPoint = new Vector3(48, 33, 0);
                result.Offset = new Vector3(0.6380005F, -3.224001F, 0);
                result.Scale = new Vector3(0.92041F, 0.7605F, 1);
                var children = result.Children;
                children.InsertAtTop(ShapeVisual_0012());
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

            CubicBezierEasingFunction CubicBezierEasingFunction_0001()
            {
                if (_cubicBezierEasingFunction_0001 != null)
                {
                    return _cubicBezierEasingFunction_0001;
                }
                var result = _cubicBezierEasingFunction_0001 = _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0.25F, 1));
                return result;
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0002()
            {
                var result = _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0), new Vector2(0, 1));
                return result;
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0003()
            {
                var result = _c.CreateCubicBezierEasingFunction(new Vector2(0.559F, 0), new Vector2(0.15F, 1));
                return result;
            }

            ExpressionAnimation ExpressionAnimation_0000()
            {
                if (_expressionAnimation_0000 != null)
                {
                    return _expressionAnimation_0000;
                }
                var result = _expressionAnimation_0000 = _c.CreateExpressionAnimation("root.AnimationProgress");
                result.SetReferenceParameter("root", ContainerVisual_0000());
                return result;
            }

            ExpressionAnimation ExpressionAnimation_0001(CompositionObject arg)
            {
                var result = _c.CreateExpressionAnimation("Matrix4x4(contents.Visibility,0,0,0,0,contents.Visibility,0,0,0,0,contents.Visibility,0,0,0,0,contents.Visibility)");
                result.SetReferenceParameter("contents", arg);
                return result;
            }

            ExpressionAnimation ExpressionAnimation_0002(CompositionObject arg)
            {
                var result = _c.CreateExpressionAnimation("Matrix3x2(contents.Visibility,0,0,contents.Visibility,0,0)");
                result.SetReferenceParameter("contents", arg);
                return result;
            }

            ExpressionAnimation ExpressionAnimation_0003()
            {
                if (_expressionAnimation_0003 != null)
                {
                    return _expressionAnimation_0003;
                }
                var result = _expressionAnimation_0003 = _c.CreateExpressionAnimation("root.AnimationProgress*0.888888889");
                result.SetReferenceParameter("root", ContainerVisual_0000());
                return result;
            }

            ExpressionAnimation ExpressionAnimation_0004(CompositionObject arg)
            {
                var result = _c.CreateExpressionAnimation("my.Position-my.Anchor");
                result.SetReferenceParameter("my", arg);
                return result;
            }

            InsetClip InsetClip_0000()
            {
                var result = _c.CreateInsetClip();
                return result;
            }

            InsetClip InsetClip_0001()
            {
                var result = _c.CreateInsetClip();
                return result;
            }

            InsetClip InsetClip_0002()
            {
                var result = _c.CreateInsetClip();
                return result;
            }

            InsetClip InsetClip_0003()
            {
                var result = _c.CreateInsetClip();
                return result;
            }

            InsetClip InsetClip_0004()
            {
                var result = _c.CreateInsetClip();
                return result;
            }

            InsetClip InsetClip_0005()
            {
                var result = _c.CreateInsetClip();
                return result;
            }

            InsetClip InsetClip_0006()
            {
                var result = _c.CreateInsetClip();
                return result;
            }

            InsetClip InsetClip_0007()
            {
                var result = _c.CreateInsetClip();
                return result;
            }

            InsetClip InsetClip_0008()
            {
                var result = _c.CreateInsetClip();
                return result;
            }

            InsetClip InsetClip_0009()
            {
                var result = _c.CreateInsetClip();
                return result;
            }

            InsetClip InsetClip_0010()
            {
                var result = _c.CreateInsetClip();
                return result;
            }

            InsetClip InsetClip_0011()
            {
                var result = _c.CreateInsetClip();
                return result;
            }

            InsetClip InsetClip_0012()
            {
                var result = _c.CreateInsetClip();
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

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0000()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.1333333F, 1, StepEasingFunction_0000());
                result.InsertKeyFrame(0.7666667F, 0, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0001()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.1333333F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0002()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.1333333F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0003()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1185185F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(1, 360, CubicBezierEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0004()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.1333333F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0005()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1185185F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(1, 360, CubicBezierEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0006()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.1333333F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0007()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1185185F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(1, 360, CubicBezierEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0008()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.1333333F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0009()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1185185F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(1, 360, CubicBezierEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0010()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.1333333F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0011()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1185185F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(1, 360, CubicBezierEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0012()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.1333333F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0013()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1185185F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(1, 360, CubicBezierEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0014()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.1333333F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0015()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1185185F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(1, 360, CubicBezierEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0016()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.1333333F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0017()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1185185F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(1, 360, CubicBezierEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0018()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.1333333F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0019()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1185185F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(1, 360, CubicBezierEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0020()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.1333333F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0021()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.2666667F, 1, StepEasingFunction_0000());
                result.InsertKeyFrame(0.9F, 0, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0022()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.1333333F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0023()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.1333333F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0024()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.1333333F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0025()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.1333333F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0026()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.1333333F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0027()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.1333333F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0028()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.1333333F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0029()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.1333333F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0030()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.05F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0031()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.05F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0032()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.05F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0033()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.05F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0034()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.05F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0035()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.05F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0036()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.05F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0037()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.05F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0038()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.05F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0039()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.05F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0040()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.05F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0041()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.05F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0042()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.05F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0043()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.05F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0044()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.05F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0045()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.05F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0046()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.05F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0047()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.05F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0048()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.05F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0049()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0.7666667F, 1, StepEasingFunction_0000());
                result.InsertKeyFrame(0.9166667F, 0, StepEasingFunction_0000());
                return result;
            }

            ShapeVisual ShapeVisual_0000()
            {
                var result = _c.CreateShapeVisual();
                result.Size = new Vector2(300, 300);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0000());
                return result;
            }

            ShapeVisual ShapeVisual_0001()
            {
                var result = _c.CreateShapeVisual();
                result.Size = new Vector2(75, 43);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0007());
                return result;
            }

            ShapeVisual ShapeVisual_0002()
            {
                var result = _c.CreateShapeVisual();
                result.Size = new Vector2(20, 20);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0009());
                shapes.Add(CompositionContainerShape_0012());
                shapes.Add(CompositionContainerShape_0016());
                shapes.Add(CompositionContainerShape_0020());
                shapes.Add(CompositionContainerShape_0024());
                shapes.Add(CompositionContainerShape_0028());
                shapes.Add(CompositionContainerShape_0032());
                shapes.Add(CompositionContainerShape_0036());
                shapes.Add(CompositionContainerShape_0040());
                return result;
            }

            ShapeVisual ShapeVisual_0003()
            {
                var result = _c.CreateShapeVisual();
                result.Size = new Vector2(75, 43);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0044());
                shapes.Add(CompositionContainerShape_0047());
                shapes.Add(CompositionContainerShape_0051());
                shapes.Add(CompositionContainerShape_0054());
                shapes.Add(CompositionContainerShape_0057());
                shapes.Add(CompositionContainerShape_0060());
                shapes.Add(CompositionContainerShape_0063());
                shapes.Add(CompositionContainerShape_0066());
                return result;
            }

            ShapeVisual ShapeVisual_0004()
            {
                var result = _c.CreateShapeVisual();
                result.Size = new Vector2(1280, 1024);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0069());
                return result;
            }

            ShapeVisual ShapeVisual_0005()
            {
                var result = _c.CreateShapeVisual();
                result.Size = new Vector2(1280, 1024);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0089());
                return result;
            }

            ShapeVisual ShapeVisual_0006()
            {
                var result = _c.CreateShapeVisual();
                result.Size = new Vector2(1280, 1024);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0109());
                shapes.Add(CompositionContainerShape_0112());
                return result;
            }

            ShapeVisual ShapeVisual_0007()
            {
                var result = _c.CreateShapeVisual();
                result.Size = new Vector2(1280, 1024);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0115());
                shapes.Add(CompositionContainerShape_0118());
                shapes.Add(CompositionContainerShape_0121());
                shapes.Add(CompositionContainerShape_0124());
                return result;
            }

            ShapeVisual ShapeVisual_0008()
            {
                var result = _c.CreateShapeVisual();
                result.Size = new Vector2(1280, 1024);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0127());
                shapes.Add(CompositionContainerShape_0130());
                shapes.Add(CompositionContainerShape_0133());
                shapes.Add(CompositionContainerShape_0136());
                return result;
            }

            ShapeVisual ShapeVisual_0009()
            {
                var result = _c.CreateShapeVisual();
                result.Size = new Vector2(1280, 1024);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0139());
                return result;
            }

            ShapeVisual ShapeVisual_0010()
            {
                var result = _c.CreateShapeVisual();
                result.Size = new Vector2(1280, 1024);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0160());
                return result;
            }

            ShapeVisual ShapeVisual_0011()
            {
                var result = _c.CreateShapeVisual();
                result.Size = new Vector2(300, 300);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0163());
                return result;
            }

            ShapeVisual ShapeVisual_0012()
            {
                var result = _c.CreateShapeVisual();
                result.Size = new Vector2(96, 66);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0168());
                return result;
            }

            StepEasingFunction StepEasingFunction_0000()
            {
                if (_stepEasingFunction_0000 != null)
                {
                    return _stepEasingFunction_0000;
                }
                var result = _stepEasingFunction_0000 = _c.CreateStepEasingFunction();
                result.IsFinalStepSingleFrame = true;
                return result;
            }

            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0000()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0, new Vector2(20.155F, 22.121F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1185185F, new Vector2(20.155F, 22.121F), LinearEasingFunction_0000());
                result.InsertKeyFrame(1, new Vector2(22.155F, 22.121F), CubicBezierEasingFunction_0001());
                return result;
            }

            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0001()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0, new Vector2(37.655F, 24.246F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1185185F, new Vector2(37.655F, 24.246F), LinearEasingFunction_0000());
                result.InsertKeyFrame(1, new Vector2(35.655F, 24.246F), CubicBezierEasingFunction_0001());
                return result;
            }

            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0002()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0, new Vector2(37.655F, 27.646F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1185185F, new Vector2(37.655F, 27.646F), LinearEasingFunction_0000());
                result.InsertKeyFrame(1, new Vector2(42.655F, 27.646F), CubicBezierEasingFunction_0001());
                return result;
            }

            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0003()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0, new Vector2(37.655F, 36.446F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1185185F, new Vector2(37.655F, 36.446F), LinearEasingFunction_0000());
                result.InsertKeyFrame(1, new Vector2(32.655F, 36.446F), CubicBezierEasingFunction_0001());
                return result;
            }

            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0004()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0, new Vector2(45.709F, 11.496F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1185185F, new Vector2(45.709F, 11.496F), LinearEasingFunction_0000());
                result.InsertKeyFrame(1, new Vector2(49.459F, 11.496F), CubicBezierEasingFunction_0001());
                return result;
            }

            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0005()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0, new Vector2(23.209F, 11.496F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1185185F, new Vector2(23.209F, 11.496F), LinearEasingFunction_0000());
                result.InsertKeyFrame(1, new Vector2(26.959F, 11.496F), CubicBezierEasingFunction_0001());
                return result;
            }

            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0006()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0, new Vector2(38.023F, 8.946F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1185185F, new Vector2(38.023F, 8.946F), LinearEasingFunction_0000());
                result.InsertKeyFrame(1, new Vector2(46.773F, 8.946F), CubicBezierEasingFunction_0001());
                return result;
            }

            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0007()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0, new Vector2(1, 1), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7666667F, new Vector2(1, 1), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.9F, new Vector2(1, 0), CubicBezierEasingFunction_0002());
                return result;
            }

            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0008()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(20000000);
                result.InsertKeyFrame(0, new Vector2(-67.5F, 38), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.325F, new Vector2(271.954F, 38), CubicBezierEasingFunction_0003());
                return result;
            }

        }
    }
}
