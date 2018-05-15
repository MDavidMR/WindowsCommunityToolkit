using Host = Lottie;
using Microsoft.Graphics.Canvas.Geometry;
using System;
using System.Numerics;
using Windows.UI;
using Windows.UI.Composition;

namespace Compositions
{
    sealed class MyComposition : Host.ICompositionSource
    {
        public bool TryCreateInstance(
            Compositor compositor,
            out Visual rootVisual,
            out Vector2 size,
            out CompositionPropertySet progressPropertySet,
            out TimeSpan duration,
            out object diagnostics)
        {
            rootVisual = Instantiator.InstantiateComposition(compositor);
            size = new Vector2(1920, 1280);
            progressPropertySet = rootVisual.Properties;
            duration = TimeSpan.FromTicks(98670000);
            diagnostics = null;
            return true;
        }

        sealed class Instantiator
        {
            readonly Compositor _c;
            readonly ExpressionAnimation _expressionAnimation;
            ColorKeyFrameAnimation _colorKeyFrameAnimation_0000;
            CompositionColorBrush _compositionColorBrush_0001;
            ContainerVisual _containerVisual_0000;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0012;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0015;
            ExpressionAnimation _expressionAnimation_0000;
            ExpressionAnimation _expressionAnimation_0001;
            LinearEasingFunction _linearEasingFunction_0000;
            ScalarKeyFrameAnimation _scalarKeyFrameAnimation_0003;
            ScalarKeyFrameAnimation _scalarKeyFrameAnimation_0004;
            ScalarKeyFrameAnimation _scalarKeyFrameAnimation_0007;
            ScalarKeyFrameAnimation _scalarKeyFrameAnimation_0008;

            CanvasGeometry CanvasGeometry_0000()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-634.375F, -102.25F));
                    builder.AddCubicBezier(new Vector2(-657.003F, 116.795F), new Vector2(-571.97F, 240.615F), new Vector2(-374.625F, 333.719F));
                    builder.AddCubicBezier(new Vector2(-90, 468), new Vector2(180, 298), new Vector2(477.501F, -3.75F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry CanvasGeometry_0001()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-32, 2));
                    builder.AddCubicBezier(new Vector2(-32, 2), new Vector2(-2, 2), new Vector2(-2, 2));
                    builder.AddCubicBezier(new Vector2(-2, 2), new Vector2(-2, 32), new Vector2(-2, 32));
                    builder.AddCubicBezier(new Vector2(-2, 32), new Vector2(-32, 32), new Vector2(-32, 32));
                    builder.AddCubicBezier(new Vector2(-32, 32), new Vector2(-32, 2), new Vector2(-32, 2));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry CanvasGeometry_0002()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-490.75F, 69));
                    builder.AddCubicBezier(new Vector2(-490.75F, 69), new Vector2(-328.25F, 72.25F), new Vector2(-328.25F, 72.25F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry CanvasGeometry_0003()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-414.25F, 53.5F));
                    builder.AddCubicBezier(new Vector2(-414.25F, 53.5F), new Vector2(-410.5F, 120), new Vector2(-411.5F, 124.75F));
                    builder.AddCubicBezier(new Vector2(-412.5F, 129.5F), new Vector2(-435, 136), new Vector2(-448.75F, 123));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry CanvasGeometry_0004()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-453.75F, 24.5F));
                    builder.AddCubicBezier(new Vector2(-453.75F, 24.5F), new Vector2(-365.75F, 26.25F), new Vector2(-365.75F, 26.25F));
                    builder.AddCubicBezier(new Vector2(-365.75F, 26.25F), new Vector2(-412, 66.25F), new Vector2(-412, 66.25F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry CanvasGeometry_0005()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-411.75F, -49.25F));
                    builder.AddCubicBezier(new Vector2(-411.75F, -49.25F), new Vector2(-411.75F, -18.75F), new Vector2(-411.75F, -18.75F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry CanvasGeometry_0006()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-485.5F, 24));
                    builder.AddCubicBezier(new Vector2(-485.5F, 24), new Vector2(-489.5F, -7.5F), new Vector2(-484, -10));
                    builder.AddCubicBezier(new Vector2(-478.5F, -12.5F), new Vector2(-421, -14.5F), new Vector2(-409.75F, -14.25F));
                    builder.AddCubicBezier(new Vector2(-398.5F, -14), new Vector2(-337.5F, -10), new Vector2(-335.5F, -7.5F));
                    builder.AddCubicBezier(new Vector2(-333.5F, -5), new Vector2(-335, 29), new Vector2(-335, 29));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry CanvasGeometry_0007()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-350.875F, 2.563F));
                    builder.AddCubicBezier(new Vector2(-318.057F, -37.59F), new Vector2(-278, -104.5F), new Vector2(-267.5F, -218));
                    builder.AddCubicBezier(new Vector2(-254.778F, -355.522F), new Vector2(-340.099F, -462.564F), new Vector2(-497, -457));
                    builder.AddCubicBezier(new Vector2(-638, -452), new Vector2(-748, -346.5F), new Vector2(-772.5F, -205));
                    builder.AddCubicBezier(new Vector2(-795.965F, -69.48F), new Vector2(-708.855F, 66.771F), new Vector2(-596, 72.5F));
                    builder.AddCubicBezier(new Vector2(-497.5F, 77.5F), new Vector2(-475.115F, 23.436F), new Vector2(-458, -29));
                    builder.AddCubicBezier(new Vector2(-434.5F, -101), new Vector2(-476, -158), new Vector2(-539.5F, -155.5F));
                    builder.AddCubicBezier(new Vector2(-603, -153), new Vector2(-656, -77), new Vector2(-603, 0));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry CanvasGeometry_0008()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-614.25F, -28));
                    builder.AddCubicBezier(new Vector2(-614.25F, -28), new Vector2(-508.25F, -28.25F), new Vector2(-508.25F, -28.25F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry CanvasGeometry_0009()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-618.25F, -89.75F));
                    builder.AddCubicBezier(new Vector2(-618.25F, -89.75F), new Vector2(-454.75F, -90), new Vector2(-454.75F, -90));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry CanvasGeometry_0010()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-527.75F, -149.5F));
                    builder.AddCubicBezier(new Vector2(-527.75F, -149.5F), new Vector2(-493.5F, -112), new Vector2(-508, -28.75F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry CanvasGeometry_0011()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-538.75F, -152.75F));
                    builder.AddCubicBezier(new Vector2(-538.75F, -152.75F), new Vector2(-582, -128.25F), new Vector2(-565, -13));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry CanvasGeometry_0012()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-583, 105));
                    builder.AddCubicBezier(new Vector2(-583, 105), new Vector2(-529, 107), new Vector2(-529, 107));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry CanvasGeometry_0013()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-603.5F, 152));
                    builder.AddCubicBezier(new Vector2(-603.5F, 152), new Vector2(-560, 22), new Vector2(-560, 22));
                    builder.AddCubicBezier(new Vector2(-560, 22), new Vector2(-511, 152), new Vector2(-511, 152));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry CanvasGeometry_0014()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(39.255F, -2.916F));
                    builder.AddCubicBezier(new Vector2(39.255F, -2.916F), new Vector2(39.581F, -2.921F), new Vector2(39.686F, -3.084F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry CanvasGeometry_0015()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(9.343F, -41.95F));
                    builder.AddCubicBezier(new Vector2(-17.589F, 1.072F), new Vector2(-22.472F, 21.165F), new Vector2(-26.658F, 61.14F));
                    builder.AddCubicBezier(new Vector2(-33.15F, 39.317F), new Vector2(-45.95F, 28.594F), new Vector2(-54.725F, 15.439F));
                    builder.AddCubicBezier(new Vector2(-58.236F, 10.175F), new Vector2(-62.588F, 5.041F), new Vector2(-68.55F, 2.922F));
                    builder.AddCubicBezier(new Vector2(-70.214F, 2.331F), new Vector2(-72.058F, 1.996F), new Vector2(-73.737F, 2.542F));
                    builder.AddCubicBezier(new Vector2(-76.888F, 3.566F), new Vector2(-78.365F, 8.893F), new Vector2(-77.589F, 12.114F));
                    builder.AddCubicBezier(new Vector2(-76.813F, 15.335F), new Vector2(-72.957F, 17.885F), new Vector2(-70.312F, 19.88F));
                    builder.AddCubicBezier(new Vector2(-58.372F, 28.885F), new Vector2(-35.218F, 29.926F), new Vector2(-21.25F, 24.584F));
                    builder.AddCubicBezier(new Vector2(-7.282F, 19.242F), new Vector2(4.934F, 8.287F), new Vector2(15.121F, -2.662F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry CanvasGeometry_0016()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-71.97F, 61.14F));
                    builder.AddCubicBezier(new Vector2(-58.417F, 35.342F), new Vector2(-42.769F, 2.237F), new Vector2(-29.216F, -23.561F));
                    builder.AddCubicBezier(new Vector2(-25.12F, -31.358F), new Vector2(-20.902F, -40.165F), new Vector2(-23.353F, -48.625F));
                    builder.AddCubicBezier(new Vector2(-24.517F, -52.645F), new Vector2(-29.167F, -62.24F), new Vector2(-42.741F, -61.083F));
                    builder.AddCubicBezier(new Vector2(-52.357F, -60.264F), new Vector2(-56.629F, -55.143F), new Vector2(-60.709F, -50.459F));
                    builder.AddCubicBezier(new Vector2(-66.666F, -43.62F), new Vector2(-71.354F, -30.469F), new Vector2(-71.535F, -20.901F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry CanvasGeometry_0017()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-7.166F, 61.14F));
                    builder.AddCubicBezier(new Vector2(5.054F, 51.775F), new Vector2(23.12F, 25.718F), new Vector2(31.215F, 14.758F));
                    builder.AddCubicBezier(new Vector2(28.639F, 20.594F), new Vector2(24.895F, 39.322F), new Vector2(24.96F, 45.701F));
                    builder.AddCubicBezier(new Vector2(25.025F, 52.08F), new Vector2(28.56F, 59.36F), new Vector2(34.686F, 61.14F));
                    builder.AddCubicBezier(new Vector2(40.478F, 62.823F), new Vector2(46.508F, 59.217F), new Vector2(51.483F, 55.806F));
                    builder.AddCubicBezier(new Vector2(61.489F, 48.945F), new Vector2(70.405F, 40.497F), new Vector2(77.793F, 30.873F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            ColorKeyFrameAnimation ColorKeyFrameAnimation_0000()
            {
                if (_colorKeyFrameAnimation_0000 != null)
                {
                    return _colorKeyFrameAnimation_0000;
                }
                var result = _colorKeyFrameAnimation_0000 = _c.CreateColorKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(98670000);
                result.InsertKeyFrame(0, Color.FromArgb(0xFF, 0x00, 0x00, 0x00), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.08783784F, Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF), CubicBezierEasingFunction_0006());
                result.InsertKeyFrame(0.1266892F, Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2128378F, Color.FromArgb(0xFF, 0x00, 0x00, 0x00), CubicBezierEasingFunction_0007());
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0000()
            {
                return _c.CreateColorBrush(Color.FromArgb(0xFF, 0xEB, 0xEB, 0xEB));
            }

            CompositionColorBrush CompositionColorBrush_0001()
            {
                if (_compositionColorBrush_0001 != null)
                {
                    return _compositionColorBrush_0001;
                }
                var result = _compositionColorBrush_0001 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00));
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0002()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00));
                result.StartAnimation("Color", ColorKeyFrameAnimation_0000());
                var controller = result.TryGetAnimationController("Color");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0003()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00));
                result.StartAnimation("Color", ColorKeyFrameAnimation_0000());
                var controller = result.TryGetAnimationController("Color");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0004()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00));
                result.StartAnimation("Color", ColorKeyFrameAnimation_0000());
                var controller = result.TryGetAnimationController("Color");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0005()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00));
                result.StartAnimation("Color", ColorKeyFrameAnimation_0000());
                var controller = result.TryGetAnimationController("Color");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0000()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(960, 540);
                result.Offset = new Vector2(0, 100);
                result.Scale = new Vector2(1.66F, 1.66F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0000());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0001()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(960, 640);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0002());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0002()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0001());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0003()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(0.25F, 0.25F);
                result.Offset = new Vector2(1440.3F, 635.712F);
                result.Scale = new Vector2(1.7F, 1.7F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0004());
                result.StartAnimation("Scale", Vector2KeyFrameAnimation_0000());
                var controller = result.TryGetAnimationController("Scale");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0004()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0005());
                shapes.Add(CompositionContainerShape_0006());
                shapes.Add(CompositionContainerShape_0007());
                shapes.Add(CompositionContainerShape_0008());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "(_.Progress < 0.214527) ? Matrix3x2(1,0,0,1,0,0) : Matrix3x2(0,0,0,0,0,0)";
                _expressionAnimation.SetReferenceParameter("_", ContainerVisual_0000());
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0005()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(-17, -16.5F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0002());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0006()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(17.508F, -16.5F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0003());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0007()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(17.5F, 17);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0004());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0008()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0005());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0009()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(-451.433F, -25.173F);
                result.Offset = new Vector2(960, 640);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0010());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0010()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0011());
                result.StartAnimation("TransformMatrix", ExpressionAnimation_0001());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0011()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0006());
                shapes.Add(CompositionSpriteShape_0007());
                shapes.Add(CompositionSpriteShape_0008());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0012()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(-451.433F, -25.173F);
                result.Offset = new Vector2(960, 640);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0013());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0013()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0014());
                result.StartAnimation("TransformMatrix", ExpressionAnimation_0001());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0014()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0009());
                shapes.Add(CompositionSpriteShape_0010());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0015()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(-451.433F, -25.173F);
                result.Offset = new Vector2(960, 640);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0016());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0016()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0017());
                result.StartAnimation("TransformMatrix", ExpressionAnimation_0001());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0017()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0011());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0018()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(-451.433F, -25.173F);
                result.Offset = new Vector2(960, 640);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0019());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0019()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0020());
                result.StartAnimation("TransformMatrix", ExpressionAnimation_0001());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0020()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0012());
                shapes.Add(CompositionSpriteShape_0013());
                shapes.Add(CompositionSpriteShape_0014());
                shapes.Add(CompositionSpriteShape_0015());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0021()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(-451.433F, -25.173F);
                result.Offset = new Vector2(960, 640);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0022());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0022()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0023());
                result.StartAnimation("TransformMatrix", ExpressionAnimation_0001());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0023()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0016());
                shapes.Add(CompositionSpriteShape_0017());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0024()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(463, 579);
                result.Scale = new Vector2(1.92F, 1.92F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0025());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0025()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0026());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "(_.Progress < 0.4814189) ? Matrix3x2(0,0,0,0,0,0) : ((_.Progress < 0.6587838) ? Matrix3x2(1,0,0,1,0,0) : Matrix3x2(0,0,0,0,0,0))";
                _expressionAnimation.SetReferenceParameter("_", ContainerVisual_0000());
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0026()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0018());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0027()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(463, 579);
                result.Scale = new Vector2(1.92F, 1.92F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0028());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0028()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0029());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "(_.Progress < 0.2736486) ? Matrix3x2(0,0,0,0,0,0) : Matrix3x2(1,0,0,1,0,0)";
                _expressionAnimation.SetReferenceParameter("_", ContainerVisual_0000());
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0029()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0030());
                shapes.Add(CompositionContainerShape_0033());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0030()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0031());
                shapes.Add(CompositionContainerShape_0032());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0031()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0019());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0032()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0020());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0033()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0034());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0034()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0021());
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0000()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0000()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 0.99F);
                propertySet.InsertScalar("TEnd", 1);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0001());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0002());
                controller = result.TryGetAnimationController("TEnd");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Min(my.TStart,my.TEnd)";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("TrimStart", _expressionAnimation);
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Max(my.TStart,my.TEnd)";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("TrimEnd", _expressionAnimation);
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0001()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0001()));
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0002()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0002()));
                result.TrimEnd = 0;
                result.StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0003());
                var controller = result.TryGetAnimationController("TrimEnd");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0003()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0003()));
                result.TrimEnd = 0;
                result.StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0003());
                var controller = result.TryGetAnimationController("TrimEnd");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0004()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0004()));
                result.TrimEnd = 0;
                result.StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0003());
                var controller = result.TryGetAnimationController("TrimEnd");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0005()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0005()));
                result.TrimEnd = 0;
                result.StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0004());
                var controller = result.TryGetAnimationController("TrimEnd");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0006()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0006()));
                result.TrimEnd = 0;
                result.StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0004());
                var controller = result.TryGetAnimationController("TrimEnd");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0007()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0007()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 0);
                propertySet.InsertScalar("TEnd", 0);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0005());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0006());
                controller = result.TryGetAnimationController("TEnd");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Min(my.TStart,my.TEnd)";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("TrimStart", _expressionAnimation);
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Max(my.TStart,my.TEnd)";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("TrimEnd", _expressionAnimation);
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0008()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0008()));
                result.TrimEnd = 0;
                result.StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0007());
                var controller = result.TryGetAnimationController("TrimEnd");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0009()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0009()));
                result.TrimEnd = 0;
                result.StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0007());
                var controller = result.TryGetAnimationController("TrimEnd");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0010()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0010()));
                result.TrimEnd = 0;
                result.StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0007());
                var controller = result.TryGetAnimationController("TrimEnd");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0011()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0011()));
                result.TrimEnd = 0;
                result.StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0007());
                var controller = result.TryGetAnimationController("TrimEnd");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0012()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0012()));
                result.TrimEnd = 0;
                result.StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0008());
                var controller = result.TryGetAnimationController("TrimEnd");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0013()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0013()));
                result.TrimEnd = 0;
                result.StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0008());
                var controller = result.TryGetAnimationController("TrimEnd");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0014()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0014()));
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0015()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0015()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 0);
                propertySet.InsertScalar("TEnd", 0);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0010());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0011());
                controller = result.TryGetAnimationController("TEnd");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Min(my.TStart,my.TEnd)";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("TrimStart", _expressionAnimation);
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Max(my.TStart,my.TEnd)";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("TrimEnd", _expressionAnimation);
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0016()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0016()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 1);
                propertySet.InsertScalar("TEnd", 1);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0012());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0013());
                controller = result.TryGetAnimationController("TEnd");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Min(my.TStart,my.TEnd)";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("TrimStart", _expressionAnimation);
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Max(my.TStart,my.TEnd)";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("TrimEnd", _expressionAnimation);
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0017()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0017()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 0);
                propertySet.InsertScalar("TEnd", 0);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0014());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0015());
                controller = result.TryGetAnimationController("TEnd");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Min(my.TStart,my.TEnd)";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("TrimStart", _expressionAnimation);
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Max(my.TStart,my.TEnd)";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("TrimEnd", _expressionAnimation);
                return result;
            }

            CompositionRectangleGeometry CompositionRectangleGeometry_0000()
            {
                var result = _c.CreateRectangleGeometry();
                result.Size = new Vector2(1920, 1080);
                return result;
            }

            CompositionRectangleGeometry CompositionRectangleGeometry_0001()
            {
                var result = _c.CreateRectangleGeometry();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Position", new Vector2(0, 0));
                result.Size = new Vector2(30, 30);
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Vector2(my.Position.X-(my.Size.X/2),my.Position.Y-(my.Size.Y/2))";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                return result;
            }

            CompositionRectangleGeometry CompositionRectangleGeometry_0002()
            {
                var result = _c.CreateRectangleGeometry();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Position", new Vector2(0, 0));
                result.Size = new Vector2(30, 30);
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "Vector2(my.Position.X-(my.Size.X/2),my.Position.Y-(my.Size.Y/2))";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                return result;
            }

            CompositionRectangleGeometry CompositionRectangleGeometry_0003()
            {
                var result = _c.CreateRectangleGeometry();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Position", new Vector2(0, 0));
                result.Size = new Vector2(30, 30);
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
                result.Geometry = CompositionRectangleGeometry_0000();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0001()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0000();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 3155;
                result.StartAnimation("StrokeThickness", ScalarKeyFrameAnimation_0000());
                var controller = result.TryGetAnimationController("StrokeThickness");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0002()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0002();
                result.Geometry = CompositionRectangleGeometry_0001();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0003()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0003();
                result.Geometry = CompositionRectangleGeometry_0002();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0004()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0004();
                result.Geometry = CompositionRectangleGeometry_0003();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0005()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0005();
                result.Geometry = CompositionPathGeometry_0001();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0006()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0002();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 13;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0007()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0003();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 13;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0008()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0004();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 13;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0009()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0005();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 13;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0010()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0006();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 13;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0011()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0007();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 13;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0012()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0008();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 13;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0013()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0009();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 13;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0014()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0010();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 13;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0015()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0011();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 13;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0016()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0012();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 13;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0017()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0013();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 13;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0018()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0014();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 0;
                result.StartAnimation("StrokeThickness", ScalarKeyFrameAnimation_0009());
                var controller = result.TryGetAnimationController("StrokeThickness");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0019()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0015();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 6.8F;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0020()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0016();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 6.8F;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0021()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0017();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 6.8F;
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
                children.InsertAtTop(ShapeVisual_0000());
                return result;
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0000()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.192F, 0), new Vector2(0.77F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0001()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.412F, 0), new Vector2(0.692F, 0.667F));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0002()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.734F, 0), new Vector2(0.662F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0003()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0, 0), new Vector2(0, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0004()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.333F, 0), new Vector2(0.667F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0005()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(1, 0), new Vector2(1, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0006()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.207F, 0), new Vector2(0.306F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0007()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.836F, 0), new Vector2(0.829F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0008()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0, 0), new Vector2(0.365F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0009()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.389F, 0), new Vector2(0.3F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0010()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.022F, 0), new Vector2(0.104F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0011()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.451F, 0), new Vector2(0, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0012()
            {
                if (_cubicBezierEasingFunction_0012 != null)
                {
                    return _cubicBezierEasingFunction_0012;
                }
                return _cubicBezierEasingFunction_0012 = _c.CreateCubicBezierEasingFunction(new Vector2(0.195F, 0), new Vector2(0, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0013()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.333F, 0), new Vector2(0.445F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0014()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0.667F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0015()
            {
                if (_cubicBezierEasingFunction_0015 != null)
                {
                    return _cubicBezierEasingFunction_0015;
                }
                return _cubicBezierEasingFunction_0015 = _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0.833F, 0.833F));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0016()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.656F, 0.026F), new Vector2(0.819F, 0.977F));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0017()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.564F, 0.093F), new Vector2(0.572F, 0.929F));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0018()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.528F, 0.125F), new Vector2(0.346F, 0.95F));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0019()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.026F, 0.006F), new Vector2(0.544F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0020()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(1, 0), new Vector2(0.833F, 0.833F));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0021()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.382F, 0), new Vector2(0.493F, 0.881F));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0022()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.48F, 0.11F), new Vector2(0.352F, 1));
            }

            ExpressionAnimation ExpressionAnimation_0000()
            {
                if (_expressionAnimation_0000 != null)
                {
                    return _expressionAnimation_0000;
                }
                var result = _expressionAnimation_0000 = _c.CreateExpressionAnimation();
                result.SetReferenceParameter("_", ContainerVisual_0000());
                result.Expression = "_.Progress";
                return result;
            }

            ExpressionAnimation ExpressionAnimation_0001()
            {
                if (_expressionAnimation_0001 != null)
                {
                    return _expressionAnimation_0001;
                }
                var result = _expressionAnimation_0001 = _c.CreateExpressionAnimation();
                result.SetReferenceParameter("_", ContainerVisual_0000());
                result.Expression = "(_.Progress < 0.6047297) ? Matrix3x2(0,0,0,0,0,0) : Matrix3x2(1,0,0,1,0,0)";
                return result;
            }

            LinearEasingFunction LinearEasingFunction_0000()
            {
                if (_linearEasingFunction_0000 != null)
                {
                    return _linearEasingFunction_0000;
                }
                return _linearEasingFunction_0000 = _c.CreateLinearEasingFunction();
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0000()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(98670000);
                result.InsertKeyFrame(0, 3155, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.05405406F, 3155, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2432432F, 13, CubicBezierEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0001()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(98670000);
                result.InsertKeyFrame(0, 0.99F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2179054F, 0.99F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2719595F, 0, CubicBezierEasingFunction_0001());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0002()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(98670000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2297297F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2989865F, 0, CubicBezierEasingFunction_0002());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0003()
            {
                if (_scalarKeyFrameAnimation_0003 != null)
                {
                    return _scalarKeyFrameAnimation_0003;
                }
                var result = _scalarKeyFrameAnimation_0003 = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(98670000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7736486F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8581081F, 1, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0004()
            {
                if (_scalarKeyFrameAnimation_0004 != null)
                {
                    return _scalarKeyFrameAnimation_0004;
                }
                var result = _scalarKeyFrameAnimation_0004 = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(98670000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7381757F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8125F, 1, CubicBezierEasingFunction_0009());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0005()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(98670000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6689189F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7922297F, 0.837F, CubicBezierEasingFunction_0010());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0006()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(98670000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6047297F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7736486F, 1, CubicBezierEasingFunction_0011());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0007()
            {
                if (_scalarKeyFrameAnimation_0007 != null)
                {
                    return _scalarKeyFrameAnimation_0007;
                }
                var result = _scalarKeyFrameAnimation_0007 = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(98670000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6908784F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8260135F, 1, CubicBezierEasingFunction_0012());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0008()
            {
                if (_scalarKeyFrameAnimation_0008 != null)
                {
                    return _scalarKeyFrameAnimation_0008;
                }
                var result = _scalarKeyFrameAnimation_0008 = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(98670000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7128378F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.847973F, 1, CubicBezierEasingFunction_0012());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0009()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(98670000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4814189F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4932432F, 9, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.6503378F, 9, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6570946F, 0, CubicBezierEasingFunction_0014());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0010()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(98670000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6317568F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6587838F, 1, CubicBezierEasingFunction_0015());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0011()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(98670000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3266402F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3449831F, 0.33792F, CubicBezierEasingFunction_0016());
                result.InsertKeyFrame(0.3633243F, 0.59203F, CubicBezierEasingFunction_0017());
                result.InsertKeyFrame(0.4054054F, 1, CubicBezierEasingFunction_0018());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0012()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(98670000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2736486F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3266404F, 0, CubicBezierEasingFunction_0019());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0013()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(98670000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6081081F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6317568F, 0, CubicBezierEasingFunction_0020());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0014()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(98670000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6402027F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6672297F, 1, CubicBezierEasingFunction_0015());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0015()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(98670000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4054054F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4307432F, 0.35118F, CubicBezierEasingFunction_0021());
                result.InsertKeyFrame(0.4763514F, 1, CubicBezierEasingFunction_0022());
                return result;
            }

            ShapeVisual ShapeVisual_0000()
            {
                var result = _c.CreateShapeVisual();
                result.Size = new Vector2(1920, 1280);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0000());
                shapes.Add(CompositionContainerShape_0001());
                shapes.Add(CompositionContainerShape_0003());
                shapes.Add(CompositionContainerShape_0009());
                shapes.Add(CompositionContainerShape_0012());
                shapes.Add(CompositionContainerShape_0015());
                shapes.Add(CompositionContainerShape_0018());
                shapes.Add(CompositionContainerShape_0021());
                shapes.Add(CompositionContainerShape_0024());
                shapes.Add(CompositionContainerShape_0027());
                return result;
            }

            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0000()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(98670000);
                result.InsertKeyFrame(0, new Vector2(1.7F, 1.7F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.08783784F, new Vector2(2.03F, 2.03F), CubicBezierEasingFunction_0003());
                result.InsertKeyFrame(0.160473F, new Vector2(2.03F, 2.03F), CubicBezierEasingFunction_0004());
                result.InsertKeyFrame(0.2128378F, new Vector2(1.7F, 1.7F), CubicBezierEasingFunction_0005());
                return result;
            }

            Instantiator(Compositor compositor)
            {
                _c = compositor;
                _expressionAnimation = compositor.CreateExpressionAnimation();
            }

            public static Visual InstantiateComposition(Compositor compositor)
                => new Instantiator(compositor).ContainerVisual_0000();
        }
    }
}
