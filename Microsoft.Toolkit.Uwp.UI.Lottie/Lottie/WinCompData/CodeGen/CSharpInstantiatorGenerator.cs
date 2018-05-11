using System;
using WinCompData.Sn;
using WinCompData.Wui;

namespace WinCompData.CodeGen
{
#if !WINDOWS_UWP
    public
#endif
    sealed class CSharpInstantiatorGenerator : InstantiatorGeneratorBase
    {
        CSharpInstantiatorGenerator(CompositionObject graphRoot, bool setCommentProperties)
            : base(graphRoot, setCommentProperties, new CSharpStringifier())
        {
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
            var generator = new CSharpInstantiatorGenerator(rootVisual, setCommentProperties: false);
            return generator.GenerateCode(className, rootVisual, width, height, progressPropertySet, duration);
        }

        protected override void GenerateNamespaceUsings(CodeBuilder builder, bool requiresWin2d)
        {
            if (requiresWin2d)
            {
                builder.WriteLine("using Microsoft.Graphics.Canvas.Geometry;");
            }
            builder.WriteLine("using System;");
            builder.WriteLine("using System.Numerics;");
            builder.WriteLine("using Windows.UI;");
            builder.WriteLine("using Windows.UI.Composition;");
            builder.WriteLine("using Windows.UI.Xaml;");
        }

        protected override void WriteICompositionSourceImplementation(CodeBuilder builder)
        {
            builder.WriteLine();
            builder.UnIndent();
            builder.UnIndent();
            builder.WriteLine("#region ICompositionSource");
            builder.Indent();
            builder.Indent();
            // Generate the ICompositionSource interface.
            builder.WriteLine("void Lottie.ICompositionSource.ConnectSink(Lottie.ICompositionSink sink)");
            builder.OpenScope();
            builder.WriteLine("CreateInstance(");
            builder.Indent();
            builder.WriteLine($"Window.Current.Compositor,");
            builder.WriteLine("out var rootVisual,");
            builder.WriteLine("out var size,");
            builder.WriteLine("out var progressPropertySet,");
            builder.WriteLine("out var duration);");
            builder.UnIndent();
            builder.WriteLine();
            builder.WriteLine($"sink.SetContent(");
            builder.Indent();
            builder.WriteLine("rootVisual,");
            builder.WriteLine("size,");
            builder.WriteLine("progressPropertySet,");
            builder.WriteLine("duration,");
            builder.WriteLine("null);");
            builder.UnIndent();
            builder.CloseScope();
            builder.WriteLine();
            builder.WriteLine("void Lottie.ICompositionSource.DisconnectSink(Lottie.ICompositionSink sink) { }");
            builder.UnIndent();
            builder.UnIndent();
            builder.WriteLine("#endregion // ICompositionSource");
            builder.Indent();
            builder.Indent();
            builder.WriteLine();
        }

        sealed class CSharpStringifier : IStringifier
        {
            string IStringifier.Deref => ".";

            string IStringifier.MemberSelect => ".";

            string IStringifier.ScopeResolve => ".";

            string IStringifier.Var => "var";

            string IStringifier.New => "new";

            string IStringifier.Null => "null";

            string IStringifier.Bool(bool value) => value ? "true" : "false";

            string IStringifier.Color(Color value) => $"Color.FromArgb({Hex(value.A)}, {Hex(value.R)}, {Hex(value.G)}, {Hex(value.B)})";

            string IStringifier.Float(float value) => Float(value);

            string IStringifier.Int(int value) => value.ToString();

            string IStringifier.Matrix3x2(Matrix3x2 value)
            {
                return $"new Matrix3x2({Float(value.M11)}, {Float(value.M12)},{Float(value.M21)}, {Float(value.M22)}, {Float(value.M31)}, {Float(value.M32)})";
            }

            string IStringifier.String(string value) => $"\"{value}\"";


            string IStringifier.TimeSpan(TimeSpan value) => $"TimeSpan.FromTicks({value.Ticks})";

            string IStringifier.Vector2(Vector2 value) => $"new Vector2({ Float(value.X) }, { Float(value.Y)})";

            string IStringifier.Vector3(Vector3 value) => $"new Vector3({ Float(value.X) }, { Float(value.Y)}, {Float(value.Z)})";


            static string Float(float value)
            {
                if (Math.Floor(value) == value)
                {
                    // Round numbers don't need decimal places or the F suffix.
                    return value.ToString("0");
                }
                else
                {
                    return value == 0 ? "0" : (value.ToString("0.######################################") + "F");
                }
            }

            static string Hex(int value) => $"0x{value.ToString("X2")}";
        }
    }

}