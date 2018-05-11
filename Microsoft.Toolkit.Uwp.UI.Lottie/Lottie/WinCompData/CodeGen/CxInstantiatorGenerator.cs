using System;
using System.Collections.Generic;
using System.Linq;
using WinCompData.Mgcg;
using WinCompData.Sn;

namespace WinCompData.CodeGen
{
#if !WINDOWS_UWP
    public
#endif
    sealed class CxInstantiatorGenerator : InstantiatorGeneratorBase
    {

        CxInstantiatorGenerator(CompositionObject graphRoot, bool setCommentProperties) 
            : base(graphRoot, setCommentProperties, new CppStringifier())
        {
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
            var generator = new CxInstantiatorGenerator(rootVisual, false);
            return generator.GenerateCode(className, rootVisual, width, height, progressPropertySet, duration);
        }

        protected override void GenerateNamespaceUsings(CodeBuilder builder, bool requiresD2d)
        {
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

        new string GenerateCode(
            string className,
            Visual rootVisual,
            float width,
            float height,
            CompositionPropertySet progressPropertySet,
            TimeSpan duration)
        {
            var builder = new CodeBuilder();
            // TODO - keyframe animations should have their reference parameters set. Doesn't
            //        matter right now because we have no expression keyframes.

            // Generate #includes and usings for namespaces.
            var requiresWin2D = _canonicalNodes.Where(n => n.RequiresWin2D).Any();
            GenerateNamespaceUsings(builder, requiresWin2D);

            builder.WriteLine();
            builder.WriteLine("namespace Compositions");
            builder.OpenScope();
            builder.WriteLine($"class {className} sealed");
            builder.OpenScope();

            // Generate the method that creates an instance of the composition.
            builder.WriteLine("public:");
            builder.WriteLine("bool TryCreateInstance(");
            builder.Indent();
            builder.WriteLine("Compositor^ const compositor,");
            builder.WriteLine("Visual^& rootVisual,");
            builder.WriteLine("float2& size,");
            builder.WriteLine("CompositionPropertySet^& progressPropertySet,");
            builder.WriteLine("TimeSpan& duration)");
            builder.UnIndent();
            builder.OpenScope();
            builder.WriteLine("Instantiator comp(compositor);");
            builder.WriteLine($"rootVisual = comp{MemberSelect}GetRootContainerVisual();");
            builder.WriteLine($"size = {{{width}, {height}}};");
            builder.WriteLine($"progressPropertySet = rootVisual{Deref}Properties;");
            builder.WriteLine($"duration{MemberSelect}Duration = {TimeSpan(duration)};");
            builder.WriteLine("return true;");
            builder.CloseScope();
            builder.WriteLine();

            // Write the instantiator.
            builder.WriteLine("private:");
            builder.WriteLine("class Instantiator sealed");
            builder.OpenScope();
            builder.WriteLine("public:");

            // Write the constructor for the instantiator.
            builder.WriteLine("Instantiator::Instantiator(Compositor^ compositor)");
            builder.OpenScope();
            builder.WriteLine("_c = compositor;");
            builder.WriteLine($"{c_singletonExpressionAnimationName} = compositor{Deref}CreateExpressionAnimation();");
            builder.WriteLine("HRESULT hr = D2D1CreateFactory(D2D1_FACTORY_TYPE_SINGLE_THREADED, _d2dFactory.GetAddressOf());");
            builder.WriteLine("if (hr != S_OK)");
            builder.OpenScope();
            builder.WriteLine($"throw {New} Platform::Exception(hr);");
            builder.CloseScope();
            builder.CloseScope();
            builder.WriteLine();

            // Write Method to Generate Everything
            builder.WriteLine("ContainerVisual^ GetRootContainerVisual()");
            builder.OpenScope();
            builder.WriteLine("return ContainerVisual_0000();");
            builder.CloseScope();
            builder.WriteLine();

            // Write the rest of the private members
            builder.WriteLine("private:");
            builder.WriteLine("Compositor^ _c;");
            // D2D Factory global
            builder.WriteLine("ComPtr<ID2D1Factory> _d2dFactory;");
            builder.WriteLine($"ExpressionAnimation^ {c_singletonExpressionAnimationName};");

            // Write fields for each object that needs storage (i.e. objects that are 
            // referenced more than once).
            foreach (var node in _canonicalNodes)
            {
                if (node.RequiresStorage)
                {
                    // Generate a field for the storage.
                    builder.WriteLine($"{node.TypeName}^ {node.FieldName};");
                }
            }
            builder.WriteLine();

            // Utility method for path geometries
            builder.WriteLine("static IGeometrySource2D^ D2DPathGeometryToIGeometrySource2D(ComPtr<ID2D1PathGeometry> path)");
            builder.OpenScope();
            builder.WriteLine("ComPtr<GeoSource> geoSource = new GeoSource(path.Get());");
            builder.WriteLine("ComPtr<ABI::Windows::Graphics::IGeometrySource2D> interop = geoSource.Detach();");
            builder.WriteLine("return (reinterpret_cast<IGeometrySource2D^>(interop.Get()));");
            builder.CloseScope();
            builder.WriteLine();

            // Write methods for each node.
            foreach (var node in _canonicalNodes)
            {
                WriteCodeForNode(builder, node);
            }

            builder.CloseScopeClassDefinition();
            builder.CloseScopeClassDefinition();
            builder.CloseScope();

            return builder.ToString();
        }

        override protected void WriteObjectFactoryStart(CodeBuilder builder, ObjectData node, IEnumerable<string> parameters = null)
        {
            var typeName = node.TypeName;
            if (node.TypeName == "CanvasGeometry")
            {
                typeName = "IGeometrySource2D";
            }
            builder.WriteLine($"{typeName}^ {node.Name}({(parameters == null ? "" : string.Join(", ", parameters))})");
            builder.OpenScope();
        }

        override protected string CanvasFigureLoop(CanvasFigureLoop value)
        {
            switch (value)
            {
                case Mgcg.CanvasFigureLoop.Open:
                    return $"D2D1_FIGURE_END_OPEN";
                case Mgcg.CanvasFigureLoop.Closed:
                    return $"D2D1_FIGURE_END_CLOSED";
                default:
                    throw new InvalidOperationException();
            }
        }

        override protected string FilledRegionDetermination(CanvasFilledRegionDetermination value)
        {
            switch (value)
            {
                case CanvasFilledRegionDetermination.Alternate:
                    return $"D2D1_FILL_MODE_ALTERNATE";
                case CanvasFilledRegionDetermination.Winding:
                    return $"D2D1_FILL_MODE_WINDING";
                default:
                    throw new InvalidOperationException();
            }
        }

        override protected bool GenerateCanvasGeometryPathFactory(CodeBuilder builder, CanvasGeometry.Path obj, ObjectData node)
        {
            WriteObjectFactoryStart(builder, node);
            if (node.RequiresStorage)
            {
                WriteCacheHandler(builder, node);
            }
            // D2D Setup
            builder.WriteLine("ComPtr<ID2D1PathGeometry> path;");
            builder.WriteLine($"_d2dFactory{Deref}CreatePathGeometry(&path);");
            builder.WriteLine("ComPtr<ID2D1GeometrySink> sink;");
            builder.WriteLine($"path{Deref}Open(&sink);");
            foreach (var command in obj.Commands)
            {
                switch (command.Type)
                {
                    case CanvasPathBuilder.CommandType.BeginFigure:
                        // Assume D2D1_FIGURE_BEGIN_FILLED
                        builder.WriteLine($"sink{Deref}BeginFigure({Vector2Raw((Vector2)command.Args)}, D2D1_FIGURE_BEGIN_FILLED);");
                        break;
                    case CanvasPathBuilder.CommandType.EndFigure:
                        builder.WriteLine($"sink{Deref}EndFigure({CanvasFigureLoop((CanvasFigureLoop)command.Args)});");
                        break;
                    case CanvasPathBuilder.CommandType.AddCubicBezier:
                        var vectors = (Vector2[])command.Args;
                        builder.WriteLine($"sink{Deref}AddBezier({{{Vector2Raw(vectors[0])}, {Vector2Raw(vectors[1])}, {Vector2Raw(vectors[2])}}});");
                        break;
                    case CanvasPathBuilder.CommandType.SetFilledRegionDetermination:
                        // TODO: Only applies to D2D Geometry group
                        //builder.WriteLine($"GeoSink{Deref}SetFilledRegionDetermination({FilledRegionDetermination((CanvasFilledRegionDetermination)command.Args)});");
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
            builder.WriteLine($"sink{Deref}Close();");
            // Convert to IGeometrySource2D
            builder.WriteLine("return D2DPathGeometryToIGeometrySource2D(path);");

            builder.CloseScope();
            builder.WriteLine();
            return true;
        }

        override protected void InitializeKeyFrameAnimation(CodeBuilder builder, KeyFrameAnimation_ obj)
        {
            InitializeCompositionAnimation(builder, obj);
            builder.WriteLine($"result{Deref}Duration = TimeSpan{{{TimeSpan(obj.Duration)}}};");
        }

        string Vector2Raw(Vector2 value) => _stringifier.Vector2Raw(value);
        string MemberSelect => _stringifier.MemberSelect;

    }
}