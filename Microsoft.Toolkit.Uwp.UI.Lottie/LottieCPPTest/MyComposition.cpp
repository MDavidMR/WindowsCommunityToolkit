#include "pch.h"
#include "d2d1.h"
#include <d2d1_1.h>
#include <d2d1helper.h>
#include "WindowsNumerics.h"
#include <Windows.Graphics.Interop.h>
#include <windows.ui.composition.interop.h>
#include <wrl.h>
#include "ICompositionSource.h"

using namespace Windows::Foundation;
using namespace Windows::Foundation::Numerics;
using namespace Windows::UI;
using namespace Windows::UI::Composition;
using namespace Windows::Graphics;
using namespace Microsoft::WRL;

namespace Compositions
{
    ref class _0351_pink_drink_machine sealed : ICompositionSource
    {
    public:
        virtual bool TryCreateInstance(
            Compositor^ compositor,
            Visual^* rootVisual,
            float2* size,
            CompositionPropertySet^* progressPropertySet,
            TimeSpan* duration,
            Object^* diagnostics)
        {
            *rootVisual = Instantiator::InstantiateComposition(compositor);
            *size = { 800, 600 };
            *progressPropertySet = (*rootVisual)->Properties;
            duration->Duration = { 29670000L };
            diagnostics = nullptr;
            return true;
        }

    private:
        class GeoSource :
            public ABI::Windows::Graphics::IGeometrySource2D,
            public ABI::Windows::Graphics::IGeometrySource2DInterop
        {
        public:
            GeoSource(
                ID2D1Geometry* pGeometry)
                : m_cRef(0)
                , m_cpGeometry(pGeometry)
            {
            }

        protected:
            ~GeoSource() = default;

        public:
            // IUnknown
            IFACEMETHODIMP QueryInterface(
                REFIID iid,
                void ** ppvObject) override
            {
                if (iid == __uuidof(ABI::Windows::Graphics::IGeometrySource2DInterop))
                {
                    AddRef();
                    *ppvObject = (ABI::Windows::Graphics::IGeometrySource2DInterop*) this;
                    return S_OK;
                }

                return E_NOINTERFACE;
            }

            IFACEMETHODIMP_(ULONG) AddRef() override
            {
                return InterlockedIncrement(&m_cRef);
            }

            IFACEMETHODIMP_(ULONG) Release() override
            {
                ULONG cRef = InterlockedDecrement(&m_cRef);
                if (0 == cRef)
                {
                    delete this;
                }
                return cRef;
            }

            // IInspectable
            IFACEMETHODIMP GetIids(ULONG*, IID**) override
            {
                return E_NOTIMPL;
            }

            IFACEMETHODIMP GetRuntimeClassName(HSTRING*) override
            {
                return E_NOTIMPL;
            }

            IFACEMETHODIMP GetTrustLevel(TrustLevel*) override
            {
                return E_NOTIMPL;
            }

            // Windows::Graphics::IGeometrySource2DInterop
            IFACEMETHODIMP GetGeometry(ID2D1Geometry** value) override
            {
                *value = m_cpGeometry.Get();
                (*value)->AddRef();
                return S_OK;
            }

            IFACEMETHODIMP TryGetGeometryUsingFactory(ID2D1Factory*, ID2D1Geometry**) override
            {
                return E_NOTIMPL;
            }

        private:
            ULONG m_cRef;
            Microsoft::WRL::ComPtr<ID2D1Geometry> m_cpGeometry;
        };
        typedef ComPtr<GeoSource> CanvasGeometry;
        class Instantiator sealed
        {
            ComPtr<ID2D1Factory> _d2dFactory;
            Compositor^ _c;
            ExpressionAnimation^ _expressionAnimation;
            CanvasGeometry _canvasGeometry_0003;
            CanvasGeometry _canvasGeometry_0004;
            CanvasGeometry _canvasGeometry_0008;
            CanvasGeometry _canvasGeometry_0011;
            CanvasGeometry _canvasGeometry_0013;
            CanvasGeometry _canvasGeometry_0041;
            CompositionColorBrush^ _compositionColorBrush_0000;
            CompositionColorBrush^ _compositionColorBrush_0001;
            CompositionColorBrush^ _compositionColorBrush_0007;
            CompositionColorBrush^ _compositionColorBrush_0008;
            ContainerVisual^ _containerVisual_0000;
            CubicBezierEasingFunction^ _cubicBezierEasingFunction_0000;
            ExpressionAnimation^ _expressionAnimation_0000;

            CanvasGeometry CanvasGeometry_0000()
            {
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ -74.5F, -18.5F }, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({ { -84.701F, -18.5F },{ -93, -10.201F },{ -93, 0 } });
                sink->AddBezier({ { -93, 10.201F },{ -84.701F, 18.5F },{ -74.5F, 18.5F } });
                sink->AddBezier({ { -74.5F, 18.5F },{ 51.5F, 18.5F },{ 51.5F, 18.5F } });
                sink->AddBezier({ { 61.701F, 18.5F },{ 70, 10.201F },{ 70, 0 } });
                sink->AddBezier({ { 70, -10.201F },{ 61.701F, -18.5F },{ 51.5F, -18.5F } });
                sink->AddBezier({ { 51.5F, -18.5F },{ -74.5F, -18.5F },{ -74.5F, -18.5F } });
                sink->EndFigure(D2D1_FIGURE_END_CLOSED);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0001()
            {
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ 6.5F, 181.001F }, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({ { 6.5F, 181.001F },{ -6.5F, 181.001F },{ -6.5F, 181.001F } });
                sink->AddBezier({ { -6.5F, 181.001F },{ -6.5F, -80 },{ -6.5F, -80 } });
                sink->AddBezier({ { -6.5F, -80 },{ -10, -80 },{ -10, -80 } });
                sink->AddBezier({ { -10, -80 },{ -10, -99.211F },{ -10, -99.211F } });
                sink->AddBezier({ { -12.583F, -101.833F },{ -14, -105.292F },{ -14, -109 } });
                sink->AddBezier({ { -14, -116.72F },{ -7.72F, -123 },{ 0, -123 } });
                sink->AddBezier({ { 7.72F, -123 },{ 14, -116.72F },{ 14, -109 } });
                sink->AddBezier({ { 14, -104.825F },{ 12.184F, -100.946F },{ 9, -98.282F } });
                sink->AddBezier({ { 9, -98.282F },{ 9, -80 },{ 9, -80 } });
                sink->AddBezier({ { 9, -80 },{ 6.5F, -80 },{ 6.5F, -80 } });
                sink->AddBezier({ { 6.5F, -80 },{ 6.5F, 181.001F },{ 6.5F, 181.001F } });
                sink->EndFigure(D2D1_FIGURE_END_CLOSED);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0002()
            {
                CanvasGeometry result;
                ID2D1Geometry **geoA = new ID2D1Geometry*, **geoB = new ID2D1Geometry*;
                CanvasGeometry_0003()->GetGeometry(geoA);
                CanvasGeometry_0004()->GetGeometry(geoB);
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                FFHR((*geoA)->CombineWithGeometry(
                    *geoB,
                    D2D1_COMBINE_MODE_XOR,
                    { 1, 0, 0, 1, 0, 0 },
                    sink.Get()));
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0003()
            {
                if (_canvasGeometry_0003 != nullptr)
                {
                    return _canvasGeometry_0003;
                }
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ -0.032F, -103.971F }, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({ { -2.789F, -103.971F },{ -5.032F, -106.214F },{ -5.032F, -108.971F } });
                sink->AddBezier({ { -5.032F, -111.728F },{ -2.789F, -113.971F },{ -0.032F, -113.971F } });
                sink->AddBezier({ { 2.725F, -113.971F },{ 4.968F, -111.728F },{ 4.968F, -108.971F } });
                sink->AddBezier({ { 4.968F, -106.214F },{ 2.725F, -103.971F },{ -0.032F, -103.971F } });
                sink->EndFigure(D2D1_FIGURE_END_CLOSED);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0004()
            {
                if (_canvasGeometry_0004 != nullptr)
                {
                    return _canvasGeometry_0004;
                }
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ 0, -116 }, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({ { -3.86F, -116 },{ -7, -112.86F },{ -7, -109 } });
                sink->AddBezier({ { -7, -105.14F },{ -3.86F, -102 },{ 0, -102 } });
                sink->AddBezier({ { 3.859F, -102 },{ 7, -105.14F },{ 7, -109 } });
                sink->AddBezier({ { 7, -112.86F },{ 3.859F, -116 },{ 0, -116 } });
                sink->EndFigure(D2D1_FIGURE_END_CLOSED);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0005()
            {
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ -50, 27.221F }, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({ { -50, 27.221F },{ 50, 27.221F },{ 50, 27.221F } });
                sink->AddBezier({ { 50, 27.221F },{ 50, 15.221F },{ 50, 15.221F } });
                sink->AddBezier({ { 50, 15.221F },{ 34.979F, 15.221F },{ 34.979F, 15.221F } });
                sink->AddBezier({ { 25.616F, 15.221F },{ 18, 7.605F },{ 18, -1.758F } });
                sink->AddBezier({ { 18, -1.758F },{ 18, -7.842F },{ 18, -7.842F } });
                sink->AddBezier({ { 18, -17.505F },{ 10.674F, -25.784F },{ 1.321F, -26.69F } });
                sink->AddBezier({ { -3.942F, -27.205F },{ -8.992F, -25.524F },{ -12.909F, -21.969F } });
                sink->AddBezier({ { -16.78F, -18.456F },{ -19, -13.466F },{ -19, -8.279F } });
                sink->AddBezier({ { -19, -8.279F },{ -19, -1.758F },{ -19, -1.758F } });
                sink->AddBezier({ { -19, 7.605F },{ -26.616F, 15.221F },{ -35.979F, 15.221F } });
                sink->AddBezier({ { -35.979F, 15.221F },{ -50, 15.221F },{ -50, 15.221F } });
                sink->AddBezier({ { -50, 15.221F },{ -50, 27.221F },{ -50, 27.221F } });
                sink->EndFigure(D2D1_FIGURE_END_CLOSED);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0006()
            {
                CanvasGeometry result;
                ID2D1Geometry **geoA = new ID2D1Geometry*, **geoB = new ID2D1Geometry*;
                CanvasGeometry_0007()->GetGeometry(geoA);
                CanvasGeometry_0010()->GetGeometry(geoB);
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                FFHR((*geoA)->CombineWithGeometry(
                    *geoB,
                    D2D1_COMBINE_MODE_XOR,
                    { 1, 0, 0, 1, 0, 0 },
                    sink.Get()));
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0007()
            {
                CanvasGeometry result;
                ID2D1Geometry **geoA = new ID2D1Geometry*, **geoB = new ID2D1Geometry*;
                CanvasGeometry_0008()->GetGeometry(geoA);
                CanvasGeometry_0009()->GetGeometry(geoB);
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                FFHR((*geoA)->CombineWithGeometry(
                    *geoB,
                    D2D1_COMBINE_MODE_XOR,
                    { 1, 0, 0, 1, 0, 0 },
                    sink.Get()));
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0008()
            {
                if (_canvasGeometry_0008 != nullptr)
                {
                    return _canvasGeometry_0008;
                }
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ 50, 27.221F }, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({ { 50, 27.221F },{ -50, 27.221F },{ -50, 27.221F } });
                sink->AddBezier({ { -50, 27.221F },{ -50, 15.221F },{ -50, 15.221F } });
                sink->AddBezier({ { -50, 15.221F },{ -35.979F, 15.221F },{ -35.979F, 15.221F } });
                sink->AddBezier({ { -26.617F, 15.221F },{ -19, 7.605F },{ -19, -1.758F } });
                sink->AddBezier({ { -19, -1.758F },{ -19, -8.279F },{ -19, -8.279F } });
                sink->AddBezier({ { -19, -13.466F },{ -16.78F, -18.456F },{ -12.909F, -21.969F } });
                sink->AddBezier({ { -8.993F, -25.524F },{ -3.937F, -27.205F },{ 1.32F, -26.69F } });
                sink->AddBezier({ { 10.673F, -25.784F },{ 18, -17.505F },{ 18, -7.842F } });
                sink->AddBezier({ { 18, -7.842F },{ 18, -1.758F },{ 18, -1.758F } });
                sink->AddBezier({ { 18, 7.605F },{ 25.617F, 15.221F },{ 34.979F, 15.221F } });
                sink->AddBezier({ { 34.979F, 15.221F },{ 50, 15.221F },{ 50, 15.221F } });
                sink->AddBezier({ { 50, 15.221F },{ 50, 27.221F },{ 50, 27.221F } });
                sink->EndFigure(D2D1_FIGURE_END_CLOSED);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0009()
            {
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ 0, -16.279F }, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({ { -3.584F, -16.279F },{ -6.5F, -13.363F },{ -6.5F, -9.779F } });
                sink->AddBezier({ { -6.5F, -6.195F },{ -3.584F, -3.279F },{ 0, -3.279F } });
                sink->AddBezier({ { 3.584F, -3.279F },{ 6.5F, -6.195F },{ 6.5F, -9.779F } });
                sink->AddBezier({ { 6.5F, -13.363F },{ 3.584F, -16.279F },{ 0, -16.279F } });
                sink->EndFigure(D2D1_FIGURE_END_CLOSED);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0010()
            {
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ 0, -4.279F }, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({ { -3.033F, -4.279F },{ -5.5F, -6.747F },{ -5.5F, -9.779F } });
                sink->AddBezier({ { -5.5F, -12.811F },{ -3.033F, -15.279F },{ 0, -15.279F } });
                sink->AddBezier({ { 3.033F, -15.279F },{ 5.5F, -12.811F },{ 5.5F, -9.779F } });
                sink->AddBezier({ { 5.5F, -6.747F },{ 3.033F, -4.279F },{ 0, -4.279F } });
                sink->EndFigure(D2D1_FIGURE_END_CLOSED);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0011()
            {
                if (_canvasGeometry_0011 != nullptr)
                {
                    return _canvasGeometry_0011;
                }
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ -283, 7 }, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({ { -283, 7 },{ 283, 7 },{ 283, 7 } });
                sink->AddBezier({ { 283, 7 },{ 283, -7 },{ 283, -7 } });
                sink->AddBezier({ { 283, -7 },{ -283, -7 },{ -283, -7 } });
                sink->AddBezier({ { -283, -7 },{ -283, 7 },{ -283, 7 } });
                sink->EndFigure(D2D1_FIGURE_END_CLOSED);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0012()
            {
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ -5.729F, -31.576F }, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({ { -5.729F, -31.576F },{ -198.579F, 14.604F },{ -198.579F, 14.604F } });
                sink->AddBezier({ { -204.139F, 15.586F },{ -208.945F, 18.657F },{ -212.173F, 23.266F } });
                sink->AddBezier({ { -215.4F, 27.875F },{ -216.644F, 33.443F },{ -215.674F, 38.943F } });
                sink->AddBezier({ { -214.704F, 44.443F },{ -211.632F, 49.249F },{ -207.023F, 52.477F } });
                sink->AddBezier({ { -202.415F, 55.704F },{ -196.848F, 56.945F },{ -191.347F, 55.978F } });
                sink->AddBezier({ { -191.347F, 55.978F },{ 5.903F, 34.404F },{ 5.903F, 34.404F } });
                sink->AddBezier({ { 5.903F, 34.404F },{ 198.638F, -12.772F },{ 198.638F, -12.772F } });
                sink->AddBezier({ { 204.139F, -13.742F },{ 208.946F, -16.814F },{ 212.172F, -21.423F } });
                sink->AddBezier({ { 215.4F, -26.032F },{ 216.643F, -31.599F },{ 215.674F, -37.099F } });
                sink->AddBezier({ { 213.664F, -48.503F },{ 202.748F, -56.143F },{ 191.347F, -54.134F } });
                sink->AddBezier({ { 191.347F, -54.134F },{ -5.729F, -31.576F },{ -5.729F, -31.576F } });
                sink->EndFigure(D2D1_FIGURE_END_CLOSED);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0013()
            {
                if (_canvasGeometry_0013 != nullptr)
                {
                    return _canvasGeometry_0013;
                }
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_ALTERNATE);
                sink->BeginFigure({ -33, -4.76F }, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({ { -30.251F, -4.76F },{ -30.251F, 4.76F },{ -27.501F, 4.76F } });
                sink->AddBezier({ { -24.753F, 4.76F },{ -24.753F, -4.76F },{ -22.004F, -4.76F } });
                sink->AddBezier({ { -19.257F, -4.76F },{ -19.257F, 4.76F },{ -16.51F, 4.76F } });
                sink->AddBezier({ { -13.761F, 4.76F },{ -13.761F, -4.76F },{ -11.013F, -4.76F } });
                sink->AddBezier({ { -8.263F, -4.76F },{ -8.263F, 4.76F },{ -5.513F, 4.76F } });
                sink->AddBezier({ { -2.764F, 4.76F },{ -2.764F, -4.76F },{ -0.014F, -4.76F } });
                sink->AddBezier({ { 2.735F, -4.76F },{ 2.735F, 4.76F },{ 5.485F, 4.76F } });
                sink->AddBezier({ { 8.236F, 4.76F },{ 8.236F, -4.76F },{ 10.986F, -4.76F } });
                sink->AddBezier({ { 13.735F, -4.76F },{ 13.735F, 4.76F },{ 16.484F, 4.76F } });
                sink->AddBezier({ { 19.235F, 4.76F },{ 19.235F, -4.76F },{ 21.987F, -4.76F } });
                sink->AddBezier({ { 24.74F, -4.76F },{ 24.74F, 4.76F },{ 27.493F, 4.76F } });
                sink->AddBezier({ { 30.247F, 4.76F },{ 30.247F, -4.76F },{ 33, -4.76F } });
                sink->EndFigure(D2D1_FIGURE_END_OPEN);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0014()
            {
                CanvasGeometry result;
                ID2D1Geometry **geoA = new ID2D1Geometry*, **geoB = new ID2D1Geometry*;
                CanvasGeometry_0015()->GetGeometry(geoA);
                CanvasGeometry_0004()->GetGeometry(geoB);
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                FFHR((*geoA)->CombineWithGeometry(
                    *geoB,
                    D2D1_COMBINE_MODE_XOR,
                    { 1, 0, 0, 1, 0, 0 },
                    sink.Get()));
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0015()
            {
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ 6.5F, 123 }, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({ { 6.5F, 123 },{ -6.5F, 123 },{ -6.5F, 123 } });
                sink->AddBezier({ { -6.5F, 123 },{ -6.5F, -80 },{ -6.5F, -80 } });
                sink->AddBezier({ { -6.5F, -80 },{ -10, -80 },{ -10, -80 } });
                sink->AddBezier({ { -10, -80 },{ -10, -99.211F },{ -10, -99.211F } });
                sink->AddBezier({ { -12.583F, -101.833F },{ -14, -105.292F },{ -14, -109 } });
                sink->AddBezier({ { -14, -116.72F },{ -7.72F, -123 },{ 0, -123 } });
                sink->AddBezier({ { 7.72F, -123 },{ 14, -116.72F },{ 14, -109 } });
                sink->AddBezier({ { 14, -104.825F },{ 12.184F, -100.946F },{ 9, -98.282F } });
                sink->AddBezier({ { 9, -98.282F },{ 9, -80 },{ 9, -80 } });
                sink->AddBezier({ { 9, -80 },{ 6.5F, -80 },{ 6.5F, -80 } });
                sink->AddBezier({ { 6.5F, -80 },{ 6.5F, 123 },{ 6.5F, 123 } });
                sink->EndFigure(D2D1_FIGURE_END_CLOSED);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0016()
            {
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ 9.5F, -93.688F }, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({ { 9.5F, -93.688F },{ 9.5F, -100.688F },{ 9.5F, -100.688F } });
                sink->AddBezier({ { 9.5F, -100.688F },{ 16.5F, -100.688F },{ 16.5F, -100.688F } });
                sink->AddBezier({ { 16.5F, -100.688F },{ 16.5F, -109.688F },{ 16.5F, -109.688F } });
                sink->AddBezier({ { 16.5F, -109.688F },{ -16.5F, -109.688F },{ -16.5F, -109.688F } });
                sink->AddBezier({ { -16.5F, -109.688F },{ -16.5F, -100.688F },{ -16.5F, -100.688F } });
                sink->AddBezier({ { -16.5F, -100.688F },{ -10.5F, -100.688F },{ -10.5F, -100.688F } });
                sink->AddBezier({ { -10.5F, -100.688F },{ -10.5F, -93.688F },{ -10.5F, -93.688F } });
                sink->AddBezier({ { -10.5F, -93.688F },{ -44.5F, -93.688F },{ -44.5F, -93.688F } });
                sink->AddBezier({ { -44.5F, -93.688F },{ -44.5F, -86.688F },{ -44.5F, -86.688F } });
                sink->AddBezier({ { -44.5F, -86.688F },{ -44.5F, -85.688F },{ -44.5F, -85.688F } });
                sink->AddBezier({ { -44.5F, -85.688F },{ -44.5F, -78.688F },{ -44.5F, -78.688F } });
                sink->AddBezier({ { -44.5F, -78.688F },{ -40.5F, -78.688F },{ -40.5F, -78.688F } });
                sink->AddBezier({ { -40.5F, -78.688F },{ -40.5F, 89.5F },{ -40.5F, 89.5F } });
                sink->AddBezier({ { -40.5F, 89.5F },{ -44.5F, 89.5F },{ -44.5F, 89.5F } });
                sink->AddBezier({ { -44.5F, 89.5F },{ -44.5F, 96.5F },{ -44.5F, 96.5F } });
                sink->AddBezier({ { -44.5F, 96.5F },{ -44.5F, 97.5F },{ -44.5F, 97.5F } });
                sink->AddBezier({ { -44.5F, 97.5F },{ -44.5F, 103.5F },{ -44.5F, 103.5F } });
                sink->AddBezier({ { -44.5F, 103.5F },{ 44.5F, 103.5F },{ 44.5F, 103.5F } });
                sink->AddBezier({ { 44.5F, 103.5F },{ 44.5F, 97.5F },{ 44.5F, 97.5F } });
                sink->AddBezier({ { 44.5F, 97.5F },{ 44.5F, 96.5F },{ 44.5F, 96.5F } });
                sink->AddBezier({ { 44.5F, 96.5F },{ 44.5F, 89.5F },{ 44.5F, 89.5F } });
                sink->AddBezier({ { 44.5F, 89.5F },{ 40.5F, 89.5F },{ 40.5F, 89.5F } });
                sink->AddBezier({ { 40.5F, 89.5F },{ 40.5F, -78.688F },{ 40.5F, -78.688F } });
                sink->AddBezier({ { 40.5F, -78.688F },{ 44.5F, -78.688F },{ 44.5F, -78.688F } });
                sink->AddBezier({ { 44.5F, -78.688F },{ 44.5F, -85.688F },{ 44.5F, -85.688F } });
                sink->AddBezier({ { 44.5F, -85.688F },{ 44.5F, -86.688F },{ 44.5F, -86.688F } });
                sink->AddBezier({ { 44.5F, -86.688F },{ 44.5F, -93.688F },{ 44.5F, -93.688F } });
                sink->AddBezier({ { 44.5F, -93.688F },{ 9.5F, -93.688F },{ 9.5F, -93.688F } });
                sink->EndFigure(D2D1_FIGURE_END_CLOSED);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0017()
            {
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ 8.5F, -100.688F }, D2D1_FIGURE_BEGIN_FILLED);
                sink->EndFigure(D2D1_FIGURE_END_OPEN);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0018()
            {
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ -39.5F, 89.5F }, D2D1_FIGURE_BEGIN_FILLED);
                sink->EndFigure(D2D1_FIGURE_END_OPEN);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0019()
            {
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ -34.5F, 89.5F }, D2D1_FIGURE_BEGIN_FILLED);
                sink->EndFigure(D2D1_FIGURE_END_OPEN);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0020()
            {
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ -34.5F, -78.688F }, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({ { -34.5F, -78.688F },{ 34.5F, -78.688F },{ 34.5F, -78.688F } });
                sink->AddBezier({ { 34.5F, -78.688F },{ 34.5F, 89.5F },{ 34.5F, 89.5F } });
                sink->AddBezier({ { 34.5F, 89.5F },{ -34.5F, 89.5F },{ -34.5F, 89.5F } });
                sink->AddBezier({ { -34.5F, 89.5F },{ -34.5F, -78.688F },{ -34.5F, -78.688F } });
                sink->EndFigure(D2D1_FIGURE_END_CLOSED);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0021()
            {
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ 35.5F, 89.5F }, D2D1_FIGURE_BEGIN_FILLED);
                sink->EndFigure(D2D1_FIGURE_END_OPEN);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0022()
            {
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_ALTERNATE);
                sink->BeginFigure({ -22.393F, -18.988F }, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({ { -22.393F, -18.988F },{ -17.006F, 30.392F },{ -17.006F, 30.392F } });
                sink->AddBezier({ { -15.627F, 41.097F },{ -9.269F, 47.5F },{ 0, 47.5F } });
                sink->AddBezier({ { 9.106F, 47.5F },{ 15.464F, 41.092F },{ 17.01F, 30.358F } });
                sink->AddBezier({ { 17.01F, 30.358F },{ 22.405F, -19.105F },{ 22.405F, -19.105F } });
                sink->AddBezier({ { 22.405F, -19.105F },{ 22.358F, -19.117F },{ 22.358F, -19.117F } });
                sink->AddBezier({ { 22.389F, -19.245F },{ 22.42F, -19.373F },{ 22.448F, -19.501F } });
                sink->AddBezier({ { 22.448F, -19.501F },{ 23, -24.553F },{ 23, -24.553F } });
                sink->AddBezier({ { 22.971F, -37.212F },{ 12.664F, -47.5F },{ 0, -47.5F } });
                sink->AddBezier({ { -12.664F, -47.5F },{ -22.969F, -37.215F },{ -23, -24.558F } });
                sink->AddBezier({ { -23, -24.558F },{ -22.337F, -18.998F },{ -22.337F, -18.998F } });
                sink->AddBezier({ { -22.337F, -18.998F },{ -22.393F, -18.988F },{ -22.393F, -18.988F } });
                sink->EndFigure(D2D1_FIGURE_END_CLOSED);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0023()
            {
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ 0, 143 }, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({ { -3.859F, 143 },{ -7, 146.141F },{ -7, 150 } });
                sink->AddBezier({ { -7, 153.859F },{ -3.859F, 157 },{ 0, 157 } });
                sink->AddBezier({ { 3.859F, 157 },{ 7, 153.859F },{ 7, 150 } });
                sink->AddBezier({ { 7, 146.141F },{ 3.859F, 143 },{ 0, 143 } });
                sink->EndFigure(D2D1_FIGURE_END_CLOSED);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0024()
            {
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ 0, 155 }, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({ { -2.757F, 155 },{ -5, 152.757F },{ -5, 150 } });
                sink->AddBezier({ { -5, 147.243F },{ -2.757F, 145 },{ 0, 145 } });
                sink->AddBezier({ { 2.757F, 145 },{ 5, 147.243F },{ 5, 150 } });
                sink->AddBezier({ { 5, 152.757F },{ 2.757F, 155 },{ 0, 155 } });
                sink->EndFigure(D2D1_FIGURE_END_CLOSED);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0025()
            {
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ -8, -123 }, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({ { -8, -123 },{ -6.5F, -123 },{ -6.5F, -123 } });
                sink->AddBezier({ { -6.5F, -123 },{ 6.5F, -123 },{ 6.5F, -123 } });
                sink->AddBezier({ { 6.5F, -123 },{ 7, -123 },{ 7, -123 } });
                sink->AddBezier({ { 7, -123 },{ 7, -140.248F },{ 7, -140.248F } });
                sink->AddBezier({ { 7, -140.248F },{ 7.385F, -140.548F },{ 7.385F, -140.548F } });
                sink->AddBezier({ { 10.318F, -142.835F },{ 12, -146.28F },{ 12, -150 } });
                sink->AddBezier({ { 12, -156.617F },{ 6.617F, -162 },{ 0, -162 } });
                sink->AddBezier({ { -6.617F, -162 },{ -12, -156.617F },{ -12, -150 } });
                sink->AddBezier({ { -12, -146.699F },{ -10.689F, -143.627F },{ -8.309F, -141.353F } });
                sink->AddBezier({ { -8.309F, -141.353F },{ -8, -141.058F },{ -8, -141.058F } });
                sink->AddBezier({ { -8, -141.058F },{ -8, -123 },{ -8, -123 } });
                sink->EndFigure(D2D1_FIGURE_END_CLOSED);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0026()
            {
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ 0, 162 }, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({ { -6.617F, 162 },{ -12, 156.617F },{ -12, 150 } });
                sink->AddBezier({ { -12, 145.359F },{ -9.282F, 141.092F },{ -5.076F, 139.126F } });
                sink->AddBezier({ { -5.076F, 139.126F },{ -4.5F, 138.856F },{ -4.5F, 138.856F } });
                sink->AddBezier({ { -4.5F, 138.856F },{ -4.5F, -121 },{ -4.5F, -121 } });
                sink->AddBezier({ { -4.5F, -121 },{ 4.5F, -121 },{ 4.5F, -121 } });
                sink->AddBezier({ { 4.5F, -121 },{ 4.5F, 138.856F },{ 4.5F, 138.856F } });
                sink->AddBezier({ { 4.5F, 138.856F },{ 5.076F, 139.126F },{ 5.076F, 139.126F } });
                sink->AddBezier({ { 9.282F, 141.091F },{ 12, 145.359F },{ 12, 150 } });
                sink->AddBezier({ { 12, 156.617F },{ 6.617F, 162 },{ 0, 162 } });
                sink->EndFigure(D2D1_FIGURE_END_CLOSED);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0027()
            {
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ 0, -143 }, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({ { -3.859F, -143 },{ -7, -146.14F },{ -7, -150 } });
                sink->AddBezier({ { -7, -153.86F },{ -3.859F, -157 },{ 0, -157 } });
                sink->AddBezier({ { 3.859F, -157 },{ 7, -153.86F },{ 7, -150 } });
                sink->AddBezier({ { 7, -146.14F },{ 3.859F, -143 },{ 0, -143 } });
                sink->EndFigure(D2D1_FIGURE_END_CLOSED);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0028()
            {
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ 0, -155 }, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({ { -2.757F, -155 },{ -5, -152.757F },{ -5, -150 } });
                sink->AddBezier({ { -5, -147.243F },{ -2.757F, -145 },{ 0, -145 } });
                sink->AddBezier({ { 2.757F, -145 },{ 5, -147.243F },{ 5, -150 } });
                sink->AddBezier({ { 5, -152.757F },{ 2.757F, -155 },{ 0, -155 } });
                sink->EndFigure(D2D1_FIGURE_END_CLOSED);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0029()
            {
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ -8, -115 }, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({ { -8, -115 },{ -8, -143.058F },{ -8, -143.058F } });
                sink->AddBezier({ { -8, -143.058F },{ -8.309F, -143.353F },{ -8.309F, -143.353F } });
                sink->AddBezier({ { -10.689F, -145.627F },{ -12, -148.698F },{ -12, -152 } });
                sink->AddBezier({ { -12, -158.617F },{ -6.617F, -164 },{ 0, -164 } });
                sink->AddBezier({ { 6.617F, -164 },{ 12, -158.617F },{ 12, -152 } });
                sink->AddBezier({ { 12, -148.28F },{ 10.318F, -144.835F },{ 7.385F, -142.548F } });
                sink->AddBezier({ { 7.385F, -142.548F },{ 7, -142.248F },{ 7, -142.248F } });
                sink->AddBezier({ { 7, -142.248F },{ 7, -115 },{ 7, -115 } });
                sink->AddBezier({ { 7, -115 },{ 6.5F, -115 },{ 6.5F, -115 } });
                sink->AddBezier({ { 6.5F, -115 },{ -6.5F, -115 },{ -6.5F, -115 } });
                sink->AddBezier({ { -6.5F, -115 },{ -8, -115 },{ -8, -115 } });
                sink->EndFigure(D2D1_FIGURE_END_CLOSED);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0030()
            {
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ -4.5F, -113 }, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({ { -4.5F, -113 },{ 4.5F, -113 },{ 4.5F, -113 } });
                sink->AddBezier({ { 4.5F, -113 },{ 4.5F, 133 },{ 4.5F, 133 } });
                sink->AddBezier({ { 4.5F, 133 },{ -4.5F, 133 },{ -4.5F, 133 } });
                sink->AddBezier({ { -4.5F, 133 },{ -4.5F, -113 },{ -4.5F, -113 } });
                sink->EndFigure(D2D1_FIGURE_END_CLOSED);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0031()
            {
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ 0, 164 }, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({ { -6.617F, 164 },{ -12, 158.617F },{ -12, 152 } });
                sink->AddBezier({ { -12, 148.698F },{ -10.689F, 145.627F },{ -8.309F, 143.353F } });
                sink->AddBezier({ { -8.309F, 143.353F },{ -8, 143.058F },{ -8, 143.058F } });
                sink->AddBezier({ { -8, 143.058F },{ -8, 135 },{ -8, 135 } });
                sink->AddBezier({ { -8, 135 },{ 7, 135 },{ 7, 135 } });
                sink->AddBezier({ { 7, 135 },{ 7, 142.248F },{ 7, 142.248F } });
                sink->AddBezier({ { 7, 142.248F },{ 7.385F, 142.549F },{ 7.385F, 142.549F } });
                sink->AddBezier({ { 10.318F, 144.835F },{ 12, 148.28F },{ 12, 152 } });
                sink->AddBezier({ { 12, 158.617F },{ 6.617F, 164 },{ 0, 164 } });
                sink->EndFigure(D2D1_FIGURE_END_CLOSED);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0032()
            {
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ 0, -159 }, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({ { -3.86F, -159 },{ -7, -155.86F },{ -7, -152 } });
                sink->AddBezier({ { -7, -148.14F },{ -3.86F, -145 },{ 0, -145 } });
                sink->AddBezier({ { 3.86F, -145 },{ 7, -148.14F },{ 7, -152 } });
                sink->AddBezier({ { 7, -155.86F },{ 3.86F, -159 },{ 0, -159 } });
                sink->EndFigure(D2D1_FIGURE_END_CLOSED);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0033()
            {
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ 0, -147 }, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({ { -2.757F, -147 },{ -5, -149.243F },{ -5, -152 } });
                sink->AddBezier({ { -5, -154.757F },{ -2.757F, -157 },{ 0, -157 } });
                sink->AddBezier({ { 2.757F, -157 },{ 5, -154.757F },{ 5, -152 } });
                sink->AddBezier({ { 5, -149.243F },{ 2.757F, -147 },{ 0, -147 } });
                sink->EndFigure(D2D1_FIGURE_END_CLOSED);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0034()
            {
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ 0, 145 }, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({ { -3.86F, 145 },{ -7, 148.141F },{ -7, 152 } });
                sink->AddBezier({ { -7, 155.859F },{ -3.86F, 159 },{ 0, 159 } });
                sink->AddBezier({ { 3.86F, 159 },{ 7, 155.859F },{ 7, 152 } });
                sink->AddBezier({ { 7, 148.141F },{ 3.86F, 145 },{ 0, 145 } });
                sink->EndFigure(D2D1_FIGURE_END_CLOSED);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0035()
            {
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ 0, 157 }, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({ { -2.757F, 157 },{ -5, 154.757F },{ -5, 152 } });
                sink->AddBezier({ { -5, 149.243F },{ -2.757F, 147 },{ 0, 147 } });
                sink->AddBezier({ { 2.757F, 147 },{ 5, 149.243F },{ 5, 152 } });
                sink->AddBezier({ { 5, 154.757F },{ 2.757F, 157 },{ 0, 157 } });
                sink->EndFigure(D2D1_FIGURE_END_CLOSED);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0036()
            {
                CanvasGeometry result;
                ID2D1Geometry **geoA = new ID2D1Geometry*, **geoB = new ID2D1Geometry*;
                CanvasGeometry_0037()->GetGeometry(geoA);
                CanvasGeometry_0040()->GetGeometry(geoB);
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                FFHR((*geoA)->CombineWithGeometry(
                    *geoB,
                    D2D1_COMBINE_MODE_XOR,
                    { 1, 0, 0, 1, 0, 0 },
                    sink.Get()));
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0037()
            {
                CanvasGeometry result;
                ID2D1Geometry **geoA = new ID2D1Geometry*, **geoB = new ID2D1Geometry*;
                CanvasGeometry_0038()->GetGeometry(geoA);
                CanvasGeometry_0039()->GetGeometry(geoB);
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                FFHR((*geoA)->CombineWithGeometry(
                    *geoB,
                    D2D1_COMBINE_MODE_XOR,
                    { 1, 0, 0, 1, 0, 0 },
                    sink.Get()));
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0038()
            {
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ 98.846F, 31.549F }, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({ { 98.049F, 31.549F },{ 97.242F, 31.477F },{ 96.43F, 31.33F } });
                sink->AddBezier({ { 91.399F, 30.417F },{ 87.287F, 26.692F },{ 85.869F, 21.794F } });
                sink->AddBezier({ { 85.869F, 21.794F },{ -88.01F, -8.907F },{ -88.01F, -8.907F } });
                sink->AddBezier({ { -91.058F, -4.817F },{ -96.221F, -2.773F },{ -101.25F, -3.684F } });
                sink->AddBezier({ { -104.798F, -4.328F },{ -107.883F, -6.314F },{ -109.937F, -9.278F } });
                sink->AddBezier({ { -111.991F, -12.242F },{ -112.767F, -15.829F },{ -112.124F, -19.377F } });
                sink->AddBezier({ { -110.795F, -26.701F },{ -103.752F, -31.579F },{ -96.43F, -30.252F } });
                sink->AddBezier({ { -91.4F, -29.339F },{ -87.287F, -25.611F },{ -85.87F, -20.714F } });
                sink->AddBezier({ { -85.87F, -20.714F },{ 88.01F, 9.985F },{ 88.01F, 9.985F } });
                sink->AddBezier({ { 91.058F, 5.896F },{ 96.221F, 3.855F },{ 101.25F, 4.764F } });
                sink->AddBezier({ { 104.798F, 5.408F },{ 107.883F, 7.394F },{ 109.937F, 10.357F } });
                sink->AddBezier({ { 111.99F, 13.321F },{ 112.767F, 16.908F },{ 112.123F, 20.456F } });
                sink->AddBezier({ { 110.941F, 26.969F },{ 105.243F, 31.548F },{ 98.846F, 31.549F } });
                sink->EndFigure(D2D1_FIGURE_END_CLOSED);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0039()
            {
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ -98.852F, -22.469F }, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({ { -99.961F, -22.469F },{ -101.042F, -22.134F },{ -101.973F, -21.489F } });
                sink->AddBezier({ { -103.18F, -20.652F },{ -103.99F, -19.395F },{ -104.252F, -17.95F } });
                sink->AddBezier({ { -104.793F, -14.966F },{ -102.806F, -12.098F },{ -99.822F, -11.557F } });
                sink->AddBezier({ { -98.376F, -11.291F },{ -96.915F, -11.609F },{ -95.708F, -12.446F } });
                sink->AddBezier({ { -94.5F, -13.283F },{ -93.691F, -14.54F },{ -93.429F, -15.986F } });
                sink->AddBezier({ { -93.166F, -17.431F },{ -93.483F, -18.893F },{ -94.319F, -20.101F } });
                sink->AddBezier({ { -95.156F, -21.308F },{ -96.413F, -22.118F },{ -97.859F, -22.38F } });
                sink->AddBezier({ { -98.19F, -22.44F },{ -98.522F, -22.469F },{ -98.852F, -22.469F } });
                sink->EndFigure(D2D1_FIGURE_END_CLOSED);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0040()
            {
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ 98.828F, 12.545F }, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({ { 97.72F, 12.545F },{ 96.639F, 12.88F },{ 95.707F, 13.525F } });
                sink->AddBezier({ { 94.5F, 14.362F },{ 93.69F, 15.62F },{ 93.429F, 17.066F } });
                sink->AddBezier({ { 93.166F, 18.511F },{ 93.482F, 19.971F },{ 94.319F, 21.179F } });
                sink->AddBezier({ { 95.156F, 22.386F },{ 96.413F, 23.197F },{ 97.858F, 23.459F } });
                sink->AddBezier({ { 99.303F, 23.723F },{ 100.765F, 23.404F },{ 101.973F, 22.567F } });
                sink->AddBezier({ { 103.18F, 21.731F },{ 103.99F, 20.474F },{ 104.252F, 19.028F } });
                sink->AddBezier({ { 104.793F, 16.045F },{ 102.806F, 13.177F },{ 99.822F, 12.636F } });
                sink->AddBezier({ { 99.49F, 12.576F },{ 99.158F, 12.545F },{ 98.828F, 12.545F } });
                sink->EndFigure(D2D1_FIGURE_END_CLOSED);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CanvasGeometry CanvasGeometry_0041()
            {
                if (_canvasGeometry_0041 != nullptr)
                {
                    return _canvasGeometry_0041;
                }
                CanvasGeometry result;
                ComPtr<ID2D1PathGeometry> path;
                FFHR(_d2dFactory->CreatePathGeometry(&path));
                ComPtr<ID2D1GeometrySink> sink;
                FFHR(path->Open(&sink));
                sink->SetFillMode(D2D1_FILL_MODE_WINDING);
                sink->BeginFigure({ 198, 300.813F }, D2D1_FIGURE_BEGIN_FILLED);
                sink->AddBezier({ { 198, 300.813F },{ 267, 300.813F },{ 267, 300.813F } });
                sink->AddBezier({ { 267, 300.813F },{ 267, 469 },{ 267, 469 } });
                sink->AddBezier({ { 267, 469 },{ 198, 469 },{ 198, 469 } });
                sink->AddBezier({ { 198, 469 },{ 198, 300.813F },{ 198, 300.813F } });
                sink->EndFigure(D2D1_FIGURE_END_CLOSED);
                FFHR(sink->Close());
                result = new GeoSource(path.Get());
                return result;
            }

            CompositionColorBrush^ CompositionColorBrush_0000()
            {
                if (_compositionColorBrush_0000 != nullptr)
                {
                    return _compositionColorBrush_0000;
                }
                auto result = _compositionColorBrush_0000 = _c->CreateColorBrush(ColorHelper::FromArgb(0xFF, 0x77, 0x77, 0x7D));
                return result;
            }

            CompositionColorBrush^ CompositionColorBrush_0001()
            {
                if (_compositionColorBrush_0001 != nullptr)
                {
                    return _compositionColorBrush_0001;
                }
                auto result = _compositionColorBrush_0001 = _c->CreateColorBrush(ColorHelper::FromArgb(0xFF, 0x83, 0x84, 0x86));
                return result;
            }

            CompositionColorBrush^ CompositionColorBrush_0002()
            {
                return _c->CreateColorBrush(ColorHelper::FromArgb(0xFF, 0x2B, 0xC4, 0xED));
            }

            CompositionColorBrush^ CompositionColorBrush_0003()
            {
                return _c->CreateColorBrush(ColorHelper::FromArgb(0x00, 0x2B, 0xC4, 0xED));
            }

            CompositionColorBrush^ CompositionColorBrush_0004()
            {
                return _c->CreateColorBrush(ColorHelper::FromArgb(0xFF, 0xF7, 0x7A, 0x10));
            }

            CompositionColorBrush^ CompositionColorBrush_0005()
            {
                return _c->CreateColorBrush(ColorHelper::FromArgb(0xFF, 0xF7, 0x94, 0x21));
            }

            CompositionColorBrush^ CompositionColorBrush_0006()
            {
                return _c->CreateColorBrush(ColorHelper::FromArgb(0xFF, 0x14, 0xA7, 0xDD));
            }

            CompositionColorBrush^ CompositionColorBrush_0007()
            {
                if (_compositionColorBrush_0007 != nullptr)
                {
                    return _compositionColorBrush_0007;
                }
                auto result = _compositionColorBrush_0007 = _c->CreateColorBrush(ColorHelper::FromArgb(0xFF, 0x97, 0xE7, 0xF7));
                return result;
            }

            CompositionColorBrush^ CompositionColorBrush_0008()
            {
                if (_compositionColorBrush_0008 != nullptr)
                {
                    return _compositionColorBrush_0008;
                }
                auto result = _compositionColorBrush_0008 = _c->CreateColorBrush(ColorHelper::FromArgb(0xFF, 0xDA, 0xD4, 0xD3));
                return result;
            }

            CompositionColorBrush^ CompositionColorBrush_0009()
            {
                return _c->CreateColorBrush(ColorHelper::FromArgb(0x51, 0x97, 0xE7, 0xF7));
            }

            CompositionColorBrush^ CompositionColorBrush_0010()
            {
                return _c->CreateColorBrush(ColorHelper::FromArgb(0xE5, 0xE7, 0x4A, 0x8B));
            }

            CompositionColorBrush^ CompositionColorBrush_0011()
            {
                return _c->CreateColorBrush(ColorHelper::FromArgb(0xE5, 0xEF, 0x73, 0xA7));
            }

            CompositionContainerShape^ CompositionContainerShape_0000()
            {
                auto result = _c->CreateContainerShape();
                result->CenterPoint = { 182, 145.5F };
                result->Offset = { 18, 0 };
                auto shapes = result->Shapes;
                shapes->Append(CompositionContainerShape_0001());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0001()
            {
                auto result = _c->CreateContainerShape();
                result->Offset = { 182, 145.5F };
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0000());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0002()
            {
                auto result = _c->CreateContainerShape();
                result->CenterPoint = { 400, 300 };
                result->Offset = { -265.431F, -37.93399F };
                auto shapes = result->Shapes;
                shapes->Append(CompositionContainerShape_0003());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0003()
            {
                auto result = _c->CreateContainerShape();
                result->Offset = { 399.625F, 293 };
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0001());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0004()
            {
                auto result = _c->CreateContainerShape();
                result->CenterPoint = { 400, 300 };
                result->Offset = { -265.431F, -37.93399F };
                auto shapes = result->Shapes;
                shapes->Append(CompositionContainerShape_0005());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0005()
            {
                auto result = _c->CreateContainerShape();
                result->Offset = { 399.625F, 293 };
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0002());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0006()
            {
                auto result = _c->CreateContainerShape();
                result->CenterPoint = { 628, 456 };
                result->Offset = { 18, 0 };
                auto shapes = result->Shapes;
                shapes->Append(CompositionContainerShape_0007());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0007()
            {
                auto result = _c->CreateContainerShape();
                result->Offset = { 628, 455.779F };
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0003());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0008()
            {
                auto result = _c->CreateContainerShape();
                result->CenterPoint = { 355.5F, 455.999F };
                result->Offset = { 18, 0 };
                auto shapes = result->Shapes;
                shapes->Append(CompositionContainerShape_0009());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0009()
            {
                auto result = _c->CreateContainerShape();
                result->Offset = { 355.5F, 455.779F };
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0004());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0010()
            {
                auto result = _c->CreateContainerShape();
                result->CenterPoint = { 355.5F, 455.999F };
                result->Offset = { -222, 0 };
                auto shapes = result->Shapes;
                shapes->Append(CompositionContainerShape_0011());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0011()
            {
                auto result = _c->CreateContainerShape();
                result->Offset = { 355.5F, 455.779F };
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0005());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0012()
            {
                auto result = _c->CreateContainerShape();
                result->CenterPoint = { 714, 493 };
                result->Offset = { 18, -2 };
                result->Scale = { 1.17138F, 1 };
                auto shapes = result->Shapes;
                shapes->Append(CompositionContainerShape_0013());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0013()
            {
                auto result = _c->CreateContainerShape();
                result->Offset = { 431, 493 };
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0006());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0014()
            {
                auto result = _c->CreateContainerShape();
                result->CenterPoint = { 714, 489 };
                result->Offset = { 18, -2 };
                result->Scale = { 1.17138F, 1 };
                auto shapes = result->Shapes;
                shapes->Append(CompositionContainerShape_0015());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0015()
            {
                auto result = _c->CreateContainerShape();
                result->Offset = { 431, 489 };
                result->Scale = { 1, 0.42857F };
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0007());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0016()
            {
                auto result = _c->CreateContainerShape();
                result->CenterPoint = { 431, 486 };
                result->Offset = { -30.5F, 13 };
                result->Scale = { 1.17138F, 7.23214F };
                auto shapes = result->Shapes;
                shapes->Append(CompositionContainerShape_0017());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0017()
            {
                auto result = _c->CreateContainerShape();
                result->Offset = { 431, 493 };
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0008());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0018()
            {
                auto result = _c->CreateContainerShape();
                auto propertySet = result->Properties;
                propertySet->InsertVector2("Anchor", { 400, 300 });
                propertySet->InsertVector2("Position", { 418, 300 });
                result->CenterPoint = { 400, 300 };
                auto shapes = result->Shapes;
                shapes->Append(CompositionContainerShape_0019());
                _expressionAnimation->ClearAllParameters();
                _expressionAnimation->Expression = "my.Position-my.Anchor";
                _expressionAnimation->SetReferenceParameter("my", result);
                result->StartAnimation("Offset", _expressionAnimation);
                result->StartAnimation("Position", Vector2KeyFrameAnimation_0000());
                auto controller = result->TryGetAnimationController("Position");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                result->StartAnimation("RotationAngleInDegrees", ScalarKeyFrameAnimation_0000());
                controller = result->TryGetAnimationController("RotationAngleInDegrees");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0019()
            {
                auto result = _c->CreateContainerShape();
                result->Offset = { 428.913F, 180.086F };
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0009());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0020()
            {
                auto result = _c->CreateContainerShape();
                auto propertySet = result->Properties;
                propertySet->InsertVector2("Anchor", { 400, 300 });
                propertySet->InsertVector2("Position", { 418, 300 });
                result->CenterPoint = { 400, 300 };
                auto shapes = result->Shapes;
                shapes->Append(CompositionContainerShape_0021());
                _expressionAnimation->ClearAllParameters();
                _expressionAnimation->Expression = "my.Position-my.Anchor";
                _expressionAnimation->SetReferenceParameter("my", result);
                result->StartAnimation("Offset", _expressionAnimation);
                result->StartAnimation("Position", Vector2KeyFrameAnimation_0001());
                auto controller = result->TryGetAnimationController("Position");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0021()
            {
                auto result = _c->CreateContainerShape();
                result->CenterPoint = { 400, 300 };
                result->Offset = { -167, 37 };
                auto shapes = result->Shapes;
                shapes->Append(CompositionContainerShape_0022());
                shapes->Append(CompositionContainerShape_0023());
                shapes->Append(CompositionContainerShape_0024());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0022()
            {
                auto result = _c->CreateContainerShape();
                result->Offset = { 400, 425 };
                result->RotationAngleInDegrees = 180;
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0010());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0023()
            {
                auto result = _c->CreateContainerShape();
                result->Offset = { 400, 425 };
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0011());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0024()
            {
                auto result = _c->CreateContainerShape();
                result->Offset = { 399.625F, 293 };
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0012());
                shapes->Append(CompositionSpriteShape_0013());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0025()
            {
                auto result = _c->CreateContainerShape();
                result->CenterPoint = { 232.5F, 379.5F };
                result->Offset = { 18.5F, 0 };
                auto shapes = result->Shapes;
                shapes->Append(CompositionContainerShape_0026());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0026()
            {
                auto result = _c->CreateContainerShape();
                result->Offset = { 232.5F, 379.5F };
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0014());
                shapes->Append(CompositionSpriteShape_0015());
                shapes->Append(CompositionSpriteShape_0016());
                shapes->Append(CompositionSpriteShape_0017());
                shapes->Append(CompositionSpriteShape_0018());
                shapes->Append(CompositionSpriteShape_0019());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0027()
            {
                auto result = _c->CreateContainerShape();
                auto propertySet = result->Properties;
                propertySet->InsertVector2("Anchor", { 400, 300 });
                propertySet->InsertVector2("Position", { 418, 302 });
                result->CenterPoint = { 400, 300 };
                auto shapes = result->Shapes;
                shapes->Append(CompositionContainerShape_0028());
                _expressionAnimation->ClearAllParameters();
                _expressionAnimation->Expression = "my.Position-my.Anchor";
                _expressionAnimation->SetReferenceParameter("my", result);
                result->StartAnimation("Offset", _expressionAnimation);
                result->StartAnimation("Position", Vector2KeyFrameAnimation_0002());
                auto controller = result->TryGetAnimationController("Position");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                result->StartAnimation("RotationAngleInDegrees", ScalarKeyFrameAnimation_0001());
                controller = result->TryGetAnimationController("RotationAngleInDegrees");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0028()
            {
                auto result = _c->CreateContainerShape();
                result->Offset = { 355.584F, 466.5F };
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0020());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0029()
            {
                auto result = _c->CreateContainerShape();
                auto propertySet = result->Properties;
                propertySet->InsertVector2("Anchor", { 400, 300 });
                propertySet->InsertVector2("Position", { 418, 300 });
                result->CenterPoint = { 400, 300 };
                auto shapes = result->Shapes;
                shapes->Append(CompositionContainerShape_0030());
                _expressionAnimation->ClearAllParameters();
                _expressionAnimation->Expression = "my.Position-my.Anchor";
                _expressionAnimation->SetReferenceParameter("my", result);
                result->StartAnimation("Offset", _expressionAnimation);
                result->StartAnimation("Position", Vector2KeyFrameAnimation_0003());
                auto controller = result->TryGetAnimationController("Position");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                result->StartAnimation("RotationAngleInDegrees", ScalarKeyFrameAnimation_0002());
                controller = result->TryGetAnimationController("RotationAngleInDegrees");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0030()
            {
                auto result = _c->CreateContainerShape();
                result->Offset = { 627.225F, 296 };
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0021());
                shapes->Append(CompositionSpriteShape_0022());
                shapes->Append(CompositionSpriteShape_0023());
                shapes->Append(CompositionSpriteShape_0024());
                shapes->Append(CompositionSpriteShape_0025());
                shapes->Append(CompositionSpriteShape_0026());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0031()
            {
                auto result = _c->CreateContainerShape();
                auto propertySet = result->Properties;
                propertySet->InsertVector2("Anchor", { 400, 300 });
                propertySet->InsertVector2("Position", { 418, 300 });
                result->CenterPoint = { 400, 300 };
                auto shapes = result->Shapes;
                shapes->Append(CompositionContainerShape_0032());
                _expressionAnimation->ClearAllParameters();
                _expressionAnimation->Expression = "my.Position-my.Anchor";
                _expressionAnimation->SetReferenceParameter("my", result);
                result->StartAnimation("Offset", _expressionAnimation);
                result->StartAnimation("Position", Vector2KeyFrameAnimation_0004());
                auto controller = result->TryGetAnimationController("Position");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                result->StartAnimation("RotationAngleInDegrees", ScalarKeyFrameAnimation_0003());
                controller = result->TryGetAnimationController("RotationAngleInDegrees");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0032()
            {
                auto result = _c->CreateContainerShape();
                result->Offset = { 355.583F, 346 };
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0027());
                shapes->Append(CompositionSpriteShape_0028());
                shapes->Append(CompositionSpriteShape_0029());
                shapes->Append(CompositionSpriteShape_0030());
                shapes->Append(CompositionSpriteShape_0031());
                shapes->Append(CompositionSpriteShape_0032());
                shapes->Append(CompositionSpriteShape_0033());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0033()
            {
                auto result = _c->CreateContainerShape();
                auto propertySet = result->Properties;
                propertySet->InsertVector2("Anchor", { 400, 300 });
                propertySet->InsertVector2("Position", { 418, 300 });
                result->CenterPoint = { 400, 300 };
                auto shapes = result->Shapes;
                shapes->Append(CompositionContainerShape_0034());
                _expressionAnimation->ClearAllParameters();
                _expressionAnimation->Expression = "my.Position-my.Anchor";
                _expressionAnimation->SetReferenceParameter("my", result);
                result->StartAnimation("Offset", _expressionAnimation);
                result->StartAnimation("Position", Vector2KeyFrameAnimation_0005());
                auto controller = result->TryGetAnimationController("Position");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                result->StartAnimation("RotationAngleInDegrees", ScalarKeyFrameAnimation_0004());
                controller = result->TryGetAnimationController("RotationAngleInDegrees");
                controller->Pause();
                controller->StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0034()
            {
                auto result = _c->CreateContainerShape();
                result->Offset = { 331.75F, 162.46F };
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0034());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0035()
            {
                auto result = _c->CreateContainerShape();
                result->CenterPoint = { -198, 84.906F };
                result->Offset = { 420, 261.25F };
                result->Scale = { 0.08696F, 0.53326F };
                auto shapes = result->Shapes;
                shapes->Append(CompositionContainerShape_0036());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0036()
            {
                auto result = _c->CreateContainerShape();
                result->Offset = { -396, -300 };
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0035());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0037()
            {
                auto result = _c->CreateContainerShape();
                result->CenterPoint = { -163.5F, 169 };
                result->Offset = { 414.5F, 300.5F };
                result->Scale = { 1.01449F, 0.46563F };
                auto shapes = result->Shapes;
                shapes->Append(CompositionContainerShape_0038());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0038()
            {
                auto result = _c->CreateContainerShape();
                result->Offset = { -396, -300 };
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0036());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0039()
            {
                auto result = _c->CreateContainerShape();
                result->CenterPoint = { -239, 84.906F };
                result->Offset = { 466.9F, 345.438F };
                result->Scale = { 0.08696F, 0.46563F };
                auto shapes = result->Shapes;
                shapes->Append(CompositionContainerShape_0040());
                return result;
            }

            CompositionContainerShape^ CompositionContainerShape_0040()
            {
                auto result = _c->CreateContainerShape();
                result->Offset = { -506, -300 };
                auto shapes = result->Shapes;
                shapes->Append(CompositionSpriteShape_0037());
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0000()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0000())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0001()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0001())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0002()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0002())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0003()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0005())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0004()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0006())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0005()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0008())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0006()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0011())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0007()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0011())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0008()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0011())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0009()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0012())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0010()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0013())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0011()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0013())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0012()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0003())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0013()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0014())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0014()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0016())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0015()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0017())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0016()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0018())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0017()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0019())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0018()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0020())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0019()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0021())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0020()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0022())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0021()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0023())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0022()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0024())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0023()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0025())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0024()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0026())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0025()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0027())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0026()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0028())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0027()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0029())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0028()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0030())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0029()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0031())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0030()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0032())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0031()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0033())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0032()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0034())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0033()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0035())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0034()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0036())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0035()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0041())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0036()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0041())));
                return result;
            }

            CompositionPathGeometry^ CompositionPathGeometry_0037()
            {
                auto result = _c->CreatePathGeometry(ref new CompositionPath(CanvasGeometryToIGeometrySource2D(CanvasGeometry_0041())));
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0000()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0000();
                result->Geometry = CompositionPathGeometry_0000();
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0001()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0001();
                result->Geometry = CompositionPathGeometry_0001();
                result->StrokeBrush = CompositionColorBrush_0002();
                result->StrokeMiterLimit = 4;
                result->StrokeThickness = 2;
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0002()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0003();
                result->Geometry = CompositionPathGeometry_0002();
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0003()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0000();
                result->Geometry = CompositionPathGeometry_0003();
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0004()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0000();
                result->Geometry = CompositionPathGeometry_0004();
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0005()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0000();
                result->Geometry = CompositionPathGeometry_0005();
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0006()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0004();
                result->Geometry = CompositionPathGeometry_0006();
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0007()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0005();
                result->Geometry = CompositionPathGeometry_0007();
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0008()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0006();
                result->Geometry = CompositionPathGeometry_0008();
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0009()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0000();
                result->Geometry = CompositionPathGeometry_0009();
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0010()
            {
                auto result = _c->CreateSpriteShape();
                result->Geometry = CompositionPathGeometry_0010();
                result->StrokeBrush = CompositionColorBrush_0000();
                result->StrokeDashCap = CompositionStrokeCap::Round;
                result->StrokeEndCap = CompositionStrokeCap::Round;
                result->StrokeStartCap = CompositionStrokeCap::Round;
                result->StrokeMiterLimit = 10;
                result->StrokeThickness = 2;
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0011()
            {
                auto result = _c->CreateSpriteShape();
                result->Geometry = CompositionPathGeometry_0011();
                result->StrokeBrush = CompositionColorBrush_0000();
                result->StrokeDashCap = CompositionStrokeCap::Round;
                result->StrokeEndCap = CompositionStrokeCap::Round;
                result->StrokeStartCap = CompositionStrokeCap::Round;
                result->StrokeMiterLimit = 10;
                result->StrokeThickness = 2;
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0012()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0001();
                result->Geometry = CompositionPathGeometry_0012();
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0013()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0001();
                result->Geometry = CompositionPathGeometry_0013();
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0014()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0007();
                result->Geometry = CompositionPathGeometry_0014();
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0015()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0007();
                result->Geometry = CompositionPathGeometry_0015();
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0016()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0007();
                result->Geometry = CompositionPathGeometry_0016();
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0017()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0007();
                result->Geometry = CompositionPathGeometry_0017();
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0018()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0007();
                result->Geometry = CompositionPathGeometry_0018();
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0019()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0007();
                result->Geometry = CompositionPathGeometry_0019();
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0020()
            {
                auto result = _c->CreateSpriteShape();
                result->Geometry = CompositionPathGeometry_0020();
                result->StrokeBrush = CompositionColorBrush_0008();
                result->StrokeMiterLimit = 4;
                result->StrokeThickness = 5;
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0021()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0001();
                result->Geometry = CompositionPathGeometry_0021();
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0022()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0001();
                result->Geometry = CompositionPathGeometry_0022();
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0023()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0001();
                result->Geometry = CompositionPathGeometry_0023();
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0024()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0001();
                result->Geometry = CompositionPathGeometry_0024();
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0025()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0001();
                result->Geometry = CompositionPathGeometry_0025();
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0026()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0001();
                result->Geometry = CompositionPathGeometry_0026();
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0027()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0001();
                result->Geometry = CompositionPathGeometry_0027();
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0028()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0001();
                result->Geometry = CompositionPathGeometry_0028();
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0029()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0001();
                result->Geometry = CompositionPathGeometry_0029();
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0030()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0001();
                result->Geometry = CompositionPathGeometry_0030();
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0031()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0001();
                result->Geometry = CompositionPathGeometry_0031();
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0032()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0001();
                result->Geometry = CompositionPathGeometry_0032();
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0033()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0001();
                result->Geometry = CompositionPathGeometry_0033();
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0034()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0008();
                result->Geometry = CompositionPathGeometry_0034();
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0035()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0009();
                result->Geometry = CompositionPathGeometry_0035();
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0036()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0010();
                result->Geometry = CompositionPathGeometry_0036();
                return result;
            }

            CompositionSpriteShape^ CompositionSpriteShape_0037()
            {
                auto result = _c->CreateSpriteShape();
                result->FillBrush = CompositionColorBrush_0011();
                result->Geometry = CompositionPathGeometry_0037();
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
                if (_cubicBezierEasingFunction_0000 != nullptr)
                {
                    return _cubicBezierEasingFunction_0000;
                }
                return _cubicBezierEasingFunction_0000 = _c->CreateCubicBezierEasingFunction({ 0.167F, 0.167F }, { 0.833F, 0.833F });
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
                return _c->CreateLinearEasingFunction();
            }

            ScalarKeyFrameAnimation^ ScalarKeyFrameAnimation_0000()
            {
                auto result = _c->CreateScalarKeyFrameAnimation();
                result->Duration = { 29670000L };
                result->InsertKeyFrame(0, -0.072F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.01123596F, -0.055F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.02247191F, 0.062F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.03370786F, 0.231F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.04494382F, 0.424F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.05617978F, 0.643F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.06741573F, 0.907F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.07865169F, 1.22F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.08988764F, 1.577F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1011236F, 1.973F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1123596F, 2.405F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1235955F, 2.874F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1348315F, 3.381F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1460674F, 3.924F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1573034F, 4.502F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1685393F, 5.112F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1797753F, 5.753F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1910112F, 6.423F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2022472F, 7.12F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2134831F, 7.841F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2247191F, 8.585F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2359551F, 9.347F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.247191F, 10.125F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.258427F, 10.915F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2696629F, 11.713F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2808989F, 12.515F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2921348F, 13.317F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3033708F, 14.115F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3146068F, 14.904F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3258427F, 15.678F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3370787F, 16.433F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3483146F, 17.163F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3595506F, 17.864F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3707865F, 18.53F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3820225F, 19.156F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3932584F, 19.738F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4044944F, 20.27F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4157303F, 20.749F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4269663F, 21.17F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4382023F, 21.53F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4494382F, 21.827F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4606742F, 22.057F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4719101F, 22.22F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4831461F, 22.314F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.494382F, 22.34F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.505618F, 22.298F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5168539F, 22.189F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5280899F, 22.015F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5393258F, 21.779F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5505618F, 21.483F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5617977F, 21.13F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5730337F, 20.723F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5842696F, 20.264F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5955056F, 19.757F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6067415F, 19.205F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6179775F, 18.611F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6292135F, 17.978F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6404495F, 17.311F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6516854F, 16.612F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6629214F, 15.887F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6741573F, 15.139F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6853933F, 14.373F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6966292F, 13.593F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7078652F, 12.804F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7191011F, 12.009F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7303371F, 11.214F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.741573F, 10.421F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.752809F, 9.636F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7640449F, 8.862F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7752809F, 8.102F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7865168F, 7.361F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7977528F, 6.642F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8089887F, 5.947F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8202247F, 5.28F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8314607F, 4.643F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8426966F, 4.04F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8539326F, 3.471F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8651685F, 2.94F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8764045F, 2.448F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8876405F, 1.997F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8988764F, 1.588F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9101124F, 1.222F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9213483F, 0.9F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9325843F, 0.624F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9438202F, 0.394F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9550562F, 0.21F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9662921F, 0.072F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9775281F, -0.018F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.988764F, -0.062F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(1, -0.06F, CubicBezierEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation^ ScalarKeyFrameAnimation_0001()
            {
                auto result = _c->CreateScalarKeyFrameAnimation();
                result->Duration = { 29670000L };
                result->InsertKeyFrame(0, 3.973F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.01123596F, 7.957F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.02247191F, 11.883F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.03370786F, 15.901F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.04494382F, 19.902F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.05617978F, 23.852F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.06741573F, 27.776F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.07865169F, 31.707F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.08988764F, 35.65F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1011236F, 39.591F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1123596F, 43.528F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1235955F, 47.466F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1348315F, 51.415F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1460674F, 55.377F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1573034F, 59.351F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1685393F, 63.335F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1797753F, 67.328F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1910112F, 71.329F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2022472F, 75.34F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2134831F, 79.361F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2247191F, 83.391F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2359551F, 87.429F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.247191F, 91.476F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.258427F, 95.532F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2696629F, 99.596F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2808989F, 103.668F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2921348F, 107.75F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3033708F, 111.84F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3146068F, 115.939F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3258427F, 120.045F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3370787F, 124.159F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3483146F, 128.28F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3595506F, 132.407F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3707865F, 136.539F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3820225F, 140.676F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3932584F, 144.817F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4044944F, 148.959F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4157303F, 153.102F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4269663F, 157.242F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4382023F, 161.378F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4494382F, 165.505F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4606742F, 169.62F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4719101F, 173.718F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4831461F, 177.794F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.494382F, 181.843F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.505618F, 185.862F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5168539F, 189.851F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5280899F, 193.812F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5393258F, 197.75F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5505618F, 201.674F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5617977F, 205.592F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5730337F, 209.516F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5842696F, 213.454F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5955056F, 217.41F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6067415F, 221.387F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6179775F, 225.385F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6292135F, 229.401F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6404495F, 233.432F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6516854F, 237.475F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6629214F, 241.528F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6741573F, 245.588F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6853933F, 249.653F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6966292F, 253.723F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7078652F, 257.796F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7191011F, 261.871F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7303371F, 265.949F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.741573F, 270.028F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.752809F, 274.109F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7640449F, 278.191F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7752809F, 282.273F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7865168F, 286.356F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7977528F, 290.44F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8089887F, 294.524F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8202247F, 298.609F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8314607F, 302.694F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8426966F, 306.78F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8539326F, 310.867F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8651685F, 314.954F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8764045F, 319.042F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8876405F, 323.13F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8988764F, 327.218F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9101124F, 331.306F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9213483F, 335.392F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9325843F, 339.476F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9438202F, 343.556F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9550562F, 347.632F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9662921F, 351.701F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9775281F, 355.76F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.988764F, 359.808F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(1, 363.843F, CubicBezierEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation^ ScalarKeyFrameAnimation_0002()
            {
                auto result = _c->CreateScalarKeyFrameAnimation();
                result->Duration = { 29670000L };
                result->InsertKeyFrame(0, -0.007F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.01123596F, -0.022F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.02247191F, 0.005F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.03370786F, 0.05F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.04494382F, 0.093F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.05617978F, 0.14F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.06741573F, 0.196F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.07865169F, 0.261F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.08988764F, 0.332F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1011236F, 0.406F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1123596F, 0.484F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1235955F, 0.563F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1348315F, 0.643F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1460674F, 0.723F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1573034F, 0.799F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1685393F, 0.872F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1797753F, 0.939F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1910112F, 0.999F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2022472F, 1.05F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2134831F, 1.091F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2247191F, 1.121F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2359551F, 1.138F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.247191F, 1.141F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.258427F, 1.13F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2696629F, 1.104F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2808989F, 1.063F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2921348F, 1.007F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3033708F, 0.936F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3146068F, 0.852F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3258427F, 0.755F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3370787F, 0.647F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3483146F, 0.53F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3595506F, 0.406F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3707865F, 0.277F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3820225F, 0.147F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3932584F, 0.018F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4044944F, -0.107F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4157303F, -0.225F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4269663F, -0.334F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4382023F, -0.429F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4494382F, -0.511F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4606742F, -0.575F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4719101F, -0.622F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4831461F, -0.649F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.494382F, -0.657F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.505618F, -0.645F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5168539F, -0.614F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5280899F, -0.564F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5393258F, -0.498F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5505618F, -0.416F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5617977F, -0.322F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5730337F, -0.216F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5842696F, -0.103F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5955056F, 0.017F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6067415F, 0.141F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6179775F, 0.266F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6292135F, 0.389F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6404495F, 0.51F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6516854F, 0.624F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6629214F, 0.731F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6741573F, 0.829F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6853933F, 0.915F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6966292F, 0.989F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7078652F, 1.049F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7191011F, 1.095F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7303371F, 1.126F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.741573F, 1.143F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.752809F, 1.145F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7640449F, 1.133F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7752809F, 1.107F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7865168F, 1.07F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7977528F, 1.021F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8089887F, 0.962F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8202247F, 0.896F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8314607F, 0.823F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8426966F, 0.744F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8539326F, 0.663F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8651685F, 0.581F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8764045F, 0.498F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8876405F, 0.418F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8988764F, 0.34F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9101124F, 0.268F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9213483F, 0.202F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9325843F, 0.143F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9438202F, 0.093F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9550562F, 0.051F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9662921F, 0.02F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9775281F, -0.001F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.988764F, -0.012F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(1, -0.012F, LinearEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation^ ScalarKeyFrameAnimation_0003()
            {
                auto result = _c->CreateScalarKeyFrameAnimation();
                result->Duration = { 29670000L };
                result->InsertKeyFrame(0, 0.702F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.01123596F, 1.387F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.02247191F, 2.077F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.03370786F, 2.781F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.04494382F, 3.467F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.05617978F, 4.133F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.06741573F, 4.779F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.07865169F, 5.405F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.08988764F, 6.011F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1011236F, 6.59F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1123596F, 7.141F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1235955F, 7.661F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1348315F, 8.147F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1460674F, 8.597F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1573034F, 9.009F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1685393F, 9.38F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1797753F, 9.706F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1910112F, 9.986F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2022472F, 10.216F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2134831F, 10.397F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2247191F, 10.524F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2359551F, 10.598F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.247191F, 10.618F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.258427F, 10.582F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2696629F, 10.49F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2808989F, 10.342F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2921348F, 10.139F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3033708F, 9.882F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3146068F, 9.571F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3258427F, 9.209F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3370787F, 8.798F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3483146F, 8.339F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3595506F, 7.837F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3707865F, 7.294F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3820225F, 6.714F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3932584F, 6.1F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4044944F, 5.457F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4157303F, 4.789F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4269663F, 4.1F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4382023F, 3.395F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4494382F, 2.679F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4606742F, 1.956F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4719101F, 1.232F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4831461F, 0.511F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.494382F, -0.203F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.505618F, -0.904F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5168539F, -1.59F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5280899F, -2.258F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5393258F, -2.906F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5505618F, -3.534F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5617977F, -4.139F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5730337F, -4.722F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5842696F, -5.282F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5955056F, -5.818F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6067415F, -6.327F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6179775F, -6.808F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6292135F, -7.257F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6404495F, -7.673F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6516854F, -8.052F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6629214F, -8.393F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6741573F, -8.693F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6853933F, -8.952F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6966292F, -9.167F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7078652F, -9.338F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7191011F, -9.463F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7303371F, -9.542F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.741573F, -9.574F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.752809F, -9.56F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7640449F, -9.498F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7752809F, -9.389F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7865168F, -9.233F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7977528F, -9.03F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8089887F, -8.783F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8202247F, -8.49F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8314607F, -8.154F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8426966F, -7.776F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8539326F, -7.358F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8651685F, -6.9F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8764045F, -6.406F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8876405F, -5.878F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8988764F, -5.318F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9101124F, -4.728F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9213483F, -4.111F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9325843F, -3.471F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9438202F, -2.811F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9550562F, -2.133F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9662921F, -1.442F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9775281F, -0.742F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.988764F, -0.035F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(1, 0.674F, CubicBezierEasingFunction_0000());
                return result;
            }

            ScalarKeyFrameAnimation^ ScalarKeyFrameAnimation_0004()
            {
                auto result = _c->CreateScalarKeyFrameAnimation();
                result->Duration = { 29670000L };
                result->InsertKeyFrame(0, 0.062F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.01123596F, 0.046F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.02247191F, -0.068F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.03370786F, -0.235F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.04494382F, -0.426F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.05617978F, -0.645F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.06741573F, -0.908F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.07865169F, -1.219F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.08988764F, -1.574F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1011236F, -1.966F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1123596F, -2.395F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1235955F, -2.861F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1348315F, -3.364F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1460674F, -3.903F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1573034F, -4.476F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1685393F, -5.081F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1797753F, -5.717F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1910112F, -6.382F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2022472F, -7.074F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2134831F, -7.791F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2247191F, -8.53F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2359551F, -9.288F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.247191F, -10.061F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.258427F, -10.847F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2696629F, -11.642F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2808989F, -12.441F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2921348F, -13.241F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3033708F, -14.036F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3146068F, -14.822F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3258427F, -15.594F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3370787F, -16.347F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3483146F, -17.075F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3595506F, -17.773F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3707865F, -18.437F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3820225F, -19.06F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3932584F, -19.639F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4044944F, -20.168F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4157303F, -20.643F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4269663F, -21.061F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4382023F, -21.418F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4494382F, -21.712F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4606742F, -21.94F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4719101F, -22.101F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4831461F, -22.193F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.494382F, -22.218F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.505618F, -22.176F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5168539F, -22.067F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5280899F, -21.894F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5393258F, -21.66F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5505618F, -21.366F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5617977F, -21.016F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5730337F, -20.612F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5842696F, -20.157F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5955056F, -19.654F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6067415F, -19.105F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6179775F, -18.514F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6292135F, -17.885F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6404495F, -17.22F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6516854F, -16.524F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6629214F, -15.801F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6741573F, -15.056F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6853933F, -14.292F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6966292F, -13.515F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7078652F, -12.728F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7191011F, -11.937F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7303371F, -11.145F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.741573F, -10.356F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.752809F, -9.575F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7640449F, -8.805F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7752809F, -8.05F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7865168F, -7.314F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7977528F, -6.599F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8089887F, -5.909F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8202247F, -5.247F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8314607F, -4.616F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8426966F, -4.017F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8539326F, -3.452F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8651685F, -2.925F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8764045F, -2.437F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8876405F, -1.989F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8988764F, -1.582F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9101124F, -1.219F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9213483F, -0.9F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9325843F, -0.625F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9438202F, -0.396F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9550562F, -0.213F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9662921F, -0.077F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9775281F, 0.013F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.988764F, 0.057F, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(1, 0.054F, CubicBezierEasingFunction_0000());
                return result;
            }

            ShapeVisual^ ShapeVisual_0000()
            {
                auto result = _c->CreateShapeVisual();
                result->Size = { 800, 600 };
                auto shapes = result->Shapes;
                shapes->Append(CompositionContainerShape_0000());
                shapes->Append(CompositionContainerShape_0002());
                shapes->Append(CompositionContainerShape_0004());
                shapes->Append(CompositionContainerShape_0006());
                shapes->Append(CompositionContainerShape_0008());
                shapes->Append(CompositionContainerShape_0010());
                shapes->Append(CompositionContainerShape_0012());
                shapes->Append(CompositionContainerShape_0014());
                shapes->Append(CompositionContainerShape_0016());
                shapes->Append(CompositionContainerShape_0018());
                shapes->Append(CompositionContainerShape_0020());
                shapes->Append(CompositionContainerShape_0025());
                shapes->Append(CompositionContainerShape_0027());
                shapes->Append(CompositionContainerShape_0029());
                shapes->Append(CompositionContainerShape_0031());
                shapes->Append(CompositionContainerShape_0033());
                shapes->Append(CompositionContainerShape_0035());
                shapes->Append(CompositionContainerShape_0037());
                shapes->Append(CompositionContainerShape_0039());
                return result;
            }

            Vector2KeyFrameAnimation^ Vector2KeyFrameAnimation_0000()
            {
                auto result = _c->CreateVector2KeyFrameAnimation();
                result->Duration = { 29670000L };
                result->InsertKeyFrame(0, { 418.155F, 300.257F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.01123596F, { 418.054F, 300.179F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.02247191F, { 417.88F, 299.725F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.03370786F, { 417.65F, 299.062F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.04494382F, { 417.364F, 298.297F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.05617978F, { 417.03F, 297.42F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.06741573F, { 416.632F, 296.364F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.07865169F, { 416.152F, 295.108F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.08988764F, { 415.597F, 293.672F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1011236F, { 414.976F, 292.076F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1123596F, { 414.29F, 290.325F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1235955F, { 413.534F, 288.413F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1348315F, { 412.705F, 286.338F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1460674F, { 411.802F, 284.102F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1573034F, { 410.826F, 281.71F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1685393F, { 409.778F, 279.169F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1797753F, { 408.659F, 276.482F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1910112F, { 407.467F, 273.656F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2022472F, { 406.206F, 270.696F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2134831F, { 404.875F, 267.612F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2247191F, { 403.479F, 264.412F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2359551F, { 402.021F, 261.11F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.247191F, { 400.506F, 257.717F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.258427F, { 398.94F, 254.25F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2696629F, { 397.329F, 250.724F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2808989F, { 395.68F, 247.158F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2921348F, { 394.003F, 243.57F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3033708F, { 392.307F, 239.983F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3146068F, { 390.604F, 236.42F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3258427F, { 388.906F, 232.904F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3370787F, { 387.226F, 229.46F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3483146F, { 385.578F, 226.115F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3595506F, { 383.976F, 222.894F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3707865F, { 382.435F, 219.823F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3820225F, { 380.969F, 216.929F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3932584F, { 379.595F, 214.234F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4044944F, { 378.325F, 211.764F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4157303F, { 377.173F, 209.539F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4269663F, { 376.153F, 207.579F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4382023F, { 375.275F, 205.901F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4494382F, { 374.549F, 204.519F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4606742F, { 373.982F, 203.445F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4719101F, { 373.58F, 202.687F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4831461F, { 373.348F, 202.249F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.494382F, { 373.285F, 202.131F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.505618F, { 373.392F, 202.33F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5168539F, { 373.664F, 202.841F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5280899F, { 374.096F, 203.654F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5393258F, { 374.68F, 204.757F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5505618F, { 375.409F, 206.137F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5617977F, { 376.274F, 207.781F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5730337F, { 377.264F, 209.675F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5842696F, { 378.369F, 211.804F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5955056F, { 379.58F, 214.155F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6067415F, { 380.887F, 216.71F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6179775F, { 382.279F, 219.455F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6292135F, { 383.745F, 222.372F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6404495F, { 385.273F, 225.441F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6516854F, { 386.853F, 228.641F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6629214F, { 388.471F, 231.953F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6741573F, { 390.117F, 235.353F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6853933F, { 391.778F, 238.82F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6966292F, { 393.444F, 242.333F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7078652F, { 395.103F, 245.869F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7191011F, { 396.745F, 249.409F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7303371F, { 398.362F, 252.932F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.741573F, { 399.944F, 256.419F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.752809F, { 401.484F, 259.852F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7640449F, { 402.975F, 263.215F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7752809F, { 404.411F, 266.492F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7865168F, { 405.787F, 269.668F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7977528F, { 407.098F, 272.731F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8089887F, { 408.341F, 275.668F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8202247F, { 409.513F, 278.47F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8314607F, { 410.611F, 281.127F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8426966F, { 411.635F, 283.63F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8539326F, { 412.583F, 285.974F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8651685F, { 413.454F, 288.151F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8764045F, { 414.249F, 290.158F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8876405F, { 414.967F, 291.989F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8988764F, { 415.61F, 293.642F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9101124F, { 416.177F, 295.114F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9213483F, { 416.67F, 296.402F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9325843F, { 417.089F, 297.505F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9438202F, { 417.435F, 298.423F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9550562F, { 417.709F, 299.154F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9662921F, { 417.912F, 299.699F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9775281F, { 418.045F, 300.057F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.988764F, { 418.109F, 300.23F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(1, { 418.103F, 300.218F }, CubicBezierEasingFunction_0000());
                return result;
            }

            Vector2KeyFrameAnimation^ Vector2KeyFrameAnimation_0001()
            {
                auto result = _c->CreateVector2KeyFrameAnimation();
                result->Duration = { 29670000L };
                result->InsertKeyFrame(0, { 418.069F, 300.566F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.01123596F, { 417.988F, 300.501F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.02247191F, { 417.979F, 299.67F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.03370786F, { 417.999F, 298.469F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.04494382F, { 417.997F, 297.133F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.05617978F, { 417.991F, 295.632F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.06741573F, { 417.989F, 293.821F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.07865169F, { 417.986F, 291.654F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.08988764F, { 417.979F, 289.176F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1011236F, { 417.971F, 286.435F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1123596F, { 417.964F, 283.441F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1235955F, { 417.957F, 280.186F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1348315F, { 417.949F, 276.665F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1460674F, { 417.941F, 272.888F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1573034F, { 417.932F, 268.867F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1685393F, { 417.923F, 264.617F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1797753F, { 417.914F, 260.15F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1910112F, { 417.906F, 255.477F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2022472F, { 417.897F, 250.611F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2134831F, { 417.889F, 245.57F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2247191F, { 417.88F, 240.372F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2359551F, { 417.872F, 235.041F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.247191F, { 417.864F, 229.598F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.258427F, { 417.856F, 224.071F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2696629F, { 417.848F, 218.485F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2808989F, { 417.84F, 212.87F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2921348F, { 417.832F, 207.257F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3033708F, { 417.824F, 201.68F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3146068F, { 417.816F, 196.172F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3258427F, { 417.808F, 190.77F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3370787F, { 417.8F, 185.51F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3483146F, { 417.792F, 180.427F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3595506F, { 417.785F, 175.559F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3707865F, { 417.778F, 170.94F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3820225F, { 417.771F, 166.606F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3932584F, { 417.765F, 162.588F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4044944F, { 417.76F, 158.918F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4157303F, { 417.755F, 155.622F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4269663F, { 417.752F, 152.727F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4382023F, { 417.748F, 150.253F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4494382F, { 417.746F, 148.218F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4606742F, { 417.745F, 146.636F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4719101F, { 417.744F, 145.518F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4831461F, { 417.744F, 144.867F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.494382F, { 417.745F, 144.685F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.505618F, { 417.747F, 144.968F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5168539F, { 417.75F, 145.708F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5280899F, { 417.755F, 146.893F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5393258F, { 417.76F, 148.51F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5505618F, { 417.766F, 150.541F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5617977F, { 417.773F, 152.969F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5730337F, { 417.78F, 155.774F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5842696F, { 417.787F, 158.937F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5955056F, { 417.794F, 162.439F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6067415F, { 417.801F, 166.26F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6179775F, { 417.807F, 170.377F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6292135F, { 417.813F, 174.767F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6404495F, { 417.819F, 179.406F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6516854F, { 417.825F, 184.266F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6629214F, { 417.831F, 189.319F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6741573F, { 417.838F, 194.535F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6853933F, { 417.844F, 199.884F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6966292F, { 417.852F, 205.334F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7078652F, { 417.859F, 210.854F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7191011F, { 417.867F, 216.412F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7303371F, { 417.875F, 221.979F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.741573F, { 417.883F, 227.524F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.752809F, { 417.891F, 233.018F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7640449F, { 417.9F, 238.433F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7752809F, { 417.909F, 243.741F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7865168F, { 417.918F, 248.919F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7977528F, { 417.927F, 253.941F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8089887F, { 417.937F, 258.787F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8202247F, { 417.946F, 263.434F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8314607F, { 417.956F, 267.865F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8426966F, { 417.965F, 272.062F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8539326F, { 417.974F, 276.01F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8651685F, { 417.982F, 279.696F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8764045F, { 417.99F, 283.107F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8876405F, { 417.998F, 286.233F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8988764F, { 418.004F, 289.065F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9101124F, { 418.01F, 291.595F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9213483F, { 418.015F, 293.817F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9325843F, { 418.02F, 295.727F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9438202F, { 418.023F, 297.32F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9550562F, { 418.025F, 298.593F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9662921F, { 418.027F, 299.545F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9775281F, { 418.028F, 300.174F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.988764F, { 418.028F, 300.482F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(1, { 418.026F, 300.469F }, CubicBezierEasingFunction_0000());
                return result;
            }

            Vector2KeyFrameAnimation^ Vector2KeyFrameAnimation_0002()
            {
                auto result = _c->CreateVector2KeyFrameAnimation();
                result->Duration = { 29670000L };
                result->InsertKeyFrame(0, { 427.784F, 305.484F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.01123596F, { 437.329F, 309.65F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.02247191F, { 446.429F, 314.395F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.03370786F, { 455.386F, 319.885F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.04494382F, { 463.9F, 325.961F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.05617978F, { 471.867F, 332.528F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.06741573F, { 479.317F, 339.579F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.07865169F, { 486.279F, 347.139F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.08988764F, { 492.724F, 355.182F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1011236F, { 498.6F, 363.647F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1123596F, { 503.873F, 372.484F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1235955F, { 508.529F, 381.666F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1348315F, { 512.553F, 391.172F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1460674F, { 515.923F, 400.966F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1573034F, { 518.616F, 411.001F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1685393F, { 520.611F, 421.223F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1797753F, { 521.893F, 431.581F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1910112F, { 522.45F, 442.027F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2022472F, { 522.276F, 452.51F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2134831F, { 521.367F, 462.981F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2247191F, { 519.72F, 473.387F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2359551F, { 517.341F, 483.672F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.247191F, { 514.236F, 493.786F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.258427F, { 510.416F, 503.675F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2696629F, { 505.896F, 513.29F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2808989F, { 500.695F, 522.58F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2921348F, { 494.833F, 531.495F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3033708F, { 488.337F, 539.988F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3146068F, { 481.237F, 548.012F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3258427F, { 473.567F, 555.522F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3370787F, { 465.363F, 562.475F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3483146F, { 456.666F, 568.832F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3595506F, { 447.521F, 574.556F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3707865F, { 437.975F, 579.613F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3820225F, { 428.078F, 583.973F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3932584F, { 417.884F, 587.611F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4044944F, { 407.449F, 590.504F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4157303F, { 396.832F, 592.636F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4269663F, { 386.093F, 593.995F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4382023F, { 375.297F, 594.575F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4494382F, { 364.51F, 594.376F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4606742F, { 353.797F, 593.406F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4719101F, { 343.225F, 591.677F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4831461F, { 332.859F, 589.214F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.494382F, { 322.761F, 586.042F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.505618F, { 312.982F, 582.197F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5168539F, { 303.568F, 577.712F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5280899F, { 294.551F, 572.622F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5393258F, { 285.956F, 566.956F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5505618F, { 277.8F, 560.736F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5617977F, { 270.097F, 553.982F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5730337F, { 262.865F, 546.707F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5842696F, { 256.126F, 538.927F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5955056F, { 249.908F, 530.662F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6067415F, { 244.248F, 521.941F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6179775F, { 239.181F, 512.8F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6292135F, { 234.746F, 503.285F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6404495F, { 230.975F, 493.444F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6516854F, { 227.897F, 483.333F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6629214F, { 225.534F, 473.005F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6741573F, { 223.906F, 462.518F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6853933F, { 223.023F, 451.928F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6966292F, { 222.894F, 441.29F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7078652F, { 223.52F, 430.661F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7191011F, { 224.901F, 420.097F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7303371F, { 227.031F, 409.652F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.741573F, { 229.9F, 399.381F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.752809F, { 233.493F, 389.337F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7640449F, { 237.792F, 379.571F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7752809F, { 242.778F, 370.135F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7865168F, { 248.423F, 361.076F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7977528F, { 254.7F, 352.441F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8089887F, { 261.576F, 344.274F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8202247F, { 269.019F, 336.616F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8314607F, { 276.988F, 329.507F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8426966F, { 285.446F, 322.982F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8539326F, { 294.348F, 317.077F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8651685F, { 303.649F, 311.819F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8764045F, { 313.303F, 307.238F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8876405F, { 323.26F, 303.356F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8988764F, { 333.468F, 300.194F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9101124F, { 343.875F, 297.768F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9213483F, { 354.424F, 296.09F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9325843F, { 365.061F, 295.169F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9438202F, { 375.727F, 295.007F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9550562F, { 386.364F, 295.603F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9662921F, { 396.914F, 296.951F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9775281F, { 407.319F, 299.039F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.988764F, { 417.522F, 301.849F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(1, { 427.469F, 305.36F }, CubicBezierEasingFunction_0000());
                return result;
            }

            Vector2KeyFrameAnimation^ Vector2KeyFrameAnimation_0003()
            {
                auto result = _c->CreateVector2KeyFrameAnimation();
                result->Duration = { 29670000L };
                result->InsertKeyFrame(0, { 417.983F, 300.027F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.01123596F, { 417.945F, 300.086F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.02247191F, { 418.013F, 299.979F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.03370786F, { 418.127F, 299.802F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.04494382F, { 418.238F, 299.63F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.05617978F, { 418.357F, 299.446F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.06741573F, { 418.501F, 299.224F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.07865169F, { 418.667F, 298.967F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.08988764F, { 418.849F, 298.688F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1011236F, { 419.041F, 298.393F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1123596F, { 419.241F, 298.087F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1235955F, { 419.446F, 297.773F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1348315F, { 419.654F, 297.458F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1460674F, { 419.859F, 297.147F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1573034F, { 420.059F, 296.845F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1685393F, { 420.248F, 296.56F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1797753F, { 420.423F, 296.297F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1910112F, { 420.579F, 296.063F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2022472F, { 420.713F, 295.862F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2134831F, { 420.821F, 295.701F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2247191F, { 420.898F, 295.585F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2359551F, { 420.943F, 295.519F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.247191F, { 420.952F, 295.505F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.258427F, { 420.923F, 295.548F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2696629F, { 420.855F, 295.649F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2808989F, { 420.748F, 295.81F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2921348F, { 420.601F, 296.03F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3033708F, { 420.416F, 296.307F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3146068F, { 420.196F, 296.638F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3258427F, { 419.943F, 297.02F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3370787F, { 419.663F, 297.445F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3483146F, { 419.359F, 297.906F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3595506F, { 419.039F, 298.396F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3707865F, { 418.708F, 298.903F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3820225F, { 418.375F, 299.418F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3932584F, { 418.045F, 299.93F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4044944F, { 417.727F, 300.426F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4157303F, { 417.428F, 300.894F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4269663F, { 417.154F, 301.325F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4382023F, { 416.912F, 301.707F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4494382F, { 416.708F, 302.03F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4606742F, { 416.546F, 302.288F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4719101F, { 416.429F, 302.474F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4831461F, { 416.361F, 302.583F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.505618F, { 416.372F, 302.566F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5168539F, { 416.45F, 302.441F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5280899F, { 416.574F, 302.243F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5393258F, { 416.741F, 301.979F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5505618F, { 416.946F, 301.654F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5617977F, { 417.184F, 301.278F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5730337F, { 417.45F, 300.859F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5842696F, { 417.739F, 300.407F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5955056F, { 418.044F, 299.931F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6067415F, { 418.36F, 299.442F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6179775F, { 418.68F, 298.948F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6292135F, { 418.998F, 298.459F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6404495F, { 419.308F, 297.985F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6516854F, { 419.604F, 297.533F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6629214F, { 419.882F, 297.113F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6741573F, { 420.135F, 296.73F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6853933F, { 420.36F, 296.391F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6966292F, { 420.553F, 296.102F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7078652F, { 420.711F, 295.866F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7191011F, { 420.831F, 295.686F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7303371F, { 420.913F, 295.563F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.741573F, { 420.957F, 295.498F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.752809F, { 420.962F, 295.49F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7640449F, { 420.93F, 295.538F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7752809F, { 420.864F, 295.637F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7865168F, { 420.765F, 295.785F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7977528F, { 420.637F, 295.976F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8089887F, { 420.484F, 296.205F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8202247F, { 420.31F, 296.467F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8314607F, { 420.119F, 296.754F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8426966F, { 419.916F, 297.061F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8539326F, { 419.705F, 297.381F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8651685F, { 419.491F, 297.706F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8764045F, { 419.278F, 298.031F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8876405F, { 419.07F, 298.349F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8988764F, { 418.871F, 298.653F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9101124F, { 418.686F, 298.938F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9213483F, { 418.516F, 299.2F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9325843F, { 418.366F, 299.432F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9438202F, { 418.237F, 299.632F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9550562F, { 418.131F, 299.796F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9662921F, { 418.051F, 299.921F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9775281F, { 417.997F, 300.005F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.988764F, { 417.97F, 300.046F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(1, { 417.971F, 300.046F }, CubicBezierEasingFunction_0000());
                return result;
            }

            Vector2KeyFrameAnimation^ Vector2KeyFrameAnimation_0004()
            {
                auto result = _c->CreateVector2KeyFrameAnimation();
                result->Duration = { 29670000L };
                result->InsertKeyFrame(0, { 416.717F, 300.765F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.01123596F, { 415.366F, 301.133F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.02247191F, { 414.117F, 301.11F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.03370786F, { 412.884F, 300.837F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.04494382F, { 411.662F, 300.394F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.05617978F, { 410.472F, 299.774F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.06741573F, { 409.332F, 298.923F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.07865169F, { 408.237F, 297.822F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.08988764F, { 407.19F, 296.49F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1011236F, { 406.195F, 294.947F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1123596F, { 405.258F, 293.2F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1235955F, { 404.382F, 291.247F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1348315F, { 403.568F, 289.088F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1460674F, { 402.821F, 286.726F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1573034F, { 402.142F, 284.171F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1685393F, { 401.537F, 281.431F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1797753F, { 401.007F, 278.516F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1910112F, { 400.555F, 275.433F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2022472F, { 400.184F, 272.193F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2134831F, { 399.895F, 268.808F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2247191F, { 399.69F, 265.29F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2359551F, { 399.568F, 261.657F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.247191F, { 399.532F, 257.923F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.258427F, { 399.581F, 254.107F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2696629F, { 399.714F, 250.226F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2808989F, { 399.931F, 246.3F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2921348F, { 400.232F, 242.351F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3033708F, { 400.614F, 238.4F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3146068F, { 401.077F, 234.471F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3258427F, { 401.618F, 230.587F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3370787F, { 402.236F, 226.772F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3483146F, { 402.928F, 223.052F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3595506F, { 403.692F, 219.45F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3707865F, { 404.526F, 215.991F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3820225F, { 405.426F, 212.699F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3932584F, { 406.389F, 209.595F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4044944F, { 407.412F, 206.702F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4157303F, { 408.49F, 204.04F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4269663F, { 409.62F, 201.626F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4382023F, { 410.796F, 199.478F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4494382F, { 412.013F, 197.61F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4606742F, { 413.265F, 196.033F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4719101F, { 414.545F, 194.757F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4831461F, { 415.846F, 193.788F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.494382F, { 417.159F, 193.128F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.505618F, { 418.479F, 192.778F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5168539F, { 419.796F, 192.733F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5280899F, { 421.105F, 192.99F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5393258F, { 422.398F, 193.538F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5505618F, { 423.669F, 194.371F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5617977F, { 424.915F, 195.478F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5730337F, { 426.13F, 196.851F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5842696F, { 427.31F, 198.481F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5955056F, { 428.45F, 200.359F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6067415F, { 429.543F, 202.476F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6179775F, { 430.584F, 204.822F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6292135F, { 431.565F, 207.384F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6404495F, { 432.479F, 210.149F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6516854F, { 433.32F, 213.102F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6629214F, { 434.08F, 216.225F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6741573F, { 434.754F, 219.5F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6853933F, { 435.338F, 222.908F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6966292F, { 435.827F, 226.431F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7078652F, { 436.218F, 230.048F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7191011F, { 436.509F, 233.74F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7303371F, { 436.697F, 237.485F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.741573F, { 436.783F, 241.266F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.752809F, { 436.765F, 245.061F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7640449F, { 436.645F, 248.852F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7752809F, { 436.424F, 252.619F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7865168F, { 436.103F, 256.345F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7977528F, { 435.684F, 260.012F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8089887F, { 435.172F, 263.604F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8202247F, { 434.569F, 267.103F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8314607F, { 433.879F, 270.496F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8426966F, { 433.107F, 273.767F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8539326F, { 432.256F, 276.902F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8651685F, { 431.333F, 279.89F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8764045F, { 430.342F, 282.718F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8876405F, { 429.289F, 285.376F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8988764F, { 428.18F, 287.852F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9101124F, { 427.021F, 290.137F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9213483F, { 425.818F, 292.224F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9325843F, { 424.578F, 294.103F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9438202F, { 423.307F, 295.769F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9550562F, { 422.014F, 297.215F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9662921F, { 420.704F, 298.435F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9775281F, { 419.385F, 299.426F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.988764F, { 418.065F, 300.184F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(1, { 416.75F, 300.707F }, CubicBezierEasingFunction_0000());
                return result;
            }

            Vector2KeyFrameAnimation^ Vector2KeyFrameAnimation_0005()
            {
                auto result = _c->CreateVector2KeyFrameAnimation();
                result->Duration = { 29670000L };
                result->InsertKeyFrame(0, { 417.834F, 300.18F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.01123596F, { 417.876F, 300.134F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.02247191F, { 418.183F, 299.802F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.03370786F, { 418.632F, 299.314F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.04494382F, { 419.144F, 298.754F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.05617978F, { 419.728F, 298.111F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.06741573F, { 420.426F, 297.336F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.07865169F, { 421.248F, 296.413F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.08988764F, { 422.179F, 295.357F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1011236F, { 423.201F, 294.181F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1123596F, { 424.308F, 292.889F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1235955F, { 425.499F, 291.476F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1348315F, { 426.773F, 289.94F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1460674F, { 428.123F, 288.281F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1573034F, { 429.542F, 286.503F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1685393F, { 431.021F, 284.609F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1797753F, { 432.553F, 282.603F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.1910112F, { 434.131F, 280.488F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2022472F, { 435.747F, 278.267F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2134831F, { 437.393F, 275.947F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2247191F, { 439.058F, 273.534F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2359551F, { 440.734F, 271.036F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.247191F, { 442.411F, 268.464F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.258427F, { 444.079F, 265.828F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2696629F, { 445.728F, 263.139F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2808989F, { 447.349F, 260.413F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.2921348F, { 448.932F, 257.663F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3033708F, { 450.469F, 254.906F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3146068F, { 451.95F, 252.16F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3258427F, { 453.368F, 249.444F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3370787F, { 454.715F, 246.777F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3483146F, { 455.985F, 244.181F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3595506F, { 457.172F, 241.676F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3707865F, { 458.271F, 239.283F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3820225F, { 459.278F, 237.023F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.3932584F, { 460.191F, 234.916F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4044944F, { 461.007F, 232.981F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4157303F, { 461.725F, 231.237F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4269663F, { 462.344F, 229.698F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4382023F, { 462.864F, 228.38F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4494382F, { 463.286F, 227.293F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4606742F, { 463.609F, 226.449F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4719101F, { 463.835F, 225.852F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.4831461F, { 463.965F, 225.507F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.494382F, { 463.999F, 225.415F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.505618F, { 463.94F, 225.574F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5168539F, { 463.788F, 225.977F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5280899F, { 463.545F, 226.618F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5393258F, { 463.211F, 227.487F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5505618F, { 462.788F, 228.573F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5617977F, { 462.277F, 229.866F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5730337F, { 461.678F, 231.353F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5842696F, { 460.99F, 233.022F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.5955056F, { 460.214F, 234.862F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6067415F, { 459.35F, 236.86F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6179775F, { 458.397F, 239.002F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6292135F, { 457.358F, 241.275F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6404495F, { 456.234F, 243.661F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6516854F, { 455.028F, 246.146F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6629214F, { 453.743F, 248.711F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6741573F, { 452.384F, 251.339F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6853933F, { 450.956F, 254.012F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.6966292F, { 449.467F, 256.714F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7078652F, { 447.923F, 259.427F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7191011F, { 446.331F, 262.135F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7303371F, { 444.701F, 264.824F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.741573F, { 443.041F, 267.478F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.752809F, { 441.361F, 270.083F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7640449F, { 439.671F, 272.629F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7752809F, { 437.981F, 275.102F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7865168F, { 436.301F, 277.494F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.7977528F, { 434.641F, 279.793F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8089887F, { 433.012F, 281.994F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8202247F, { 431.424F, 284.087F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8314607F, { 429.885F, 286.067F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8426966F, { 428.407F, 287.929F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8539326F, { 426.997F, 289.668F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8651685F, { 425.663F, 291.28F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8764045F, { 424.415F, 292.763F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8876405F, { 423.259F, 294.114F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.8988764F, { 422.201F, 295.332F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9101124F, { 421.248F, 296.414F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9213483F, { 420.404F, 297.36F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9325843F, { 419.675F, 298.17F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9438202F, { 419.064F, 298.842F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9550562F, { 418.573F, 299.378F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9662921F, { 418.206F, 299.777F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.9775281F, { 417.964F, 300.039F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(0.988764F, { 417.847F, 300.166F }, CubicBezierEasingFunction_0000());
                result->InsertKeyFrame(1, { 417.854F, 300.157F }, CubicBezierEasingFunction_0000());
                return result;
            }

            static IGeometrySource2D^ CanvasGeometryToIGeometrySource2D(CanvasGeometry geo)
            {
                ComPtr<ABI::Windows::Graphics::IGeometrySource2D> interop = geo.Detach();
                return reinterpret_cast<IGeometrySource2D^>(interop.Get());
            }

            static void FFHR(HRESULT hr)
            {
                if (hr != S_OK)
                {
                    RoFailFastWithErrorContext(hr);
                }
            }

            Instantiator(Compositor^ compositor)
            {
                _c = compositor;
                _expressionAnimation = _c->CreateExpressionAnimation();
                FFHR(D2D1CreateFactory(D2D1_FACTORY_TYPE_SINGLE_THREADED, _d2dFactory.GetAddressOf()));
            }

        public:
            static Visual^ InstantiateComposition(Compositor^ compositor)
            {
                return Instantiator(compositor).ContainerVisual_0000();
            }

        };
    };
}
