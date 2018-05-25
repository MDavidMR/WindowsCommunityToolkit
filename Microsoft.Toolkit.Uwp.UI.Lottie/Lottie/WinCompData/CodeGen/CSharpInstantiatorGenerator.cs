using System;
using WinCompData.Sn;
using WinCompData.Wui;
using WinCompData.Mgcg;

namespace WinCompData.CodeGen
{
#if !WINDOWS_UWP
    public
#endif
    sealed class CSharpInstantiatorGenerator : InstantiatorGeneratorBase
    {
        readonly CSharpStringifier _stringifier;

        CSharpInstantiatorGenerator(CompositionObject graphRoot, bool setCommentProperties, CSharpStringifier stringifier)
            : base(graphRoot, setCommentProperties, stringifier)
        {
            _stringifier = stringifier;
        }

        /// <summary>
        /// Returns the C# code for a factory that will instantiate the given <see cref="Visual"/> as a
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
            var generator = new CSharpInstantiatorGenerator(rootVisual, setCommentProperties: false, stringifier: new CSharpStringifier());
            return generator.GenerateCode(className, rootVisual, width, height, progressPropertySet, duration);
        }

        protected override void WritePreamble(CodeBuilder builder, bool requiresWin2d)
        {
            builder.WriteLine("using Host = Lottie;");
            if (requiresWin2d)
            {
                builder.WriteLine("using Microsoft.Graphics.Canvas.Geometry;");
            }
            builder.WriteLine("using System;");
            builder.WriteLine("using System.Numerics;");
            builder.WriteLine("using Windows.Graphics;");
            builder.WriteLine("using Windows.UI;");
            builder.WriteLine("using Windows.UI.Composition;");
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
            builder.WriteLine($"sealed class {className} : Host.ICompositionSource");
            builder.OpenScope();

            // Generate the method that creates an instance of the composition.
            builder.WriteLine("public bool TryCreateInstance(");
            builder.Indent();
            builder.WriteLine("Compositor compositor,");
            builder.WriteLine("out Visual rootVisual,");
            builder.WriteLine("out Vector2 size,");
            builder.WriteLine("out CompositionPropertySet progressPropertySet,");
            builder.WriteLine("out TimeSpan duration,");
            builder.WriteLine("out object diagnostics)");
            builder.UnIndent();
            builder.OpenScope();
            builder.WriteLine("rootVisual = Instantiator.InstantiateComposition(compositor);");
            builder.WriteLine($"size = {Vector2(size)};");
            builder.WriteLine("progressPropertySet = rootVisual.Properties;");
            builder.WriteLine($"duration = {_stringifier.TimeSpan(duration)};");
            builder.WriteLine("diagnostics = null;");
            builder.WriteLine("return true;");
            builder.CloseScope();
            builder.WriteLine();

            // Write the instantiator.
            builder.WriteLine("sealed class Instantiator");
            builder.OpenScope();
        }

        protected override void WriteClassEnd(CodeBuilder builder, Visual rootVisual, string reusableExpressionAnimationField)
        {
            // Write the constructor for the instantiator.
            builder.WriteLine("Instantiator(Compositor compositor)");
            builder.OpenScope();
            builder.WriteLine("_c = compositor;");
            builder.WriteLine($"{reusableExpressionAnimationField} = compositor.CreateExpressionAnimation();");
            builder.CloseScope();
            builder.WriteLine();

            // Generate the code for the root method.
            builder.WriteLine("public static Visual InstantiateComposition(Compositor compositor)");
            builder.Indent();
            builder.WriteLine($"=> new Instantiator(compositor).{CallFactoryFor(rootVisual)};");
            builder.UnIndent();

            // Close the scope for the instantiator class.
            builder.CloseScope();

            // Close the scope for the class.
            builder.CloseScope();

            // Close the scope for the namespace
            builder.CloseScope();
        }

        protected override void WriteCanvasGeometryCombinationFactory(CodeBuilder builder, CanvasGeometry.Combination obj, string typeName, string fieldName)
        {
            builder.WriteLine($"var result = {(fieldName != null ? $" {fieldName} = " : "")}{CallFactoryFor(obj.A)}.");
            builder.Indent();
            builder.WriteLine($"CombineWith({CallFactoryFor(obj.B)},");
            if (obj.Matrix.IsIdentity)
            {
                builder.WriteLine("Matrix3x2.Identity,");
            }
            else
            {
                builder.WriteLine($"{_stringifier.Matrix3x2(obj.Matrix)},");
            }
            builder.WriteLine($"{_stringifier.CanvasGeometryCombine(obj.CombineMode)});");
            builder.UnIndent();
        }

        protected override void WriteCanvasGeometryEllipseFactory(CodeBuilder builder, CanvasGeometry.Ellipse obj, string typeName, string fieldName)
        {
            builder.WriteLine($"var result = {(fieldName != null ? $" {fieldName} " : "")}CanvasGeometry.CreateEllipse(");
            builder.Indent();
            builder.WriteLine($"null,");
            builder.WriteLine($"{Float(obj.X)},");
            builder.WriteLine($"{Float(obj.Y)},");
            builder.WriteLine($"{Float(obj.RadiusX)},");
            builder.WriteLine($"{Float(obj.RadiusY)};");
            builder.UnIndent();
        }

        protected override void WriteCanvasGeometryPathFactory(CodeBuilder builder, CanvasGeometry.Path obj, string typeName, string fieldName)
        {
            builder.WriteLine($"{typeName} result;");
            builder.WriteLine($"using (var builder = new CanvasPathBuilder(null))");
            builder.OpenScope();
            foreach (var command in obj.Commands)
            {
                switch (command.Type)
                {
                    case CanvasPathBuilder.CommandType.BeginFigure:
                        builder.WriteLine($"builder.BeginFigure({Vector2((Vector2)command.Args)});");
                        break;
                    case CanvasPathBuilder.CommandType.EndFigure:
                        builder.WriteLine($"builder.EndFigure({_stringifier.CanvasFigureLoop((CanvasFigureLoop)command.Args)});");
                        break;
                    case CanvasPathBuilder.CommandType.AddLine:
                        var endPoint = ((Vector2[])command.Args)[0];
                        builder.WriteLine($"builder.AddLine({Vector2(endPoint)});");
                        break;
                    case CanvasPathBuilder.CommandType.AddCubicBezier:
                        var vectors = (Vector2[])command.Args;
                        builder.WriteLine($"builder.AddCubicBezier({Vector2(vectors[0])}, {Vector2(vectors[1])}, {Vector2(vectors[2])});");
                        break;
                    case CanvasPathBuilder.CommandType.SetFilledRegionDetermination:
                        builder.WriteLine($"builder.SetFilledRegionDetermination({_stringifier.FilledRegionDetermination((CanvasFilledRegionDetermination)command.Args)});");
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
            builder.WriteLine($"result = {(fieldName != null ? $" {fieldName} = " : "")}CanvasGeometry.CreatePath(builder);");
            builder.CloseScope();
        }

        protected override void WriteCanvasGeometryRoundedRectangleFactory(CodeBuilder builder, CanvasGeometry.RoundedRectangle obj, string typeName, string fieldName)
        {
            builder.WriteLine($"var result = {(fieldName != null ? $" {fieldName} " : "")}CanvasGeometry.CreateRoundedRectangle(");
            builder.Indent();
            builder.WriteLine("null,");
            builder.WriteLine($"{Float(obj.X)},");
            builder.WriteLine($"{Float(obj.Y)},");
            builder.WriteLine($"{Float(obj.W)},");
            builder.WriteLine($"{Float(obj.H)},");
            builder.WriteLine($"{Float(obj.RadiusX)},");
            builder.WriteLine($"{Float(obj.RadiusY)};");
            builder.UnIndent();
        }

        string Float(float value) => _stringifier.Float(value);

        string Vector2(Vector2 value) => _stringifier.Vector2(value);

        sealed class CSharpStringifier : IStringifier
        {
            string IStringifier.Deref => ".";

            string IStringifier.MemberSelect => ".";

            string IStringifier.ScopeResolve => ".";

            string IStringifier.Var => "var";

            string IStringifier.New => "new";

            string IStringifier.Null => "null";

            string IStringifier.IListAdd => "Add";

            string IStringifier.FactoryCall(string value) => value;

            string IStringifier.Bool(bool value) => value ? "true" : "false";

            public string CanvasFigureLoop(CanvasFigureLoop value)
            {
                switch (value)
                {
                    case Mgcg.CanvasFigureLoop.Open:
                        return "CanvasFigureLoop.Open";
                    case Mgcg.CanvasFigureLoop.Closed:
                        return "CanvasFigureLoop.Closed";
                    default:
                        throw new InvalidOperationException();
                }
            }

            public string CanvasGeometryCombine(CanvasGeometryCombine value)
            {
                switch (value)
                {
                    case Mgcg.CanvasGeometryCombine.Union:
                        return "CanvasGeometryCombine.Union";
                    case Mgcg.CanvasGeometryCombine.Exclude:
                        return "CanvasGeometryCombine.Exclude";
                    case Mgcg.CanvasGeometryCombine.Intersect:
                        return "CanvasGeometryCombine.Intersect";
                    case Mgcg.CanvasGeometryCombine.Xor:
                        return "CanvasGeometryCombine.Xor";
                    default:
                        throw new InvalidOperationException();
                }
            }

            string IStringifier.Color(Color value) => $"Color.FromArgb({Hex(value.A)}, {Hex(value.R)}, {Hex(value.G)}, {Hex(value.B)})";

            public string FilledRegionDetermination(CanvasFilledRegionDetermination value)
            {
                switch (value)
                {
                    case CanvasFilledRegionDetermination.Alternate:
                        return "CanvasFilledRegionDetermination.Alternate";
                    case CanvasFilledRegionDetermination.Winding:
                        return "CanvasFilledRegionDetermination.Winding";
                    default:
                        throw new InvalidOperationException();
                }
            }

            string IStringifier.Float(float value) => Float(value);

            string IStringifier.Int(int value) => value.ToString();

            public string Matrix3x2(Matrix3x2 value)
            {
                return $"new Matrix3x2({Float(value.M11)}, {Float(value.M12)}, {Float(value.M21)}, {Float(value.M22)}, {Float(value.M31)}, {Float(value.M32)})";
            }

            string IStringifier.Readonly => "readonly";

            string IStringifier.ReferenceTypeName(string value) => value;

            public string ReferenceTypeName(string value) => value;

            string IStringifier.String(string value) => $"\"{value}\"";


            public string TimeSpan(TimeSpan value) => $"TimeSpan.FromTicks({value.Ticks})";

            public string Vector2(Vector2 value) => $"new Vector2({ Float(value.X) }, { Float(value.Y)})";

            string IStringifier.Vector3(Vector3 value) => $"new Vector3({ Float(value.X) }, { Float(value.Y)}, {Float(value.Z)})";

            public string Float(float value) => 
                Math.Floor(value) == value 
                    ? value.ToString("0") 
                    : value.ToString("0.######################################") + "F";
                
            static string Hex(int value) => $"0x{value.ToString("X2")}";
        }
    }

}