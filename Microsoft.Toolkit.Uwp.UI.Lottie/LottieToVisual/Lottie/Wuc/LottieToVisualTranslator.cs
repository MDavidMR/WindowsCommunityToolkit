using Lottie.Data;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Geometry;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Windows.UI.Composition;

namespace Lottie.Wuc
{
    /// <summary>
    /// Translates a <see cref="LottieComposition"/> to an equivalent <see cref="Visual"/>.
    /// </summary>
    public sealed class LottieToVisualTranslator
    {
        readonly LottieComposition _lc;
        readonly Compositor _c;
        readonly ShapeVisual _rootVisual;
        readonly ExpressionAnimation _progressBindingAnimation;
        readonly TranslationInfo _translationInfo = new TranslationInfo();
        readonly bool _annotate = true;
        readonly List<AnimationController> _controllers = new List<AnimationController>();
        readonly ResourceDisposer _resources = new ResourceDisposer();

        /// <summary>
        /// The name of the property on the resulting <see cref="Visual"/> that controls the progress
        /// of the animation. Setting this property (directly or with an animation)
        /// between 0 and 1 controls the position of the animation.
        /// </summary>
        public static string ProgressPropertyName => "AnimationProgress";

        LottieToVisualTranslator(LottieComposition lottieComposition, Compositor compositor)
        {
            _lc = lottieComposition;
            _c = compositor;
            _rootVisual = _c.CreateShapeVisual();
            _progressBindingAnimation = CreateExpressionAnimation($"root.{ProgressPropertyName}");
            // Add the master progress property to the visual.
            _rootVisual.Properties.InsertScalar(ProgressPropertyName, 0);

            // TODO: clamp based on relative animation timelines
            _progressBindingAnimation.SetReferenceParameter("root", _rootVisual);

            // Create a CompositionViewBox to scale the result to the size requested by Lottie.
            var viewBox = _c.CreateViewBox();
            viewBox.Size = new System.Numerics.Vector2(_lc.Width, _lc.Height);
            _rootVisual.ViewBox = viewBox;

            if (_annotate)
            {
                viewBox.Comment = $"Scene ViewBox {lottieComposition.Width} x {lottieComposition.Height}";
                _rootVisual.Comment = "LottieVisual";
            }
        }

        /// <summary>
        /// Attemtps to translates the given <see cref="LottieComposition"/>.
        /// </summary>
        /// <param name="lottieComposition">The <see cref="LottieComposition"/> to translate.</param>
        /// <param name="compositor">A <see cref="Compositor"/> used to create the <see cref="CompositionObject"/>s.</param>
        /// <param name="visual">The <see cref="Visual"/> that contains the translated Lottie.</param>
        /// <param name="resources">Resources that must be kept alive as long as <paramref name="visual"/> is alive, and should be Disposed when no longer required.</param>
        /// <param name="translationInfo">Information about the translation.</param>
        public static bool TryTranslateLottieComposition(
            LottieComposition lottieComposition,
            Compositor compositor,
            out Visual visual,
            out IDisposable resources,
            out TranslationInfo translationInfo)
        {
            // Start a stopwatch to time the translation.
            var sw = Stopwatch.StartNew();

            // Set up the translator.
            var translator = new LottieToVisualTranslator(lottieComposition, compositor);

            // Translate the Lottie content to a CompositionShapeVisual tree.
            translator.Translate();

            // Save the translation time.
            translator._translationInfo._translationTime = sw.Elapsed;

            // Set the out parameters.
            visual = translator._rootVisual;
            resources = translator._resources;
            translationInfo = translator._translationInfo;

            return true;
        }

        void Translate()
        {
            var shapeTree = CreateContainerShape();
            _rootVisual.Shapes.Add(shapeTree);

            if (_annotate)
            {
                shapeTree.Comment = "LottieShapeRoot";
            }

            // Get the layers in painting order.
            foreach (var layer in _lc.Layers.GetLayersBottomToTop())
            {
                shapeTree.Shapes.Add(TranslateLayer(_lc.Layers, layer));
            }
        }

        CompositionContainerShape TranslateLayer(LayerContainer layerContainer, Layer layer)
        {
            // Create shape containers for the layer.
            // The rootTransformNode is the root for the layer. It may be the same object
            // as the leafTransformNode if there are no inherited transforms.
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

            // Create the chain of transform nodes.
            TranslateTransformForLayer(layerContainer, layer, out var rootTransformNode, out var leafTransformNode);
            var contentsNode = CreateContainerShape();
            leafTransformNode.Shapes.Add(contentsNode);

            if (_annotate)
            {
                contentsNode.Comment = $"{layer.Name}.Contents";
            }

            switch (layer.Type)
            {
                case Layer.LayerType.Image:
                    TranslateImageLayer((ImageLayer)layer, contentsNode);
                    break;
                case Layer.LayerType.Null:
                    TranslateNullLayer((NullLayer)layer, contentsNode);
                    break;
                case Layer.LayerType.PreComp:
                    TranslatePrecompLayer((PreCompLayer)layer, contentsNode);
                    break;
                case Layer.LayerType.Shape:
                    TranslateShapeLayer((ShapeLayer)layer, contentsNode);
                    break;
                case Layer.LayerType.Solid:
                    TranslateSolidLayer((SolidLayer)layer, contentsNode);
                    break;
                case Layer.LayerType.Text:
                    TranslateTextLayer((TextLayer)layer, contentsNode);
                    break;
                default:
                    throw new InvalidOperationException();
            }

            // Implement the Visibility for the node.
            // TODO: layer ip > 0 || layer op < 1          
            if ((layer.InFrame > _lc.StartFrame) || (layer.OutFrame < _lc.EndFrame))
            {
                var durationInFrames = _lc.EndFrame - _lc.StartFrame;
                // Clamp progress values
                var inFrameProgress = layer.InFrame < _lc.StartFrame ? 0 : layer.InFrame / durationInFrames;
                var outFrameProgress = layer.OutFrame > _lc.EndFrame ? 1 : layer.OutFrame / durationInFrames;

                if (inFrameProgress < 1)
                {
                    // Insert Visibility flag into the node's PropertySet
                    contentsNode.Properties.InsertScalar("Visibility", 0);

                    // Create Animation to toggle visibility
                    var stepAnimation = CreateScalarKeyFrameAnimation();
                    stepAnimation.InsertKeyFrame(0, 0);
                    stepAnimation.InsertKeyFrame((inFrameProgress < 0) ? 0 : inFrameProgress, 1,
                        CreateStepEasingFunction(stepCount: 1, isFinalStepSingleFrame: true,
                                                isInitialStepSingleFrame: false, initialStep: 0, finalStep: 1));
                    stepAnimation.InsertKeyFrame((outFrameProgress > 1) ? 1 : outFrameProgress, 1);
                    stepAnimation.InsertKeyFrame(1, (outFrameProgress < 1) ? 0 : 1,
                        CreateStepEasingFunction(stepCount: 1, initialStep: 0,
                                                 isInitialStepSingleFrame: true, finalStep: 1, isFinalStepSingleFrame: false));
                    stepAnimation.Duration = _lc.Duration;
                    stepAnimation.Target = "Visibility";

                    // Create Matrix3x2 Expression Animation, and start animation on reference parameter
                    // this should animate between identity and degenerate transformation matrices.
                    var compositionMatrixAnim = CreateExpressionAnimation("Matrix3x2(contents.Visibility,0,0,contents.Visibility,0,0)");
                    compositionMatrixAnim.SetReferenceParameter("contents", contentsNode);
                    compositionMatrixAnim.Target = "TransformMatrix";

                    AddAnimation(contentsNode, compositionMatrixAnim);
                    AddAnimation(contentsNode, stepAnimation);
                }
                else
                {
                    // TODO: Fix Visibility correctly with Progress 
                }
            }

            return rootTransformNode;
        }

        void TranslateImageLayer(ImageLayer layer, CompositionContainerShape contentsNode)
        { }

        void TranslateNullLayer(NullLayer layer, CompositionContainerShape contentsNode)
        { }

        void TranslatePrecompLayer(PreCompLayer layer, CompositionContainerShape contentsNode)
        { }


        void TranslateShapeLayer(ShapeLayer layer, CompositionContainerShape contentsNode)
        {
            var layerName = layer.Name;
            // TODO: Stroke/FillBase
            ShapeStroke stroke = null;
            ShapeFill fill = null;
            TrimPath trim = null;
            //MergePaths currentMergePaths;

            // TODO - The Contents are in left-to-right order here, but BodyMovin and After Effects provides them
            //        in right to left order. Keep the original order and reverse them here.

            // Enumerate the list of contents. Each item is a command.
            // Some commands set state for subsequent commands, while others 
            // render geometries.
            foreach (var shapeContent in layer.Contents)
            {
                switch (shapeContent.ContentType)
                {
                    case ShapeLayerContent.ShapeContentType.SolidColorStroke:
                    case ShapeLayerContent.ShapeContentType.GradientStroke:
                        // Set the stroke to be used from this point on.
                        stroke = (ShapeStroke)shapeContent;
                        break;

                    case ShapeLayerContent.ShapeContentType.SolidColorFill:
                    case ShapeLayerContent.ShapeContentType.GradientFill:
                        fill = (ShapeFill)shapeContent;
                        break;

                    case ShapeLayerContent.ShapeContentType.TrimPath:
                        trim = (TrimPath)shapeContent;
                        break;

                    case ShapeLayerContent.ShapeContentType.Group:
                        contentsNode.Shapes.Add(TranslateGroupShapeContent((ShapeGroup)shapeContent, stroke, fill, trim, layerName));
                        break;
                    case ShapeLayerContent.ShapeContentType.Path:
                        contentsNode.Shapes.Add(TranslatePathShapeContent((PathShape)shapeContent, stroke, fill, trim, layerName));
                        break;
                    case ShapeLayerContent.ShapeContentType.Ellipse:
                        contentsNode.Shapes.Add(TranslateEllipseShapeContent((EllipseShape)shapeContent, stroke, fill, trim, layerName));
                        break;
                    case ShapeLayerContent.ShapeContentType.Rectangle:
                        contentsNode.Shapes.Add(TranslateRectangleShapeContent((RectangleShape)shapeContent, stroke, fill, trim, layerName));
                        break;
                    case ShapeLayerContent.ShapeContentType.Polystar:
                        throw new NotSupportedException();
                    case ShapeLayerContent.ShapeContentType.Repeater:
                        throw new NotSupportedException();

                    case ShapeLayerContent.ShapeContentType.Transform:
                    case ShapeLayerContent.ShapeContentType.MergePaths:
                        throw new NotSupportedException();
                    default:
                        throw new InvalidOperationException();
                }
            }
        }

        CompositionShape TranslateGroupShapeContent(ShapeGroup shapeContent, ShapeStroke stroke, ShapeFill fill, TrimPath trimPath, string containerName)
        {
            var compositionNode = CreateContainerShape();

            string groupName = null;
            if (_annotate)
            {
                groupName = $"{containerName}.{shapeContent.Name}";
                compositionNode.Comment = groupName;
            }

            foreach (var item in shapeContent.Items)
            {
                switch (item.ContentType)
                {
                    case ShapeLayerContent.ShapeContentType.SolidColorStroke:
                    case ShapeLayerContent.ShapeContentType.GradientStroke:
                        stroke = (ShapeStroke)item;
                        break;

                    case ShapeLayerContent.ShapeContentType.SolidColorFill:
                    case ShapeLayerContent.ShapeContentType.GradientFill:
                        fill = (ShapeFill)item;
                        break;

                    case ShapeLayerContent.ShapeContentType.Transform:
                        TranslateAndApplyTransform((AnimatableTransform)item, compositionNode);
                        break;

                    case ShapeLayerContent.ShapeContentType.Group:
                        compositionNode.Shapes.Add(TranslateGroupShapeContent((ShapeGroup)item, stroke, fill, trimPath, groupName));
                        break;

                    case ShapeLayerContent.ShapeContentType.Path:
                        compositionNode.Shapes.Add(TranslatePathShapeContent((PathShape)item, stroke, fill, trimPath, groupName));
                        break;
                    case ShapeLayerContent.ShapeContentType.Ellipse:
                        compositionNode.Shapes.Add(TranslateEllipseShapeContent((EllipseShape)item, stroke, fill, trimPath, groupName));
                        break;

                    case ShapeLayerContent.ShapeContentType.Rectangle:
                        compositionNode.Shapes.Add(TranslateRectangleShapeContent((RectangleShape)item, stroke, fill, trimPath, groupName));
                        break;

                    case ShapeLayerContent.ShapeContentType.Polystar:
                        throw new NotSupportedException();

                    case ShapeLayerContent.ShapeContentType.Repeater:
                        throw new NotSupportedException();

                    case ShapeLayerContent.ShapeContentType.TrimPath:
                        // TODO: Individually vs Simultaneously ExpressionKeyFrames
                        trimPath = (TrimPath)item;
                        break;

                    case ShapeLayerContent.ShapeContentType.MergePaths:
                        // TODO: Combine all following geometries to a single group
                        // CombineGeometries(shapesJson(0 -> i -1);
                        throw new NotSupportedException();

                    default:
                        throw new InvalidOperationException();
                }
            }
            return compositionNode;
        }


        CompositionShape TranslateEllipseShapeContent(EllipseShape shapeContent, ShapeStroke stroke, ShapeFill fill, TrimPath trimPath, string containerName)
        {
            // An ellipse is represented as a SpriteShape with a CompositionEllipseGeometry.
            var compositionSpriteShape = CreateSpriteShape();

            var compositionEllipseGeometry = _c.CreateEllipseGeometry();
            compositionSpriteShape.Geometry = compositionEllipseGeometry;
            if (_annotate)
            {
                var shapeName = $"{containerName}.{shapeContent.Name}";
                compositionSpriteShape.Comment = shapeName;
                compositionEllipseGeometry.Comment = $"{shapeName}.EllipseGeometry";
            }
            compositionEllipseGeometry.Center = ToSNVector2(shapeContent.Position.InitialValue);

            if (shapeContent.Position.HasAnimation)
            {
                CreateCompositionVector2Animation(shapeContent.Position, "Center", out var compAnim); // TODO: test
                AddAnimation(compositionEllipseGeometry, compAnim);
            }
            compositionEllipseGeometry.Radius = ToSNVector2(shapeContent.Size.InitialValue);

            if (shapeContent.Size.HasAnimation)
            {
                CreateCompositionVector2Animation(shapeContent.Size, "Radius", out var compAnim); // TODO: Test
                AddAnimation(compositionEllipseGeometry, compAnim);
            }

            // Get fill data and set properties on SpriteShape
            compositionSpriteShape.FillBrush = TranslateShapeFill(fill);

            // Get stroke data and set properties on SpriteShape
            TranslateAndApplyShapeStroke(stroke, compositionSpriteShape);

            // Get trim data and set properties on (SpriteShape's) Geometry
            TranslateAndApplyTrimPath(trimPath, compositionSpriteShape.Geometry);

            return compositionSpriteShape;
        }


        CompositionShape TranslateRectangleShapeContent(RectangleShape shapeContent, ShapeStroke stroke, ShapeFill fill, TrimPath trimPath, string containerName)
        {
            // A rectangle is represented as a SpriteShape with a CompositionRoundedRectangleGeometry.
            var compositionRectangleShape = CreateSpriteShape();
            var compositionShape = compositionRectangleShape;

            var compositionRectangleGeometry = _c.CreateRoundedRectangleGeometry();
            compositionRectangleShape.Geometry = compositionRectangleGeometry;

            if (_annotate)
            {
                var shapeContentName = $"{containerName}.{shapeContent.Name}";
                compositionRectangleShape.Comment = shapeContentName;
                compositionRectangleGeometry.Comment = $"{shapeContentName}.RectangleGeometry";
            }

            // Map RectangleShape's position to RoundedRectangleGeometry.Offset by using custom property, Position, and an ExpressionAnimation
            compositionRectangleGeometry.Properties.InsertVector2("Position", ToSNVector2(shapeContent.Position.InitialValue)); // TODO: Move properties higher up the tree into a single prop set per layer using name as id

            // ExpressionAnimation to compensate for default centerpoint being top-left vs geometric center
            var compositionOffsetExpression = CreateExpressionAnimation("Vector2(my.Position.X - (my.Size.X/2), my.Position.Y - (my.Size.Y/2))");
            compositionOffsetExpression.SetReferenceParameter("my", compositionRectangleGeometry);
            compositionOffsetExpression.Target = "Offset";
            AddAnimation(compositionRectangleGeometry, compositionOffsetExpression);

            if (shapeContent.Position.HasAnimation)
            {
                CreateCompositionVector2Animation(shapeContent.Position, "Position", out var compAnim);
                AddAnimation(compositionRectangleGeometry, compAnim);
            }

            // Map RectangleShape's size to RoundedRectangleGeometry.Size
            compositionRectangleGeometry.Size = ToSNVector2(shapeContent.Size.InitialValue);

            if (shapeContent.Size.HasAnimation)
            {
                CreateCompositionVector2Animation(shapeContent.Size, "Size", out var compAnim);
                AddAnimation(compositionRectangleGeometry, compAnim);
            }

            // Map RectangleShape's size to RoundedRectangleGeometry.CornerRadius
            // CornerRadius data exported from AfterEffects is assumed to be the same for both corner radii.
            compositionRectangleGeometry.CornerRadius = new System.Numerics.Vector2(shapeContent.CornerRadius.InitialValue);

            if (shapeContent.CornerRadius.HasAnimation)
            {
                CreateCompositionScalarAnimation(shapeContent.CornerRadius, "CornerRadius.X", out var xCompAnim); // TODO: Test
                AddAnimation(compositionRectangleGeometry, xCompAnim);
                CreateCompositionScalarAnimation(shapeContent.CornerRadius, "CornerRadius.Y", out var yCompAnim);
                AddAnimation(compositionRectangleGeometry, yCompAnim);
            }

            // Get fill data and set properties on SpriteShape
            compositionRectangleShape.FillBrush = TranslateShapeFill(fill);

            // Get stroke data and set properties on SpriteShape
            TranslateAndApplyShapeStroke(stroke, compositionRectangleShape);

            // Get trim data and set properties on (SpriteShape's) Geometry
            TranslateAndApplyTrimPath(trimPath, compositionRectangleShape.Geometry);

            return compositionRectangleShape;
        }

        CompositionShape TranslatePathShapeContent(PathShape shapeContent, ShapeStroke stroke, ShapeFill fill, TrimPath trimPath, string containerName)
        {
            // Set fill rule (defaults to Alternate)
            // Note: AfterEffects specified a path's fillRule as part of the Fill applied on it, not the Path itself.
            var fillRule = CanvasFilledRegionDetermination.Alternate; //TODO: use platform agnostic enum and convert to Win2D/D2D fillrule as needed?
            if (fill != null)
            {
                fillRule = ToCanvasFillRule(fill.FillType);
            }

            // Map PathShape's Geometry data to PathGeometry.Path
            var geometry = shapeContent.PathData;

            // A path is represented as a SpriteShape with a CompositionPathGeometry.
            var compositionSpriteShape = CreateSpriteShape();

            var compositionPathGeometry = _c.CreatePathGeometry();
            compositionSpriteShape.Geometry = compositionPathGeometry;
            compositionPathGeometry.Path = CompositionPathFromPathGeometry(geometry.InitialValue);

            if (_annotate)
            {
                var shapeName = $"{containerName}.{shapeContent.Name}";
                compositionSpriteShape.Comment = shapeName;
                compositionPathGeometry.Comment = $"{shapeName}.PathGeometry";
            }

            if (geometry.HasAnimation)
            {
                CreateCompositionPathGeometryAnimation(geometry, "Path", out var compAnim);
                AddAnimation(compositionPathGeometry, compAnim);
            }

            // Get fill data and set properties on SpriteShape
            compositionSpriteShape.FillBrush = TranslateShapeFill(fill);

            // Get stroke data and set properties on SpriteShape
            TranslateAndApplyShapeStroke(stroke, compositionSpriteShape);

            // Get trim data and set properties on (SpriteShape's) Geometry
            TranslateAndApplyTrimPath(trimPath, compositionSpriteShape.Geometry);

            return compositionSpriteShape;
        }

        void TranslateAndApplyTrimPath(TrimPath trimPath, CompositionGeometry geometry)
        {
            if (trimPath == null)
            {
                return;
            }

            //set trim start
            geometry.TrimStart = trimPath.Start.InitialValue;
            if (trimPath.Start.HasAnimation)
            {
                CreateCompositionScalarAnimation(trimPath.Start, "TrimStart", out var compAnim);
                AddAnimation(geometry, compAnim);
            }

            // set trim end
            geometry.TrimEnd = trimPath.End.InitialValue;
            if (trimPath.End.HasAnimation)
            {
                CreateCompositionScalarAnimation(trimPath.End, "TrimEnd", out var compAnim);
                AddAnimation(geometry, compAnim);
            }

            // set trim offset
            geometry.TrimOffset = trimPath.Offset.InitialValue;
            if (trimPath.Offset.HasAnimation)
            {
                CreateCompositionScalarAnimation(trimPath.Offset, "TrimOffset", out var compAnim);
                AddAnimation(geometry, compAnim);
            }
        }


        void TranslateAndApplyShapeStroke(ShapeStroke shapeStroke, CompositionSpriteShape shape)
        {
            if (shapeStroke == null)
            {
                return;
            }
            // TODO: Push opacity to Brush
            // A ShapeStroke is represented as a CompositionColorBrush and Stroke properties on the relevant SpriteShape.
            var compositionColorBrush = _c.CreateColorBrush();
            if (_annotate)
            {
                compositionColorBrush.Comment = $"{shapeStroke.Name}.Color";
            }
            compositionColorBrush.Color = ToWuColor(shapeStroke.Color.InitialValue);
            if (shapeStroke.Color.HasAnimation)
            {
                CreateCompositionColorAnimation(shapeStroke.Color, "Color", out var compAnim);
                AddAnimation(compositionColorBrush, compAnim);
            }

            // TODO - rename rather than assigning
            var sprite = shape;
            // Map ShapeStroke's color to SpriteShape.StrokeBrush
            sprite.StrokeBrush = compositionColorBrush;

            // Map ShapeStroke's width to SpriteShape.StrokeThickness
            sprite.StrokeThickness = shapeStroke.Thickness.InitialValue;
            if (shapeStroke.Thickness.HasAnimation)
            {
                CreateCompositionScalarAnimation(shapeStroke.Thickness, "StrokeThickness", out var compAnim);
                AddAnimation(shape, compAnim);
            }

            // Map ShapeStroke's linecap to SpriteShape.StrokeStart/End/DashCap
            sprite.StrokeStartCap = sprite.StrokeEndCap = sprite.StrokeDashCap = ToCompositionStrokeCap(shapeStroke.CapType);

            // Map ShapeStroke's linejoin to SpriteShape.StrokeLineJoin
            sprite.StrokeLineJoin = ToCompositionStrokeLineJoin(shapeStroke.JoinType);

            // Set MiterLimit
            sprite.StrokeMiterLimit = shapeStroke.MiterLimit;

            // Map ShapeStroke's dash pattern to SpriteShape.StrokeDashArray
            // NOTE: DashPattern animation (animating dash sizes) are not supported on CompositionSpriteShape.
            var dashPattern = shapeStroke.DashPattern;
            if (dashPattern.Any())
            {
                foreach (var dash in dashPattern)
                {
                    sprite.StrokeDashArray.Add(dash); // TODO: Ensure that this is correct; is there a way to add an entire list?
                }
            }

            // Set DashOffset
            sprite.StrokeDashOffset = shapeStroke.DashOffset.InitialValue;
            if (shapeStroke.DashOffset.HasAnimation)
            {
                CreateCompositionScalarAnimation(shapeStroke.DashOffset, "StrokeDashOffset", out var compAnim); // TODO: Test that this is in the correct direction
                AddAnimation(shape, compAnim);
            }
        }

        CompositionColorBrush TranslateShapeFill(ShapeFill shapeFill)
        {
            if (shapeFill == null)
            {
                return null;
            }
            // A ShapeFill is represented as a CompositionColorBrush
            // Note: FillType is passed onto Win2D's PathBuilder at the time of geometry construction
            var compositionColorBrush = _c.CreateColorBrush();
            if (_annotate)
            {
                compositionColorBrush.Comment = $"{shapeFill.Name}.Color";
            }

            compositionColorBrush.Color = ToWuColor(shapeFill.Color.InitialValue);
            if (shapeFill.Color.HasAnimation)
            {
                CreateCompositionColorAnimation(shapeFill.Color, "Color", out var compAnim);
                AddAnimation(compositionColorBrush, compAnim);
            }
            return compositionColorBrush;
        }


        void TranslateSolidLayer(SolidLayer layer, CompositionContainerShape contentsNode)
        {
            var rectangleGeometry = _c.CreateRectangleGeometry();
            rectangleGeometry.Size = new System.Numerics.Vector2(layer.Width, layer.Height);

            var rectangleShape = CreateSpriteShape();
            rectangleShape.Geometry = rectangleGeometry;

            var brush = _c.CreateColorBrush(ToWuColor(layer.Color));
            rectangleShape.FillBrush = brush;

            if (_annotate)
            {
                rectangleShape.Comment = contentsNode.Comment + ".SolidLayerRectangle";
                rectangleGeometry.Comment = rectangleShape.Comment + ".RectangleGeometry";
                brush.Comment = rectangleShape.Comment + ".Color";
            }

            // TODO - return the shape rather than adding it.
            contentsNode.Shapes.Add(rectangleShape);
        }

        void TranslateTextLayer(TextLayer layer, CompositionContainerShape contentsNode)
        { }


        // Returns a chain of CompositionShape that define the transform for a layer.
        // The top of the chain is the rootTransform, the bottom is the leafTransform.
        void TranslateTransformForLayer(LayerContainer layerContainer, Layer layer, out CompositionContainerShape rootTransformNode, out CompositionContainerShape leafTransformNode)
        {
            leafTransformNode = TranslateTransform(layer.Transform);
            if (_annotate)
            {
                leafTransformNode.Comment = $"{layer.Name}.Transforms";
            }

            if (layer.ParentId != null)
            {
                var parentLayer = layerContainer.GetLayerById(layer.ParentId.Value);
                TranslateTransformForLayer(layerContainer, parentLayer, out rootTransformNode, out var parentLeafTransform);

                if (_annotate)
                {
                    rootTransformNode.Comment = $"{layer.Name}.AncestorTransformFrom_{parentLayer.Name}";
                }

                parentLeafTransform.Shapes.Add(leafTransformNode);
            }
            else
            {
                rootTransformNode = leafTransformNode;
            }
        }

        CompositionContainerShape TranslateTransform(AnimatableTransform transform)
        {
            var shape = CreateContainerShape();
            TranslateAndApplyTransform(transform, shape);
            return shape;
        }

        void TranslateAndApplyTransform(AnimatableTransform transform, CompositionContainerShape shape)
        {
            // Set the anchor
            shape.Properties.InsertVector2("Anchor", ToSNVector2(transform.Anchor.InitialValue));

            // start expression: centerpoint = anchor
            var centerPointExpression = CreateExpressionAnimation("my.Anchor");
            centerPointExpression.SetReferenceParameter("my", shape);
            centerPointExpression.Target = "CenterPoint";
            AddAnimation(shape, centerPointExpression);

            if (transform.Anchor.IsSplitDimension)
            {
                // BLOCKED: 14632318 animationGroup Targets can't dot in
                var xDimension = transform.Anchor.XDimension;
                var yDimension = transform.Anchor.YDimension;

                if (xDimension.HasAnimation)
                {
                    CreateCompositionScalarAnimation(xDimension, "Anchor.X", out var compAnim);
                    AddAnimation(shape, compAnim);
                }

                if (yDimension.HasAnimation)
                {
                    CreateCompositionScalarAnimation(yDimension, "Anchor.Y", out var compAnim);
                    AddAnimation(shape, compAnim);
                }
            }
            else
            {
                if (transform.Anchor.HasAnimation)
                {
                    CreateCompositionVector2Animation(transform.Anchor, "Anchor", out var compAnim);
                    AddAnimation(shape, compAnim);
                }
            }

            // set position 
            shape.Properties.InsertVector2("Position", ToSNVector2(transform.Position.InitialValue));

            // start expression: offset = position - anchor
            var offsetExpression = CreateExpressionAnimation("my.Position - my.Anchor");
            offsetExpression.SetReferenceParameter("my", shape);
            offsetExpression.Target = "Offset";
            AddAnimation(shape, offsetExpression);

            if (transform.Position.IsSplitDimension)
            {
                // BLOCKED: 14632318 animationGroup Targets can't dot in
                var xDimension = transform.Position.XDimension;
                var yDimension = transform.Position.YDimension;

                if (xDimension.HasAnimation)
                {
                    CreateCompositionScalarAnimation(xDimension, "Position.X", out var compAnim);
                    AddAnimation(shape, compAnim);
                }

                if (yDimension.HasAnimation)
                {
                    CreateCompositionScalarAnimation(yDimension, "Position.Y", out var compAnim);
                    AddAnimation(shape, compAnim);
                }
            }
            else
            {
                if (transform.Position.HasAnimation)
                {
                    CreateCompositionVector2Animation(transform.Position, "Position", out var compAnim);
                    AddAnimation(shape, compAnim);
                }
            }

            // set scale 
            shape.Scale = ToSNVector2(transform.Scale.InitialValue);

            if (transform.Scale.HasAnimation)
            {
                CreateCompositionVector2Animation(transform.Scale, "Scale", out var compAnim);
                AddAnimation(shape, compAnim);
            }

            // set Rotation
            shape.RotationAngleInDegrees = transform.Rotation.InitialValue;

            if (transform.Rotation.HasAnimation)
            {
                CreateCompositionScalarAnimation(transform.Rotation, "RotationAngleInDegrees", out var compAnim);
                AddAnimation(shape, compAnim);
            }

            // set Skew and Skew Axis
            // TODO: TransformMatrix --> for a Layer, does this clash with Visibility? Should I add an extra ContainerShape?

            // set Opacity
            // TODO: set up push down opacity

            //TODO: Repeater Opacity
        }

        void AddAnimation(CompositionObject compObject, CompositionAnimation animation)
        {
            // Start the animation ...
            compObject.StartAnimation(animation.Target, animation);

            // ... but pause it immediately.
            if (animation is KeyFrameAnimation)
            {
                var controller = compObject.TryGetAnimationController(animation.Target);
                controller.Pause();

                // Bind the controller's Progress with a single AnimationProgress property on the scene root for easily manipulation
                controller.StartAnimation("Progress", _progressBindingAnimation);

                // Save the controller for use later.
                _controllers.Add(controller);
                // TODO - is this necessary?
                _resources.AddResource(controller);
            }


            // TODO - is this necessary?
            _resources.AddResource(animation);
            _resources.AddResource(compObject);

        }

        void CreateCompositionScalarAnimation(
            AnimatableValue<float> value,
            string target,
            out ScalarKeyFrameAnimation compositionAnimation)
            => GenericCreateCompositionAnimation(
                value,
                target,
                c => CreateScalarKeyFrameAnimation(),
                (ca, progress, val, easing) => ca.InsertKeyFrame(progress, val, easing),
                out compositionAnimation);


        void CreateCompositionColorAnimation(
            AnimatableValue<Data.Color> value,
            string target,
            out ColorKeyFrameAnimation compositionAnimation)
            => GenericCreateCompositionAnimation(
                value,
                target,
                c => c.CreateColorKeyFrameAnimation(),
                (ca, progress, val, easing) => ca.InsertKeyFrame(progress, ToWuColor(val), easing),
                out compositionAnimation);


        void CreateCompositionPathGeometryAnimation(
            AnimatableValue<PathGeometry> value,
            string target,
            out PathKeyFrameAnimation compositionAnimation)
            => GenericCreateCompositionAnimation(
                value,
                target,
                c => c.CreatePathKeyFrameAnimation(),
                (ca, progress, val, easing) => ca.InsertKeyFrame(progress, CompositionPathFromPathGeometry(val), easing),
                out compositionAnimation);

        void CreateCompositionVector2Animation(
            AnimatableVector2 value,
            string target,
            out Vector2KeyFrameAnimation compositionAnimation)
            => GenericCreateCompositionAnimation(
                value,
                target,
                c => c.CreateVector2KeyFrameAnimation(),
                (ca, progress, val, easing) => ca.InsertKeyFrame(progress, ToSNVector2(val), easing),
                out compositionAnimation);


        void GenericCreateCompositionAnimation<CA, T>(
            AnimatableValue<T> value,
            string target,
            Func<Compositor, CA> compositionAnimationFactory,
            Action<CA, float, T, CompositionEasingFunction> insertKeyFrame,
            out CA compositionAnimation) where CA : KeyFrameAnimation
        {
            var duration = _lc.Duration;
            compositionAnimation = compositionAnimationFactory(_c);
            compositionAnimation.Duration = duration;
            compositionAnimation.Target = target;

            var startProgress = GetProgressFromKeyFrame(value.KeyFrames.First(), _lc.EndFrame - _lc.StartFrame);

            if (startProgress > 0)
            {
                // Set an initial keyframe to set the value before the first specified keyframe time
                // is hit.
                insertKeyFrame(compositionAnimation, 0, value.InitialValue, null /* easing */);
            }

            foreach (var keyFrame in value.KeyFrames)
            {
                var progress = GetProgressFromKeyFrame(keyFrame, _lc.EndFrame - _lc.StartFrame);

                if ((progress < 0) || (progress > 1))
                {
                    continue;
                }

                progress = (progress < 0) ? 0 : ((progress > 1) ? 1 : progress); // TODO: This fails if multiple frames are specified beyond animation OP

                insertKeyFrame(
                    compositionAnimation,
                    progress,
                    keyFrame.Value,
                    CreateCompositionEasingFunction(keyFrame.Easing));
            }
        }

        static float GetProgressFromKeyFrame<T>(
            KeyFrame<T> keyFrame,
            float compositionDurationFrames)
        {
            return keyFrame.Frame.Value / compositionDurationFrames;
        }

        static CompositionPath CompositionPathFromPathGeometry(PathGeometry pathGeometry)
        {
            using (var device = CanvasDevice.GetSharedDevice())
            using (var builder = new CanvasPathBuilder(device))
            {
                builder.SetFilledRegionDetermination(CanvasFilledRegionDeterminationFromFillRule(pathGeometry.FillRule));
                builder.BeginFigure(ToSNVector2(pathGeometry.Start));

                foreach (var bezier in pathGeometry.Beziers)
                {
                    builder.AddCubicBezier(ToSNVector2(bezier.ControlPoint1), ToSNVector2(bezier.ControlPoint2), ToSNVector2(bezier.Vertex));
                }

                builder.EndFigure(pathGeometry.IsClosed ? CanvasFigureLoop.Closed : CanvasFigureLoop.Open);
                return new CompositionPath(CanvasGeometry.CreatePath(builder));
            }
        }

        static CanvasFilledRegionDetermination CanvasFilledRegionDeterminationFromFillRule(FillRule fillRule)
        {
            switch (fillRule)
            {
                case FillRule.Alternate:
                    return CanvasFilledRegionDetermination.Alternate;
                case FillRule.EvenOdd:
                    return CanvasFilledRegionDetermination.Winding;
                default:
                    throw new InvalidOperationException();
            }
        }

        CompositionEasingFunction CreateCompositionEasingFunction(
            Easing easingFunction)
        {
            if (easingFunction == null)
            {
                return null;
            }

            switch (easingFunction.Type)
            {
                case Easing.EasingType.Linear:
                    {
                        _translationInfo._linearEasingFunctionCount++;
                        return _c.CreateLinearEasingFunction();
                    }
                case Easing.EasingType.CubicBezier:
                    {
                        _translationInfo._cubicBezierEasingFunctionCount++;
                        var f = (CubicBezierEasing)easingFunction;
                        return _c.CreateCubicBezierEasingFunction(ToSNVector2(f.ControlPoint1), ToSNVector2(f.ControlPoint2));
                    }
                default:
                    throw new InvalidOperationException();
            }
        }

        StepEasingFunction CreateStepEasingFunction(int stepCount, int initialStep, int finalStep, bool isInitialStepSingleFrame, bool isFinalStepSingleFrame)
        {
            _translationInfo._stepEasingFunctionCount++;
            var result = _c.CreateStepEasingFunction(stepCount);
            result.FinalStep = finalStep;
            result.InitialStep = initialStep;
            result.IsFinalStepSingleFrame = isFinalStepSingleFrame;
            result.IsInitialStepSingleFrame = isInitialStepSingleFrame;
            return result;
        }

        ScalarKeyFrameAnimation CreateScalarKeyFrameAnimation()
        {
            _translationInfo._scalarKeyFrameAnimationCount++;
            return _c.CreateScalarKeyFrameAnimation();
        }
        CompositionContainerShape CreateContainerShape()
        {
            _translationInfo._containerShapeCount++;
            return _c.CreateContainerShape();
        }

        CompositionSpriteShape CreateSpriteShape()
        {
            _translationInfo._spriteShapeCount++;
            return _c.CreateSpriteShape();
        }

        ExpressionAnimation CreateExpressionAnimation(string expression)
        {
            _translationInfo._expressionAnimationCount++;
            return _c.CreateExpressionAnimation(expression);
        }

        static Windows.UI.Color ToWuColor(Data.Color color) =>
            Windows.UI.Color.FromArgb(color.A, color.R, color.G, color.B);


        static System.Numerics.Vector2 ToSNVector2(Lottie.Data.Vector2 vector2) =>
            new System.Numerics.Vector2(vector2.X, vector2.Y);


        static CompositionStrokeCap ToCompositionStrokeCap(ShapeStroke.LineCapType lineCapType)
        {
            switch (lineCapType)
            {
                case ShapeStroke.LineCapType.Butt:
                    return CompositionStrokeCap.Flat;
                case ShapeStroke.LineCapType.Round:
                    return CompositionStrokeCap.Round;
                case ShapeStroke.LineCapType.Unknown:
                default:
                    return CompositionStrokeCap.Square;
            }
        }

        static CompositionStrokeLineJoin ToCompositionStrokeLineJoin(ShapeStroke.LineJoinType lineJoinType)
        {
            switch (lineJoinType)
            {
                case ShapeStroke.LineJoinType.Bevel:
                    return CompositionStrokeLineJoin.Bevel;
                case ShapeStroke.LineJoinType.Miter:
                    return CompositionStrokeLineJoin.Miter;
                case ShapeStroke.LineJoinType.Round:
                default:
                    return CompositionStrokeLineJoin.Round;
            }
        }

        // TODO - eliminate this - only used while we have a Win2d dependency
        static CanvasFilledRegionDetermination ToCanvasFillRule(ShapeFill.PathFillType fillType)
        {
            return (fillType == ShapeFill.PathFillType.Winding) ? CanvasFilledRegionDetermination.Winding : CanvasFilledRegionDetermination.Alternate;
        }

        // Holds onto resources that must be prevented from being GC'd.
        sealed class ResourceDisposer : IDisposable
        {
            readonly List<IDisposable> _resources = new List<IDisposable>();

            internal void AddResource(IDisposable resource) => _resources.Add(resource);

            void IDisposable.Dispose()
            {
                foreach (var resource in _resources)
                {
                    resource.Dispose();
                }
            }
        }
    }
}
