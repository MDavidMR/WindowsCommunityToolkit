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
    sealed class BatteryComposition : ICompositionSource
    {
        public void CreateInstance(
            Compositor compositor,
            out Visual rootVisual,
            out Vector2 size,
            out CompositionPropertySet progressPropertySet,
            out TimeSpan duration)
        {
            rootVisual = Instantiator.InstantiateComposition(compositor);
            size = new Vector2(1920, 1081);
            progressPropertySet = rootVisual.Properties;
            duration = TimeSpan.FromTicks(28800000);
        }

        void ICompositionSource.ConnectSink(ICompositionSink sink)
        {
            CreateInstance(
                Window.Current.Compositor,
                out var rootVisual,
                out var size,
                out var progressPropertySet,
                out var duration);

            sink.SetContent(
                rootVisual,
                size,
                progressPropertySet,
                duration,
                null);
        }

        void ICompositionSource.DisconnectSink(ICompositionSink sink) { }

        sealed class Instantiator
        {
            readonly Compositor _c;
            readonly ExpressionAnimation _expressionAnimation;
            CompositionColorBrush _compositionColorBrush_0000;
            CompositionColorBrush _compositionColorBrush_0001;
            CompositionColorBrush _compositionColorBrush_0004;
            CompositionColorBrush _compositionColorBrush_0005;
            CompositionColorBrush _compositionColorBrush_0006;
            ContainerVisual _containerVisual_0000;
            ExpressionAnimation _expressionAnimation_0000;
            InsetClip _insetClip_0000;
            StepEasingFunction _stepEasingFunction_0000;

            internal static Visual InstantiateComposition(Compositor compositor)
                => new Instantiator(compositor).ContainerVisual_0000();

            Instantiator(Compositor compositor)
            {
                _c = compositor;
                _expressionAnimation = compositor.CreateExpressionAnimation();
            }

            CanvasGeometry CanvasGeometry_0000()
            {
                using (var builder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice()))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(166, 403.5F));
                    builder.AddCubicBezier(new Vector2(166, 403.5F), new Vector2(-226, 405.5F), new Vector2(-226, 405.5F));
                    builder.AddCubicBezier(new Vector2(-226, 405.5F), new Vector2(-194, 459.5F), new Vector2(-194, 459.5F));
                    builder.AddCubicBezier(new Vector2(-194, 459.5F), new Vector2(136, 453.5F), new Vector2(136, 453.5F));
                    builder.AddCubicBezier(new Vector2(136, 453.5F), new Vector2(166, 403.5F), new Vector2(166, 403.5F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CompositionColorBrush CompositionColorBrush_0000()
            {
                if (_compositionColorBrush_0000 != null)
                {
                    return _compositionColorBrush_0000;
                }
                var result = _compositionColorBrush_0000 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x84, 0x8A, 0x90));
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0001()
            {
                if (_compositionColorBrush_0001 != null)
                {
                    return _compositionColorBrush_0001;
                }
                var result = _compositionColorBrush_0001 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x1F, 0x0E, 0x0E));
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0002()
            {
                return _c.CreateColorBrush(Color.FromArgb(0xFF, 0xB6, 0xCC, 0xE2));
            }

            CompositionColorBrush CompositionColorBrush_0003()
            {
                return _c.CreateColorBrush(Color.FromArgb(0xFF, 0x46, 0x3F, 0x3F));
            }

            CompositionColorBrush CompositionColorBrush_0004()
            {
                if (_compositionColorBrush_0004 != null)
                {
                    return _compositionColorBrush_0004;
                }
                var result = _compositionColorBrush_0004 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xF3, 0x1B, 0x0A));
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0005()
            {
                if (_compositionColorBrush_0005 != null)
                {
                    return _compositionColorBrush_0005;
                }
                var result = _compositionColorBrush_0005 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xF3, 0xE6, 0x0A));
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0006()
            {
                if (_compositionColorBrush_0006 != null)
                {
                    return _compositionColorBrush_0006;
                }
                var result = _compositionColorBrush_0006 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x0A, 0xF3, 0x36));
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0000()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(960, 540.5F);
                result.Scale = new Vector2(0.99115F, 0.99565F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0001());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0001()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0000());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0002()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(964, 476.5F);
                result.Scale = new Vector2(1.18F, 1.18F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0003());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0003()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(-30, 73.5F);
                result.Scale = new Vector2(1, 0.8725F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0001());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0004()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(960, 540.5F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0005());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0005()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(-31, -418.5F);
                result.Scale = new Vector2(0.76F, 1);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0002());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0006()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(-37.082F, -361.679F);
                result.Offset = new Vector2(961.082F, 534.179F);
                result.Scale = new Vector2(0.97083F, 1.01748F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0007());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0007()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(-38, -372.5F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0003());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0008()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(961, 721.5F);
                result.Scale = new Vector2(0.99301F, 0.55026F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0009());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0009()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0010());
                result.StartAnimation("Visibility", ScalarKeyFrameAnimation_0000());
                var controller = result.TryGetAnimationController("Visibility");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Matrix3x2(contents.Visibility,0,0,contents.Visibility,0,0)";
                _expressionAnimation.SetReferenceParameter("contents", result);
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0010()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(-32, 351.5F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0004());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0011()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(961, 674.5F);
                result.Scale = new Vector2(0.99301F, 0.55026F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0012());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0012()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0013());
                result.StartAnimation("Visibility", ScalarKeyFrameAnimation_0001());
                var controller = result.TryGetAnimationController("Visibility");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Matrix3x2(contents.Visibility,0,0,contents.Visibility,0,0)";
                _expressionAnimation.SetReferenceParameter("contents", result);
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0013()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(-32, 351.5F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0005());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0014()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(961, 627.5F);
                result.Scale = new Vector2(0.99301F, 0.55026F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0015());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0015()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0016());
                result.StartAnimation("Visibility", ScalarKeyFrameAnimation_0002());
                var controller = result.TryGetAnimationController("Visibility");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Matrix3x2(contents.Visibility,0,0,contents.Visibility,0,0)";
                _expressionAnimation.SetReferenceParameter("contents", result);
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0016()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(-32, 351.5F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0006());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0017()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(961, 580.5F);
                result.Scale = new Vector2(0.99301F, 0.55026F);
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
                result.StartAnimation("Visibility", ScalarKeyFrameAnimation_0003());
                var controller = result.TryGetAnimationController("Visibility");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Matrix3x2(contents.Visibility,0,0,contents.Visibility,0,0)";
                _expressionAnimation.SetReferenceParameter("contents", result);
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0019()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(-32, 351.5F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0007());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0020()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(961, 533.5F);
                result.Scale = new Vector2(0.99301F, 0.55026F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0021());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0021()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0022());
                result.StartAnimation("Visibility", ScalarKeyFrameAnimation_0004());
                var controller = result.TryGetAnimationController("Visibility");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Matrix3x2(contents.Visibility,0,0,contents.Visibility,0,0)";
                _expressionAnimation.SetReferenceParameter("contents", result);
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0022()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(-32, 351.5F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0008());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0023()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(961, 485.5F);
                result.Scale = new Vector2(0.99301F, 0.55026F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0024());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0024()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0025());
                result.StartAnimation("Visibility", ScalarKeyFrameAnimation_0005());
                var controller = result.TryGetAnimationController("Visibility");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Matrix3x2(contents.Visibility,0,0,contents.Visibility,0,0)";
                _expressionAnimation.SetReferenceParameter("contents", result);
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0025()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(-32, 351.5F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0009());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0026()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(961, 437.5F);
                result.Scale = new Vector2(0.99301F, 0.55026F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0027());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0027()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0028());
                result.StartAnimation("Visibility", ScalarKeyFrameAnimation_0006());
                var controller = result.TryGetAnimationController("Visibility");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Matrix3x2(contents.Visibility,0,0,contents.Visibility,0,0)";
                _expressionAnimation.SetReferenceParameter("contents", result);
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0028()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(-32, 351.5F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0010());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0029()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(961, 389.5F);
                result.Scale = new Vector2(0.99301F, 0.55026F);
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
                result.StartAnimation("Visibility", ScalarKeyFrameAnimation_0007());
                var controller = result.TryGetAnimationController("Visibility");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Matrix3x2(contents.Visibility,0,0,contents.Visibility,0,0)";
                _expressionAnimation.SetReferenceParameter("contents", result);
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0031()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(-32, 351.5F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0011());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0032()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(961, 341.5F);
                result.Scale = new Vector2(0.99301F, 0.55026F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0033());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0033()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0034());
                result.StartAnimation("Visibility", ScalarKeyFrameAnimation_0008());
                var controller = result.TryGetAnimationController("Visibility");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Matrix3x2(contents.Visibility,0,0,contents.Visibility,0,0)";
                _expressionAnimation.SetReferenceParameter("contents", result);
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0034()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(-32, 351.5F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0012());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0035()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(962, 293);
                result.Scale = new Vector2(0.99301F, 0.55026F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0036());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0036()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0037());
                result.StartAnimation("Visibility", ScalarKeyFrameAnimation_0009());
                var controller = result.TryGetAnimationController("Visibility");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Matrix3x2(contents.Visibility,0,0,contents.Visibility,0,0)";
                _expressionAnimation.SetReferenceParameter("contents", result);
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0037()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(-32, 351.5F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0013());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0038()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(962, 245);
                result.Scale = new Vector2(0.99301F, 0.55026F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0039());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0039()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Visibility", 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0040());
                result.StartAnimation("Visibility", ScalarKeyFrameAnimation_0010());
                var controller = result.TryGetAnimationController("Visibility");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Matrix3x2(contents.Visibility,0,0,contents.Visibility,0,0)";
                _expressionAnimation.SetReferenceParameter("contents", result);
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0040()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(-32, 351.5F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0014());
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0000()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0000()));
                return result;
            }

            CompositionRoundedRectangleGeometry CompositionRoundedRectangleGeometry_0000()
            {
                var result = _c.CreateRoundedRectangleGeometry();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Position", new Vector2(0, 0));
                result.CornerRadius = new Vector2(20, 20);
                result.Size = new Vector2(348, 740);
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Vector2(my.Position.X-(my.Size.X/2),my.Position.Y-(my.Size.Y/2))";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                return result;
            }

            CompositionRoundedRectangleGeometry CompositionRoundedRectangleGeometry_0001()
            {
                var result = _c.CreateRoundedRectangleGeometry();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Position", new Vector2(0, 0));
                result.CornerRadius = new Vector2(20, 20);
                result.Size = new Vector2(150, 44);
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Vector2(my.Position.X-(my.Size.X/2),my.Position.Y-(my.Size.Y/2))";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                return result;
            }

            CompositionRoundedRectangleGeometry CompositionRoundedRectangleGeometry_0002()
            {
                var result = _c.CreateRoundedRectangleGeometry();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Position", new Vector2(0, 0));
                result.CornerRadius = new Vector2(20, 20);
                result.Size = new Vector2(404, 56);
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Vector2(my.Position.X-(my.Size.X/2),my.Position.Y-(my.Size.Y/2))";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                return result;
            }

            CompositionRoundedRectangleGeometry CompositionRoundedRectangleGeometry_0003()
            {
                var result = _c.CreateRoundedRectangleGeometry();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Position", new Vector2(0, 0));
                result.CornerRadius = new Vector2(20, 20);
                result.Size = new Vector2(396, 80);
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Vector2(my.Position.X-(my.Size.X/2),my.Position.Y-(my.Size.Y/2))";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                return result;
            }

            CompositionRoundedRectangleGeometry CompositionRoundedRectangleGeometry_0004()
            {
                var result = _c.CreateRoundedRectangleGeometry();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Position", new Vector2(0, 0));
                result.CornerRadius = new Vector2(20, 20);
                result.Size = new Vector2(396, 80);
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Vector2(my.Position.X-(my.Size.X/2),my.Position.Y-(my.Size.Y/2))";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                return result;
            }

            CompositionRoundedRectangleGeometry CompositionRoundedRectangleGeometry_0005()
            {
                var result = _c.CreateRoundedRectangleGeometry();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Position", new Vector2(0, 0));
                result.CornerRadius = new Vector2(20, 20);
                result.Size = new Vector2(396, 80);
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Vector2(my.Position.X-(my.Size.X/2),my.Position.Y-(my.Size.Y/2))";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                return result;
            }

            CompositionRoundedRectangleGeometry CompositionRoundedRectangleGeometry_0006()
            {
                var result = _c.CreateRoundedRectangleGeometry();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Position", new Vector2(0, 0));
                result.CornerRadius = new Vector2(20, 20);
                result.Size = new Vector2(396, 80);
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Vector2(my.Position.X-(my.Size.X/2),my.Position.Y-(my.Size.Y/2))";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                return result;
            }

            CompositionRoundedRectangleGeometry CompositionRoundedRectangleGeometry_0007()
            {
                var result = _c.CreateRoundedRectangleGeometry();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Position", new Vector2(0, 0));
                result.CornerRadius = new Vector2(20, 20);
                result.Size = new Vector2(396, 80);
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Vector2(my.Position.X-(my.Size.X/2),my.Position.Y-(my.Size.Y/2))";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                return result;
            }

            CompositionRoundedRectangleGeometry CompositionRoundedRectangleGeometry_0008()
            {
                var result = _c.CreateRoundedRectangleGeometry();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Position", new Vector2(0, 0));
                result.CornerRadius = new Vector2(20, 20);
                result.Size = new Vector2(396, 80);
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Vector2(my.Position.X-(my.Size.X/2),my.Position.Y-(my.Size.Y/2))";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                return result;
            }

            CompositionRoundedRectangleGeometry CompositionRoundedRectangleGeometry_0009()
            {
                var result = _c.CreateRoundedRectangleGeometry();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Position", new Vector2(0, 0));
                result.CornerRadius = new Vector2(20, 20);
                result.Size = new Vector2(396, 80);
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Vector2(my.Position.X-(my.Size.X/2),my.Position.Y-(my.Size.Y/2))";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                return result;
            }

            CompositionRoundedRectangleGeometry CompositionRoundedRectangleGeometry_0010()
            {
                var result = _c.CreateRoundedRectangleGeometry();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Position", new Vector2(0, 0));
                result.CornerRadius = new Vector2(20, 20);
                result.Size = new Vector2(396, 80);
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Vector2(my.Position.X-(my.Size.X/2),my.Position.Y-(my.Size.Y/2))";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                return result;
            }

            CompositionRoundedRectangleGeometry CompositionRoundedRectangleGeometry_0011()
            {
                var result = _c.CreateRoundedRectangleGeometry();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Position", new Vector2(0, 0));
                result.CornerRadius = new Vector2(20, 20);
                result.Size = new Vector2(396, 80);
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Vector2(my.Position.X-(my.Size.X/2),my.Position.Y-(my.Size.Y/2))";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                return result;
            }

            CompositionRoundedRectangleGeometry CompositionRoundedRectangleGeometry_0012()
            {
                var result = _c.CreateRoundedRectangleGeometry();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Position", new Vector2(0, 0));
                result.CornerRadius = new Vector2(20, 20);
                result.Size = new Vector2(396, 80);
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Vector2(my.Position.X-(my.Size.X/2),my.Position.Y-(my.Size.Y/2))";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                return result;
            }

            CompositionRoundedRectangleGeometry CompositionRoundedRectangleGeometry_0013()
            {
                var result = _c.CreateRoundedRectangleGeometry();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Position", new Vector2(0, 0));
                result.CornerRadius = new Vector2(20, 20);
                result.Size = new Vector2(396, 80);
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Vector2(my.Position.X-(my.Size.X/2),my.Position.Y-(my.Size.Y/2))";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0000()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0000();
                result.Geometry = CompositionPathGeometry_0000();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 9;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0001()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0002();
                result.Geometry = CompositionRoundedRectangleGeometry_0000();
                result.StrokeBrush = CompositionColorBrush_0003();
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 9;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0002()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0000();
                result.Geometry = CompositionRoundedRectangleGeometry_0001();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 9;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0003()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0000();
                result.Geometry = CompositionRoundedRectangleGeometry_0002();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 9;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0004()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0004();
                result.Geometry = CompositionRoundedRectangleGeometry_0003();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 2;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0005()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0004();
                result.Geometry = CompositionRoundedRectangleGeometry_0004();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 2;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0006()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0004();
                result.Geometry = CompositionRoundedRectangleGeometry_0005();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 2;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0007()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0004();
                result.Geometry = CompositionRoundedRectangleGeometry_0006();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 2;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0008()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0005();
                result.Geometry = CompositionRoundedRectangleGeometry_0007();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 2;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0009()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0005();
                result.Geometry = CompositionRoundedRectangleGeometry_0008();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 2;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0010()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0005();
                result.Geometry = CompositionRoundedRectangleGeometry_0009();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 2;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0011()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0005();
                result.Geometry = CompositionRoundedRectangleGeometry_0010();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 2;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0012()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0006();
                result.Geometry = CompositionRoundedRectangleGeometry_0011();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 2;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0013()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0006();
                result.Geometry = CompositionRoundedRectangleGeometry_0012();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 2;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0014()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0006();
                result.Geometry = CompositionRoundedRectangleGeometry_0013();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 2;
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
                propertySet.InsertScalar("Progress", 0);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0001());
                children.InsertAtTop(ContainerVisual_0003());
                return result;
            }

            ContainerVisual ContainerVisual_0001()
            {
                var result = _c.CreateContainerVisual();
                result.Clip = InsetClip_0000();
                result.Size = new Vector2(1920, 1081);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0002());
                return result;
            }

            ContainerVisual ContainerVisual_0002()
            {
                var result = _c.CreateContainerVisual();
                result.CenterPoint = new Vector3(960, 540.5F, 0);
                result.Offset = new Vector3(0, 88, 0);
                result.Scale = new Vector3(1, 0.82979F, 1);
                var children = result.Children;
                children.InsertAtTop(ShapeVisual_0000());
                return result;
            }

            ContainerVisual ContainerVisual_0003()
            {
                var result = _c.CreateContainerVisual();
                result.Clip = InsetClip_0000();
                result.Size = new Vector2(1920, 1081);
                var children = result.Children;
                children.InsertAtTop(ContainerVisual_0004());
                return result;
            }

            ContainerVisual ContainerVisual_0004()
            {
                var result = _c.CreateContainerVisual();
                result.CenterPoint = new Vector3(960, 540.5F, 0);
                var children = result.Children;
                children.InsertAtTop(ShapeVisual_0001());
                return result;
            }

            ExpressionAnimation ExpressionAnimation_0000()
            {
                if (_expressionAnimation_0000 != null)
                {
                    return _expressionAnimation_0000;
                }
                var result = _expressionAnimation_0000 = _c.CreateExpressionAnimation();
                result.SetReferenceParameter("root", ContainerVisual_0000());
                result.Expression = "root.Progress";
                return result;
            }

            InsetClip InsetClip_0000()
            {
                if (_insetClip_0000 != null)
                {
                    return _insetClip_0000;
                }
                var result = _insetClip_0000 = _c.CreateInsetClip();
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0000()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(28800000);
                result.InsertKeyFrame(0.08333334F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0001()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(28800000);
                result.InsertKeyFrame(0.1527778F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0002()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(28800000);
                result.InsertKeyFrame(0.25F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0003()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(28800000);
                result.InsertKeyFrame(0.3194444F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0004()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(28800000);
                result.InsertKeyFrame(0.3888889F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0005()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(28800000);
                result.InsertKeyFrame(0.4861111F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0006()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(28800000);
                result.InsertKeyFrame(0.5833333F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0007()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(28800000);
                result.InsertKeyFrame(0.6527778F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0008()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(28800000);
                result.InsertKeyFrame(0.75F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0009()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(28800000);
                result.InsertKeyFrame(0.8333333F, 1, StepEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0010()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(28800000);
                result.InsertKeyFrame(0.9305556F, 1, StepEasingFunction_0000());
                return result;
            }

            ShapeVisual ShapeVisual_0000()
            {
                var result = _c.CreateShapeVisual();
                result.Size = new Vector2(1920, 1081);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0000());
                shapes.Add(CompositionContainerShape_0002());
                shapes.Add(CompositionContainerShape_0004());
                shapes.Add(CompositionContainerShape_0006());
                return result;
            }

            ShapeVisual ShapeVisual_0001()
            {
                var result = _c.CreateShapeVisual();
                result.Size = new Vector2(1920, 1081);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0008());
                shapes.Add(CompositionContainerShape_0011());
                shapes.Add(CompositionContainerShape_0014());
                shapes.Add(CompositionContainerShape_0017());
                shapes.Add(CompositionContainerShape_0020());
                shapes.Add(CompositionContainerShape_0023());
                shapes.Add(CompositionContainerShape_0026());
                shapes.Add(CompositionContainerShape_0029());
                shapes.Add(CompositionContainerShape_0032());
                shapes.Add(CompositionContainerShape_0035());
                shapes.Add(CompositionContainerShape_0038());
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

        }
    }
}
