using Lottie;
using Microsoft.Graphics.Canvas.Geometry;
using System;
using System.Numerics;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;

namespace Compositions
{
    sealed class UiFeedbackAnimations : ICompositionSource
    {
        public void CreateInstance(
            Compositor compositor,
            out Visual rootVisual,
            out Vector2 size,
            out CompositionPropertySet progressPropertySet,
            out TimeSpan duration)
        {
            rootVisual = Instantiator.InstantiateComposition(compositor);
            size = new Vector2(500, 500);
            progressPropertySet = rootVisual.Properties;
            duration = TimeSpan.FromTicks(62170000);
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
            ColorKeyFrameAnimation _colorKeyFrameAnimation_0001;
            CompositionColorBrush _compositionColorBrush_0001;
            CompositionColorBrush _compositionColorBrush_0002;
            ContainerVisual _containerVisual_0000;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0003;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0007;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0008;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0009;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0010;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0011;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0012;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0015;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0016;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0017;
            ExpressionAnimation _expressionAnimation_0000;
            LinearEasingFunction _linearEasingFunction_0000;
            ScalarKeyFrameAnimation _scalarKeyFrameAnimation_0000;
            ScalarKeyFrameAnimation _scalarKeyFrameAnimation_0001;
            ScalarKeyFrameAnimation _scalarKeyFrameAnimation_0002;
            ScalarKeyFrameAnimation _scalarKeyFrameAnimation_0003;
            ScalarKeyFrameAnimation _scalarKeyFrameAnimation_0006;
            ScalarKeyFrameAnimation _scalarKeyFrameAnimation_0007;
            ScalarKeyFrameAnimation _scalarKeyFrameAnimation_0014;
            ScalarKeyFrameAnimation _scalarKeyFrameAnimation_0015;
            ScalarKeyFrameAnimation _scalarKeyFrameAnimation_0016;
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
                    builder.BeginFigure(new Vector2(-36, -95));
                    builder.AddCubicBezier(new Vector2(-6.109F, -111.25F), new Vector2(53.672F, -143.75F), new Vector2(83.5F, -160));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0017()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-47, -104.25F));
                    builder.AddCubicBezier(new Vector2(-45.764F, -132.127F), new Vector2(-43.293F, -187.88F), new Vector2(-42, -215.75F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0018()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-62.75F, -98));
                    builder.AddCubicBezier(new Vector2(-65.574F, -100.161F), new Vector2(-71.223F, -104.483F), new Vector2(-75.639F, -107.47F));
                    builder.AddCubicBezier(new Vector2(-108.56F, -129.736F), new Vector2(-152.687F, -159.079F), new Vector2(-174.75F, -173.75F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0019()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-57.75F, -77.25F));
                    builder.AddCubicBezier(new Vector2(-75.295F, -64.375F), new Vector2(-110.386F, -38.624F), new Vector2(-128, -25.75F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0020()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-41.75F, -76.75F));
                    builder.AddCubicBezier(new Vector2(-32.172F, -63.811F), new Vector2(-13.016F, -37.932F), new Vector2(-3.5F, -25));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0021()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-64.25F, -86.5F));
                    builder.AddCubicBezier(new Vector2(-62.719F, -83.536F), new Vector2(-57.19F, -72.83F), new Vector2(-54.75F, -74.25F));
                    builder.AddCubicBezier(new Vector2(-47.164F, -78.664F), new Vector2(-31.055F, -99.888F), new Vector2(-23, -110.5F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0022()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(20.5F, -20.5F));
                    builder.AddCubicBezier(new Vector2(20.5F, -20.5F), new Vector2(-20.5F, -20.5F), new Vector2(-20.5F, -20.5F));
                    builder.AddCubicBezier(new Vector2(-20.5F, -20.5F), new Vector2(-20.5F, 20.5F), new Vector2(-20.5F, 20.5F));
                    builder.AddCubicBezier(new Vector2(-20.5F, 20.5F), new Vector2(20.5F, 20.5F), new Vector2(20.5F, 20.5F));
                    builder.AddCubicBezier(new Vector2(20.5F, 20.5F), new Vector2(20.5F, -20.5F), new Vector2(20.5F, -20.5F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0023()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(20.5F, -20.5F));
                    builder.AddCubicBezier(new Vector2(20.5F, -20.5F), new Vector2(-20.5F, -20.5F), new Vector2(-20.5F, -20.5F));
                    builder.AddCubicBezier(new Vector2(-20.5F, -20.5F), new Vector2(-20.5F, 20.5F), new Vector2(-20.5F, 20.5F));
                    builder.AddCubicBezier(new Vector2(-20.5F, 20.5F), new Vector2(20.5F, 20.5F), new Vector2(20.5F, 20.5F));
                    builder.AddCubicBezier(new Vector2(20.5F, 20.5F), new Vector2(20.5F, -20.5F), new Vector2(20.5F, -20.5F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0024()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(20.5F, -20.5F));
                    builder.AddCubicBezier(new Vector2(20.5F, -20.5F), new Vector2(-20.5F, -20.5F), new Vector2(-20.5F, -20.5F));
                    builder.AddCubicBezier(new Vector2(-20.5F, -20.5F), new Vector2(-20.5F, 20.5F), new Vector2(-20.5F, 20.5F));
                    builder.AddCubicBezier(new Vector2(-20.5F, 20.5F), new Vector2(20.5F, 20.5F), new Vector2(20.5F, 20.5F));
                    builder.AddCubicBezier(new Vector2(20.5F, 20.5F), new Vector2(20.5F, -20.5F), new Vector2(20.5F, -20.5F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0025()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(5.533F, -39.656F));
                    builder.AddCubicBezier(new Vector2(5.533F, -39.656F), new Vector2(-35.467F, 1.344F), new Vector2(-35.467F, 1.344F));
                    builder.AddCubicBezier(new Vector2(-35.467F, 1.344F), new Vector2(20.5F, 20.5F), new Vector2(20.5F, 20.5F));
                    builder.AddCubicBezier(new Vector2(20.5F, 20.5F), new Vector2(5.533F, -39.656F), new Vector2(5.533F, -39.656F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0026()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(5.533F, -39.656F));
                    builder.AddCubicBezier(new Vector2(5.533F, -39.656F), new Vector2(-35.467F, 1.344F), new Vector2(-35.467F, 1.344F));
                    builder.AddCubicBezier(new Vector2(-35.467F, 1.344F), new Vector2(20.5F, 20.5F), new Vector2(20.5F, 20.5F));
                    builder.AddCubicBezier(new Vector2(20.5F, 20.5F), new Vector2(5.533F, -39.656F), new Vector2(5.533F, -39.656F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0027()
            {
                var result = CanvasGeometry_0028().
                    CombineWith(CanvasGeometry_0029(),
                    Matrix3x2.Identity,
                    CanvasGeometryCombine.Xor);
                return result;
            }
            
            CanvasGeometry CanvasGeometry_0028()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(169.273F, -4.766F));
                    builder.AddCubicBezier(new Vector2(169.372F, -5.464F), new Vector2(169.633F, -6.029F), new Vector2(170.055F, -6.461F));
                    builder.AddCubicBezier(new Vector2(170.477F, -6.893F), new Vector2(170.99F, -7.109F), new Vector2(171.594F, -7.109F));
                    builder.AddCubicBezier(new Vector2(172.219F, -7.109F), new Vector2(172.707F, -6.903F), new Vector2(173.059F, -6.492F));
                    builder.AddCubicBezier(new Vector2(173.411F, -6.081F), new Vector2(173.589F, -5.506F), new Vector2(173.594F, -4.766F));
                    builder.AddCubicBezier(new Vector2(173.594F, -4.766F), new Vector2(169.273F, -4.766F), new Vector2(169.273F, -4.766F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0029()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(174.906F, -4.352F));
                    builder.AddCubicBezier(new Vector2(174.906F, -5.555F), new Vector2(174.62F, -6.495F), new Vector2(174.047F, -7.172F));
                    builder.AddCubicBezier(new Vector2(173.474F, -7.849F), new Vector2(172.664F, -8.188F), new Vector2(171.617F, -8.188F));
                    builder.AddCubicBezier(new Vector2(170.57F, -8.188F), new Vector2(169.694F, -7.796F), new Vector2(168.988F, -7.012F));
                    builder.AddCubicBezier(new Vector2(168.282F, -6.228F), new Vector2(167.93F, -5.214F), new Vector2(167.93F, -3.969F));
                    builder.AddCubicBezier(new Vector2(167.93F, -2.651F), new Vector2(168.252F, -1.629F), new Vector2(168.898F, -0.902F));
                    builder.AddCubicBezier(new Vector2(169.544F, -0.175F), new Vector2(170.433F, 0.188F), new Vector2(171.563F, 0.188F));
                    builder.AddCubicBezier(new Vector2(172.719F, 0.188F), new Vector2(173.649F, -0.068F), new Vector2(174.352F, -0.578F));
                    builder.AddCubicBezier(new Vector2(174.352F, -0.578F), new Vector2(174.352F, -1.781F), new Vector2(174.352F, -1.781F));
                    builder.AddCubicBezier(new Vector2(173.597F, -1.187F), new Vector2(172.768F, -0.891F), new Vector2(171.867F, -0.891F));
                    builder.AddCubicBezier(new Vector2(171.065F, -0.891F), new Vector2(170.435F, -1.133F), new Vector2(169.977F, -1.617F));
                    builder.AddCubicBezier(new Vector2(169.519F, -2.101F), new Vector2(169.279F, -2.789F), new Vector2(169.258F, -3.68F));
                    builder.AddCubicBezier(new Vector2(169.258F, -3.68F), new Vector2(174.906F, -3.68F), new Vector2(174.906F, -3.68F));
                    builder.AddCubicBezier(new Vector2(174.906F, -3.68F), new Vector2(174.906F, -4.352F), new Vector2(174.906F, -4.352F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0030()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(167.086F, -8.031F));
                    builder.AddCubicBezier(new Vector2(166.909F, -8.104F), new Vector2(166.653F, -8.141F), new Vector2(166.32F, -8.141F));
                    builder.AddCubicBezier(new Vector2(165.856F, -8.141F), new Vector2(165.438F, -7.983F), new Vector2(165.063F, -7.668F));
                    builder.AddCubicBezier(new Vector2(164.688F, -7.353F), new Vector2(164.409F, -6.915F), new Vector2(164.227F, -6.352F));
                    builder.AddCubicBezier(new Vector2(164.227F, -6.352F), new Vector2(164.195F, -6.352F), new Vector2(164.195F, -6.352F));
                    builder.AddCubicBezier(new Vector2(164.195F, -6.352F), new Vector2(164.195F, -8), new Vector2(164.195F, -8));
                    builder.AddCubicBezier(new Vector2(164.195F, -8), new Vector2(162.914F, -8), new Vector2(162.914F, -8));
                    builder.AddCubicBezier(new Vector2(162.914F, -8), new Vector2(162.914F, 0), new Vector2(162.914F, 0));
                    builder.AddCubicBezier(new Vector2(162.914F, 0), new Vector2(164.195F, 0), new Vector2(164.195F, 0));
                    builder.AddCubicBezier(new Vector2(164.195F, 0), new Vector2(164.195F, -4.078F), new Vector2(164.195F, -4.078F));
                    builder.AddCubicBezier(new Vector2(164.195F, -4.969F), new Vector2(164.379F, -5.672F), new Vector2(164.746F, -6.188F));
                    builder.AddCubicBezier(new Vector2(165.113F, -6.704F), new Vector2(165.57F, -6.961F), new Vector2(166.117F, -6.961F));
                    builder.AddCubicBezier(new Vector2(166.539F, -6.961F), new Vector2(166.862F, -6.875F), new Vector2(167.086F, -6.703F));
                    builder.AddCubicBezier(new Vector2(167.086F, -6.703F), new Vector2(167.086F, -8.031F), new Vector2(167.086F, -8.031F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0031()
            {
                var result = CanvasGeometry_0032().
                    CombineWith(CanvasGeometry_0033(),
                    Matrix3x2.Identity,
                    CanvasGeometryCombine.Xor);
                return result;
            }
            
            CanvasGeometry CanvasGeometry_0032()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(155.344F, -4.766F));
                    builder.AddCubicBezier(new Vector2(155.443F, -5.464F), new Vector2(155.703F, -6.029F), new Vector2(156.125F, -6.461F));
                    builder.AddCubicBezier(new Vector2(156.547F, -6.893F), new Vector2(157.06F, -7.109F), new Vector2(157.664F, -7.109F));
                    builder.AddCubicBezier(new Vector2(158.289F, -7.109F), new Vector2(158.777F, -6.903F), new Vector2(159.129F, -6.492F));
                    builder.AddCubicBezier(new Vector2(159.481F, -6.081F), new Vector2(159.659F, -5.506F), new Vector2(159.664F, -4.766F));
                    builder.AddCubicBezier(new Vector2(159.664F, -4.766F), new Vector2(155.344F, -4.766F), new Vector2(155.344F, -4.766F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0033()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(160.977F, -4.352F));
                    builder.AddCubicBezier(new Vector2(160.977F, -5.555F), new Vector2(160.69F, -6.495F), new Vector2(160.117F, -7.172F));
                    builder.AddCubicBezier(new Vector2(159.544F, -7.849F), new Vector2(158.735F, -8.188F), new Vector2(157.688F, -8.188F));
                    builder.AddCubicBezier(new Vector2(156.641F, -8.188F), new Vector2(155.765F, -7.796F), new Vector2(155.059F, -7.012F));
                    builder.AddCubicBezier(new Vector2(154.353F, -6.228F), new Vector2(154, -5.214F), new Vector2(154, -3.969F));
                    builder.AddCubicBezier(new Vector2(154, -2.651F), new Vector2(154.323F, -1.629F), new Vector2(154.969F, -0.902F));
                    builder.AddCubicBezier(new Vector2(155.615F, -0.175F), new Vector2(156.503F, 0.188F), new Vector2(157.633F, 0.188F));
                    builder.AddCubicBezier(new Vector2(158.789F, 0.188F), new Vector2(159.719F, -0.068F), new Vector2(160.422F, -0.578F));
                    builder.AddCubicBezier(new Vector2(160.422F, -0.578F), new Vector2(160.422F, -1.781F), new Vector2(160.422F, -1.781F));
                    builder.AddCubicBezier(new Vector2(159.667F, -1.187F), new Vector2(158.839F, -0.891F), new Vector2(157.938F, -0.891F));
                    builder.AddCubicBezier(new Vector2(157.136F, -0.891F), new Vector2(156.505F, -1.133F), new Vector2(156.047F, -1.617F));
                    builder.AddCubicBezier(new Vector2(155.589F, -2.101F), new Vector2(155.349F, -2.789F), new Vector2(155.328F, -3.68F));
                    builder.AddCubicBezier(new Vector2(155.328F, -3.68F), new Vector2(160.977F, -3.68F), new Vector2(160.977F, -3.68F));
                    builder.AddCubicBezier(new Vector2(160.977F, -3.68F), new Vector2(160.977F, -4.352F), new Vector2(160.977F, -4.352F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0034()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(152.133F, -4.93F));
                    builder.AddCubicBezier(new Vector2(152.133F, -7.102F), new Vector2(151.232F, -8.188F), new Vector2(149.43F, -8.188F));
                    builder.AddCubicBezier(new Vector2(148.295F, -8.188F), new Vector2(147.42F, -7.682F), new Vector2(146.805F, -6.672F));
                    builder.AddCubicBezier(new Vector2(146.805F, -6.672F), new Vector2(146.773F, -6.672F), new Vector2(146.773F, -6.672F));
                    builder.AddCubicBezier(new Vector2(146.773F, -6.672F), new Vector2(146.773F, -11.844F), new Vector2(146.773F, -11.844F));
                    builder.AddCubicBezier(new Vector2(146.773F, -11.844F), new Vector2(145.492F, -11.844F), new Vector2(145.492F, -11.844F));
                    builder.AddCubicBezier(new Vector2(145.492F, -11.844F), new Vector2(145.492F, 0), new Vector2(145.492F, 0));
                    builder.AddCubicBezier(new Vector2(145.492F, 0), new Vector2(146.773F, 0), new Vector2(146.773F, 0));
                    builder.AddCubicBezier(new Vector2(146.773F, 0), new Vector2(146.773F, -4.531F), new Vector2(146.773F, -4.531F));
                    builder.AddCubicBezier(new Vector2(146.773F, -5.286F), new Vector2(146.987F, -5.905F), new Vector2(147.414F, -6.387F));
                    builder.AddCubicBezier(new Vector2(147.841F, -6.869F), new Vector2(148.367F, -7.109F), new Vector2(148.992F, -7.109F));
                    builder.AddCubicBezier(new Vector2(150.232F, -7.109F), new Vector2(150.852F, -6.276F), new Vector2(150.852F, -4.609F));
                    builder.AddCubicBezier(new Vector2(150.852F, -4.609F), new Vector2(150.852F, 0), new Vector2(150.852F, 0));
                    builder.AddCubicBezier(new Vector2(150.852F, 0), new Vector2(152.133F, 0), new Vector2(152.133F, 0));
                    builder.AddCubicBezier(new Vector2(152.133F, 0), new Vector2(152.133F, -4.93F), new Vector2(152.133F, -4.93F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0035()
            {
                var result = CanvasGeometry_0036().
                    CombineWith(CanvasGeometry_0037(),
                    Matrix3x2.Identity,
                    CanvasGeometryCombine.Xor);
                return result;
            }
            
            CanvasGeometry CanvasGeometry_0036()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(133.539F, -4.766F));
                    builder.AddCubicBezier(new Vector2(133.638F, -5.464F), new Vector2(133.898F, -6.029F), new Vector2(134.32F, -6.461F));
                    builder.AddCubicBezier(new Vector2(134.742F, -6.893F), new Vector2(135.255F, -7.109F), new Vector2(135.859F, -7.109F));
                    builder.AddCubicBezier(new Vector2(136.484F, -7.109F), new Vector2(136.972F, -6.903F), new Vector2(137.324F, -6.492F));
                    builder.AddCubicBezier(new Vector2(137.676F, -6.081F), new Vector2(137.854F, -5.506F), new Vector2(137.859F, -4.766F));
                    builder.AddCubicBezier(new Vector2(137.859F, -4.766F), new Vector2(133.539F, -4.766F), new Vector2(133.539F, -4.766F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0037()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(139.172F, -4.352F));
                    builder.AddCubicBezier(new Vector2(139.172F, -5.555F), new Vector2(138.886F, -6.495F), new Vector2(138.313F, -7.172F));
                    builder.AddCubicBezier(new Vector2(137.74F, -7.849F), new Vector2(136.93F, -8.188F), new Vector2(135.883F, -8.188F));
                    builder.AddCubicBezier(new Vector2(134.836F, -8.188F), new Vector2(133.96F, -7.796F), new Vector2(133.254F, -7.012F));
                    builder.AddCubicBezier(new Vector2(132.548F, -6.228F), new Vector2(132.195F, -5.214F), new Vector2(132.195F, -3.969F));
                    builder.AddCubicBezier(new Vector2(132.195F, -2.651F), new Vector2(132.518F, -1.629F), new Vector2(133.164F, -0.902F));
                    builder.AddCubicBezier(new Vector2(133.81F, -0.175F), new Vector2(134.698F, 0.188F), new Vector2(135.828F, 0.188F));
                    builder.AddCubicBezier(new Vector2(136.984F, 0.188F), new Vector2(137.914F, -0.068F), new Vector2(138.617F, -0.578F));
                    builder.AddCubicBezier(new Vector2(138.617F, -0.578F), new Vector2(138.617F, -1.781F), new Vector2(138.617F, -1.781F));
                    builder.AddCubicBezier(new Vector2(137.862F, -1.187F), new Vector2(137.034F, -0.891F), new Vector2(136.133F, -0.891F));
                    builder.AddCubicBezier(new Vector2(135.331F, -0.891F), new Vector2(134.7F, -1.133F), new Vector2(134.242F, -1.617F));
                    builder.AddCubicBezier(new Vector2(133.784F, -2.101F), new Vector2(133.544F, -2.789F), new Vector2(133.523F, -3.68F));
                    builder.AddCubicBezier(new Vector2(133.523F, -3.68F), new Vector2(139.172F, -3.68F), new Vector2(139.172F, -3.68F));
                    builder.AddCubicBezier(new Vector2(139.172F, -3.68F), new Vector2(139.172F, -4.352F), new Vector2(139.172F, -4.352F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0038()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(130.148F, -11.844F));
                    builder.AddCubicBezier(new Vector2(130.148F, -11.844F), new Vector2(128.867F, -11.844F), new Vector2(128.867F, -11.844F));
                    builder.AddCubicBezier(new Vector2(128.867F, -11.844F), new Vector2(128.867F, 0), new Vector2(128.867F, 0));
                    builder.AddCubicBezier(new Vector2(128.867F, 0), new Vector2(130.148F, 0), new Vector2(130.148F, 0));
                    builder.AddCubicBezier(new Vector2(130.148F, 0), new Vector2(130.148F, -11.844F), new Vector2(130.148F, -11.844F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0039()
            {
                var result = CanvasGeometry_0040().
                    CombineWith(CanvasGeometry_0041(),
                    Matrix3x2.Identity,
                    CanvasGeometryCombine.Xor);
                return result;
            }
            
            CanvasGeometry CanvasGeometry_0040()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(126.273F, -8));
                    builder.AddCubicBezier(new Vector2(126.273F, -8), new Vector2(124.992F, -8), new Vector2(124.992F, -8));
                    builder.AddCubicBezier(new Vector2(124.992F, -8), new Vector2(124.992F, 0), new Vector2(124.992F, 0));
                    builder.AddCubicBezier(new Vector2(124.992F, 0), new Vector2(126.273F, 0), new Vector2(126.273F, 0));
                    builder.AddCubicBezier(new Vector2(126.273F, 0), new Vector2(126.273F, -8), new Vector2(126.273F, -8));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0041()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(126.246F, -10.273F));
                    builder.AddCubicBezier(new Vector2(126.41F, -10.434F), new Vector2(126.492F, -10.63F), new Vector2(126.492F, -10.859F));
                    builder.AddCubicBezier(new Vector2(126.492F, -11.099F), new Vector2(126.41F, -11.298F), new Vector2(126.246F, -11.457F));
                    builder.AddCubicBezier(new Vector2(126.082F, -11.616F), new Vector2(125.882F, -11.695F), new Vector2(125.648F, -11.695F));
                    builder.AddCubicBezier(new Vector2(125.419F, -11.695F), new Vector2(125.224F, -11.616F), new Vector2(125.063F, -11.457F));
                    builder.AddCubicBezier(new Vector2(124.902F, -11.298F), new Vector2(124.82F, -11.099F), new Vector2(124.82F, -10.859F));
                    builder.AddCubicBezier(new Vector2(124.82F, -10.619F), new Vector2(124.902F, -10.422F), new Vector2(125.063F, -10.266F));
                    builder.AddCubicBezier(new Vector2(125.224F, -10.11F), new Vector2(125.419F, -10.031F), new Vector2(125.648F, -10.031F));
                    builder.AddCubicBezier(new Vector2(125.882F, -10.031F), new Vector2(126.082F, -10.112F), new Vector2(126.246F, -10.273F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0042()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(123.938F, -11.875F));
                    builder.AddCubicBezier(new Vector2(123.709F, -11.969F), new Vector2(123.399F, -12.016F), new Vector2(123.008F, -12.016F));
                    builder.AddCubicBezier(new Vector2(122.284F, -12.016F), new Vector2(121.679F, -11.772F), new Vector2(121.195F, -11.285F));
                    builder.AddCubicBezier(new Vector2(120.711F, -10.798F), new Vector2(120.469F, -10.136F), new Vector2(120.469F, -9.297F));
                    builder.AddCubicBezier(new Vector2(120.469F, -9.297F), new Vector2(120.469F, -8), new Vector2(120.469F, -8));
                    builder.AddCubicBezier(new Vector2(120.469F, -8), new Vector2(119.102F, -8), new Vector2(119.102F, -8));
                    builder.AddCubicBezier(new Vector2(119.102F, -8), new Vector2(119.102F, -6.906F), new Vector2(119.102F, -6.906F));
                    builder.AddCubicBezier(new Vector2(119.102F, -6.906F), new Vector2(120.469F, -6.906F), new Vector2(120.469F, -6.906F));
                    builder.AddCubicBezier(new Vector2(120.469F, -6.906F), new Vector2(120.469F, 0), new Vector2(120.469F, 0));
                    builder.AddCubicBezier(new Vector2(120.469F, 0), new Vector2(121.742F, 0), new Vector2(121.742F, 0));
                    builder.AddCubicBezier(new Vector2(121.742F, 0), new Vector2(121.742F, -6.906F), new Vector2(121.742F, -6.906F));
                    builder.AddCubicBezier(new Vector2(121.742F, -6.906F), new Vector2(123.617F, -6.906F), new Vector2(123.617F, -6.906F));
                    builder.AddCubicBezier(new Vector2(123.617F, -6.906F), new Vector2(123.617F, -8), new Vector2(123.617F, -8));
                    builder.AddCubicBezier(new Vector2(123.617F, -8), new Vector2(121.742F, -8), new Vector2(121.742F, -8));
                    builder.AddCubicBezier(new Vector2(121.742F, -8), new Vector2(121.742F, -9.234F), new Vector2(121.742F, -9.234F));
                    builder.AddCubicBezier(new Vector2(121.742F, -10.364F), new Vector2(122.19F, -10.93F), new Vector2(123.086F, -10.93F));
                    builder.AddCubicBezier(new Vector2(123.404F, -10.93F), new Vector2(123.688F, -10.86F), new Vector2(123.938F, -10.719F));
                    builder.AddCubicBezier(new Vector2(123.938F, -10.719F), new Vector2(123.938F, -11.875F), new Vector2(123.938F, -11.875F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0043()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(112.836F, -11.203F));
                    builder.AddCubicBezier(new Vector2(112.836F, -11.203F), new Vector2(111.523F, -11.203F), new Vector2(111.523F, -11.203F));
                    builder.AddCubicBezier(new Vector2(111.523F, -11.203F), new Vector2(111.523F, -3.313F), new Vector2(111.523F, -3.313F));
                    builder.AddCubicBezier(new Vector2(111.523F, -2.537F), new Vector2(111.55F, -1.987F), new Vector2(111.602F, -1.664F));
                    builder.AddCubicBezier(new Vector2(111.602F, -1.664F), new Vector2(111.57F, -1.664F), new Vector2(111.57F, -1.664F));
                    builder.AddCubicBezier(new Vector2(111.502F, -1.799F), new Vector2(111.351F, -2.049F), new Vector2(111.117F, -2.414F));
                    builder.AddCubicBezier(new Vector2(111.117F, -2.414F), new Vector2(105.508F, -11.203F), new Vector2(105.508F, -11.203F));
                    builder.AddCubicBezier(new Vector2(105.508F, -11.203F), new Vector2(103.805F, -11.203F), new Vector2(103.805F, -11.203F));
                    builder.AddCubicBezier(new Vector2(103.805F, -11.203F), new Vector2(103.805F, 0), new Vector2(103.805F, 0));
                    builder.AddCubicBezier(new Vector2(103.805F, 0), new Vector2(105.117F, 0), new Vector2(105.117F, 0));
                    builder.AddCubicBezier(new Vector2(105.117F, 0), new Vector2(105.117F, -8.094F), new Vector2(105.117F, -8.094F));
                    builder.AddCubicBezier(new Vector2(105.117F, -8.88F), new Vector2(105.097F, -9.393F), new Vector2(105.055F, -9.633F));
                    builder.AddCubicBezier(new Vector2(105.055F, -9.633F), new Vector2(105.102F, -9.633F), new Vector2(105.102F, -9.633F));
                    builder.AddCubicBezier(new Vector2(105.196F, -9.388F), new Vector2(105.315F, -9.154F), new Vector2(105.461F, -8.93F));
                    builder.AddCubicBezier(new Vector2(105.461F, -8.93F), new Vector2(111.227F, 0), new Vector2(111.227F, 0));
                    builder.AddCubicBezier(new Vector2(111.227F, 0), new Vector2(112.836F, 0), new Vector2(112.836F, 0));
                    builder.AddCubicBezier(new Vector2(112.836F, 0), new Vector2(112.836F, -11.203F), new Vector2(112.836F, -11.203F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0044()
            {
                var result = CanvasGeometry_0045().
                    CombineWith(CanvasGeometry_0046(),
                    Matrix3x2.Identity,
                    CanvasGeometryCombine.Xor);
                return result;
            }
            
            CanvasGeometry CanvasGeometry_0045()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(99.195F, -8.992F));
                    builder.AddCubicBezier(new Vector2(99.883F, -8.185F), new Vector2(100.227F, -7.042F), new Vector2(100.227F, -5.563F));
                    builder.AddCubicBezier(new Vector2(100.227F, -4.12F), new Vector2(99.872F, -2.997F), new Vector2(99.164F, -2.195F));
                    builder.AddCubicBezier(new Vector2(98.456F, -1.393F), new Vector2(97.487F, -0.992F), new Vector2(96.258F, -0.992F));
                    builder.AddCubicBezier(new Vector2(95.107F, -0.992F), new Vector2(94.173F, -1.413F), new Vector2(93.457F, -2.254F));
                    builder.AddCubicBezier(new Vector2(92.741F, -3.095F), new Vector2(92.383F, -4.206F), new Vector2(92.383F, -5.586F));
                    builder.AddCubicBezier(new Vector2(92.383F, -6.966F), new Vector2(92.75F, -8.081F), new Vector2(93.484F, -8.93F));
                    builder.AddCubicBezier(new Vector2(94.218F, -9.779F), new Vector2(95.175F, -10.203F), new Vector2(96.352F, -10.203F));
                    builder.AddCubicBezier(new Vector2(97.56F, -10.203F), new Vector2(98.507F, -9.799F), new Vector2(99.195F, -8.992F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0046()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(100.148F, -1.406F));
                    builder.AddCubicBezier(new Vector2(101.117F, -2.469F), new Vector2(101.602F, -3.914F), new Vector2(101.602F, -5.742F));
                    builder.AddCubicBezier(new Vector2(101.602F, -7.424F), new Vector2(101.129F, -8.786F), new Vector2(100.184F, -9.828F));
                    builder.AddCubicBezier(new Vector2(99.239F, -10.87F), new Vector2(97.992F, -11.391F), new Vector2(96.445F, -11.391F));
                    builder.AddCubicBezier(new Vector2(94.768F, -11.391F), new Vector2(93.443F, -10.854F), new Vector2(92.469F, -9.781F));
                    builder.AddCubicBezier(new Vector2(91.495F, -8.708F), new Vector2(91.008F, -7.271F), new Vector2(91.008F, -5.469F));
                    builder.AddCubicBezier(new Vector2(91.008F, -3.792F), new Vector2(91.485F, -2.43F), new Vector2(92.441F, -1.383F));
                    builder.AddCubicBezier(new Vector2(93.397F, -0.336F), new Vector2(94.669F, 0.188F), new Vector2(96.258F, 0.188F));
                    builder.AddCubicBezier(new Vector2(97.883F, 0.188F), new Vector2(99.179F, -0.343F), new Vector2(100.148F, -1.406F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0047()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(83.301F, -0.184F));
                    builder.AddCubicBezier(new Vector2(83.543F, -0.103F), new Vector2(83.799F, -0.035F), new Vector2(84.07F, 0.02F));
                    builder.AddCubicBezier(new Vector2(84.341F, 0.075F), new Vector2(84.607F, 0.116F), new Vector2(84.867F, 0.145F));
                    builder.AddCubicBezier(new Vector2(85.127F, 0.174F), new Vector2(85.346F, 0.188F), new Vector2(85.523F, 0.188F));
                    builder.AddCubicBezier(new Vector2(86.054F, 0.188F), new Vector2(86.56F, 0.134F), new Vector2(87.039F, 0.027F));
                    builder.AddCubicBezier(new Vector2(87.518F, -0.08F), new Vector2(87.942F, -0.252F), new Vector2(88.309F, -0.492F));
                    builder.AddCubicBezier(new Vector2(88.676F, -0.732F), new Vector2(88.968F, -1.043F), new Vector2(89.184F, -1.426F));
                    builder.AddCubicBezier(new Vector2(89.4F, -1.809F), new Vector2(89.508F, -2.276F), new Vector2(89.508F, -2.828F));
                    builder.AddCubicBezier(new Vector2(89.508F, -3.245F), new Vector2(89.429F, -3.615F), new Vector2(89.27F, -3.938F));
                    builder.AddCubicBezier(new Vector2(89.111F, -4.261F), new Vector2(88.896F, -4.554F), new Vector2(88.625F, -4.82F));
                    builder.AddCubicBezier(new Vector2(88.354F, -5.086F), new Vector2(88.039F, -5.328F), new Vector2(87.68F, -5.547F));
                    builder.AddCubicBezier(new Vector2(87.321F, -5.766F), new Vector2(86.94F, -5.974F), new Vector2(86.539F, -6.172F));
                    builder.AddCubicBezier(new Vector2(86.148F, -6.365F), new Vector2(85.803F, -6.542F), new Vector2(85.504F, -6.703F));
                    builder.AddCubicBezier(new Vector2(85.204F, -6.864F), new Vector2(84.95F, -7.031F), new Vector2(84.742F, -7.203F));
                    builder.AddCubicBezier(new Vector2(84.534F, -7.375F), new Vector2(84.377F, -7.565F), new Vector2(84.27F, -7.773F));
                    builder.AddCubicBezier(new Vector2(84.163F, -7.981F), new Vector2(84.109F, -8.23F), new Vector2(84.109F, -8.516F));
                    builder.AddCubicBezier(new Vector2(84.109F, -8.823F), new Vector2(84.179F, -9.083F), new Vector2(84.32F, -9.297F));
                    builder.AddCubicBezier(new Vector2(84.461F, -9.511F), new Vector2(84.643F, -9.685F), new Vector2(84.867F, -9.82F));
                    builder.AddCubicBezier(new Vector2(85.091F, -9.955F), new Vector2(85.347F, -10.053F), new Vector2(85.633F, -10.113F));
                    builder.AddCubicBezier(new Vector2(85.919F, -10.173F), new Vector2(86.206F, -10.203F), new Vector2(86.492F, -10.203F));
                    builder.AddCubicBezier(new Vector2(87.528F, -10.203F), new Vector2(88.378F, -9.974F), new Vector2(89.039F, -9.516F));
                    builder.AddCubicBezier(new Vector2(89.039F, -9.516F), new Vector2(89.039F, -10.992F), new Vector2(89.039F, -10.992F));
                    builder.AddCubicBezier(new Vector2(88.534F, -11.258F), new Vector2(87.729F, -11.391F), new Vector2(86.625F, -11.391F));
                    builder.AddCubicBezier(new Vector2(86.141F, -11.391F), new Vector2(85.665F, -11.331F), new Vector2(85.199F, -11.211F));
                    builder.AddCubicBezier(new Vector2(84.733F, -11.091F), new Vector2(84.318F, -10.909F), new Vector2(83.953F, -10.664F));
                    builder.AddCubicBezier(new Vector2(83.588F, -10.419F), new Vector2(83.294F, -10.108F), new Vector2(83.07F, -9.73F));
                    builder.AddCubicBezier(new Vector2(82.846F, -9.352F), new Vector2(82.734F, -8.908F), new Vector2(82.734F, -8.398F));
                    builder.AddCubicBezier(new Vector2(82.734F, -7.981F), new Vector2(82.806F, -7.619F), new Vector2(82.949F, -7.309F));
                    builder.AddCubicBezier(new Vector2(83.092F, -6.999F), new Vector2(83.289F, -6.722F), new Vector2(83.539F, -6.477F));
                    builder.AddCubicBezier(new Vector2(83.789F, -6.232F), new Vector2(84.083F, -6.008F), new Vector2(84.422F, -5.805F));
                    builder.AddCubicBezier(new Vector2(84.761F, -5.602F), new Vector2(85.125F, -5.401F), new Vector2(85.516F, -5.203F));
                    builder.AddCubicBezier(new Vector2(85.886F, -5.015F), new Vector2(86.231F, -4.837F), new Vector2(86.551F, -4.668F));
                    builder.AddCubicBezier(new Vector2(86.871F, -4.499F), new Vector2(87.149F, -4.322F), new Vector2(87.383F, -4.137F));
                    builder.AddCubicBezier(new Vector2(87.617F, -3.952F), new Vector2(87.801F, -3.747F), new Vector2(87.934F, -3.523F));
                    builder.AddCubicBezier(new Vector2(88.067F, -3.299F), new Vector2(88.133F, -3.036F), new Vector2(88.133F, -2.734F));
                    builder.AddCubicBezier(new Vector2(88.133F, -2.171F), new Vector2(87.933F, -1.74F), new Vector2(87.535F, -1.441F));
                    builder.AddCubicBezier(new Vector2(87.137F, -1.141F), new Vector2(86.534F, -0.992F), new Vector2(85.727F, -0.992F));
                    builder.AddCubicBezier(new Vector2(85.493F, -0.992F), new Vector2(85.237F, -1.016F), new Vector2(84.961F, -1.063F));
                    builder.AddCubicBezier(new Vector2(84.685F, -1.11F), new Vector2(84.41F, -1.176F), new Vector2(84.137F, -1.262F));
                    builder.AddCubicBezier(new Vector2(83.864F, -1.348F), new Vector2(83.602F, -1.453F), new Vector2(83.355F, -1.578F));
                    builder.AddCubicBezier(new Vector2(83.108F, -1.703F), new Vector2(82.896F, -1.844F), new Vector2(82.719F, -2));
                    builder.AddCubicBezier(new Vector2(82.719F, -2), new Vector2(82.719F, -0.453F), new Vector2(82.719F, -0.453F));
                    builder.AddCubicBezier(new Vector2(82.865F, -0.354F), new Vector2(83.059F, -0.265F), new Vector2(83.301F, -0.184F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0048()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(80.398F, -11.203F));
                    builder.AddCubicBezier(new Vector2(80.398F, -11.203F), new Vector2(79.086F, -11.203F), new Vector2(79.086F, -11.203F));
                    builder.AddCubicBezier(new Vector2(79.086F, -11.203F), new Vector2(79.086F, -4), new Vector2(79.086F, -4));
                    builder.AddCubicBezier(new Vector2(79.086F, -1.995F), new Vector2(78.495F, -0.992F), new Vector2(77.313F, -0.992F));
                    builder.AddCubicBezier(new Vector2(76.865F, -0.992F), new Vector2(76.5F, -1.094F), new Vector2(76.219F, -1.297F));
                    builder.AddCubicBezier(new Vector2(76.219F, -1.297F), new Vector2(76.219F, 0), new Vector2(76.219F, 0));
                    builder.AddCubicBezier(new Vector2(76.5F, 0.125F), new Vector2(76.859F, 0.188F), new Vector2(77.297F, 0.188F));
                    builder.AddCubicBezier(new Vector2(78.24F, 0.188F), new Vector2(78.992F, -0.181F), new Vector2(79.555F, -0.918F));
                    builder.AddCubicBezier(new Vector2(80.118F, -1.655F), new Vector2(80.398F, -2.688F), new Vector2(80.398F, -4.016F));
                    builder.AddCubicBezier(new Vector2(80.398F, -4.016F), new Vector2(80.398F, -11.203F), new Vector2(80.398F, -11.203F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0049()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(71.586F, -8.031F));
                    builder.AddCubicBezier(new Vector2(71.409F, -8.104F), new Vector2(71.153F, -8.141F), new Vector2(70.82F, -8.141F));
                    builder.AddCubicBezier(new Vector2(70.356F, -8.141F), new Vector2(69.938F, -7.983F), new Vector2(69.563F, -7.668F));
                    builder.AddCubicBezier(new Vector2(69.188F, -7.353F), new Vector2(68.909F, -6.915F), new Vector2(68.727F, -6.352F));
                    builder.AddCubicBezier(new Vector2(68.727F, -6.352F), new Vector2(68.695F, -6.352F), new Vector2(68.695F, -6.352F));
                    builder.AddCubicBezier(new Vector2(68.695F, -6.352F), new Vector2(68.695F, -8), new Vector2(68.695F, -8));
                    builder.AddCubicBezier(new Vector2(68.695F, -8), new Vector2(67.414F, -8), new Vector2(67.414F, -8));
                    builder.AddCubicBezier(new Vector2(67.414F, -8), new Vector2(67.414F, 0), new Vector2(67.414F, 0));
                    builder.AddCubicBezier(new Vector2(67.414F, 0), new Vector2(68.695F, 0), new Vector2(68.695F, 0));
                    builder.AddCubicBezier(new Vector2(68.695F, 0), new Vector2(68.695F, -4.078F), new Vector2(68.695F, -4.078F));
                    builder.AddCubicBezier(new Vector2(68.695F, -4.969F), new Vector2(68.879F, -5.672F), new Vector2(69.246F, -6.188F));
                    builder.AddCubicBezier(new Vector2(69.613F, -6.704F), new Vector2(70.07F, -6.961F), new Vector2(70.617F, -6.961F));
                    builder.AddCubicBezier(new Vector2(71.039F, -6.961F), new Vector2(71.362F, -6.875F), new Vector2(71.586F, -6.703F));
                    builder.AddCubicBezier(new Vector2(71.586F, -6.703F), new Vector2(71.586F, -8.031F), new Vector2(71.586F, -8.031F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0050()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(64.828F, -8));
                    builder.AddCubicBezier(new Vector2(64.828F, -8), new Vector2(63.547F, -8), new Vector2(63.547F, -8));
                    builder.AddCubicBezier(new Vector2(63.547F, -8), new Vector2(63.547F, -3.391F), new Vector2(63.547F, -3.391F));
                    builder.AddCubicBezier(new Vector2(63.547F, -2.646F), new Vector2(63.345F, -2.043F), new Vector2(62.941F, -1.582F));
                    builder.AddCubicBezier(new Vector2(62.537F, -1.121F), new Vector2(62.023F, -0.891F), new Vector2(61.398F, -0.891F));
                    builder.AddCubicBezier(new Vector2(60.106F, -0.891F), new Vector2(59.461F, -1.734F), new Vector2(59.461F, -3.422F));
                    builder.AddCubicBezier(new Vector2(59.461F, -3.422F), new Vector2(59.461F, -8), new Vector2(59.461F, -8));
                    builder.AddCubicBezier(new Vector2(59.461F, -8), new Vector2(58.188F, -8), new Vector2(58.188F, -8));
                    builder.AddCubicBezier(new Vector2(58.188F, -8), new Vector2(58.188F, -3.219F), new Vector2(58.188F, -3.219F));
                    builder.AddCubicBezier(new Vector2(58.188F, -0.948F), new Vector2(59.141F, 0.188F), new Vector2(61.047F, 0.188F));
                    builder.AddCubicBezier(new Vector2(62.162F, 0.188F), new Vector2(62.985F, -0.297F), new Vector2(63.516F, -1.266F));
                    builder.AddCubicBezier(new Vector2(63.516F, -1.266F), new Vector2(63.547F, -1.266F), new Vector2(63.547F, -1.266F));
                    builder.AddCubicBezier(new Vector2(63.547F, -1.266F), new Vector2(63.547F, 0), new Vector2(63.547F, 0));
                    builder.AddCubicBezier(new Vector2(63.547F, 0), new Vector2(64.828F, 0), new Vector2(64.828F, 0));
                    builder.AddCubicBezier(new Vector2(64.828F, 0), new Vector2(64.828F, -8), new Vector2(64.828F, -8));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0051()
            {
                var result = CanvasGeometry_0052().
                    CombineWith(CanvasGeometry_0053(),
                    Matrix3x2.Identity,
                    CanvasGeometryCombine.Xor);
                return result;
            }
            
            CanvasGeometry CanvasGeometry_0052()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(54.332F, -6.297F));
                    builder.AddCubicBezier(new Vector2(54.777F, -5.755F), new Vector2(55, -4.984F), new Vector2(55, -3.984F));
                    builder.AddCubicBezier(new Vector2(55, -2.994F), new Vector2(54.777F, -2.231F), new Vector2(54.332F, -1.695F));
                    builder.AddCubicBezier(new Vector2(53.887F, -1.159F), new Vector2(53.25F, -0.891F), new Vector2(52.422F, -0.891F));
                    builder.AddCubicBezier(new Vector2(51.609F, -0.891F), new Vector2(50.961F, -1.164F), new Vector2(50.477F, -1.711F));
                    builder.AddCubicBezier(new Vector2(49.993F, -2.258F), new Vector2(49.75F, -3.005F), new Vector2(49.75F, -3.953F));
                    builder.AddCubicBezier(new Vector2(49.75F, -4.937F), new Vector2(49.99F, -5.71F), new Vector2(50.469F, -6.27F));
                    builder.AddCubicBezier(new Vector2(50.948F, -6.83F), new Vector2(51.599F, -7.109F), new Vector2(52.422F, -7.109F));
                    builder.AddCubicBezier(new Vector2(53.25F, -7.109F), new Vector2(53.887F, -6.839F), new Vector2(54.332F, -6.297F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0053()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(55.23F, -0.965F));
                    builder.AddCubicBezier(new Vector2(55.951F, -1.733F), new Vector2(56.313F, -2.755F), new Vector2(56.313F, -4.031F));
                    builder.AddCubicBezier(new Vector2(56.313F, -5.333F), new Vector2(55.978F, -6.352F), new Vector2(55.309F, -7.086F));
                    builder.AddCubicBezier(new Vector2(54.64F, -7.82F), new Vector2(53.709F, -8.188F), new Vector2(52.516F, -8.188F));
                    builder.AddCubicBezier(new Vector2(51.266F, -8.188F), new Vector2(50.273F, -7.81F), new Vector2(49.539F, -7.055F));
                    builder.AddCubicBezier(new Vector2(48.805F, -6.3F), new Vector2(48.438F, -5.25F), new Vector2(48.438F, -3.906F));
                    builder.AddCubicBezier(new Vector2(48.438F, -2.672F), new Vector2(48.79F, -1.681F), new Vector2(49.496F, -0.934F));
                    builder.AddCubicBezier(new Vector2(50.202F, -0.187F), new Vector2(51.146F, 0.188F), new Vector2(52.328F, 0.188F));
                    builder.AddCubicBezier(new Vector2(53.542F, 0.188F), new Vector2(54.509F, -0.197F), new Vector2(55.23F, -0.965F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0054()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(46.281F, -8));
                    builder.AddCubicBezier(new Vector2(46.281F, -8), new Vector2(44.008F, -1.828F), new Vector2(44.008F, -1.828F));
                    builder.AddCubicBezier(new Vector2(43.93F, -1.557F), new Vector2(43.878F, -1.359F), new Vector2(43.852F, -1.234F));
                    builder.AddCubicBezier(new Vector2(43.852F, -1.234F), new Vector2(43.805F, -1.234F), new Vector2(43.805F, -1.234F));
                    builder.AddCubicBezier(new Vector2(43.722F, -1.562F), new Vector2(43.667F, -1.766F), new Vector2(43.641F, -1.844F));
                    builder.AddCubicBezier(new Vector2(43.641F, -1.844F), new Vector2(41.477F, -8), new Vector2(41.477F, -8));
                    builder.AddCubicBezier(new Vector2(41.477F, -8), new Vector2(40.055F, -8), new Vector2(40.055F, -8));
                    builder.AddCubicBezier(new Vector2(40.055F, -8), new Vector2(43.18F, -0.016F), new Vector2(43.18F, -0.016F));
                    builder.AddCubicBezier(new Vector2(43.18F, -0.016F), new Vector2(42.539F, 1.5F), new Vector2(42.539F, 1.5F));
                    builder.AddCubicBezier(new Vector2(42.216F, 2.271F), new Vector2(41.732F, 2.656F), new Vector2(41.086F, 2.656F));
                    builder.AddCubicBezier(new Vector2(40.857F, 2.656F), new Vector2(40.604F, 2.61F), new Vector2(40.328F, 2.516F));
                    builder.AddCubicBezier(new Vector2(40.328F, 2.516F), new Vector2(40.328F, 3.664F), new Vector2(40.328F, 3.664F));
                    builder.AddCubicBezier(new Vector2(40.552F, 3.732F), new Vector2(40.831F, 3.766F), new Vector2(41.164F, 3.766F));
                    builder.AddCubicBezier(new Vector2(42.352F, 3.766F), new Vector2(43.274F, 2.937F), new Vector2(43.93F, 1.281F));
                    builder.AddCubicBezier(new Vector2(43.93F, 1.281F), new Vector2(47.609F, -8), new Vector2(47.609F, -8));
                    builder.AddCubicBezier(new Vector2(47.609F, -8), new Vector2(46.281F, -8), new Vector2(46.281F, -8));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0055()
            {
                var result = CanvasGeometry_0056().
                    CombineWith(CanvasGeometry_0057(),
                    Matrix3x2.Identity,
                    CanvasGeometryCombine.Xor);
                return result;
            }
            
            CanvasGeometry CanvasGeometry_0056()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(29.414F, -6.332F));
                    builder.AddCubicBezier(new Vector2(29.867F, -6.85F), new Vector2(30.466F, -7.109F), new Vector2(31.211F, -7.109F));
                    builder.AddCubicBezier(new Vector2(31.914F, -7.109F), new Vector2(32.472F, -6.857F), new Vector2(32.883F, -6.352F));
                    builder.AddCubicBezier(new Vector2(33.294F, -5.847F), new Vector2(33.5F, -5.149F), new Vector2(33.5F, -4.258F));
                    builder.AddCubicBezier(new Vector2(33.5F, -3.201F), new Vector2(33.28F, -2.375F), new Vector2(32.84F, -1.781F));
                    builder.AddCubicBezier(new Vector2(32.4F, -1.187F), new Vector2(31.792F, -0.891F), new Vector2(31.016F, -0.891F));
                    builder.AddCubicBezier(new Vector2(30.355F, -0.891F), new Vector2(29.809F, -1.121F), new Vector2(29.379F, -1.582F));
                    builder.AddCubicBezier(new Vector2(28.949F, -2.043F), new Vector2(28.734F, -2.605F), new Vector2(28.734F, -3.266F));
                    builder.AddCubicBezier(new Vector2(28.734F, -3.266F), new Vector2(28.734F, -4.383F), new Vector2(28.734F, -4.383F));
                    builder.AddCubicBezier(new Vector2(28.734F, -5.164F), new Vector2(28.961F, -5.814F), new Vector2(29.414F, -6.332F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0057()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(31.164F, 0.188F));
                    builder.AddCubicBezier(new Vector2(32.294F, 0.188F), new Vector2(33.185F, -0.215F), new Vector2(33.836F, -1.02F));
                    builder.AddCubicBezier(new Vector2(34.487F, -1.825F), new Vector2(34.813F, -2.895F), new Vector2(34.813F, -4.234F));
                    builder.AddCubicBezier(new Vector2(34.813F, -5.437F), new Vector2(34.523F, -6.397F), new Vector2(33.945F, -7.113F));
                    builder.AddCubicBezier(new Vector2(33.367F, -7.829F), new Vector2(32.562F, -8.188F), new Vector2(31.531F, -8.188F));
                    builder.AddCubicBezier(new Vector2(30.317F, -8.188F), new Vector2(29.396F, -7.657F), new Vector2(28.766F, -6.594F));
                    builder.AddCubicBezier(new Vector2(28.766F, -6.594F), new Vector2(28.734F, -6.594F), new Vector2(28.734F, -6.594F));
                    builder.AddCubicBezier(new Vector2(28.734F, -6.594F), new Vector2(28.734F, -8), new Vector2(28.734F, -8));
                    builder.AddCubicBezier(new Vector2(28.734F, -8), new Vector2(27.453F, -8), new Vector2(27.453F, -8));
                    builder.AddCubicBezier(new Vector2(27.453F, -8), new Vector2(27.453F, 3.68F), new Vector2(27.453F, 3.68F));
                    builder.AddCubicBezier(new Vector2(27.453F, 3.68F), new Vector2(28.734F, 3.68F), new Vector2(28.734F, 3.68F));
                    builder.AddCubicBezier(new Vector2(28.734F, 3.68F), new Vector2(28.734F, -1.156F), new Vector2(28.734F, -1.156F));
                    builder.AddCubicBezier(new Vector2(28.734F, -1.156F), new Vector2(28.766F, -1.156F), new Vector2(28.766F, -1.156F));
                    builder.AddCubicBezier(new Vector2(29.329F, -0.26F), new Vector2(30.128F, 0.188F), new Vector2(31.164F, 0.188F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0058()
            {
                var result = CanvasGeometry_0059().
                    CombineWith(CanvasGeometry_0060(),
                    Matrix3x2.Identity,
                    CanvasGeometryCombine.Xor);
                return result;
            }
            
            CanvasGeometry CanvasGeometry_0059()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(23.426F, -6.297F));
                    builder.AddCubicBezier(new Vector2(23.871F, -5.755F), new Vector2(24.094F, -4.984F), new Vector2(24.094F, -3.984F));
                    builder.AddCubicBezier(new Vector2(24.094F, -2.994F), new Vector2(23.871F, -2.231F), new Vector2(23.426F, -1.695F));
                    builder.AddCubicBezier(new Vector2(22.981F, -1.159F), new Vector2(22.344F, -0.891F), new Vector2(21.516F, -0.891F));
                    builder.AddCubicBezier(new Vector2(20.703F, -0.891F), new Vector2(20.054F, -1.164F), new Vector2(19.57F, -1.711F));
                    builder.AddCubicBezier(new Vector2(19.086F, -2.258F), new Vector2(18.844F, -3.005F), new Vector2(18.844F, -3.953F));
                    builder.AddCubicBezier(new Vector2(18.844F, -4.937F), new Vector2(19.084F, -5.71F), new Vector2(19.563F, -6.27F));
                    builder.AddCubicBezier(new Vector2(20.042F, -6.83F), new Vector2(20.693F, -7.109F), new Vector2(21.516F, -7.109F));
                    builder.AddCubicBezier(new Vector2(22.344F, -7.109F), new Vector2(22.981F, -6.839F), new Vector2(23.426F, -6.297F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0060()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(24.324F, -0.965F));
                    builder.AddCubicBezier(new Vector2(25.045F, -1.733F), new Vector2(25.406F, -2.755F), new Vector2(25.406F, -4.031F));
                    builder.AddCubicBezier(new Vector2(25.406F, -5.333F), new Vector2(25.071F, -6.352F), new Vector2(24.402F, -7.086F));
                    builder.AddCubicBezier(new Vector2(23.733F, -7.82F), new Vector2(22.802F, -8.188F), new Vector2(21.609F, -8.188F));
                    builder.AddCubicBezier(new Vector2(20.359F, -8.188F), new Vector2(19.367F, -7.81F), new Vector2(18.633F, -7.055F));
                    builder.AddCubicBezier(new Vector2(17.899F, -6.3F), new Vector2(17.531F, -5.25F), new Vector2(17.531F, -3.906F));
                    builder.AddCubicBezier(new Vector2(17.531F, -2.672F), new Vector2(17.884F, -1.681F), new Vector2(18.59F, -0.934F));
                    builder.AddCubicBezier(new Vector2(19.296F, -0.187F), new Vector2(20.24F, 0.188F), new Vector2(21.422F, 0.188F));
                    builder.AddCubicBezier(new Vector2(22.636F, 0.188F), new Vector2(23.603F, -0.197F), new Vector2(24.324F, -0.965F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0061()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(16.688F, -8.031F));
                    builder.AddCubicBezier(new Vector2(16.511F, -8.104F), new Vector2(16.255F, -8.141F), new Vector2(15.922F, -8.141F));
                    builder.AddCubicBezier(new Vector2(15.458F, -8.141F), new Vector2(15.039F, -7.983F), new Vector2(14.664F, -7.668F));
                    builder.AddCubicBezier(new Vector2(14.289F, -7.353F), new Vector2(14.01F, -6.915F), new Vector2(13.828F, -6.352F));
                    builder.AddCubicBezier(new Vector2(13.828F, -6.352F), new Vector2(13.797F, -6.352F), new Vector2(13.797F, -6.352F));
                    builder.AddCubicBezier(new Vector2(13.797F, -6.352F), new Vector2(13.797F, -8), new Vector2(13.797F, -8));
                    builder.AddCubicBezier(new Vector2(13.797F, -8), new Vector2(12.516F, -8), new Vector2(12.516F, -8));
                    builder.AddCubicBezier(new Vector2(12.516F, -8), new Vector2(12.516F, 0), new Vector2(12.516F, 0));
                    builder.AddCubicBezier(new Vector2(12.516F, 0), new Vector2(13.797F, 0), new Vector2(13.797F, 0));
                    builder.AddCubicBezier(new Vector2(13.797F, 0), new Vector2(13.797F, -4.078F), new Vector2(13.797F, -4.078F));
                    builder.AddCubicBezier(new Vector2(13.797F, -4.969F), new Vector2(13.981F, -5.672F), new Vector2(14.348F, -6.188F));
                    builder.AddCubicBezier(new Vector2(14.715F, -6.704F), new Vector2(15.172F, -6.961F), new Vector2(15.719F, -6.961F));
                    builder.AddCubicBezier(new Vector2(16.141F, -6.961F), new Vector2(16.464F, -6.875F), new Vector2(16.688F, -6.703F));
                    builder.AddCubicBezier(new Vector2(16.688F, -6.703F), new Vector2(16.688F, -8.031F), new Vector2(16.688F, -8.031F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0062()
            {
                var result = CanvasGeometry_0063().
                    CombineWith(CanvasGeometry_0064(),
                    Matrix3x2.Identity,
                    CanvasGeometryCombine.Xor);
                return result;
            }
            
            CanvasGeometry CanvasGeometry_0063()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(4.531F, -10.016F));
                    builder.AddCubicBezier(new Vector2(7.583F, -10.016F), new Vector2(9.109F, -8.581F), new Vector2(9.109F, -5.711F));
                    builder.AddCubicBezier(new Vector2(9.109F, -4.268F), new Vector2(8.701F, -3.153F), new Vector2(7.883F, -2.367F));
                    builder.AddCubicBezier(new Vector2(7.065F, -1.581F), new Vector2(5.922F, -1.188F), new Vector2(4.453F, -1.188F));
                    builder.AddCubicBezier(new Vector2(4.453F, -1.188F), new Vector2(2.781F, -1.188F), new Vector2(2.781F, -1.188F));
                    builder.AddCubicBezier(new Vector2(2.781F, -1.188F), new Vector2(2.781F, -10.016F), new Vector2(2.781F, -10.016F));
                    builder.AddCubicBezier(new Vector2(2.781F, -10.016F), new Vector2(4.531F, -10.016F), new Vector2(4.531F, -10.016F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0064()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(4.438F, 0));
                    builder.AddCubicBezier(new Vector2(6.277F, 0), new Vector2(7.744F, -0.524F), new Vector2(8.84F, -1.574F));
                    builder.AddCubicBezier(new Vector2(9.936F, -2.623F), new Vector2(10.484F, -4.013F), new Vector2(10.484F, -5.742F));
                    builder.AddCubicBezier(new Vector2(10.484F, -9.383F), new Vector2(8.511F, -11.203F), new Vector2(4.563F, -11.203F));
                    builder.AddCubicBezier(new Vector2(4.563F, -11.203F), new Vector2(1.469F, -11.203F), new Vector2(1.469F, -11.203F));
                    builder.AddCubicBezier(new Vector2(1.469F, -11.203F), new Vector2(1.469F, 0), new Vector2(1.469F, 0));
                    builder.AddCubicBezier(new Vector2(1.469F, 0), new Vector2(4.438F, 0), new Vector2(4.438F, 0));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            ColorKeyFrameAnimation ColorKeyFrameAnimation_0000()
            {
                var result = _c.CreateColorKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(62170000);
                result.InsertKeyFrame(0, Color.FromArgb(0xFF, 0x38, 0x38, 0x38), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6327078F, Color.FromArgb(0xFF, 0x38, 0x38, 0x38), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6863271F, Color.FromArgb(0x00, 0x38, 0x38, 0x38), CubicBezierEasingFunction_0003());
                return result;
            }
            
            ColorKeyFrameAnimation ColorKeyFrameAnimation_0001()
            {
                if (_colorKeyFrameAnimation_0001 != null)
                {
                    return _colorKeyFrameAnimation_0001;
                }
                var result = _colorKeyFrameAnimation_0001 = _c.CreateColorKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(62170000);
                result.InsertKeyFrame(0, Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6380697F, Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6648794F, Color.FromArgb(0x00, 0xFF, 0xFF, 0xFF), CubicBezierEasingFunction_0003());
                return result;
            }
            
            CompositionColorBrush CompositionColorBrush_0000()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x38, 0x38, 0x38));
                result.StartAnimation("Color", ColorKeyFrameAnimation_0000());
                var controller = result.TryGetAnimationController("Color");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
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
                var result = _compositionColorBrush_0002 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x30, 0x75, 0xBA));
                return result;
            }
            
            CompositionColorBrush CompositionColorBrush_0003()
            {
                return _c.CreateColorBrush(Color.FromArgb(0xFF, 0x31, 0x75, 0xBB));
            }
            
            CompositionColorBrush CompositionColorBrush_0004()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));
                result.StartAnimation("Color", ColorKeyFrameAnimation_0001());
                var controller = result.TryGetAnimationController("Color");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionColorBrush CompositionColorBrush_0005()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));
                result.StartAnimation("Color", ColorKeyFrameAnimation_0001());
                var controller = result.TryGetAnimationController("Color");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionColorBrush CompositionColorBrush_0006()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));
                result.StartAnimation("Color", ColorKeyFrameAnimation_0001());
                var controller = result.TryGetAnimationController("Color");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionColorBrush CompositionColorBrush_0007()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));
                result.StartAnimation("Color", ColorKeyFrameAnimation_0001());
                var controller = result.TryGetAnimationController("Color");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionColorBrush CompositionColorBrush_0008()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));
                result.StartAnimation("Color", ColorKeyFrameAnimation_0001());
                var controller = result.TryGetAnimationController("Color");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionColorBrush CompositionColorBrush_0009()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));
                result.StartAnimation("Color", ColorKeyFrameAnimation_0001());
                var controller = result.TryGetAnimationController("Color");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionColorBrush CompositionColorBrush_0010()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));
                result.StartAnimation("Color", ColorKeyFrameAnimation_0001());
                var controller = result.TryGetAnimationController("Color");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionColorBrush CompositionColorBrush_0011()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));
                result.StartAnimation("Color", ColorKeyFrameAnimation_0001());
                var controller = result.TryGetAnimationController("Color");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionColorBrush CompositionColorBrush_0012()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));
                result.StartAnimation("Color", ColorKeyFrameAnimation_0001());
                var controller = result.TryGetAnimationController("Color");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionColorBrush CompositionColorBrush_0013()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));
                result.StartAnimation("Color", ColorKeyFrameAnimation_0001());
                var controller = result.TryGetAnimationController("Color");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionColorBrush CompositionColorBrush_0014()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));
                result.StartAnimation("Color", ColorKeyFrameAnimation_0001());
                var controller = result.TryGetAnimationController("Color");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionColorBrush CompositionColorBrush_0015()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));
                result.StartAnimation("Color", ColorKeyFrameAnimation_0001());
                var controller = result.TryGetAnimationController("Color");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionColorBrush CompositionColorBrush_0016()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));
                result.StartAnimation("Color", ColorKeyFrameAnimation_0001());
                var controller = result.TryGetAnimationController("Color");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionColorBrush CompositionColorBrush_0017()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));
                result.StartAnimation("Color", ColorKeyFrameAnimation_0001());
                var controller = result.TryGetAnimationController("Color");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionColorBrush CompositionColorBrush_0018()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));
                result.StartAnimation("Color", ColorKeyFrameAnimation_0001());
                var controller = result.TryGetAnimationController("Color");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionColorBrush CompositionColorBrush_0019()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));
                result.StartAnimation("Color", ColorKeyFrameAnimation_0001());
                var controller = result.TryGetAnimationController("Color");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionColorBrush CompositionColorBrush_0020()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));
                result.StartAnimation("Color", ColorKeyFrameAnimation_0001());
                var controller = result.TryGetAnimationController("Color");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionColorBrush CompositionColorBrush_0021()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));
                result.StartAnimation("Color", ColorKeyFrameAnimation_0001());
                var controller = result.TryGetAnimationController("Color");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionColorBrush CompositionColorBrush_0022()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));
                result.StartAnimation("Color", ColorKeyFrameAnimation_0001());
                var controller = result.TryGetAnimationController("Color");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionColorBrush CompositionColorBrush_0023()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));
                result.StartAnimation("Color", ColorKeyFrameAnimation_0001());
                var controller = result.TryGetAnimationController("Color");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0000()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(250.5F, 256.5F);
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
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0002()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(10.464F, -1.864F));
                propertySet.InsertVector2("Position", new Vector2(251.606F, 255.298F));
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
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0003()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(8, 0);
                result.Scale = new Vector2(0.5F, 0.5F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0004());
                shapes.Add(CompositionContainerShape_0008());
                shapes.Add(CompositionContainerShape_0009());
                shapes.Add(CompositionContainerShape_0010());
                shapes.Add(CompositionContainerShape_0011());
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
                result.Offset = new Vector2(302, 340);
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
                result.Offset = new Vector2(300.5F, 342.5F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0024());
                shapes.Add(CompositionContainerShape_0025());
                shapes.Add(CompositionContainerShape_0026());
                shapes.Add(CompositionContainerShape_0027());
                shapes.Add(CompositionContainerShape_0028());
                shapes.Add(CompositionContainerShape_0029());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0024()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0017());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0025()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0018());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0026()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0019());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0027()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0020());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0028()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0021());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0029()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0022());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0030()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(15.5F, -168.25F);
                result.Offset = new Vector2(302, 340);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0031());
                shapes.Add(CompositionContainerShape_0032());
                shapes.Add(CompositionContainerShape_0033());
                shapes.Add(CompositionContainerShape_0034());
                shapes.Add(CompositionContainerShape_0035());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0031()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(0, 0));
                propertySet.InsertVector2("Position", new Vector2(-50.75F, -86.75F));
                result.RotationAngleInDegrees = -307;
                result.Scale = new Vector2(0, 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0023());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0003());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("Scale", Vector2KeyFrameAnimation_0004());
                controller = result.TryGetAnimationController("Scale");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("RotationAngleInDegrees", ScalarKeyFrameAnimation_0014());
                controller = result.TryGetAnimationController("RotationAngleInDegrees");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0032()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(0, 0));
                propertySet.InsertVector2("Position", new Vector2(-50.75F, -86.75F));
                result.RotationAngleInDegrees = -307;
                result.Scale = new Vector2(0, 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0024());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0005());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("Scale", Vector2KeyFrameAnimation_0006());
                controller = result.TryGetAnimationController("Scale");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("RotationAngleInDegrees", ScalarKeyFrameAnimation_0014());
                controller = result.TryGetAnimationController("RotationAngleInDegrees");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0033()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(0, 0));
                propertySet.InsertVector2("Position", new Vector2(-50.75F, -86.75F));
                result.RotationAngleInDegrees = -307;
                result.Scale = new Vector2(0, 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0025());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0007());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("Scale", Vector2KeyFrameAnimation_0008());
                controller = result.TryGetAnimationController("Scale");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("RotationAngleInDegrees", ScalarKeyFrameAnimation_0014());
                controller = result.TryGetAnimationController("RotationAngleInDegrees");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0034()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(0, 0));
                propertySet.InsertVector2("Position", new Vector2(-50.75F, -86.75F));
                result.RotationAngleInDegrees = -307;
                result.Scale = new Vector2(0, 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0026());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0009());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("Scale", Vector2KeyFrameAnimation_0008());
                controller = result.TryGetAnimationController("Scale");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("RotationAngleInDegrees", ScalarKeyFrameAnimation_0014());
                controller = result.TryGetAnimationController("RotationAngleInDegrees");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0035()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(0, 0));
                propertySet.InsertVector2("Position", new Vector2(-50.75F, -86.75F));
                result.RotationAngleInDegrees = -307;
                result.Scale = new Vector2(0, 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0027());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0010());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("Scale", Vector2KeyFrameAnimation_0011());
                controller = result.TryGetAnimationController("Scale");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("RotationAngleInDegrees", ScalarKeyFrameAnimation_0014());
                controller = result.TryGetAnimationController("RotationAngleInDegrees");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0036()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(91.45F, -4.125F);
                result.Offset = new Vector2(161.418F, 355.125F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0037());
                shapes.Add(CompositionContainerShape_0038());
                shapes.Add(CompositionContainerShape_0039());
                shapes.Add(CompositionContainerShape_0040());
                shapes.Add(CompositionContainerShape_0041());
                shapes.Add(CompositionContainerShape_0042());
                shapes.Add(CompositionContainerShape_0043());
                shapes.Add(CompositionContainerShape_0044());
                shapes.Add(CompositionContainerShape_0045());
                shapes.Add(CompositionContainerShape_0046());
                shapes.Add(CompositionContainerShape_0047());
                shapes.Add(CompositionContainerShape_0048());
                shapes.Add(CompositionContainerShape_0049());
                shapes.Add(CompositionContainerShape_0050());
                shapes.Add(CompositionContainerShape_0051());
                shapes.Add(CompositionContainerShape_0052());
                shapes.Add(CompositionContainerShape_0053());
                shapes.Add(CompositionContainerShape_0054());
                shapes.Add(CompositionContainerShape_0055());
                shapes.Add(CompositionContainerShape_0056());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0037()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0028());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0038()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0029());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0039()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0030());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0040()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0031());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0041()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0032());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0042()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0033());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0043()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0034());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0044()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0035());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0045()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0036());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0046()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0037());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0047()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0038());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0048()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0039());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0049()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0040());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0050()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0041());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0051()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0042());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0052()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0043());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0053()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0044());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0054()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0045());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0055()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0046());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0056()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0047());
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
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0000());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0001());
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
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0002());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0003());
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
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0000());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0001());
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
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0002());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0003());
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
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0000());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0001());
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
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0002());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0003());
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
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0000());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0001());
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
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0002());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0003());
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
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0000());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0001());
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
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0002());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0003());
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
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0004());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0005());
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
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0006());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0007());
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
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0018()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 0);
                propertySet.InsertScalar("TEnd", 0);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0008());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0009());
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
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0019()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 0);
                propertySet.InsertScalar("TEnd", 0);
                result.StartAnimation("TStart", ScalarKeyFrameAnimation_0006());
                var controller = result.TryGetAnimationController("TStart");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("TEnd", ScalarKeyFrameAnimation_0007());
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
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0020()));
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
            
            CompositionPathGeometry CompositionPathGeometry_0021()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0021()));
                var propertySet = result.Properties;
                propertySet.InsertScalar("TStart", 0);
                propertySet.InsertScalar("TEnd", 0);
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
            
            CompositionPathGeometry CompositionPathGeometry_0022()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0022()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0023()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0023()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0024()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0024()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0025()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0025()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0026()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0026()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0027()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0027()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0028()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0030()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0029()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0031()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0030()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0034()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0031()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0035()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0032()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0038()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0033()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0039()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0034()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0042()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0035()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0043()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0036()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0044()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0037()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0047()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0038()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0048()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0039()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0049()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0040()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0050()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0041()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0051()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0042()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0054()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0043()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0055()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0044()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0058()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0045()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0061()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0046()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0062()));
                return result;
            }
            
            CompositionRoundedRectangleGeometry CompositionRoundedRectangleGeometry_0000()
            {
                var result = _c.CreateRoundedRectangleGeometry();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Position", new Vector2(0, 0));
                result.CornerRadius = new Vector2(15, 15);
                result.Size = new Vector2(318.937F, 300);
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
                result.Geometry = CompositionRoundedRectangleGeometry_0000();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0001()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0000();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeMiterLimit = 10;
                result.StrokeThickness = 0.45F;
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
                result.StrokeThickness = 4;
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
                result.StrokeThickness = 4;
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
                result.StrokeThickness = 4;
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
                result.StrokeThickness = 4;
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
                result.StrokeThickness = 4;
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
                result.StrokeThickness = 4;
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
                result.StrokeThickness = 4;
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
                result.StrokeThickness = 4;
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
                result.StrokeThickness = 4;
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
                result.StrokeThickness = 4;
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0017()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0016();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeDashOffset = 12;
                var strokeDashArray = result.StrokeDashArray;
                strokeDashArray.Add(95);
                strokeDashArray.Add(14);
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 3;
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0018()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0017();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 3;
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0019()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0018();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeDashOffset = -9;
                var strokeDashArray = result.StrokeDashArray;
                strokeDashArray.Add(121);
                strokeDashArray.Add(6);
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 3;
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0020()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0019();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 3;
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0021()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0020();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeDashOffset = -45;
                var strokeDashArray = result.StrokeDashArray;
                strokeDashArray.Add(28);
                strokeDashArray.Add(18);
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 3;
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0022()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0021();
                result.StrokeBrush = CompositionColorBrush_0003();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 4;
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0023()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0022();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 6;
                result.StartAnimation("StrokeThickness", ScalarKeyFrameAnimation_0015());
                var controller = result.TryGetAnimationController("StrokeThickness");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0024()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0023();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 6;
                result.StartAnimation("StrokeThickness", ScalarKeyFrameAnimation_0015());
                var controller = result.TryGetAnimationController("StrokeThickness");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0025()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0024();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 4;
                result.StartAnimation("StrokeThickness", ScalarKeyFrameAnimation_0016());
                var controller = result.TryGetAnimationController("StrokeThickness");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0026()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0025();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 4;
                result.StartAnimation("StrokeThickness", ScalarKeyFrameAnimation_0016());
                var controller = result.TryGetAnimationController("StrokeThickness");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0027()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0026();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 6;
                result.StartAnimation("StrokeThickness", ScalarKeyFrameAnimation_0015());
                var controller = result.TryGetAnimationController("StrokeThickness");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0028()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0004();
                result.Geometry = CompositionPathGeometry_0027();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0029()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0005();
                result.Geometry = CompositionPathGeometry_0028();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0030()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0006();
                result.Geometry = CompositionPathGeometry_0029();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0031()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0007();
                result.Geometry = CompositionPathGeometry_0030();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0032()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0008();
                result.Geometry = CompositionPathGeometry_0031();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0033()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0009();
                result.Geometry = CompositionPathGeometry_0032();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0034()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0010();
                result.Geometry = CompositionPathGeometry_0033();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0035()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0011();
                result.Geometry = CompositionPathGeometry_0034();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0036()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0012();
                result.Geometry = CompositionPathGeometry_0035();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0037()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0013();
                result.Geometry = CompositionPathGeometry_0036();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0038()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0014();
                result.Geometry = CompositionPathGeometry_0037();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0039()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0015();
                result.Geometry = CompositionPathGeometry_0038();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0040()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0016();
                result.Geometry = CompositionPathGeometry_0039();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0041()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0017();
                result.Geometry = CompositionPathGeometry_0040();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0042()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0018();
                result.Geometry = CompositionPathGeometry_0041();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0043()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0019();
                result.Geometry = CompositionPathGeometry_0042();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0044()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0020();
                result.Geometry = CompositionPathGeometry_0043();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0045()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0021();
                result.Geometry = CompositionPathGeometry_0044();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0046()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0022();
                result.Geometry = CompositionPathGeometry_0045();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0047()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0023();
                result.Geometry = CompositionPathGeometry_0046();
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
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.29F, 0), new Vector2(0, 1));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0001()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0), new Vector2(0.675F, 1));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0002()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.94F, 0), new Vector2(0.993F, 1));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0003()
            {
                if (_cubicBezierEasingFunction_0003 != null)
                {
                    return _cubicBezierEasingFunction_0003;
                }
                return _cubicBezierEasingFunction_0003 = _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0.833F, 0.833F));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0004()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.751F, 0), new Vector2(0.347F, 1));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0005()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.333F, 0), new Vector2(0.833F, 1));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0006()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(1, 0), new Vector2(0.833F, 1));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0007()
            {
                if (_cubicBezierEasingFunction_0007 != null)
                {
                    return _cubicBezierEasingFunction_0007;
                }
                return _cubicBezierEasingFunction_0007 = _c.CreateCubicBezierEasingFunction(new Vector2(0.073F, 0), new Vector2(0.389F, 1));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0008()
            {
                if (_cubicBezierEasingFunction_0008 != null)
                {
                    return _cubicBezierEasingFunction_0008;
                }
                return _cubicBezierEasingFunction_0008 = _c.CreateCubicBezierEasingFunction(new Vector2(0.34F, 0.003F), new Vector2(0.673F, 1));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0009()
            {
                if (_cubicBezierEasingFunction_0009 != null)
                {
                    return _cubicBezierEasingFunction_0009;
                }
                return _cubicBezierEasingFunction_0009 = _c.CreateCubicBezierEasingFunction(new Vector2(0.699F, 0), new Vector2(1, 1));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0010()
            {
                if (_cubicBezierEasingFunction_0010 != null)
                {
                    return _cubicBezierEasingFunction_0010;
                }
                return _cubicBezierEasingFunction_0010 = _c.CreateCubicBezierEasingFunction(new Vector2(0.337F, 0.01F), new Vector2(0.67F, 0.982F));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0011()
            {
                if (_cubicBezierEasingFunction_0011 != null)
                {
                    return _cubicBezierEasingFunction_0011;
                }
                return _cubicBezierEasingFunction_0011 = _c.CreateCubicBezierEasingFunction(new Vector2(0.611F, 0), new Vector2(0.927F, 1));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0012()
            {
                if (_cubicBezierEasingFunction_0012 != null)
                {
                    return _cubicBezierEasingFunction_0012;
                }
                return _cubicBezierEasingFunction_0012 = _c.CreateCubicBezierEasingFunction(new Vector2(0, 0), new Vector2(0.301F, 1));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0013()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.461F, 0), new Vector2(0.927F, 1));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0014()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(1, 0), new Vector2(0.755F, 1));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0015()
            {
                if (_cubicBezierEasingFunction_0015 != null)
                {
                    return _cubicBezierEasingFunction_0015;
                }
                return _cubicBezierEasingFunction_0015 = _c.CreateCubicBezierEasingFunction(new Vector2(0.205F, 0), new Vector2(0.224F, 1));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0016()
            {
                if (_cubicBezierEasingFunction_0016 != null)
                {
                    return _cubicBezierEasingFunction_0016;
                }
                return _cubicBezierEasingFunction_0016 = _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0), new Vector2(0.307F, 1));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0017()
            {
                if (_cubicBezierEasingFunction_0017 != null)
                {
                    return _cubicBezierEasingFunction_0017;
                }
                return _cubicBezierEasingFunction_0017 = _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0), new Vector2(0.667F, 1));
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
                result.Duration = TimeSpan.FromTicks(62170000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2064343F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.233244F, 0, CubicBezierEasingFunction_0007());
                result.InsertKeyFrame(0.2922252F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2949062F, 1, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.3217158F, 0, CubicBezierEasingFunction_0007());
                result.InsertKeyFrame(0.380697F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.383378F, 1, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.4101877F, 0, CubicBezierEasingFunction_0007());
                result.InsertKeyFrame(0.4691689F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4718499F, 1, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.4986595F, 0, CubicBezierEasingFunction_0007());
                result.InsertKeyFrame(0.5576407F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5603217F, 1, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.5871314F, 0, CubicBezierEasingFunction_0007());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0001()
            {
                if (_scalarKeyFrameAnimation_0001 != null)
                {
                    return _scalarKeyFrameAnimation_0001;
                }
                var result = _scalarKeyFrameAnimation_0001 = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(62170000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.233244F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2654155F, 0, CubicBezierEasingFunction_0009());
                result.InsertKeyFrame(0.2922252F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2949062F, 1, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.3217158F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3538874F, 0, CubicBezierEasingFunction_0009());
                result.InsertKeyFrame(0.380697F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.383378F, 1, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.4101877F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4423592F, 0, CubicBezierEasingFunction_0009());
                result.InsertKeyFrame(0.4691689F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4718499F, 1, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.4986595F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5308311F, 0, CubicBezierEasingFunction_0009());
                result.InsertKeyFrame(0.5576407F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5603217F, 1, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.5871314F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6193029F, 0, CubicBezierEasingFunction_0009());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0002()
            {
                if (_scalarKeyFrameAnimation_0002 != null)
                {
                    return _scalarKeyFrameAnimation_0002;
                }
                var result = _scalarKeyFrameAnimation_0002 = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(62170000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2198391F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2466488F, 0, CubicBezierEasingFunction_0007());
                result.InsertKeyFrame(0.30563F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.308311F, 1, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.3351206F, 0, CubicBezierEasingFunction_0007());
                result.InsertKeyFrame(0.3941019F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3967828F, 1, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.4235925F, 0, CubicBezierEasingFunction_0007());
                result.InsertKeyFrame(0.4825737F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4852547F, 1, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.5120643F, 0, CubicBezierEasingFunction_0007());
                result.InsertKeyFrame(0.5710456F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5737265F, 1, CubicBezierEasingFunction_0008());
                result.InsertKeyFrame(0.6005362F, 0, CubicBezierEasingFunction_0007());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0003()
            {
                if (_scalarKeyFrameAnimation_0003 != null)
                {
                    return _scalarKeyFrameAnimation_0003;
                }
                var result = _scalarKeyFrameAnimation_0003 = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(62170000);
                result.InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2466488F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2788204F, 0, CubicBezierEasingFunction_0009());
                result.InsertKeyFrame(0.30563F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.308311F, 1, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.3351206F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3672922F, 0, CubicBezierEasingFunction_0009());
                result.InsertKeyFrame(0.3941019F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3967828F, 1, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.4235925F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4557641F, 0, CubicBezierEasingFunction_0009());
                result.InsertKeyFrame(0.4825737F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4852547F, 1, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.5120643F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5442359F, 0, CubicBezierEasingFunction_0009());
                result.InsertKeyFrame(0.5710456F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5737265F, 1, CubicBezierEasingFunction_0010());
                result.InsertKeyFrame(0.6005362F, 1, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6327078F, 0, CubicBezierEasingFunction_0009());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0004()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(62170000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6782842F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7232637F, 1, CubicBezierEasingFunction_0011());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0005()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(62170000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7232627F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7804593F, 1, CubicBezierEasingFunction_0012());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0006()
            {
                if (_scalarKeyFrameAnimation_0006 != null)
                {
                    return _scalarKeyFrameAnimation_0006;
                }
                var result = _scalarKeyFrameAnimation_0006 = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(62170000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6887105F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.73637F, 1, CubicBezierEasingFunction_0011());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0007()
            {
                if (_scalarKeyFrameAnimation_0007 != null)
                {
                    return _scalarKeyFrameAnimation_0007;
                }
                var result = _scalarKeyFrameAnimation_0007 = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(62170000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.73637F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7935657F, 1, CubicBezierEasingFunction_0012());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0008()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(62170000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6782842F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7259446F, 1, CubicBezierEasingFunction_0011());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0009()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(62170000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7259437F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7831403F, 1, CubicBezierEasingFunction_0012());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0010()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(62170000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6648794F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7125398F, 1, CubicBezierEasingFunction_0011());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0011()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(62170000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7125389F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7697355F, 1, CubicBezierEasingFunction_0012());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0012()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(62170000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.844504F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8847185F, 1, CubicBezierEasingFunction_0013());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0013()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(62170000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.9544236F, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.997319F, 1, CubicBezierEasingFunction_0014());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0014()
            {
                if (_scalarKeyFrameAnimation_0014 != null)
                {
                    return _scalarKeyFrameAnimation_0014;
                }
                var result = _scalarKeyFrameAnimation_0014 = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(62170000);
                result.InsertKeyFrame(0, -307, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6782842F, -307, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7828418F, -49, CubicBezierEasingFunction_0017());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0015()
            {
                if (_scalarKeyFrameAnimation_0015 != null)
                {
                    return _scalarKeyFrameAnimation_0015;
                }
                var result = _scalarKeyFrameAnimation_0015 = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(62170000);
                result.InsertKeyFrame(0, 6, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7372654F, 6, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7828418F, 0, CubicBezierEasingFunction_0017());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0016()
            {
                if (_scalarKeyFrameAnimation_0016 != null)
                {
                    return _scalarKeyFrameAnimation_0016;
                }
                var result = _scalarKeyFrameAnimation_0016 = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(62170000);
                result.InsertKeyFrame(0, 4, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7372654F, 4, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7828418F, 0, CubicBezierEasingFunction_0017());
                return result;
            }
            
            ShapeVisual ShapeVisual_0000()
            {
                var result = _c.CreateShapeVisual();
                result.Size = new Vector2(500, 500);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0000());
                shapes.Add(CompositionContainerShape_0002());
                shapes.Add(CompositionContainerShape_0012());
                shapes.Add(CompositionContainerShape_0023());
                shapes.Add(CompositionContainerShape_0030());
                shapes.Add(CompositionContainerShape_0036());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0000()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(62170000);
                result.InsertKeyFrame(0, new Vector2(1, 1), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1608579F, new Vector2(1, 1), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2064343F, new Vector2(1.05F, 1.05F), CubicBezierEasingFunction_0000());
                result.InsertKeyFrame(0.6327078F, new Vector2(1.05F, 1.05F), CubicBezierEasingFunction_0001());
                result.InsertKeyFrame(0.6863271F, new Vector2(1.4F, 1.4F), CubicBezierEasingFunction_0002());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0001()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(62170000);
                result.InsertKeyFrame(0, new Vector2(251.606F, 255.298F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2064343F, new Vector2(251.606F, 255.298F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2225201F, new Vector2(252.606F, 253.298F), CubicBezierEasingFunction_0003());
                result.InsertKeyFrame(0.2386059F, new Vector2(250.606F, 257.298F), CubicBezierEasingFunction_0003());
                result.InsertKeyFrame(0.2546917F, new Vector2(250.606F, 253.298F), CubicBezierEasingFunction_0003());
                result.InsertKeyFrame(0.2707775F, new Vector2(252.606F, 256.298F), CubicBezierEasingFunction_0003());
                result.InsertKeyFrame(0.2868633F, new Vector2(250.606F, 253.298F), CubicBezierEasingFunction_0003());
                result.InsertKeyFrame(0.3029491F, new Vector2(252.606F, 254.298F), CubicBezierEasingFunction_0003());
                result.InsertKeyFrame(0.3190348F, new Vector2(251.606F, 257.298F), CubicBezierEasingFunction_0003());
                result.InsertKeyFrame(0.3351206F, new Vector2(251.606F, 253.298F), CubicBezierEasingFunction_0003());
                result.InsertKeyFrame(0.3512064F, new Vector2(251.606F, 255.298F), CubicBezierEasingFunction_0003());
                result.InsertKeyFrame(0.3672922F, new Vector2(252.606F, 253.298F), CubicBezierEasingFunction_0003());
                result.InsertKeyFrame(0.383378F, new Vector2(250.606F, 257.298F), CubicBezierEasingFunction_0003());
                result.InsertKeyFrame(0.3994638F, new Vector2(250.606F, 253.298F), CubicBezierEasingFunction_0003());
                result.InsertKeyFrame(0.4155496F, new Vector2(252.606F, 256.298F), CubicBezierEasingFunction_0003());
                result.InsertKeyFrame(0.4316354F, new Vector2(250.606F, 253.298F), CubicBezierEasingFunction_0003());
                result.InsertKeyFrame(0.4477212F, new Vector2(252.606F, 254.298F), CubicBezierEasingFunction_0003());
                result.InsertKeyFrame(0.463807F, new Vector2(251.606F, 257.298F), CubicBezierEasingFunction_0003());
                result.InsertKeyFrame(0.4798928F, new Vector2(251.606F, 253.298F), CubicBezierEasingFunction_0003());
                result.InsertKeyFrame(0.4959786F, new Vector2(251.606F, 255.298F), CubicBezierEasingFunction_0003());
                result.InsertKeyFrame(0.5120643F, new Vector2(252.606F, 253.298F), CubicBezierEasingFunction_0003());
                result.InsertKeyFrame(0.5281501F, new Vector2(250.606F, 257.298F), CubicBezierEasingFunction_0003());
                result.InsertKeyFrame(0.5442359F, new Vector2(250.606F, 253.298F), CubicBezierEasingFunction_0003());
                result.InsertKeyFrame(0.5603217F, new Vector2(252.606F, 256.298F), CubicBezierEasingFunction_0003());
                result.InsertKeyFrame(0.5764075F, new Vector2(250.606F, 253.298F), CubicBezierEasingFunction_0003());
                result.InsertKeyFrame(0.5924933F, new Vector2(252.606F, 254.298F), CubicBezierEasingFunction_0003());
                result.InsertKeyFrame(0.6085791F, new Vector2(251.606F, 257.298F), CubicBezierEasingFunction_0003());
                result.InsertKeyFrame(0.6246649F, new Vector2(251.606F, 253.298F), CubicBezierEasingFunction_0003());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0002()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(62170000);
                result.InsertKeyFrame(0, new Vector2(1, 1), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1608579F, new Vector2(1, 1), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2064343F, new Vector2(0.85F, 0.85F), CubicBezierEasingFunction_0004());
                result.InsertKeyFrame(0.6327078F, new Vector2(0.85F, 0.85F), CubicBezierEasingFunction_0005());
                result.InsertKeyFrame(0.6863271F, new Vector2(0, 0), CubicBezierEasingFunction_0006());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0003()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(62170000);
                result.InsertKeyFrame(0, new Vector2(-50.75F, -86.75F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6782842F, new Vector2(-50.75F, -86.75F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7828418F, new Vector2(46, -199.75F), CubicBezierEasingFunction_0015());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0004()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(62170000);
                result.InsertKeyFrame(0, new Vector2(0, 0), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6782842F, new Vector2(0, 0), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7828418F, new Vector2(0.77F, 0.77F), CubicBezierEasingFunction_0016());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0005()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(62170000);
                result.InsertKeyFrame(0, new Vector2(-50.75F, -86.75F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6782842F, new Vector2(-50.75F, -86.75F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7828418F, new Vector2(-66.5F, -27.25F), CubicBezierEasingFunction_0015());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0006()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(62170000);
                result.InsertKeyFrame(0, new Vector2(0, 0), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6782842F, new Vector2(0, 0), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7828418F, new Vector2(0.45F, 0.45F), CubicBezierEasingFunction_0016());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0007()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(62170000);
                result.InsertKeyFrame(0, new Vector2(-50.75F, -86.75F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6782842F, new Vector2(-50.75F, -86.75F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7828418F, new Vector2(-183, -88.25F), CubicBezierEasingFunction_0015());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0008()
            {
                if (_vector2KeyFrameAnimation_0008 != null)
                {
                    return _vector2KeyFrameAnimation_0008;
                }
                var result = _vector2KeyFrameAnimation_0008 = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(62170000);
                result.InsertKeyFrame(0, new Vector2(0, 0), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6782842F, new Vector2(0, 0), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7828418F, new Vector2(0.82F, 0.82F), CubicBezierEasingFunction_0016());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0009()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(62170000);
                result.InsertKeyFrame(0, new Vector2(-50.75F, -86.75F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6782842F, new Vector2(-50.75F, -86.75F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7828418F, new Vector2(-127.5F, -210.75F), CubicBezierEasingFunction_0015());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0010()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(62170000);
                result.InsertKeyFrame(0, new Vector2(-50.75F, -86.75F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6782842F, new Vector2(-50.75F, -86.75F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7828418F, new Vector2(69.5F, -38.75F), CubicBezierEasingFunction_0015());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0011()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(62170000);
                result.InsertKeyFrame(0, new Vector2(0, 0), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6782842F, new Vector2(0, 0), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7828418F, new Vector2(0.49F, 0.49F), CubicBezierEasingFunction_0016());
                return result;
            }
            
        }
    }
}
