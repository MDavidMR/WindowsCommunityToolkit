// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

// Use the simple algorithm for combining trim paths. We're not sure of the correct semantics
// for multiple trim paths, so it's possible this is actually the most correct.
#define SimpleTrimPathCombining
#define SpatialBeziers
//#define LinearEasingOnSpatialBeziers
// Use Win2D to create paths from geometry combines when merging shape layers.
//#define PreCombineGeometries
#if DEBUG
// For diagnosing issues, give nothing a clip.
//#define NoClipping
// For diagnosing issues, give nothing scale.
//#define NoScaling
// For diagnosing issues, do not control visibility.
//#define NoInvisibility
// For diagnosing issues, do not inherit transforms.
//#define NoTransformInheritance
#endif
using LottieData;
using LottieData.Optimization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WinCompData;
using Expr = WinCompData.Expressions.Expression;
using CubicBezierFunction = WinCompData.Expressions.CubicBezierFunction;
using TypeConstraint = WinCompData.Expressions.TypeConstraint;
using ExpressionType = WinCompData.Expressions.ExpressionType;
using WinCompData.Mgcg;

namespace LottieToWinComp
{
    /// <summary>
    /// Translates a <see cref="LottieData.LottieComposition"/> to an equivalent <see cref="Visual"/>.
    /// </summary>
#if PUBLIC
    public
#endif
    sealed class LottieToWinCompTranslator : IDisposable
    {
        // Very small animation progress increment used to place keyframes as close as possible
        // to each other.
        const float c_keyFrameProgressEpsilon = 0.0000001F;
        readonly LottieComposition _lc;
        readonly TranslationIssues _unsupported;
        readonly bool _addDescriptions;
        readonly Compositor _c;
        readonly ContainerVisual _rootVisual;
        readonly Dictionary<ScaleAndOffset, ExpressionAnimation> _progressBindingAnimations = new Dictionary<ScaleAndOffset, ExpressionAnimation>();
        readonly Optimizer _lottieDataOptimizer = new Optimizer();
        // Holds CubicBezierEasingFunctions for reuse when they have the same parameters.
        readonly Dictionary<CubicBezierEasing, CubicBezierEasingFunction> _cubicBezierEasingFunctions = new Dictionary<CubicBezierEasing, CubicBezierEasingFunction>();
        // Holds ColorBrushes that are not animated and can therefore be reused.
        readonly Dictionary<Color, CompositionColorBrush> _nonAnimatedColorBrushes = new Dictionary<Color, CompositionColorBrush>();
        // Holds a LinearEasingFunction that can be reused in multiple animations.
        LinearEasingFunction _linearEasingFunction;
        // Holds a StepEasingFunction that can be reused in multiple animations.
        StepEasingFunction _holdStepEasingFunction;
        // Holds a StepEasingFunction that can be reused in multiple animations.
        StepEasingFunction _jumpStepEasingFunction;
        // The name used to bind to the property set that contains the Progress property.
        const string c_rootName = "_";

        /// <summary>
        /// The name of the property on the resulting <see cref="Visual"/> that controls the progress
        /// of the animation. Setting this property (directly or with an animation)
        /// between 0 and 1 controls the position of the animation.
        /// </summary>
        public static string ProgressPropertyName => "Progress";

        LottieToWinCompTranslator(
            LottieData.LottieComposition lottieComposition,
            Compositor compositor,
            bool strictTranslation,
            bool addDescriptions)
        {
            _lc = lottieComposition;
            _c = compositor;
            _unsupported = new TranslationIssues(strictTranslation);
            _addDescriptions = addDescriptions;

            // Create the root.
            _rootVisual = CreateContainerVisual();
            if (_addDescriptions)
            {
                Describe(_rootVisual, "The root of the composition.", "");
            }

            // Add the master progress property to the visual.
            _rootVisual.Properties.InsertScalar(ProgressPropertyName, 0);
        }

        /// <summary>
        /// Attempts to translates the given <see cref="LottieData.LottieComposition"/>.
        /// </summary>
        /// <param name="lottieComposition">The <see cref="LottieData.LottieComposition"/> to translate.</param>
        /// <param name="visual">The <see cref="Visual"/> that contains the translated Lottie.</param>
        /// <param name="resources">Resources that must be kept alive as long as <paramref name="visual"/> is alive, and should be Disposed when no longer required.</param>
        /// <param name="translationIssues">A list of issues that were encountered during the translation.</param>
        public static bool TryTranslateLottieComposition(
            LottieData.LottieComposition lottieComposition,
            bool strictTranslation,
            out Visual visual,
            out (string Code, string Description)[] translationIssues) =>
            TryTranslateLottieComposition(
                lottieComposition,
                strictTranslation,
                true,   // add descriptions for codegen comments
                out visual,
                out translationIssues);

        /// <summary>
        /// Attempts to translates the given <see cref="LottieData.LottieComposition"/>.
        /// </summary>
        /// <param name="lottieComposition">The <see cref="LottieComposition"/> to translate.</param>
        /// <param name="addCodegenDescriptions">Add descriptions to objects for comments on generated code.</param>
        /// <param name="visual">The <see cref="Visual"/> that contains the translated Lottie.</param>
        /// <param name="resources">Resources that must be kept alive as long as <paramref name="visual"/> is alive, and should be Disposed when no longer required.</param>
        /// <param name="translationIssues">A list of issues that were encountered during the translation.</param>
        public static bool TryTranslateLottieComposition(
            LottieComposition lottieComposition,
            bool strictTranslation,
            bool addCodegenDescriptions,
            out Visual visual,
            out (string Code, string Description)[] translationIssues)
        {
            // Set up the translator.
            using (var translator = new LottieToWinCompTranslator(
                lottieComposition,
                new Compositor(),
                strictTranslation,
                addCodegenDescriptions))
            {

                // Translate the Lottie content to a CompositionShapeVisual tree.
                translator.Translate();

                // Set the out parameters.
                visual = translator._rootVisual;
                translationIssues = translator._unsupported.GetIssues();
            }

            return true;
        }

        void Translate()
        {
            var context = new TranslationContext(_lc);
            AddTranslatedLayersToContainerVisual(_rootVisual, context, _lc.Layers, compositionDescription: "Root");
            if (_lc.Is3d)
            {
                if (_lc.Is3d)
                {
                    _unsupported.ThreeD();
                }
            }
        }

        void AddTranslatedLayersToContainerVisual(
            ContainerVisual container,
            TranslationContext context,
            LayerCollection layers,
            string compositionDescription)
        {
            var translatedLayers =
                (from layer in layers.GetLayersBottomToTop()
                 let translatedLayer = TranslateLayer(context, layer)
                 where translatedLayer != null
                 select (translatedLayer: translatedLayer, layer)).ToArray();

            // Layers are translated into either a Visual tree or a Shape tree. Convert the list of Visual and
            // Shape roots to a list of Visual roots by wrapping the Shape trees in ShapeVisuals.
            var translatedAsVisuals = VisualsAndShapesToVisuals(context, translatedLayers.Select(a => a.translatedLayer));

            container.Children.AddRange(translatedAsVisuals);
        }

        // Takes a list of Visuals and Shapes and returns a list of Visuals.
        IEnumerable<Visual> VisualsAndShapesToVisuals(TranslationContext context, IEnumerable<CompositionObject> items)
        {
            ShapeVisual shapeVisual = null;

            foreach (var item in items)
            {
                switch (item.Type)
                {
                    case CompositionObjectType.CompositionContainerShape:
                    case CompositionObjectType.CompositionSpriteShape:
                        if (shapeVisual == null)
                        {
                            shapeVisual = _c.CreateShapeVisual();
                            // ShapeVisual clips to its size
#if NoClipping
                            shapeVisual.Size = Vector2(float.MaxValue);
#else
                            shapeVisual.Size = Vector2(context.Width, context.Height);
#endif 
                        }
                        shapeVisual.Shapes.Add((CompositionShape)item);
                        // TODO - combine the descriptions beter.
                        shapeVisual.ShortDescription = item.ShortDescription;
                        break;
                    case CompositionObjectType.ContainerVisual:
                    case CompositionObjectType.ShapeVisual:
                        if (shapeVisual != null)
                        {
                            yield return shapeVisual;
                            shapeVisual = null;
                        }
                        yield return (Visual)item;
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }

            if (shapeVisual != null)
            {
                yield return shapeVisual;
            }
        }

        // Translates a Lottie layer into null a Visual or a Shape. 
        // Note that ShapeVisual clips to its size.
        CompositionObject TranslateLayer(TranslationContext context, Layer layer)
        {
            if (layer.Is3d)
            {
                _unsupported.ThreeDLayer();
            }

            if (layer.BlendMode != BlendMode.Normal)
            {
                _unsupported.BlendMode(layer.BlendMode);
            }

            if (layer.TimeStretch != 1)
            {
                _unsupported.TimeStretch();
            }

            if (layer.IsHidden)
            {
                return null;
            }

            switch (layer.Type)
            {
                case Layer.LayerType.Image:
                    return TranslateImageLayer(context, (ImageLayer)layer);
                case Layer.LayerType.Null:
                    // Null layers only exist to hold transforms when declared as parents of other layers.
                    return null;
                case Layer.LayerType.PreComp:
                    return TranslatePreCompLayerToVisual(context, (PreCompLayer)layer);
                case Layer.LayerType.Shape:
                    return TranslateShapeLayer(context, (ShapeLayer)layer);
                case Layer.LayerType.Solid:
                    return TranslateSolidLayer(context, (SolidLayer)layer);
                case Layer.LayerType.Text:
                    return TranslateTextLayer(context, (TextLayer)layer);
                default:
                    throw new InvalidOperationException();
            }
        }

        // Returns a chain of ContainerShape that define the transforms for a layer.
        // The top of the chain is the rootTransform, the bottom is the leafTransform.
        bool TryCreateContainerShapeTransformChain(
            TranslationContext context,
            Layer layer,
            out CompositionContainerShape rootNode,
            out CompositionContainerShape contentsNode)
        {

            // Create containers for the contents in the layer.
            // The rootTransformNode is the root for the layer. It may be the same object
            // as the leafTransformNode if there are no inherited transforms.
            // The contentsNode only exists to be the target of the visbility matrix.
            //
            //     +---------------+
            //     |      ...      |
            //     +---------------+
            //            ^
            //            |            
            //     +-------------------+
            //     | rootTransformNode |--Transform (values are inherited from root ancestor of the transform tree)
            //     +-------------------+
            //            ^
            //            |
            //     + - - - - - - - - - - - - +
            //     | other transforms nodes  |--Transform (values inherited from the transform tree)
            //     + - - - - - - - - - - - - +
            //            ^
            //            |
            //     +-------------------+
            //     | leafTransformNode |--Transform defined on the layer
            //     +-------------------+
            //            ^
            //            |
            //     +---------------+
            //     | contentsNode  |--Visibility
            //     +---------------+
            //        ^        ^
            //        |        |
            // +---------+ +---------+
            // | content | | content | ...
            // +---------+ +---------+
            //

            // Convert the layer's in point and out point into absolute progress (0..1) values.
            var inProgress = GetInPointProgress(context, layer);
            var outProgress = GetOutPointProgress(context, layer);
            if (inProgress > 1 || outProgress <= 0)
            {
                // The layer is never visible. Don't create anything.
                rootNode = null;
                contentsNode = null;
                return false;
            }

            TranslateTransformOnContainerShapeForLayer(context, layer, out rootNode, out var leafTransformNode);
            contentsNode = leafTransformNode;

            // Implement the Visibility for the layer. Only needed if the layer becomes visible after
            // the LottieCompositionSource's in point, or it becomes invisible before the LottieCompositionSource's out point.
            if (inProgress > 0 || outProgress < 1)
            {
                // Insert another node to hold the visiblity property.
                contentsNode = CreateContainerShape();
                leafTransformNode.Shapes.Add(contentsNode);
#if !NoInvisibility
                var visibilityExpression =
                    ExpressionFactory.CreateProgressExpression(
                        ExpressionFactory.RootProgress,
                        new ExpressionFactory.Segment(double.MinValue, inProgress, Expr.Matrix3x2Zero),
                        new ExpressionFactory.Segment(inProgress, outProgress, Expr.Matrix3x2Identity),
                        new ExpressionFactory.Segment(outProgress, double.MaxValue, Expr.Matrix3x2Zero)
                        );

                var visibilityAnimation = CreateExpressionAnimation(visibilityExpression);
                visibilityAnimation.SetReferenceParameter(c_rootName, _rootVisual);
                StartAnimation(contentsNode, "TransformMatrix", visibilityAnimation);
#endif // !NoInvisibility
                if (_addDescriptions)
                {
                    Describe(contentsNode, string.IsNullOrWhiteSpace(layer.Name)
                        ? "Animates visibility of the layer."
                        : $"Animates visibility of layer: \"{layer.Name}\".", "Visibility");
                }
            }

            return true;
        }


        // Returns a chain of ContainerVisual that define the transforms for a layer.
        // The top of the chain is the rootTransform, the bottom is the leafTransform.
        // Returns false if the layer is never visible.
        bool TryCreateContainerVisualTransformChain(
            TranslationContext context,
            Layer layer,
            out ContainerVisual rootNode,
            out ContainerVisual contentsNode)
        {
            // Create containers for the contents in the layer.
            // The rootTransformNode is the root for the layer. It may be the same object
            // as the leafTransformNode if there are no inherited transforms.
            // The contentsNode only exists to be the target of the visbility matrix.
            //
            //     +---------------+
            //     |      ...      |
            //     +---------------+
            //            ^
            //            |            
            //     +-------------------+
            //     | rootTransformNode |--Transform (values are inherited from root ancestor of the transform tree)
            //     +-------------------+
            //            ^
            //            |
            //     + - - - - - - - - - - - - +
            //     | other transforms nodes  |--Transform (values inherited from the transform tree)
            //     + - - - - - - - - - - - - +
            //            ^
            //            |
            //     +-------------------+
            //     | leafTransformNode |--Transform defined on the layer
            //     +-------------------+
            //            ^
            //            |
            //     +---------------+
            //     | contentsNode  |--Visibility
            //     +---------------+
            //        ^        ^
            //        |        |
            // +---------+ +---------+
            // | content | | content | ...
            // +---------+ +---------+
            //

            // Convert the layer's in point and out point into absolute progress (0..1) values.
            var inProgress = GetInPointProgress(context, layer);
            var outProgress = GetOutPointProgress(context, layer);
            if (inProgress > 1 || outProgress <= 0)
            {
                // The layer is never visible. Don't create anything.
                rootNode = null;
                contentsNode = null;
                return false;
            }

            TranslateTransformOnContainerVisualForLayer(context, layer, out rootNode, out var leafTransformNode);
            contentsNode = leafTransformNode;


            // Implement the Visibility for the layer. Only needed if the layer becomes visible after
            // the LottieCompositionSource's in point, or it becomes invisible before the LottieCompositionSource's out point.
            if (inProgress > 0 || outProgress < 1)
            {
                // Insert another node to hold the visiblity property.
                contentsNode = CreateContainerVisual();
                leafTransformNode.Children.Add(contentsNode);

#if !NoInvisibility
                var invisible = Expr.Scalar(0);
                var visible = Expr.Scalar(1);

                var visibilityExpression =
                    ExpressionFactory.CreateProgressExpression(
                        ExpressionFactory.RootProgress,
                        new ExpressionFactory.Segment(double.MinValue, inProgress, invisible),
                        new ExpressionFactory.Segment(inProgress, outProgress, visible),
                        new ExpressionFactory.Segment(outProgress, double.MaxValue, invisible)
                        );

                var visibilityAnimation = CreateExpressionAnimation(visibilityExpression);
                visibilityAnimation.SetReferenceParameter(c_rootName, _rootVisual);
                StartAnimation(contentsNode, "Opacity", visibilityAnimation);
#endif // !NoInvisibility
                if (_addDescriptions)
                {
                    Describe(contentsNode, string.IsNullOrWhiteSpace(layer.Name)
                        ? "Animates visibility of the layer."
                        : $"Animates visibility of layer: \"{layer.Name}\".", "Visibility");
                }
            }

            return true;
        }

        Visual TranslateImageLayer(TranslationContext context, ImageLayer layer)
        {
            // Not yet implemented. Currently CompositionShape does not support SurfaceBrush as of RS4.
            // TODO - but this is a visual now, so we could support it.
            _unsupported.ImageLayer();
            return null;
        }

        Visual TranslatePreCompLayerToVisual(TranslationContext context, PreCompLayer layer)
        {
            // Create the transform chain.
            if (!TryCreateContainerVisualTransformChain(context, layer, out var rootNode, out var contentsNode))
            {
                // The layer is never visible.
                return null;
            }

            var result = CreateContainerVisual();

            result.Children.Add(rootNode);
#if !NoClipping
            // PreComps must clip to their size.
            result.Clip = CreateInsetClip();

            // Size is necessary to enable clipping.
            result.Size = Vector2(context.Width, context.Height);
#endif

            // TODO - the animations produced inside a PreComp need to be time-mapped.
            var referencedLayersAsset = _lc.Assets.GetAssetById(layer.RefId);
            switch (referencedLayersAsset.Type)
            {
                case Asset.AssetType.LayerCollection:
                    var layerCollectionAsset = (LayerCollectionAsset)referencedLayersAsset;
                    var referencedLayers = layerCollectionAsset.Layers;
                    // Push the reference layers onto the stack. These will be used to look up parent transforms for layers under this precomp.
                    var subContext = new TranslationContext(context, layer, referencedLayers);
                    AddTranslatedLayersToContainerVisual(contentsNode, subContext, referencedLayers, $"{layer.Name}:{layerCollectionAsset.Id}");
                    break;
                case Asset.AssetType.Image:
                    _unsupported.ImageAssets();
                    break;
                default:
                    throw new InvalidOperationException();
            }

            if (_addDescriptions)
            {
                Describe(result, $"PreComp layer: {layer.Name}", layer.Name);
            }
            return result;
        }

        sealed class ShapeContentContext
        {
            readonly LottieToWinCompTranslator _owner;
            internal SolidColorStroke Stroke { get; private set; }
            internal SolidColorFill Fill { get; private set; }
            internal TrimPath TrimPath { get; private set; }
            internal RoundedCorner RoundedCorner { get; private set; }
            // Opacity is not part of the Lottie context for shapes. But because WinComp
            // doesn't support opacity on shapes, the opacity is inherited from
            // the Transform and passed through to the brushes here.
            internal Animatable<double> OpacityPercent { get; private set; }

            internal ShapeContentContext(LottieToWinCompTranslator owner)
            {
                _owner = owner;
            }
            internal void UpdateFromStack(Stack<ShapeLayerContent> stack)
            {
                while (stack.Count > 0)
                {
                    var popped = stack.Peek();
                    switch (popped.ContentType)
                    {
                        case ShapeContentType.LinearGradientFill:
                        case ShapeContentType.RadialGradientFill:
                            _owner._unsupported.GradientFill();
                            break;

                        case ShapeContentType.LinearGradientStroke:
                        case ShapeContentType.RadialGradientStroke:
                            _owner._unsupported.GradientStroke();
                            break;

                        case ShapeContentType.SolidColorFill:
                            Fill = ComposeSolidColorFill(Fill, (SolidColorFill)popped);
                            break;

                        case ShapeContentType.SolidColorStroke:
                            Stroke = ComposeStrokes(Stroke, (SolidColorStroke)popped);
                            break;

                        case ShapeContentType.RoundedCorner:
                            RoundedCorner = ComposeRoundedCorners(RoundedCorner, (RoundedCorner)popped);
                            break;

                        case ShapeContentType.TrimPath:
                            TrimPath = ComposeTrimPaths(TrimPath, (TrimPath)popped);
                            break;

                        default: return;
                    }
                    stack.Pop();
                }
            }

            internal ShapeContentContext Clone()
            {
                return new ShapeContentContext(_owner)
                {
                    Fill = Fill,
                    Stroke = Stroke,
                    TrimPath = TrimPath,
                    RoundedCorner = RoundedCorner,
                    OpacityPercent = OpacityPercent,
                };
            }

            internal void UpdateOpacityFromTransform(Transform transform)
            {
                if (transform == null)
                {
                    return;
                }

                OpacityPercent = ComposeOpacityPercents(OpacityPercent, transform.OpacityPercent);
            }

            Animatable<double> ComposeOpacityPercents(Animatable<double> a, Animatable<double> b)
            {
                if (a == null)
                {
                    return b;
                }

                if (b == null)
                {
                    return a;
                }

                if (!a.IsAnimated && !b.IsAnimated)
                {
                    return new Animatable<double>(a.InitialValue * (b.InitialValue / 100.0), null);
                }

                if (a.IsAnimated && b.IsAnimated)
                {
                    _owner._unsupported.AnimationMultiplication();
                    return a;
                }

                // Only one is animated.
                if (a.IsAnimated)
                {
                    if (b.InitialValue == 100)
                    {
                        return a;
                    }
                    else
                    {
                        var bScale = b.InitialValue;
                        return new Animatable<double>(
                            initialValue: a.InitialValue * bScale,
                            keyFrames: a.KeyFrames.Select(kf => new KeyFrame<double>(
                                kf.Frame,
                                kf.Value * (bScale / 100),
                                kf.SpatialControlPoint1,
                                kf.SpatialControlPoint2,
                                kf.Easing)),
                            propertyIndex: null);
                    }
                }
                else
                {
                    return ComposeOpacityPercents(b, a);
                }
            }

            SolidColorFill ComposeSolidColorFill(SolidColorFill a, SolidColorFill b)
            {
                if (a == null)
                {
                    return b;
                }
                else if (b == null)
                {
                    return a;
                }

                if (!b.Color.IsAnimated &&
                    !b.OpacityPercent.IsAnimated)
                {
                    if (b.OpacityPercent.InitialValue == 100 &&
                        b.Color.InitialValue.A == 1)
                    {
                        // b overrides a.
                        return b;
                    }
                    else if (b.OpacityPercent.InitialValue == 0 || b.Color.InitialValue.A == 0)
                    {
                        // b is transparent, so a wins.
                        return a;
                    }
                }

                _owner._unsupported.MultipleFills();
                return b;
            }

            SolidColorStroke ComposeStrokes(SolidColorStroke a, SolidColorStroke b)
            {
                if (a == null)
                {
                    return b;
                }
                else if (b == null)
                {
                    return a;
                }

                if (!a.Thickness.IsAnimated && !b.Thickness.IsAnimated &&
                    !a.DashPattern.Any() && !b.DashPattern.Any() &&
                    a.OpacityPercent.AlwaysEquals(100) && b.OpacityPercent.AlwaysEquals(100))
                {
                    if (a.Thickness.InitialValue >= b.Thickness.InitialValue)
                    {
                        // a occludes b, so b can be ignored.
                        return a;
                    }
                }

                // The new stroke should be in addition to the existing stroke. And colors should blend.
                _owner._unsupported.MultipleStrokes();
                return b;
            }

            RoundedCorner ComposeRoundedCorners(RoundedCorner a, RoundedCorner b)
            {
                if (a == null)
                {
                    return b;
                }
                else if (b == null)
                {
                    return a;
                }

                if (!b.Radius.IsAnimated)
                {
                    if (b.Radius.InitialValue >= 0)
                    {
                        // If b has a non-0 value, it wins.
                        return b;
                    }
                    else
                    {
                        // b is always 0. A wins.
                        return a;
                    }
                }

                _owner._unsupported.MultipleAnimatedRoundedCorners();
                return b;
            }

            TrimPath ComposeTrimPaths(TrimPath a, TrimPath b)
            {
                if (a == null)
                {
                    return b;
                }
                else if (b == null)
                {
                    return a;
                }

                _owner._unsupported.MultipleTrimPaths();
                return b;
            }
        }

        // May return null if the layer does not produce any renderable content.
        CompositionShape TranslateShapeLayer(TranslationContext context, ShapeLayer layer)
        {
            if (!TryCreateContainerShapeTransformChain(context, layer, out var rootNode, out var contentsNode))
            {
                // The layer is never visible.
                return null;
            }

            var shapeContext = new ShapeContentContext(this);
            shapeContext.UpdateOpacityFromTransform(layer.Transform);

            var contents = TranslateShapeLayerContents(context, shapeContext, layer.Contents, contentsNode).ToArray();
            if (contents.Length > 0)
            {
                contentsNode.Shapes.AddRange(contents);
                return rootNode;
            }
            else
            {
                return null;
            }
        }

        // May return null if the group does not produce any renderable content.
        CompositionShape TranslateGroupShapeContent(TranslationContext context, ShapeContentContext shapeContext, ShapeGroup group)
        {
            var compositionNode = CreateContainerShape();

            var contents = TranslateShapeLayerContents(context, shapeContext, group.Items, compositionNode).ToArray();

            if (contents.Length > 0)
            {
                if (_addDescriptions)
                {
                    Describe(compositionNode, $"Group: {group.Name}");
                }
                compositionNode.Shapes.AddRange(contents);
                return compositionNode;
            }
            else
            {
                return null;
            }
        }

        IEnumerable<CompositionShape> TranslateShapeLayerContents<T>(
            TranslationContext context,
            ShapeContentContext shapeContext,
            IEnumerable<ShapeLayerContent> contents,
            T transformContainer) where T : CompositionObject, IContainShapes
        {
            // The Contents of a ShapeLayer is a list of instructions for a stack machine.

            // When evaluated, the stack of ShapeLayerContent produces a list of CompositionShape.
            // Some ShapeLayerContent modify the evaluation context (e.g. stroke, fill, trim)
            // Some ShapeLayerContent evaluate to geometries (e.g. any geometry, merge path)
            // Transform only works correctly on a group. It's needed to rotate a rectangle.
            // TODO - transform that is not on a group

            var stack = new Stack<ShapeLayerContent>(contents);

            while (true)
            {
                shapeContext.UpdateFromStack(stack);
                if (stack.Count == 0)
                {
                    break;
                }

                var shapeContent = stack.Pop();
                switch (shapeContent.ContentType)
                {
                    case ShapeContentType.Transform:
                        shapeContext.UpdateOpacityFromTransform((Transform)shapeContent);
                        switch (transformContainer.Type)
                        {
                            case CompositionObjectType.ContainerVisual:
                                TranslateAndApplyTransformToContainerVisual(context, (Transform)shapeContent, (ContainerVisual)(CompositionObject)transformContainer);
                                break;
                            case CompositionObjectType.CompositionContainerShape:
                                TranslateAndApplyTransformToContainerShape(context, (Transform)shapeContent, (CompositionContainerShape)(CompositionObject)transformContainer);
                                break;
                            default:
                                throw new InvalidOperationException();
                        }
                        break;

                    case ShapeContentType.Group:
                        var group = TranslateGroupShapeContent(context, shapeContext.Clone(), (ShapeGroup)shapeContent);
                        if (group != null)
                        {
                            yield return group;
                        }
                        break;
                    case ShapeContentType.Path:
                        yield return TranslatePathContent(context, shapeContext, (Shape)shapeContent);
                        break;
                    case ShapeContentType.Ellipse:
                        yield return TranslateEllipseContent(context, shapeContext, (Ellipse)shapeContent);
                        break;
                    case ShapeContentType.Rectangle:
                        yield return TranslateRectangleContent(context, shapeContext, (Rectangle)shapeContent);
                        break;
                    case ShapeContentType.Polystar:
                        _unsupported.Polystar();
                        break;
                    case ShapeContentType.Repeater:
                        _unsupported.Repeater();
                        break;
                    case ShapeContentType.MergePaths:
                        var mergedPaths = TranslateMergePathsContent(context, shapeContext, stack, ((MergePaths)shapeContent).Mode);
                        if (mergedPaths != null)
                        {
                            yield return mergedPaths;
                        }
                        break;
                    default:
                    case ShapeContentType.SolidColorStroke:
                    case ShapeContentType.LinearGradientStroke:
                    case ShapeContentType.RadialGradientStroke:
                    case ShapeContentType.SolidColorFill:
                    case ShapeContentType.LinearGradientFill:
                    case ShapeContentType.RadialGradientFill:
                    case ShapeContentType.TrimPath:
                    case ShapeContentType.RoundedCorner:
                        throw new InvalidOperationException();
                }
            }
        }

        // Merge the stack into a single shape. Merging is done recursively - the top geometry on the
        // stack is merged with the merge of the remainder of the stack.
        CompositionShape TranslateMergePathsContent(TranslationContext context, ShapeContentContext shapeContext, Stack<ShapeLayerContent> stack, MergePaths.MergeMode mergeMode)
        {
            var mergedGeometry = MergeShapeLayerContent(shapeContext, stack, mergeMode);
            if (mergedGeometry != null)
            {
                var result = CreateSpriteShape();
                result.Geometry = CreatePathGeometry(new CompositionPath(mergedGeometry));
                TranslateAndApplyShapeContentContext(context, shapeContext, result);
                return result;
            }
            else
            {
                return null;
            }
        }

        CanvasGeometry MergeShapeLayerContent(ShapeContentContext context, Stack<ShapeLayerContent> stack, MergePaths.MergeMode mergeMode)
        {
            var pathFillType = context.Fill == null ? SolidColorFill.PathFillType.EvenOdd : context.Fill.FillType;
            var geometries = CreateCanvasGeometries(context, stack, pathFillType).ToArray();

            switch (geometries.Length)
            {
                case 0:
                    return null;
                case 1:
                    return geometries[0];
                default:
                    return CombineGeometries(geometries, mergeMode);
            }
        }

        // Merges the given paths with MergeMode.Merge.
        CanvasGeometry MergePaths(CanvasGeometry.Path[] paths)
        {
            Debug.Assert(paths.Length > 1);
            var builder = new CanvasPathBuilder(null);
            var filledRegionDetermination = paths[0].FilledRegionDetermination;
            builder.SetFilledRegionDetermination(filledRegionDetermination);
            foreach (var path in paths)
            {
                Debug.Assert(filledRegionDetermination == path.FilledRegionDetermination);
                foreach (var command in path.Commands)
                {
                    switch (command.Type)
                    {
                        case CanvasPathBuilder.CommandType.BeginFigure:
                            builder.BeginFigure(((CanvasPathBuilder.Command.BeginFigure)command).StartPoint);
                            break;
                        case CanvasPathBuilder.CommandType.EndFigure:
                            builder.EndFigure(((CanvasPathBuilder.Command.EndFigure)command).FigureLoop);
                            break;
                        case CanvasPathBuilder.CommandType.AddCubicBezier:
                            var cb = (CanvasPathBuilder.Command.AddCubicBezier)command;
                            builder.AddCubicBezier(cb.ControlPoint1, cb.ControlPoint2, cb.EndPoint);
                            break;
                        case CanvasPathBuilder.CommandType.AddLine:
                            builder.AddLine(((CanvasPathBuilder.Command.AddLine)command).EndPoint);
                            break;
                        default:
                            throw new InvalidOperationException();
                    }
                }
            }
            return CanvasGeometry.CreatePath(builder);
        }

        // Combine all of the given geometries into a single geometry.
        CanvasGeometry CombineGeometries(CanvasGeometry[] geometries, MergePaths.MergeMode mergeMode)
        {
            switch (geometries.Length)
            {
                case 0:
                    return null;
                case 1:
                    return geometries[0];
            }

            // If MergeMode.Merge and they're all paths with the same FilledRegionDetermination, 
            // combine into a single path.
            if (mergeMode == LottieData.MergePaths.MergeMode.Merge &&
                geometries.All(g => g.Type == CanvasGeometry.GeometryType.Path) &&
                geometries.Select(g => ((CanvasGeometry.Path)g).FilledRegionDetermination).Distinct().Count() == 1)
            {
                return MergePaths(geometries.Cast<CanvasGeometry.Path>().ToArray());
            }
            else
            {
                if (geometries.Length > 50)
                {
                    // There will be stack overflows if the CanvasGeometry.Combine is too large.
                    // Usually not a problem, but handle degenerate cases.
                    _unsupported.MergingALargeNumberOfShapes();
                    geometries = geometries.Take(50).ToArray();
                }

                var combineMode = GeometryCombine(mergeMode);

#if PreCombineGeometries
            return CanvasGeometryCombiner.CombineGeometries(geometries, combineMode);
#else
                var accumulator = geometries[0];
                for (var i = 1; i < geometries.Length; i++)
                {
                    accumulator = accumulator.CombineWith(geometries[i], Matrix3x2Identity, combineMode);
                }
                return accumulator;
#endif
            }
        }

        IEnumerable<CanvasGeometry> CreateCanvasGeometries(ShapeContentContext context, Stack<ShapeLayerContent> stack, SolidColorFill.PathFillType pathFillType)
        {
            while (stack.Count > 0)
            {
                // Ignore context on the stack - we only want geometries.
                var shapeContent = stack.Pop();
                switch (shapeContent.ContentType)
                {
                    case ShapeContentType.Group:
                        {
                            // Convert all the shapes in the group to a list of geometries
                            var group = (ShapeGroup)shapeContent;
                            var groupedGeometries = CreateCanvasGeometries(context.Clone(), new Stack<ShapeLayerContent>(group.Items), pathFillType);
                            foreach (var geometry in groupedGeometries)
                            {
                                yield return geometry;
                            }
                        }
                        break;
                    case ShapeContentType.MergePaths:
                        yield return MergeShapeLayerContent(context, stack, ((MergePaths)shapeContent).Mode);
                        break;
                    case ShapeContentType.Repeater:
                        _unsupported.Repeater();
                        break;
                    case ShapeContentType.Transform:
                        // Ignore transforms applied to geometries.
                        // TODO - should transforms be applied to the geometries?
                        continue;

                    case ShapeContentType.SolidColorStroke:
                    case ShapeContentType.LinearGradientStroke:
                    case ShapeContentType.RadialGradientStroke:
                    case ShapeContentType.SolidColorFill:
                    case ShapeContentType.RadialGradientFill:
                    case ShapeContentType.LinearGradientFill:
                    case ShapeContentType.TrimPath:
                    case ShapeContentType.RoundedCorner:
                        // Ignore commands that set the context - we only want geometries.
                        continue;

                    case ShapeContentType.Path:
                        yield return CreateWin2dPathGeometry((Shape)shapeContent, pathFillType);
                        break;
                    case ShapeContentType.Ellipse:
                        yield return CreateWin2dEllipseGeometry((Ellipse)shapeContent);
                        break;
                    case ShapeContentType.Rectangle:
                        yield return CreateWin2dRectangleGeometry(context, (Rectangle)shapeContent);
                        break;
                    case ShapeContentType.Polystar:
                        _unsupported.Polystar();
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }

        }

        // Returns true iff all of the points lie on the same line, and p1 and p2 are between p0 and p3.
        // Such cubic beziers can be replaced by a line from p0 to p3.
        static bool IsCubicBezierALine(
            WinCompData.Sn.Vector2 p0,
            WinCompData.Sn.Vector2 p1,
            WinCompData.Sn.Vector2 p2,
            WinCompData.Sn.Vector2 p3)
        {
            if (!IsCubicBezierColinear(p0, p1, p2, p3))
            {
                return false;
            }

            // The points are on the same line. The cubic bezier is a line if
            // p1 and p2 are between p0..p3.
            var outerDiffX = Math.Abs(p0.X - p3.X);

            if (Math.Abs(p0.X - p1.X) > outerDiffX)
            {
                return false;
            }
            if (Math.Abs(p3.X - p1.X) > outerDiffX)
            {
                return false;
            }

            if (Math.Abs(p0.X - p2.X) > outerDiffX)
            {
                return false;
            }
            if (Math.Abs(p3.X - p2.X) > outerDiffX)
            {
                return false;
            }


            var outerDiffY = Math.Abs(p0.Y - p3.Y);

            if (Math.Abs(p0.Y - p1.Y) > outerDiffY)
            {
                return false;
            }
            if (Math.Abs(p3.Y - p1.Y) > outerDiffY)
            {
                return false;
            }

            if (Math.Abs(p0.Y - p2.Y) > outerDiffY)
            {
                return false;
            }
            if (Math.Abs(p3.Y - p2.Y) > outerDiffY)
            {
                return false;
            }

            return true;
        }

        // Returns true if each of the given points is on the same line.
        static bool IsCubicBezierColinear(
            WinCompData.Sn.Vector2 p0,
            WinCompData.Sn.Vector2 p1,
            WinCompData.Sn.Vector2 p2,
            WinCompData.Sn.Vector2 p3)
        {
            var p01X = p0.X - p1.X;
            var p01Y = p0.Y - p1.Y;

            var p02X = p0.X - p2.X;
            var p02Y = p0.Y - p2.Y;

            var p03X = p0.X - p3.X;
            var p03Y = p0.Y - p3.Y;

            if (p01Y == 0 || p02Y == 0 || p03Y == 0)
            {
                // Can't divide by Y because it's 0 in at least one case. (i.e. horizontal line)
                if (p01X == 0 || p02X == 0 || p03X == 0)
                {
                    // Can't divide by X because it's 0 in at least one case (i.e. vertical line)
                    // The points can only be colinear if they're all equal.
                    return p0 == p1 && p0 == p2 && p0 == p3;
                }
                else
                {
                    return (p01Y / p01X) == (p02Y / p02X) &&
                           (p01Y / p01X) == (p03Y / p03X);
                }
            }
            else
            {
                return (p01X / p01Y) == (p02X / p02Y) &&
                       (p01X / p01Y) == (p03X / p03Y);
            }
        }

        CanvasGeometry CreateWin2dPathGeometry(Shape path, SolidColorFill.PathFillType fillType)
        {
            if (path.PathData.IsAnimated)
            {
                _unsupported.CombiningAnimatedShapes();
            }

            var pathData = path.PathData.InitialValue;
            var beziers = pathData.Beziers.ToArray();

            using (var builder = new CanvasPathBuilder(null))
            {
                builder.SetFilledRegionDetermination(FilledRegionDetermination(fillType));
                if (beziers.Length == 0)
                {
                    builder.BeginFigure(Vector2(0));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                }
                else
                {
                    var cp0 = Vector2(pathData.Start);
                    builder.BeginFigure(Vector2(pathData.Start));
                    foreach (var segment in beziers)
                    {
                        var cp1 = Vector2(segment.ControlPoint1);
                        var cp2 = Vector2(segment.ControlPoint2);
                        var cp3 = Vector2(segment.Vertex);

                        if (IsCubicBezierALine(cp0, cp1, cp2, cp3))
                        {
                            // Ignore 0-length lines.
                            if (!cp0.Equals(cp3))
                            {
                                builder.AddLine(cp3);
                            }
                        }
                        else
                        {
                            builder.AddCubicBezier(cp1, cp2, cp3);
                        }
                        cp0 = cp3;
                    }
                    builder.EndFigure(pathData.IsClosed ? CanvasFigureLoop.Closed : CanvasFigureLoop.Open);
                }
                var result = CanvasGeometry.CreatePath(builder);
                if (_addDescriptions)
                {
                    Describe(result, path.Name);
                }
                return result;
            }
        }

        CanvasGeometry CreateWin2dEllipseGeometry(Ellipse ellipse)
        {
            var ellipsePosition = ellipse.Position;
            var ellipseDiameter = ellipse.Diameter;

            if (ellipsePosition.IsAnimated || ellipseDiameter.IsAnimated)
            {
                _unsupported.CombiningAnimatedShapes();
            }

            var xRadius = ellipseDiameter.InitialValue.X / 2;
            var yRadius = ellipseDiameter.InitialValue.Y / 2;

            var result = CanvasGeometry.CreateEllipse(
                null,
                (float)(ellipsePosition.InitialValue.X - (xRadius / 2)),
                (float)(ellipsePosition.InitialValue.Y - (yRadius / 2)),
                (float)xRadius,
                (float)yRadius);

            if (_addDescriptions)
            {
                Describe(result, ellipse.Name);
            }
            return result;
        }

        CanvasGeometry CreateWin2dRectangleGeometry(ShapeContentContext context, Rectangle rectangle)
        {
            var position = rectangle.Position;
            var size = rectangle.Size;
            // If a Rectangle is in the context, use it to override the corner radius.
            var cornerRadius = context.RoundedCorner != null ? context.RoundedCorner.Radius : rectangle.CornerRadius;

            if (position.IsAnimated || size.IsAnimated || cornerRadius.IsAnimated)
            {
                _unsupported.CombiningAnimatedShapes();
            }

            var width = size.InitialValue.X;
            var height = size.InitialValue.Y;
            var radius = cornerRadius.InitialValue;

            var result = CanvasGeometry.CreateRoundedRectangle(
                null,
                (float)(position.InitialValue.X - (width / 2)),
                (float)(position.InitialValue.Y - (height / 2)),
                (float)width,
                (float)height,
                (float)radius,
                (float)radius);

            if (_addDescriptions)
            {
                Describe(result, rectangle.Name);
            }
            return result;
        }

        CompositionShape TranslateEllipseContent(TranslationContext context, ShapeContentContext shapeContext, Ellipse shapeContent)
        {
            // An ellipse is represented as a SpriteShape with a CompositionEllipseGeometry.
            var compositionSpriteShape = CreateSpriteShape();

            var compositionEllipseGeometry = CreateEllipseGeometry();
            compositionSpriteShape.Geometry = compositionEllipseGeometry;
            if (_addDescriptions)
            {
                Describe(compositionSpriteShape, shapeContent.Name);
                Describe(compositionEllipseGeometry, $"{shapeContent.Name}.EllipseGeometry");
            }
            compositionEllipseGeometry.Center = Vector2(shapeContent.Position.InitialValue);
            ApplyVector2KeyFrameAnimation(context, (AnimatableVector3)shapeContent.Position, compositionEllipseGeometry, "Center", "Center", null);

            compositionEllipseGeometry.Radius = Vector2(shapeContent.Diameter.InitialValue) * 0.5F;
            ApplyScaledVector2KeyFrameAnimation(context, (AnimatableVector3)shapeContent.Diameter, 0.5, compositionEllipseGeometry, "Radius", "Radius", null);

            TranslateAndApplyShapeContentContext(context, shapeContext, compositionSpriteShape);

            return compositionSpriteShape;
        }

        CompositionShape TranslateRectangleContent(TranslationContext context, ShapeContentContext shapeContext, Rectangle shapeContent)
        {
            var compositionRectangle = CreateSpriteShape();

            if (shapeContent.CornerRadius.AlwaysEquals(0) && shapeContext.RoundedCorner == null)
            {
                // Use a non-rounded rectangle geometry.
                var geometry = CreateRectangleGeometry();
                compositionRectangle.Geometry = geometry;

                // Map Rectangle's position to RoundedRectangleGeometry.Offset by using custom property, Position, and an ExpressionAnimation
                geometry.Properties.InsertVector2("Position", Vector2(shapeContent.Position.InitialValue));

                // ExpressionAnimation to compensate for default centerpoint being top-left vs geometric center
                var compositionOffsetExpression = CreateExpressionAnimation(ExpressionFactory.OffsetExpression);
                compositionOffsetExpression.SetReferenceParameter("my", geometry);
                StartAnimation(geometry, "Offset", compositionOffsetExpression);

                ApplyVector2KeyFrameAnimation(context, (AnimatableVector3)shapeContent.Position, geometry, nameof(Rectangle.Position), "Position", null);

                // Map Rectangle's size to RoundedRectangleGeometry.Size
                geometry.Size = Vector2(shapeContent.Size.InitialValue);
                ApplyVector2KeyFrameAnimation(context, (AnimatableVector3)shapeContent.Size, geometry, nameof(Rectangle.Size), "Size", null);

            }
            else
            {
                // Use a rounded rectangle geometry.
                var geometry = CreateRoundedRectangleGeometry();
                compositionRectangle.Geometry = geometry;

                // Map Rectangle's position to RoundedRectangleGeometry.Offset by using custom property, Position, and an ExpressionAnimation
                geometry.Properties.InsertVector2("Position", Vector2(shapeContent.Position.InitialValue));

                // ExpressionAnimation to compensate for default centerpoint being top-left vs geometric center
                var compositionOffsetExpression = CreateExpressionAnimation(ExpressionFactory.OffsetExpression);
                compositionOffsetExpression.SetReferenceParameter("my", geometry);
                StartAnimation(geometry, "Offset", compositionOffsetExpression);

                ApplyVector2KeyFrameAnimation(context, (AnimatableVector3)shapeContent.Position, geometry, "Position", "Position", null);

                // Map Rectangle's size to RoundedRectangleGeometry.Size
                geometry.Size = Vector2(shapeContent.Size.InitialValue);
                ApplyVector2KeyFrameAnimation(context, (AnimatableVector3)shapeContent.Size, geometry, nameof(geometry.Size), "Size", null);

                // Map Rectangle's size to RoundedRectangleGeometry.CornerRadius
                // If a RoundedRectangle is in the context, use it to override the corner radius.
                var cornerRadius = shapeContext.RoundedCorner != null ? shapeContext.RoundedCorner.Radius : shapeContent.CornerRadius;
                if (cornerRadius.IsAnimated || cornerRadius.InitialValue != 0)
                {
                    geometry.CornerRadius = Vector2((float)cornerRadius.InitialValue);
                    ApplyScalarKeyFrameAnimation(context, cornerRadius, geometry, "CornerRadius.X", "CornerRadius.X", null);
                    ApplyScalarKeyFrameAnimation(context, cornerRadius, geometry, "CornerRadius.Y", "CornerRadius.Y", null);
                }
            }

            // Lottie rectangles have 0,0 at top right. That causes problems for TrimPath which expects 0,0 to be top left.
            // Add an offset.
            // TODO - this only works correctly if Size and TrimOffset are not animated. A complete solution requires
            //        adding another property. 
            var isPartialTrimPath = shapeContext.TrimPath != null &&
                (shapeContext.TrimPath.StartPercent.IsAnimated || shapeContext.TrimPath.EndPercent.IsAnimated || shapeContext.TrimPath.OffsetDegrees.IsAnimated ||
                shapeContext.TrimPath.StartPercent.InitialValue != 0 || shapeContext.TrimPath.EndPercent.InitialValue != 100);

            if (shapeContent.Size.IsAnimated && isPartialTrimPath)
            {
                // Warn that we might be getting things wrong
                _unsupported.AnimatedRectangleWithTrimPath();
            }
            var width = shapeContent.Size.InitialValue.X;
            var height = shapeContent.Size.InitialValue.Y;
            var trimOffsetDegrees = (width / (2 * (width + height))) * 360;
            TranslateAndApplyShapeContentContext(context, shapeContext, compositionRectangle, trimOffsetDegrees: trimOffsetDegrees);

            if (_addDescriptions)
            {
                Describe(compositionRectangle, shapeContent.Name);
                Describe(compositionRectangle.Geometry, $"{shapeContent.Name}.RectangleGeometry");
            }
            return compositionRectangle;
        }

        CompositionShape TranslatePathContent(TranslationContext context, ShapeContentContext shapeContext, Shape shapeContent)
        {
            if (shapeContext.RoundedCorner != null &&
                (shapeContext.RoundedCorner.Radius.IsAnimated || shapeContext.RoundedCorner.Radius.InitialValue != 0))
            {
                // TODO - can rounded corners be implemented by composing cubic beziers?
                _unsupported.PathWithRoundedCorners();
            }

            // Map Path's Geometry data to PathGeometry.Path
            var geometry = shapeContent.PathData;

            // A path is represented as a SpriteShape with a CompositionPathGeometry.
            var compositionSpriteShape = CreateSpriteShape();

            var compositionPathGeometry = CreatePathGeometry();
            compositionSpriteShape.Geometry = compositionPathGeometry;
            compositionPathGeometry.Path = CompositionPathFromPathGeometry(geometry.InitialValue, GetPathFillType(shapeContext.Fill));

            if (_addDescriptions)
            {
                Describe(compositionSpriteShape, shapeContent.Name);
                Describe(compositionPathGeometry, $"{shapeContent.Name}.PathGeometry");
            }
            ApplyPathKeyFrameAnimation(context, geometry, GetPathFillType(shapeContext.Fill), compositionPathGeometry, "Path", "Path", null);

            TranslateAndApplyShapeContentContext(context, shapeContext, compositionSpriteShape, 0);

            return compositionSpriteShape;
        }

        void TranslateAndApplyShapeContentContext(TranslationContext context, ShapeContentContext shapeContext, CompositionSpriteShape shape, double trimOffsetDegrees = 0)
        {
            shape.FillBrush = TranslateShapeFill(context, shapeContext.Fill, shapeContext.OpacityPercent);
            TranslateAndApplyStroke(context, shapeContext.Stroke, shape, shapeContext.OpacityPercent);
            TranslateAndApplyTrimPath(context, shapeContext.TrimPath, shape.Geometry, trimOffsetDegrees);
        }

        enum AnimatableOrder
        {
            Before,
            After,
            Equal,
            BeforeAndAfter,
        }

        static AnimatableOrder GetValueOrder(double a, double b)
        {
            if (a == b)
            {
                return AnimatableOrder.Equal;
            }
            else if (a < b)
            {
                return AnimatableOrder.Before;
            }
            else
            {
                return AnimatableOrder.After;
            }
        }

        static AnimatableOrder GetAnimatableOrder(Animatable<double> a, Animatable<double> b)
        {
            var initialA = a.InitialValue;
            var initialB = b.InitialValue;

            var initialOrder = GetValueOrder(initialA, initialB);
            if (!a.IsAnimated && !b.IsAnimated)
            {
                return initialOrder;
            }

            // TODO - recognize more cases. For now just handle a is always before b
            var aMin = initialA;
            var aMax = initialA;
            if (a.IsAnimated)
            {
                aMin = Math.Min(a.KeyFrames.Min(kf => kf.Value), initialA);
                aMax = Math.Max(a.KeyFrames.Max(kf => kf.Value), initialA);
            }

            var bMin = initialB;
            var bMax = initialB;
            if (b.IsAnimated)
            {
                bMin = Math.Min(b.KeyFrames.Min(kf => kf.Value), initialB);
                bMax = Math.Max(b.KeyFrames.Max(kf => kf.Value), initialB);
            }

            switch (initialOrder)
            {
                case AnimatableOrder.Before:
                    return aMax <= bMin ? initialOrder : AnimatableOrder.BeforeAndAfter;
                case AnimatableOrder.After:
                    return aMin >= bMax ? initialOrder : AnimatableOrder.BeforeAndAfter;
                case AnimatableOrder.Equal:
                    {
                        if (aMin == aMax && bMin == bMax && aMin == bMax)
                        {
                            return AnimatableOrder.Equal;
                        }
                        else if (aMin < bMax)
                        {
                            // Might be before, unless they cross over.
                            return bMin < initialA || aMax > initialA ? AnimatableOrder.BeforeAndAfter : AnimatableOrder.Before;
                        }
                        else
                        {
                            // Might be after, unless they cross over.
                            return bMin > aMax ? AnimatableOrder.BeforeAndAfter : AnimatableOrder.After;
                        }
                    }
                case AnimatableOrder.BeforeAndAfter:
                default:
                    throw new InvalidOperationException();
            }
        }

        void TranslateAndApplyTrimPath(TranslationContext context, TrimPath trimPath, CompositionGeometry geometry, double trimOffsetDegrees)
        {
            if (trimPath == null)
            {
                return;
            }

            var startPercent = _lottieDataOptimizer.GetOptimized(trimPath.StartPercent);
            var endPercent = _lottieDataOptimizer.GetOptimized(trimPath.EndPercent);

            var order = GetAnimatableOrder(startPercent, endPercent);

            switch (order)
            {
                case AnimatableOrder.Before:
                case AnimatableOrder.Equal:
                    break;
                case AnimatableOrder.After:
                    {
                        // Swap is necessary to match the WinComp semantics.
                        var temp = startPercent;
                        startPercent = endPercent;
                        endPercent = temp;
                    }
                    break;
                case AnimatableOrder.BeforeAndAfter:
                    break;
                default:
                    throw new InvalidOperationException();
            }

            if (order == AnimatableOrder.BeforeAndAfter)
            {
                // Add properties that will be animated. The TrimStart and TrimEnd properties
                // will be set by these values through an expression.
                geometry.Properties.InsertScalar("TStart", (float)(startPercent.InitialValue / 100));
                ApplyScaledScalarKeyFrameAnimation(context, startPercent, 1 / 100.0, geometry.Properties, "TStart", "TStart", null);
                var trimStartExpression = CreateExpressionAnimation(ExpressionFactory.MinTStartTEnd);
                trimStartExpression.SetReferenceParameter("my", geometry);
                StartAnimation(geometry, nameof(geometry.TrimStart), trimStartExpression);

                geometry.Properties.InsertScalar("TEnd", (float)(endPercent.InitialValue / 100));
                ApplyScaledScalarKeyFrameAnimation(context, endPercent, 1 / 100.0, geometry.Properties, "TEnd", "TEnd", null);
                var trimEndExpression = CreateExpressionAnimation(ExpressionFactory.MaxTStartTEnd);
                trimEndExpression.SetReferenceParameter("my", geometry);
                StartAnimation(geometry, nameof(geometry.TrimEnd), trimEndExpression);
            }
            else
            {
                geometry.TrimStart = Float(startPercent.InitialValue / 100);
                ApplyScaledScalarKeyFrameAnimation(context, startPercent, 1 / 100.0, geometry, nameof(geometry.TrimStart), "TrimStart", null);

                geometry.TrimEnd = Float(endPercent.InitialValue / 100);
                ApplyScaledScalarKeyFrameAnimation(context, endPercent, 1 / 100.0, geometry, nameof(geometry.TrimEnd), "TrimEnd", null);
            }

            if (trimOffsetDegrees != 0 && !trimPath.OffsetDegrees.IsAnimated)
            {
                // Rectangle shapes are treated specially here to account for Lottie rectangle 0,0 being
                // top right and WinComp rectangle 0,0 being top left. As long as the TrimOffset isn't
                // being animated we can simply add an offset to the trim path.
                geometry.TrimOffset = (float)((trimPath.OffsetDegrees.InitialValue + trimOffsetDegrees) / 360);
            }
            else
            {
                if (trimOffsetDegrees != 0)
                {
                    // TODO - can be handled with another property.
                    _unsupported.AnimatedTrimOffsetWithStaticTrimOffset();
                }

                geometry.TrimOffset = Float(trimPath.OffsetDegrees.InitialValue / 360);
                ApplyScaledScalarKeyFrameAnimation(context, trimPath.OffsetDegrees, 1 / 360.0, geometry, nameof(geometry.TrimOffset), "TrimOffset", null);
            }
        }

        void TranslateAndApplyStroke(TranslationContext context, SolidColorStroke shapeStroke, CompositionSpriteShape sprite, Animatable<double> opacityPercent)
        {
            if (shapeStroke == null || shapeStroke.Thickness.AlwaysEquals(0))
            {
                return;
            }

            // A ShapeStroke is represented as a CompositionColorBrush and Stroke properties on the relevant SpriteShape.

            // Map ShapeStroke's color to SpriteShape.StrokeBrush

            sprite.StrokeBrush = CreateAnimatedColorBrush(context, MultiplyAnimatableColorByAnimatableOpacityPercent(shapeStroke.Color, shapeStroke.OpacityPercent), opacityPercent);

            // Map ShapeStroke's width to SpriteShape.StrokeThickness
            sprite.StrokeThickness = (float)shapeStroke.Thickness.InitialValue;
            ApplyScalarKeyFrameAnimation(context, shapeStroke.Thickness, sprite, nameof(sprite.StrokeThickness), "StrokeThickness", null);

            // Map ShapeStroke's linecap to SpriteShape.StrokeStart/End/DashCap
            sprite.StrokeStartCap = sprite.StrokeEndCap = sprite.StrokeDashCap = StrokeCap(shapeStroke.CapType);

            // Map ShapeStroke's linejoin to SpriteShape.StrokeLineJoin
            sprite.StrokeLineJoin = StrokeLineJoin(shapeStroke.JoinType);

            // Set MiterLimit
            sprite.StrokeMiterLimit = (float)shapeStroke.MiterLimit;

            // Map ShapeStroke's dash pattern to SpriteShape.StrokeDashArray
            // NOTE: DashPattern animation (animating dash sizes) are not supported on CompositionSpriteShape.
            foreach (var dash in shapeStroke.DashPattern)
            {
                sprite.StrokeDashArray.Add((float)dash);
            }

            // Set DashOffset
            sprite.StrokeDashOffset = (float)shapeStroke.DashOffset.InitialValue;
            ApplyScalarKeyFrameAnimation(context, shapeStroke.DashOffset, sprite, nameof(sprite.StrokeDashOffset), "StrokeDashOffset", null);
        }

        CompositionColorBrush TranslateShapeFill(TranslationContext context, SolidColorFill shapeFill, Animatable<double> opacityPercent)
        {
            if (shapeFill == null)
            {
                return null;
            }
            // A ShapeFill is represented as a CompositionColorBrush.
            return CreateAnimatedColorBrush(context, MultiplyAnimatableColorByAnimatableOpacityPercent(shapeFill.Color, shapeFill.OpacityPercent), opacityPercent);
        }

        CompositionShape TranslateSolidLayer(TranslationContext context, SolidLayer layer)
        {
            if (layer.IsHidden || layer.Transform.OpacityPercent.AlwaysEquals(0))
            {
                // The layer does not render anything. Nothing to translate. This can happen when someone
                // creates a solid layer to act like a Null layer.
                return null;
            }

            if (!TryCreateContainerShapeTransformChain(context, layer, out var rootNode, out var contentsNode))
            {
                // The layer is never visible.
                return null;
            }

            var rectangleGeometry = CreateRectangleGeometry();
            rectangleGeometry.Size = Vector2(layer.Width, layer.Height);

            var rectangle = CreateSpriteShape();
            rectangle.Geometry = rectangleGeometry;

            contentsNode.Shapes.Add(rectangle);

            rectangle.FillBrush = CreateAnimatedColorBrush(context, layer.Color, layer.Transform.OpacityPercent);

            if (_addDescriptions)
            {
                Describe(rectangle, "SolidLayerRectangle");
                Describe(rectangleGeometry, "SolidLayerRectangle.RectangleGeometry");
            }
            return rootNode;
        }

        Visual TranslateTextLayer(TranslationContext context, TextLayer layer)
        {
            // Text layers are not yet suported.
            _unsupported.TextLayer();
            return null;
        }


        // Returns a chain of ContainerVisual that define the transform for a layer.
        // The top of the chain is the rootTransform, the bottom is the leafTransform.
        void TranslateTransformOnContainerVisualForLayer(
            TranslationContext context,
            Layer layer,
            out ContainerVisual rootTransformNode,
            out ContainerVisual leafTransformNode)
        {
            // Create a ContainerVisual to apply the transform to.
            leafTransformNode = CreateContainerVisual();

            // Apply the transform.
            TranslateAndApplyTransformToContainerVisual(context, layer.Transform, leafTransformNode);
            if (_addDescriptions)
            {
                Describe(leafTransformNode, $"'{layer.Name}'.Transforms");
            }

#if NoTransformInheritance
            rootTransformNode = leafTransformNode;
#else
            // Translate the parent transform, if any.
            if (layer.Parent != null)
            {
                var parentLayer = context.Layers.GetLayerById(layer.Parent.Value);
                TranslateTransformOnContainerVisualForLayer(context, parentLayer, out rootTransformNode, out var parentLeafTransform);
                parentLeafTransform.Children.Add(leafTransformNode);
            }
            else
            {
                rootTransformNode = leafTransformNode;
            }
#endif
        }


        // Returns a chain of CompositionContainerShape that define the transform for a layer.
        // The top of the chain is the rootTransform, the bottom is the leafTransform.
        void TranslateTransformOnContainerShapeForLayer(
            TranslationContext context,
            Layer layer,
            out CompositionContainerShape rootTransformNode,
            out CompositionContainerShape leafTransformNode)
        {
            // Create a ContainerVisual to apply the transform to.
            leafTransformNode = CreateContainerShape();

            // Apply the transform from the layer.
            TranslateAndApplyTransformToContainerShape(context, layer.Transform, leafTransformNode);
            if (_addDescriptions)
            {
                Describe(leafTransformNode, $"'{layer.Name}'.Transforms");
            }
#if NoTransformInheritance
            rootTransformNode = leafTransformNode;
#else
            // Translate the parent transform, if any.
            if (layer.Parent != null)
            {
                var parentLayer = context.Layers.GetLayerById(layer.Parent.Value);
                TranslateTransformOnContainerShapeForLayer(context, parentLayer, out rootTransformNode, out var parentLeafTransform);
                parentLeafTransform.Shapes.Add(leafTransformNode);
            }
            else
            {
                rootTransformNode = leafTransformNode;
            }
#endif
        }


        void TranslateAndApplyTransformToContainerVisual(TranslationContext context, Transform transform, ContainerVisual container)
        {
            var initialAnchor = Vector2(transform.Anchor.InitialValue);
            var initialPosition = Vector2(transform.Position.InitialValue);

            if (transform.Anchor.IsAnimated || transform.Position.IsAnimated ||
                transform.Anchor.Type == AnimatableVector3Type.XYZ || transform.Position.Type == AnimatableVector3Type.XYZ)
            {
                container.Properties.InsertVector2("Anchor", initialAnchor);
                container.Properties.InsertVector2("Position", initialPosition);
            }

            if (transform.Anchor.IsAnimated)
            {
                var centerPointExpression = CreateExpressionAnimation(
                    Expr.Vector3(
                            Expr.Scalar("my.Anchor.X"),
                            Expr.Scalar("my.Anchor.Y"),
                            Expr.Scalar(0)));
                centerPointExpression.SetReferenceParameter("my", container);
                StartAnimation(container, nameof(container.CenterPoint), centerPointExpression);
            }
            else
            {
                container.CenterPoint = Vector3DefaultIsZero(initialAnchor);
            }

            if (transform.Anchor.Type == AnimatableVector3Type.XYZ)
            {
                // TODO BLOCKED: 14632318 animationGroup Targets can't dot in
                var anchorValue = (AnimatableXYZ)transform.Anchor;
                ApplyScalarKeyFrameAnimation(context, anchorValue.X, container, "Anchor.X", "Anchor.X", null);
                ApplyScalarKeyFrameAnimation(context, anchorValue.Y, container, "Anchor.Y", "Anchor.Y", null);
            }
            else
            {
                ApplyVector2KeyFrameAnimation(context, (AnimatableVector3)transform.Anchor, container, "Anchor", "Anchor", null);
            }

            if (transform.Position.IsAnimated || transform.Anchor.IsAnimated)
            {
                var offsetExpression = CreateExpressionAnimation(
                    Expr.Vector3(
                        Expr.Subtract(Expr.Scalar("my.Position.X"), Expr.Scalar("my.Anchor.X")),
                        Expr.Subtract(Expr.Scalar("my.Position.Y"), Expr.Scalar("my.Anchor.Y")),
                        Expr.Scalar(0)));
                offsetExpression.SetReferenceParameter("my", container);
                StartAnimation(container, nameof(container.Offset), offsetExpression);
            }
            else
            {
                container.Offset = Vector3DefaultIsZero(initialPosition - initialAnchor);
            }

            if (transform.Position.Type == AnimatableVector3Type.XYZ)
            {
                // TODO BLOCKED: 14632318 animationGroup Targets can't dot in
                var anchorValue = (AnimatableXYZ)transform.Position;
                ApplyScalarKeyFrameAnimation(context, anchorValue.X, container, "Position.X", "Position.X", null);
                ApplyScalarKeyFrameAnimation(context, anchorValue.Y, container, "Position.Y", "Position.Y", null);
            }
            else
            {
                ApplyVector2KeyFrameAnimation(context, (AnimatableVector3)transform.Position, container, "Position", "Position", null);
            }

#if !NoScaling
            container.Scale = Vector3DefaultIsOne(transform.ScalePercent.InitialValue * (1 / 100.0));
            ApplyScaledVector3KeyFrameAnimation(context, (AnimatableVector3)transform.ScalePercent, 1 / 100.0, container, nameof(container.Scale), "Scale", null);
#endif

            container.RotationAngleInDegrees = FloatDefaultIsZero(transform.RotationDegrees.InitialValue);
            ApplyScalarKeyFrameAnimation(context, transform.RotationDegrees, container, nameof(container.RotationAngleInDegrees), "RotationAngleInDegress", null);

            if (transform.OpacityPercent.IsAnimated || transform.OpacityPercent.InitialValue != 100)
            {
                // TODO - apply opacity to the visual, and ensure it doesn't get pushed to brushes
            }
            // set Skew and Skew Axis
            // TODO: TransformMatrix --> for a Layer, does this clash with Visibility? Should I add an extra ContainerShape?
        }

        void TranslateAndApplyTransformToContainerShape(TranslationContext context, Transform transform, CompositionContainerShape container)
        {
            var initialAnchor = Vector2(transform.Anchor.InitialValue);
            var initialPosition = Vector2(transform.Position.InitialValue);

            if (transform.Anchor.IsAnimated || transform.Position.IsAnimated ||
                transform.Anchor.Type == AnimatableVector3Type.XYZ || transform.Position.Type == AnimatableVector3Type.XYZ)
            {
                container.Properties.InsertVector2("Anchor", initialAnchor);
                container.Properties.InsertVector2("Position", initialPosition);
            }

            if (transform.Anchor.IsAnimated)
            {
                var centerPointExpression = CreateExpressionAnimation(ExpressionFactory.MyAnchor2);
                centerPointExpression.SetReferenceParameter("my", container);
                StartAnimation(container, nameof(container.CenterPoint), centerPointExpression);
            }
            else
            {
                container.CenterPoint = Vector2DefaultIsZero(initialAnchor);
            }

            if (transform.Anchor.Type == AnimatableVector3Type.XYZ)
            {
                // TODO BLOCKED: 14632318 animationGroup Targets can't dot in
                var anchorValue = (AnimatableXYZ)transform.Anchor;
                ApplyScalarKeyFrameAnimation(context, anchorValue.X, container, "Anchor.X", "Anchor.X", null);
                ApplyScalarKeyFrameAnimation(context, anchorValue.Y, container, "Anchor.Y", "Anchor.Y", null);
            }
            else
            {
                ApplyVector2KeyFrameAnimation(context, (AnimatableVector3)transform.Anchor, container, "Anchor", "Anchor", null);
            }

            if (transform.Position.IsAnimated || transform.Anchor.IsAnimated)
            {
                var offsetExpression = CreateExpressionAnimation(ExpressionFactory.PositionMinusAnchor);
                offsetExpression.SetReferenceParameter("my", container);
                StartAnimation(container, nameof(container.Offset), offsetExpression);
            }
            else
            {
                container.Offset = Vector2DefaultIsZero(initialPosition - initialAnchor);
            }

            if (transform.Position.Type == AnimatableVector3Type.XYZ)
            {
                // TODO BLOCKED: 14632318 animationGroup Targets can't dot in
                var anchorValue = (AnimatableXYZ)transform.Position;
                ApplyScalarKeyFrameAnimation(context, anchorValue.X, container, "Position.X", "Position.X", null);
                ApplyScalarKeyFrameAnimation(context, anchorValue.Y, container, "Position.Y", "Position.Y", null);
            }
            else
            {
                ApplyVector2KeyFrameAnimation(context, (AnimatableVector3)transform.Position, container, "Position", "Position", null);
            }

#if !NoScaling
            container.Scale = Vector2DefaultIsOne(transform.ScalePercent.InitialValue * (1 / 100.0));
            ApplyScaledVector2KeyFrameAnimation(context, (AnimatableVector3)transform.ScalePercent, 1 / 100.0, container, nameof(container.Scale), "Scale", null);
#endif

            container.RotationAngleInDegrees = FloatDefaultIsZero(transform.RotationDegrees.InitialValue);
            ApplyScalarKeyFrameAnimation(context, transform.RotationDegrees, container, nameof(container.RotationAngleInDegrees), "RotationAngleInDegrees", null);

            // set Skew and Skew Axis
            // TODO: TransformMatrix --> for a Layer, does this clash with Visibility? Should I add an extra ContainerShape?
        }

        void StartAnimation(CompositionObject compObject, string target, ExpressionAnimation animation)
        {
            // Start the animation.
            compObject.StartAnimation(target, animation);
        }

        void StartAnimation(CompositionObject compObject, string target, KeyFrameAnimation_ animation, double scale = 1, double offset = 0)
        {
            Debug.Assert(offset >= 0);
            Debug.Assert(scale <= 1);
            Debug.Assert(animation.KeyFrameCount > 0);

            // Start the animation ...
            compObject.StartAnimation(target, animation);

            // ... but pause it immediately so that it doesn't react to time. Instead, bind
            // its progress to the progress of the composition.
            var controller = compObject.TryGetAnimationController(target);
            controller.Pause();

            // Bind it to the root visual's Progress property, scaling and offsetting if necessary.
            var key = new ScaleAndOffset(scale, offset);
            if (!_progressBindingAnimations.TryGetValue(key, out var bindingAnimation))
            {
                bindingAnimation = CreateExpressionAnimation(ExpressionFactory.ScaledAndOffsetRootProgress(scale, offset));
                bindingAnimation.SetReferenceParameter(c_rootName, _rootVisual);
                _progressBindingAnimations.Add(key, bindingAnimation);
            }

            // Bind the controller's Progress with a single Progress property on the scene root.
            // The Progress property provides the time reference for the animation.
            controller.StartAnimation("Progress", bindingAnimation);
        }

        void ApplyScalarKeyFrameAnimation(
            TranslationContext context,
            Animatable<double> value,
            CompositionObject targetObject,
            string targetPropertyName,
            string longDescription,
            string shortDescription)
            => ApplyScaledScalarKeyFrameAnimation(context, value, 1, targetObject, targetPropertyName, longDescription, shortDescription);

        void ApplyScaledScalarKeyFrameAnimation(
            TranslationContext context,
            Animatable<double> value,
            double scale,
            CompositionObject targetObject,
            string targetPropertyName,
            string longDescription,
            string shortDescription)
        {
            value = _lottieDataOptimizer.GetOptimized(value);
            if (value.IsAnimated)
            {
                GenericCreateCompositionKeyFrameAnimation(
                    context,
                    value,
                    CreateScalarKeyFrameAnimation,
                    (ca, progress, val, easing) => ca.InsertKeyFrame(progress, (float)(val * scale), easing),
                    null,
                    targetObject,
                    targetPropertyName,
                    longDescription,
                    shortDescription);
            }
        }

        void ApplyColorKeyFrameAnimation(
            TranslationContext context,
            Animatable<LottieData.Color> value,
            CompositionObject targetObject,
            string targetPropertyName,
            string longDescription,
            string shortDescription)
        {
            value = _lottieDataOptimizer.GetOptimized(value);
            if (value.IsAnimated)
            {
                GenericCreateCompositionKeyFrameAnimation(
                    context,
                    value,
                    CreateColorKeyFrameAnimation,
                    (ca, progress, val, easing) => ca.InsertKeyFrame(progress, Color(val), easing),
                    null,
                    targetObject,
                    targetPropertyName,
                    longDescription,
                    shortDescription);
            }
        }

        void ApplyPathKeyFrameAnimation(
            TranslationContext context,
            Animatable<PathGeometry> value,
            SolidColorFill.PathFillType fillType,
            CompositionObject targetObject,
            string targetPropertyName,
            string longDescription,
            string shortDescription)
        {
            value = _lottieDataOptimizer.GetOptimized(value);
            if (value.IsAnimated)
            {
                GenericCreateCompositionKeyFrameAnimation(
                    context,
                    value,
                    CreatePathKeyFrameAnimation,
                    (ca, progress, val, easing) => ca.InsertKeyFrame(progress, CompositionPathFromPathGeometry(val, fillType), easing),
                    null,
                    targetObject,
                    targetPropertyName,
                    longDescription,
                    shortDescription);
            }
        }

        void ApplyVector2KeyFrameAnimation(
            TranslationContext context,
            AnimatableVector3 value,
            CompositionObject targetObject,
            string targetPropertyName,
            string longDescription,
            string shortDescription)
            => ApplyScaledVector2KeyFrameAnimation(context, value, 1, targetObject, targetPropertyName, longDescription, shortDescription);

        void ApplyScaledVector2KeyFrameAnimation(
            TranslationContext context,
            AnimatableVector3 value,
            double scale,
            CompositionObject targetObject,
            string targetPropertyName,
            string longDescription,
            string shortDescription)
        {
            if (value.IsAnimated)
            {
                GenericCreateCompositionKeyFrameAnimation(
                    context,
                    value,
                    CreateVector2KeyFrameAnimation,
                    (ca, progress, val, easing) => ca.InsertKeyFrame(progress, Vector2(val * scale), easing),
                    (ca, progress, expr, easing) => ca.InsertExpressionKeyFrame(progress, scale != 1 ? Scale(expr, scale) : expr.ToString(), easing),
                    targetObject,
                    targetPropertyName,
                    longDescription,
                    shortDescription);
            }
        }

        void ApplyVector3KeyFrameAnimation(
            TranslationContext context,
            AnimatableVector3 value,
            CompositionObject targetObject,
            string targetPropertyName,
            string longDescription,
            string shortDescription)
            => ApplyScaledVector3KeyFrameAnimation(context, value, 1, targetObject, targetPropertyName, longDescription, shortDescription);

        void ApplyScaledVector3KeyFrameAnimation(
            TranslationContext context,
            AnimatableVector3 value,
            double scale,
            CompositionObject targetObject,
            string targetPropertyName,
            string longDescription,
            string shortDescription)
        {
            if (value.IsAnimated)
            {
                GenericCreateCompositionKeyFrameAnimation(
                    context,
                    value,
                    CreateVector3KeyFrameAnimation,
                    (ca, progress, val, easing) => ca.InsertKeyFrame(progress, Vector3(val) * (float)scale, easing),
                    (ca, progress, expr, easing) => ca.InsertExpressionKeyFrame(progress, scale != 1 ? Scale(expr, scale).ToString() : expr.ToString(), easing),
                    targetObject,
                    targetPropertyName,
                    longDescription,
                    shortDescription);
            }
        }

        void GenericCreateCompositionKeyFrameAnimation<CA, T>(
            TranslationContext context,
            Animatable<T> value,
            Func<CA> compositionAnimationFactory,
            Action<CA, float, T, CompositionEasingFunction> insertKeyFrame,
            Action<CA, float, Expr, CompositionEasingFunction> insertExpressionKeyFrame,
            CompositionObject targetObject,
            string targetPropertyName,
            string longDescription,
            string shortDescription) where CA : KeyFrameAnimation_ where T : IEquatable<T>
        {
            var compositionAnimation = compositionAnimationFactory();
            if (_addDescriptions)
            {
                Describe(compositionAnimation, longDescription, shortDescription);
            }
            compositionAnimation.Duration = _lc.Duration;

            // Get only the key frames that exist from at or just before the animation starts, and end at or just after the animation ends.
            var trimmedKeyFrames = _lottieDataOptimizer.GetTrimmed(value.KeyFrames, context.StartTime, context.EndTime).ToArray();

            if (trimmedKeyFrames.Length == 0)
            {
                // TODO - handle this earlier.
                return;
            }
            else if (trimmedKeyFrames.Length == 1)
            {
                // If only 1 keyframe is returned, it should always be the first keyframe.
                // TODO - this fires some times, which means that the non-animated value being used is not correct.
                //Debug.Assert(trimmedKeyFrames[0].Value.Equals(value.InitialValue));

                // TODO - handle this earlier
                return;
            }

            var firstKeyFrame = trimmedKeyFrames[0];
            var lastKeyFrame = trimmedKeyFrames[trimmedKeyFrames.Length - 1];

            var animationStartTime = firstKeyFrame.Frame;
            var animationEndTime = lastKeyFrame.Frame;

            if (firstKeyFrame.Frame > context.StartTime)
            {
                // TODO - we should just set an initial value rather than adding a keyframe, but
                //        at this point we don't have the ability to set a value (no access to
                //        the property). Could return a nullable with the initial value, except
                //        that not every T is a struct.

                // The first key frame is after the start of the animation. Create an extra keyframe at 0 to
                // set and hold an initial value until the first specified keyframe.
                insertKeyFrame(compositionAnimation, 0 /* progress */, firstKeyFrame.Value, CreateLinearEasingFunction() /* easing */);

                animationStartTime = context.StartTime;
            }

            if (lastKeyFrame.Frame < context.EndTime)
            {
                // The last key frame is before the end of the animation. 
                animationEndTime = context.EndTime;
            }

            var animationDuration = animationEndTime - animationStartTime;

            // The Math.Min is to deal with rounding errors that cause the scale to be slightly more than 1.
            var scale = Math.Min(context.DurationInFrames / animationDuration, 1.0);
            var offset = (context.StartTime - animationStartTime) / animationDuration;

            // Insert the keyframes with the progress adjusted so the first keyframe is at 0 and the remaining
            // progress values are scaled appropriately.
            var previousValue = firstKeyFrame.Value;
            var previousProgress = 0.0 - c_keyFrameProgressEpsilon;
            var rootReferenceRequired = false;
            var previousKeyFrameWasExpression = false;
            string progressMappingProperty = null;
            ScalarKeyFrameAnimation progressMappingAnimation = null;

            foreach (var keyFrame in trimmedKeyFrames)
            {
                var adjustedProgress = (keyFrame.Frame - animationStartTime) / animationDuration;

                if (keyFrame.SpatialControlPoint1 != default(Vector3) || keyFrame.SpatialControlPoint2 != default(Vector3))
                {
                    // TODO - should only be on Vector3. In which case, should they be on Animatable, or on something else?
                    if (typeof(T) != typeof(Vector3))
                    {
                        Debug.WriteLine("Spatial control point on non-Vector3 type");
                    }
                    var cp0 = Vector2((Vector3)(object)previousValue);
                    var cp1 = Vector2(keyFrame.SpatialControlPoint1);
                    var cp2 = Vector2(keyFrame.SpatialControlPoint2);
                    var cp3 = Vector2((Vector3)(object)keyFrame.Value);
                    CubicBezierFunction cb;

                    switch (keyFrame.Easing.Type)
                    {
                        case Easing.EasingType.Linear:
                        case Easing.EasingType.CubicBezier:
                            if (progressMappingProperty == null)
                            {
                                progressMappingProperty = $"t{_tCounter++}";
                                progressMappingAnimation = CreateScalarKeyFrameAnimation();
                                progressMappingAnimation.Duration = _lc.Duration;
                            }
#if LinearEasingOnSpatialBeziers
                            cb = CubicBezierFunction.Create(cp0, (cp0 + cp1), (cp2 + cp3), cp3, GetRemappedProgress(previousProgress, adjustedProgress));
#else
                            cb = CubicBezierFunction.Create(
                                cp0,
                                (cp0 + cp1),
                                (cp2 + cp3),
                                cp3,
                                Expr.Scalar($"{c_rootName}.{progressMappingProperty}"));
#endif
                            break;
                        case Easing.EasingType.Hold:
                            // Holds should never have interesting cubic beziers, so replace with one that is definitely colinear.
                            cb = CubicBezierFunction.Zero;
                            break;
                        default:
                            throw new InvalidOperationException();
                    }

                    if (cb.IsEquivalentToLinear || adjustedProgress == 0
#if !SpatialBeziers
                        || true
#endif
                        )
                    {
                        // The cubic bezier function is equivalent to a line, or its value starts at the start of the animation, so no need
                        // for an expression to do spatial beziers on it. Just use a regular key frame.

                        if (previousKeyFrameWasExpression)
                        {
                            // Ensure the previous expression doesn't continue being evaluated during the current keyframe.
                            // This is necessary because the expression is only defined from the previous progress to the current progress.
                            insertKeyFrame(compositionAnimation, (float)previousProgress + c_keyFrameProgressEpsilon, previousValue, CreateJumpStepEasingFunction());
                        }

                        // The easing for a keyframe at 0 is unimportant, so always use linear.
                        var easing = adjustedProgress == 0 ? LinearEasing.Instance : keyFrame.Easing;

                        insertKeyFrame(compositionAnimation, (float)adjustedProgress, keyFrame.Value, CreateCompositionEasingFunction(easing));
                        previousKeyFrameWasExpression = false;
                    }
                    else
                    {
                        // Expression key frame needed for a spatial bezier.

                        // Make the progress value just before the requested progress value
                        // so that there is room to add a key frame just after this to hold
                        // the final value. This is necessary so that the expression we're about
                        // to add won't get evaluated during the following segment.
                        if (adjustedProgress > 0)
                        {
                            adjustedProgress -= c_keyFrameProgressEpsilon;
                        }

#if !LinearEasingOnSpatialBeziers
                        // Add an animation to map from progress to t over the range of this key frame.
                        if (previousProgress > 0)
                        {
                            progressMappingAnimation.InsertKeyFrame((float)previousProgress + c_keyFrameProgressEpsilon, 0, CreateJumpStepEasingFunction());
                        }
                        progressMappingAnimation.InsertKeyFrame((float)adjustedProgress, 1, CreateCompositionEasingFunction(keyFrame.Easing));
#endif
                        insertExpressionKeyFrame(
                            compositionAnimation,
                            (float)adjustedProgress,
                            cb,                                 // Expression. 
                            CreateJumpStepEasingFunction());    // Jump to the final value so the expression is evaluated all the way through.
                        // Note that a reference to the root Visual is required by the animation because it
                        // is used in the expression.
                        rootReferenceRequired = true;
                        previousKeyFrameWasExpression = true;
                    }
                }
                else
                {

                    if (previousKeyFrameWasExpression)
                    {
                        // Ensure the previous expression doesn't continue being evaluated during the current keyframe.
                        insertKeyFrame(compositionAnimation, (float)previousProgress + c_keyFrameProgressEpsilon, previousValue, CreateJumpStepEasingFunction());
                    }

                    insertKeyFrame(compositionAnimation, (float)adjustedProgress, keyFrame.Value, CreateCompositionEasingFunction(keyFrame.Easing));
                    previousKeyFrameWasExpression = false;
                }
                previousValue = keyFrame.Value;
                previousProgress = adjustedProgress;
            }

            if (previousKeyFrameWasExpression && previousProgress < 1)
            {
                // Add a keyframe to hold the final value. Otherwise the expression on the last keyframe
                // will get evaluated outside the bounds of its keyframe.
                insertKeyFrame(compositionAnimation, (float)previousProgress + c_keyFrameProgressEpsilon, (T)(object)previousValue, CreateJumpStepEasingFunction());
            }

            // Add a reference to the root Visual if needed (i.e. if an expression keyframe was added).
            if (rootReferenceRequired)
            {
                compositionAnimation.SetReferenceParameter(c_rootName, _rootVisual);
            }

            // Start the animation scaled and offset.
            StartAnimation(targetObject, targetPropertyName, compositionAnimation, scale, offset);

            // Start the animation that maps from the Progress property to a t value for use by the spatial beziers.
            if (progressMappingAnimation != null && progressMappingAnimation.KeyFrameCount > 0)
            {
                _rootVisual.Properties.InsertScalar(progressMappingProperty, 0);
                StartAnimation(_rootVisual, progressMappingProperty, progressMappingAnimation);
            }
        }


        float GetInPointProgress(TranslationContext context, Layer layer)
        {
            var result = (layer.InPoint - context.StartTime) / context.DurationInFrames;

            return (float)result;
        }

        float GetOutPointProgress(TranslationContext context, Layer layer)
        {
            var result = (layer.OutPoint - context.StartTime) / context.DurationInFrames;

            return (float)result;
        }

        static string Scale(Expr expression, double scale)
        {
            return Expr.Multiply(Expr.Scalar(scale), expression).ToString();
        }

        sealed class TimeRemap : Expr
        {
            readonly double _tRangeLow;
            readonly double _tRangeHigh;
            readonly Expr _t;
            internal TimeRemap(double tRangeLow, double tRangeHigh, Expr t)
            {
                if (tRangeLow >= tRangeHigh)
                {
                    throw new ArgumentException();
                }

                _tRangeLow = tRangeLow;
                _tRangeHigh = tRangeHigh;
                _t = t;
            }

            public override Expr Simplified
            {
                get
                {
                    // Adjust t and (1-t) based on the given range. This will make T vary between
                    // 0..1 over the duration of the keyframe.
                    return Multiply(
                        Scalar(1 / (_tRangeHigh - _tRangeLow)),
                        Subtract(_t, Scalar(_tRangeLow)));
                }
            }
            public override string ToString() => Simplified.ToString();

            public override ExpressionType InferredType => new ExpressionType(TypeConstraint.Scalar);

        }

        // Returns the name of a variable on the root property set that advances linearly from 0 to 1 over the
        // given range of Progress.
        TimeRemap GetRemappedProgress(double tRangeLow, double tRangeHigh) =>
            new TimeRemap(tRangeLow, tRangeHigh, ExpressionFactory.RootProgress);

        int _tCounter = 0;
        struct RemappedProgressParameters
        {
            internal double tRangeLow;
            internal double tRangeHigh;
            internal Vector3 controlPoint1;
            internal Vector3 controlPoint2;
        }
        readonly Dictionary<RemappedProgressParameters, Expr> _remappedProgressExpressions = new Dictionary<RemappedProgressParameters, Expr>();

        // Returns the name of a variable on the root property set that advances from 0 to 1 over the
        // given range of Progress, using the given cubic bezier easing.
        Expr GetRemappedProgress(double tRangeLow, double tRangeHigh, Vector3 controlPoint1, Vector3 controlPoint2)
        {
            // Use an existing property if a matching one has already been created.
            var parameters = new RemappedProgressParameters { tRangeLow = tRangeLow, tRangeHigh = tRangeHigh, controlPoint1 = controlPoint1, controlPoint2 = controlPoint2 };
            if (!_remappedProgressExpressions.TryGetValue(parameters, out Expr result))
            {
                // Create a property to hold the value.
                var propertyName = $"t{_tCounter++}";
                _rootVisual.Properties.InsertScalar(propertyName, 0);

                // Create the remapping expression.
                var remap = new TimeRemap(tRangeLow, tRangeHigh, ExpressionFactory.RootProgress);

                // Create a cubic bezier function to map the time using the given control points.
                var oneOne = Vector2(1);
                var easing = CubicBezierFunction.Create(Vector2(0), Vector2(controlPoint1), Vector2(controlPoint2), oneOne, remap);

                var animation = CreateExpressionAnimation(Expr.Scalar($"({easing}).Y"));
                animation.SetReferenceParameter(c_rootName, _rootVisual);
                StartAnimation(_rootVisual, propertyName, animation);
                result = Expr.Scalar($"{c_rootName}.{propertyName}");
                _remappedProgressExpressions.Add(parameters, result);
            }
            return result;
        }

        static SolidColorFill.PathFillType GetPathFillType(SolidColorFill fill) => fill == null ? SolidColorFill.PathFillType.EvenOdd : fill.FillType;

        CompositionPath CompositionPathFromPathGeometry(PathGeometry pathGeometry, SolidColorFill.PathFillType fillType)
        {
            using (var builder = new WinCompData.Mgcg.CanvasPathBuilder(null))
            {
                var canvasFilledRegionDetermination = FilledRegionDetermination(fillType);

                builder.SetFilledRegionDetermination(canvasFilledRegionDetermination);
                builder.BeginFigure(Vector2(pathGeometry.Start));

                foreach (var bezier in pathGeometry.Beziers)
                {
                    builder.AddCubicBezier(Vector2(bezier.ControlPoint1), Vector2(bezier.ControlPoint2), Vector2(bezier.Vertex));
                }

                builder.EndFigure(pathGeometry.IsClosed ? CanvasFigureLoop.Closed : CanvasFigureLoop.Open);
                return new CompositionPath(CanvasGeometry.CreatePath(builder));
            }
        }

        Animatable<Color> MultiplyAnimatableColorByAnimatableOpacityPercent(
            Animatable<Color> color,
            Animatable<double> opacityPercent)
        {
            color = _lottieDataOptimizer.GetOptimized(color);
            opacityPercent = _lottieDataOptimizer.GetOptimized(opacityPercent);

            if (opacityPercent == null)
            {
                return color;
            }

            if (color.IsAnimated)
            {
                if (opacityPercent.IsAnimated)
                {

                    // TOOD: multiply animations to produce a new set of key frames for the opacity-multiplied color.
                    _unsupported.OpacityAndColorAnimatedTogether();
                    return color;
                }
                else
                {
                    // Multiply the color animation by the single opacity value.
                    return new Animatable<Color>(
                        initialValue: MultiplyColorByOpacityPercent(color.InitialValue, opacityPercent.InitialValue),
                        keyFrames: color.KeyFrames.Select(kf =>
                            new KeyFrame<Color>(
                                kf.Frame,
                                MultiplyColorByOpacityPercent(kf.Value, opacityPercent.InitialValue),
                                kf.SpatialControlPoint1,
                                kf.SpatialControlPoint2,
                                kf.Easing)),
                        propertyIndex: null);
                }
            }
            else if (opacityPercent.IsAnimated)
            {
                // Color is not animated.
                return MultiplyColorByAnimatableOpacityPercent(color.InitialValue, opacityPercent);
            }
            else
            {
                // Multiply color by opacity
                var nonAnimatedMultipliedColor = MultiplyColorByOpacityPercent(color.InitialValue, opacityPercent.InitialValue);
                return new Animatable<Color>(nonAnimatedMultipliedColor, null);
            }
        }

        Animatable<Color> MultiplyColorByAnimatableOpacityPercent(
            Color color,
            Animatable<double> opacityPercent)
        {
            if (!opacityPercent.IsAnimated)
            {
                return new Animatable<Color>(MultiplyColorByOpacityPercent(color, opacityPercent.InitialValue), null);
            }
            else
            {
                // Multiply the single color value by the opacity animation.
                return new Animatable<Color>(
                    initialValue: MultiplyColorByOpacityPercent(color, opacityPercent.InitialValue),
                    keyFrames: opacityPercent.KeyFrames.Select(kf =>
                        new KeyFrame<Color>(
                            kf.Frame,
                            MultiplyColorByOpacityPercent(color, kf.Value),
                            kf.SpatialControlPoint1,
                            kf.SpatialControlPoint2,
                            kf.Easing)),
                    propertyIndex: null);
            }
        }


        static Color MultiplyColorByOpacityPercent(Color color, double opacityPercent)
            => opacityPercent == 100 ? color
            : LottieData.Color.FromArgb(color.A * opacityPercent / 100, color.R, color.G, color.B);


        CompositionColorBrush CreateAnimatedColorBrush(TranslationContext context, Color color, Animatable<double> opacityPercent)
        {
            var multipliedColor = MultiplyColorByAnimatableOpacityPercent(color, opacityPercent);
            return CreateAnimatedColorBrush(context, multipliedColor);
        }

        CompositionColorBrush CreateAnimatedColorBrush(TranslationContext context, Animatable<Color> color, Animatable<double> opacityPercent)
        {
            var multipliedColor = MultiplyAnimatableColorByAnimatableOpacityPercent(color, opacityPercent);
            return CreateAnimatedColorBrush(context, multipliedColor);
        }

        CompositionColorBrush CreateAnimatedColorBrush(TranslationContext context, Animatable<Color> color)
        {
            if (color.IsAnimated)
            {
                var result = CreateColorBrush(color.InitialValue);
                ApplyColorKeyFrameAnimation(context, color, result, nameof(result.Color), "Color", null);
                return result;
            }
            else
            {
                return CreateNonAnimatedColorBrush(color.InitialValue);
            }
        }

        CompositionColorBrush CreateNonAnimatedColorBrush(Color color)
        {
            if (!_nonAnimatedColorBrushes.TryGetValue(color, out var result))
            {
                result = CreateColorBrush(color);
                _nonAnimatedColorBrushes.Add(color, result);
            }
            return result;
        }

        public void Dispose()
        {
        }

        CompositionEllipseGeometry CreateEllipseGeometry()
        {
            return _c.CreateEllipseGeometry();
        }

        CompositionPathGeometry CreatePathGeometry()
        {
            return _c.CreatePathGeometry();
        }

        CompositionPathGeometry CreatePathGeometry(CompositionPath path)
        {
            return _c.CreatePathGeometry(path);
        }

        CompositionRectangleGeometry CreateRectangleGeometry()
        {
            return _c.CreateRectangleGeometry();
        }

        CompositionRoundedRectangleGeometry CreateRoundedRectangleGeometry()
        {
            return _c.CreateRoundedRectangleGeometry();
        }

        CompositionColorBrush CreateColorBrush(Color color)
        {
            return _c.CreateColorBrush(Color(color));
        }

        CompositionEasingFunction CreateCompositionEasingFunction(Easing easingFunction)
        {
            if (easingFunction == null)
            {
                return null;
            }

            switch (easingFunction.Type)
            {
                case Easing.EasingType.Linear:
                    return CreateLinearEasingFunction();
                case Easing.EasingType.CubicBezier:
                    return CreateCubicBezierEasingFunction((CubicBezierEasing)easingFunction);
                case Easing.EasingType.Hold:
                    return CreateHoldStepEasingFunction();
                default:
                    throw new InvalidOperationException();
            }
        }

        LinearEasingFunction CreateLinearEasingFunction()
        {
            if (_linearEasingFunction == null)
            {
                _linearEasingFunction = _c.CreateLinearEasingFunction();
            }
            return _linearEasingFunction;
        }

        CubicBezierEasingFunction CreateCubicBezierEasingFunction(CubicBezierEasing cubicBezierEasing)
        {
            if (!_cubicBezierEasingFunctions.TryGetValue(cubicBezierEasing, out var result))
            {
                // WinComp does not support control points with components > 1. Clamp the values to 1.
                var controlPoint1 = ClampedVector2(cubicBezierEasing.ControlPoint1);
                var controlPoint2 = ClampedVector2(cubicBezierEasing.ControlPoint2);

                result = _c.CreateCubicBezierEasingFunction(controlPoint1, controlPoint2);
                _cubicBezierEasingFunctions.Add(cubicBezierEasing, result);
            }
            return result;
        }

        // Returns an easing function that holds its initial value and jumps to the final value at the end.
        StepEasingFunction CreateHoldStepEasingFunction()
        {
            if (_holdStepEasingFunction == null)
            {
                _holdStepEasingFunction = _c.CreateStepEasingFunction(1);
                _holdStepEasingFunction.IsFinalStepSingleFrame = true;
            }
            return _holdStepEasingFunction;
        }

        // Returns an easing function that jumps immediately to its final value.
        StepEasingFunction CreateJumpStepEasingFunction()
        {
            if (_jumpStepEasingFunction == null)
            {
                _jumpStepEasingFunction = _c.CreateStepEasingFunction(1);
                _jumpStepEasingFunction.IsInitialStepSingleFrame = true;
            }
            return _jumpStepEasingFunction;
        }

        ScalarKeyFrameAnimation CreateScalarKeyFrameAnimation()
        {
            return _c.CreateScalarKeyFrameAnimation();
        }

        ColorKeyFrameAnimation CreateColorKeyFrameAnimation()
        {
            return _c.CreateColorKeyFrameAnimation();
        }

        PathKeyFrameAnimation CreatePathKeyFrameAnimation()
        {
            return _c.CreatePathKeyFrameAnimation();
        }

        Vector2KeyFrameAnimation CreateVector2KeyFrameAnimation()
        {
            return _c.CreateVector2KeyFrameAnimation();
        }

        Vector3KeyFrameAnimation CreateVector3KeyFrameAnimation()
        {
            return _c.CreateVector3KeyFrameAnimation();
        }

        InsetClip CreateInsetClip()
        {
            return _c.CreateInsetClip();
        }

        CompositionContainerShape CreateContainerShape()
        {
            return _c.CreateContainerShape();
        }

        ContainerVisual CreateContainerVisual()
        {
            return _c.CreateContainerVisual();
        }

        ShapeVisual CreateShapeVisual()
        {
            return _c.CreateShapeVisual();
        }

        CompositionSpriteShape CreateSpriteShape()
        {
            return _c.CreateSpriteShape();
        }

        ExpressionAnimation CreateExpressionAnimation(Expr expression)
        {
            return _c.CreateExpressionAnimation(expression);
        }

        static CompositionStrokeCap StrokeCap(SolidColorStroke.LineCapType lineCapType)
        {
            switch (lineCapType)
            {
                case SolidColorStroke.LineCapType.Butt:
                    return CompositionStrokeCap.Flat;
                case SolidColorStroke.LineCapType.Round:
                    return CompositionStrokeCap.Round;
                case SolidColorStroke.LineCapType.Projected:
                    return CompositionStrokeCap.Square;
                default:
                    throw new InvalidOperationException();
            }
        }

        static CompositionStrokeLineJoin StrokeLineJoin(SolidColorStroke.LineJoinType lineJoinType)
        {
            switch (lineJoinType)
            {
                case SolidColorStroke.LineJoinType.Bevel:
                    return CompositionStrokeLineJoin.Bevel;
                case SolidColorStroke.LineJoinType.Miter:
                    return CompositionStrokeLineJoin.Miter;
                case SolidColorStroke.LineJoinType.Round:
                default:
                    return CompositionStrokeLineJoin.Round;
            }
        }

        static CanvasFilledRegionDetermination FilledRegionDetermination(SolidColorFill.PathFillType fillType)
        {
            return (fillType == SolidColorFill.PathFillType.Winding) ? CanvasFilledRegionDetermination.Winding : CanvasFilledRegionDetermination.Alternate;
        }

        static CanvasGeometryCombine GeometryCombine(MergePaths.MergeMode mergeMode)
        {
            switch (mergeMode)
            {
                case LottieData.MergePaths.MergeMode.Add: return CanvasGeometryCombine.Union;
                case LottieData.MergePaths.MergeMode.Subtract: return CanvasGeometryCombine.Exclude;
                case LottieData.MergePaths.MergeMode.Intersect: return CanvasGeometryCombine.Intersect;
                // TODO - find out what merge should be - maybe should be a Union.
                case LottieData.MergePaths.MergeMode.Merge:
                case LottieData.MergePaths.MergeMode.ExcludeIntersections: return CanvasGeometryCombine.Xor;
                default:
                    throw new InvalidOperationException();
            }
        }

        // Sets a description on an object.
        void Describe(IDescribable obj, string longDescription, string shortDescription = null)
        {
            // This method should only be called if the user wanted descriptions.
            Debug.Assert(_addDescriptions);

            // Descriptions should never get set more than once.
            Debug.Assert(obj.ShortDescription == null);
            Debug.Assert(obj.LongDescription == null);

            obj.ShortDescription = shortDescription ?? longDescription;
            obj.LongDescription = longDescription;
        }

        static WinCompData.Wui.Color Color(LottieData.Color color) =>
            WinCompData.Wui.Color.FromArgb((byte)(255 * color.A), (byte)(255 * color.R), (byte)(255 * color.G), (byte)(255 * color.B));

        static float Float(double value) => (float)value;

        static float? FloatDefaultIsZero(double value) => value == 0 ? null : (float?)value;
        static float? FloatDefaultIsOne(double value) => value == 1 ? null : (float?)value;

        static WinCompData.Sn.Matrix3x2 Matrix3x2Identity => WinCompData.Sn.Matrix3x2.Identity;

        static WinCompData.Sn.Vector2 Vector2(LottieData.Vector3 vector3) => Vector2(vector3.X, vector3.Y);
        static WinCompData.Sn.Vector2 Vector2(double x, double y) => new WinCompData.Sn.Vector2((float)x, (float)y);
        static WinCompData.Sn.Vector2 Vector2(float x, float y) => new WinCompData.Sn.Vector2(x, y);
        static WinCompData.Sn.Vector2 Vector2(float x) => new WinCompData.Sn.Vector2(x, x);
        static WinCompData.Sn.Vector2? Vector2DefaultIsOne(LottieData.Vector3 vector2) =>
            vector2.X == 1 && vector2.Y == 1 ? null : (WinCompData.Sn.Vector2?)Vector2(vector2);
        static WinCompData.Sn.Vector2? Vector2DefaultIsZero(WinCompData.Sn.Vector2 vector2) =>
            vector2.X == 0 && vector2.Y == 0 ? null : (WinCompData.Sn.Vector2?)vector2;
        static WinCompData.Sn.Vector2 ClampedVector2(LottieData.Vector3 vector3) => ClampedVector2((float)vector3.X, (float)vector3.Y);
        static WinCompData.Sn.Vector2 ClampedVector2(float x, float y) => Vector2(Clamp(x, 0, 1), Clamp(y, 0, 1));

        static WinCompData.Sn.Vector3 Vector3(double x, double y, double z) => new WinCompData.Sn.Vector3((float)x, (float)y, (float)z);
        static WinCompData.Sn.Vector3 Vector3(LottieData.Vector3 vector3) => new WinCompData.Sn.Vector3((float)vector3.X, (float)vector3.Y, (float)vector3.Z);
        static WinCompData.Sn.Vector3? Vector3DefaultIsZero(WinCompData.Sn.Vector2 vector2) =>
                    vector2.X == 0 && vector2.Y == 0 ? null : (WinCompData.Sn.Vector3?)Vector3(vector2);
        static WinCompData.Sn.Vector3? Vector3DefaultIsOne(WinCompData.Sn.Vector3 vector3) =>
                    vector3.X == 1 && vector3.Y == 1 && vector3.Z == 1 ? null : (WinCompData.Sn.Vector3?)vector3;
        static WinCompData.Sn.Vector3? Vector3DefaultIsOne(LottieData.Vector3 vector3) => Vector3DefaultIsOne(new WinCompData.Sn.Vector3((float)vector3.X, (float)vector3.Y, (float)vector3.Z));
        static WinCompData.Sn.Vector3 Vector3(WinCompData.Sn.Vector2 vector2) => Vector3(vector2.X, vector2.Y, 0);

        static float Clamp(float value, float min, float max)
        {
            Debug.Assert(min <= max);
            return Math.Min(Math.Max(min, value), max);
        }


        // The context in which to translate a composition.
        // This is used to ensure that layers in a PreComp are translated in the context
        // of the PreComp.
        sealed class TranslationContext
        {
            Layer Layer { get; }
            internal TranslationContext ContainingContext { get; }

            // A set of layers that can be referenced by id.
            internal LayerCollection Layers { get; }

            internal double Width { get; }
            internal double Height { get; }

            // The start time of the current layer, in composition time.
            internal double StartTime { get; }
            internal double EndTime => StartTime + DurationInFrames;
            internal double DurationInFrames { get; }

            // Constructs the root context.
            internal TranslationContext(LottieComposition lottieComposition)
            {
                Layers = lottieComposition.Layers;
                StartTime = lottieComposition.InPoint;
                DurationInFrames = lottieComposition.OutPoint - lottieComposition.InPoint;
                Width = lottieComposition.Width;
                Height = lottieComposition.Height;
            }

            // Constructs a context for the given layer.
            internal TranslationContext(TranslationContext context, PreCompLayer layer, LayerCollection layers)
            {
                Layer = layer;
                // Precomps define a new temporal and spatial space.
                Width = layer.Width;
                Height = layer.Height;
                StartTime = context.StartTime - layer.StartTime;

                ContainingContext = context;
                Layers = layers;
                DurationInFrames = context.DurationInFrames;
            }
        }

        // A pair of doubles used as a key in a dictionary.
        sealed class ScaleAndOffset
        {
            readonly double _scale;
            readonly double _offset;

            internal ScaleAndOffset(double scale, double offset)
            {
                _scale = scale;
                _offset = offset;
            }

            public override bool Equals(object obj)
            {
                var other = obj as ScaleAndOffset;
                if (other == null)
                {
                    return false;
                }
                return other._scale == _scale && other._offset == _offset;
            }

            public override int GetHashCode() => _scale.GetHashCode() ^ _offset.GetHashCode();
        }
    }
}
