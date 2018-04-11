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
using WinCompData;
using WinCompData.Mgc;
using WinCompData.Mgcg;
using LottieData;
using System;
using System.Collections.Generic;
using System.Linq;
using LottieData.Optimization;
using System.Diagnostics;

namespace Lottie
{
    /// <summary>
    /// Translates a <see cref="LottieData.LottieComposition"/> to an equivalent <see cref="Visual"/>.
    /// </summary>
#if PUBLIC
    public
#endif
    sealed class LottieToVisualTranslator : IDisposable
    {
        readonly LottieData.LottieComposition _lc;
        readonly HashSet<string> _issues = new HashSet<string>();
        readonly bool _strictTranslation;
        readonly bool _annotate;
        readonly Compositor _c;
        readonly ContainerVisual _rootVisual;
        readonly ContainerVisual _lottieCoordinateSpaceRoot;
        readonly Dictionary<ScaleAndOffset, ExpressionAnimation> _progressBindingAnimations = new Dictionary<ScaleAndOffset, ExpressionAnimation>();
        readonly CanvasDevice _canvasDevice;
        readonly Optimizer _lottieDataOptimizer = new Optimizer();
        // Holds CubicBezierEasingFunctions for reuse when they have the same parameters.
        readonly Dictionary<CubicBezierEasing, CubicBezierEasingFunction> _cubicBezierEasingFunctions = new Dictionary<CubicBezierEasing, CubicBezierEasingFunction>();
        // Holds ColorBrushes that are not animated and can therefore be reused.
        readonly Dictionary<Color, CompositionColorBrush> _nonAnimatedColorBrushes = new Dictionary<Color, CompositionColorBrush>();
        // Holds a LinearEasingFunction that can be reused in multiple animations.
        LinearEasingFunction _linearEasingFunction;
        // Holds a StepEasingFunction that can be reused in multiple animations.
        StepEasingFunction _holdStepEasingFunction;

        /// <summary>
        /// The name of the property on the resulting <see cref="Visual"/> that controls the progress
        /// of the animation. Setting this property (directly or with an animation)
        /// between 0 and 1 controls the position of the animation.
        /// </summary>
        public static string ProgressPropertyName => "AnimationProgress";

        LottieToVisualTranslator(
            LottieData.LottieComposition lottieComposition,
            Compositor compositor,
            bool strictTranslation,
            bool annotateCompositionObjects)
        {
            _lc = lottieComposition;
            _c = compositor;
            _strictTranslation = strictTranslation;
            _annotate = annotateCompositionObjects;
            _canvasDevice = CanvasDevice.GetSharedDevice();

            // Create the root.
            _rootVisual = CreateContainerVisual();
            if (_annotate)
            {
                _rootVisual.Comment = "Lottie";
            }

            // Add the master progress property to the visual.
            _rootVisual.Properties.InsertScalar(ProgressPropertyName, 0);

            // Add a container below the root to translate between the coordinate space
            // of the root and the Lottie coordinate space.
            _lottieCoordinateSpaceRoot = CreateContainerVisual();
            if (_annotate)
            {
                _lottieCoordinateSpaceRoot.Comment = "Lottie coordinate space root";
            }
            _rootVisual.Children.Add(_lottieCoordinateSpaceRoot);

            // Add expressions to translate between coordinate spaces. This must
            // be done with expressions because the root visual may be resized
            // at any time.
            _lottieCoordinateSpaceRoot.Size = Vector2(_lc.Width, _lc.Height);

            // Scale the coordinate space visual so that both dimensions fit within the
            // size of the root visual. This provides the same functionality as a ViewBox.
            // This is a Uniform stretch.
            // TODO - we could add a UniformScale property and change it depending on Uniform or UniformToFill
            // TOOD - UniformToFill would require a clip.
            var viewboxScaleExpression = CreateExpressionAnimation(
                $"Vector3(root.Size.X/{_lc.Width} < root.Size.Y/{_lc.Height} ? root.Size.X/{_lc.Width} : root.Size.Y/{_lc.Height}," + // X
                        $"root.Size.X/{_lc.Width} < root.Size.Y/{_lc.Height} ? root.Size.X/{_lc.Width} : root.Size.Y/{_lc.Height}," + // Y
                        "1)" // Z
                );
            viewboxScaleExpression.SetReferenceParameter("root", _rootVisual);
            _lottieCoordinateSpaceRoot.StartAnimation(nameof(_lottieCoordinateSpaceRoot.Scale), viewboxScaleExpression);

            // Offset the coordinate space visual to keep it centered in the root visual.
            var viewboxOffsetExpression = CreateExpressionAnimation(
                $"Vector3((root.Size.X-({_lc.Width} * lc.Scale.X))/2," +
                        $"(root.Size.Y-({_lc.Height} * lc.Scale.Y))/2, 0)");
            viewboxOffsetExpression.SetReferenceParameter("root", _rootVisual);
            viewboxOffsetExpression.SetReferenceParameter("lc", _lottieCoordinateSpaceRoot);
            _lottieCoordinateSpaceRoot.StartAnimation(nameof(_lottieCoordinateSpaceRoot.Offset), viewboxOffsetExpression);
        }

        /// <summary>
        /// Attempts to translates the given <see cref="LottieData.LottieComposition"/>.
        /// </summary>
        /// <param name="lottieComposition">The <see cref="LottieData.LottieComposition"/> to translate.</param>
        /// <param name="compositor">A <see cref="Compositor"/> used to create the <see cref="CompositionObject"/>s.</param>
        /// <param name="visual">The <see cref="Visual"/> that contains the translated Lottie.</param>
        /// <param name="resources">Resources that must be kept alive as long as <paramref name="visual"/> is alive, and should be Disposed when no longer required.</param>
        /// <param name="translationIssues">A list of issues that were encountered during the translation.</param>
        public static bool TryTranslateLottieComposition(
            LottieData.LottieComposition lottieComposition,
            Windows.UI.Composition.Compositor compositor,
            bool strictTranslation,
            out Visual visual,
            out IEnumerable<string> translationIssues) =>
            TryTranslateLottieComposition(
                lottieComposition,
                compositor,
                strictTranslation,
                false,
                out visual,
                out translationIssues);

        /// <summary>
        /// Attempts to translates the given <see cref="LottieData.LottieComposition"/>.
        /// </summary>
        /// <param name="lottieComposition">The <see cref="LottieData.LottieComposition"/> to translate.</param>
        /// <param name="compositor">A <see cref="Compositor"/> used to create the <see cref="CompositionObject"/>s.</param>
        /// <param name="annotateCompositionObjects">Add a string to the .Comment property of the <see cref="CompositionObjects"/>s to help with debugging.</param>
        /// <param name="visual">The <see cref="Visual"/> that contains the translated Lottie.</param>
        /// <param name="resources">Resources that must be kept alive as long as <paramref name="visual"/> is alive, and should be Disposed when no longer required.</param>
        /// <param name="translationIssues">A list of issues that were encountered during the translation.</param>
        public static bool TryTranslateLottieComposition(
            LottieData.LottieComposition lottieComposition,
            Windows.UI.Composition.Compositor compositor,
            bool strictTranslation,
            bool annotateCompositionObjects,
            out Visual visual,
            out IEnumerable<string> translationIssues)
        {
            // Set up the translator.
            using (var translator = new LottieToVisualTranslator(
                lottieComposition,
                new WinCompData.Compositor(),
                strictTranslation,
                annotateCompositionObjects))
            {

                // Translate the Lottie content to a CompositionShapeVisual tree.
                translator.Translate();

                // Set the out parameters.
                visual = translator._rootVisual;
                translationIssues = translator._issues;
            }

            return true;
        }


        void Translate()
        {
            var context = new TranslationContext(_lc);

            // Get the layers in painting order.
            var translatedLayers =
                (from layer in _lc.Layers.GetLayersBottomToTop()
                 let translatedLayer = TranslateLayer(context, layer)
                 where translatedLayer != null
                 select translatedLayer).ToArray();

            foreach (var tl in translatedLayers)
            {
                _lottieCoordinateSpaceRoot.Children.Add(tl);
            }
        }

        // Translates a Lottie layer into a Visual or null. Visual is used instead of a
        // CompositionContainerShape in order to support clipping that is required
        // by PreComp layers.
        // Note that ShapeVisual clips to its size.
        Visual TranslateLayer(TranslationContext context, Layer layer)
        {
            if (layer.IsHidden)
            {
                return null;
            }

            switch (layer.Type)
            {
                case Layer.LayerType.Image:
                    return TranslateImageLayerToVisual(context, (ImageLayer)layer);
                case Layer.LayerType.Null:
                    // Null layers only exist to hold transforms when declared as parents of other layers.
                    return null;
                case Layer.LayerType.PreComp:
                    return TranslatePreCompLayerToVisual(context, (PreCompLayer)layer);
                case Layer.LayerType.Shape:
                    return TranslateShapeLayerToVisual(context, (ShapeLayer)layer);
                case Layer.LayerType.Solid:
                    return TranslateSolidLayerToVisual(context, (SolidLayer)layer);
                case Layer.LayerType.Text:
                    return TranslateTextLayerToVisual(context, (TextLayer)layer);
                default:
                    throw new InvalidOperationException();
            }
        }


        // Returns a chain of ContainerShape that define the transforms for a layer.
        // The top of the chain is the rootTransform, the bottom is the leafTransform.
        void CreateContainerShapeTransformChain(
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
            TranslateTransformOnContainerShapeForLayer(context, layer, out rootNode, out var leafTransformNode);
            contentsNode = leafTransformNode;

            // Implement the Visibility for the layer. Only needed if the layer becomes visible after
            // the LottieComposition's in point, or it becomes invisible before the LottieComposition's out point.

            // Convert the layer's in point and out point into absolute progress (0..1) values.
            var inProgress = GetInPointProgress(context, layer);
            var outProgress = GetOutPointProgress(context, layer);

            if (inProgress > 0 || outProgress < 1)
            {
                // If it's ever visible.
                // TODO - if not, don't create the layer.
                if (inProgress < 1)
                {
                    // Insert another node to hold the visiblity property.
                    contentsNode = CreateContainerShape();
                    leafTransformNode.Shapes.Add(contentsNode);

                    // Insert Visibility flag into the node's PropertySet.
                    if (inProgress <= 0)
                    {
                        // Initially visible
                        contentsNode.Properties.InsertScalar("Visibility", 1);

                        // If it ever goes inivisble again.
                        if (outProgress < 1)
                        {
#if !NoInvisibility
                            var stepAnimation = CreateScalarKeyFrameAnimation();
                            stepAnimation.InsertKeyFrame((float)outProgress, 0, CreateHoldStepEasingFunction());
                            stepAnimation.Duration = _lc.Duration;
                            stepAnimation.Target = "Visibility";
                            StartAnimation(contentsNode, stepAnimation);
#endif
                        }
                    }
                    else
                    {
#if !NoInvisibility
                        // Initially invisible.
                        contentsNode.Properties.InsertScalar("Visibility", 0);
#else
                        contentsNode.Properties.InsertScalar("Visibility", 1);
#endif
                        var stepAnimation = CreateScalarKeyFrameAnimation();
                        stepAnimation.InsertKeyFrame((float)inProgress, 1, CreateHoldStepEasingFunction());

                        // If it ever goes invisible again.
                        if (outProgress < 1)
                        {
                            stepAnimation.InsertKeyFrame((float)outProgress, 0, CreateHoldStepEasingFunction());
                        }
                        stepAnimation.Duration = _lc.Duration;
                        stepAnimation.Target = "Visibility";
#if !NoInvisibility
                        StartAnimation(contentsNode, stepAnimation);
#endif
                    }

                    // TODO - only create this matrix if the layer has a Visibility animation.
                    // There is no Visibility property on Visual, so simulate it with a 
                    // Matrix3x2 expression that animates between identity and
                    // degenerate.
                    var compositionMatrixAnim = CreateExpressionAnimation("Matrix3x2(contents.Visibility,0,0,contents.Visibility,0,0)");
                    compositionMatrixAnim.SetReferenceParameter("contents", contentsNode);
                    compositionMatrixAnim.Target = "TransformMatrix";

                    StartAnimation(contentsNode, compositionMatrixAnim);
                }
                else
                {
                    // TODO: Fix Visibility correctly with Progress 
                }
            }

            if (_annotate)
            {
                contentsNode.Comment = contentsNode.Comment != null
                    ? $"{contentsNode.Comment} & '{layer.Name}'.Contents"
                    : $"'{layer.Name}'.Contents";
            }

            // Return the root of the chain of transforms (might be the same as the contents node)
            if (_annotate)
            {
                rootNode.Comment = string.Join(' ', $"{layer.Type}Layer:'{layer.Name}'", rootNode.Comment);
            }
        }


        // Returns a chain of ContainerVisual that define the transforms for a layer.
        // The top of the chain is the rootTransform, the bottom is the leafTransform.
        void CreateContainerVisualTransformChain(
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
            TranslateTransformOnContainerVisualForLayer(context, layer, out rootNode, out var leafTransformNode);
            contentsNode = leafTransformNode;


            // Implement the Visibility for the layer. Only needed if the layer becomes visible after
            // the LottieComposition's in point, or it becomes invisible before the LottieComposition's out point.

            // Convert the layer's in point and out point into absolute progress (0..1) values.
            var inProgress = GetInPointProgress(context, layer);
            var outProgress = GetOutPointProgress(context, layer);

            if (inProgress > 0 || outProgress < 1)
            {
                // If it's ever visible.
                // TODO - if not, don't create the layer.
                if (inProgress < 1)
                {
                    // Insert another node to hold the visiblity property.
                    contentsNode = CreateContainerVisual();
                    leafTransformNode.Children.Add(contentsNode);

                    // Insert Visibility flag into the node's PropertySet.
                    if (inProgress <= 0)
                    {
                        // Initially visible
                        contentsNode.Properties.InsertScalar("Visibility", 1);

                        // If it ever goes inivisble again.
                        if (outProgress < 1)
                        {
#if !NoInvisibility
                            var stepAnimation = CreateScalarKeyFrameAnimation();
                            stepAnimation.InsertKeyFrame((float)outProgress, 0, CreateHoldStepEasingFunction());
                            stepAnimation.Duration = _lc.Duration;
                            stepAnimation.Target = "Visibility";
                            StartAnimation(contentsNode, stepAnimation);
#endif
                        }
                    }
                    else
                    {
#if !NoInvisibility
                        // Initially invisible.
                        contentsNode.Properties.InsertScalar("Visibility", 0);
#else
                        contentsNode.Properties.InsertScalar("Visibility", 1);
#endif
                        var stepAnimation = CreateScalarKeyFrameAnimation();
                        stepAnimation.InsertKeyFrame((float)inProgress, 1, CreateHoldStepEasingFunction());

                        // If it ever goes invisible again.
                        if (outProgress < 1)
                        {
                            stepAnimation.InsertKeyFrame((float)outProgress, 0, CreateHoldStepEasingFunction());
                        }
                        stepAnimation.Duration = _lc.Duration;
                        stepAnimation.Target = "Visibility";
#if !NoInvisibility
                        StartAnimation(contentsNode, stepAnimation);
#endif
                    }

                    // TODO - only create this matrix if the layer has a Visibility animation.
                    // There is no Visibility property on Visual, so simulate it with a 
                    // Matrix4x4 expression that animates between identity and
                    // degenerate.
                    var compositionMatrixAnim = CreateExpressionAnimation("Matrix4x4(contents.Visibility,0,0,0,0,contents.Visibility,0,0,0,0,contents.Visibility,0,0,0,0,contents.Visibility)");
                    compositionMatrixAnim.SetReferenceParameter("contents", contentsNode);
                    compositionMatrixAnim.Target = "TransformMatrix";

                    StartAnimation(contentsNode, compositionMatrixAnim);
                }
                else
                {
                    // TODO: Fix Visibility correctly with Progress 
                }
            }

            if (_annotate)
            {
                contentsNode.Comment = contentsNode.Comment != null
                    ? $"{contentsNode.Comment} & '{layer.Name}'.Contents"
                    : $"'{layer.Name}'.Contents";

                rootNode.Comment = string.Join(' ', $"{layer.Type}Layer:'{layer.Name}'", rootNode.Comment);
            }
        }


        Visual TranslateImageLayerToVisual(TranslationContext context, ImageLayer layer)
        {
            // Not yet implemented. Currently CompositionShape does not support SurfaceBrush as of RS4.
            // TODO - but this is a visual now, so we could support it.
            return null;
        }

        Visual TranslatePreCompLayerToVisual(TranslationContext context, PreCompLayer layer)
        {
            // Create the transform chain.
            CreateContainerVisualTransformChain(context, layer, out var rootNode, out var contentsNode);

            var result = CreateContainerVisual();
            if (_annotate)
            {
                result.Comment = $"{layer.Type}Layer:'{layer.Name}'->'{layer.RefId}'";
            }

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
                    var referencedLayers = ((LayerCollectionAsset)referencedLayersAsset).Layers;
                    // Push the reference layers onto the stack. These will be used to look up parent transforms for layers under this precomp.
                    var ctxt = new TranslationContext(context, layer, referencedLayers);
                    foreach (var subLayer in referencedLayers.GetLayersBottomToTop())
                    {
                        var translatedLayer = TranslateLayer(ctxt, subLayer);
                        if (translatedLayer != null)
                        {
                            contentsNode.Children.Add(translatedLayer);
                        }
                    }
                    break;
                default:
                    throw new InvalidOperationException();
            }


            return result;
        }

        sealed class ShapeContentContext
        {
            readonly LottieToVisualTranslator _owner;
            internal SolidColorStroke Stroke { get; private set; }
            internal SolidColorFill Fill { get; private set; }
            internal TrimPath TrimPath { get; private set; }
            internal RoundedCorner RoundedCorner { get; private set; }
            // Opacity is not part of the Lottie context for shapes. But because WinComp
            // doesn't support opacity on shapes, the opacity is inherited from
            // the Transform and passed through to the brushes here.
            internal Animatable<double> OpacityPercent { get; private set; }

            internal ShapeContentContext(LottieToVisualTranslator owner)
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
                        case ShapeContentType.SolidColorStroke:
                            // Set the stroke to be used from this point on.
                            Stroke = (SolidColorStroke)popped;
                            break;

                        case ShapeContentType.LinearGradientStroke:
                        case ShapeContentType.RadialGradientStroke:
                            _owner.Unsupported("Gradient stroke");
                            break;

                        case ShapeContentType.SolidColorFill:
                            Fill = (SolidColorFill)popped;
                            break;

                        case ShapeContentType.LinearGradientFill:
                        case ShapeContentType.RadialGradientFill:
                            _owner.Unsupported("Gradient fill");
                            break;
                        case ShapeContentType.TrimPath:
                            TrimPath = (TrimPath)popped;
                            break;

                        case ShapeContentType.RoundedCorner:
                            RoundedCorner = (RoundedCorner)popped;
                            break;
                        default: return;
                    }
                    stack.Pop();
                }
            }

            internal void UpdateOpacityFromTransform(Transform transform)
            {
                if (transform == null)
                {
                    return;
                }

                OpacityPercent = MultiplyOpacityPercents(OpacityPercent, transform.OpacityPercent);
            }

            Animatable<double> MultiplyOpacityPercents(Animatable<double> a, Animatable<double> b)
            {
                if (a == null || (!a.IsAnimated && a.InitialValue == 100))
                {
                    return b;
                }

                if (b == null || (!b.IsAnimated && b.InitialValue == 100))
                {
                    return a;
                }

                if (a.IsAnimated && b.IsAnimated)
                {
                    _owner.Unsupported("Animation multiplication.");
                }

                if (a.IsAnimated)
                {
                    var bScale = b.InitialValue;
                    return new Animatable<double>(
                        initialValue: a.InitialValue * bScale,
                        keyFrames: a.KeyFrames.Select(kf => new KeyFrame<double>(kf.Frame, kf.Value * bScale, kf.Easing)),
                        propertyIndex: null);
                }
                else
                {
                    return MultiplyOpacityPercents(b, a);
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
        }

        // May return null if the layer does not produce any renderable content.
        Visual TranslateShapeLayerToVisual(TranslationContext context, ShapeLayer layer)
        {
            CreateContainerShapeTransformChain(context, layer, out var rootNode, out var contentsNode);

            var shapeContext = new ShapeContentContext(this);
            shapeContext.UpdateOpacityFromTransform(layer.Transform);

            var contents = TranslateShapeLayerContents(context, shapeContext, layer.Contents, contentsNode).ToArray();
            if (contents.Length > 0)
            {
                contentsNode.Shapes.AddRange(contents);

                var result = CreateShapeVisual();
                if (_annotate)
                {
                    result.Comment = $"{layer.Type}Layer:'{layer.Name}'";
                }

                // ShapeVisual clips to its size, so if the size isn't set nothing will be visible.
#if !NoClipping
                result.Size = Vector2(context.Width, context.Height);
#else
                result.Size = Vector2(5000, 5000);
#endif
                result.Shapes.Add(rootNode);
                return result;
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
                if (_annotate)
                {
                    compositionNode.Comment = group.Name;
                }
                compositionNode.Shapes.AddRange(contents);
                return compositionNode;
            }
            else
            {
                return null;
            }
        }

        IEnumerable<CompositionShape> TranslateShapeLayerContents(TranslationContext context, ShapeContentContext shapeContext, IEnumerable<ShapeLayerContent> contents, CompositionContainerShape container)
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
                        TranslateAndApplyTransform(context, (Transform)shapeContent, container);
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
                        Unsupported("Polystar");
                        break;
                    case ShapeContentType.Repeater:
                        Unsupported("Repeater");
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
            var combineMode = GeometryCombine(mergeMode);
            var pathFillType = context.Fill == null ? SolidColorFill.PathFillType.EvenOdd : context.Fill.FillType;
            var geometries = CreateCanvasGeometries(context, stack, pathFillType).ToArray();

            if (geometries.Length == 0)
            {
                return null;
            }

            var accumulator = geometries[0];
            for (var i = 1; i < geometries.Length; i++)
            {
                accumulator = accumulator.CombineWith(geometries[i], Matrix3x2Identity, combineMode);
            }
            return accumulator;
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
                        Unsupported("Repeater");
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
                        Unsupported("Polystar");
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }

        }

        CanvasGeometry CreateWin2dPathGeometry(Shape path, SolidColorFill.PathFillType fillType)
        {
            if (path.PathData.IsAnimated)
            {
                Unsupported("Combining of shapes that are animated");
            }

            var pathData = path.PathData.InitialValue;
            var beziers = pathData.Beziers.ToArray();

            using (var builder = new CanvasPathBuilder(_canvasDevice))
            {
                builder.SetFilledRegionDetermination(FilledRegionDetermination(fillType));
                if (beziers.Length == 0)
                {
                    builder.BeginFigure(Vector2(0));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                }
                else
                {
                    builder.BeginFigure(Vector2(pathData.Start));
                    foreach (var segment in beziers)
                    {
                        builder.AddCubicBezier(Vector2(segment.ControlPoint1), Vector2(segment.ControlPoint2), Vector2(segment.Vertex));
                    }
                    builder.EndFigure(pathData.IsClosed ? CanvasFigureLoop.Closed : CanvasFigureLoop.Open);
                }
                return CanvasGeometry.CreatePath(builder);
            }
        }

        CanvasGeometry CreateWin2dEllipseGeometry(Ellipse ellipse)
        {
            var ellipsePosition = ellipse.Position;
            var ellipseDiameter = ellipse.Diameter;

            if (ellipsePosition.IsAnimated || ellipseDiameter.IsAnimated)
            {
                Unsupported("Combining of shapes that are animated");
            }

            var xRadius = ellipseDiameter.InitialValue.X / 2;
            var yRadius = ellipseDiameter.InitialValue.Y / 2;

            return CanvasGeometry.CreateEllipse(
                _canvasDevice,
                (float)(ellipsePosition.InitialValue.X - (xRadius / 2)),
                (float)(ellipsePosition.InitialValue.Y - (yRadius / 2)),
                (float)xRadius,
                (float)yRadius);
        }

        CanvasGeometry CreateWin2dRectangleGeometry(ShapeContentContext context, Rectangle rectangle)
        {
            var position = rectangle.Position;
            var size = rectangle.Size;
            // If a Rectangle is in the context, use it to override the corner radius.
            var cornerRadius = context.RoundedCorner != null ? context.RoundedCorner.Radius : rectangle.CornerRadius;

            if (position.IsAnimated || size.IsAnimated || cornerRadius.IsAnimated)
            {
                Unsupported("Combining of shapes that are animated");
            }

            var width = size.InitialValue.X;
            var height = size.InitialValue.Y;
            var radius = cornerRadius.InitialValue;

            return CanvasGeometry.CreateRoundedRectangle(
                _canvasDevice,
                (float)(position.InitialValue.X - (width / 2)),
                (float)(position.InitialValue.Y - (height / 2)),
                (float)width,
                (float)height,
                (float)radius,
                (float)radius);
        }

        CompositionShape TranslateEllipseContent(TranslationContext context, ShapeContentContext shapeContext, Ellipse shapeContent)
        {
            // An ellipse is represented as a SpriteShape with a CompositionEllipseGeometry.
            var compositionSpriteShape = CreateSpriteShape();

            var compositionEllipseGeometry = CreateEllipseGeometry();
            compositionSpriteShape.Geometry = compositionEllipseGeometry;
            if (_annotate)
            {
                compositionSpriteShape.Comment = shapeContent.Name;
                compositionEllipseGeometry.Comment = $"{shapeContent.Name}.EllipseGeometry";
            }

            compositionEllipseGeometry.Center = Vector2(shapeContent.Position.InitialValue);
            ApplyVector2KeyFrameAnimation(context, (AnimatableVector3)shapeContent.Position, compositionEllipseGeometry, "Center");

            compositionEllipseGeometry.Radius = Vector2(shapeContent.Diameter.InitialValue) * 0.5F;
            ApplyScaledVector2KeyFrameAnimation(context, (AnimatableVector3)shapeContent.Diameter, 0.5, compositionEllipseGeometry, "Radius");

            TranslateAndApplyShapeContentContext(context, shapeContext, compositionSpriteShape);

            return compositionSpriteShape;
        }

        CompositionShape TranslateRectangleContent(TranslationContext context, ShapeContentContext shapeContext, Rectangle shapeContent)
        {
            var compositionRectangle = CreateSpriteShape();

            if (!shapeContent.CornerRadius.IsAnimated && shapeContent.CornerRadius.InitialValue == 0)
            {
                // Use a non-rounded rectangle geometry.
                var geometry = CreateRectangleGeometry();
                compositionRectangle.Geometry = geometry;

                // Map Rectangle's position to RoundedRectangleGeometry.Offset by using custom property, Position, and an ExpressionAnimation
                geometry.Properties.InsertVector2("Position", Vector2(shapeContent.Position.InitialValue));

                // ExpressionAnimation to compensate for default centerpoint being top-left vs geometric center
                var compositionOffsetExpression = CreateExpressionAnimation("Vector2(my.Position.X - (my.Size.X/2), my.Position.Y - (my.Size.Y/2))");
                compositionOffsetExpression.SetReferenceParameter("my", geometry);
                compositionOffsetExpression.Target = "Offset";
                StartAnimation(geometry, compositionOffsetExpression);

                ApplyVector2KeyFrameAnimation(context, (AnimatableVector3)shapeContent.Position, geometry, nameof(Rectangle.Position));

                // Map Rectangle's size to RoundedRectangleGeometry.Size
                geometry.Size = Vector2(shapeContent.Size.InitialValue);
                ApplyVector2KeyFrameAnimation(context, (AnimatableVector3)shapeContent.Size, geometry, nameof(Rectangle.Size));

            }
            else
            {
                // Use a rounded rectangle geometry.
                var geometry = CreateRoundedRectangleGeometry();
                compositionRectangle.Geometry = geometry;

                // Map Rectangle's position to RoundedRectangleGeometry.Offset by using custom property, Position, and an ExpressionAnimation
                geometry.Properties.InsertVector2("Position", Vector2(shapeContent.Position.InitialValue));

                // ExpressionAnimation to compensate for default centerpoint being top-left vs geometric center
                var compositionOffsetExpression = CreateExpressionAnimation("Vector2(my.Position.X - (my.Size.X/2), my.Position.Y - (my.Size.Y/2))");
                compositionOffsetExpression.SetReferenceParameter("my", geometry);
                compositionOffsetExpression.Target = "Offset";
                StartAnimation(geometry, compositionOffsetExpression);

                ApplyVector2KeyFrameAnimation(context, (AnimatableVector3)shapeContent.Position, geometry, "Position");

                // Map Rectangle's size to RoundedRectangleGeometry.Size
                geometry.Size = Vector2(shapeContent.Size.InitialValue);
                ApplyVector2KeyFrameAnimation(context, (AnimatableVector3)shapeContent.Size, geometry, nameof(geometry.Size));

                // Map Rectangle's size to RoundedRectangleGeometry.CornerRadius
                // If a RoundedRectangle is in the context, use it to override the corner radius.
                var cornerRadius = shapeContext.RoundedCorner != null ? shapeContext.RoundedCorner.Radius : shapeContent.CornerRadius;
                if (cornerRadius.IsAnimated || cornerRadius.InitialValue != 0)
                {
                    geometry.CornerRadius = Vector2((float)cornerRadius.InitialValue);
                    ApplyScalarKeyFrameAnimation(context, cornerRadius, geometry, "CornerRadius.X");
                    ApplyScalarKeyFrameAnimation(context, cornerRadius, geometry, "CornerRadius.Y");
                }
            }

            TranslateAndApplyShapeContentContext(context, shapeContext, compositionRectangle);

            if (_annotate)
            {
                compositionRectangle.Comment = shapeContent.Name;
                compositionRectangle.Geometry.Comment = $"{shapeContent.Name}.RectangleGeometry";
            }

            return compositionRectangle;
        }

        CompositionShape TranslatePathContent(TranslationContext context, ShapeContentContext shapeContext, Shape shapeContent)
        {
            // Map Path's Geometry data to PathGeometry.Path
            var geometry = shapeContent.PathData;

            // A path is represented as a SpriteShape with a CompositionPathGeometry.
            var compositionSpriteShape = CreateSpriteShape();

            var compositionPathGeometry = CreatePathGeometry();
            compositionSpriteShape.Geometry = compositionPathGeometry;
            compositionPathGeometry.Path = CompositionPathFromPathGeometry(geometry.InitialValue, GetPathFillType(shapeContext.Fill));

            if (_annotate)
            {
                compositionSpriteShape.Comment = shapeContent.Name;
                compositionPathGeometry.Comment = $"{shapeContent.Name}.PathGeometry";
            }

            ApplyPathKeyFrameAnimation(context, geometry, GetPathFillType(shapeContext.Fill), compositionPathGeometry, "Path");

            TranslateAndApplyShapeContentContext(context, shapeContext, compositionSpriteShape);

            return compositionSpriteShape;
        }

        void TranslateAndApplyShapeContentContext(TranslationContext context, ShapeContentContext shapeContext, CompositionSpriteShape shape)
        {
            shape.FillBrush = TranslateShapeFill(context, shapeContext.Fill, shapeContext.OpacityPercent);
            TranslateAndApplyStroke(context, shapeContext.Stroke, shape, shapeContext.OpacityPercent);
            TranslateAndApplyTrimPath(context, shapeContext.TrimPath, shape.Geometry);
        }

        void TranslateAndApplyTrimPath(TranslationContext context, TrimPath trimPath, CompositionGeometry geometry)
        {
            if (trimPath == null)
            {
                return;
            }

            geometry.TrimStart = FloatDefaultIsZero(trimPath.StartPercent.InitialValue / 100);
            ApplyScaledScalarKeyFrameAnimation(context, trimPath.StartPercent, 1 / 100.0, geometry, nameof(geometry.TrimStart));

            geometry.TrimEnd = FloatDefaultIsOne(trimPath.EndPercent.InitialValue / 100);
            ApplyScaledScalarKeyFrameAnimation(context, trimPath.EndPercent, 1 / 100.0, geometry, nameof(geometry.TrimEnd));

            geometry.TrimOffset = FloatDefaultIsZero(trimPath.OffsetDegrees.InitialValue / 360);
            ApplyScaledScalarKeyFrameAnimation(context, trimPath.OffsetDegrees, 1 / 360.0, geometry, nameof(geometry.TrimOffset));
        }

        void TranslateAndApplyStroke(TranslationContext context, SolidColorStroke shapeStroke, CompositionSpriteShape sprite, Animatable<double> opacityPercent)
        {
            if (shapeStroke == null || (!shapeStroke.Thickness.IsAnimated && shapeStroke.Thickness.InitialValue == 0))
            {
                return;
            }

            // A ShapeStroke is represented as a CompositionColorBrush and Stroke properties on the relevant SpriteShape.

            // Map ShapeStroke's color to SpriteShape.StrokeBrush

            sprite.StrokeBrush = CreateAnimatedColorBrush(context, MultiplyAnimatableColorByAnimatableOpacityPercent(shapeStroke.Color, shapeStroke.OpacityPercent), opacityPercent);

            // Map ShapeStroke's width to SpriteShape.StrokeThickness
            sprite.StrokeThickness = (float)shapeStroke.Thickness.InitialValue;
            ApplyScalarKeyFrameAnimation(context, shapeStroke.Thickness, sprite, nameof(sprite.StrokeThickness));

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
            ApplyScalarKeyFrameAnimation(context, shapeStroke.DashOffset, sprite, nameof(sprite.StrokeDashOffset));
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


        Visual TranslateSolidLayerToVisual(TranslationContext context, SolidLayer layer)
        {

            CreateContainerVisualTransformChain(context, layer, out var rootNode, out var contentsNode);

            var shapeVisual = CreateShapeVisual();
            contentsNode.Children.Add(shapeVisual);

            var rectangleGeometry = CreateRectangleGeometry();
            rectangleGeometry.Size = Vector2(layer.Width, layer.Height);

            var rectangle = CreateSpriteShape();
            rectangle.Geometry = rectangleGeometry;

            // TODO - the opacity in the transform needs to be taken into consideration here
            var brush = CreateNonAnimatedColorBrush(layer.Color);

            rectangle.FillBrush = brush;

            if (_annotate)
            {
                rectangle.Comment = "SolidLayerRectangle";
                rectangleGeometry.Comment = rectangle.Comment + ".RectangleGeometry";
            }

            if (_annotate)
            {
                shapeVisual.Comment = $"{layer.Type}Layer:'{layer.Name}'";
            }

            shapeVisual.Size = Vector2(context.Width, context.Height);
            shapeVisual.Shapes.Add(rectangle);
            return rootNode;
        }

        Visual TranslateTextLayerToVisual(TranslationContext context, TextLayer layer)
        {
            // Text layers are not yet suported.
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
            TranslateAndApplyTransform(context, layer.Transform, leafTransformNode);
            if (_annotate)
            {
                leafTransformNode.Comment = $"'{layer.Name}'.Transforms";
            }

#if NoTransformInheritance
            rootTransformNode = leafTransformNode;
#else
            // Translate the parent transform, if any.
            if (layer.ParentId != null)
            {
                var parentLayer = context.Layers.GetLayerById(layer.ParentId.Value);
                TranslateTransformOnContainerVisualForLayer(context, parentLayer, out rootTransformNode, out var parentLeafTransform);

                if (_annotate)
                {
                    rootTransformNode.Comment = $"'{layer.Name}'.AncestorTransformFrom_{parentLayer.Name}";
                }

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
            TranslateAndApplyTransform(context, layer.Transform, leafTransformNode);
            if (_annotate)
            {
                leafTransformNode.Comment = $"'{layer.Name}'.Transforms";
            }

#if NoTransformInheritance
            rootTransformNode = leafTransformNode;
#else
            // Translate the parent transform, if any.
            if (layer.ParentId != null)
            {
                var parentLayer = context.Layers.GetLayerById(layer.ParentId.Value);
                TranslateTransformOnContainerShapeForLayer(context, parentLayer, out rootTransformNode, out var parentLeafTransform);

                if (_annotate)
                {
                    rootTransformNode.Comment = $"'{layer.Name}'.AncestorTransformFrom_{parentLayer.Name}";
                }

                parentLeafTransform.Shapes.Add(leafTransformNode);
            }
            else
            {
                rootTransformNode = leafTransformNode;
            }
#endif
        }


        void TranslateAndApplyTransform(TranslationContext context, Transform transform, ContainerVisual container)
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
                var centerPointExpression = CreateExpressionAnimation("Vector3(my.Anchor.X, my.Anchor.Y, 0)");
                centerPointExpression.SetReferenceParameter("my", container);
                centerPointExpression.Target = nameof(container.CenterPoint);
                StartAnimation(container, centerPointExpression);
            }
            else
            {
                container.CenterPoint = Vector3DefaultIsZero(initialAnchor);
            }

            if (transform.Anchor.Type == AnimatableVector3Type.XYZ)
            {
                // TODO BLOCKED: 14632318 animationGroup Targets can't dot in
                var anchorValue = (AnimatableXYZ)transform.Anchor;
                ApplyScalarKeyFrameAnimation(context, anchorValue.X, container, "Anchor.X");
                ApplyScalarKeyFrameAnimation(context, anchorValue.Y, container, "Anchor.Y");
            }
            else
            {
                ApplyVector2KeyFrameAnimation(context, (AnimatableVector3)transform.Anchor, container, "Anchor");
            }

            if (transform.Position.IsAnimated || transform.Anchor.IsAnimated)
            {
                var offsetExpression = CreateExpressionAnimation("Vector3(my.Position.X - my.Anchor.X, my.Position.Y - my.Anchor.Y, 0)");
                offsetExpression.SetReferenceParameter("my", container);
                offsetExpression.Target = nameof(container.Offset);
                StartAnimation(container, offsetExpression);
            }
            else
            {
                container.Offset = Vector3DefaultIsZero(initialPosition - initialAnchor);
            }

            if (transform.Position.Type == AnimatableVector3Type.XYZ)
            {
                // TODO BLOCKED: 14632318 animationGroup Targets can't dot in
                var anchorValue = (AnimatableXYZ)transform.Position;
                ApplyScalarKeyFrameAnimation(context, anchorValue.X, container, "Position.X");
                ApplyScalarKeyFrameAnimation(context, anchorValue.Y, container, "Position.Y");
            }
            else
            {
                ApplyVector2KeyFrameAnimation(context, (AnimatableVector3)transform.Position, container, "Position");
            }

#if !NoScaling
            container.Scale = Vector3DefaultIsOne(transform.ScalePercent.InitialValue * (1 / 100.0));
            ApplyScaledVector3KeyFrameAnimation(context, (AnimatableVector3)transform.ScalePercent, 1 / 100.0, container, nameof(container.Scale));
#endif

            container.RotationAngleInDegrees = FloatDefaultIsZero(transform.RotationDegrees.InitialValue);
            ApplyScalarKeyFrameAnimation(context, transform.RotationDegrees, container, nameof(container.RotationAngleInDegrees));

            // set Skew and Skew Axis
            // TODO: TransformMatrix --> for a Layer, does this clash with Visibility? Should I add an extra ContainerShape?
        }

        void TranslateAndApplyTransform(TranslationContext context, Transform transform, CompositionContainerShape container)
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
                var centerPointExpression = CreateExpressionAnimation("my.Anchor");
                centerPointExpression.SetReferenceParameter("my", container);
                centerPointExpression.Target = nameof(container.CenterPoint);
                StartAnimation(container, centerPointExpression);
            }
            else
            {
                container.CenterPoint = Vector2DefaultIsZero(initialAnchor);
            }

            if (transform.Anchor.Type == AnimatableVector3Type.XYZ)
            {
                // TODO BLOCKED: 14632318 animationGroup Targets can't dot in
                var anchorValue = (AnimatableXYZ)transform.Anchor;
                ApplyScalarKeyFrameAnimation(context, anchorValue.X, container, "Anchor.X");
                ApplyScalarKeyFrameAnimation(context, anchorValue.Y, container, "Anchor.Y");
            }
            else
            {
                ApplyVector2KeyFrameAnimation(context, (AnimatableVector3)transform.Anchor, container, "Anchor");
            }

            if (transform.Position.IsAnimated || transform.Anchor.IsAnimated)
            {
                var offsetExpression = CreateExpressionAnimation("my.Position - my.Anchor");
                offsetExpression.SetReferenceParameter("my", container);
                offsetExpression.Target = nameof(container.Offset);
                StartAnimation(container, offsetExpression);
            }
            else
            {
                container.Offset = Vector2DefaultIsZero(initialPosition - initialAnchor);
            }

            if (transform.Position.Type == AnimatableVector3Type.XYZ)
            {
                // TODO BLOCKED: 14632318 animationGroup Targets can't dot in
                var anchorValue = (AnimatableXYZ)transform.Position;
                ApplyScalarKeyFrameAnimation(context, anchorValue.X, container, "Position.X");
                ApplyScalarKeyFrameAnimation(context, anchorValue.Y, container, "Position.Y");
            }
            else
            {
                ApplyVector2KeyFrameAnimation(context, (AnimatableVector3)transform.Position, container, "Position");
            }

#if !NoScaling
            container.Scale = Vector2DefaultIsOne(transform.ScalePercent.InitialValue * (1 / 100.0));
            ApplyScaledVector2KeyFrameAnimation(context, (AnimatableVector3)transform.ScalePercent, 1 / 100.0, container, nameof(container.Scale));
#endif

            container.RotationAngleInDegrees = FloatDefaultIsZero(transform.RotationDegrees.InitialValue);
            ApplyScalarKeyFrameAnimation(context, transform.RotationDegrees, container, nameof(container.RotationAngleInDegrees));

            // set Skew and Skew Axis
            // TODO: TransformMatrix --> for a Layer, does this clash with Visibility? Should I add an extra ContainerShape?
        }

        void StartAnimation(CompositionObject compObject, ExpressionAnimation animation)
        {
            // Start the animation.
            compObject.StartAnimation(animation.Target, animation);
        }

        void StartAnimation(CompositionObject compObject, KeyFrameAnimation_ animation, double scale = 1, double offset = 0)
        {
            Debug.Assert(offset >= 0);
            Debug.Assert(scale <= 1);

            // Start the animation ...
            compObject.StartAnimation(animation.Target, animation);

            // ... but pause it immediately so that it doesn't react to time. Instead, bind
            // its progress to the progress of the composition.
            var controller = compObject.TryGetAnimationController(animation.Target);
            controller.Pause();

            // Bind it to the root visual's Progress property, scaling and offsetting if necessary.
            var key = new ScaleAndOffset(scale, offset);
            if (!_progressBindingAnimations.TryGetValue(key, out var bindingAnimation))
            {
                var expr = $"root.{ProgressPropertyName}";

                if (scale != 1)
                {
                    expr = $"{expr}*{scale.ToString("0.0###########")}";
                }
                if (offset != 0)
                {
                    expr = $"{expr}+{offset.ToString("0.0###########")}";
                }

                bindingAnimation = CreateExpressionAnimation(expr);
                bindingAnimation.SetReferenceParameter("root", _rootVisual);
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
            string targetPropertyName)
            => ApplyScaledScalarKeyFrameAnimation(context, value, 1, targetObject, targetPropertyName);

        void ApplyScaledScalarKeyFrameAnimation(
            TranslationContext context,
            Animatable<double> value,
            double scale,
            CompositionObject targetObject,
            string targetPropertyName)
        {
            value = _lottieDataOptimizer.GetOptimized(value);
            if (value.IsAnimated)
            {
                GenericCreateCompositionKeyFrameAnimation(
                    context,
                    value,
                    CreateScalarKeyFrameAnimation,
                    (ca, progress, val, easing) => ca.InsertKeyFrame(progress, (float)(val * scale), easing),
                    targetObject,
                    targetPropertyName);
            }
        }

        void ApplyColorKeyFrameAnimation(
            TranslationContext context,
            Animatable<LottieData.Color> value,
            CompositionObject targetObject,
            string targetPropertyName)
        {
            value = _lottieDataOptimizer.GetOptimized(value);
            if (value.IsAnimated)
            {
                GenericCreateCompositionKeyFrameAnimation(
                    context,
                    value,
                    CreateColorKeyFrameAnimation,
                    (ca, progress, val, easing) => ca.InsertKeyFrame(progress, Color(val), easing),
                    targetObject,
                    targetPropertyName);
            }
        }

        void ApplyPathKeyFrameAnimation(
            TranslationContext context,
            Animatable<PathGeometry> value,
            SolidColorFill.PathFillType fillType,
            CompositionObject targetObject,
            string targetPropertyName)
        {
            value = _lottieDataOptimizer.GetOptimized(value);
            if (value.IsAnimated)
            {
                GenericCreateCompositionKeyFrameAnimation(
                    context,
                    value,
                    CreatePathKeyFrameAnimation,
                    (ca, progress, val, easing) => ca.InsertKeyFrame(progress, CompositionPathFromPathGeometry(val, fillType), easing),
                    targetObject,
                    targetPropertyName);
            }
        }

        void ApplyVector2KeyFrameAnimation(
            TranslationContext context,
            AnimatableVector3 value,
            CompositionObject targetObject,
            string targetPropertyName)
            => ApplyScaledVector2KeyFrameAnimation(context, value, 1, targetObject, targetPropertyName);

        void ApplyScaledVector2KeyFrameAnimation(
            TranslationContext context,
            AnimatableVector3 value,
            double scale,
            CompositionObject targetObject,
            string targetPropertyName)
        {
            if (value.IsAnimated)
            {
                GenericCreateCompositionKeyFrameAnimation(
                    context,
                    value,
                    CreateVector2KeyFrameAnimation,
                    (ca, progress, val, easing) => ca.InsertKeyFrame(progress, Vector2(val) * (float)scale, easing),
                    targetObject,
                    targetPropertyName);
            }
        }

        void ApplyVector3KeyFrameAnimation(
            TranslationContext context,
            AnimatableVector3 value,
            CompositionObject targetObject,
            string targetPropertyName)
            => ApplyScaledVector3KeyFrameAnimation(context, value, 1, targetObject, targetPropertyName);

        void ApplyScaledVector3KeyFrameAnimation(
            TranslationContext context,
            AnimatableVector3 value,
            double scale,
            CompositionObject targetObject,
            string targetPropertyName)
        {
            if (value.IsAnimated)
            {
                GenericCreateCompositionKeyFrameAnimation(
                    context,
                    value,
                    CreateVector3KeyFrameAnimation,
                    (ca, progress, val, easing) => ca.InsertKeyFrame(progress, Vector3(val) * (float)scale, easing),
                    targetObject,
                    targetPropertyName);
            }
        }

        void GenericCreateCompositionKeyFrameAnimation<CA, T>(
            TranslationContext context,
            Animatable<T> value,
            Func<CA> compositionAnimationFactory,
            Action<CA, float, T, CompositionEasingFunction> insertKeyFrame,
            CompositionObject targetObject,
            string targetPropertyName) where CA : KeyFrameAnimation_ where T : IEquatable<T>
        {
            var compositionAnimation = compositionAnimationFactory();
            compositionAnimation.Duration = _lc.Duration;
            compositionAnimation.Target = targetPropertyName;

            // Get only the key frames that exist from at or just before the animation starts, and end at or just after the animation ends.
            var trimmedKeyFrames = _lottieDataOptimizer.GetTrimmed(value.KeyFrames, context.StartTime, context.EndTime).ToArray();

            if (trimmedKeyFrames.Length == 0)
            {
                // TODO - handle this earlier.
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

            var scale = context.DurationInFrames / animationDuration;
            var offset = (context.StartTime - animationStartTime) / animationDuration;

            // Insert the keyframes with the progress adjusted so the first keyframe is at 0 and the remaining
            // progress values are scaled appropriately.
            foreach (var keyFrame in trimmedKeyFrames)
            {
                var adjustedProgress = (keyFrame.Frame - animationStartTime) / animationDuration;

                insertKeyFrame(compositionAnimation, (float)adjustedProgress, keyFrame.Value, CreateCompositionEasingFunction(keyFrame.Easing));
            }

            // Start the animation scaled and offset.
            StartAnimation(targetObject, compositionAnimation, scale, offset);
        }


        float GetInPointProgress(TranslationContext context, Layer layer)
        {
            var result = (layer.InPoint - context.StartTime)/ context.DurationInFrames;

            return (float)result;
        }

        float GetOutPointProgress(TranslationContext context, Layer layer)
        {
            var result = (layer.OutPoint - context.StartTime) / context.DurationInFrames;

            return (float)result;
        }

        static SolidColorFill.PathFillType GetPathFillType(SolidColorFill fill) => fill == null ? SolidColorFill.PathFillType.EvenOdd : fill.FillType;

        CompositionPath CompositionPathFromPathGeometry(PathGeometry pathGeometry, SolidColorFill.PathFillType fillType)
        {
            using (var builder = new CanvasPathBuilder(_canvasDevice))
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
                    Unsupported("Opacity and color animated at the same time");
                    return color;
                }
                else
                {
                    // Multiply the color animation by the single opacity value.
                    return new Animatable<Color>(
                        initialValue: MultiplyColorByOpacityPercent(color.InitialValue, opacityPercent.InitialValue),
                        keyFrames: color.KeyFrames.Select(kf =>
                            new KeyFrame<Color>(kf.Frame, MultiplyColorByOpacityPercent(kf.Value, opacityPercent.InitialValue), kf.Easing)),
                        propertyIndex: null);
                }
            }
            else if (opacityPercent.IsAnimated)
            {
                if (color.IsAnimated)
                {
                    // TODO: multiply animations to produce a new set of key frames for the opacity-multiplied color.
                    Unsupported("Opacity and color animated at the same time");
                    return color;
                }
                else
                {
                    // Multiply the single color value by the opacity animation.
                    return new Animatable<Color>(
                        initialValue: MultiplyColorByOpacityPercent(color.InitialValue, opacityPercent.InitialValue),
                        keyFrames: opacityPercent.KeyFrames.Select(kf =>
                            new KeyFrame<Color>(kf.Frame, MultiplyColorByOpacityPercent(color.InitialValue, kf.Value), kf.Easing)),
                        propertyIndex: null);

                }
            }
            else
            {
                return color;
            }

        }

        static Color MultiplyColorByOpacityPercent(Color color, double opacityPercent)
            => opacityPercent == 100 ? color
            : LottieData.Color.FromArgb(color.A * opacityPercent / 100, color.R, color.G, color.B);


        CompositionColorBrush CreateAnimatedColorBrush(TranslationContext context, Animatable<Color> color, Animatable<double> opacityPercent)
        {
            var multipliedColor = MultiplyAnimatableColorByAnimatableOpacityPercent(color, opacityPercent);

            if (multipliedColor.IsAnimated)
            {
                var result = CreateColorBrush(multipliedColor.InitialValue);
                ApplyColorKeyFrameAnimation(context, multipliedColor, result, nameof(result.Color));
                return result;
            }
            else
            {
                return CreateNonAnimatedColorBrush(multipliedColor.InitialValue);
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
            _canvasDevice.Dispose();
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
                case Easing.EasingType.Step:
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

        ExpressionAnimation CreateExpressionAnimation(string expression)
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
                case MergePaths.MergeMode.Add: return CanvasGeometryCombine.Union;
                case MergePaths.MergeMode.Subtract: return CanvasGeometryCombine.Exclude;
                case MergePaths.MergeMode.Intersect: return CanvasGeometryCombine.Intersect;
                // TODO - find out what merge should be - maybe should be a Union.
                case MergePaths.MergeMode.Merge:
                case MergePaths.MergeMode.ExcludeIntersections: return CanvasGeometryCombine.Xor;
                default:
                    throw new InvalidOperationException();
            }
        }


        static float? FloatDefaultIsZero(double value) => value == 0 ? null : (float?)value;
        static float? FloatDefaultIsOne(double value) => value == 1 ? null : (float?)value;

        static WinCompData.Sn.Matrix3x2 Matrix3x2Identity => WinCompData.Sn.Matrix3x2.Identity;

        static WinCompData.Sn.Vector2 Vector2(LottieData.Vector3 vector3) => Vector2(vector3.X, vector3.Y);
        static WinCompData.Sn.Vector2 Vector2(double x, double y) => new WinCompData.Sn.Vector2((float)x, (float)y);
        static WinCompData.Sn.Vector3 Vector3(double x, double y, double z) => new WinCompData.Sn.Vector3((float)x, (float)y, (float)z);
        static WinCompData.Sn.Vector3 Vector3(LottieData.Vector3 vector3) => new WinCompData.Sn.Vector3((float)vector3.X, (float)vector3.Y, (float)vector3.Z);

        static WinCompData.Sn.Vector2? Vector2DefaultIsOne(LottieData.Vector3 vector2) =>
            vector2.X == 1 && vector2.Y == 1 ? null : (WinCompData.Sn.Vector2?)Vector2(vector2);
        static WinCompData.Sn.Vector2? Vector2DefaultIsZero(LottieData.Vector3 vector2) =>
            vector2.X == 0 && vector2.Y == 0 ? null : (WinCompData.Sn.Vector2?)Vector2(vector2);
        static WinCompData.Sn.Vector2? Vector2DefaultIsZero(WinCompData.Sn.Vector2 vector2) =>
            vector2.X == 0 && vector2.Y == 0 ? null : (WinCompData.Sn.Vector2?)vector2;

        static WinCompData.Sn.Vector2 ClampedVector2(LottieData.Vector3 vector3) => ClampedVector2((float)vector3.X, (float)vector3.Y);

        static WinCompData.Sn.Vector2 ClampedVector2(float x, float y) => Vector2(Math.Clamp(x, 0, 1), Math.Clamp(y, 0, 1));

        static WinCompData.Sn.Vector2 Vector2(float x, float y) => new WinCompData.Sn.Vector2(x, y);
        static WinCompData.Sn.Vector2 Vector2(float x) => new WinCompData.Sn.Vector2(x, x);

        static WinCompData.Sn.Vector3? Vector3DefaultIsZero(WinCompData.Sn.Vector2 vector2) =>
                    vector2.X == 0 && vector2.Y == 0 ? null : (WinCompData.Sn.Vector3?)Vector3(vector2);
        static WinCompData.Sn.Vector3? Vector3DefaultIsOne(WinCompData.Sn.Vector3 vector3) =>
                    vector3.X == 1 && vector3.Y == 1 && vector3.Z == 1 ? null : (WinCompData.Sn.Vector3?)vector3;
        static WinCompData.Sn.Vector3? Vector3DefaultIsOne(LottieData.Vector3 vector3) => Vector3DefaultIsOne(new WinCompData.Sn.Vector3((float)vector3.X, (float)vector3.Y, (float)vector3.Z));

        static WinCompData.Sn.Vector3 Vector3(WinCompData.Sn.Vector2 vector2) => Vector3(vector2.X, vector2.Y, 0);


        static WinCompData.Wui.Color Color(LottieData.Color color) =>
            WinCompData.Wui.Color.FromArgb((byte)(255 * color.A), (byte)(255 * color.R), (byte)(255 * color.G), (byte)(255 * color.B));

        void Unsupported(string details)
        {
            _issues.Add(details);
            if (_strictTranslation)
            {
                throw new NotSupportedException(details);
            }
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
            internal TranslationContext(LottieData.LottieComposition lottieComposition)
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
