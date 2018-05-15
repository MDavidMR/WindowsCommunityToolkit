using System;
using WinCompData.Mgcg;
using WinCompData.Sn;

namespace WinCompData.CodeGen
{
#if !WINDOWS_UWP
    public
#endif
    sealed class CxInstantiatorGenerator : InstantiatorGeneratorBase
    {
        readonly CppStringifier _stringifier;

        CxInstantiatorGenerator(CompositionObject graphRoot, bool setCommentProperties, CppStringifier stringifier)
            : base(graphRoot, setCommentProperties, stringifier)
        {
            _stringifier = stringifier;
        }

        /// <summary>
        /// Returns the Cx code for a factory that will instantiate the given <see cref="Visual"/> as a
        /// Windows.UI.Composition Visual.
        /// </summary>
        public static string CreateFactoryCode(
            string className,
            Visual rootVisual,
            float width,
            float height,
            CompositionPropertySet progressPropertySet,
            TimeSpan duration)
        {
            var generator = new CxInstantiatorGenerator(rootVisual, false, new CppStringifier());
            return generator.GenerateCode(className, rootVisual, width, height, progressPropertySet, duration);
        }

        protected override void WritePreamble(CodeBuilder builder, bool requiresD2d)
        {
            if (requiresD2d)
            {
                builder.WriteLine("#include \"pch.h\"");
                // D2D
                builder.WriteLine("#include \"d2d1.h\"");
                builder.WriteLine("#include <d2d1_1.h>");
                builder.WriteLine("#include <d2d1helper.h>");
                // floatY, floatYxZ
                builder.WriteLine("#include \"WindowsNumerics.h\"");
                // Interop
                builder.WriteLine("#include <Windows.Graphics.Interop.h>");
                builder.WriteLine("#include <windows.ui.composition.interop.h>");
                // Most likely bundle GeoSource.h as file incase multiple comps are used
                builder.WriteLine("#include \"GeoSource.h\"");
                // ComPtr
                builder.WriteLine("#include <wrl.h>");
            }
            builder.WriteLine();
            builder.WriteLine("using namespace Windows::Foundation;");
            builder.WriteLine("using namespace Windows::Foundation::Numerics;");
            builder.WriteLine("using namespace Windows::UI;");
            builder.WriteLine("using namespace Windows::UI::Composition;");
            builder.WriteLine("using namespace Windows::Graphics;");
            builder.WriteLine("using namespace Microsoft::WRL;");
        }

        protected override void WriteClassStart(
            CodeBuilder builder, 
            string className, 
            Vector2 size, 
            CompositionPropertySet progressPropertySet, 
            TimeSpan duration)
        {
            builder.WriteLine();
            builder.WriteLine("namespace Compositions");
            builder.OpenScope();
            builder.WriteLine($"ref class {className} sealed");
            builder.OpenScope();

            // Generate the method that creates an instance of the composition.
            builder.UnIndent();
            builder.WriteLine("public:");
            builder.Indent();
            builder.WriteLine("bool TryCreateInstance(");
            builder.Indent();
            builder.WriteLine("Compositor^ compositor,");
            builder.WriteLine("Visual^* rootVisual,");
            builder.WriteLine("float2* size,");
            builder.WriteLine("CompositionPropertySet^* progressPropertySet,");
            builder.WriteLine("TimeSpan* duration,");
            builder.WriteLine("Object^* diagnostics)");
            builder.UnIndent();
            builder.OpenScope();
            builder.WriteLine("*rootVisual = Instantiator::InstantiateComposition(compositor);");
            builder.WriteLine($"*size = {Vector2(size)};");
            builder.WriteLine("*progressPropertySet = (*rootVisual)->Properties;");
            builder.WriteLine($"duration->Duration = {_stringifier.TimeSpan(duration)};");
            builder.WriteLine("diagnostics = nullptr;");
            builder.WriteLine("return true;");
            builder.CloseScope();
            builder.WriteLine();

            // Write the instantiator.
            builder.UnIndent();
            builder.WriteLine("private:");
            builder.Indent();
            builder.WriteLine("class Instantiator sealed");
            builder.OpenScope();

            // D2D factory field.
            builder.WriteLine("ComPtr<ID2D1Factory> _d2dFactory;");
        }

        protected override void WriteClassEnd(CodeBuilder builder, Visual rootVisual, string reusableExpressionAnimationField)
        {
            // Utility method for path geometries
            builder.WriteLine("static IGeometrySource2D^ D2DPathGeometryToIGeometrySource2D(ComPtr<ID2D1PathGeometry> path)");
            builder.OpenScope();
            builder.WriteLine("ComPtr<GeoSource> geoSource = new GeoSource(path.Get());");
            builder.WriteLine("ComPtr<ABI::Windows::Graphics::IGeometrySource2D> interop = geoSource.Detach();");
            builder.WriteLine("return reinterpret_cast<IGeometrySource2D^>(interop.Get());");
            builder.CloseScope();
            builder.WriteLine();

            // Write the constructor for the instantiator.
            builder.WriteLine("Instantiator(Compositor^ compositor)");
            builder.OpenScope();
            builder.WriteLine("_c = compositor;");
            // Instantiate the reusable ExpressionAnimation.
            builder.WriteLine($"{reusableExpressionAnimationField} = _c->CreateExpressionAnimation();");
            builder.WriteLine("HRESULT hr = D2D1CreateFactory(D2D1_FACTORY_TYPE_SINGLE_THREADED, _d2dFactory.GetAddressOf());");
            builder.WriteLine("if (hr != S_OK)");
            builder.OpenScope();
            builder.WriteLine("throw ref new Platform::Exception(hr);");
            builder.CloseScope();
            builder.CloseScope();

            // Write the method that instantiates the composition.
            builder.WriteLine();
            builder.UnIndent();
            builder.WriteLine("public:");
            builder.Indent();
            builder.WriteLine("static Visual^ InstantiateComposition(Compositor^ compositor)");
            builder.OpenScope();
            builder.WriteLine($"return Instantiator(compositor).{CallFactoryFor(rootVisual)};");
            builder.CloseScope();

            // Close the scope for the instantiator class.
            builder.CloseClassScope();

            // Close the scope for the class.
            builder.CloseClassScope();

            // Close the scope for the namespace.
            builder.CloseScope();
        }

        protected override void WriteCanvasGeometryCombinationFactory(CodeBuilder builder, CanvasGeometry.Combination obj, string typeName, string fieldName)
        {
            builder.WriteLine(" -- TODO -- ");
        }

        protected override void WriteCanvasGeometryEllipseFactory(CodeBuilder builder, CanvasGeometry.Ellipse obj, string typeName, string fieldName)
        {
            builder.WriteLine(" -- TODO -- ");
        }

        protected override void WriteCanvasGeometryPathFactory(CodeBuilder builder, CanvasGeometry.Path obj, string typeName, string fieldName)
        {
            builder.WriteLine($"{typeName} result;");

            // D2D Setup
            builder.WriteLine("ComPtr<ID2D1PathGeometry> path;");
            builder.WriteLine("_d2dFactory->CreatePathGeometry(&path);");
            builder.WriteLine("ComPtr<ID2D1GeometrySink> sink;");
            builder.WriteLine("path->Open(&sink);");
            foreach (var command in obj.Commands)
            {
                switch (command.Type)
                {
                    case CanvasPathBuilder.CommandType.BeginFigure:
                        // Assume D2D1_FIGURE_BEGIN_FILLED
                        builder.WriteLine($"sink->BeginFigure({Vector2((Vector2)command.Args)}, D2D1_FIGURE_BEGIN_FILLED);");
                        break;
                    case CanvasPathBuilder.CommandType.EndFigure:
                        builder.WriteLine($"sink->EndFigure({CanvasFigureLoop((CanvasFigureLoop)command.Args)});");
                        break;
                    case CanvasPathBuilder.CommandType.AddCubicBezier:
                        var vectors = (Vector2[])command.Args;
                        builder.WriteLine($"sink->AddBezier({{{Vector2(vectors[0])}, {Vector2(vectors[1])}, {Vector2(vectors[2])}}});");
                        break;
                    case CanvasPathBuilder.CommandType.SetFilledRegionDetermination:
                        // TODO: Only applies to D2D Geometry group
                        //builder.WriteLine($"GeoSink->SetFilledRegionDetermination({FilledRegionDetermination((CanvasFilledRegionDetermination)command.Args)});");
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
            builder.WriteLine("sink->Close();");

            // Convert to IGeometrySource2D
            builder.WriteLine("result = D2DPathGeometryToIGeometrySource2D(path);");
        }

        protected override void WriteCanvasGeometryRoundedRectangleFactory(CodeBuilder builder, CanvasGeometry.RoundedRectangle obj, string typeName, string fieldName)
        {
            builder.WriteLine(" -- TODO -- ");
        }

        string CanvasFigureLoop(CanvasFigureLoop value) => _stringifier.CanvasFigureLoop(value);
        string FilledRegionDetermination(CanvasFilledRegionDetermination value) => _stringifier.FilledRegionDetermination(value);
        string Vector2(Vector2 value) => _stringifier.Vector2(value);
    }
}