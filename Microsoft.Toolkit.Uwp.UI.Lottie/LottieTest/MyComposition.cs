using Lottie;
using Microsoft.Graphics.Canvas.Geometry;
using System;
using System.Numerics;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;

namespace Compositions
{
    sealed class MyComposition : ICompositionSource
    {
        public void CreateInstance(
            Compositor compositor,
            out Visual rootVisual,
            out Vector2 size,
            out CompositionPropertySet progressPropertySet,
            out TimeSpan duration)
        {
            rootVisual = Instantiator.InstantiateComposition(compositor);
            size = new Vector2(1920, 1080);
            progressPropertySet = rootVisual.Properties;
            duration = TimeSpan.FromTicks(37170000);
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
            CompositionColorBrush _compositionColorBrush_0001;
            CompositionColorBrush _compositionColorBrush_0002;
            CompositionColorBrush _compositionColorBrush_0003;
            ContainerVisual _containerVisual_0000;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0000;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0010;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0011;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0012;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0013;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0014;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0015;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0016;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0017;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0019;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0020;
            ExpressionAnimation _expressionAnimation_0000;
            ExpressionAnimation _expressionAnimation_0001;
            LinearEasingFunction _linearEasingFunction_0000;
            ScalarKeyFrameAnimation _scalarKeyFrameAnimation_0002;
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
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-64.5F, 79.5F));
                    builder.AddCubicBezier(new Vector2(-64.502F, 75.91F), new Vector2(-64.761F, 63.69F), new Vector2(-65, 53));
                    builder.AddCubicBezier(new Vector2(-65.933F, 11.355F), new Vector2(-64, -60), new Vector2(-65.605F, -82.653F));
                    builder.AddCubicBezier(new Vector2(-65.739F, -84.551F), new Vector2(-65.557F, -86.615F), new Vector2(-64.388F, -88.116F));
                    builder.AddCubicBezier(new Vector2(-62.915F, -90.008F), new Vector2(-60.232F, -90.338F), new Vector2(-57.84F, -90.508F));
                    builder.AddCubicBezier(new Vector2(-33.568F, -92.235F), new Vector2(-9.224F, -92.948F), new Vector2(15.107F, -92.646F));
                    builder.AddCubicBezier(new Vector2(17.362F, -92.618F), new Vector2(19.708F, -92.561F), new Vector2(21.72F, -91.541F));
                    builder.AddCubicBezier(new Vector2(23.53F, -90.624F), new Vector2(24.88F, -89.022F), new Vector2(26.178F, -87.462F));
                    builder.AddCubicBezier(new Vector2(38.193F, -73.022F), new Vector2(52.259F, -63.436F), new Vector2(66.821F, -51.569F));
                    builder.AddCubicBezier(new Vector2(66.059F, -50.368F), new Vector2(64.434F, -50.134F), new Vector2(63.016F, -50.023F));
                    builder.AddCubicBezier(new Vector2(49.588F, -48.968F), new Vector2(36.133F, -48.254F), new Vector2(22.669F, -47.881F));
                    builder.AddCubicBezier(new Vector2(21.997F, -47.862F), new Vector2(21.177F, -47.928F), new Vector2(20.881F, -48.531F));
                    builder.AddCubicBezier(new Vector2(20.707F, -48.885F), new Vector2(20.786F, -49.305F), new Vector2(20.867F, -49.69F));
                    builder.AddCubicBezier(new Vector2(23.453F, -61.964F), new Vector2(24.462F, -71.569F), new Vector2(23.862F, -84.098F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0001()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(68.253F, -45));
                    builder.AddCubicBezier(new Vector2(72.472F, -13.072F), new Vector2(66.645F, 23.409F), new Vector2(70.891F, 55.334F));
                    builder.AddCubicBezier(new Vector2(71.6F, 60.667F), new Vector2(72.592F, 65.986F), new Vector2(72.656F, 71.365F));
                    builder.AddCubicBezier(new Vector2(72.67F, 72.574F), new Vector2(72.611F, 73.867F), new Vector2(71.906F, 74.849F));
                    builder.AddCubicBezier(new Vector2(70.801F, 76.389F), new Vector2(68.613F, 76.56F), new Vector2(66.717F, 76.565F));
                    builder.AddCubicBezier(new Vector2(45.807F, 76.618F), new Vector2(-4.783F, 78.675F), new Vector2(-44, 79));
                    builder.AddCubicBezier(new Vector2(-59.26F, 79.126F), new Vector2(-61.784F, 77.676F), new Vector2(-67.384F, 80.216F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0002()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-27.934F, 32.289F));
                    builder.AddCubicBezier(new Vector2(-26.232F, 40.567F), new Vector2(-26.075F, 49.16F), new Vector2(-27.475F, 57.495F));
                    builder.AddCubicBezier(new Vector2(-27.709F, 58.887F), new Vector2(-28.011F, 60.328F), new Vector2(-28.879F, 61.441F));
                    builder.AddCubicBezier(new Vector2(-30.039F, 62.928F), new Vector2(-32.011F, 63.552F), new Vector2(-33.893F, 63.686F));
                    builder.AddCubicBezier(new Vector2(-35.567F, 63.805F), new Vector2(-37.332F, 63.574F), new Vector2(-38.716F, 62.626F));
                    builder.AddCubicBezier(new Vector2(-40.1F, 61.678F), new Vector2(-40.99F, 59.89F), new Vector2(-40.527F, 58.277F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0003()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-5.939F, 34.091F));
                    builder.AddCubicBezier(new Vector2(-9.524F, 32.446F), new Vector2(-13.862F, 33.493F), new Vector2(-16.639F, 36.675F));
                    builder.AddCubicBezier(new Vector2(-17.624F, 37.804F), new Vector2(-18.445F, 39.254F), new Vector2(-18.555F, 40.884F));
                    builder.AddCubicBezier(new Vector2(-18.725F, 43.396F), new Vector2(-17.146F, 45.679F), new Vector2(-15.276F, 46.822F));
                    builder.AddCubicBezier(new Vector2(-13.406F, 47.965F), new Vector2(-11.269F, 48.243F), new Vector2(-9.206F, 48.703F));
                    builder.AddCubicBezier(new Vector2(-7.143F, 49.163F), new Vector2(-5.006F, 49.891F), new Vector2(-3.53F, 51.682F));
                    builder.AddCubicBezier(new Vector2(-2.593F, 52.819F), new Vector2(-0.288F, 56.858F), new Vector2(-3.107F, 59.089F));
                    builder.AddCubicBezier(new Vector2(-7.839F, 62.833F), new Vector2(-13.767F, 64.307F), new Vector2(-19.209F, 62.565F));
                    builder.AddCubicBezier(new Vector2(-19.39F, 62.507F), new Vector2(-19.594F, 62.419F), new Vector2(-19.657F, 62.207F));
                    builder.AddCubicBezier(new Vector2(-19.72F, 61.995F), new Vector2(-19.464F, 61.736F), new Vector2(-19.353F, 61.917F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0004()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(10.534F, 34.768F));
                    builder.AddCubicBezier(new Vector2(8.948F, 35.347F), new Vector2(8.064F, 37.231F), new Vector2(7.449F, 38.99F));
                    builder.AddCubicBezier(new Vector2(6.291F, 42.299F), new Vector2(5.504F, 45.775F), new Vector2(5.11F, 49.308F));
                    builder.AddCubicBezier(new Vector2(4.79F, 52.178F), new Vector2(4.775F, 55.282F), new Vector2(6.127F, 57.733F));
                    builder.AddCubicBezier(new Vector2(7.083F, 59.465F), new Vector2(8.628F, 60.678F), new Vector2(10.257F, 61.546F));
                    builder.AddCubicBezier(new Vector2(12.111F, 62.534F), new Vector2(14.213F, 63.137F), new Vector2(16.212F, 62.632F));
                    builder.AddCubicBezier(new Vector2(18.229F, 62.123F), new Vector2(19.951F, 60.502F), new Vector2(21.01F, 58.487F));
                    builder.AddCubicBezier(new Vector2(22.069F, 56.472F), new Vector2(22.508F, 54.094F), new Vector2(22.538F, 51.747F));
                    builder.AddCubicBezier(new Vector2(22.639F, 43.702F), new Vector2(17.593F, 35.926F), new Vector2(10.798F, 33.659F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0005()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(28.548F, 63.332F));
                    builder.AddCubicBezier(new Vector2(28.547F, 60.06F), new Vector2(28.545F, 56.788F), new Vector2(28.544F, 53.516F));
                    builder.AddCubicBezier(new Vector2(28.541F, 46.442F), new Vector2(28.528F, 39.261F), new Vector2(27.069F, 32.455F));
                    builder.AddCubicBezier(new Vector2(28.63F, 33.482F), new Vector2(29.537F, 35.64F), new Vector2(30.396F, 37.644F));
                    builder.AddCubicBezier(new Vector2(34.28F, 46.699F), new Vector2(39.071F, 55.074F), new Vector2(44.606F, 62.48F));
                    builder.AddCubicBezier(new Vector2(44.589F, 57.629F), new Vector2(44.563F, 52.696F), new Vector2(43.49F, 48.056F));
                    builder.AddCubicBezier(new Vector2(42.875F, 45.396F), new Vector2(42.384F, 29.828F), new Vector2(42.057F, 30.001F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0006()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-15, -115.5F));
                    builder.AddCubicBezier(new Vector2(-8.873F, -120.125F), new Vector2(3.38F, -129.375F), new Vector2(9.5F, -134));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0007()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-34, -135.25F));
                    builder.AddCubicBezier(new Vector2(-31.617F, -141.618F), new Vector2(-26.852F, -154.354F), new Vector2(-24.5F, -160.75F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0008()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-64.75F, -137));
                    builder.AddCubicBezier(new Vector2(-66.265F, -144.798F), new Vector2(-69.296F, -160.395F), new Vector2(-70.75F, -168.25F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0009()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-91.75F, -124.5F));
                    builder.AddCubicBezier(new Vector2(-96.125F, -127.752F), new Vector2(-104.875F, -134.255F), new Vector2(-109.25F, -137.5F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0010()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-9.25F, -53.75F));
                    builder.AddCubicBezier(new Vector2(-4.295F, -49.923F), new Vector2(5.614F, -42.27F), new Vector2(10.5F, -38.5F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0011()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-35.25F, -35.75F));
                    builder.AddCubicBezier(new Vector2(-33.377F, -30.25F), new Vector2(-29.63F, -19.25F), new Vector2(-27.75F, -13.75F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0012()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-72.75F, -33.25F));
                    builder.AddCubicBezier(new Vector2(-74.813F, -27.904F), new Vector2(-78.938F, -17.213F), new Vector2(-81, -11.75F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0013()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-91.5F, -53));
                    builder.AddCubicBezier(new Vector2(-95.938F, -50.623F), new Vector2(-104.812F, -45.87F), new Vector2(-109.25F, -43.5F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0014()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-11.75F, -84.75F));
                    builder.AddCubicBezier(new Vector2(-6.563F, -85.083F), new Vector2(3.812F, -85.75F), new Vector2(9, -86.25F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0015()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-89.5F, -88));
                    builder.AddCubicBezier(new Vector2(-95.563F, -88.314F), new Vector2(-107.688F, -88.943F), new Vector2(-113.75F, -89.25F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0016()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-46.75F, -91.563F));
                    builder.AddCubicBezier(new Vector2(-57.25F, -64.313F), new Vector2(-73.25F, -57.5F), new Vector2(-92, -70.25F));
                    builder.AddCubicBezier(new Vector2(-110.222F, -82.641F), new Vector2(-100.132F, -105.161F), new Vector2(-89.25F, -111));
                    builder.AddCubicBezier(new Vector2(-79, -116.5F), new Vector2(-68, -114), new Vector2(-57.625F, -103.75F));
                    builder.AddCubicBezier(new Vector2(-51, -97.5F), new Vector2(-42.625F, -88.625F), new Vector2(-37.875F, -84.5F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            CanvasGeometry CanvasGeometry_0017()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-46.938F, -91.5F));
                    builder.AddCubicBezier(new Vector2(-43.438F, -70.75F), new Vector2(-23.884F, -54.847F), new Vector2(-6.625F, -66.75F));
                    builder.AddCubicBezier(new Vector2(7.875F, -76.75F), new Vector2(14.75F, -96), new Vector2(0.75F, -106.875F));
                    builder.AddCubicBezier(new Vector2(-10.628F, -115.713F), new Vector2(-32.603F, -109.976F), new Vector2(-40.312F, -101.813F));
                    builder.AddCubicBezier(new Vector2(-47.75F, -93.938F), new Vector2(-53.15F, -88.45F), new Vector2(-56.875F, -84.25F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }

            ColorKeyFrameAnimation ColorKeyFrameAnimation_0000()
            {
                var result = _c.CreateColorKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(37170000);
                result.InsertKeyFrame(0, Color.FromArgb(0xFF, 0x45, 0x4C, 0x54), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.07589286F, Color.FromArgb(0xFF, 0x37, 0x3D, 0x42), CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.7767857F, Color.FromArgb(0xFF, 0x37, 0x3D, 0x42), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.875F, Color.FromArgb(0xFF, 0x45, 0x4C, 0x54), CubicBezierEasingFunction_0000());
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0000()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x45, 0x4C, 0x54));
                result.StartAnimation("Color", ColorKeyFrameAnimation_0000());
                var controller = result.TryGetAnimationController("Color");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0001());
                return result;
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
                var result = _compositionColorBrush_0002 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x23, 0xF1, 0xC0));
                return result;
            }

            CompositionColorBrush CompositionColorBrush_0003()
            {
                if (_compositionColorBrush_0003 != null)
                {
                    return _compositionColorBrush_0003;
                }
                var result = _compositionColorBrush_0003 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xE2, 0x14, 0x14));
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0000()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(908.5F, 456.5F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0001());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0001()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0000());
                result.StartAnimation("Scale", Vector2KeyFrameAnimation_0000());
                var controller = result.TryGetAnimationController("Scale");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0001());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0002()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(10.464F, -1.864F));
                propertySet.InsertVector2("Position", new Vector2(909.606F, 455.298F));
                result.CenterPoint = new Vector2(10.464F, -1.864F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0003());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0001());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("Scale", Vector2KeyFrameAnimation_0002());
                controller = result.TryGetAnimationController("Scale");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0001());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0003()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(8, 0);
                result.Scale = new Vector2(0.5F, 0.5F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0004());
                //shapes.Add(CompositionContainerShape_0008());
                //shapes.Add(CompositionContainerShape_0009());
                //shapes.Add(CompositionContainerShape_0010());
                //shapes.Add(CompositionContainerShape_0011());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0004()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0005());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0005()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0006());
                shapes.Add(CompositionContainerShape_0007());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0006()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0001());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0007()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0002());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0008()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0003());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0009()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0004());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0010()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0005());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0011()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0006());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0012()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(-51.5F, -82);
                result.Offset = new Vector2(960, 540);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0013());
                shapes.Add(CompositionContainerShape_0014());
                shapes.Add(CompositionContainerShape_0015());
                shapes.Add(CompositionContainerShape_0016());
                shapes.Add(CompositionContainerShape_0017());
                shapes.Add(CompositionContainerShape_0018());
                shapes.Add(CompositionContainerShape_0019());
                shapes.Add(CompositionContainerShape_0020());
                shapes.Add(CompositionContainerShape_0021());
                shapes.Add(CompositionContainerShape_0022());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0013()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0007());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0014()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0008());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0015()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0009());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0016()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0010());
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
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0012());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0019()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0013());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0020()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0014());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0021()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0015());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0022()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0016());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0023()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(-51.5F, -82);
                result.Offset = new Vector2(956, 546.5F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0024());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0024()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0025());
                shapes.Add(CompositionContainerShape_0026());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "((_.Progress) < 0.5650224) ? (Matrix3x2(0,0,0,0,0,0)) : (Matrix3x2(1,0,0,1,0,0))";
                _expressionAnimation.SetReferenceParameter("_", ContainerVisual_0000());
                result.StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0025()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0017());
                return result;
            }

            CompositionContainerShape CompositionContainerShape_0026()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0018());
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0000()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0000()));
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
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0003()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0003()));
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0004()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0004()));
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0005()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0005()));
                return result;
            }

            CompositionPathGeometry CompositionPathGeometry_0006()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0006()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 1);
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

            CompositionPathGeometry CompositionPathGeometry_0007()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0007()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 1);
                propertySet.InsertScalar("TEnd", 1);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0003());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0004());
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
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 1);
                propertySet.InsertScalar("TEnd", 1);
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

            CompositionPathGeometry CompositionPathGeometry_0009()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0009()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 1);
                propertySet.InsertScalar("TEnd", 1);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0007());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0008());
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

            CompositionPathGeometry CompositionPathGeometry_0010()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0010()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 1);
                propertySet.InsertScalar("TEnd", 1);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0009());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0010());
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

            CompositionPathGeometry CompositionPathGeometry_0011()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0011()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 1);
                propertySet.InsertScalar("TEnd", 1);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0011());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0012());
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

            CompositionPathGeometry CompositionPathGeometry_0012()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0012()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 1);
                propertySet.InsertScalar("TEnd", 1);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0013());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0014());
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

            CompositionPathGeometry CompositionPathGeometry_0013()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0013()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 1);
                propertySet.InsertScalar("TEnd", 1);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0015());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0016());
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

            CompositionPathGeometry CompositionPathGeometry_0014()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0014()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 1);
                propertySet.InsertScalar("TEnd", 1);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0017());
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

            CompositionPathGeometry CompositionPathGeometry_0015()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0015()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 1);
                propertySet.InsertScalar("TEnd", 1);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0018());
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

            CompositionPathGeometry CompositionPathGeometry_0016()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0016()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 0);
                propertySet.InsertScalar("TEnd", 0);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0020());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0021());
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
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0023());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0024());
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
                result.Size = new Vector2(320, 301);
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
                result.StrokeMiterLimit = 10;
//                result.StrokeThickness = 0.45F;
                result.StrokeThickness = 1F;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0002()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0001();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeMiterLimit = 10;
                result.StrokeThickness = 0.45F;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0003()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0002();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 4;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0004()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0003();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 4;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0005()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0004();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 4;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0006()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0005();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 4;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0007()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0006();
                result.StrokeBrush = CompositionColorBrush_0002();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeDashOffset = 1;
                var strokeDashArray = result.StrokeDashArray;
                strokeDashArray.Add(13);
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 3;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0008()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0007();
                result.StrokeBrush = CompositionColorBrush_0002();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 3;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0009()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0008();
                result.StrokeBrush = CompositionColorBrush_0002();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeDashOffset = -2;
                var strokeDashArray = result.StrokeDashArray;
                strokeDashArray.Add(12);
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 3;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0010()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0009();
                result.StrokeBrush = CompositionColorBrush_0002();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 3;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0011()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0010();
                result.StrokeBrush = CompositionColorBrush_0002();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                var strokeDashArray = result.StrokeDashArray;
                strokeDashArray.Add(11);
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 3;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0012()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0011();
                result.StrokeBrush = CompositionColorBrush_0002();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 3;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0013()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0012();
                result.StrokeBrush = CompositionColorBrush_0002();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                var strokeDashArray = result.StrokeDashArray;
                strokeDashArray.Add(9);
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 3;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0014()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0013();
                result.StrokeBrush = CompositionColorBrush_0002();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 3;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0015()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0014();
                result.StrokeBrush = CompositionColorBrush_0002();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 3;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0016()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0015();
                result.StrokeBrush = CompositionColorBrush_0002();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeDashOffset = 16;
                var strokeDashArray = result.StrokeDashArray;
                strokeDashArray.Add(7);
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 3;
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0017()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0016();
                result.StrokeBrush = CompositionColorBrush_0003();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 3;
                //result.StartAnimation("StrokeThickness", ScalarKeyFrameAnimation_0019());
                //var controller = result.TryGetAnimationController("StrokeThickness");
                //controller.Pause();
                //controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionSpriteShape CompositionSpriteShape_0018()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0017();
                result.StrokeBrush = CompositionColorBrush_0003();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 3;
                //result.StartAnimation("StrokeThickness", ScalarKeyFrameAnimation_0022());
                //var controller = result.TryGetAnimationController("StrokeThickness");
                //controller.Pause();
                //controller.StartAnimation("Progress", ExpressionAnimation_0000());
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
                var children = result.Children;
                children.InsertAtTop(ShapeVisual_0000());
                result.StartAnimation("t0", ScalarKeyFrameAnimation_0000());
                var controller = result.TryGetAnimationController("t0");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0000()
            {
                if (_cubicBezierEasingFunction_0000 != null)
                {
                    return _cubicBezierEasingFunction_0000;
                }
                return _cubicBezierEasingFunction_0000 = _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0.833F, 0.833F));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0001()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.817F, 0), new Vector2(0.573F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0002()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0), new Vector2(0.675F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0003()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.94F, 0), new Vector2(0.667F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0004()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.04F, 0), new Vector2(0.457F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0005()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.751F, 0), new Vector2(0.347F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0006()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.333F, 0), new Vector2(0.833F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0007()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(1, 0), new Vector2(0.833F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0008()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0), new Vector2(0.833F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0009()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0), new Vector2(0.667F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0010()
            {
                if (_cubicBezierEasingFunction_0010 != null)
                {
                    return _cubicBezierEasingFunction_0010;
                }
                return _cubicBezierEasingFunction_0010 = _c.CreateCubicBezierEasingFunction(new Vector2(0.073F, 0), new Vector2(0.389F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0011()
            {
                if (_cubicBezierEasingFunction_0011 != null)
                {
                    return _cubicBezierEasingFunction_0011;
                }
                return _cubicBezierEasingFunction_0011 = _c.CreateCubicBezierEasingFunction(new Vector2(0.34F, 0.003F), new Vector2(0.667F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0012()
            {
                if (_cubicBezierEasingFunction_0012 != null)
                {
                    return _cubicBezierEasingFunction_0012;
                }
                return _cubicBezierEasingFunction_0012 = _c.CreateCubicBezierEasingFunction(new Vector2(0.34F, 0.003F), new Vector2(0.673F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0013()
            {
                if (_cubicBezierEasingFunction_0013 != null)
                {
                    return _cubicBezierEasingFunction_0013;
                }
                return _cubicBezierEasingFunction_0013 = _c.CreateCubicBezierEasingFunction(new Vector2(0.699F, 0), new Vector2(1, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0014()
            {
                if (_cubicBezierEasingFunction_0014 != null)
                {
                    return _cubicBezierEasingFunction_0014;
                }
                return _cubicBezierEasingFunction_0014 = _c.CreateCubicBezierEasingFunction(new Vector2(0.161F, 0), new Vector2(0.67F, 0.982F));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0015()
            {
                if (_cubicBezierEasingFunction_0015 != null)
                {
                    return _cubicBezierEasingFunction_0015;
                }
                return _cubicBezierEasingFunction_0015 = _c.CreateCubicBezierEasingFunction(new Vector2(0.34F, 0.003F), new Vector2(0.833F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0016()
            {
                if (_cubicBezierEasingFunction_0016 != null)
                {
                    return _cubicBezierEasingFunction_0016;
                }
                return _cubicBezierEasingFunction_0016 = _c.CreateCubicBezierEasingFunction(new Vector2(0.337F, 0.01F), new Vector2(0.67F, 0.982F));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0017()
            {
                if (_cubicBezierEasingFunction_0017 != null)
                {
                    return _cubicBezierEasingFunction_0017;
                }
                return _cubicBezierEasingFunction_0017 = _c.CreateCubicBezierEasingFunction(new Vector2(0.112F, 0), new Vector2(0.081F, 0.53F));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0018()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.67F, 1), new Vector2(0.683F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0019()
            {
                if (_cubicBezierEasingFunction_0019 != null)
                {
                    return _cubicBezierEasingFunction_0019;
                }
                return _cubicBezierEasingFunction_0019 = _c.CreateCubicBezierEasingFunction(new Vector2(0.828F, 0), new Vector2(0.667F, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0020()
            {
                if (_cubicBezierEasingFunction_0020 != null)
                {
                    return _cubicBezierEasingFunction_0020;
                }
                return _cubicBezierEasingFunction_0020 = _c.CreateCubicBezierEasingFunction(new Vector2(0.49F, 0), new Vector2(1, 1));
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0021()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.67F, 0.895F), new Vector2(0.683F, 1));
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
                result.Expression = "_.Progress*0.995535714285714+0.00446428571428571";
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
                result.Duration = TimeSpan.FromTicks(37170000);
                result.InsertKeyFrame(0.07174898F, 0, StepEasingFunction_0000());
                result.InsertKeyFrame(0.0941703F, 1, CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.0941704F, 0, StepEasingFunction_0000());
                result.InsertKeyFrame(0.1165918F, 1, CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.1165919F, 0, StepEasingFunction_0000());
                result.InsertKeyFrame(0.1434977F, 1, CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.1434978F, 0, StepEasingFunction_0000());
                result.InsertKeyFrame(0.1704035F, 1, CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.1704036F, 0, StepEasingFunction_0000());
                result.InsertKeyFrame(0.192825F, 1, CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.1928251F, 0, StepEasingFunction_0000());
                result.InsertKeyFrame(0.2197308F, 1, CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.2197309F, 0, StepEasingFunction_0000());
                result.InsertKeyFrame(0.2421524F, 1, CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.2421525F, 0, StepEasingFunction_0000());
                result.InsertKeyFrame(0.2645739F, 1, CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.264574F, 0, StepEasingFunction_0000());
                result.InsertKeyFrame(0.2914797F, 1, CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.2914798F, 0, StepEasingFunction_0000());
                result.InsertKeyFrame(0.3183855F, 1, CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.3183856F, 0, StepEasingFunction_0000());
                result.InsertKeyFrame(0.3408071F, 1, CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.3408072F, 0, StepEasingFunction_0000());
                result.InsertKeyFrame(0.3677129F, 1, CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.367713F, 0, StepEasingFunction_0000());
                result.InsertKeyFrame(0.3901344F, 1, CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.3901345F, 0, StepEasingFunction_0000());
                result.InsertKeyFrame(0.412556F, 1, CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.4125561F, 0, StepEasingFunction_0000());
                result.InsertKeyFrame(0.4394618F, 1, CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.4394619F, 0, StepEasingFunction_0000());
                result.InsertKeyFrame(0.4663676F, 1, CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.4663677F, 0, StepEasingFunction_0000());
                result.InsertKeyFrame(0.4887891F, 1, CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.4887892F, 0, StepEasingFunction_0000());
                result.InsertKeyFrame(0.515695F, 1, CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.5156951F, 0, StepEasingFunction_0000());
                result.InsertKeyFrame(0.5381165F, 1, CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.5381166F, 0, StepEasingFunction_0000());
                result.InsertKeyFrame(0.560538F, 1, CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.5605381F, 0, StepEasingFunction_0000());
                result.InsertKeyFrame(0.5874438F, 1, CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.5874439F, 0, StepEasingFunction_0000());
                result.InsertKeyFrame(0.6143497F, 1, CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.6143498F, 0, StepEasingFunction_0000());
                result.InsertKeyFrame(0.6367712F, 1, CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.6367713F, 0, StepEasingFunction_0000());
                result.InsertKeyFrame(0.663677F, 1, CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.6636772F, 0, StepEasingFunction_0000());
                result.InsertKeyFrame(0.6860986F, 1, CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.6860987F, 0, StepEasingFunction_0000());
                result.InsertKeyFrame(0.7085201F, 1, CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.7085202F, 0, StepEasingFunction_0000());
                result.InsertKeyFrame(0.7354259F, 1, CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.735426F, 0, StepEasingFunction_0000());
                result.InsertKeyFrame(0.7623317F, 1, CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.7623318F, 0, StepEasingFunction_0000());
                result.InsertKeyFrame(0.7847533F, 1, CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.7847534F, 0, StepEasingFunction_0000());
                result.InsertKeyFrame(0.8116591F, 1, CubicBezierEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0001()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(37170000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.07174888F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1434978F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.2152466F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2197309F, 1, CubicBezierEasingFunction_0011());
                result.InsertKeyFrame(0.2914798F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.3632287F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.367713F, 1, CubicBezierEasingFunction_0011());
                result.InsertKeyFrame(0.4394619F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.5112107F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5156951F, 1, CubicBezierEasingFunction_0011());
                result.InsertKeyFrame(0.5874439F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.6591928F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6636772F, 1, CubicBezierEasingFunction_0011());
                result.InsertKeyFrame(0.735426F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.8071749F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8116592F, 1, CubicBezierEasingFunction_0012());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0002()
            {
                if (_scalarKeyFrameAnimation_0002 != null)
                {
                    return _scalarKeyFrameAnimation_0002;
                }
                var result = _scalarKeyFrameAnimation_0002 = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(37170000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1434978F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2152466F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.2197309F, 1, CubicBezierEasingFunction_0014());
                result.InsertKeyFrame(0.2914798F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3632287F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.367713F, 1, CubicBezierEasingFunction_0014());
                result.InsertKeyFrame(0.4394619F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5112107F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.5156951F, 1, CubicBezierEasingFunction_0014());
                result.InsertKeyFrame(0.5874439F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6591928F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.6636772F, 1, CubicBezierEasingFunction_0014());
                result.InsertKeyFrame(0.735426F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8071749F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.8116592F, 1, CubicBezierEasingFunction_0014());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0003()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(37170000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.07174888F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1390135F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.2152466F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2197309F, 1, CubicBezierEasingFunction_0015());
                result.InsertKeyFrame(0.2869955F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.3632287F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.367713F, 1, CubicBezierEasingFunction_0015());
                result.InsertKeyFrame(0.4349776F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.5112107F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5156951F, 1, CubicBezierEasingFunction_0015());
                result.InsertKeyFrame(0.5829597F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.6591928F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6636772F, 1, CubicBezierEasingFunction_0015());
                result.InsertKeyFrame(0.7309417F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.8071749F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8116592F, 1, CubicBezierEasingFunction_0012());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0004()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(37170000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1390135F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2017937F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.2152466F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2197309F, 1, CubicBezierEasingFunction_0016());
                result.InsertKeyFrame(0.2869955F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3497758F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.3632287F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.367713F, 1, CubicBezierEasingFunction_0016());
                result.InsertKeyFrame(0.4349776F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4977579F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.5112107F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5156951F, 1, CubicBezierEasingFunction_0016());
                result.InsertKeyFrame(0.5829597F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6457399F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.6591928F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6636772F, 1, CubicBezierEasingFunction_0016());
                result.InsertKeyFrame(0.7309417F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.793722F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.8071749F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8116592F, 1, CubicBezierEasingFunction_0016());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0005()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(37170000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.07623319F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1524664F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.2152466F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2197309F, 1, CubicBezierEasingFunction_0012());
                result.InsertKeyFrame(0.2242152F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3004484F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.3632287F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.367713F, 1, CubicBezierEasingFunction_0012());
                result.InsertKeyFrame(0.3721973F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4484305F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.5112107F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5156951F, 1, CubicBezierEasingFunction_0012());
                result.InsertKeyFrame(0.5201794F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5964125F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.6591928F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6636772F, 1, CubicBezierEasingFunction_0012());
                result.InsertKeyFrame(0.6681615F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7443946F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.8071749F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8116592F, 1, CubicBezierEasingFunction_0012());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0006()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(37170000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1524664F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2152466F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.2197309F, 1, CubicBezierEasingFunction_0014());
                result.InsertKeyFrame(0.3004484F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3632287F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.367713F, 1, CubicBezierEasingFunction_0014());
                result.InsertKeyFrame(0.4484305F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5112107F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.5156951F, 1, CubicBezierEasingFunction_0014());
                result.InsertKeyFrame(0.5964125F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6591928F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.6636772F, 1, CubicBezierEasingFunction_0014());
                result.InsertKeyFrame(0.7443946F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8071749F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.8116592F, 1, CubicBezierEasingFunction_0014());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0007()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(37170000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.08071749F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1390135F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.2152466F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2197309F, 1, CubicBezierEasingFunction_0012());
                result.InsertKeyFrame(0.2286996F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2869955F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.3632287F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.367713F, 1, CubicBezierEasingFunction_0012());
                result.InsertKeyFrame(0.3766816F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4349776F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.5112107F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5156951F, 1, CubicBezierEasingFunction_0012());
                result.InsertKeyFrame(0.5246637F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5829597F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.6591928F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6636772F, 1, CubicBezierEasingFunction_0012());
                result.InsertKeyFrame(0.6726457F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7309417F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.8071749F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8116592F, 1, CubicBezierEasingFunction_0012());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0008()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(37170000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1390135F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2152466F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.2197309F, 1, CubicBezierEasingFunction_0014());
                result.InsertKeyFrame(0.2869955F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3632287F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.367713F, 1, CubicBezierEasingFunction_0014());
                result.InsertKeyFrame(0.4349776F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5112107F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.5156951F, 1, CubicBezierEasingFunction_0014());
                result.InsertKeyFrame(0.5829597F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6591928F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.6636772F, 1, CubicBezierEasingFunction_0014());
                result.InsertKeyFrame(0.7309417F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8071749F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.8116592F, 1, CubicBezierEasingFunction_0014());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0009()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(37170000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.07174888F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1390135F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.2152466F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2197309F, 1, CubicBezierEasingFunction_0011());
                result.InsertKeyFrame(0.2869955F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.3632287F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.367713F, 1, CubicBezierEasingFunction_0011());
                result.InsertKeyFrame(0.4349776F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.5112107F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5156951F, 1, CubicBezierEasingFunction_0011());
                result.InsertKeyFrame(0.5829597F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.6591928F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6636772F, 1, CubicBezierEasingFunction_0011());
                result.InsertKeyFrame(0.7309417F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.8071749F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8116592F, 1, CubicBezierEasingFunction_0012());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0010()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(37170000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1390135F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2107623F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.2152466F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2197309F, 1, CubicBezierEasingFunction_0016());
                result.InsertKeyFrame(0.2869955F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3587444F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.3632287F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.367713F, 1, CubicBezierEasingFunction_0016());
                result.InsertKeyFrame(0.4349776F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5067264F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.5112107F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5156951F, 1, CubicBezierEasingFunction_0016());
                result.InsertKeyFrame(0.5829597F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6547085F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.6591928F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6636772F, 1, CubicBezierEasingFunction_0016());
                result.InsertKeyFrame(0.7309417F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8026906F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.8071749F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8116592F, 1, CubicBezierEasingFunction_0016());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0011()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(37170000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.07174888F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1434978F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.2152466F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2197309F, 1, CubicBezierEasingFunction_0015());
                result.InsertKeyFrame(0.2914798F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.3632287F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.367713F, 1, CubicBezierEasingFunction_0015());
                result.InsertKeyFrame(0.4394619F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.5112107F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5156951F, 1, CubicBezierEasingFunction_0015());
                result.InsertKeyFrame(0.5874439F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.6591928F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6636772F, 1, CubicBezierEasingFunction_0015());
                result.InsertKeyFrame(0.735426F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.8071749F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8116592F, 1, CubicBezierEasingFunction_0012());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0012()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(37170000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1434978F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2107623F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.2152466F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2197309F, 1, CubicBezierEasingFunction_0016());
                result.InsertKeyFrame(0.2914798F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3587444F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.3632287F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.367713F, 1, CubicBezierEasingFunction_0016());
                result.InsertKeyFrame(0.4394619F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5067264F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.5112107F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5156951F, 1, CubicBezierEasingFunction_0016());
                result.InsertKeyFrame(0.5874439F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6547085F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.6591928F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6636772F, 1, CubicBezierEasingFunction_0016());
                result.InsertKeyFrame(0.735426F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8026906F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.8071749F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8116592F, 1, CubicBezierEasingFunction_0016());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0013()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(37170000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.08520179F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1479821F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.2152466F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2197309F, 1, CubicBezierEasingFunction_0012());
                result.InsertKeyFrame(0.2331839F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2959641F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.3632287F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.367713F, 1, CubicBezierEasingFunction_0012());
                result.InsertKeyFrame(0.3811659F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4439462F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.5112107F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5156951F, 1, CubicBezierEasingFunction_0012());
                result.InsertKeyFrame(0.529148F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5919282F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.6591928F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6636772F, 1, CubicBezierEasingFunction_0012());
                result.InsertKeyFrame(0.67713F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7399103F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.8071749F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8116592F, 1, CubicBezierEasingFunction_0012());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0014()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(37170000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1479821F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2152466F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.2197309F, 1, CubicBezierEasingFunction_0014());
                result.InsertKeyFrame(0.2959641F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3632287F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.367713F, 1, CubicBezierEasingFunction_0014());
                result.InsertKeyFrame(0.4439462F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5112107F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.5156951F, 1, CubicBezierEasingFunction_0014());
                result.InsertKeyFrame(0.5919282F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6591928F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.6636772F, 1, CubicBezierEasingFunction_0014());
                result.InsertKeyFrame(0.7399103F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8071749F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.8116592F, 1, CubicBezierEasingFunction_0014());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0015()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(37170000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.08071749F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1479821F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.2152466F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2197309F, 1, CubicBezierEasingFunction_0012());
                result.InsertKeyFrame(0.2286996F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2959641F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.3632287F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.367713F, 1, CubicBezierEasingFunction_0012());
                result.InsertKeyFrame(0.3766816F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4439462F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.5112107F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5156951F, 1, CubicBezierEasingFunction_0012());
                result.InsertKeyFrame(0.5246637F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5919282F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.6591928F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6636772F, 1, CubicBezierEasingFunction_0012());
                result.InsertKeyFrame(0.6726457F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7399103F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.8071749F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8116592F, 1, CubicBezierEasingFunction_0012());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0016()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(37170000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1479821F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.206278F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.2152466F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2197309F, 1, CubicBezierEasingFunction_0016());
                result.InsertKeyFrame(0.2959641F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3542601F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.3632287F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.367713F, 1, CubicBezierEasingFunction_0016());
                result.InsertKeyFrame(0.4439462F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5022421F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.5112107F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5156951F, 1, CubicBezierEasingFunction_0016());
                result.InsertKeyFrame(0.5919282F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6502242F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.6591928F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6636772F, 1, CubicBezierEasingFunction_0016());
                result.InsertKeyFrame(0.7399103F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7982063F, 0, CubicBezierEasingFunction_0013());
                result.InsertKeyFrame(0.8071749F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8116592F, 1, CubicBezierEasingFunction_0016());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0017()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(37170000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.07174888F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1479821F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.2152466F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2197309F, 1, CubicBezierEasingFunction_0011());
                result.InsertKeyFrame(0.2959641F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.3632287F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.367713F, 1, CubicBezierEasingFunction_0011());
                result.InsertKeyFrame(0.4439462F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.5112107F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5156951F, 1, CubicBezierEasingFunction_0011());
                result.InsertKeyFrame(0.5919282F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.6591928F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6636772F, 1, CubicBezierEasingFunction_0011());
                result.InsertKeyFrame(0.7399103F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.8071749F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8116592F, 1, CubicBezierEasingFunction_0012());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0018()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(37170000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.08071749F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1434978F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.2152466F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2197309F, 1, CubicBezierEasingFunction_0012());
                result.InsertKeyFrame(0.2286996F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2914798F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.3632287F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.367713F, 1, CubicBezierEasingFunction_0012());
                result.InsertKeyFrame(0.3766816F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4394619F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.5112107F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5156951F, 1, CubicBezierEasingFunction_0012());
                result.InsertKeyFrame(0.5246637F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5874439F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.6591928F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6636772F, 1, CubicBezierEasingFunction_0012());
                result.InsertKeyFrame(0.6726457F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.735426F, 0, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.8071749F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8116592F, 1, CubicBezierEasingFunction_0012());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0019()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(37170000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8733453F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.9276468F, 3, CubicBezierEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0020()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(37170000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8741076F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.9211121F, 0.73102F, CubicBezierEasingFunction_0017());
                result.InsertKeyFrame(0.9730942F, 1, CubicBezierEasingFunction_0018());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0021()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(37170000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.9078341F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.9729103F, 0.86F, CubicBezierEasingFunction_0019());
                result.InsertKeyFrame(0.9932736F, 0.84F, CubicBezierEasingFunction_0020());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0022()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(37170000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8699552F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.9242485F, 3, CubicBezierEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0023()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(37170000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8699552F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.922556F, 0.73102F, CubicBezierEasingFunction_0017());
                result.InsertKeyFrame(0.9730942F, 1, CubicBezierEasingFunction_0021());
                return result;
            }

            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0024()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(37170000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.9079328F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.9726143F, 0.88F, CubicBezierEasingFunction_0019());
                result.InsertKeyFrame(0.9929758F, 0.84F, CubicBezierEasingFunction_0020());
                return result;
            }

            ShapeVisual ShapeVisual_0000()
            {
                var result = _c.CreateShapeVisual();
                result.Size = new Vector2(1920, 1080);
                var shapes = result.Shapes;
                //shapes.Add(CompositionContainerShape_0000());
                shapes.Add(CompositionContainerShape_0002());
                //shapes.Add(CompositionContainerShape_0012());
                //shapes.Add(CompositionContainerShape_0023());
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
                result.Duration = TimeSpan.FromTicks(37170000);
                result.InsertKeyFrame(0, new Vector2(1, 1), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.07589286F, new Vector2(1.05F, 1.05F), CubicBezierEasingFunction_0001());
                result.InsertKeyFrame(0.7767857F, new Vector2(1.05F, 1.05F), CubicBezierEasingFunction_0002());
                result.InsertKeyFrame(0.875F, new Vector2(1, 1), CubicBezierEasingFunction_0003());
                result.InsertKeyFrame(0.9508929F, new Vector2(1, 1), CubicBezierEasingFunction_0004());
                return result;
            }

            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0001()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.SetReferenceParameter("_", ContainerVisual_0000());
                result.Duration = TimeSpan.FromTicks(37170000);
                result.InsertKeyFrame(0, new Vector2(909.606F, 455.298F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.07174888F, new Vector2(909.606F, 455.298F), LinearEasingFunction_0000());
                result.InsertExpressionKeyFrame(0.0941703F, "(Pow(1 - _.t0, 3) * Vector2(909.606,455.298)) + (3 * Square((1 - _.t0)) * _.t0 * Vector2(909.7727,454.9647)) + (3 * (1 - _.t0) * Square(_.t0) * Vector2(910.7727,452.9647)) + (Pow(_.t0, 3) * Vector2(910.606,453.298))", StepEasingFunction_0000());
                result.InsertExpressionKeyFrame(0.1165918F, "(Pow(1 - _.t0, 3) * Vector2(910.606,453.298)) + (3 * Square((1 - _.t0)) * _.t0 * Vector2(910.4393,453.6313)) + (3 * (1 - _.t0) * Square(_.t0) * Vector2(908.9393,457.298)) + (Pow(_.t0, 3) * Vector2(908.606,457.298))", StepEasingFunction_0000());
                result.InsertExpressionKeyFrame(0.1434977F, "(Pow(1 - _.t0, 3) * Vector2(908.606,457.298)) + (3 * Square((1 - _.t0)) * _.t0 * Vector2(908.2727,457.298)) + (3 * (1 - _.t0) * Square(_.t0) * Vector2(908.4393,453.6313)) + (Pow(_.t0, 3) * Vector2(908.606,453.298))", StepEasingFunction_0000());
                result.InsertExpressionKeyFrame(0.1704035F, "(Pow(1 - _.t0, 3) * Vector2(908.606,453.298)) + (3 * Square((1 - _.t0)) * _.t0 * Vector2(908.7727,452.9647)) + (3 * (1 - _.t0) * Square(_.t0) * Vector2(909.106,455.298)) + (Pow(_.t0, 3) * Vector2(909.606,455.298))", StepEasingFunction_0000());
                result.InsertExpressionKeyFrame(0.192825F, "(Pow(1 - _.t0, 3) * Vector2(909.606,455.298)) + (3 * Square((1 - _.t0)) * _.t0 * Vector2(910.106,455.298)) + (3 * (1 - _.t0) * Square(_.t0) * Vector2(911.606,453.298)) + (Pow(_.t0, 3) * Vector2(911.606,453.298))", StepEasingFunction_0000());
                result.InsertExpressionKeyFrame(0.2197308F, "(Pow(1 - _.t0, 3) * Vector2(911.606,453.298)) + (3 * Square((1 - _.t0)) * _.t0 * Vector2(911.606,453.298)) + (3 * (1 - _.t0) * Square(_.t0) * Vector2(909.7727,455.298)) + (Pow(_.t0, 3) * Vector2(909.606,455.298))", StepEasingFunction_0000());
                result.InsertExpressionKeyFrame(0.2421524F, "(Pow(1 - _.t0, 3) * Vector2(909.606,455.298)) + (3 * Square((1 - _.t0)) * _.t0 * Vector2(909.4393,455.298)) + (3 * (1 - _.t0) * Square(_.t0) * Vector2(910.7727,452.9647)) + (Pow(_.t0, 3) * Vector2(910.606,453.298))", StepEasingFunction_0000());
                result.InsertExpressionKeyFrame(0.2645739F, "(Pow(1 - _.t0, 3) * Vector2(910.606,453.298)) + (3 * Square((1 - _.t0)) * _.t0 * Vector2(910.4393,453.6313)) + (3 * (1 - _.t0) * Square(_.t0) * Vector2(908.9393,457.298)) + (Pow(_.t0, 3) * Vector2(908.606,457.298))", StepEasingFunction_0000());
                result.InsertExpressionKeyFrame(0.2914797F, "(Pow(1 - _.t0, 3) * Vector2(908.606,457.298)) + (3 * Square((1 - _.t0)) * _.t0 * Vector2(908.2727,457.298)) + (3 * (1 - _.t0) * Square(_.t0) * Vector2(908.4393,453.6313)) + (Pow(_.t0, 3) * Vector2(908.606,453.298))", StepEasingFunction_0000());
                result.InsertExpressionKeyFrame(0.3183855F, "(Pow(1 - _.t0, 3) * Vector2(908.606,453.298)) + (3 * Square((1 - _.t0)) * _.t0 * Vector2(908.7727,452.9647)) + (3 * (1 - _.t0) * Square(_.t0) * Vector2(909.106,455.298)) + (Pow(_.t0, 3) * Vector2(909.606,455.298))", StepEasingFunction_0000());
                result.InsertExpressionKeyFrame(0.3408071F, "(Pow(1 - _.t0, 3) * Vector2(909.606,455.298)) + (3 * Square((1 - _.t0)) * _.t0 * Vector2(910.106,455.298)) + (3 * (1 - _.t0) * Square(_.t0) * Vector2(911.606,453.298)) + (Pow(_.t0, 3) * Vector2(911.606,453.298))", StepEasingFunction_0000());
                result.InsertExpressionKeyFrame(0.3677129F, "(Pow(1 - _.t0, 3) * Vector2(911.606,453.298)) + (3 * Square((1 - _.t0)) * _.t0 * Vector2(911.606,453.298)) + (3 * (1 - _.t0) * Square(_.t0) * Vector2(909.7727,455.298)) + (Pow(_.t0, 3) * Vector2(909.606,455.298))", StepEasingFunction_0000());
                result.InsertExpressionKeyFrame(0.3901344F, "(Pow(1 - _.t0, 3) * Vector2(909.606,455.298)) + (3 * Square((1 - _.t0)) * _.t0 * Vector2(909.4393,455.298)) + (3 * (1 - _.t0) * Square(_.t0) * Vector2(910.7727,452.9647)) + (Pow(_.t0, 3) * Vector2(910.606,453.298))", StepEasingFunction_0000());
                result.InsertExpressionKeyFrame(0.412556F, "(Pow(1 - _.t0, 3) * Vector2(910.606,453.298)) + (3 * Square((1 - _.t0)) * _.t0 * Vector2(910.4393,453.6313)) + (3 * (1 - _.t0) * Square(_.t0) * Vector2(908.9393,457.298)) + (Pow(_.t0, 3) * Vector2(908.606,457.298))", StepEasingFunction_0000());
                result.InsertExpressionKeyFrame(0.4394618F, "(Pow(1 - _.t0, 3) * Vector2(908.606,457.298)) + (3 * Square((1 - _.t0)) * _.t0 * Vector2(908.2727,457.298)) + (3 * (1 - _.t0) * Square(_.t0) * Vector2(908.4393,453.6313)) + (Pow(_.t0, 3) * Vector2(908.606,453.298))", StepEasingFunction_0000());
                result.InsertExpressionKeyFrame(0.4663676F, "(Pow(1 - _.t0, 3) * Vector2(908.606,453.298)) + (3 * Square((1 - _.t0)) * _.t0 * Vector2(908.7727,452.9647)) + (3 * (1 - _.t0) * Square(_.t0) * Vector2(909.106,455.298)) + (Pow(_.t0, 3) * Vector2(909.606,455.298))", StepEasingFunction_0000());
                result.InsertExpressionKeyFrame(0.4887891F, "(Pow(1 - _.t0, 3) * Vector2(909.606,455.298)) + (3 * Square((1 - _.t0)) * _.t0 * Vector2(910.106,455.298)) + (3 * (1 - _.t0) * Square(_.t0) * Vector2(911.606,453.298)) + (Pow(_.t0, 3) * Vector2(911.606,453.298))", StepEasingFunction_0000());
                result.InsertExpressionKeyFrame(0.515695F, "(Pow(1 - _.t0, 3) * Vector2(911.606,453.298)) + (3 * Square((1 - _.t0)) * _.t0 * Vector2(911.606,453.298)) + (3 * (1 - _.t0) * Square(_.t0) * Vector2(909.7727,455.298)) + (Pow(_.t0, 3) * Vector2(909.606,455.298))", StepEasingFunction_0000());
                result.InsertExpressionKeyFrame(0.5381165F, "(Pow(1 - _.t0, 3) * Vector2(909.606,455.298)) + (3 * Square((1 - _.t0)) * _.t0 * Vector2(909.4393,455.298)) + (3 * (1 - _.t0) * Square(_.t0) * Vector2(910.7727,452.9647)) + (Pow(_.t0, 3) * Vector2(910.606,453.298))", StepEasingFunction_0000());
                result.InsertExpressionKeyFrame(0.560538F, "(Pow(1 - _.t0, 3) * Vector2(910.606,453.298)) + (3 * Square((1 - _.t0)) * _.t0 * Vector2(910.4393,453.6313)) + (3 * (1 - _.t0) * Square(_.t0) * Vector2(908.9393,457.298)) + (Pow(_.t0, 3) * Vector2(908.606,457.298))", StepEasingFunction_0000());
                result.InsertExpressionKeyFrame(0.5874438F, "(Pow(1 - _.t0, 3) * Vector2(908.606,457.298)) + (3 * Square((1 - _.t0)) * _.t0 * Vector2(908.2727,457.298)) + (3 * (1 - _.t0) * Square(_.t0) * Vector2(908.4393,453.6313)) + (Pow(_.t0, 3) * Vector2(908.606,453.298))", StepEasingFunction_0000());
                result.InsertExpressionKeyFrame(0.6143497F, "(Pow(1 - _.t0, 3) * Vector2(908.606,453.298)) + (3 * Square((1 - _.t0)) * _.t0 * Vector2(908.7727,452.9647)) + (3 * (1 - _.t0) * Square(_.t0) * Vector2(909.106,455.298)) + (Pow(_.t0, 3) * Vector2(909.606,455.298))", StepEasingFunction_0000());
                result.InsertExpressionKeyFrame(0.6367712F, "(Pow(1 - _.t0, 3) * Vector2(909.606,455.298)) + (3 * Square((1 - _.t0)) * _.t0 * Vector2(910.106,455.298)) + (3 * (1 - _.t0) * Square(_.t0) * Vector2(911.606,453.298)) + (Pow(_.t0, 3) * Vector2(911.606,453.298))", StepEasingFunction_0000());
                result.InsertExpressionKeyFrame(0.663677F, "(Pow(1 - _.t0, 3) * Vector2(911.606,453.298)) + (3 * Square((1 - _.t0)) * _.t0 * Vector2(911.606,453.298)) + (3 * (1 - _.t0) * Square(_.t0) * Vector2(909.7727,455.298)) + (Pow(_.t0, 3) * Vector2(909.606,455.298))", StepEasingFunction_0000());
                result.InsertExpressionKeyFrame(0.6860986F, "(Pow(1 - _.t0, 3) * Vector2(909.606,455.298)) + (3 * Square((1 - _.t0)) * _.t0 * Vector2(909.4393,455.298)) + (3 * (1 - _.t0) * Square(_.t0) * Vector2(910.7727,452.9647)) + (Pow(_.t0, 3) * Vector2(910.606,453.298))", StepEasingFunction_0000());
                result.InsertExpressionKeyFrame(0.7085201F, "(Pow(1 - _.t0, 3) * Vector2(910.606,453.298)) + (3 * Square((1 - _.t0)) * _.t0 * Vector2(910.4393,453.6313)) + (3 * (1 - _.t0) * Square(_.t0) * Vector2(908.9393,457.298)) + (Pow(_.t0, 3) * Vector2(908.606,457.298))", StepEasingFunction_0000());
                result.InsertExpressionKeyFrame(0.7354259F, "(Pow(1 - _.t0, 3) * Vector2(908.606,457.298)) + (3 * Square((1 - _.t0)) * _.t0 * Vector2(908.2727,457.298)) + (3 * (1 - _.t0) * Square(_.t0) * Vector2(908.4393,453.6313)) + (Pow(_.t0, 3) * Vector2(908.606,453.298))", StepEasingFunction_0000());
                result.InsertExpressionKeyFrame(0.7623317F, "(Pow(1 - _.t0, 3) * Vector2(908.606,453.298)) + (3 * Square((1 - _.t0)) * _.t0 * Vector2(908.7727,452.9647)) + (3 * (1 - _.t0) * Square(_.t0) * Vector2(909.106,455.298)) + (Pow(_.t0, 3) * Vector2(909.606,455.298))", StepEasingFunction_0000());
                result.InsertExpressionKeyFrame(0.7847533F, "(Pow(1 - _.t0, 3) * Vector2(909.606,455.298)) + (3 * Square((1 - _.t0)) * _.t0 * Vector2(910.106,455.298)) + (3 * (1 - _.t0) * Square(_.t0) * Vector2(911.606,453.298)) + (Pow(_.t0, 3) * Vector2(911.606,453.298))", StepEasingFunction_0000());
                result.InsertExpressionKeyFrame(0.8116591F, "(Pow(1 - _.t0, 3) * Vector2(911.606,453.298)) + (3 * Square((1 - _.t0)) * _.t0 * Vector2(911.606,453.298)) + (3 * (1 - _.t0) * Square(_.t0) * Vector2(909.9393,454.9647)) + (Pow(_.t0, 3) * Vector2(909.606,455.298))", StepEasingFunction_0000());
                result.InsertKeyFrame(0.8116592F, new Vector2(909.606F, 455.298F), StepEasingFunction_0000());
                return result;
            }

            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0002()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(37170000);
                result.InsertKeyFrame(0, new Vector2(1, 1), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.07589286F, new Vector2(0.85F, 0.85F), CubicBezierEasingFunction_0005());
                result.InsertKeyFrame(0.8125F, new Vector2(0.85F, 0.85F), CubicBezierEasingFunction_0006());
                result.InsertKeyFrame(0.875F, new Vector2(0, 0), CubicBezierEasingFunction_0007());
                result.InsertKeyFrame(0.8794643F, new Vector2(0, 0), CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.9419643F, new Vector2(1, 1), CubicBezierEasingFunction_0009());
                return result;
            }

        }
    }
}
