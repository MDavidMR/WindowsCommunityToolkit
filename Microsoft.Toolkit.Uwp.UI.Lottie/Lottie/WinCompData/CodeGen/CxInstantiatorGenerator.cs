// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

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

        CxInstantiatorGenerator(CompositionObject graphRoot, TimeSpan duration, bool setCommentProperties, CppStringifier stringifier)
            : base(graphRoot, duration, setCommentProperties, stringifier)
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
            var generator = new CxInstantiatorGenerator(rootVisual, duration, false, new CppStringifier());
            return generator.GenerateCode(className, rootVisual, width, height, progressPropertySet);
        }

        protected override void WritePreamble(CodeBuilder builder, bool requiresD2d)
        {
            builder.WriteLine("#include \"pch.h\"");
            builder.WriteLine("#include \"ICompositionSource.h\"");
            if (requiresD2d)
            {
                // D2D
                builder.WriteLine("#include \"d2d1.h\"");
                builder.WriteLine("#include <d2d1_1.h>");
                builder.WriteLine("#include <d2d1helper.h>");
                // floatY, floatYxZ
                builder.WriteLine("#include \"WindowsNumerics.h\"");
                // Interop
                builder.WriteLine("#include <Windows.Graphics.Interop.h>");
                builder.WriteLine("#include <windows.ui.composition.interop.h>");
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
            builder.WriteLine($"ref class {className} sealed : public ICompositionSource");
            builder.OpenScope();

            // Generate the method that creates an instance of the composition.
            builder.UnIndent();
            builder.WriteLine("public:");
            builder.Indent();
            builder.WriteLine("virtual bool TryCreateInstance(");
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

            builder.UnIndent();
            builder.WriteLine("private:");
            builder.Indent();

            // Write GeoSource to allow it's use in function definitions
            builder.WriteLine($"{_stringifier.GeoSourceClass}");

            // Typedef to simplify generation
            builder.WriteLine("typedef ComPtr<GeoSource> CanvasGeometry;");

            // Write the instantiator.
            builder.WriteLine("class Instantiator sealed");
            builder.OpenScope();

            // D2D factory field.
            builder.WriteLine("ComPtr<ID2D1Factory> _d2dFactory;");
        }

        protected override void WriteClassEnd(CodeBuilder builder, Visual rootVisual, string reusableExpressionAnimationField)
        {
            // Utility method for D2D geometries
            builder.WriteLine("static IGeometrySource2D^ CanvasGeometryToIGeometrySource2D(CanvasGeometry geo)");
            builder.OpenScope();
            builder.WriteLine("ComPtr<ABI::Windows::Graphics::IGeometrySource2D> interop = geo.Detach();");
            builder.WriteLine("return reinterpret_cast<IGeometrySource2D^>(interop.Get());");
            builder.CloseScope();
            builder.WriteLine();

            // Utility method for fail-fasting on bad HRESULTs from d2d operations
            builder.WriteLine("static void FFHR(HRESULT hr)");
            builder.OpenScope();
            builder.WriteLine("if (hr != S_OK)");
            builder.OpenScope();
            builder.WriteLine("RoFailFastWithErrorContext(hr);");
            builder.CloseScope();
            builder.CloseScope();
            builder.WriteLine();

            // Write the constructor for the instantiator.
            builder.WriteLine("Instantiator(Compositor^ compositor)");
            builder.OpenScope();
            builder.WriteLine("_c = compositor;");
            // Instantiate the reusable ExpressionAnimation.
            builder.WriteLine($"{reusableExpressionAnimationField} = _c->CreateExpressionAnimation();");
            builder.WriteLine($"{FailFastWrapper("D2D1CreateFactory(D2D1_FACTORY_TYPE_SINGLE_THREADED, _d2dFactory.GetAddressOf())")};");
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
            builder.WriteLine();

            // Close the scope for the instantiator class.
            builder.CloseClassScope();

            // Close the scope for the class.
            builder.CloseClassScope();

            // Close the scope for the namespace.
            builder.CloseScope();
        }

        protected override void WriteCanvasGeometryCombinationFactory(CodeBuilder builder, CanvasGeometry.Combination obj, string typeName, string fieldName)
        {
            builder.WriteLine($"{typeName} result;");
            builder.WriteLine("ID2D1Geometry **geoA = new ID2D1Geometry*, **geoB = new ID2D1Geometry*;");
            builder.WriteLine($"{CallFactoryFor(obj.A)}->GetGeometry(geoA);");
            builder.WriteLine($"{CallFactoryFor(obj.B)}->GetGeometry(geoB);");
            builder.WriteLine("ComPtr<ID2D1PathGeometry> path;");
            builder.WriteLine($"{FailFastWrapper("_d2dFactory->CreatePathGeometry(&path)")};");
            builder.WriteLine("ComPtr<ID2D1GeometrySink> sink;");
            builder.WriteLine($"{FailFastWrapper("path->Open(&sink)")};");
            builder.WriteLine($"FFHR((*geoA)->CombineWithGeometry(");
            builder.Indent();
            builder.WriteLine($"*geoB,");
            builder.WriteLine($"{_stringifier.CanvasGeometryCombine(obj.CombineMode)},");
            builder.WriteLine($"{_stringifier.Matrix3x2(obj.Matrix)},");
            builder.WriteLine($"sink.Get()));");
            builder.UnIndent();
            builder.WriteLine($"{FailFastWrapper("sink->Close()")};");
            builder.WriteLine($"result = {FieldAssignment(fieldName)}new GeoSource(path.Get());");
        }

        protected override void WriteCanvasGeometryEllipseFactory(CodeBuilder builder, CanvasGeometry.Ellipse obj, string typeName, string fieldName)
        {
            builder.WriteLine($"{typeName} result;");
            builder.WriteLine("ComPtr<ID2D1EllipseGeometry> ellipse;");
            builder.WriteLine("FFHR(_d2dFactory->CreateEllipseGeometry(");
            builder.Indent();
            builder.WriteLine($"D2D1::Ellipse({{{Float(obj.X)},{Float(obj.Y)}}}, {Float(obj.RadiusX)}, {Float(obj.RadiusY)}),");
            builder.WriteLine("&ellipse));");
            builder.UnIndent();
            builder.CloseScope();
            builder.WriteLine($"result = {FieldAssignment(fieldName)}new GeoSource(ellipse.Get());");
        }

        protected override void WriteCanvasGeometryPathFactory(CodeBuilder builder, CanvasGeometry.Path obj, string typeName, string fieldName)
        {
            builder.WriteLine($"{typeName} result;");

            // D2D Setup
            builder.WriteLine("ComPtr<ID2D1PathGeometry> path;");
            builder.WriteLine($"{FailFastWrapper("_d2dFactory->CreatePathGeometry(&path)")};");
            builder.WriteLine("ComPtr<ID2D1GeometrySink> sink;");
            builder.WriteLine($"{FailFastWrapper("path->Open(&sink)")};");
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
                    case CanvasPathBuilder.CommandType.AddLine:
                        var endPoint = ((Vector2[])command.Args)[0];
                        builder.WriteLine($"sink->AddLine({Vector2(endPoint)});");
                        break;
                    case CanvasPathBuilder.CommandType.AddCubicBezier:
                        var vectors = (Vector2[])command.Args;
                        builder.WriteLine($"sink->AddBezier({{ {Vector2(vectors[0])}, {Vector2(vectors[1])}, {Vector2(vectors[2])} }});");
                        break;
                    case CanvasPathBuilder.CommandType.SetFilledRegionDetermination:
                        builder.WriteLine($"sink->SetFillMode({FilledRegionDetermination((CanvasFilledRegionDetermination)command.Args)});");
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
            builder.WriteLine($"{FailFastWrapper("sink->Close()")};");
            builder.WriteLine($"result = {FieldAssignment(fieldName)}new GeoSource(path.Get());");
        }

        protected override void WriteCanvasGeometryRoundedRectangleFactory(CodeBuilder builder, CanvasGeometry.RoundedRectangle obj, string typeName, string fieldName)
        {
            builder.WriteLine($"{typeName} result;");
            builder.WriteLine("ComPtr<ID2D1RoundedRectangleGeometry> rect;");
            builder.WriteLine("FFHR(_d2dFactory->CreateRoundedRectangleGeometry(");
            builder.Indent();
            builder.WriteLine($"D2D1::RoundedRect({{{Float(obj.X)},{Float(obj.Y)}}}, {Float(obj.RadiusX)}, {Float(obj.RadiusY)}),");
            builder.WriteLine("&rect));");
            builder.UnIndent();
            builder.WriteLine($"result = {FieldAssignment(fieldName)}new GeoSource(rect.Get());");
        }

        string CanvasFigureLoop(CanvasFigureLoop value) => _stringifier.CanvasFigureLoop(value);
        static string FieldAssignment(string fieldName) => (fieldName != null ? $"{fieldName} = " : "");
        string FilledRegionDetermination(CanvasFilledRegionDetermination value) => _stringifier.FilledRegionDetermination(value);
        string Float(float value) => _stringifier.Float(value);
        string FailFastWrapper(string value) => _stringifier.FailFastWrapper(value);
        string Vector2(Vector2 value) => _stringifier.Vector2(value);
    }
}
