#include "pch.h"
#include "d2d1.h"
#include <d2d1_1.h>
#include <d2d1helper.h>
#include "WindowsNumerics.h"
#include <Windows.Graphics.Interop.h>
#include <windows.ui.composition.interop.h>
#include "GeoSource.h"
#include <wrl.h>

using namespace Windows::Foundation;
using namespace Windows::Foundation::Numerics;
using namespace Windows::UI;
using namespace Windows::UI::Composition;
using namespace Windows::Graphics;
using namespace Microsoft::WRL;

namespace Compositions
{
    class Oobe_hi sealed
    {
        public:
        bool TryCreateInstance(
            Compositor^ const compositor,
            Visual^& rootVisual,
            float2& size,
            CompositionPropertySet^& progressPropertySet,
            TimeSpan& duration)
        {
            Instantiator comp(compositor);
            rootVisual = comp.GetRootContainerVisual();
            size = {1920, 1280};
            progressPropertySet = rootVisual->Properties;
            duration.Duration = 98670000L;
            return true;
        }
        
        private:
        class Instantiator sealed
        {
            public:
            Instantiator::Instantiator(Compositor^ compositor)
            {
                _c = compositor;
                _expressionAnimation = compositor->CreateExpressionAnimation();
                HRESULT hr = D2D1CreateFactory(D2D1_FACTORY_TYPE_SINGLE_THREADED, _d2dFactory.GetAddressOf());
                if (hr != S_OK)
                {
                    throw ref new Platform::Exception(hr);
                }
            }
            
            ContainerVisual^ GetRootContainerVisual()
            {
                return ContainerVisual_0000();
            }
            
            private:
            Compositor^ _c;
            ComPtr<ID2D1Factory> _d2dFactory;
            ExpressionAnimation^ _expressionAnimation;
            ColorKeyFrameAnimation^ _colorKeyFrameAnimation_0000;
            CompositionColorBrush^ _compositionColorBrush_0000;
            CompositionRectangleGeometry^ _compositionRectangleGeometry_0000;
            ContainerVisual^ _containerVisual_0000;
            CubicBezierEasingFunction^ _cubicBezierEasingFunction_0010;
            CubicBezierEasingFunction^ _cubicBezierEasingFunction_0015;
            ExpressionAnimation^ _expressionAnimation_0000;
            LinearEasingFunction^ _linearEasingFunction_0000;
            ScalarKeyFrameAnimation^ _scalarKeyFrameAnimation_0003;
            ScalarKeyFrameAnimation^ _scalarKeyFrameAnimation_0004;
            ScalarKeyFrameAnimation^ _scalarKeyFrameAnimation_0005;
            ScalarKeyFrameAnimation^ _scalarKeyFrameAnimation_0006;
            
            static IGeometrySource2D^ D2DPathGeometryToIGeometrySource2D(ComPtr<ID2D1PathGeometry> path)
            {
                ComPtr<GeoSource> geoSource = new GeoSource(path.Get());
                ComPtr<ABI::Windows::Graphics::IGeometrySource2D> interop = geoSource.Detach();
                return (reinterpret_cast<IGeometrySource2D^>(interop.Get()));
            }
            
            IGeometrySource2D^ CanvasGeometry_0000()
            {
                ComPtr<ID2D1PathGeometry> path;
                _d2dFactory->CreatePathGeometry(&path);
                ComPtr<ID2D1GeometrySink> sink;
                path->Open(&sink);
                sink->BeginFigure({-634.375F, -102.25F}, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({{-657.003F, 116.795F}, {-571.97F, 240.615F}, {-374.625F, 333.719F}});
                sink->AddBezier({{-90, 468}, {180, 298}, {477.501F, -3.75F}});
                sink->EndFigure(D2D1_FIGURE_END_OPEN);
                sink->Close();
                return D2DPathGeometryToIGeometrySource2D(path);
            }
            
            IGeometrySource2D^ CanvasGeometry_0001()
            {
                ComPtr<ID2D1PathGeometry> path;
                _d2dFactory->CreatePathGeometry(&path);
                ComPtr<ID2D1GeometrySink> sink;
                path->Open(&sink);
                sink->BeginFigure({-32, 2}, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({{-32, 2}, {-2, 2}, {-2, 2}});
                sink->AddBezier({{-2, 2}, {-2, 32}, {-2, 32}});
                sink->AddBezier({{-2, 32}, {-32, 32}, {-32, 32}});
                sink->AddBezier({{-32, 32}, {-32, 2}, {-32, 2}});
                sink->EndFigure(D2D1_FIGURE_END_CLOSED);
                sink->Close();
                return D2DPathGeometryToIGeometrySource2D(path);
            }
            
            IGeometrySource2D^ CanvasGeometry_0002()
            {
                ComPtr<ID2D1PathGeometry> path;
                _d2dFactory->CreatePathGeometry(&path);
                ComPtr<ID2D1GeometrySink> sink;
                path->Open(&sink);
                sink->BeginFigure({-490.75F, 69}, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({{-490.75F, 69}, {-328.25F, 72.25F}, {-328.25F, 72.25F}});
                sink->EndFigure(D2D1_FIGURE_END_OPEN);
                sink->Close();
                return D2DPathGeometryToIGeometrySource2D(path);
            }
            
            IGeometrySource2D^ CanvasGeometry_0003()
            {
                ComPtr<ID2D1PathGeometry> path;
                _d2dFactory->CreatePathGeometry(&path);
                ComPtr<ID2D1GeometrySink> sink;
                path->Open(&sink);
                sink->BeginFigure({-414.25F, 53.5F}, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({{-414.25F, 53.5F}, {-410.5F, 120}, {-411.5F, 124.75F}});
                sink->AddBezier({{-412.5F, 129.5F}, {-435, 136}, {-448.75F, 123}});
                sink->EndFigure(D2D1_FIGURE_END_OPEN);
                sink->Close();
                return D2DPathGeometryToIGeometrySource2D(path);
            }
            
            IGeometrySource2D^ CanvasGeometry_0004()
            {
                ComPtr<ID2D1PathGeometry> path;
                _d2dFactory->CreatePathGeometry(&path);
                ComPtr<ID2D1GeometrySink> sink;
                path->Open(&sink);
                sink->BeginFigure({-453.75F, 24.5F}, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({{-453.75F, 24.5F}, {-365.75F, 26.25F}, {-365.75F, 26.25F}});
                sink->AddBezier({{-365.75F, 26.25F}, {-412, 66.25F}, {-412, 66.25F}});
                sink->EndFigure(D2D1_FIGURE_END_OPEN);
                sink->Close();
                return D2DPathGeometryToIGeometrySource2D(path);
            }
            
            IGeometrySource2D^ CanvasGeometry_0005()
            {
                ComPtr<ID2D1PathGeometry> path;
                _d2dFactory->CreatePathGeometry(&path);
                ComPtr<ID2D1GeometrySink> sink;
                path->Open(&sink);
                sink->BeginFigure({-411.75F, -49.25F}, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({{-411.75F, -49.25F}, {-411.75F, -18.75F}, {-411.75F, -18.75F}});
                sink->EndFigure(D2D1_FIGURE_END_OPEN);
                sink->Close();
                return D2DPathGeometryToIGeometrySource2D(path);
            }
            
            IGeometrySource2D^ CanvasGeometry_0006()
            {
                ComPtr<ID2D1PathGeometry> path;
                _d2dFactory->CreatePathGeometry(&path);
                ComPtr<ID2D1GeometrySink> sink;
                path->Open(&sink);
                sink->BeginFigure({-485.5F, 24}, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({{-485.5F, 24}, {-489.5F, -7.5F}, {-484, -10}});
                sink->AddBezier({{-478.5F, -12.5F}, {-421, -14.5F}, {-409.75F, -14.25F}});
                sink->AddBezier({{-398.5F, -14}, {-337.5F, -10}, {-335.5F, -7.5F}});
                sink->AddBezier({{-333.5F, -5}, {-335, 29}, {-335, 29}});
                sink->EndFigure(D2D1_FIGURE_END_OPEN);
                sink->Close();
                return D2DPathGeometryToIGeometrySource2D(path);
            }
            
            IGeometrySource2D^ CanvasGeometry_0007()
            {
                ComPtr<ID2D1PathGeometry> path;
                _d2dFactory->CreatePathGeometry(&path);
                ComPtr<ID2D1GeometrySink> sink;
                path->Open(&sink);
                sink->BeginFigure({-583, 105}, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({{-583, 105}, {-529, 107}, {-529, 107}});
                sink->EndFigure(D2D1_FIGURE_END_OPEN);
                sink->Close();
                return D2DPathGeometryToIGeometrySource2D(path);
            }
            
            IGeometrySource2D^ CanvasGeometry_0008()
            {
                ComPtr<ID2D1PathGeometry> path;
                _d2dFactory->CreatePathGeometry(&path);
                ComPtr<ID2D1GeometrySink> sink;
                path->Open(&sink);
                sink->BeginFigure({-603.5F, 152}, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({{-603.5F, 152}, {-560, 22}, {-560, 22}});
                sink->AddBezier({{-560, 22}, {-511, 152}, {-511, 152}});
                sink->EndFigure(D2D1_FIGURE_END_OPEN);
                sink->Close();
                return D2DPathGeometryToIGeometrySource2D(path);
            }
            
            IGeometrySource2D^ CanvasGeometry_0009()
            {
                ComPtr<ID2D1PathGeometry> path;
                _d2dFactory->CreatePathGeometry(&path);
                ComPtr<ID2D1GeometrySink> sink;
                path->Open(&sink);
                sink->BeginFigure({-614.25F, -28}, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({{-614.25F, -28}, {-508.25F, -28.25F}, {-508.25F, -28.25F}});
                sink->EndFigure(D2D1_FIGURE_END_OPEN);
                sink->Close();
                return D2DPathGeometryToIGeometrySource2D(path);
            }
            
            IGeometrySource2D^ CanvasGeometry_0010()
            {
                ComPtr<ID2D1PathGeometry> path;
                _d2dFactory->CreatePathGeometry(&path);
                ComPtr<ID2D1GeometrySink> sink;
                path->Open(&sink);
                sink->BeginFigure({-618.25F, -89.75F}, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({{-618.25F, -89.75F}, {-454.75F, -90}, {-454.75F, -90}});
                sink->EndFigure(D2D1_FIGURE_END_OPEN);
                sink->Close();
                return D2DPathGeometryToIGeometrySource2D(path);
            }
            
            IGeometrySource2D^ CanvasGeometry_0011()
            {
                ComPtr<ID2D1PathGeometry> path;
                _d2dFactory->CreatePathGeometry(&path);
                ComPtr<ID2D1GeometrySink> sink;
                path->Open(&sink);
                sink->BeginFigure({-527.75F, -149.5F}, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({{-527.75F, -149.5F}, {-493.5F, -112}, {-508, -28.75F}});
                sink->EndFigure(D2D1_FIGURE_END_OPEN);
                sink->Close();
                return D2DPathGeometryToIGeometrySource2D(path);
            }
            
            IGeometrySource2D^ CanvasGeometry_0012()
            {
                ComPtr<ID2D1PathGeometry> path;
                _d2dFactory->CreatePathGeometry(&path);
                ComPtr<ID2D1GeometrySink> sink;
                path->Open(&sink);
                sink->BeginFigure({-538.75F, -152.75F}, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({{-538.75F, -152.75F}, {-582, -128.25F}, {-565, -13}});
                sink->EndFigure(D2D1_FIGURE_END_OPEN);
                sink->Close();
                return D2DPathGeometryToIGeometrySource2D(path);
            }
            
            IGeometrySource2D^ CanvasGeometry_0013()
            {
                ComPtr<ID2D1PathGeometry> path;
                _d2dFactory->CreatePathGeometry(&path);
                ComPtr<ID2D1GeometrySink> sink;
                path->Open(&sink);
                sink->BeginFigure({-350.875F, 2.563F}, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({{-318.057F, -37.59F}, {-278, -104.5F}, {-267.5F, -218}});
                sink->AddBezier({{-254.778F, -355.522F}, {-340.099F, -462.564F}, {-497, -457}});
                sink->AddBezier({{-638, -452}, {-748, -346.5F}, {-772.5F, -205}});
                sink->AddBezier({{-795.965F, -69.48F}, {-708.855F, 66.771F}, {-596, 72.5F}});
                sink->AddBezier({{-497.5F, 77.5F}, {-475.115F, 23.436F}, {-458, -29}});
                sink->AddBezier({{-434.5F, -101}, {-476, -158}, {-539.5F, -155.5F}});
                sink->AddBezier({{-603, -153}, {-656, -77}, {-603, 0}});
                sink->EndFigure(D2D1_FIGURE_END_OPEN);
                sink->Close();
                return D2DPathGeometryToIGeometrySource2D(path);
            }
            
            IGeometrySource2D^ CanvasGeometry_0014()
            {
                ComPtr<ID2D1PathGeometry> path;
                _d2dFactory->CreatePathGeometry(&path);
                ComPtr<ID2D1GeometrySink> sink;
                path->Open(&sink);
                sink->BeginFigure({39.255F, -2.916F}, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({{39.255F, -2.916F}, {39.581F, -2.921F}, {39.686F, -3.084F}});
                sink->EndFigure(D2D1_FIGURE_END_OPEN);
                sink->Close();
                return D2DPathGeometryToIGeometrySource2D(path);
            }
            
            IGeometrySource2D^ CanvasGeometry_0015()
            {
                ComPtr<ID2D1PathGeometry> path;
                _d2dFactory->CreatePathGeometry(&path);
                ComPtr<ID2D1GeometrySink> sink;
                path->Open(&sink);
                sink->BeginFigure({9.343F, -41.95F}, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({{-17.589F, 1.072F}, {-22.472F, 21.165F}, {-26.658F, 61.14F}});
                sink->AddBezier({{-33.15F, 39.317F}, {-45.95F, 28.594F}, {-54.725F, 15.439F}});
                sink->AddBezier({{-58.236F, 10.175F}, {-62.588F, 5.041F}, {-68.55F, 2.922F}});
                sink->AddBezier({{-70.214F, 2.331F}, {-72.058F, 1.996F}, {-73.737F, 2.542F}});
                sink->AddBezier({{-76.888F, 3.566F}, {-78.365F, 8.893F}, {-77.589F, 12.114F}});
                sink->AddBezier({{-76.813F, 15.335F}, {-72.957F, 17.885F}, {-70.312F, 19.88F}});
                sink->AddBezier({{-58.372F, 28.885F}, {-35.218F, 29.926F}, {-21.25F, 24.584F}});
                sink->AddBezier({{-7.282F, 19.242F}, {4.934F, 8.287F}, {15.121F, -2.662F}});
                sink->EndFigure(D2D1_FIGURE_END_OPEN);
                sink->Close();
                return D2DPathGeometryToIGeometrySource2D(path);
            }
            
            IGeometrySource2D^ CanvasGeometry_0016()
            {
                ComPtr<ID2D1PathGeometry> path;
                _d2dFactory->CreatePathGeometry(&path);
                ComPtr<ID2D1GeometrySink> sink;
                path->Open(&sink);
                sink->BeginFigure({-71.97F, 61.14F}, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({{-58.417F, 35.342F}, {-42.769F, 2.237F}, {-29.216F, -23.561F}});
                sink->AddBezier({{-25.12F, -31.358F}, {-20.902F, -40.165F}, {-23.353F, -48.625F}});
                sink->AddBezier({{-24.517F, -52.645F}, {-29.167F, -62.24F}, {-42.741F, -61.083F}});
                sink->AddBezier({{-52.357F, -60.264F}, {-56.629F, -55.143F}, {-60.709F, -50.459F}});
                sink->AddBezier({{-66.666F, -43.62F}, {-71.354F, -30.469F}, {-71.535F, -20.901F}});
                sink->EndFigure(D2D1_FIGURE_END_OPEN);
                sink->Close();
                return D2DPathGeometryToIGeometrySource2D(path);
            }
            
            IGeometrySource2D^ CanvasGeometry_0017()
            {
                ComPtr<ID2D1PathGeometry> path;
                _d2dFactory->CreatePathGeometry(&path);
                ComPtr<ID2D1GeometrySink> sink;
                path->Open(&sink);
                sink->BeginFigure({-7.166F, 61.14F}, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({{5.054F, 51.775F}, {23.12F, 25.718F}, {31.215F, 14.758F}});
                sink->AddBezier({{28.639F, 20.594F}, {24.895F, 39.322F}, {24.96F, 45.701F}});
                sink->AddBezier({{25.025F, 52.08F}, {28.56F, 59.36F}, {34.686F, 61.14F}});
                sink->AddBezier({{40.478F, 62.823F}, {46.508F, 59.217F}, {51.483F, 55.806F}});
                sink->AddBezier({{61.489F, 48.945F}, {70.405F, 40.497F}, {77.793F, 30.873F}});
                sink->EndFigure(D2D1_FIGURE_END_OPEN);
                sink->Close();
                return D2DPathGeometryToIGeometrySource2D(path);
            }
            
            IGeometrySource2D^ CanvasGeometry_0018()
            {
                ComPtr<ID2D1PathGeometry> path;
                _d2dFactory->CreatePathGeometry(&path);
                ComPtr<ID2D1GeometrySink> sink;
                path->Open(&sink);
                sink->BeginFigure({8, 360}, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({{8, 360}, {-8, 360}, {-8, 360}});
                sink->AddBezier({{-8, 360}, {-8, -360}, {-8, -360}});
                sink->AddBezier({{-8, -360}, {8, -360}, {8, -360}});
                sink->AddBezier({{8, -360}, {8, 360}, {8, 360}});
                sink->EndFigure(D2D1_FIGURE_END_CLOSED);
                sink->Close();
                return D2DPathGeometryToIGeometrySource2D(path);
            }
            
            ColorKeyFrameAnimation^ ColorKeyFrameAnimation_0000()
            {
                if (_colorKeyFrameAnimation_0000 != nullptr)
                {
                    return _colorKeyFrameAnimation_0000;
                }
                auto result = _colorKeyFrameAnimation_0000 = _c->CreateColorKeyFrameAnimation();
                result->Duration = TimeSpan{98670000L};
                result->InsertKeyFrame(0, ColorHelper::FromArgb(0x00, 0xFF, 0xFF, 0xFF), LinearEasingFunction_0000());
                result->InsertKeyFrame(0.08783784F, ColorHelper::FromArgb(0xFF, 0xFF, 0xFF, 0xFF), CubicBezierEasingFunction_0006());
                result->InsertKeyFrame(0.1266892F, ColorHelper::FromArgb(0xFF, 0xFF, 0xFF, 0xFF), LinearEasingFunction_0000());
                result->InsertKeyFrame(0.2128378F, ColorHelper::FromArgb(0x00, 0xFF, 0xFF, 0xFF), CubicBezierEasingFunction_0007());
                return result;
            }
            
            CompositionColorBrush^ CompositionColorBrush_0000()
            {
                if (_compositionColorBrush_0000 != nullptr)
                {
                    return _compositionColorBrush_0000;
                }
                auto result = _compositionColorBrush_0000 = _c->CreateColorBrush(ColorHelper::FromArgb(0xFF, 0x00, 0x00, 0x00));
                return result;
            }
            
            CompositionColorBrush^ CompositionColorBrush_0001()
            {
                return _c->CreateColorBrush(ColorHelper::FromArgb(0xFF, 0xEB, 0xEB, 0xEB));
            }
            
            CompositionColorBrush^ CompositionColorBrush_0002()
            {
                auto result = _c->CreateColorBrush(ColorHelper::FromArgb(0x00, 0xFF, 0xFF, 0xFF));
                result->StartAnimation("Color", ColorKeyFrameAnimation_0000());
                auto controller = result->TryGetAnimationController("Color");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionColorBrush^ CompositionColorBrush_0003()
            {
                auto result = _c->CreateColorBrush(ColorHelper::FromArgb(0x00, 0xFF, 0xFF, 0xFF));
                result->StartAnimation("Color", ColorKeyFrameAnimation_0000());
                auto controller = result->TryGetAnimationController("Color");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionColorBrush^ CompositionColorBrush_0004()
            {
                auto result = _c->CreateColorBrush(ColorHelper::FromArgb(0x00, 0xFF, 0xFF, 0xFF));
                result->StartAnimation("Color", ColorKeyFrameAnimation_0000());
                auto controller = result->TryGetAnimationController("Color");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionColorBrush^ CompositionColorBrush_0005()
            {
                auto result = _c->CreateColorBrush(ColorHelper::FromArgb(0x00, 0xFF, 0xFF, 0xFF));
                result->StartAnimation("Color", ColorKeyFrameAnimation_0000());
                auto controller = result->TryGetAnimationController("Color");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionColorBrush^ CompositionColorBrush_0006()
            {
                return _c->CreateColorBrush(ColorHelper::FromArgb(0xEA, 0x0F, 0x0F, 0x0F));
            }
            
            CompositionContainerShape^ CompositionContainerShape_0000()
            {
                auto result = _c->CreateContainerShape();
                result->CenterPoint = float2(960, 540);
                result->Offset = float2(-17, 9);
                result->Scale = float2(1.71F, 1.71F);
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0000());
                return result;
            }
            
            CompositionContainerShape^ CompositionContainerShape_0001()
            {
                auto result = _c->CreateContainerShape();
                result->CenterPoint = float2(960, 540);
                result->Offset = float2(0, 100);
                result->Scale = float2(1.66F, 1.66F);
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0001());
                return result;
            }
            
            CompositionContainerShape^ CompositionContainerShape_0002()
            {
                auto result = _c->CreateContainerShape();
                result->Offset = float2(960, 640);
                auto shapes = result->Shapes;
                shapes->Append(CompositionContainerShape_0003());
                return result;
            }
            
            CompositionContainerShape^ CompositionContainerShape_0003()
            {
                auto result = _c->CreateContainerShape();
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0002());
                return result;
            }
            
            CompositionContainerShape^ CompositionContainerShape_0004()
            {
                auto result = _c->CreateContainerShape();
                result->CenterPoint = float2(0.25F, 0.25F);
                result->Offset = float2(1440.3F, 635.712F);
                result->Scale = float2(1.7F, 1.7F);
                auto shapes = result->Shapes;
                shapes->Append(CompositionContainerShape_0005());
                result->StartAnimation("Scale", Vector2KeyFrameAnimation_0000());
                auto controller = result->TryGetAnimationController("Scale");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionContainerShape^ CompositionContainerShape_0005()
            {
                auto result = _c->CreateContainerShape();
                auto shapes = result->Shapes;
                shapes->Append(CompositionContainerShape_0006());
                shapes->Append(CompositionContainerShape_0007());
                shapes->Append(CompositionContainerShape_0008());
                shapes->Append(CompositionContainerShape_0009());
                _expressionAnimation->ClearAllParameters();
                _expressionAnimation->Expression = "(_.Progress < 0.214527) ? (Matrix3x2(1,0,0,1,0,0)) : (Matrix3x2(0,0,0,0,0,0))";
                _expressionAnimation->SetReferenceParameter("_", ContainerVisual_0000());
                result->StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }
            
            CompositionContainerShape^ CompositionContainerShape_0006()
            {
                auto result = _c->CreateContainerShape();
                result->Offset = float2(-17, -16.5F);
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0003());
                return result;
            }
            
            CompositionContainerShape^ CompositionContainerShape_0007()
            {
                auto result = _c->CreateContainerShape();
                result->Offset = float2(17.508F, -16.5F);
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0004());
                return result;
            }
            
            CompositionContainerShape^ CompositionContainerShape_0008()
            {
                auto result = _c->CreateContainerShape();
                result->Offset = float2(17.5F, 17);
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0005());
                return result;
            }
            
            CompositionContainerShape^ CompositionContainerShape_0009()
            {
                auto result = _c->CreateContainerShape();
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0006());
                return result;
            }
            
            CompositionContainerShape^ CompositionContainerShape_0010()
            {
                auto result = _c->CreateContainerShape();
                result->CenterPoint = float2(-451.433F, -25.173F);
                result->Offset = float2(960, 640);
                auto shapes = result->Shapes;
                shapes->Append(CompositionContainerShape_0011());
                return result;
            }
            
            CompositionContainerShape^ CompositionContainerShape_0011()
            {
                auto result = _c->CreateContainerShape();
                auto shapes = result->Shapes;
                shapes->Append(CompositionContainerShape_0012());
                shapes->Append(CompositionContainerShape_0013());
                shapes->Append(CompositionContainerShape_0014());
                shapes->Append(CompositionContainerShape_0015());
                shapes->Append(CompositionContainerShape_0016());
                _expressionAnimation->ClearAllParameters();
                _expressionAnimation->Expression = "(_.Progress < 0.6047297) ? (Matrix3x2(0,0,0,0,0,0)) : (Matrix3x2(1,0,0,1,0,0))";
                _expressionAnimation->SetReferenceParameter("_", ContainerVisual_0000());
                result->StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }
            
            CompositionContainerShape^ CompositionContainerShape_0012()
            {
                auto result = _c->CreateContainerShape();
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0007());
                shapes->Append(CompositionSpriteShape_0008());
                shapes->Append(CompositionSpriteShape_0009());
                return result;
            }
            
            CompositionContainerShape^ CompositionContainerShape_0013()
            {
                auto result = _c->CreateContainerShape();
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0010());
                shapes->Append(CompositionSpriteShape_0011());
                return result;
            }
            
            CompositionContainerShape^ CompositionContainerShape_0014()
            {
                auto result = _c->CreateContainerShape();
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0012());
                shapes->Append(CompositionSpriteShape_0013());
                return result;
            }
            
            CompositionContainerShape^ CompositionContainerShape_0015()
            {
                auto result = _c->CreateContainerShape();
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0014());
                shapes->Append(CompositionSpriteShape_0015());
                shapes->Append(CompositionSpriteShape_0016());
                shapes->Append(CompositionSpriteShape_0017());
                return result;
            }
            
            CompositionContainerShape^ CompositionContainerShape_0016()
            {
                auto result = _c->CreateContainerShape();
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0018());
                return result;
            }
            
            CompositionContainerShape^ CompositionContainerShape_0017()
            {
                auto result = _c->CreateContainerShape();
                result->Offset = float2(463, 579);
                result->Scale = float2(1.92F, 1.92F);
                auto shapes = result->Shapes;
                shapes->Append(CompositionContainerShape_0018());
                return result;
            }
            
            CompositionContainerShape^ CompositionContainerShape_0018()
            {
                auto result = _c->CreateContainerShape();
                auto shapes = result->Shapes;
                shapes->Append(CompositionContainerShape_0019());
                shapes->Append(CompositionContainerShape_0020());
                _expressionAnimation->ClearAllParameters();
                _expressionAnimation->Expression = "(_.Progress < 0.2736486) ? (Matrix3x2(0,0,0,0,0,0)) : (Matrix3x2(1,0,0,1,0,0))";
                _expressionAnimation->SetReferenceParameter("_", ContainerVisual_0000());
                result->StartAnimation("TransformMatrix", _expressionAnimation);
                return result;
            }
            
            CompositionContainerShape^ CompositionContainerShape_0019()
            {
                auto result = _c->CreateContainerShape();
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0019());
                return result;
            }
            
            CompositionContainerShape^ CompositionContainerShape_0020()
            {
                auto result = _c->CreateContainerShape();
                auto shapes = result->Shapes;
                shapes->Append(CompositionContainerShape_0021());
                shapes->Append(CompositionContainerShape_0024());
                return result;
            }
            
            CompositionContainerShape^ CompositionContainerShape_0021()
            {
                auto result = _c->CreateContainerShape();
                auto shapes = result->Shapes;
                shapes->Append(CompositionContainerShape_0022());
                shapes->Append(CompositionContainerShape_0023());
                return result;
            }
            
            CompositionContainerShape^ CompositionContainerShape_0022()
            {
                auto result = _c->CreateContainerShape();
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0020());
                return result;
            }
            
            CompositionContainerShape^ CompositionContainerShape_0023()
            {
                auto result = _c->CreateContainerShape();
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0021());
                return result;
            }
            
            CompositionContainerShape^ CompositionContainerShape_0024()
            {
                auto result = _c->CreateContainerShape();
                auto shapes = result->Shapes;
                shapes->Append(CompositionContainerShape_0025());
                return result;
            }
            
            CompositionContainerShape^ CompositionContainerShape_0025()
            {
                auto result = _c->CreateContainerShape();
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0022());
                return result;
            }
            
            CompositionContainerShape^ CompositionContainerShape_0026()
            {
                auto result = _c->CreateContainerShape();
                result->Offset = float2(960, 640);
                result->Scale = float2(1.775F, 1.775F);
                auto shapes = result->Shapes;
                shapes->Append(CompositionContainerShape_0027());
                return result;
            }
            
            CompositionContainerShape^ CompositionContainerShape_0027()
            {
                auto result = _c->CreateContainerShape();
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0023());
                return result;
            }
            
            CompositionPathGeometry^ CompositionPathGeometry_0000()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometry_0000()));
                auto propertySet = result->Properties;
                propertySet->InsertScalar("TStart", 1);
                propertySet->InsertScalar("TEnd", 0.99F);
                result->StartAnimation("TStart", ScalarKeyFrameAnimation_0001());
                auto controller = result->TryGetAnimationController("TStart");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                result->StartAnimation("TEnd", ScalarKeyFrameAnimation_0002());
                controller = result->TryGetAnimationController("TEnd");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                _expressionAnimation->ClearAllParameters();
                _expressionAnimation->Expression = "Min(my.TStart,my.TEnd)";
                _expressionAnimation->SetReferenceParameter("my", result);
                result->StartAnimation("TrimStart", _expressionAnimation);
                _expressionAnimation->ClearAllParameters();
                _expressionAnimation->Expression = "Max(my.TStart,my.TEnd)";
                _expressionAnimation->SetReferenceParameter("my", result);
                result->StartAnimation("TrimEnd", _expressionAnimation);
                return result;
            }
            
            CompositionPathGeometry^ CompositionPathGeometry_0001()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometry_0001()));
                return result;
            }
            
            CompositionPathGeometry^ CompositionPathGeometry_0002()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometry_0002()));
                result->TrimEnd = 0;
                result->StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0003());
                auto controller = result->TryGetAnimationController("TrimEnd");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionPathGeometry^ CompositionPathGeometry_0003()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometry_0003()));
                result->TrimEnd = 0;
                result->StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0003());
                auto controller = result->TryGetAnimationController("TrimEnd");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionPathGeometry^ CompositionPathGeometry_0004()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometry_0004()));
                result->TrimEnd = 0;
                result->StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0003());
                auto controller = result->TryGetAnimationController("TrimEnd");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionPathGeometry^ CompositionPathGeometry_0005()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometry_0005()));
                result->TrimEnd = 0;
                result->StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0004());
                auto controller = result->TryGetAnimationController("TrimEnd");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionPathGeometry^ CompositionPathGeometry_0006()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometry_0006()));
                result->TrimEnd = 0;
                result->StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0004());
                auto controller = result->TryGetAnimationController("TrimEnd");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionPathGeometry^ CompositionPathGeometry_0007()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometry_0007()));
                result->TrimEnd = 0;
                result->StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0005());
                auto controller = result->TryGetAnimationController("TrimEnd");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionPathGeometry^ CompositionPathGeometry_0008()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometry_0008()));
                result->TrimEnd = 0;
                result->StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0005());
                auto controller = result->TryGetAnimationController("TrimEnd");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionPathGeometry^ CompositionPathGeometry_0009()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometry_0009()));
                result->TrimEnd = 0;
                result->StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0006());
                auto controller = result->TryGetAnimationController("TrimEnd");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionPathGeometry^ CompositionPathGeometry_0010()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometry_0010()));
                result->TrimEnd = 0;
                result->StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0006());
                auto controller = result->TryGetAnimationController("TrimEnd");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionPathGeometry^ CompositionPathGeometry_0011()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometry_0011()));
                result->TrimEnd = 0;
                result->StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0006());
                auto controller = result->TryGetAnimationController("TrimEnd");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionPathGeometry^ CompositionPathGeometry_0012()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometry_0012()));
                result->TrimEnd = 0;
                result->StartAnimation("TrimEnd", ScalarKeyFrameAnimation_0006());
                auto controller = result->TryGetAnimationController("TrimEnd");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionPathGeometry^ CompositionPathGeometry_0013()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometry_0013()));
                auto propertySet = result->Properties;
                propertySet->InsertScalar("TStart", 0);
                propertySet->InsertScalar("TEnd", 0);
                result->StartAnimation("TStart", ScalarKeyFrameAnimation_0007());
                auto controller = result->TryGetAnimationController("TStart");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                result->StartAnimation("TEnd", ScalarKeyFrameAnimation_0008());
                controller = result->TryGetAnimationController("TEnd");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                _expressionAnimation->ClearAllParameters();
                _expressionAnimation->Expression = "Min(my.TStart,my.TEnd)";
                _expressionAnimation->SetReferenceParameter("my", result);
                result->StartAnimation("TrimStart", _expressionAnimation);
                _expressionAnimation->ClearAllParameters();
                _expressionAnimation->Expression = "Max(my.TStart,my.TEnd)";
                _expressionAnimation->SetReferenceParameter("my", result);
                result->StartAnimation("TrimEnd", _expressionAnimation);
                return result;
            }
            
            CompositionPathGeometry^ CompositionPathGeometry_0014()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometry_0014()));
                return result;
            }
            
            CompositionPathGeometry^ CompositionPathGeometry_0015()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometry_0015()));
                auto propertySet = result->Properties;
                propertySet->InsertScalar("TStart", 0);
                propertySet->InsertScalar("TEnd", 0);
                result->StartAnimation("TStart", ScalarKeyFrameAnimation_0010());
                auto controller = result->TryGetAnimationController("TStart");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                result->StartAnimation("TEnd", ScalarKeyFrameAnimation_0011());
                controller = result->TryGetAnimationController("TEnd");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                _expressionAnimation->ClearAllParameters();
                _expressionAnimation->Expression = "Min(my.TStart,my.TEnd)";
                _expressionAnimation->SetReferenceParameter("my", result);
                result->StartAnimation("TrimStart", _expressionAnimation);
                _expressionAnimation->ClearAllParameters();
                _expressionAnimation->Expression = "Max(my.TStart,my.TEnd)";
                _expressionAnimation->SetReferenceParameter("my", result);
                result->StartAnimation("TrimEnd", _expressionAnimation);
                return result;
            }
            
            CompositionPathGeometry^ CompositionPathGeometry_0016()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometry_0016()));
                auto propertySet = result->Properties;
                propertySet->InsertScalar("TStart", 1);
                propertySet->InsertScalar("TEnd", 1);
                result->StartAnimation("TStart", ScalarKeyFrameAnimation_0012());
                auto controller = result->TryGetAnimationController("TStart");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                result->StartAnimation("TEnd", ScalarKeyFrameAnimation_0013());
                controller = result->TryGetAnimationController("TEnd");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                _expressionAnimation->ClearAllParameters();
                _expressionAnimation->Expression = "Min(my.TStart,my.TEnd)";
                _expressionAnimation->SetReferenceParameter("my", result);
                result->StartAnimation("TrimStart", _expressionAnimation);
                _expressionAnimation->ClearAllParameters();
                _expressionAnimation->Expression = "Max(my.TStart,my.TEnd)";
                _expressionAnimation->SetReferenceParameter("my", result);
                result->StartAnimation("TrimEnd", _expressionAnimation);
                return result;
            }
            
            CompositionPathGeometry^ CompositionPathGeometry_0017()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometry_0017()));
                auto propertySet = result->Properties;
                propertySet->InsertScalar("TStart", 0);
                propertySet->InsertScalar("TEnd", 0);
                result->StartAnimation("TStart", ScalarKeyFrameAnimation_0014());
                auto controller = result->TryGetAnimationController("TStart");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                result->StartAnimation("TEnd", ScalarKeyFrameAnimation_0015());
                controller = result->TryGetAnimationController("TEnd");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                _expressionAnimation->ClearAllParameters();
                _expressionAnimation->Expression = "Min(my.TStart,my.TEnd)";
                _expressionAnimation->SetReferenceParameter("my", result);
                result->StartAnimation("TrimStart", _expressionAnimation);
                _expressionAnimation->ClearAllParameters();
                _expressionAnimation->Expression = "Max(my.TStart,my.TEnd)";
                _expressionAnimation->SetReferenceParameter("my", result);
                result->StartAnimation("TrimEnd", _expressionAnimation);
                return result;
            }
            
            CompositionPathGeometry^ CompositionPathGeometry_0018()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometry_0018()));
                return result;
            }
            
            CompositionRectangleGeometry^ CompositionRectangleGeometry_0000()
            {
                if (_compositionRectangleGeometry_0000 != nullptr)
                {
                    return _compositionRectangleGeometry_0000;
                }
                auto result = _compositionRectangleGeometry_0000 = _c->CreateRectangleGeometry();
                result->Size = float2(1920, 1080);
                return result;
            }
            
            CompositionRectangleGeometry^ CompositionRectangleGeometry_0001()
            {
                auto result = _c->CreateRectangleGeometry();
                auto propertySet = result->Properties;
                propertySet->InsertVector2("Position", float2(0, 0));
                result->Size = float2(30, 30);
                _expressionAnimation->ClearAllParameters();
                _expressionAnimation->Expression = "Vector2(my.Position.X-(my.Size.X/2),my.Position.Y-(my.Size.Y/2))";
                _expressionAnimation->SetReferenceParameter("my", result);
                result->StartAnimation("Offset", _expressionAnimation);
                return result;
            }
            
            CompositionRectangleGeometry^ CompositionRectangleGeometry_0002()
            {
                auto result = _c->CreateRectangleGeometry();
                auto propertySet = result->Properties;
                propertySet->InsertVector2("Position", float2(0, 0));
                result->Size = float2(30, 30);
                _expressionAnimation->ClearAllParameters();
                _expressionAnimation->Expression = "Vector2(my.Position.X-(my.Size.X/2),my.Position.Y-(my.Size.Y/2))";
                _expressionAnimation->SetReferenceParameter("my", result);
                result->StartAnimation("Offset", _expressionAnimation);
                return result;
            }
            
            CompositionRectangleGeometry^ CompositionRectangleGeometry_0003()
            {
                auto result = _c->CreateRectangleGeometry();
                auto propertySet = result->Properties;
                propertySet->InsertVector2("Position", float2(0, 0));
                result->Size = float2(30, 30);
                _expressionAnimation->ClearAllParameters();
                _expressionAnimation->Expression = "Vector2(my.Position.X-(my.Size.X/2),my.Position.Y-(my.Size.Y/2))";
                _expressionAnimation->SetReferenceParameter("my", result);
                result->StartAnimation("Offset", _expressionAnimation);
                return result;
            }
            
            CompositionSpriteShape^ CompositionSpriteShape_0000()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0000();
                result->Geometry = CompositionRectangleGeometry_0000();
                return result;
            }
            
            CompositionSpriteShape^ CompositionSpriteShape_0001()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0001();
                result->Geometry = CompositionRectangleGeometry_0000();
                return result;
            }
            
            CompositionSpriteShape^ CompositionSpriteShape_0002()
            {
                auto result = _c->CreateSpriteShape();
                result->Geometry = CompositionPathGeometry_0000();
                result->StrokeBrush = CompositionColorBrush_0000();
                result->StrokeDashCap = CompositionStrokeCap::Round;
                result->StrokeEndCap = CompositionStrokeCap::Round;
                result->StrokeLineJoin = CompositionStrokeLineJoin::Round;
                result->StrokeStartCap = CompositionStrokeCap::Round;
                result->StrokeMiterLimit = 4;
                result->StrokeThickness = 3155;
                result->StartAnimation("StrokeThickness", ScalarKeyFrameAnimation_0000());
                auto controller = result->TryGetAnimationController("StrokeThickness");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionSpriteShape^ CompositionSpriteShape_0003()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0002();
                result->Geometry = CompositionRectangleGeometry_0001();
                return result;
            }
            
            CompositionSpriteShape^ CompositionSpriteShape_0004()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0003();
                result->Geometry = CompositionRectangleGeometry_0002();
                return result;
            }
            
            CompositionSpriteShape^ CompositionSpriteShape_0005()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0004();
                result->Geometry = CompositionRectangleGeometry_0003();
                return result;
            }
            
            CompositionSpriteShape^ CompositionSpriteShape_0006()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0005();
                result->Geometry = CompositionPathGeometry_0001();
                return result;
            }
            
            CompositionSpriteShape^ CompositionSpriteShape_0007()
            {
                auto result = _c->CreateSpriteShape();
                result->Geometry = CompositionPathGeometry_0002();
                result->StrokeBrush = CompositionColorBrush_0000();
                result->StrokeDashCap = CompositionStrokeCap::Round;
                result->StrokeEndCap = CompositionStrokeCap::Round;
                result->StrokeLineJoin = CompositionStrokeLineJoin::Round;
                result->StrokeStartCap = CompositionStrokeCap::Round;
                result->StrokeMiterLimit = 4;
                result->StrokeThickness = 13;
                return result;
            }
            
            CompositionSpriteShape^ CompositionSpriteShape_0008()
            {
                auto result = _c->CreateSpriteShape();
                result->Geometry = CompositionPathGeometry_0003();
                result->StrokeBrush = CompositionColorBrush_0000();
                result->StrokeDashCap = CompositionStrokeCap::Round;
                result->StrokeEndCap = CompositionStrokeCap::Round;
                result->StrokeLineJoin = CompositionStrokeLineJoin::Round;
                result->StrokeStartCap = CompositionStrokeCap::Round;
                result->StrokeMiterLimit = 4;
                result->StrokeThickness = 13;
                return result;
            }
            
            CompositionSpriteShape^ CompositionSpriteShape_0009()
            {
                auto result = _c->CreateSpriteShape();
                result->Geometry = CompositionPathGeometry_0004();
                result->StrokeBrush = CompositionColorBrush_0000();
                result->StrokeDashCap = CompositionStrokeCap::Round;
                result->StrokeEndCap = CompositionStrokeCap::Round;
                result->StrokeLineJoin = CompositionStrokeLineJoin::Round;
                result->StrokeStartCap = CompositionStrokeCap::Round;
                result->StrokeMiterLimit = 4;
                result->StrokeThickness = 13;
                return result;
            }
            
            CompositionSpriteShape^ CompositionSpriteShape_0010()
            {
                auto result = _c->CreateSpriteShape();
                result->Geometry = CompositionPathGeometry_0005();
                result->StrokeBrush = CompositionColorBrush_0000();
                result->StrokeDashCap = CompositionStrokeCap::Round;
                result->StrokeEndCap = CompositionStrokeCap::Round;
                result->StrokeLineJoin = CompositionStrokeLineJoin::Round;
                result->StrokeStartCap = CompositionStrokeCap::Round;
                result->StrokeMiterLimit = 4;
                result->StrokeThickness = 13;
                return result;
            }
            
            CompositionSpriteShape^ CompositionSpriteShape_0011()
            {
                auto result = _c->CreateSpriteShape();
                result->Geometry = CompositionPathGeometry_0006();
                result->StrokeBrush = CompositionColorBrush_0000();
                result->StrokeDashCap = CompositionStrokeCap::Round;
                result->StrokeEndCap = CompositionStrokeCap::Round;
                result->StrokeLineJoin = CompositionStrokeLineJoin::Round;
                result->StrokeStartCap = CompositionStrokeCap::Round;
                result->StrokeMiterLimit = 4;
                result->StrokeThickness = 13;
                return result;
            }
            
            CompositionSpriteShape^ CompositionSpriteShape_0012()
            {
                auto result = _c->CreateSpriteShape();
                result->Geometry = CompositionPathGeometry_0007();
                result->StrokeBrush = CompositionColorBrush_0000();
                result->StrokeDashCap = CompositionStrokeCap::Round;
                result->StrokeEndCap = CompositionStrokeCap::Round;
                result->StrokeLineJoin = CompositionStrokeLineJoin::Round;
                result->StrokeStartCap = CompositionStrokeCap::Round;
                result->StrokeMiterLimit = 4;
                result->StrokeThickness = 13;
                return result;
            }
            
            CompositionSpriteShape^ CompositionSpriteShape_0013()
            {
                auto result = _c->CreateSpriteShape();
                result->Geometry = CompositionPathGeometry_0008();
                result->StrokeBrush = CompositionColorBrush_0000();
                result->StrokeDashCap = CompositionStrokeCap::Round;
                result->StrokeEndCap = CompositionStrokeCap::Round;
                result->StrokeLineJoin = CompositionStrokeLineJoin::Round;
                result->StrokeStartCap = CompositionStrokeCap::Round;
                result->StrokeMiterLimit = 4;
                result->StrokeThickness = 13;
                return result;
            }
            
            CompositionSpriteShape^ CompositionSpriteShape_0014()
            {
                auto result = _c->CreateSpriteShape();
                result->Geometry = CompositionPathGeometry_0009();
                result->StrokeBrush = CompositionColorBrush_0000();
                result->StrokeDashCap = CompositionStrokeCap::Round;
                result->StrokeEndCap = CompositionStrokeCap::Round;
                result->StrokeLineJoin = CompositionStrokeLineJoin::Round;
                result->StrokeStartCap = CompositionStrokeCap::Round;
                result->StrokeMiterLimit = 4;
                result->StrokeThickness = 13;
                return result;
            }
            
            CompositionSpriteShape^ CompositionSpriteShape_0015()
            {
                auto result = _c->CreateSpriteShape();
                result->Geometry = CompositionPathGeometry_0010();
                result->StrokeBrush = CompositionColorBrush_0000();
                result->StrokeDashCap = CompositionStrokeCap::Round;
                result->StrokeEndCap = CompositionStrokeCap::Round;
                result->StrokeLineJoin = CompositionStrokeLineJoin::Round;
                result->StrokeStartCap = CompositionStrokeCap::Round;
                result->StrokeMiterLimit = 4;
                result->StrokeThickness = 13;
                return result;
            }
            
            CompositionSpriteShape^ CompositionSpriteShape_0016()
            {
                auto result = _c->CreateSpriteShape();
                result->Geometry = CompositionPathGeometry_0011();
                result->StrokeBrush = CompositionColorBrush_0000();
                result->StrokeDashCap = CompositionStrokeCap::Round;
                result->StrokeEndCap = CompositionStrokeCap::Round;
                result->StrokeLineJoin = CompositionStrokeLineJoin::Round;
                result->StrokeStartCap = CompositionStrokeCap::Round;
                result->StrokeMiterLimit = 4;
                result->StrokeThickness = 13;
                return result;
            }
            
            CompositionSpriteShape^ CompositionSpriteShape_0017()
            {
                auto result = _c->CreateSpriteShape();
                result->Geometry = CompositionPathGeometry_0012();
                result->StrokeBrush = CompositionColorBrush_0000();
                result->StrokeDashCap = CompositionStrokeCap::Round;
                result->StrokeEndCap = CompositionStrokeCap::Round;
                result->StrokeLineJoin = CompositionStrokeLineJoin::Round;
                result->StrokeStartCap = CompositionStrokeCap::Round;
                result->StrokeMiterLimit = 4;
                result->StrokeThickness = 13;
                return result;
            }
            
            CompositionSpriteShape^ CompositionSpriteShape_0018()
            {
                auto result = _c->CreateSpriteShape();
                result->Geometry = CompositionPathGeometry_0013();
                result->StrokeBrush = CompositionColorBrush_0000();
                result->StrokeDashCap = CompositionStrokeCap::Round;
                result->StrokeEndCap = CompositionStrokeCap::Round;
                result->StrokeLineJoin = CompositionStrokeLineJoin::Round;
                result->StrokeStartCap = CompositionStrokeCap::Round;
                result->StrokeMiterLimit = 4;
                result->StrokeThickness = 13;
                return result;
            }
            
            CompositionSpriteShape^ CompositionSpriteShape_0019()
            {
                auto result = _c->CreateSpriteShape();
                result->Geometry = CompositionPathGeometry_0014();
                result->StrokeBrush = CompositionColorBrush_0000();
                result->StrokeDashCap = CompositionStrokeCap::Round;
                result->StrokeEndCap = CompositionStrokeCap::Round;
                result->StrokeLineJoin = CompositionStrokeLineJoin::Round;
                result->StrokeStartCap = CompositionStrokeCap::Round;
                result->StrokeMiterLimit = 4;
                result->StrokeThickness = 0;
                result->StartAnimation("StrokeThickness", ScalarKeyFrameAnimation_0009());
                auto controller = result->TryGetAnimationController("StrokeThickness");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionSpriteShape^ CompositionSpriteShape_0020()
            {
                auto result = _c->CreateSpriteShape();
                result->Geometry = CompositionPathGeometry_0015();
                result->StrokeBrush = CompositionColorBrush_0000();
                result->StrokeDashCap = CompositionStrokeCap::Round;
                result->StrokeEndCap = CompositionStrokeCap::Round;
                result->StrokeLineJoin = CompositionStrokeLineJoin::Round;
                result->StrokeStartCap = CompositionStrokeCap::Round;
                result->StrokeMiterLimit = 4;
                result->StrokeThickness = 6.8F;
                return result;
            }
            
            CompositionSpriteShape^ CompositionSpriteShape_0021()
            {
                auto result = _c->CreateSpriteShape();
                result->Geometry = CompositionPathGeometry_0016();
                result->StrokeBrush = CompositionColorBrush_0000();
                result->StrokeDashCap = CompositionStrokeCap::Round;
                result->StrokeEndCap = CompositionStrokeCap::Round;
                result->StrokeLineJoin = CompositionStrokeLineJoin::Round;
                result->StrokeStartCap = CompositionStrokeCap::Round;
                result->StrokeMiterLimit = 4;
                result->StrokeThickness = 6.8F;
                return result;
            }
            
            CompositionSpriteShape^ CompositionSpriteShape_0022()
            {
                auto result = _c->CreateSpriteShape();
                result->Geometry = CompositionPathGeometry_0017();
                result->StrokeBrush = CompositionColorBrush_0000();
                result->StrokeDashCap = CompositionStrokeCap::Round;
                result->StrokeEndCap = CompositionStrokeCap::Round;
                result->StrokeLineJoin = CompositionStrokeLineJoin::Round;
                result->StrokeStartCap = CompositionStrokeCap::Round;
                result->StrokeMiterLimit = 4;
                result->StrokeThickness = 6.8F;
                return result;
            }
            
            CompositionSpriteShape^ CompositionSpriteShape_0023()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0006();
                result->Geometry = CompositionPathGeometry_0018();
                return result;
            }
            
            ContainerVisual^ ContainerVisual_0000()
            {
                if (_containerVisual_0000 != nullptr)
                {
                    return _containerVisual_0000;
                }
                auto result = _containerVisual_0000 = _c->CreateContainerVisual();
                auto propertySet = result->Properties;
                propertySet->InsertScalar("Progress", 0);
                auto children = result->Children;
                children->InsertAtTop(ShapeVisual_0000());
                return result;
            }
            
            CubicBezierEasingFunction^ CubicBezierEasingFunction_0000()
            {
                return _c->CreateCubicBezierEasingFunction(float2(0.192F, 0), float2(0.77F, 1));
            }
            
            CubicBezierEasingFunction^ CubicBezierEasingFunction_0001()
            {
                return _c->CreateCubicBezierEasingFunction(float2(0.734F, 0), float2(0.662F, 1));
            }
            
            CubicBezierEasingFunction^ CubicBezierEasingFunction_0002()
            {
                return _c->CreateCubicBezierEasingFunction(float2(0.412F, 0), float2(0.692F, 0.667F));
            }
            
            CubicBezierEasingFunction^ CubicBezierEasingFunction_0003()
            {
                return _c->CreateCubicBezierEasingFunction(float2(0, 0), float2(0, 1));
            }
            
            CubicBezierEasingFunction^ CubicBezierEasingFunction_0004()
            {
                return _c->CreateCubicBezierEasingFunction(float2(0.333F, 0), float2(0.667F, 1));
            }
            
            CubicBezierEasingFunction^ CubicBezierEasingFunction_0005()
            {
                return _c->CreateCubicBezierEasingFunction(float2(1, 0), float2(1, 1));
            }
            
            CubicBezierEasingFunction^ CubicBezierEasingFunction_0006()
            {
                return _c->CreateCubicBezierEasingFunction(float2(0.207F, 0), float2(0.21F, 1));
            }
            
            CubicBezierEasingFunction^ CubicBezierEasingFunction_0007()
            {
                return _c->CreateCubicBezierEasingFunction(float2(0.79F, 0), float2(0.793F, 1));
            }
            
            CubicBezierEasingFunction^ CubicBezierEasingFunction_0008()
            {
                return _c->CreateCubicBezierEasingFunction(float2(0, 0), float2(0.365F, 1));
            }
            
            CubicBezierEasingFunction^ CubicBezierEasingFunction_0009()
            {
                return _c->CreateCubicBezierEasingFunction(float2(0.389F, 0), float2(0.3F, 1));
            }
            
            CubicBezierEasingFunction^ CubicBezierEasingFunction_0010()
            {
                if (_cubicBezierEasingFunction_0010 != nullptr)
                {
                    return _cubicBezierEasingFunction_0010;
                }
                return _cubicBezierEasingFunction_0010 = _c->CreateCubicBezierEasingFunction(float2(0.195F, 0), float2(0, 1));
            }
            
            CubicBezierEasingFunction^ CubicBezierEasingFunction_0011()
            {
                return _c->CreateCubicBezierEasingFunction(float2(0.022F, 0), float2(0.104F, 1));
            }
            
            CubicBezierEasingFunction^ CubicBezierEasingFunction_0012()
            {
                return _c->CreateCubicBezierEasingFunction(float2(0.451F, 0), float2(0, 1));
            }
            
            CubicBezierEasingFunction^ CubicBezierEasingFunction_0013()
            {
                return _c->CreateCubicBezierEasingFunction(float2(0.333F, 0), float2(0.833F, 0.833F));
            }
            
            CubicBezierEasingFunction^ CubicBezierEasingFunction_0014()
            {
                return _c->CreateCubicBezierEasingFunction(float2(0.167F, 0.167F), float2(0.667F, 1));
            }
            
            CubicBezierEasingFunction^ CubicBezierEasingFunction_0015()
            {
                if (_cubicBezierEasingFunction_0015 != nullptr)
                {
                    return _cubicBezierEasingFunction_0015;
                }
                return _cubicBezierEasingFunction_0015 = _c->CreateCubicBezierEasingFunction(float2(0.167F, 0.167F), float2(0.833F, 0.833F));
            }
            
            CubicBezierEasingFunction^ CubicBezierEasingFunction_0016()
            {
                return _c->CreateCubicBezierEasingFunction(float2(0.656F, 0.026F), float2(0.819F, 0.977F));
            }
            
            CubicBezierEasingFunction^ CubicBezierEasingFunction_0017()
            {
                return _c->CreateCubicBezierEasingFunction(float2(0.564F, 0.093F), float2(0.572F, 0.929F));
            }
            
            CubicBezierEasingFunction^ CubicBezierEasingFunction_0018()
            {
                return _c->CreateCubicBezierEasingFunction(float2(0.528F, 0.125F), float2(0.346F, 0.95F));
            }
            
            CubicBezierEasingFunction^ CubicBezierEasingFunction_0019()
            {
                return _c->CreateCubicBezierEasingFunction(float2(0.026F, 0.006F), float2(0.544F, 1));
            }
            
            CubicBezierEasingFunction^ CubicBezierEasingFunction_0020()
            {
                return _c->CreateCubicBezierEasingFunction(float2(1, 0), float2(0.833F, 0.833F));
            }
            
            CubicBezierEasingFunction^ CubicBezierEasingFunction_0021()
            {
                return _c->CreateCubicBezierEasingFunction(float2(0.382F, 0), float2(0.493F, 0.881F));
            }
            
            CubicBezierEasingFunction^ CubicBezierEasingFunction_0022()
            {
                return _c->CreateCubicBezierEasingFunction(float2(0.48F, 0.11F), float2(0.352F, 1));
            }
            
            ExpressionAnimation^ ExpressionAnimation_0000()
            {
                if (_expressionAnimation_0000 != nullptr)
                {
                    return _expressionAnimation_0000;
                }
                auto result = _expressionAnimation_0000 = _c->CreateExpressionAnimation();
                result->SetReferenceParameter("_", ContainerVisual_0000());
                result->Expression = "_.Progress";
                return result;
            }
            
            LinearEasingFunction^ LinearEasingFunction_0000()
            {
                if (_linearEasingFunction_0000 != nullptr)
                {
                    return _linearEasingFunction_0000;
                }
                return _linearEasingFunction_0000 = _c->CreateLinearEasingFunction();
            }
            
            ScalarKeyFrameAnimation^ ScalarKeyFrameAnimation_0000()
            {
                auto result = _c->CreateScalarKeyFrameAnimation();
                result->Duration = TimeSpan{98670000L};
                result->InsertKeyFrame(0, 3155, LinearEasingFunction_0000());
                result->InsertKeyFrame(0.05405406F, 3155, LinearEasingFunction_0000());
                result->InsertKeyFrame(0.2432432F, 13, CubicBezierEasingFunction_0000());
                return result;
            }
            
            ScalarKeyFrameAnimation^ ScalarKeyFrameAnimation_0001()
            {
                auto result = _c->CreateScalarKeyFrameAnimation();
                result->Duration = TimeSpan{98670000L};
                result->InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result->InsertKeyFrame(0.2297297F, 1, LinearEasingFunction_0000());
                result->InsertKeyFrame(0.2989865F, 0, CubicBezierEasingFunction_0001());
                return result;
            }
            
            ScalarKeyFrameAnimation^ ScalarKeyFrameAnimation_0002()
            {
                auto result = _c->CreateScalarKeyFrameAnimation();
                result->Duration = TimeSpan{98670000L};
                result->InsertKeyFrame(0, 0.99F, LinearEasingFunction_0000());
                result->InsertKeyFrame(0.2179054F, 0.99F, LinearEasingFunction_0000());
                result->InsertKeyFrame(0.2719595F, 0, CubicBezierEasingFunction_0002());
                return result;
            }
            
            ScalarKeyFrameAnimation^ ScalarKeyFrameAnimation_0003()
            {
                if (_scalarKeyFrameAnimation_0003 != nullptr)
                {
                    return _scalarKeyFrameAnimation_0003;
                }
                auto result = _scalarKeyFrameAnimation_0003 = _c->CreateScalarKeyFrameAnimation();
                result->Duration = TimeSpan{98670000L};
                result->InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result->InsertKeyFrame(0.7736486F, 0, LinearEasingFunction_0000());
                result->InsertKeyFrame(0.8581081F, 1, CubicBezierEasingFunction_0008());
                return result;
            }
            
            ScalarKeyFrameAnimation^ ScalarKeyFrameAnimation_0004()
            {
                if (_scalarKeyFrameAnimation_0004 != nullptr)
                {
                    return _scalarKeyFrameAnimation_0004;
                }
                auto result = _scalarKeyFrameAnimation_0004 = _c->CreateScalarKeyFrameAnimation();
                result->Duration = TimeSpan{98670000L};
                result->InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result->InsertKeyFrame(0.7381757F, 0, LinearEasingFunction_0000());
                result->InsertKeyFrame(0.8125F, 1, CubicBezierEasingFunction_0009());
                return result;
            }
            
            ScalarKeyFrameAnimation^ ScalarKeyFrameAnimation_0005()
            {
                if (_scalarKeyFrameAnimation_0005 != nullptr)
                {
                    return _scalarKeyFrameAnimation_0005;
                }
                auto result = _scalarKeyFrameAnimation_0005 = _c->CreateScalarKeyFrameAnimation();
                result->Duration = TimeSpan{98670000L};
                result->InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result->InsertKeyFrame(0.7128378F, 0, LinearEasingFunction_0000());
                result->InsertKeyFrame(0.847973F, 1, CubicBezierEasingFunction_0010());
                return result;
            }
            
            ScalarKeyFrameAnimation^ ScalarKeyFrameAnimation_0006()
            {
                if (_scalarKeyFrameAnimation_0006 != nullptr)
                {
                    return _scalarKeyFrameAnimation_0006;
                }
                auto result = _scalarKeyFrameAnimation_0006 = _c->CreateScalarKeyFrameAnimation();
                result->Duration = TimeSpan{98670000L};
                result->InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result->InsertKeyFrame(0.6908784F, 0, LinearEasingFunction_0000());
                result->InsertKeyFrame(0.8260135F, 1, CubicBezierEasingFunction_0010());
                return result;
            }
            
            ScalarKeyFrameAnimation^ ScalarKeyFrameAnimation_0007()
            {
                auto result = _c->CreateScalarKeyFrameAnimation();
                result->Duration = TimeSpan{98670000L};
                result->InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result->InsertKeyFrame(0.6689189F, 0, LinearEasingFunction_0000());
                result->InsertKeyFrame(0.7922297F, 0.838F, CubicBezierEasingFunction_0011());
                return result;
            }
            
            ScalarKeyFrameAnimation^ ScalarKeyFrameAnimation_0008()
            {
                auto result = _c->CreateScalarKeyFrameAnimation();
                result->Duration = TimeSpan{98670000L};
                result->InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result->InsertKeyFrame(0.6047297F, 0, LinearEasingFunction_0000());
                result->InsertKeyFrame(0.7736486F, 1, CubicBezierEasingFunction_0012());
                return result;
            }
            
            ScalarKeyFrameAnimation^ ScalarKeyFrameAnimation_0009()
            {
                auto result = _c->CreateScalarKeyFrameAnimation();
                result->Duration = TimeSpan{98670000L};
                result->InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result->InsertKeyFrame(0.4814189F, 0, LinearEasingFunction_0000());
                result->InsertKeyFrame(0.4932432F, 9, CubicBezierEasingFunction_0013());
                result->InsertKeyFrame(0.6503378F, 9, LinearEasingFunction_0000());
                result->InsertKeyFrame(0.6570946F, 0, CubicBezierEasingFunction_0014());
                return result;
            }
            
            ScalarKeyFrameAnimation^ ScalarKeyFrameAnimation_0010()
            {
                auto result = _c->CreateScalarKeyFrameAnimation();
                result->Duration = TimeSpan{98670000L};
                result->InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result->InsertKeyFrame(0.6317568F, 0, LinearEasingFunction_0000());
                result->InsertKeyFrame(0.6587838F, 1, CubicBezierEasingFunction_0015());
                return result;
            }
            
            ScalarKeyFrameAnimation^ ScalarKeyFrameAnimation_0011()
            {
                auto result = _c->CreateScalarKeyFrameAnimation();
                result->Duration = TimeSpan{98670000L};
                result->InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result->InsertKeyFrame(0.3266402F, 0, LinearEasingFunction_0000());
                result->InsertKeyFrame(0.3449831F, 0.33792F, CubicBezierEasingFunction_0016());
                result->InsertKeyFrame(0.3633243F, 0.59203F, CubicBezierEasingFunction_0017());
                result->InsertKeyFrame(0.4054054F, 1, CubicBezierEasingFunction_0018());
                return result;
            }
            
            ScalarKeyFrameAnimation^ ScalarKeyFrameAnimation_0012()
            {
                auto result = _c->CreateScalarKeyFrameAnimation();
                result->Duration = TimeSpan{98670000L};
                result->InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result->InsertKeyFrame(0.2736486F, 1, LinearEasingFunction_0000());
                result->InsertKeyFrame(0.3266404F, 0, CubicBezierEasingFunction_0019());
                return result;
            }
            
            ScalarKeyFrameAnimation^ ScalarKeyFrameAnimation_0013()
            {
                auto result = _c->CreateScalarKeyFrameAnimation();
                result->Duration = TimeSpan{98670000L};
                result->InsertKeyFrame(0, 1, LinearEasingFunction_0000());
                result->InsertKeyFrame(0.6081081F, 1, LinearEasingFunction_0000());
                result->InsertKeyFrame(0.6317568F, 0, CubicBezierEasingFunction_0020());
                return result;
            }
            
            ScalarKeyFrameAnimation^ ScalarKeyFrameAnimation_0014()
            {
                auto result = _c->CreateScalarKeyFrameAnimation();
                result->Duration = TimeSpan{98670000L};
                result->InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result->InsertKeyFrame(0.6402027F, 0, LinearEasingFunction_0000());
                result->InsertKeyFrame(0.6672297F, 1, CubicBezierEasingFunction_0015());
                return result;
            }
            
            ScalarKeyFrameAnimation^ ScalarKeyFrameAnimation_0015()
            {
                auto result = _c->CreateScalarKeyFrameAnimation();
                result->Duration = TimeSpan{98670000L};
                result->InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result->InsertKeyFrame(0.4054054F, 0, LinearEasingFunction_0000());
                result->InsertKeyFrame(0.4307432F, 0.35118F, CubicBezierEasingFunction_0021());
                result->InsertKeyFrame(0.4763514F, 1, CubicBezierEasingFunction_0022());
                return result;
            }
            
            ShapeVisual^ ShapeVisual_0000()
            {
                auto result = _c->CreateShapeVisual();
                result->Size = float2(1920, 1280);
                auto shapes = result->Shapes;
                shapes->Append(CompositionContainerShape_0000());
                shapes->Append(CompositionContainerShape_0001());
                shapes->Append(CompositionContainerShape_0002());
                shapes->Append(CompositionContainerShape_0004());
                shapes->Append(CompositionContainerShape_0010());
                shapes->Append(CompositionContainerShape_0017());
                shapes->Append(CompositionContainerShape_0026());
                return result;
            }
            
            Vector2KeyFrameAnimation^ Vector2KeyFrameAnimation_0000()
            {
                auto result = _c->CreateVector2KeyFrameAnimation();
                result->Duration = TimeSpan{98670000L};
                result->InsertKeyFrame(0, float2(1.7F, 1.7F), LinearEasingFunction_0000());
                result->InsertKeyFrame(0.08783784F, float2(2.03F, 2.03F), CubicBezierEasingFunction_0003());
                result->InsertKeyFrame(0.160473F, float2(2.03F, 2.03F), CubicBezierEasingFunction_0004());
                result->InsertKeyFrame(0.2128378F, float2(1.7F, 1.7F), CubicBezierEasingFunction_0005());
                return result;
            }
            
        };
    };
}
