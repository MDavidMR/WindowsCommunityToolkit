using Host = Lottie;
using Microsoft.Graphics.Canvas.Geometry;
using System;
using System.Numerics;
using Windows.UI;
using Windows.UI.Composition;

namespace Compositions
{
    sealed class LottieLogo : Host.ICompositionSource
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
            size = new Vector2(375, 667);
            progressPropertySet = rootVisual.Properties;
            duration = TimeSpan.FromTicks(59670000);
            diagnostics = null;
            return true;
        }

        sealed class Instantiator
        {
            readonly Compositor _c;
            readonly ExpressionAnimation _expressionAnimation;
            CanvasGeometry _canvasGeometry_0000;
            CanvasGeometry _canvasGeometry_0001;
            CanvasGeometry _canvasGeometry_0002;
            CanvasGeometry _canvasGeometry_0003;
            CanvasGeometry _canvasGeometry_0004;
            CanvasGeometry _canvasGeometry_0005;
            CanvasGeometry _canvasGeometry_0006;
            CanvasGeometry _canvasGeometry_0007;
            CanvasGeometry _canvasGeometry_0008;
            CompositionColorBrush _compositionColorBrush_0001;
            CompositionColorBrush _compositionColorBrush_0002;
            CompositionEllipseGeometry _compositionEllipseGeometry_0003;
            ContainerVisual _containerVisual_0000;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0002;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0003;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0006;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0008;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0009;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0010;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0013;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0014;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0016;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0017;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0025;
            ExpressionAnimation _expressionAnimation_0000;
            ExpressionAnimation _expressionAnimation_0001;
            ExpressionAnimation _expressionAnimation_0002;
            ExpressionAnimation _expressionAnimation_0003;
            ExpressionAnimation _expressionAnimation_0004;
            ExpressionAnimation _expressionAnimation_0005;
            ExpressionAnimation _expressionAnimation_0006;
            ExpressionAnimation _expressionAnimation_0007;
            ExpressionAnimation _expressionAnimation_0008;
            LinearEasingFunction _linearEasingFunction_0000;
            ScalarKeyFrameAnimation _scalarKeyFrameAnimation_0000;
            ScalarKeyFrameAnimation _scalarKeyFrameAnimation_0010;
            ScalarKeyFrameAnimation _scalarKeyFrameAnimation_0034;
            ScalarKeyFrameAnimation _scalarKeyFrameAnimation_0035;
            ScalarKeyFrameAnimation _scalarKeyFrameAnimation_0037;
            ScalarKeyFrameAnimation _scalarKeyFrameAnimation_0044;
            ScalarKeyFrameAnimation _scalarKeyFrameAnimation_0055;
            ScalarKeyFrameAnimation _scalarKeyFrameAnimation_0060;
            StepEasingFunction _stepEasingFunction_0000;
            Vector2KeyFrameAnimation _vector2KeyFrameAnimation_0002;
            Vector2KeyFrameAnimation _vector2KeyFrameAnimation_0003;
            Vector2KeyFrameAnimation _vector2KeyFrameAnimation_0004;
            Vector2KeyFrameAnimation _vector2KeyFrameAnimation_0005;
            Vector2KeyFrameAnimation _vector2KeyFrameAnimation_0006;
            Vector2KeyFrameAnimation _vector2KeyFrameAnimation_0008;

            internal static Visual InstantiateComposition(Compositor compositor)
                => new Instantiator(compositor).ContainerVisual_0000();

            Instantiator(Compositor compositor)
            {
                _c = compositor;
                _expressionAnimation = compositor.CreateExpressionAnimation();
            }

            CanvasGeometry CanvasGeometry_0000()
            {
                if (_canvasGeometry_0000 != null)
                {
                    return _canvasGeometry_0000;
                }
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-13.664F, -0.145F));
                    builder.AddCubicBezier(new Vector2(-13.664F, -0.145F), new Vector2(75.663F, 0.29F), new Vector2(75.663F, 0.29F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return _canvasGeometry_0000 = CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0001()
            {
                if (_canvasGeometry_0001 != null)
                {
                    return _canvasGeometry_0001;
                }
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(0.859F, -21.143F));
                    builder.AddCubicBezier(new Vector2(0.859F, -21.143F), new Vector2(-4.359F, 70.392F), new Vector2(-4.359F, 70.392F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return _canvasGeometry_0001 = CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0002()
            {
                if (_canvasGeometry_0002 != null)
                {
                    return _canvasGeometry_0002;
                }
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-26.67F, -0.283F));
                    builder.AddCubicBezier(new Vector2(-26.67F, -0.283F), new Vector2(99.171F, 0.066F), new Vector2(99.171F, 0.066F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return _canvasGeometry_0002 = CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0003()
            {
                if (_canvasGeometry_0003 != null)
                {
                    return _canvasGeometry_0003;
                }
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-13.664F, -0.145F));
                    builder.AddCubicBezier(new Vector2(-13.664F, -0.145F), new Vector2(62.163F, 0.29F), new Vector2(62.163F, 0.29F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return _canvasGeometry_0003 = CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0004()
            {
                if (_canvasGeometry_0004 != null)
                {
                    return _canvasGeometry_0004;
                }
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-30.72F, 63.761F));
                    builder.AddCubicBezier(new Vector2(-30.689F, 63.167F), new Vector2(-30.789F, 50.847F), new Vector2(-30.741F, 45.192F));
                    builder.AddCubicBezier(new Vector2(-30.665F, 36.214F), new Vector2(-37.343F, 27.074F), new Vector2(-37.397F, 27.014F));
                    builder.AddCubicBezier(new Vector2(-38.558F, 25.714F), new Vector2(-39.752F, 24.147F), new Vector2(-40.698F, 22.661F));
                    builder.AddCubicBezier(new Vector2(-46.637F, 13.334F), new Vector2(-47.84F, 0.933F), new Vector2(-37.873F, -7.117F));
                    builder.AddCubicBezier(new Vector2(-13.196F, -27.046F), new Vector2(8.96F, 11.559F), new Vector2(49.506F, 11.559F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return _canvasGeometry_0004 = CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0005()
            {
                if (_canvasGeometry_0005 != null)
                {
                    return _canvasGeometry_0005;
                }
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(246.65F, 213.814F));
                    builder.AddCubicBezier(new Vector2(246.65F, 213.814F), new Vector2(340.956F, 213.628F), new Vector2(340.956F, 213.628F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return _canvasGeometry_0005 = CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0006()
            {
                if (_canvasGeometry_0006 != null)
                {
                    return _canvasGeometry_0006;
                }
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(1.681F, -29.992F));
                    builder.AddCubicBezier(new Vector2(1.681F, -29.992F), new Vector2(-1.681F, 29.992F), new Vector2(-1.681F, 29.992F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return _canvasGeometry_0006 = CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0007()
            {
                if (_canvasGeometry_0007 != null)
                {
                    return _canvasGeometry_0007;
                }
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(1.768F, -25.966F));
                    builder.AddCubicBezier(new Vector2(1.768F, -25.966F), new Vector2(-1.768F, 25.966F), new Vector2(-1.768F, 25.966F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return _canvasGeometry_0007 = CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0008()
            {
                if (_canvasGeometry_0008 != null)
                {
                    return _canvasGeometry_0008;
                }
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-8.837F, -58.229F));
                    builder.AddCubicBezier(new Vector2(-8.837F, -58.229F), new Vector2(-10.163F, 29.495F), new Vector2(-35.834F, 33.662F));
                    builder.AddCubicBezier(new Vector2(-44.058F, 34.997F), new Vector2(-50.232F, 30.05F), new Vector2(-51.688F, 23.148F));
                    builder.AddCubicBezier(new Vector2(-53.144F, 16.245F), new Vector2(-49.655F, 9.156F), new Vector2(-41.174F, 7.293F));
                    builder.AddCubicBezier(new Vector2(-17.357F, 2.06F), new Vector2(4.235F, 57.188F), new Vector2(51.797F, 44.178F));
                    builder.AddCubicBezier(new Vector2(51.957F, 44.134F), new Vector2(52.687F, 43.874F), new Vector2(53.188F, 43.741F));
                    builder.AddCubicBezier(new Vector2(53.689F, 43.608F), new Vector2(68.971F, 41.357F), new Vector2(140.394F, 43.672F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return _canvasGeometry_0008 = CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0009()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-67.125F, -112));
                    builder.AddCubicBezier(new Vector2(-67.125F, -112), new Vector2(-73.558F, -100.719F), new Vector2(-75.458F, -89.951F));
                    builder.AddCubicBezier(new Vector2(-78.625F, -72), new Vector2(-79.375F, -58.25F), new Vector2(-80.375F, -39.25F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0010()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-67.25F, -105.5F));
                    builder.AddCubicBezier(new Vector2(-67.25F, -105.5F), new Vector2(-70.433F, -94.969F), new Vector2(-72.333F, -84.201F));
                    builder.AddCubicBezier(new Vector2(-75.5F, -66.25F), new Vector2(-75.5F, -56.75F), new Vector2(-76.5F, -37.75F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0011()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(34.5F, -13.05F));
                    builder.AddCubicBezier(new Vector2(7.5F, -14.5F), new Vector2(-4, -37), new Vector2(-35.046F, -35.579F));
                    builder.AddCubicBezier(new Vector2(-61.472F, -34.369F), new Vector2(-62.25F, -5.75F), new Vector2(-62.25F, -5.75F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0012()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-3, 35.95F));
                    builder.AddCubicBezier(new Vector2(-3, 35.95F), new Vector2(-1.5F, 7.5F), new Vector2(-1.352F, -6.756F));
                    builder.AddCubicBezier(new Vector2(-9.903F, -15.019F), new Vector2(-21.57F, -20.579F), new Vector2(-32.046F, -20.579F));
                    builder.AddCubicBezier(new Vector2(-53.5F, -20.579F), new Vector2(-42.25F, 4.25F), new Vector2(-42.25F, 4.25F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0013()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(16.231F, 39.073F));
                    builder.AddCubicBezier(new Vector2(16.231F, 39.073F), new Vector2(-32.769F, 57.365F), new Vector2(-32.769F, 57.365F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0014()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(7.45F, 21.95F));
                    builder.AddCubicBezier(new Vector2(7.45F, 21.95F), new Vector2(-32.75F, 55.75F), new Vector2(-32.75F, 55.75F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0015()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-94.5F, 37.073F));
                    builder.AddCubicBezier(new Vector2(-94.5F, 37.073F), new Vector2(-48.769F, 55.365F), new Vector2(-48.769F, 55.365F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0016()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-87.5F, 20.95F));
                    builder.AddCubicBezier(new Vector2(-87.5F, 20.95F), new Vector2(-48.75F, 54.75F), new Vector2(-48.75F, 54.75F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0017()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(166.731F, -7.927F));
                    builder.AddCubicBezier(new Vector2(166.731F, -7.927F), new Vector2(136.731F, 7.115F), new Vector2(136.731F, 7.115F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0018()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(156.45F, -23.05F));
                    builder.AddCubicBezier(new Vector2(156.45F, -23.05F), new Vector2(132, 2.75F), new Vector2(132, 2.75F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0019()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(169.5F, 18.073F));
                    builder.AddCubicBezier(new Vector2(169.5F, 18.073F), new Vector2(137.481F, 11.365F), new Vector2(137.481F, 11.365F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0020()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(119.5F, -45.05F));
                    builder.AddCubicBezier(new Vector2(119.5F, -45.05F), new Vector2(82.75F, -44.75F), new Vector2(82.75F, -44.75F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0021()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(119.25F, -20.05F));
                    builder.AddCubicBezier(new Vector2(119.25F, -20.05F), new Vector2(63.5F, -20.5F), new Vector2(63.5F, -20.5F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0022()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(128, 3.65F));
                    builder.AddCubicBezier(new Vector2(128, 3.65F), new Vector2(78.25F, 3.5F), new Vector2(78.25F, 3.5F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0023()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(149.624F, 8.244F));
                    builder.AddCubicBezier(new Vector2(149.624F, 8.244F), new Vector2(136.648F, 10.156F), new Vector2(136.648F, 10.156F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0024()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(144.429F, -5.397F));
                    builder.AddCubicBezier(new Vector2(144.429F, -5.397F), new Vector2(132.275F, 4.731F), new Vector2(132.275F, 4.731F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0025()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(145.677F, 22.22F));
                    builder.AddCubicBezier(new Vector2(145.677F, 22.22F), new Vector2(134.922F, 14.749F), new Vector2(134.922F, 14.749F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0026()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(147.699F, 13.025F));
                    builder.AddCubicBezier(new Vector2(147.699F, 13.025F), new Vector2(133.195F, 13.21F), new Vector2(133.195F, 13.21F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0027()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(142.183F, -5.112F));
                    builder.AddCubicBezier(new Vector2(142.183F, -5.112F), new Vector2(130.029F, 5.016F), new Vector2(130.029F, 5.016F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0028()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(142.038F, 29.278F));
                    builder.AddCubicBezier(new Vector2(142.038F, 29.278F), new Vector2(131.282F, 21.807F), new Vector2(131.282F, 21.807F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CompositionColorBrush CompositionColorBrush_0000()
            {
                return _c.CreateColorBrush(Color.FromArgb(0xFF, 0x00, 0xD1, 0xC1));
            }

            CompositionColorBrush CompositionColorBrush_0001()
            {
                if (_compositionColorBrush_0001 != null)
                {
                    return _compositionColorBrush_0001;
                }
                var result = _compositionColorBrush_0001 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0002()
            {
                if (_compositionColorBrush_0002 != null)
                {
                    return _compositionColorBrush_0002;
                }
                var result = _compositionColorBrush_0002 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x00, 0x7A, 0x87));
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0000()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(187.5F, 333.5F);
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
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0003());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0003()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(60, 60));
                propertySet.InsertVector2("Position", new Vector2(164.782F, 57.473F));
                result.CenterPoint = new Vector2(60, 60);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0004());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0000());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0004()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(196.791F, 266.504F));
                propertySet.InsertVector2("Position", new Vector2(43.263F, 59.75F));
                result.CenterPoint = new Vector2(196.791F, 266.504F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0005());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0001());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0005()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0006());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "(_.Progress < 0.5363129) ? (Matrix3x2(0,0,0,0,0,0)) : (Matrix3x2(1,0,0,1,0,0))";
                _expressionAnimation.SetReferenceParameter("_", ContainerVisual_0000());
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0006()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(196, 267);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0001());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0007()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0008());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0008()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(345.124F, 261.801F));
                propertySet.InsertVector2("Position", new Vector2(119.167F, 57.479F));
                result.CenterPoint = new Vector2(345.124F, 261.801F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0009());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0002());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0009()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0010());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "(_.Progress < 0.4692737) ? (Matrix3x2(0,0,0,0,0,0)) : ((_.Progress < 0.5698324) ? (Matrix3x2(1,0,0,1,0,0)) : (Matrix3x2(0,0,0,0,0,0)))";
                _expressionAnimation.SetReferenceParameter("_", ContainerVisual_0000());
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0010()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(344.674F, 261.877F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0002());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0011()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0012());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0012()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(345.124F, 261.801F));
                propertySet.InsertVector2("Position", new Vector2(119.167F, 57.479F));
                result.CenterPoint = new Vector2(345.124F, 261.801F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0013());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0002());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0013()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(345.124F, 261.801F);
                result.Offset = new Vector2(0.06500244F, 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0014());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0014()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0015());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "(_.Progress < 0.5139665) ? (Matrix3x2(0,0,0,0,0,0)) : (Matrix3x2(1,0,0,1,0,0))";
                _expressionAnimation.SetReferenceParameter("_", ContainerVisual_0000());
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0015()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(344.674F, 261.877F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0003());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0016()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0017());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0017()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(303.802F, 282.182F));
                propertySet.InsertVector2("Position", new Vector2(93.594F, 62.861F));
                result.CenterPoint = new Vector2(303.802F, 282.182F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0018());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0003());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0018()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0019());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "(_.Progress < 0.4357542) ? (Matrix3x2(0,0,0,0,0,0)) : ((_.Progress < 0.5195531) ? (Matrix3x2(1,0,0,1,0,0)) : (Matrix3x2(0,0,0,0,0,0)))";
                _expressionAnimation.SetReferenceParameter("_", ContainerVisual_0000());
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0019()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(304.135F, 282.409F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0004());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0020()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0021());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0021()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(303.802F, 282.182F));
                propertySet.InsertVector2("Position", new Vector2(93.594F, 62.861F));
                result.CenterPoint = new Vector2(303.802F, 282.182F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0022());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0003());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0022()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(303.802F, 282.182F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0023());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0023()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0024());
                result.StartAnimation("TransformMatrix", ExpressionAnimation_0001());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0024()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(304.135F, 282.409F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0005());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0025()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0026());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0026()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(332.05F, 237.932F));
                propertySet.InsertVector2("Position", new Vector2(109.092F, 33.61F));
                result.CenterPoint = new Vector2(332.05F, 237.932F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0027());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0004());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0027()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0028());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "(_.Progress < 0.4636872) ? (Matrix3x2(0,0,0,0,0,0)) : ((_.Progress < 0.5363129) ? (Matrix3x2(1,0,0,1,0,0)) : (Matrix3x2(0,0,0,0,0,0)))";
                _expressionAnimation.SetReferenceParameter("_", ContainerVisual_0000());
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0028()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(331.664F, 238.14F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0006());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0029()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0030());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0030()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(332.05F, 237.932F));
                propertySet.InsertVector2("Position", new Vector2(109.092F, 33.61F));
                result.CenterPoint = new Vector2(332.05F, 237.932F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0031());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0004());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0031()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(332.05F, 237.932F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0032());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0032()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0033());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "(_.Progress < 0.4804469) ? (Matrix3x2(0,0,0,0,0,0)) : (Matrix3x2(1,0,0,1,0,0))";
                _expressionAnimation.SetReferenceParameter("_", ContainerVisual_0000());
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0033()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(331.664F, 238.14F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0007());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0034()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0035());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0035()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(344.672F, 214.842F));
                propertySet.InsertVector2("Position", new Vector2(113.715F, 9.146F));
                result.CenterPoint = new Vector2(344.672F, 214.842F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0036());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0005());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0036()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0037());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "(_.Progress < 0.4413408) ? (Matrix3x2(0,0,0,0,0,0)) : ((_.Progress < 0.5251397) ? (Matrix3x2(1,0,0,1,0,0)) : (Matrix3x2(0,0,0,0,0,0)))";
                _expressionAnimation.SetReferenceParameter("_", ContainerVisual_0000());
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0037()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(344.672F, 214.842F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0008());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0038()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0039());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0039()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(344.672F, 214.842F));
                propertySet.InsertVector2("Position", new Vector2(113.715F, 9.146F));
                result.CenterPoint = new Vector2(344.672F, 214.842F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0040());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0005());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0040()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(344.672F, 214.842F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0041());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0041()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0042());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "(_.Progress < 0.4692737) ? (Matrix3x2(0,0,0,0,0,0)) : (Matrix3x2(1,0,0,1,0,0))";
                _expressionAnimation.SetReferenceParameter("_", ContainerVisual_0000());
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0042()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(344.672F, 214.842F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0009());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0043()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0044());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0044()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(250, 250));
                propertySet.InsertVector2("Position", new Vector2(39.043F, 48.678F));
                result.CenterPoint = new Vector2(250, 250);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0045());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0006());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0045()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0046());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "(_.Progress < 0.3296089) ? (Matrix3x2(0,0,0,0,0,0)) : ((_.Progress < 0.8715084) ? (Matrix3x2(1,0,0,1,0,0)) : (Matrix3x2(0,0,0,0,0,0)))";
                _expressionAnimation.SetReferenceParameter("_", ContainerVisual_0000());
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0046()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(227.677F, 234.375F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0010());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0047()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0048());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0048()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(250, 250);
                result.Offset = new Vector2(-210.957F, -204.322F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0049());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0049()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0050());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "(_.Progress < 0.424581) ? (Matrix3x2(0,0,0,0,0,0)) : ((_.Progress < 0.5139665) ? (Matrix3x2(1,0,0,1,0,0)) : (Matrix3x2(0,0,0,0,0,0)))";
                _expressionAnimation.SetReferenceParameter("_", ContainerVisual_0000());
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0050()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0011());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0051()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0052());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0052()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(250, 250);
                result.Offset = new Vector2(-210.957F, -204.322F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0053());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0053()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0054());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "(_.Progress < 0.4022346) ? (Matrix3x2(0,0,0,0,0,0)) : ((_.Progress < 0.4972067) ? (Matrix3x2(1,0,0,1,0,0)) : (Matrix3x2(0,0,0,0,0,0)))";
                _expressionAnimation.SetReferenceParameter("_", ContainerVisual_0000());
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0054()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(277.698F, 247.258F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0012());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0055()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0056());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0056()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(250, 250);
                result.Offset = new Vector2(-210.957F, -204.322F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0057());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0057()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0058());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "(_.Progress < 0.4581006) ? (Matrix3x2(0,0,0,0,0,0)) : (Matrix3x2(1,0,0,1,0,0))";
                _expressionAnimation.SetReferenceParameter("_", ContainerVisual_0000());
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0058()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0013());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0059()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0060());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0060()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(250, 250);
                result.Offset = new Vector2(-210.957F, -204.322F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0061());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0061()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0062());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "(_.Progress < 0.3910615) ? (Matrix3x2(0,0,0,0,0,0)) : ((_.Progress < 0.8994414) ? (Matrix3x2(1,0,0,1,0,0)) : (Matrix3x2(0,0,0,0,0,0)))";
                _expressionAnimation.SetReferenceParameter("_", ContainerVisual_0000());
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0062()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(242.756F, 265.581F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0014());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0063()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0064());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0064()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(250, 250);
                result.Offset = new Vector2(-210.957F, -204.322F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0065());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0065()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0066());
                result.StartAnimation("TransformMatrix", ExpressionAnimation_0001());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0066()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(242.756F, 265.581F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0015());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0067()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0068());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0068()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(196.791F, 266.504F));
                propertySet.InsertVector2("Position", new Vector2(-62.792F, 73.057F));
                result.CenterPoint = new Vector2(196.791F, 266.504F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0069());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0007());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0069()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0070());
                result.StartAnimation("TransformMatrix", ExpressionAnimation_0002());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0070()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(196, 267);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0016());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0071()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0072());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0072()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(196.791F, 266.504F));
                propertySet.InsertVector2("Position", new Vector2(-62.792F, 73.057F));
                result.CenterPoint = new Vector2(196.791F, 266.504F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0073());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0009());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0073()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0074());
                result.StartAnimation("TransformMatrix", ExpressionAnimation_0002());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0074()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(196, 267);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0017());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0075()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0076());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0076()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(250, 250));
                propertySet.InsertVector2("Position", new Vector2(39.043F, 48.678F));
                result.CenterPoint = new Vector2(250, 250);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0077());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0006());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0077()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0078());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "(_.Progress < 0.3296089) ? (Matrix3x2(0,0,0,0,0,0)) : (Matrix3x2(1,0,0,1,0,0))";
                _expressionAnimation.SetReferenceParameter("_", ContainerVisual_0000());
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0078()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(227.677F, 234.375F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0018());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0079()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0080());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0080()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(250, 250);
                result.Offset = new Vector2(-210.957F, -204.322F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0081());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0081()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0082());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "(_.Progress < 0.4189944) ? (Matrix3x2(0,0,0,0,0,0)) : (Matrix3x2(1,0,0,1,0,0))";
                _expressionAnimation.SetReferenceParameter("_", ContainerVisual_0000());
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0082()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(277.698F, 247.258F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0019());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0083()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0084());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0084()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(250, 250));
                propertySet.InsertVector2("Position", new Vector2(39.043F, 48.678F));
                result.CenterPoint = new Vector2(250, 250);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0085());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0006());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0085()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(250, 250);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0086());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0086()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0087());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "(_.Progress < 0.3910615) ? (Matrix3x2(0,0,0,0,0,0)) : (Matrix3x2(1,0,0,1,0,0))";
                _expressionAnimation.SetReferenceParameter("_", ContainerVisual_0000());
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0087()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(227.677F, 234.375F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0020());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0088()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0089());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0089()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(60, 60));
                propertySet.InsertVector2("Position", new Vector2(-33.667F, 8.182F));
                result.CenterPoint = new Vector2(60, 60);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0090());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0010());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0090()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(196.791F, 266.504F));
                propertySet.InsertVector2("Position", new Vector2(39.875F, 60));
                result.CenterPoint = new Vector2(196.791F, 266.504F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0091());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0011());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0091()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0092());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "(_.Progress < 0.1564246) ? (Matrix3x2(0,0,0,0,0,0)) : ((_.Progress < 0.301676) ? (Matrix3x2(1,0,0,1,0,0)) : (Matrix3x2(0,0,0,0,0,0)))";
                _expressionAnimation.SetReferenceParameter("_", ContainerVisual_0000());
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0092()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(196, 267);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0021());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0093()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0094());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0094()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(250, 250);
                result.Offset = new Vector2(-210.957F, -204.322F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0095());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0095()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0096());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "(_.Progress < 0.08938547) ? (Matrix3x2(0,0,0,0,0,0)) : (Matrix3x2(1,0,0,1,0,0))";
                _expressionAnimation.SetReferenceParameter("_", ContainerVisual_0000());
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0096()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(166.029F, 270.643F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0022());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0097()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0098());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0098()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(250, 250);
                result.Offset = new Vector2(-210.957F, -204.322F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0099());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0099()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0100());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "(_.Progress < 0.1005587) ? (Matrix3x2(0,0,0,0,0,0)) : (Matrix3x2(1,0,0,1,0,0))";
                _expressionAnimation.SetReferenceParameter("_", ContainerVisual_0000());
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0100()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(166.029F, 270.643F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0023());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0101()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0102());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0102()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(196.791F, 266.504F));
                propertySet.InsertVector2("Position", new Vector2(295.771F, 108.994F));
                result.CenterPoint = new Vector2(196.791F, 266.504F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0103());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0012());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "(_.Progress * 0.9835165) + 0.01648352";
                _expressionAnimation.SetReferenceParameter("_", ContainerVisual_0000());
                controller.StartAnimation("Progress", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0103()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0104());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "(_.Progress < 0.09497207) ? (Matrix3x2(1,0,0,1,0,0)) : (Matrix3x2(0,0,0,0,0,0))";
                _expressionAnimation.SetReferenceParameter("_", ContainerVisual_0000());
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0104()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(196, 267);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0024());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0105()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0106());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0106()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(25.043F, 45.678F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0107());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0107()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0108());
                result.StartAnimation("TransformMatrix", ExpressionAnimation_0003());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0108()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0025());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0109()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0110());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0110()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(25.043F, 45.678F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0111());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0111()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0112());
                result.StartAnimation("TransformMatrix", ExpressionAnimation_0003());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0112()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0026());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0113()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0114());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0114()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(25.043F, 45.678F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0115());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0115()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0116());
                result.StartAnimation("TransformMatrix", ExpressionAnimation_0004());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0116()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0027());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0117()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0118());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0118()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(25.043F, 45.678F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0119());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0119()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0120());
                result.StartAnimation("TransformMatrix", ExpressionAnimation_0004());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0120()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0028());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0121()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0122());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0122()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(25.043F, 45.678F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0123());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0123()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0124());
                result.StartAnimation("TransformMatrix", ExpressionAnimation_0005());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0124()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0029());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0125()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0126());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0126()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(25.043F, 45.678F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0127());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0127()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0128());
                result.StartAnimation("TransformMatrix", ExpressionAnimation_0005());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0128()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0030());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0129()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0130());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0130()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(25.043F, 45.678F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0131());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0131()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0132());
                result.StartAnimation("TransformMatrix", ExpressionAnimation_0005());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0132()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0031());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0133()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0134());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0134()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(25.043F, 45.678F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0135());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0135()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0136());
                result.StartAnimation("TransformMatrix", ExpressionAnimation_0005());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0136()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0032());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0137()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0138());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0138()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(25.043F, 45.678F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0139());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0139()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0140());
                result.StartAnimation("TransformMatrix", ExpressionAnimation_0006());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0140()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0033());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0141()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0142());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0142()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(25.043F, 45.678F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0143());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0143()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0144());
                result.StartAnimation("TransformMatrix", ExpressionAnimation_0006());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0144()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0034());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0145()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0146());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0146()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(25.043F, 45.678F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0147());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0147()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0148());
                result.StartAnimation("TransformMatrix", ExpressionAnimation_0006());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0148()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0035());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0149()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0150());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0150()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(25.043F, 45.678F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0151());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0151()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0152());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "(_.Progress < 0.4469274) ? (Matrix3x2(0,0,0,0,0,0)) : ((_.Progress < 0.5027933) ? (Matrix3x2(1,0,0,1,0,0)) : (Matrix3x2(0,0,0,0,0,0)))";
                _expressionAnimation.SetReferenceParameter("_", ContainerVisual_0000());
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0152()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0036());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0153()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0154());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0154()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(25.043F, 45.678F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0155());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0155()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0156());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "(_.Progress < 0.4692737) ? (Matrix3x2(0,0,0,0,0,0)) : ((_.Progress < 0.5251397) ? (Matrix3x2(1,0,0,1,0,0)) : (Matrix3x2(0,0,0,0,0,0)))";
                _expressionAnimation.SetReferenceParameter("_", ContainerVisual_0000());
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0156()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0037());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0157()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0158());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0158()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(25.043F, 45.678F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0159());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0159()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0160());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "(_.Progress < 0.4748603) ? (Matrix3x2(0,0,0,0,0,0)) : ((_.Progress < 0.5307263) ? (Matrix3x2(1,0,0,1,0,0)) : (Matrix3x2(0,0,0,0,0,0)))";
                _expressionAnimation.SetReferenceParameter("_", ContainerVisual_0000());
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0160()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0038());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0161()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0162());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0162()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(58.205F, -39.394F);
                result.RotationAngleInDegrees = 97.9F;
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0163());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0163()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0164());
                result.StartAnimation("TransformMatrix", ExpressionAnimation_0007());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0164()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0039());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0165()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0166());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0166()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(58.205F, -39.394F);
                result.RotationAngleInDegrees = 97.9F;
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0167());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0167()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0168());
                result.StartAnimation("TransformMatrix", ExpressionAnimation_0007());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0168()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0040());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0169()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0170());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0170()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(58.205F, -39.394F);
                result.RotationAngleInDegrees = 97.9F;
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0171());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0171()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0172());
                result.StartAnimation("TransformMatrix", ExpressionAnimation_0007());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0172()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0041());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0173()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0174());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0174()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(53.205F, 131.606F);
                result.RotationAngleInDegrees = -89.1F;
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0175());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0175()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0176());
                result.StartAnimation("TransformMatrix", ExpressionAnimation_0008());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0176()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0042());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0177()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0178());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0178()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(53.205F, 131.606F);
                result.RotationAngleInDegrees = -89.1F;
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0179());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0179()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0180());
                result.StartAnimation("TransformMatrix", ExpressionAnimation_0008());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0180()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0043());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0181()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(60, 60);
                result.Offset = new Vector2(154.457F, 287.822F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0182());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0182()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(53.205F, 131.606F);
                result.RotationAngleInDegrees = -89.1F;
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0183());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0183()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0184());
                result.StartAnimation("TransformMatrix", ExpressionAnimation_0008());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0184()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0044());
                return result;
            }

            CompositionEllipseGeometry CompositionEllipseGeometry_0000()
            {
                var result = _c.CreateEllipseGeometry();
                result.Center = new Vector2(0.8F, -0.5F);
                result.Radius = new Vector2(4.6F, 4.6F);
                return result;
            }

            CompositionEllipseGeometry CompositionEllipseGeometry_0001()
            {
                var result = _c.CreateEllipseGeometry();
                result.Center = new Vector2(0.8F, -0.5F);
                result.Radius = new Vector2(1.5F, 1.5F);
                result.StartAnimation("Radius", Vector2KeyFrameAnimation_0008());
                var controller = result.TryGetAnimationController("Radius");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionEllipseGeometry CompositionEllipseGeometry_0002()
            {
                var result = _c.CreateEllipseGeometry();
                result.Center = new Vector2(0.8F, -0.5F);
                result.Radius = new Vector2(1.5F, 1.5F);
                result.StartAnimation("Radius", Vector2KeyFrameAnimation_0008());
                var controller = result.TryGetAnimationController("Radius");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TrimStart", ScalarKeyFrameAnimation_0020());
                controller = result.TryGetAnimationController("TrimStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0021());
                controller = result.TryGetAnimationController("TrimEnd");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionEllipseGeometry CompositionEllipseGeometry_0003()
            {
                if (_compositionEllipseGeometry_0003 != null)
                {
                    return _compositionEllipseGeometry_0003;
                }
                var result = _compositionEllipseGeometry_0003 = _c.CreateEllipseGeometry();
                result.Center = new Vector2(0.8F, -0.5F);
                result.Radius = new Vector2(4.7F, 4.7F);
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0000()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0000()));
                result.TrimEnd = 0;
                result.StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0002());
                var controller = result.TryGetAnimationController("TrimEnd");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0001()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0000()));
                result.TrimEnd = 0;
                result.StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0003());
                var controller = result.TryGetAnimationController("TrimEnd");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0002()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0001()));
                result.TrimEnd = 0;
                result.StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0004());
                var controller = result.TryGetAnimationController("TrimEnd");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0003()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0001()));
                result.TrimEnd = 0;
                result.StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0005());
                var controller = result.TryGetAnimationController("TrimEnd");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0004()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0002()));
                result.TrimEnd = 0;
                result.StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0006());
                var controller = result.TryGetAnimationController("TrimEnd");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0005()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0002()));
                result.TrimEnd = 0;
                result.StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0007());
                var controller = result.TryGetAnimationController("TrimEnd");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0006()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0003()));
                result.TrimEnd = 0;
                result.StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0008());
                var controller = result.TryGetAnimationController("TrimEnd");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0007()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0003()));
                result.TrimEnd = 0;
                result.StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0009());
                var controller = result.TryGetAnimationController("TrimEnd");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0008()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0004()));
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

            CompositionPathGeometry CompositionPathGeometry_0009()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0005()));
                result.TrimEnd = 0.411F;
                result.TrimStart = 0.29F;
                result.StartAnimation("TrimStart", ScalarKeyFrameAnimation_0012());
                var controller = result.TryGetAnimationController("TrimStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0013());
                controller = result.TryGetAnimationController("TrimEnd");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0010()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0006()));
                result.TrimEnd = 0.5F;
                result.TrimStart = 0.5F;
                result.StartAnimation("TrimStart", ScalarKeyFrameAnimation_0014());
                var controller = result.TryGetAnimationController("TrimStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0015());
                controller = result.TryGetAnimationController("TrimEnd");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0011()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0005()));
                result.TrimEnd = 0.411F;
                result.TrimStart = 0.29F;
                result.StartAnimation("TrimStart", ScalarKeyFrameAnimation_0016());
                var controller = result.TryGetAnimationController("TrimStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0017());
                controller = result.TryGetAnimationController("TrimEnd");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0012()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0007()));
                result.TrimEnd = 0.117F;
                result.StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0018());
                var controller = result.TryGetAnimationController("TrimEnd");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0013()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0007()));
                result.TrimEnd = 0.117F;
                result.StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0019());
                var controller = result.TryGetAnimationController("TrimEnd");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0014()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0004()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 0);
                propertySet.InsertScalar("TEnd", 0);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0010());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0022());
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

            CompositionPathGeometry CompositionPathGeometry_0015()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0006()));
                result.TrimEnd = 0.5F;
                result.TrimStart = 0.5F;
                result.StartAnimation("TrimStart", ScalarKeyFrameAnimation_0023());
                var controller = result.TryGetAnimationController("TrimStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0024());
                controller = result.TryGetAnimationController("TrimEnd");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0016()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0004()));
                result.TrimEnd = 0.249F;
                result.TrimStart = 0.249F;
                result.StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0025());
                var controller = result.TryGetAnimationController("TrimEnd");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0017()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0008()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 0.8F);
                propertySet.InsertScalar("TEnd", 0.81F);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0026());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0027());
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

            CompositionPathGeometry CompositionPathGeometry_0018()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0008()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 0.8F);
                propertySet.InsertScalar("TEnd", 0.81F);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0028());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0029());
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

            CompositionPathGeometry CompositionPathGeometry_0019()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0009()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 0.87F);
                propertySet.InsertScalar("TEnd", 1);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0030());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0031());
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

            CompositionPathGeometry CompositionPathGeometry_0020()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0010()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 0.87F);
                propertySet.InsertScalar("TEnd", 1);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0032());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0033());
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

            CompositionPathGeometry CompositionPathGeometry_0021()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0011()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 0.87F);
                propertySet.InsertScalar("TEnd", 1);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0034());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0035());
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

            CompositionPathGeometry CompositionPathGeometry_0022()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0012()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 0.87F);
                propertySet.InsertScalar("TEnd", 1);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0034());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0035());
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

            CompositionPathGeometry CompositionPathGeometry_0023()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0013()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 0.87F);
                propertySet.InsertScalar("TEnd", 1);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0036());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0037());
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

            CompositionPathGeometry CompositionPathGeometry_0024()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0014()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 0.87F);
                propertySet.InsertScalar("TEnd", 1);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0038());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0037());
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

            CompositionPathGeometry CompositionPathGeometry_0025()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0015()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 0.87F);
                propertySet.InsertScalar("TEnd", 1);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0039());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0040());
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

            CompositionPathGeometry CompositionPathGeometry_0026()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0016()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 0.87F);
                propertySet.InsertScalar("TEnd", 1);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0041());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0042());
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

            CompositionPathGeometry CompositionPathGeometry_0027()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0017()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 0.87F);
                propertySet.InsertScalar("TEnd", 1);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0043());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0044());
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

            CompositionPathGeometry CompositionPathGeometry_0028()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0018()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 0.87F);
                propertySet.InsertScalar("TEnd", 1);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0045());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0044());
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

            CompositionPathGeometry CompositionPathGeometry_0029()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0019()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 0.87F);
                propertySet.InsertScalar("TEnd", 1);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0046());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0047());
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

            CompositionPathGeometry CompositionPathGeometry_0030()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0020()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 0.87F);
                propertySet.InsertScalar("TEnd", 1);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0048());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0049());
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

            CompositionPathGeometry CompositionPathGeometry_0031()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0021()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 0.87F);
                propertySet.InsertScalar("TEnd", 1);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0050());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0051());
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

            CompositionPathGeometry CompositionPathGeometry_0032()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0022()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 0.87F);
                propertySet.InsertScalar("TEnd", 1);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0052());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0053());
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

            CompositionPathGeometry CompositionPathGeometry_0033()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0023()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 0.87F);
                propertySet.InsertScalar("TEnd", 1);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0054());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0055());
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

            CompositionPathGeometry CompositionPathGeometry_0034()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0024()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 0.87F);
                propertySet.InsertScalar("TEnd", 1);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0056());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0055());
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

            CompositionPathGeometry CompositionPathGeometry_0035()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0025()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 0.87F);
                propertySet.InsertScalar("TEnd", 1);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0057());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0058());
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

            CompositionPathGeometry CompositionPathGeometry_0036()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0026()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 0.87F);
                propertySet.InsertScalar("TEnd", 1);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0059());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0060());
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

            CompositionPathGeometry CompositionPathGeometry_0037()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0027()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 0.87F);
                propertySet.InsertScalar("TEnd", 1);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0061());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0060());
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

            CompositionPathGeometry CompositionPathGeometry_0038()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0028()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 0.87F);
                propertySet.InsertScalar("TEnd", 1);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0062());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0063());
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
                var propertySet = result.Properties;
                propertySet.InsertVector2("Position", new Vector2(0, 0));
                result.Size = new Vector2(375, 667);
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
                result.FillBrush = CompositionColorBrush_0001();
                result.Geometry = CompositionEllipseGeometry_0000();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0002()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0000();
                result.StrokeBrush = CompositionColorBrush_0002();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 10;
                result.StrokeThickness = 9.562F;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0003()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0001();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 10;
                result.StrokeThickness = 9.562F;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0004()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0002();
                result.StrokeBrush = CompositionColorBrush_0002();
                result.StrokeDashCap = CompositionStrokeCap.Square;
                result.StrokeEndCap = CompositionStrokeCap.Square;
                result.StrokeStartCap = CompositionStrokeCap.Square;
                result.StrokeMiterLimit = 10;
                result.StrokeThickness = 8.4F;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0005()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0003();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Square;
                result.StrokeEndCap = CompositionStrokeCap.Square;
                result.StrokeStartCap = CompositionStrokeCap.Square;
                result.StrokeMiterLimit = 10;
                result.StrokeThickness = 9.194F;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0006()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0004();
                result.StrokeBrush = CompositionColorBrush_0002();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 10;
                result.StrokeThickness = 8.4F;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0007()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0005();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 10;
                result.StrokeThickness = 9.562F;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0008()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0006();
                result.StrokeBrush = CompositionColorBrush_0002();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 10;
                result.StrokeThickness = 8.4F;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0009()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0007();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 10;
                result.StrokeThickness = 9.562F;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0010()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0008();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 10;
                result.StrokeThickness = 8.4F;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0011()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0009();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 10;
                result.StrokeThickness = 9.194F;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0012()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0010();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Square;
                result.StrokeEndCap = CompositionStrokeCap.Square;
                result.StrokeStartCap = CompositionStrokeCap.Square;
                result.StrokeMiterLimit = 10;
                result.StrokeThickness = 9.194F;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0013()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0011();
                result.StrokeBrush = CompositionColorBrush_0002();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 10;
                result.StrokeThickness = 9.194F;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0014()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0012();
                result.StrokeBrush = CompositionColorBrush_0002();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 8.4F;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0015()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0013();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 9.194F;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0016()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionEllipseGeometry_0001();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 8.8F;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0017()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionEllipseGeometry_0002();
                result.StrokeBrush = CompositionColorBrush_0002();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 9.194F;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0018()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0014();
                result.StrokeBrush = CompositionColorBrush_0002();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 10;
                result.StrokeThickness = 8.4F;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0019()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0015();
                result.StrokeBrush = CompositionColorBrush_0002();
                result.StrokeDashCap = CompositionStrokeCap.Square;
                result.StrokeEndCap = CompositionStrokeCap.Square;
                result.StrokeStartCap = CompositionStrokeCap.Square;
                result.StrokeMiterLimit = 10;
                result.StrokeThickness = 9.194F;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0020()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0016();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 10;
                result.StrokeThickness = 9.194F;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0021()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0001();
                result.Geometry = CompositionEllipseGeometry_0003();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0022()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0017();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 10;
                result.StrokeThickness = 8.4F;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0023()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0018();
                result.StrokeBrush = CompositionColorBrush_0002();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 10;
                result.StrokeThickness = 9.194F;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0024()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0001();
                result.Geometry = CompositionEllipseGeometry_0003();
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0025()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0019();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 1.5F;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0026()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0020();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 1.5F;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0027()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0021();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 1.5F;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0028()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0022();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 1.5F;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0029()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0023();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 2;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0030()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0024();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 2;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0031()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0025();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 2;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0032()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0026();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 2;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0033()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0027();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 2;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0034()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0028();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 2;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0035()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0029();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 2;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0036()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0030();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 1.5F;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0037()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0031();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 1.5F;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0038()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0032();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 1.5F;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0039()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0033();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 2;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0040()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0034();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 2;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0041()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0035();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 2;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0042()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0036();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 2;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0043()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0037();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 2;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0044()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0038();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
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
                propertySet.InsertScalar("t0", 0);
                propertySet.InsertScalar("t1", 0);
                propertySet.InsertScalar("t2", 0);
                var children = result.Children;
                children.InsertAtTop(ShapeVisual_0000());
                result.StartAnimation("t0", ScalarKeyFrameAnimation_0000());
                var controller = result.TryGetAnimationController("t0");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("t1", ScalarKeyFrameAnimation_0000());
                controller = result.TryGetAnimationController("t1");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("t2", ScalarKeyFrameAnimation_0001());
                controller = result.TryGetAnimationController("t2");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0000()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.198F), new Vector2(0.638F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0001()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.523F, 0), new Vector2(0.795F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0002()
            {
                if (_cubicBezierEasingFunction_0002 != null)
                {
                    return _cubicBezierEasingFunction_0002;
                }
                return _cubicBezierEasingFunction_0002 = _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0.18F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0003()
            {
                if (_cubicBezierEasingFunction_0003 != null)
                {
                    return _cubicBezierEasingFunction_0003;
                }
                return _cubicBezierEasingFunction_0003 = _c.CreateCubicBezierEasingFunction(new Vector2(0.82F, 0), new Vector2(0.833F, 0.833F));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0004()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0, 0), new Vector2(0, 0.812F));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0005()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.39F, 0.707F), new Vector2(0.708F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0006()
            {
                if (_cubicBezierEasingFunction_0006 != null)
                {
                    return _cubicBezierEasingFunction_0006;
                }
                return _cubicBezierEasingFunction_0006 = _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0.667F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0007()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0), new Vector2(0.667F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0008()
            {
                if (_cubicBezierEasingFunction_0008 != null)
                {
                    return _cubicBezierEasingFunction_0008;
                }
                return _cubicBezierEasingFunction_0008 = _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0.833F, 0.833F));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0009()
            {
                if (_cubicBezierEasingFunction_0009 != null)
                {
                    return _cubicBezierEasingFunction_0009;
                }
                return _cubicBezierEasingFunction_0009 = _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0.12F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0010()
            {
                if (_cubicBezierEasingFunction_0010 != null)
                {
                    return _cubicBezierEasingFunction_0010;
                }
                return _cubicBezierEasingFunction_0010 = _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0), new Vector2(0.12F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0011()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0.12F, 0.12F));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0012()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.301F, 0), new Vector2(0.833F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0013()
            {
                if (_cubicBezierEasingFunction_0013 != null)
                {
                    return _cubicBezierEasingFunction_0013;
                }
                return _cubicBezierEasingFunction_0013 = _c.CreateCubicBezierEasingFunction(new Vector2(0.301F, 0), new Vector2(0.667F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0014()
            {
                if (_cubicBezierEasingFunction_0014 != null)
                {
                    return _cubicBezierEasingFunction_0014;
                }
                return _cubicBezierEasingFunction_0014 = _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0.06F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0015()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0.21F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0016()
            {
                if (_cubicBezierEasingFunction_0016 != null)
                {
                    return _cubicBezierEasingFunction_0016;
                }
                return _cubicBezierEasingFunction_0016 = _c.CreateCubicBezierEasingFunction(new Vector2(0.18F, 0), new Vector2(0.348F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0017()
            {
                if (_cubicBezierEasingFunction_0017 != null)
                {
                    return _cubicBezierEasingFunction_0017;
                }
                return _cubicBezierEasingFunction_0017 = _c.CreateCubicBezierEasingFunction(new Vector2(0.693F, 0), new Vector2(0.27F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0018()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.333F, 0), new Vector2(0.667F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0019()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 1), new Vector2(0.432F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0020()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0.673F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0021()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0.26F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0022()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.74F, 0), new Vector2(0.833F, 0.833F));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0023()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0.703F, 0.857F));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0024()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.333F, 0.202F), new Vector2(0.938F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0025()
            {
                if (_cubicBezierEasingFunction_0025 != null)
                {
                    return _cubicBezierEasingFunction_0025;
                }
                return _cubicBezierEasingFunction_0025 = _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0.337F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0026()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0.703F, 0.821F));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0027()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.037F, 0.168F), new Vector2(0.263F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0028()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.823F, 0), new Vector2(0.833F, 0.833F));
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
                result.Expression = "(_.Progress < 0.452514) ? (Matrix3x2(0,0,0,0,0,0)) : (Matrix3x2(1,0,0,1,0,0))";
                return result;
            }

            ExpressionAnimation ExpressionAnimation_0002()
            {
                if (_expressionAnimation_0002 != null)
                {
                    return _expressionAnimation_0002;
                }
                var result = _expressionAnimation_0002 = _c.CreateExpressionAnimation();
                result.SetReferenceParameter("_", ContainerVisual_0000());
                result.Expression = "(_.Progress < 0.301676) ? (Matrix3x2(0,0,0,0,0,0)) : (Matrix3x2(1,0,0,1,0,0))";
                return result;
            }

            ExpressionAnimation ExpressionAnimation_0003()
            {
                if (_expressionAnimation_0003 != null)
                {
                    return _expressionAnimation_0003;
                }
                var result = _expressionAnimation_0003 = _c.CreateExpressionAnimation();
                result.SetReferenceParameter("_", ContainerVisual_0000());
                result.Expression = "(_.Progress < 0.1675978) ? (Matrix3x2(0,0,0,0,0,0)) : ((_.Progress < 0.2067039) ? (Matrix3x2(1,0,0,1,0,0)) : (Matrix3x2(0,0,0,0,0,0)))";
                return result;
            }

            ExpressionAnimation ExpressionAnimation_0004()
            {
                if (_expressionAnimation_0004 != null)
                {
                    return _expressionAnimation_0004;
                }
                var result = _expressionAnimation_0004 = _c.CreateExpressionAnimation();
                result.SetReferenceParameter("_", ContainerVisual_0000());
                result.Expression = "(_.Progress < 0.3631285) ? (Matrix3x2(0,0,0,0,0,0)) : ((_.Progress < 0.4189944) ? (Matrix3x2(1,0,0,1,0,0)) : (Matrix3x2(0,0,0,0,0,0)))";
                return result;
            }

            ExpressionAnimation ExpressionAnimation_0005()
            {
                if (_expressionAnimation_0005 != null)
                {
                    return _expressionAnimation_0005;
                }
                var result = _expressionAnimation_0005 = _c.CreateExpressionAnimation();
                result.SetReferenceParameter("_", ContainerVisual_0000());
                result.Expression = "(_.Progress < 0.301676) ? (Matrix3x2(0,0,0,0,0,0)) : ((_.Progress < 0.3575419) ? (Matrix3x2(1,0,0,1,0,0)) : (Matrix3x2(0,0,0,0,0,0)))";
                return result;
            }

            ExpressionAnimation ExpressionAnimation_0006()
            {
                if (_expressionAnimation_0006 != null)
                {
                    return _expressionAnimation_0006;
                }
                var result = _expressionAnimation_0006 = _c.CreateExpressionAnimation();
                result.SetReferenceParameter("_", ContainerVisual_0000());
                result.Expression = "(_.Progress < 0.5418994) ? (Matrix3x2(0,0,0,0,0,0)) : ((_.Progress < 0.5977654) ? (Matrix3x2(1,0,0,1,0,0)) : (Matrix3x2(0,0,0,0,0,0)))";
                return result;
            }

            ExpressionAnimation ExpressionAnimation_0007()
            {
                if (_expressionAnimation_0007 != null)
                {
                    return _expressionAnimation_0007;
                }
                var result = _expressionAnimation_0007 = _c.CreateExpressionAnimation();
                result.SetReferenceParameter("_", ContainerVisual_0000());
                result.Expression = "(_.Progress < 0.4189944) ? (Matrix3x2(0,0,0,0,0,0)) : ((_.Progress < 0.4636872) ? (Matrix3x2(1,0,0,1,0,0)) : (Matrix3x2(0,0,0,0,0,0)))";
                return result;
            }

            ExpressionAnimation ExpressionAnimation_0008()
            {
                if (_expressionAnimation_0008 != null)
                {
                    return _expressionAnimation_0008;
                }
                var result = _expressionAnimation_0008 = _c.CreateExpressionAnimation();
                result.SetReferenceParameter("_", ContainerVisual_0000());
                result.Expression = "(_.Progress < 0.424581) ? (Matrix3x2(0,0,0,0,0,0)) : ((_.Progress < 0.4692737) ? (Matrix3x2(1,0,0,1,0,0)) : (Matrix3x2(0,0,0,0,0,0)))";
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
                if (_scalarKeyFrameAnimation_0000 != null)
                {
                    return _scalarKeyFrameAnimation_0000;
                }
                var result = _scalarKeyFrameAnimation_0000 = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0.1969666F, 0, StepEasingFunction_0000());
                result.InsertKeyFrame(0.24581F, 1, CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.2458101F, 0, StepEasingFunction_0000());
                result.InsertKeyFrame(0.3016759F, 1, CubicBezierEasingFunction_0001());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0001()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0002()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4692737F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5139665F, 0.316F, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0003()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5139665F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5418994F, 0.316F, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0004()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4357542F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4916201F, 0.457F, CubicBezierEasingFunction_0009());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0005()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.452514F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5083799F, 0.457F, CubicBezierEasingFunction_0009());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0006()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4636872F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5139665F, 0.43F, CubicBezierEasingFunction_0009());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0007()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4804469F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5307263F, 0.43F, CubicBezierEasingFunction_0009());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0008()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4413408F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4916201F, 0.375F, CubicBezierEasingFunction_0009());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0009()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4692737F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5195531F, 0.375F, CubicBezierEasingFunction_0009());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0010()
            {
                if (_scalarKeyFrameAnimation_0010 != null)
                {
                    return _scalarKeyFrameAnimation_0010;
                }
                var result = _scalarKeyFrameAnimation_0010 = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.301676F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3910615F, 0.249F, CubicBezierEasingFunction_0012());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0011()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.301676F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4134078F, 1, CubicBezierEasingFunction_0013());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0012()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.29F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.424581F, 0.29F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4748603F, 0, CubicBezierEasingFunction_0009());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0013()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.411F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.424581F, 0.411F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4748603F, 0.665F, CubicBezierEasingFunction_0009());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0014()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.5F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4022346F, 0.5F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4581006F, 0, CubicBezierEasingFunction_0014());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0015()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.5F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4022346F, 0.5F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4581006F, 1, CubicBezierEasingFunction_0014());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0016()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.29F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4581006F, 0.29F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5083799F, 0, CubicBezierEasingFunction_0009());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0017()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.411F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4581006F, 0.411F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5083799F, 0.665F, CubicBezierEasingFunction_0009());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0018()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.117F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3910615F, 0.117F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4189944F, 1, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0019()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.117F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.452514F, 0.117F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4916201F, 1, CubicBezierEasingFunction_0015());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0020()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.301676F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3519553F, 0.3F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.5083799F, 0.399F, CubicBezierEasingFunction_0019());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0021()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.301676F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3519553F, 0.88F, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0022()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.301676F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4357542F, 1, CubicBezierEasingFunction_0013());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0023()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.5F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4189944F, 0.5F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4748603F, 0, CubicBezierEasingFunction_0014());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0024()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.5F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4189944F, 0.5F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4748603F, 1, CubicBezierEasingFunction_0014());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0025()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.249F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3910615F, 0.249F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4692737F, 0.891F, CubicBezierEasingFunction_0020());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0026()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.8F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.08938547F, 0.8F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1117318F, 0.5F, CubicBezierEasingFunction_0023());
                result.InsertKeyFrame(0.1564246F, 0, CubicBezierEasingFunction_0024());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0027()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.81F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.08938547F, 0.81F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.150838F, 0.734F, CubicBezierEasingFunction_0025());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0028()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.8F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1005587F, 0.8F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1284916F, 0.5F, CubicBezierEasingFunction_0026());
                result.InsertKeyFrame(0.3072626F, 0.3F, CubicBezierEasingFunction_0027());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0029()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.81F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1005587F, 0.81F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1620112F, 0.734F, CubicBezierEasingFunction_0025());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0030()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1620112F, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1843575F, 0.37533F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.2011173F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0031()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1620112F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1843575F, 0.66356F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.2011173F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0032()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1620112F, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1843575F, 0.25333F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.2011173F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0033()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1620112F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1843575F, 0.69056F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.2011173F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0034()
            {
                if (_scalarKeyFrameAnimation_0034 != null)
                {
                    return _scalarKeyFrameAnimation_0034;
                }
                var result = _scalarKeyFrameAnimation_0034 = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3631285F, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3910615F, 0.21233F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.4189944F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0035()
            {
                if (_scalarKeyFrameAnimation_0035 != null)
                {
                    return _scalarKeyFrameAnimation_0035;
                }
                var result = _scalarKeyFrameAnimation_0035 = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3631285F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3910615F, 0.66356F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.4189944F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0036()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.301676F, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3184358F, 0.42133F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.3575419F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0037()
            {
                if (_scalarKeyFrameAnimation_0037 != null)
                {
                    return _scalarKeyFrameAnimation_0037;
                }
                var result = _scalarKeyFrameAnimation_0037 = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.301676F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3184358F, 0.66356F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.3575419F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0038()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.301676F, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3184358F, 0.43833F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.3575419F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0039()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.301676F, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3184358F, 0.50633F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.3575419F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0040()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.301676F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3184358F, 0.75856F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.3575419F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0041()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.301676F, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3184358F, 0.43933F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.3575419F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0042()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.301676F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3184358F, 0.70456F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.3575419F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0043()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5418994F, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5586592F, 0.42133F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.5977654F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0044()
            {
                if (_scalarKeyFrameAnimation_0044 != null)
                {
                    return _scalarKeyFrameAnimation_0044;
                }
                var result = _scalarKeyFrameAnimation_0044 = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5418994F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5586592F, 0.66356F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.5977654F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0045()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5418994F, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5586592F, 0.43833F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.5977654F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0046()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5418994F, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5586592F, 0.50633F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.5977654F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0047()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5418994F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5586592F, 0.75856F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.5977654F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0048()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4469274F, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4636872F, 0.21233F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.4860335F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0049()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4469274F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4636872F, 0.66356F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.4860335F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0050()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4692737F, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4860335F, 0.21233F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.5083799F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0051()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4692737F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4860335F, 0.66356F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.5083799F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0052()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4748603F, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5027933F, 0.21233F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.5251397F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0053()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4748603F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5027933F, 0.66356F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.5251397F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0054()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4189944F, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4357542F, 0.42133F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.4581006F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0055()
            {
                if (_scalarKeyFrameAnimation_0055 != null)
                {
                    return _scalarKeyFrameAnimation_0055;
                }
                var result = _scalarKeyFrameAnimation_0055 = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4189944F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4357542F, 0.66356F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.4581006F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0056()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4189944F, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4357542F, 0.43833F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.4581006F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0057()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4189944F, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4357542F, 0.50633F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.4581006F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0058()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4189944F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4357542F, 0.75856F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.4581006F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0059()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.424581F, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4413408F, 0.42133F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.4636872F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0060()
            {
                if (_scalarKeyFrameAnimation_0060 != null)
                {
                    return _scalarKeyFrameAnimation_0060;
                }
                var result = _scalarKeyFrameAnimation_0060 = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.424581F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4413408F, 0.66356F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.4636872F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0061()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.424581F, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4413408F, 0.43833F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.4636872F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0062()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.424581F, 0.87F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4413408F, 0.50633F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.4636872F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0063()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.424581F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4413408F, 0.75856F, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.4636872F, 0, CubicBezierEasingFunction_0008());
                return result;
            }

            ShapeVisual ShapeVisual_0000()
            {
                var result = _c.CreateShapeVisual();
                result.Size = new Vector2(375, 667);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0000());
                shapes.Add(CompositionContainerShape_0002());
                shapes.Add(CompositionContainerShape_0007());
                shapes.Add(CompositionContainerShape_0011());
                shapes.Add(CompositionContainerShape_0016());
                shapes.Add(CompositionContainerShape_0020());
                shapes.Add(CompositionContainerShape_0025());
                shapes.Add(CompositionContainerShape_0029());
                shapes.Add(CompositionContainerShape_0034());
                shapes.Add(CompositionContainerShape_0038());
                shapes.Add(CompositionContainerShape_0043());
                shapes.Add(CompositionContainerShape_0047());
                shapes.Add(CompositionContainerShape_0051());
                shapes.Add(CompositionContainerShape_0055());
                shapes.Add(CompositionContainerShape_0059());
                shapes.Add(CompositionContainerShape_0063());
                shapes.Add(CompositionContainerShape_0067());
                shapes.Add(CompositionContainerShape_0071());
                shapes.Add(CompositionContainerShape_0075());
                shapes.Add(CompositionContainerShape_0079());
                shapes.Add(CompositionContainerShape_0083());
                shapes.Add(CompositionContainerShape_0088());
                shapes.Add(CompositionContainerShape_0093());
                shapes.Add(CompositionContainerShape_0097());
                shapes.Add(CompositionContainerShape_0101());
                shapes.Add(CompositionContainerShape_0105());
                shapes.Add(CompositionContainerShape_0109());
                shapes.Add(CompositionContainerShape_0113());
                shapes.Add(CompositionContainerShape_0117());
                shapes.Add(CompositionContainerShape_0121());
                shapes.Add(CompositionContainerShape_0125());
                shapes.Add(CompositionContainerShape_0129());
                shapes.Add(CompositionContainerShape_0133());
                shapes.Add(CompositionContainerShape_0137());
                shapes.Add(CompositionContainerShape_0141());
                shapes.Add(CompositionContainerShape_0145());
                shapes.Add(CompositionContainerShape_0149());
                shapes.Add(CompositionContainerShape_0153());
                shapes.Add(CompositionContainerShape_0157());
                shapes.Add(CompositionContainerShape_0161());
                shapes.Add(CompositionContainerShape_0165());
                shapes.Add(CompositionContainerShape_0169());
                shapes.Add(CompositionContainerShape_0173());
                shapes.Add(CompositionContainerShape_0177());
                shapes.Add(CompositionContainerShape_0181());
                return result;
            }

            StepEasingFunction StepEasingFunction_0000()
            {
                if (_stepEasingFunction_0000 != null)
                {
                    return _stepEasingFunction_0000;
                }
                var result = _stepEasingFunction_0000 = _c.CreateStepEasingFunction();
                result.IsInitialStepSingleFrame = true;
                return result;
            }

            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0000()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, new Vector2(164.782F, 57.473F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5363129F, new Vector2(164.782F, 57.473F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5530726F, new Vector2(164.782F, 55.473F), CubicBezierEasingFunction_0002());
                result.InsertKeyFrame(0.5698324F, new Vector2(164.782F, 57.473F), CubicBezierEasingFunction_0003());
                result.InsertKeyFrame(0.5865922F, new Vector2(164.782F, 56.909F), CubicBezierEasingFunction_0002());
                result.InsertKeyFrame(0.603352F, new Vector2(164.782F, 57.473F), CubicBezierEasingFunction_0003());
                return result;
            }

            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0001()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, new Vector2(43.263F, 59.75F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5363129F, new Vector2(43.263F, 59.75F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.603352F, new Vector2(62.513F, 59.75F), CubicBezierEasingFunction_0004());
                result.InsertKeyFrame(0.6424581F, new Vector2(63.763F, 59.75F), CubicBezierEasingFunction_0005());
                return result;
            }

            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0002()
            {
                if (_vector2KeyFrameAnimation_0002 != null)
                {
                    return _vector2KeyFrameAnimation_0002;
                }
                var result = _vector2KeyFrameAnimation_0002 = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, new Vector2(119.167F, 57.479F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4692737F, new Vector2(119.167F, 57.479F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5139665F, new Vector2(137.167F, 57.479F), CubicBezierEasingFunction_0006());
                result.InsertKeyFrame(0.5363129F, new Vector2(134.167F, 57.479F), CubicBezierEasingFunction_0007());
                return result;
            }

            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0003()
            {
                if (_vector2KeyFrameAnimation_0003 != null)
                {
                    return _vector2KeyFrameAnimation_0003;
                }
                var result = _vector2KeyFrameAnimation_0003 = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, new Vector2(93.594F, 62.861F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4357542F, new Vector2(93.594F, 62.861F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4916201F, new Vector2(92.626F, 82.829F), CubicBezierEasingFunction_0009());
                result.InsertKeyFrame(0.5139665F, new Vector2(92.844F, 77.861F), CubicBezierEasingFunction_0010());
                return result;
            }

            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0004()
            {
                if (_vector2KeyFrameAnimation_0004 != null)
                {
                    return _vector2KeyFrameAnimation_0004;
                }
                var result = _vector2KeyFrameAnimation_0004 = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, new Vector2(109.092F, 33.61F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4636872F, new Vector2(109.092F, 33.61F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5139665F, new Vector2(121.092F, 33.61F), CubicBezierEasingFunction_0009());
                result.InsertKeyFrame(0.5363129F, new Vector2(121.092F, 33.61F), CubicBezierEasingFunction_0011());
                return result;
            }

            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0005()
            {
                if (_vector2KeyFrameAnimation_0005 != null)
                {
                    return _vector2KeyFrameAnimation_0005;
                }
                var result = _vector2KeyFrameAnimation_0005 = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, new Vector2(113.715F, 9.146F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4413408F, new Vector2(113.715F, 9.146F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4916201F, new Vector2(137.715F, 9.146F), CubicBezierEasingFunction_0009());
                result.InsertKeyFrame(0.5139665F, new Vector2(133.715F, 9.146F), CubicBezierEasingFunction_0010());
                return result;
            }

            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0006()
            {
                if (_vector2KeyFrameAnimation_0006 != null)
                {
                    return _vector2KeyFrameAnimation_0006;
                }
                var result = _vector2KeyFrameAnimation_0006 = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, new Vector2(39.043F, 48.678F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3128492F, new Vector2(39.043F, 48.678F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3575419F, new Vector2(39.043F, 45.678F), CubicBezierEasingFunction_0006());
                return result;
            }

            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0007()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.SetReferenceParameter("_", ContainerVisual_0000());
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, new Vector2(-62.792F, 73.057F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1731844F, new Vector2(-62.792F, 73.057F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1969665F, new Vector2(-53.792F, 7.557F), CubicBezierEasingFunction_0008());
                result.InsertExpressionKeyFrame(0.24581F, "(Pow(1 - _.t0, 3) * Vector2((-53.792),7.557)) + (3 * Square((1 - _.t0)) * _.t0 * Vector2((-53.792),7.557)) + (3 * (1 - _.t0) * Square(_.t0) * Vector2((-52.82329),(-71.07968))) + (Pow(_.t0, 3) * Vector2((-33.667),(-72.818)))", StepEasingFunction_0000());
                result.InsertExpressionKeyFrame(0.3016759F, "(Pow(1 - _.t0, 3) * Vector2((-33.667),(-72.818))) + (3 * Square((1 - _.t0)) * _.t0 * Vector2((-17.45947),(-74.28873))) + (3 * (1 - _.t0) * Square(_.t0) * Vector2((-14.167),102.182)) + (Pow(_.t0, 3) * Vector2((-14.167),102.182))", StepEasingFunction_0000());
                result.InsertKeyFrame(0.301676F, new Vector2(-14.167F, 102.182F), StepEasingFunction_0000());
                result.InsertKeyFrame(0.3519553F, new Vector2(-14.167F, 59.182F), CubicBezierEasingFunction_0016());
                result.InsertKeyFrame(0.4078212F, new Vector2(-14.167F, 62.182F), CubicBezierEasingFunction_0017());
                return result;
            }

            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0008()
            {
                if (_vector2KeyFrameAnimation_0008 != null)
                {
                    return _vector2KeyFrameAnimation_0008;
                }
                var result = _vector2KeyFrameAnimation_0008 = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, new Vector2(1.5F, 1.5F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.301676F, new Vector2(1.5F, 1.5F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3407821F, new Vector2(22.3F, 22.3F), CubicBezierEasingFunction_0018());
                return result;
            }

            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0009()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.SetReferenceParameter("_", ContainerVisual_0000());
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, new Vector2(-62.792F, 73.057F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1731844F, new Vector2(-62.792F, 73.057F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1969665F, new Vector2(-53.792F, 7.557F), CubicBezierEasingFunction_0008());
                result.InsertExpressionKeyFrame(0.24581F, "(Pow(1 - _.t1, 3) * Vector2((-53.792),7.557)) + (3 * Square((1 - _.t1)) * _.t1 * Vector2((-53.792),7.557)) + (3 * (1 - _.t1) * Square(_.t1) * Vector2((-52.82329),(-71.07968))) + (Pow(_.t1, 3) * Vector2((-33.667),(-72.818)))", StepEasingFunction_0000());
                result.InsertExpressionKeyFrame(0.3016759F, "(Pow(1 - _.t1, 3) * Vector2((-33.667),(-72.818))) + (3 * Square((1 - _.t1)) * _.t1 * Vector2((-17.45947),(-74.28873))) + (3 * (1 - _.t1) * Square(_.t1) * Vector2((-14.167),102.182)) + (Pow(_.t1, 3) * Vector2((-14.167),102.182))", StepEasingFunction_0000());
                result.InsertKeyFrame(0.301676F, new Vector2(-14.167F, 102.182F), StepEasingFunction_0000());
                result.InsertKeyFrame(0.3519553F, new Vector2(-14.167F, 59.182F), CubicBezierEasingFunction_0016());
                result.InsertKeyFrame(0.4078212F, new Vector2(-14.167F, 62.182F), CubicBezierEasingFunction_0017());
                return result;
            }

            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0010()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, new Vector2(-33.667F, 8.182F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1564246F, new Vector2(-33.667F, 8.182F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2234637F, new Vector2(-33.667F, -72.818F), CubicBezierEasingFunction_0021());
                result.InsertKeyFrame(0.301676F, new Vector2(-33.667F, 102.057F), CubicBezierEasingFunction_0022());
                return result;
            }

            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0011()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, new Vector2(39.875F, 60), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1564246F, new Vector2(39.875F, 60), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.301676F, new Vector2(79.375F, 60), CubicBezierEasingFunction_0008());
                return result;
            }

            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0012()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(59670000);
                result.InsertKeyFrame(0, new Vector2(295.771F, 108.994F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1043956F, new Vector2(35.771F, 108.994F), CubicBezierEasingFunction_0028());
                return result;
            }

        }
    }
}
