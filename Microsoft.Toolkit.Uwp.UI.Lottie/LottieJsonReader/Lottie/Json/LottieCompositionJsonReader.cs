using Lottie.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Windows.Data.Json;

namespace Lottie.Json
{

    // TODO - remove this - only needed to satisfy Win2D stuff.
    enum CanvasFilledRegionDetermination
    {
        //
        // Summary:
        //     Specifies that self-intersecting regions are considered 'filled' based on the
        //     Alternate fill rule.
        Alternate = 0,
        //
        // Summary:
        //     Specifies that self-intersecting regions are considered 'filled' based on the
        //     Winding fill rule.
        Winding = 1
    }

    public sealed class LottieCompositionJsonReader
    {
        static readonly AnimatableFloatParser s_animatableFloatParser = new AnimatableFloatParser(1);
        static readonly AnimatableVector2Parser s_animatableVector2Parser = new AnimatableVector2Parser(1);
        static readonly AnimatableColorParser s_animatableColorParser = new AnimatableColorParser();
        readonly List<string> m_issues = new List<string>();

        /// <summary>
        /// Parses a Json string to create a <see cref="LottieComposition"/>.
        /// </summary>
        public static LottieComposition ReadLottieCompositionFromJson(string json, out string[] issues)
            => ReadLottieCompositionFromJson(JsonObject.Parse(json), out issues);

        LottieCompositionJsonReader() { }

        static LottieComposition ReadLottieCompositionFromJson(JsonObject obj, out string[] issues)
        {
            var reader = new LottieCompositionJsonReader();
            LottieComposition result = null;
            try
            {
                result = reader.ReadLottieComposition(obj);
            }
            catch (LottieJsonReaderException e)
            {
                reader.m_issues.Add(e.Message);
            }
            issues = reader.m_issues.ToArray();
            return result;
        }

        LottieComposition ReadLottieComposition(JsonObject obj)
        {
            var width = (int)obj.GetNamedNumber("w", -1);
            if (width == -1)
            {
                throw new LottieJsonReaderException("Width parameter not found.");
            }

            var height = (int)obj.GetNamedNumber("h", -1);
            if (width == -1)
            {
                throw new LottieJsonReaderException("Height parameter not found.");
            }


            var startFrame = (long)obj.GetNamedNumber("ip", 0);
            var endFrame = (long)obj.GetNamedNumber("op", 0);
            var frameRate = (float)obj.GetNamedNumber("fr", 0);
            var version = obj.GetNamedString("v");
            var versions = version.Split('.');

            var durationInFrames = endFrame - startFrame;

            var layers =
                new LayerContainer(from jl in obj.GetNamedArray("layers", null)
                                   let jo = jl.GetObject()
                                   select ReadLayer(jo, durationInFrames));


            var lottieComposition = new LottieComposition(
                width,
                height,
                startFrame,
                endFrame,
                frameRate,
                new Version(int.Parse(versions[0]), int.Parse(versions[1]), int.Parse(versions[2])),
                layers);


            // TODO: parse assets, precomps, etc.


            // TODO: Add AnimationController functionality by getting controller per animation and wrapping all into uber controller
            // Start all composition animations in a single commit batch (except ExpressionAnimation, which can be started at the time of creation so long as their reference parameter is controlled from here

            return lottieComposition;
        }


        Layer ReadLayer(JsonObject layerJson, float compositionDurationInFrames)
        {
            // Layer Info: Name, Id, Index, Parent
            var layerName = layerJson.GetNamedString("nm");
            var refId = layerJson.GetNamedString("refId", string.Empty);
            var layerId = (int)layerJson.GetNamedNumber("ind");

            var parentId = (int?)layerJson.GetNamedNumber("parent", -1);
            if (parentId.Value == -1)
            {
                parentId = null;
            }

            // Warnings
            if (layerName.EndsWith(".ai") || layerJson.GetNamedString("cl", "") == "ai")
            {
                m_issues.Add("Illustrator layers must be converted to shape layers.");
            }

            if (layerJson.ContainsKey("ef"))
            {
                m_issues.Add("Layer effects are not supported. If you are using them for " +
                                " fills, strokes, trim paths etc. then try adding them directly as contents " +
                                " in your shape layer.");
            }

            if (layerJson.ContainsKey("tt"))
            {
                m_issues.Add("Mattes are not yet supported.");
            }

            if (layerJson.ContainsKey("maskProperties"))
            {
                m_issues.Add("Masks are not yet supported.");
            }

            // ----------------------
            // Layer Transform
            // ----------------------

            var transform = ReadAnimatableTransform(layerJson.GetNamedObject("ks"));

            // ------------------------------
            // Layer Animation
            // ------------------------------
            var timeStretch = (float)layerJson.GetNamedNumber("sr", 1.0);
            var startFrame = (float)layerJson.GetNamedNumber("st");
            var startProgress = startFrame / compositionDurationInFrames;

            // Bodymovin pre-scales the in frame and out frame by the time stretch. However, that will
            // cause the stretch to be double counted since the in out animation gets treated the same
            // as all other animations and will have stretch applied to it again.
            var inFrame = (float)layerJson.GetNamedNumber("ip") / timeStretch;
            var outFrame = (float)layerJson.GetNamedNumber("op") / timeStretch;


            // Layer type
            var layerType = (Layer.LayerType)layerJson.GetNamedNumber("ty", -1);

            switch (layerType)
            {
                case Layer.LayerType.PreComp:
                    {
                        var result = new PreCompLayer(
                            layerName,
                            layerId,
                            parentId,
                            refId,
                            transform,
                            timeStretch,
                            startProgress,
                            inFrame,
                            outFrame);
                        return result;
                    }
                case Layer.LayerType.Solid:
                    {
                        var solidWidth = (int)(layerJson.GetNamedNumber("sw"));
                        var solidHeight = (int)(layerJson.GetNamedNumber("sh"));
                        var solidColor = GetSolidColorFromString(layerJson.GetNamedString("sc"));

                        var result = new SolidLayer(
                            layerName,
                            layerId,
                            parentId,
                            refId,
                            transform,
                            solidWidth,
                            solidHeight,
                            solidColor,
                            timeStretch,
                            startProgress,
                            inFrame,
                            outFrame);
                        return result;
                    }

                case Layer.LayerType.Image:
                    {
                        var result = new ImageLayer(
                            layerName,
                            layerId,
                            parentId,
                            refId,
                            transform,
                            timeStretch,
                            startProgress,
                            inFrame,
                            outFrame);
                        return result;
                    }
                case Layer.LayerType.Null:
                    {
                        var result = new NullLayer(
                            layerName,
                            layerId,
                            parentId,
                            refId,
                            transform,
                            timeStretch,
                            startProgress,
                            inFrame,
                            outFrame);
                        return result;
                    }
                case Layer.LayerType.Shape:
                    {
                        var shapes = new List<ShapeLayerContent>();
                        var shapesJson = layerJson.GetNamedArray("shapes", null);
                        shapes.Capacity = shapesJson.Count;
                        if (shapesJson != null)
                        {
                            // TODO: Stroke/FillBase
                            ShapeStroke currentStroke = null;
                            ShapeFill currentFill = null;
                            TrimPath currentTrim = null;
                            //MergePaths currentMergePaths;

                            // TODO: Walk this array backwards to simplify MergePath creation and Fill and Stroke and TrimPath Assignment
                            for (var i = shapesJson.Count - 1; i >= 0; i--)
                            {
                                var item = ReadShapeContent(shapesJson[i].GetObject(), currentFill, currentStroke, currentTrim, layerName); // include fill, stroke, trimpath, mergepath into constructor
                                if (item != null)
                                {
                                    switch (item.ContentType)
                                    {
                                        case ShapeLayerContent.ShapeContentType.SolidColorStroke:
                                        case ShapeLayerContent.ShapeContentType.GradientStroke:
                                            currentStroke = (ShapeStroke)item;
                                            break;

                                        case ShapeLayerContent.ShapeContentType.SolidColorFill:
                                        case ShapeLayerContent.ShapeContentType.GradientFill:
                                            currentFill = (ShapeFill)item;
                                            break;

                                        case ShapeLayerContent.ShapeContentType.Group:
                                        case ShapeLayerContent.ShapeContentType.Path:
                                        case ShapeLayerContent.ShapeContentType.Ellipse:
                                        case ShapeLayerContent.ShapeContentType.Rectangle:
                                        case ShapeLayerContent.ShapeContentType.Polystar:
                                        case ShapeLayerContent.ShapeContentType.Repeater:
                                            //compositionContentsNode.Shapes.Add(compositionShape);
                                            break;

                                        case ShapeLayerContent.ShapeContentType.TrimPath:
                                            // TODO: Individually vs Simultaneously ExpressionKeyFrames
                                            currentTrim = (TrimPath)item;
                                            break;

                                        case ShapeLayerContent.ShapeContentType.MergePaths:
                                        // TODO: Combine all following geometries to a single group
                                        // CombineGeometries(shapesJson(0 -> i -1);
                                        case ShapeLayerContent.ShapeContentType.Transform:
                                            m_issues.Add("Transform shape content type not yet supported.");
                                            continue;
                                        default:
                                            throw new InvalidOperationException();
                                    }
                                    shapes.Add(item);
                                }
                            }
                        }


                        var result = new ShapeLayer(
                            layerName,
                            shapes,
                            layerId,
                            parentId,
                            refId,
                            transform,
                            timeStretch,
                            startProgress,
                            inFrame,
                            outFrame);
                        return result;
                    }
                case Layer.LayerType.Text:
                    {
                        var result = new TextLayer(
                            layerName,
                            layerId,
                            parentId,
                            refId,
                            transform,
                            timeStretch,
                            startProgress,
                            inFrame,
                            outFrame);
                        return result;
                    }
                default:
                    throw new InvalidOperationException();
            }

        }

        static Color GetSolidColorFromString(string hex)
        {
            var index = 1; // Skip '#'
                           // '#AARRGGBB'
            byte a = 255;
            if (hex.Length == 9)
            {
                a = (byte)Convert.ToUInt32(hex.Substring(index, 2), 16);
                index += 2;
            }
            var r = (byte)Convert.ToUInt32(hex.Substring(index, 2), 16);
            index += 2;
            var g = (byte)Convert.ToUInt32(hex.Substring(index, 2), 16);
            index += 2;
            var b = (byte)Convert.ToUInt32(hex.Substring(index, 2), 16);
            return Color.FromArgb(a, r, g, b);
        }

        ShapeLayerContent ReadShapeContent(
            JsonObject obj,
            ShapeFill currentFill,
            ShapeStroke currentStroke,
            TrimPath currentTrim,
            string layerName)
        {
            var type = obj.GetNamedString("ty");

            switch (type)
            {
                case "gr":
                    return ReadShapeGroup(obj, currentFill, currentStroke, currentTrim, layerName);
                case "st":
                    return ReadShapeStroke(obj, currentFill, currentStroke, layerName);
                case "gs":
                    break;
                case "fl":
                    return ReadShapeFill(obj, currentFill, currentStroke, layerName);
                case "gf":
                    m_issues.Add($"Unsupported shape content type: gf GradientFill");
                    return null;
                case "tr":
                    return ReadAnimatableTransform(obj); // TODO: does Transform deserve its own node with name
                case "sh":
                    return ReadPathShape(obj, currentFill, currentStroke, currentTrim, layerName);
                case "el":
                    return ReadEllipseShape(obj, currentFill, currentStroke, currentTrim, layerName);
                case "rc":
                    return ReadRectangleShape(obj, currentFill, currentStroke, currentTrim, layerName);
                case "tm":
                    return ReadTrimPath(obj);
                case "sr":
                    return ReadPolystarShape(obj, currentFill, currentStroke, layerName);
                case "mm":  // MergePath
                    m_issues.Add($"Unsupported shape content type: mm MergePath");
                    return null;
                case "rd":
                    m_issues.Add($"Unsupported shape content type: rd RoundedCorners");
                    return null;
                case "rp":  // Repeater
                    m_issues.Add($"Unsupported shape content type: rp Repeater");
                    return null;
                default:
                    break;
            }
            m_issues.Add($"Unexpected shape content type: {type}");
            return null;
        }

        ShapeGroup ReadShapeGroup(
            JsonObject obj,
            ShapeFill inheritedFill,
            ShapeStroke inheritedStroke,
            TrimPath inheritedTrim,
            string inheritedString)
        {
            var itemsJson = obj.GetNamedArray("it");
            var name = obj.GetNamedString("nm");
            var currentString = inheritedString + "." + name;

            var items = new List<ShapeLayerContent>();
            ShapeFill currentFill = inheritedFill;
            ShapeStroke currentStroke = inheritedStroke;
            TrimPath currentTrim = inheritedTrim;

            for (var i = itemsJson.Count - 1; i >= 0; i--)
            {
                var item = ReadShapeContent(itemsJson[i].GetObject(), currentFill, currentStroke, currentTrim, currentString);
                if (item != null)
                {
                    items.Add(item);
                }
            }
            return new ShapeGroup(name, items);
        }

        // "st"
        ShapeStroke ReadShapeStroke(

            JsonObject obj,
            ShapeFill currentFill,
            ShapeStroke currentStroke,
            string layerName)
        {
            var name = obj.GetNamedString("nm");
            var strokeName = layerName + "." + name;


            // Map ShapeStroke's color data onto ColorBrush.Color
            var jsonColor = obj.GetNamedObject("c", null);

            var color = ReadAnimatableColor(jsonColor);

            var opacity = new AnimatableValue<float>(1F);
            var jsonOpacity = obj.GetNamedObject("o", null);
            if (jsonOpacity != null)
            {
                opacity = ReadScaledAnimatableFloat(jsonOpacity, 1 / 100.0);
            }

            // Get stroke properties to be set on SpriteShape
            var thickness = ReadAnimatableFloat(obj.GetNamedObject("w"));
            var capType = (ShapeStroke.LineCapType)(int)(obj.GetNamedNumber("lc") - 1); //TODO: Why -1? Ask Hernan.
            var joinType = (ShapeStroke.LineJoinType)(int)(obj.GetNamedNumber("lj") - 1);
            var miterLimit = (float)(obj.GetNamedNumber("ml", 4)); // Default miter limit in AfterEffects is 4

            // Get dash pattern to be set as StrokeDashArray
            var dashPattern = new List<float>();
            var offset = new AnimatableValue<float>(0);
            if (obj.ContainsKey("d"))
            {
                var dashesJson = obj.GetNamedArray("d");
                for (uint i = 0; i < dashesJson.Count; i++)
                {
                    var dashJson = dashesJson.GetObjectAt(i);
                    switch (dashJson.GetNamedString("n"))
                    {
                        case "o":
                            offset = ReadAnimatableFloat(dashJson.GetNamedObject("v"));
                            break;
                        case "d":
                        case "g":
                            dashPattern.Add(ReadAnimatableFloat(dashJson.GetNamedObject("v")).InitialValue);
                            break;
                    }
                }
            }

            return new ShapeStroke(strokeName, offset, dashPattern, color, opacity, thickness, capType, joinType, miterLimit);

        }

        // "fl"
        ShapeFill ReadShapeFill(

            JsonObject obj,
            ShapeFill currentFill,
            ShapeStroke currentStroke,
            string currentString)
        {
            // Set name
            var name = obj.GetNamedString("nm");
            var fillName = currentString + "." + name;


            // Map ShapeFill's color data onto ColorBrush.Color
            var jsonColor = obj.GetNamedObject("c", null);
            var color = ReadAnimatableColor(jsonColor);

            // TODO: Push opacity to Brush
            AnimatableValue<float> opacity = new AnimatableValue<float>(1);
            var jsonOpacity = obj.GetNamedObject("o", null);
            if (jsonOpacity != null)
            {
                opacity = ReadScaledAnimatableFloat(jsonOpacity, 1 / 100.0);
            }

            // TODO: Figure out what this is
            bool fillEnabled = obj.GetNamedBoolean("fillEnabled", false);

            // Get FillType and push this data to PathGeometry
            var fillTypeInt = (int)obj.GetNamedNumber("r", 1);
            var fillType = fillTypeInt == 1 ? ShapeFill.PathFillType.Winding : ShapeFill.PathFillType.EvenOdd;

            return new ShapeFill(fillName, fillEnabled, fillType, color, opacity);
        }

        PathShape ReadPathShape(
            JsonObject obj,
            ShapeFill currentFill,
            ShapeStroke currentStroke,
            TrimPath currentTrim,
            string currentString)
        {
            var name = obj.GetNamedString("nm");
            var pathName = currentString + "." + name;

            // Set fill rule (defaults to Alternate)
            // Note: AfterEffects specified a path's fillRule as part of the Fill applied on it, not the Path itself.
            var fillRule = CanvasFilledRegionDetermination.Alternate; //TODO: use platform agnostic enum and convert to Win2D/D2D fillrule as needed?
            if (currentFill != null)
            {
                fillRule = ToCanvasFillRule(currentFill.FillType);
            }

            // Map PathShape's Geometry data to PathGeometry.Path
            var geometry = ReadAnimatableGeometry(obj.GetNamedObject("ks"), fillRule);

            return new PathShape(pathName, geometry);
        }

        // TODO - eliminate this - only used while we have a Win2d dependency
        static CanvasFilledRegionDetermination ToCanvasFillRule(ShapeFill.PathFillType fillType)
        {
            return (fillType == ShapeFill.PathFillType.Winding) ? CanvasFilledRegionDetermination.Winding : CanvasFilledRegionDetermination.Alternate;
        }

        EllipseShape ReadEllipseShape(
            JsonObject obj,
            ShapeFill currentFill,
            ShapeStroke currentStroke,
            TrimPath currentTrim,
            string currentString)
        {

            // Set name
            var name = obj.GetNamedString("nm");
            var ellipseName = currentString + "." + name;

            var position = ReadAnimatableVector2(obj.GetNamedObject("p"));

            var size = ReadScaledAnimatableVector2(obj.GetNamedObject("s"), 0.5); // radius = (0.5)* size

            return new EllipseShape(ellipseName, position, size);
        }

        TrimPath ReadTrimPath(JsonObject obj)
        {
            var start = ReadScaledAnimatableFloat(obj.GetNamedObject("s"), 1 / 100.0);
            var end = ReadScaledAnimatableFloat(obj.GetNamedObject("e"), 1 / 100.0);
            var offset = ReadScaledAnimatableFloat(obj.GetNamedObject("o"), 1 / 360.0); //TODO: Modular function for multiples of 360 -- eg. 3x + 175
            return new TrimPath(obj.GetNamedString("nm"), (TrimPath.TrimType)(int)obj.GetNamedNumber("m", 1), start, end, offset);
        }

        PolystarShape ReadPolystarShape(

            JsonObject obj,
            ShapeFill currentFill,
            ShapeStroke currentStroke,
            string currentString)
        {

            // Set name
            var name = obj.GetNamedString("nm");
            var polystarName = currentString + "." + name;

            var type = (PolystarShape.PolyStarType)(int)obj.GetNamedNumber("sy");

            var points = ReadAnimatableFloat(obj.GetNamedObject("pt"));
            if (points.HasAnimation)
            {
                m_issues.Add("PolyStar.Points animation is unsupported");
            }

            var position = ReadAnimatableVector2(obj.GetNamedObject("p"));
            if (position.HasAnimation)
            {
                // TODO: 
            }

            var rotation = ReadAnimatableFloat(obj.GetNamedObject("r"));
            if (rotation.HasAnimation)
            {
                // TODO:
            }

            var outerRadius = ReadAnimatableFloat(obj.GetNamedObject("or"));
            if (outerRadius.HasAnimation)
            {
                m_issues.Add("PolyStar.OuterRadius animation is unsupported");
            }

            var outerRoundedness = ReadAnimatableFloat(obj.GetNamedObject("os"));
            if (outerRoundedness.HasAnimation)
            {
                m_issues.Add("PolyStar.OuterRoundedness animation is unsupported");
            }

            AnimatableValue<float> innerRadius;
            AnimatableValue<float> innerRoundedness;

            if (type == PolystarShape.PolyStarType.Star)
            {
                innerRadius = ReadAnimatableFloat(obj.GetNamedObject("ir"));
                if (innerRadius.HasAnimation)
                {
                    m_issues.Add("PolyStar.InnerRadius animation is unsupported");
                }

                innerRoundedness = ReadAnimatableFloat(obj.GetNamedObject("is"));
                if (innerRoundedness.HasAnimation)
                {
                    m_issues.Add("PolyStar.InnerRoundedness animation is unsupported");
                }
            }
            else
            {
                innerRadius = null;
                innerRoundedness = null;
            }

            return null;

            // return new PolystarShape(name, type, points, position, rotation, innerRadius, outerRadius, innerRoundedness, outerRoundedness);
        }

        RectangleShape ReadRectangleShape(

            JsonObject obj,
            ShapeFill currentFill,
            ShapeStroke currentStroke,
            TrimPath currentTrim,
            string currentString)
        {
            // Set name
            var name = obj.GetNamedString("nm");
            var rectName = currentString + "." + name;

            // Map RectangleShape's position to RoundedRectangleGeometry.Offset by using custom porporty, Position, and an ExpressionAnimation
            var position = ReadAnimatableVector2(obj.GetNamedObject("p"));

            // Map RectangleShape's size to RoundedRectangleGeometry.Size
            var size = ReadAnimatableVector2(obj.GetNamedObject("s"));

            // Map RectangleShape's size to RoundedRectangleGeometry.CornerRadius
            // CornerRadius data exported from AfterEffects is assumed to be the same for both corner radii.
            var cornerRadius = ReadAnimatableFloat(obj.GetNamedObject("r"));

            return new RectangleShape(rectName, position, size, cornerRadius);
        }

        AnimatableValue<Color> ReadAnimatableColor(JsonObject jsonColor)
        {
            if (jsonColor == null)
            {
                return new AnimatableValue<Color>();
            }

            if (jsonColor.ContainsKey("x"))
            {
                m_issues.Add("Expressions in color animations are not yet supported.");
            }

            s_animatableColorParser.ParseJson(jsonColor, out IEnumerable<KeyFrame<Color>> keyFrames, out Color initialValue);

            return new AnimatableValue<Color>(keyFrames, initialValue);
        }

        AnimatableTransform ReadAnimatableTransform(JsonObject obj)
        {
            AnimatableVector2 anchor = null;
            AnimatableVector2 position = null;
            AnimatableVector2 scale = null;
            AnimatableValue<float> rotation = null;
            AnimatableValue<float> opacity;
            //AnimatableFloat startOpacity = null;
            //AnimatableFloat endOpacity = null;

            var anchorJson = obj.GetNamedObject("a", null);
            if (anchorJson != null)
            {
                anchor = ReadAnimatableVector2(anchorJson);
            }
            else
            {
                // Cameras don't have an anchor point property. Although we don't support them, at least we won't crash.
                m_issues.Add("Layer has no transform property. You may be using an unsupported layer type such as a camera.");
                anchor = new AnimatableVector2();
            }

            var positionJson = obj.GetNamedObject("p", null);
            if (positionJson != null)
            {
                position = ReadAnimatableVector2(positionJson);
            }
            else
            {
                throw new LottieJsonReaderException("Missing transform for position");
            }

            var scaleJson = obj.GetNamedObject("s", null);
            if (scaleJson != null)
            {
                scale = ReadScaledAnimatableVector2(scaleJson, 1 / 100.0);
            }
            else
            {
                // Repeaters have start/end opacity instead of opacity 

            }

            var rotationJson = obj.GetNamedObject("r", null);
            if (rotationJson == null)
            {
                rotationJson = obj.GetNamedObject("rz", null);
            }
            if (rotationJson != null)
            {
                rotation = ReadAnimatableFloat(rotationJson);
            }
            else
            {
                throw new LottieJsonReaderException("Missing transform for rotation");
            }

            var opacityJson = obj.GetNamedObject("o", null);
            if (opacityJson != null)
            {
                opacity = ReadScaledAnimatableFloat(opacityJson, 1 / 100.0);
            }
            else
            {
                // Somehow some community animations don't have opacity in the transform.
                opacity = new AnimatableValue<float>(1);
            }

            //var startOpacityJson = json.GetNamedObject("so", null);
            //if (startOpacityJson != null)
            //{
            //    startOpacity = AnimatableFloat.Factory.NewInstance(startOpacityJson, composition, false);
            //}

            //var endOpacityJson = json.GetNamedObject("eo", null);
            //if (endOpacityJson != null)
            //{
            //    endOpacity = AnimatableFloat.Factory.NewInstance(endOpacityJson, composition, false);
            //}

            return new AnimatableTransform(anchor, position, scale, rotation, opacity);
        }

        AnimatableVector2 ReadAnimatableVector2(JsonObject obj)
        {
            if (obj.ContainsKey("k"))
            {
                // TODO: Spatial Beziers to, ti 
                s_animatableVector2Parser.ParseJson(obj, out IEnumerable<KeyFrame<Vector2>> keyFrames, out Vector2 initialValue);
                return new AnimatableVector2(keyFrames, initialValue);
            }
            else
            {
                // Split X and Y dimensions 
                return new AnimatableVector2(
                    ReadAnimatableFloat(obj.GetNamedObject("x")),
                    ReadAnimatableFloat(obj.GetNamedObject("y")));
            }
        }

        AnimatableVector2 ReadScaledAnimatableVector2(JsonObject obj, double scale)
        {
            if (obj.ContainsKey("k"))
            {
                // TODO: Spatial Beziers to, ti 
                new AnimatableVector2Parser(scale).ParseJson(obj, out IEnumerable<KeyFrame<Vector2>> keyFrames, out Vector2 initialValue);
                return new AnimatableVector2(keyFrames, initialValue);
            }
            else
            {
                // Split X and Y dimensions 
                return new AnimatableVector2(
                    ReadAnimatableFloat(obj.GetNamedObject("x")),
                    ReadAnimatableFloat(obj.GetNamedObject("y")));
            }
        }

        AnimatableValue<PathGeometry> ReadAnimatableGeometry(JsonObject obj, CanvasFilledRegionDetermination fillRule)
        {
            if (obj != null && obj.ContainsKey("x"))
            {
                m_issues.Add("Expressions in geometry animations are not yet supported.");
            }
            new AnimatableGeometryParser(fillRule).ParseJson(obj, out IEnumerable<KeyFrame<PathGeometry>> keyFrames, out PathGeometry initialValue);
            return new AnimatableValue<PathGeometry>(keyFrames, initialValue);
        }


        AnimatableValue<float> ReadAnimatableFloat(JsonObject obj)
        {
            if (obj != null && obj.ContainsKey("x"))
            {
                m_issues.Add("Expressions in float animations are not yet supported.");
            }
            s_animatableFloatParser.ParseJson(obj, out IEnumerable<KeyFrame<float>> keyFrames, out float initialValue);
            return new AnimatableValue<float>(keyFrames, initialValue);
        }

        AnimatableValue<float> ReadScaledAnimatableFloat(JsonObject obj, double scale)
        {
            if (obj != null && obj.ContainsKey("x"))
            {
                m_issues.Add("Expressions in float animations are not yet supported.");
            }
            new AnimatableFloatParser(scale).ParseJson(obj, out IEnumerable<KeyFrame<float>> keyFrames, out float initialValue);
            return new AnimatableValue<float>(keyFrames, initialValue);
        }

        sealed class AnimatableVector2Parser : AnimatableValueParser<Vector2>
        {
            internal AnimatableVector2Parser(double scale) : base(Vector2ValueFactory(scale)) { }

            static Func<IJsonValue, Vector2> Vector2ValueFactory(double scale) =>
                (IJsonValue obj) => Vector2FromJsonArray(obj.GetArray()) * (float)scale;

            static Vector2 Vector2FromJsonArray(JsonArray values)
            {
                if (values.Count < 2)
                {
                    throw new LottieJsonReaderException($"Unable to parse point for {values}");
                }
                return new Vector2(ReadFloat(values[0]), ReadFloat(values[1]));
            }
        }

        sealed class AnimatableColorParser : AnimatableValueParser<Color>
        {
            internal AnimatableColorParser() : base(ColorValueFactory) { }

            static Func<IJsonValue, Color> ColorValueFactory => (IJsonValue obj) =>
            {
                var colorArray = obj.GetArray();
                if (colorArray.Count == 4)
                {
                    var shouldUse255 = true;
                    for (var i = 0; i < colorArray.Count; i++)
                    {
                        var colorChannel = colorArray[i].GetNumber();
                        if (colorChannel > 1)
                        {
                            shouldUse255 = false;
                        }
                    }

                    var multiplier = shouldUse255 ? 255f : 1f;
                    return Color.FromArgb(
                        (byte)(colorArray[3].GetNumber() * multiplier),
                        (byte)(colorArray[0].GetNumber() * multiplier),
                        (byte)(colorArray[1].GetNumber() * multiplier),
                        (byte)(colorArray[2].GetNumber() * multiplier));
                }
                // Return black.
                return Color.FromArgb(255, 0, 0, 0);
            };
        }

        sealed class AnimatableGeometryParser : AnimatableValueParser<PathGeometry>
        {
            internal AnimatableGeometryParser(CanvasFilledRegionDetermination fillRule) : base(PathGeometryFactory.Instance(fillRule)) { }

            sealed class PathGeometryFactory
            {
                readonly CanvasFilledRegionDetermination _fillRule;

                internal static Func<IJsonValue, PathGeometry> Instance(CanvasFilledRegionDetermination fillRule)
                {
                    return new PathGeometryFactory(fillRule).ReadPathGeometryFromJson;
                }

                PathGeometryFactory(CanvasFilledRegionDetermination fillRule)
                {
                    _fillRule = fillRule;
                }

                PathGeometry ReadPathGeometryFromJson(IJsonValue value)
                {
                    JsonObject pointsData = null;
                    if (value.ValueType == JsonValueType.Array)
                    {
                        var firstObject = value.GetArray()[0];
                        if (firstObject.ValueType == JsonValueType.Object && firstObject.GetObject().ContainsKey("v"))
                        {
                            pointsData = firstObject.GetObject();
                        }
                    }
                    else if (value.ValueType == JsonValueType.Object && value.GetObject().ContainsKey("v"))
                    {
                        pointsData = value.GetObject();
                    }

                    if (pointsData == null)
                    {
                        return null;
                    }

                    var vertices = pointsData.GetNamedArray("v", null);
                    var inTangents = pointsData.GetNamedArray("i", null);
                    var outTangents = pointsData.GetNamedArray("o", null);
                    var closed = pointsData.GetNamedBoolean("c", false);

                    if (vertices == null || inTangents == null || outTangents == null || vertices.Count != inTangents.Count || vertices.Count != outTangents.Count)
                    {
                        throw new LottieJsonReaderException($"Unable to process points array or tangents. {pointsData}");
                    }

                    var fillRule = (_fillRule == CanvasFilledRegionDetermination.Alternate) ? FillRule.Alternate : FillRule.EvenOdd;
                    var initialPoint = new Vector2();
                    var beziers = new List<BezierSegment>();

                    if (vertices.Count == 0)
                    {
                        return new PathGeometry(initialPoint, beziers, false, fillRule);
                    }

                    var length = vertices.Count;
                    var vertex = PointAtIndex(0, vertices);

                    initialPoint = vertex; // initial point

                    for (var i = 1; i < length; i++)
                    {
                        vertex = PointAtIndex(i, vertices);
                        var previousVertex = PointAtIndex(i - 1, vertices); // TODO: reuse previouVertex = vertex 
                        var relCp1 = PointAtIndex(i - 1, outTangents);
                        var relCp2 = PointAtIndex(i, inTangents);
                        var controlPoint1 = previousVertex + relCp1;
                        var controlPoint2 = vertex + relCp2;

                        var bezier = new BezierSegment(controlPoint1, controlPoint2, vertex); // add cubic bezier curve to next vertex
                        beziers.Add(bezier);
                    }

                    if (closed)
                    {
                        vertex = PointAtIndex(0, vertices);
                        var previousVertex = PointAtIndex(length - 1, vertices);
                        var relCp1 = PointAtIndex(length - 1, outTangents);
                        var relCp2 = PointAtIndex(0, inTangents);
                        var controlPoint1 = previousVertex + relCp1;
                        var controlPoint2 = vertex + relCp2;

                        var bezier = new BezierSegment(controlPoint1, controlPoint2, vertex);
                        beziers.Add(bezier);
                    }



                    return new PathGeometry(initialPoint, beziers, closed, fillRule);
                }

                static Vector2 PointAtIndex(int idx, JsonArray points)
                {
                    if (idx >= points.Count)
                    {
                        throw new LottieJsonReaderException($"Invalid index {idx}. There are only {points.Count} points.");
                    }

                    var pointArray = points.GetArrayAt((uint)idx);
                    var x = pointArray[0];
                    var y = pointArray[1];
                    return new Vector2(x != null ? (float)x.GetNumber() : 0, y != null ? (float)y.GetNumber() : 0);
                }
            }
        }

        sealed class AnimatableFloatParser : AnimatableValueParser<float>
        {
            internal AnimatableFloatParser(double factor) : base(FloatValueFactory(factor)) { }

            static Func<IJsonValue, float> FloatValueFactory(double scale) => (IJsonValue obj) => (float)(ReadFloat(obj) * scale);
        }

        abstract class AnimatableValueParser<T>
        {
            readonly Func<IJsonValue, T> _valueFactory;

            protected AnimatableValueParser(Func<IJsonValue, T> valueFactory)
            {
                _valueFactory = valueFactory;
            }

            internal void ParseJson(JsonObject obj, out IEnumerable<KeyFrame<T>> keyFrames, out T initialValue)
            {
                keyFrames = ParseKeyframes(obj);
                initialValue = ParseInitialValue(keyFrames, obj);
            }

            KeyFrame<T>[] ParseKeyframes(JsonObject obj)
            {
                if (obj != null)
                {
                    var k = obj["k"];
                    if (HasKeyframes(k))
                    {
                        return ReadKeyFrames(k.GetArray()).ToArray();
                    }
                }
                // No keyframes or no json - return an empty list.
                return new KeyFrame<T>[0];
            }

            T ParseInitialValue(IEnumerable<KeyFrame<T>> keyframes, JsonObject obj)
            {
                if (obj != null)
                {
                    if (keyframes.Any())
                    {
                        return keyframes.First().Value;
                    }
                    return _valueFactory(obj["k"]);
                }
                return default(T);
            }

            static bool HasKeyframes(IJsonValue json)
            {
                if (json.ValueType != JsonValueType.Array)
                {
                    return false;
                }

                var firstObject = json.GetArray()[0];
                return firstObject.ValueType == JsonValueType.Object && firstObject.GetObject().ContainsKey("t");
            }

            IEnumerable<KeyFrame<T>> ReadKeyFrames(JsonArray json)
            {
                if (!json.Any())
                {
                    yield break;
                }

                // Keyframes are encoded in Lottie as an array consisting of a sequence
                // of start and end value with easing functions, with the final value
                // being the frame number for the last end value.
                // [
                //   { start, end },
                //   { start, end },
                //   { start, end },
                //   { endFrame }
                // ]

                var startEndPairs = json.Take(json.Count() - 1);
                var finalFrame = json.Last();

                Easing easing = null;
                T endValue = default(T);
                bool isFirstTimeThroughLoop = true;
                foreach (var pair in startEndPairs.Select(v => v.GetObject()))
                {
                    var startFrame = (float)pair.GetNamedNumber("t", 0);

                    if (!isFirstTimeThroughLoop)
                    {
                        // This is not the first time through the loop. Get the endValue from
                        // the previous pair and create a keyframe.
                        yield return new KeyFrame<T>(endValue, easing, startFrame);
                    }
                    else
                    {
                        isFirstTimeThroughLoop = false;
                    }

                    T startValue = default(T);
                    if (pair.TryGetValue("s", out var startValueJson))
                    {
                        startValue = _valueFactory(startValueJson);
                    }

                    // Create the keyframe for the starting value.
                    yield return new KeyFrame<T>(startValue, easing, startFrame);


                    // Read the end value. The end frame number isn't known until 
                    // the next pair is read.
                    if (pair.TryGetValue("e", out var endValueJson))
                    {
                        endValue = _valueFactory(endValueJson);
                    }


                    // Read the easing function used to interpolate to the end value.
                    easing = null;
                    Vector2? cp1 = null;
                    Vector2? cp2 = null;
                    if ((int)pair.GetNamedNumber("h", 0) == 1)
                    {
                        // Start and end value are the same.
                        // TODO - what if h is specified AND an end value is specified?
                        endValue = startValue;
                    }
                    else
                    {
                        //TODO: Confirm o and i order
                        // Reading the easing function parameters.
                        var cp1Json = pair.GetNamedObject("o", null);
                        var cp2Json = pair.GetNamedObject("i", null);
                        if (cp1Json != null && cp2Json != null)
                        {
                            cp1 = new Vector2(ReadFloat(cp1Json["x"]), ReadFloat(cp1Json["y"]));
                            cp2 = new Vector2(ReadFloat(cp2Json["x"]), ReadFloat(cp2Json["y"]));
                            // TODO: Clamp Control Points if the X, Y values are through the roof
                            easing = new CubicBezierEasing(cp1.Value, cp2.Value);
                        }
                    }
                }

                if (!isFirstTimeThroughLoop)
                {
                    // Output the final keyframe if at least one pair was read.
                    var finalFrameNumber = (float)finalFrame.GetObject().GetNamedNumber("t", 0);
                    yield return new KeyFrame<T>(endValue, easing, finalFrameNumber);
                }
            }
        }

        static float ReadFloat(IJsonValue jsonValue)
        {
            switch (jsonValue.ValueType)
            {
                case JsonValueType.Number:
                    return (float)jsonValue.GetNumber();
                case JsonValueType.Array:
                    return (float)jsonValue.GetArray()[0].GetNumber();
                case JsonValueType.Null:
                case JsonValueType.Boolean:
                case JsonValueType.String:
                case JsonValueType.Object:
                default:
                    return 0;
            }
        }
    }
}
