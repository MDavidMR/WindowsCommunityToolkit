using System;
using System.Collections;
using System.Collections.Generic;

namespace WinCompData.Tools
{

#if !WINDOWS_UWP
    public
#endif
    abstract class Graph
    {
        internal Graph() { }

        public class Node : INodePrivate
        {
            List<Node> _inReferences;
            List<Node> _outReferences;

            public object Object;
            public Node[] InReferences => _inReferences == null ? null : _inReferences.ToArray();
            public Node[] OutReferences => _outReferences == null ? null : _outReferences.ToArray();

            public int ReferenceCount => InReferences.Length;

            public NodeType Type { get; private set; }

            List<Node> INodePrivate.InReferences
            {
                get
                {
                    if (_inReferences == null)
                    {
                        _inReferences = new List<Node>();
                    }
                    return _inReferences;
                }
            }

            List<Node> INodePrivate.OutReferences
            {
                get
                {
                    if (_outReferences == null)
                    {
                        _outReferences = new List<Node>();
                    }
                    return _outReferences;
                }
            }

            void INodePrivate.Initialize(NodeType type)
            {
                Type = type;
            }
        }

        public enum NodeType
        {
            CompositionObject,
            CompositionPath,
        }


        protected void InitializeNode(Node node, NodeType type)
            => NodePrivate(node).Initialize(type);

        protected void AddVertex(Node from, Node to)
        {
            var fromNode = NodePrivate(from);
            var toNode = NodePrivate(to);

            fromNode.OutReferences.Add(to);
            toNode.InReferences.Add(from);
        }

        static INodePrivate NodePrivate(Node node) => node;

        // Private inteface that allows ObjectGraph to modify Nodes.
        interface INodePrivate
        {
            void Initialize(NodeType type);
            List<Node> InReferences { get; }
            List<Node> OutReferences { get; }
        }
    }

#if !WINDOWS_UWP
    public
#endif
    sealed class ObjectGraph<T> : Graph, IEnumerable<T> where T : Graph.Node, new()
    {
        readonly bool _includeVertices;
        readonly Dictionary<object, T> _references = new Dictionary<object, T>();
        readonly Dictionary<CompositionObjectType, int> _compositionObjectCounter = new Dictionary<CompositionObjectType, int>();

        internal ObjectGraph(bool includeVertices)
        {
            _includeVertices = includeVertices;
        }

        internal static ObjectGraph<T> FromCompositionObject(CompositionObject root, bool includeVertices)
        {
            var result = new ObjectGraph<T>(includeVertices);
            result.Reference(null, root);
            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _references.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _references.Values.GetEnumerator();
        }

        internal T this[Object obj] => _references[obj];

        // The return value currently has no meaning. Having a return value makes it
        // possible to write the case statements as single statements rather than
        // a call then a break.
        bool Reference(T from, CompositionObject obj)
        {
            if (obj == null)
            {
                return true;
            }

            // Object has been seen before. Just add the reference.
            if (_references.TryGetValue(obj, out var node))
            {
                if (_includeVertices && from != null)
                {
                    AddVertex(from, node);
                }
                return true;
            }

            // Object has not been seen before. Count it, register it, and visit it.

            // Count the types.
            if (!_compositionObjectCounter.TryGetValue(obj.Type, out var counter))
            {
                _compositionObjectCounter.Add(obj.Type, 1);
            }
            else
            {
                _compositionObjectCounter[obj.Type] = counter + 1;
            }

            // Create a node for the object.
            node = new T
            {
                Object = obj,
            };

            InitializeNode(node, NodeType.CompositionObject);

            // Link the nodes in the graph.
            if (_includeVertices && from != null)
            {
                AddVertex(from, node);
            }
            _references.Add(obj, node);


            switch (obj.Type)
            {
                case CompositionObjectType.AnimationController:
                    return VisitAnimationController((AnimationController)obj, node);
                case CompositionObjectType.ColorKeyFrameAnimation:
                    return VisitColorKeyFrameAnimation((ColorKeyFrameAnimation)obj, node);
                case CompositionObjectType.CompositionColorBrush:
                    return VisitCompositionColorBrush((CompositionColorBrush)obj, node);
                case CompositionObjectType.CompositionContainerShape:
                    return VisitCompositionContainerShape((CompositionContainerShape)obj, node);
                case CompositionObjectType.CompositionEllipseGeometry:
                    return VisitCompositionEllipseGeometry((CompositionEllipseGeometry)obj, node);
                case CompositionObjectType.CompositionPathGeometry:
                    return VisitCompositionPathGeometry((CompositionPathGeometry)obj, node);
                case CompositionObjectType.CompositionPropertySet:
                    return VisitCompositionPropertySet((CompositionPropertySet)obj, node);
                case CompositionObjectType.CompositionRectangleGeometry:
                    return VisitCompositionRectangleGeometry((CompositionRectangleGeometry)obj, node);
                case CompositionObjectType.CompositionRoundedRectangleGeometry:
                    return VisitCompositionRoundedRectangleGeometry((CompositionRoundedRectangleGeometry)obj, node);
                case CompositionObjectType.CompositionSpriteShape:
                    return VisitCompositionSpriteShape((CompositionSpriteShape)obj, node);
                case CompositionObjectType.CompositionViewBox:
                    return VisitCompositionViewBox((CompositionViewBox)obj, node);
                case CompositionObjectType.ContainerVisual:
                    return VisitContainerVisual((ContainerVisual)obj, node);
                case CompositionObjectType.CubicBezierEasingFunction:
                    return VisitCubicBezierEasingFunction(node, (CubicBezierEasingFunction)obj);
                case CompositionObjectType.ExpressionAnimation:
                    return VisitExpressionAnimation((ExpressionAnimation)obj, node);
                case CompositionObjectType.InsetClip:
                    return VisitInsetClip((InsetClip)obj, node);
                case CompositionObjectType.LinearEasingFunction:
                    return VisitLinearEasingFunction((LinearEasingFunction)obj, node);
                case CompositionObjectType.PathKeyFrameAnimation:
                    return VisitPathKeyFrameAnimation((PathKeyFrameAnimation)obj, node);
                case CompositionObjectType.ScalarKeyFrameAnimation:
                    return VisitScalarKeyFrameAnimation((ScalarKeyFrameAnimation)obj, node);
                case CompositionObjectType.ShapeVisual:
                    return VisitShapeVisual((ShapeVisual)obj, node);
                case CompositionObjectType.StepEasingFunction:
                    return VisitStepEasingFunction((StepEasingFunction)obj, node);
                case CompositionObjectType.Vector2KeyFrameAnimation:
                    return VisitVector2KeyFrameAnimation((Vector2KeyFrameAnimation)obj, node);
                case CompositionObjectType.Vector3KeyFrameAnimation:
                    return VisitVector3KeyFrameAnimation((Vector3KeyFrameAnimation)obj, node);
                default:
                    throw new InvalidOperationException();
            }
        }

        bool VisitCompositionObject(CompositionObject obj, T node)
        {
            // Prevent infinite recursion on CompositionPropertySet (its Properties
            // refer back to itself).
            if (obj.Type != CompositionObjectType.CompositionPropertySet)
            {
                Reference(node, obj.Properties);
            }

            foreach (var animator in obj.Animators)
            {
                Reference(node, animator.Animation);
                Reference(node, animator.Controller);
            }
            return true;
        }

        bool VisitCompositionPropertySet(CompositionPropertySet obj, T node)
        {
            return VisitCompositionObject(obj, node);
        }

        bool VisitCompositionRectangleGeometry(CompositionRectangleGeometry obj, T node)
        {
            return VisitCompositionGeometry(obj, node);
        }

        bool VisitCompositionRoundedRectangleGeometry(CompositionRoundedRectangleGeometry obj, T node)
        {
            return VisitCompositionGeometry(obj, node);
        }

        bool VisitExpressionAnimation(ExpressionAnimation obj, T node)
        {
            return VisitCompositionAnimation(obj, node);
        }

        bool VisitCompositionClip(CompositionClip obj, T node)
        {
            return VisitCompositionObject(obj, node);
        }

        bool VisitInsetClip(InsetClip obj, T node)
        {
            return VisitCompositionClip(obj, node);
        }
        bool VisitAnimationController(AnimationController obj, T node)
        {
            VisitCompositionObject(obj, node);
            Reference(node, obj.TargetObject);
            return true;
        }

        bool VisitCompositionEasingFunction(CompositionEasingFunction obj, T node)
        {
            return VisitCompositionObject(obj, node);
        }

        bool VisitCubicBezierEasingFunction(T node, CubicBezierEasingFunction obj)
        {
            return VisitCompositionEasingFunction(obj, node);
        }

        bool VisitLinearEasingFunction(LinearEasingFunction obj, T node)
        {
            return VisitCompositionEasingFunction(obj, node);
        }

        bool VisitPathKeyFrameAnimation(PathKeyFrameAnimation obj, T node)
        {
            VisitKeyFrameAnimation(obj, node);
            foreach (var keyFrame in obj.KeyFrames)
            {
                Reference(node, keyFrame.Value);
            }
            return true;
        }

        bool VisitCompositionAnimation(CompositionAnimation obj, T node)
        {
            VisitCompositionObject(obj, node);
            foreach (var parameter in obj.ReferenceParameters)
            {
                Reference(node, parameter.Value);
            }

            return true;
        }

        bool VisitKeyFrameAnimation<V>(KeyFrameAnimation<V> obj, T node)
        {
            VisitCompositionAnimation(obj, node);
            foreach (var keyFrame in obj.KeyFrames)
            {
                Reference(node, keyFrame.Easing);
            }

            return true;
        }

        bool VisitScalarKeyFrameAnimation(ScalarKeyFrameAnimation obj, T node)
        {
            return VisitKeyFrameAnimation(obj, node);
        }

        bool VisitCompositionShape(CompositionShape obj, T node)
        {
            return VisitCompositionObject(obj, node);
        }

        bool VisitCompositionSpriteShape(CompositionSpriteShape obj, T node)
        {
            VisitCompositionShape(obj, node);
            Reference(node, obj.FillBrush);
            Reference(node, obj.Geometry);
            Reference(node, obj.StrokeBrush);
            return true;
        }

        bool VisitCompositionViewBox(CompositionViewBox obj, T node)
        {
            return VisitCompositionObject(obj, node);
        }

        bool VisitCompositionGeometry(CompositionGeometry obj, T node)
        {
            return VisitCompositionObject(obj, node);
        }

        bool VisitCompositionEllipseGeometry(CompositionEllipseGeometry obj, T node)
        {
            return VisitCompositionGeometry(obj, node);
        }

        bool Reference(T from, CompositionPath obj)
        {
            if (_references.TryGetValue(obj, out var node))
            {
                AddVertex(from, node);
                return true;
            }
            else
            {
                node = new T
                {
                    Object = obj,
                };
                InitializeNode(node, NodeType.CompositionPath);
                AddVertex(from, node);
                _references.Add(obj, node);
            }

            return true;
        }

        bool VisitCompositionPathGeometry(CompositionPathGeometry obj, T node)
        {
            VisitCompositionGeometry(obj, node);
            Reference(node, obj.Path);
            return true;
        }

        bool VisitCompositionBrush(CompositionBrush obj, T node)
        {
            return VisitCompositionObject(obj, node);
        }

        bool VisitColorKeyFrameAnimation(ColorKeyFrameAnimation obj, T node)
        {
            return VisitKeyFrameAnimation(obj, node);
        }

        bool VisitCompositionColorBrush(CompositionColorBrush obj, T node)
        {
            return VisitCompositionBrush(obj, node);
        }

        bool VisitCompositionContainerShape(CompositionContainerShape obj, T node)
        {
            VisitCompositionShape(obj, node);
            foreach (var shape in obj.Shapes)
            {
                Reference(node, shape);
            }
            return true;
        }

        bool VisitVisual(Visual obj, T node)
        {
            VisitCompositionObject(obj, node);
            Reference(node, obj.Clip);
            return true;
        }

        bool VisitShapeVisual(ShapeVisual obj, T node)
        {
            VisitVisual(obj, node);
            Reference(node, obj.ViewBox);
            foreach (var shape in obj.Shapes)
            {
                Reference(node, shape);
            }
            return true;
        }

        bool VisitStepEasingFunction(StepEasingFunction obj, T node)
        {
            return VisitCompositionEasingFunction(obj, node);
        }

        bool VisitVector2KeyFrameAnimation(Vector2KeyFrameAnimation obj, T node)
        {
            return VisitKeyFrameAnimation(obj, node);
        }

        bool VisitVector3KeyFrameAnimation(Vector3KeyFrameAnimation obj, T node)
        {
            return VisitKeyFrameAnimation(obj, node);
        }

        bool VisitContainerVisual(ContainerVisual obj, T node)
        {
            VisitVisual(obj, node);
            foreach (var child in obj.Children)
            {
                Reference(node, child);
            }
            return true;
        }
    }
}
