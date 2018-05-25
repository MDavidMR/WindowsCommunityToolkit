using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using WinCompData;
using WinCompData.CodeGen;
using WinCompData.Mgcg;
using WinCompData.Sn;
using WinCompData.Tools;
using WinCompData.Wui;

namespace LottieTest
{

    // Generates a list of geometry paths. The paths can be used to help develop
    // optimizations for DWM.
    sealed class PathsGenerator : InstantiatorGeneratorBase
    {
        readonly List<string> _paths = new List<string>();
        readonly StringBuilder _sb = new StringBuilder();

        internal static string[] GeneratePaths(CompositionObject root)
        {
            // Get the CanvasGeometries that are not contained by other CanvasGeometries.
            var cgs = GetCanvasGeometries(root);

            var instance = new PathsGenerator(root);
            instance.GenerateCode("", (Visual)root, 0, 0, root.Properties, TimeSpan.Zero);
            return instance._paths.ToArray();
        }

        PathsGenerator(CompositionObject graphRoot) : base(graphRoot, setCommentProperties: false, stringifier: new Stringifier())
        {
        }

        // Returns the list of CanvasGeometry objects that are not referenced by any CanvasGeometry.
        static CanvasGeometry[] GetCanvasGeometries(CompositionObject root)
        {
            var result =
                from node in Graph.FromCompositionObject(root, true)
                // Filter to CanvasGeometry nodes.
                where node.Type == Graph.NodeType.CanvasGeometry
                // Filter to nodes that are not referenced by a CanvasGeometry.
                where !node.InReferences.Where(n => n.Type == Graph.NodeType.CanvasGeometry).Any()
                select (CanvasGeometry)node.Object;

            return result.ToArray();
        }

        protected override void WriteCanvasGeometryCombinationFactory(CodeBuilder builder, CanvasGeometry.Combination obj, string typeName, string fieldName)
        {
        }

        protected override void WriteCanvasGeometryEllipseFactory(CodeBuilder builder, CanvasGeometry.Ellipse obj, string typeName, string fieldName)
        {
        }

        protected override void WriteCanvasGeometryPathFactory(CodeBuilder builder, CanvasGeometry.Path obj, string typeName, string fieldName)
        {
            foreach (var command in obj.Commands)
            {
                switch (command.Type)
                {
                    case CanvasPathBuilder.CommandType.BeginFigure:
                        // Assume D2D1_FIGURE_BEGIN_FILLED
                        var startPoint = (Vector2)command.Args;
                        _sb.Append($"M{Vector2(startPoint)}");
                        break;
                    case CanvasPathBuilder.CommandType.EndFigure:
                        var loopType = (CanvasFigureLoop)command.Args;
                        if (loopType == CanvasFigureLoop.Closed)
                        {
                            _sb.Append("Z");
                        }
                        _paths.Add(_sb.ToString());
                        _sb.Clear();
                        break;
                    case CanvasPathBuilder.CommandType.AddLine:
                        var endPoint = ((Vector2[])command.Args)[0];
                        _sb.Append($" L{Vector2(endPoint)}");
                        break;
                    case CanvasPathBuilder.CommandType.AddCubicBezier:
                        var vectors = (Vector2[])command.Args;
                        _sb.Append($"C{Vector2(vectors[0])} {Vector2(vectors[1])} {Vector2(vectors[2])}");
                        break;
                    case CanvasPathBuilder.CommandType.SetFilledRegionDetermination:
                        Debug.Assert(_sb.Length == 0);
                        var filledRegionDetermination = (CanvasFilledRegionDetermination)command.Args;
                        switch (filledRegionDetermination)
                        {
                            case CanvasFilledRegionDetermination.Alternate:
                                // F0 is assumed)
                                //_sb.Append("F0");
                                break;
                            case CanvasFilledRegionDetermination.Winding:
                                _sb.Append("F1 ");
                                break;
                            default:
                                throw new InvalidOperationException();
                        }
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
        }

        static string Vector2(Vector2 value) => value.Y < 0 ? $"{value.X}{value.Y}" : $"{value.X} {value.Y}";

        protected override void WriteCanvasGeometryRoundedRectangleFactory(CodeBuilder builder, CanvasGeometry.RoundedRectangle obj, string typeName, string fieldName)
        {
        }

        protected override void WriteClassEnd(CodeBuilder builder, Visual rootVisual, string reusableExpressionAnimationField)
        {
        }

        protected override void WriteClassStart(CodeBuilder builder, string className, Vector2 size, CompositionPropertySet progressPropertySet, TimeSpan duration)
        {
        }

        protected override void WritePreamble(CodeBuilder builder, bool requiresWin2d)
        {
        }

        sealed class Stringifier : IStringifier
        {
            public string Deref => "";

            public string IListAdd => "";

            public string MemberSelect => "";

            public string New => "";

            public string Null => "";

            public string Readonly => "";

            public string ScopeResolve => "";

            public string Var => "";

            public string FactoryCall(string value) => "";

            public string Bool(bool value)
            {
                return "";
            }

            public string CanvasFigureLoop(CanvasFigureLoop value)
            {
                return "";
            }

            public string CanvasGeometryCombine(CanvasGeometryCombine value)
            {
                return "";
            }

            public string Color(Color value)
            {
                return "";
            }

            public string FilledRegionDetermination(CanvasFilledRegionDetermination value)
            {
                return "";
            }

            public string Float(float value)
            {
                return "";
            }

            public string Int(int value)
            {
                return "";
            }

            public string Matrix3x2(Matrix3x2 value)
            {
                return "";
            }

            public string ReferenceTypeName(string value)
            {
                return "";
            }

            public string String(string value)
            {
                return "";
            }

            public string TimeSpan(TimeSpan value)
            {
                return "";
            }

            public string Vector2(Vector2 value)
            {
                return "";
            }

            public string Vector3(Vector3 value)
            {
                return "";
            }
        }
    }
}
