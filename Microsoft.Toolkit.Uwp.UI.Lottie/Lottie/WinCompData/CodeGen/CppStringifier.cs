using System;
using WinCompData.Sn;
using WinCompData.Wui;

namespace WinCompData.CodeGen
{
    /// <summary>
    /// Stringifiers for C++ syntax.
    /// </summary>
    sealed class CppStringifier : InstantiatorGeneratorBase.IStringifier
    {
        string InstantiatorGeneratorBase.IStringifier.Bool(bool value) => value ? "true" : "false";

        public string CanvasFigureLoop(Mgcg.CanvasFigureLoop value)
        {
            switch (value)
            {
                case Mgcg.CanvasFigureLoop.Open:
                    return "D2D1_FIGURE_END_OPEN";
                case Mgcg.CanvasFigureLoop.Closed:
                    return "D2D1_FIGURE_END_CLOSED";
                default:
                    throw new InvalidOperationException();
            }
        }

        public string CanvasGeometryCombine(Mgcg.CanvasGeometryCombine value)
        {
            switch (value)
            {
                case Mgcg.CanvasGeometryCombine.Union:
                    return "D2D1_COMBINE_MODE_UNION";
                case Mgcg.CanvasGeometryCombine.Exclude:
                    return "D2D1_COMBINE_MODE_EXCLUDE";
                case Mgcg.CanvasGeometryCombine.Intersect:
                    return "D2D1_COMBINE_MODE_INTERSECT";
                case Mgcg.CanvasGeometryCombine.Xor:
                    return "D2D1_COMBINE_MODE_XOR";
                default:
                    throw new InvalidOperationException();
            }
        }

        string InstantiatorGeneratorBase.IStringifier.Color(Color value) => $"ColorHelper::FromArgb({Hex(value.A)}, {Hex(value.R)}, {Hex(value.G)}, {Hex(value.B)})";

        public string Deref => "->";

        string InstantiatorGeneratorBase.IStringifier.Float(float value) => Float(value);

        public string FilledRegionDetermination(Mgcg.CanvasFilledRegionDetermination value)
        {
            switch (value)
            {
                case Mgcg.CanvasFilledRegionDetermination.Alternate:
                    return "D2D1_FILL_MODE_ALTERNATE";
                case Mgcg.CanvasFilledRegionDetermination.Winding:
                    return "D2D1_FILL_MODE_WINDING";
                default:
                    throw new InvalidOperationException();
            }
        }

        string InstantiatorGeneratorBase.IStringifier.Int32(int value) => value.ToString();
        public string Int64(long value) => $"{value}L";

        string InstantiatorGeneratorBase.IStringifier.Int64TypeName => "int64_t";

        string InstantiatorGeneratorBase.IStringifier.ScopeResolve => "::";

        public string MemberSelect => ".";

        public string New => "ref new";

        string InstantiatorGeneratorBase.IStringifier.Null => "nullptr";

        public string Matrix3x2(Matrix3x2 value)
        {
            return $"{{{Float(value.M11)}, {Float(value.M12)}, {Float(value.M21)}, {Float(value.M22)}, {Float(value.M31)}, {Float(value.M32)}}}";
        }

        string InstantiatorGeneratorBase.IStringifier.Readonly => "";

        string InstantiatorGeneratorBase.IStringifier.ReferenceTypeName(string value) =>
            value == "CanvasGeometry"
                // C++ uses a typdef for CanvasGeometry that is ComPtr<GeoSource>, thus no hat pointer
                ? "CanvasGeometry"
                : $"{value}^";

        string InstantiatorGeneratorBase.IStringifier.String(string value) => $"\"{value}\"";

        public string TimeSpan(TimeSpan value) => TimeSpan(Int64(value.Ticks));
        public string TimeSpan(string ticks) => $"{{ {ticks} }}";

        string InstantiatorGeneratorBase.IStringifier.Var => "auto";

        public string Vector2(Vector2 value) => $"{{ {Float(value.X)}, {Float(value.Y)} }}";

        string InstantiatorGeneratorBase.IStringifier.Vector3(Vector3 value) => $"{{ {Float(value.X)}, {Float(value.Y)}, {Float(value.Z)} }}";

        public string Float(float value) =>
            Math.Floor(value) == value
                ? value.ToString("0")
                : value.ToString("0.######################################") + "F";

        static string Hex(int value) => $"0x{value.ToString("X2")}";

        string InstantiatorGeneratorBase.IStringifier.IListAdd => "Append";

        string InstantiatorGeneratorBase.IStringifier.FactoryCall(string value) => $"CanvasGeometryToIGeometrySource2D({value})";

        public string FailFastWrapper(string value) => $"FFHR({value})";

        public string GeoSourceClass =>
              @"class GeoSource :
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
";

    }
}
