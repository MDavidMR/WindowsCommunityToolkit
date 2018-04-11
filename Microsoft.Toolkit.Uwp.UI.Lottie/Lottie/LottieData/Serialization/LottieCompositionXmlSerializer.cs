using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace LottieData.Tools
{
#if !WINDOWS_UWP
    public
#endif
    sealed class LottieCompositionXmlSerializer
    {
        LottieCompositionXmlSerializer() { }

        public static XDocument ToXml(LottieObject lottieObject)
        {
            return new LottieCompositionXmlSerializer().ToXDocument(lottieObject);
        }

        XDocument ToXDocument(LottieObject lottieObject)
        {
            return new XDocument(FromLottieObject(lottieObject));
        }

        XElement FromLottieObject(LottieObject obj)
        {
            switch (obj.ObjectType)
            {
                case LottieObjectType.Ellipse:
                    return FromEllipse((Ellipse)obj);
                case LottieObjectType.ImageLayer:
                    return FromImageLayer((ImageLayer)obj);
                case LottieObjectType.LinearGradientFill:
                    return FromLinearGradientFill((LinearGradientFill)obj);
                case LottieObjectType.LinearGradientStroke:
                    return FromLinearGradientStroke((LinearGradientStroke)obj);
                case LottieObjectType.LottieComposition:
                    return FromLottieComposition((LottieComposition)obj);
                case LottieObjectType.MergePaths:
                    return FromMergePaths((MergePaths)obj);
                case LottieObjectType.NullLayer:
                    return FromNullLayer((NullLayer)obj);
                case LottieObjectType.Polystar:
                    return FromPolystar((Polystar)obj);
                case LottieObjectType.PreCompLayer:
                    return FromPreCompLayer((PreCompLayer)obj);
                case LottieObjectType.RadialGradientFill:
                    return FromRadialGradientFill((RadialGradientFill)obj);
                case LottieObjectType.RadialGradientStroke:
                    return FromRadialGradientStroke((RadialGradientStroke)obj);
                case LottieObjectType.Rectangle:
                    return FromRectangle((Rectangle)obj);
                case LottieObjectType.Repeater:
                    return FromRepeater((Repeater)obj);
                case LottieObjectType.RoundedCorner:
                    return FromRoundedCorner((RoundedCorner)obj);
                case LottieObjectType.Shape:
                    return FromShape((Shape)obj);
                case LottieObjectType.ShapeGroup:
                    return FromShapeGroup((ShapeGroup)obj);
                case LottieObjectType.ShapeLayer:
                    return FromShapeLayer((ShapeLayer)obj);
                case LottieObjectType.SolidColorFill:
                    return FromSolidColorFill((SolidColorFill)obj);
                case LottieObjectType.SolidColorStroke:
                    return FromSolidColorStroke((SolidColorStroke)obj);
                case LottieObjectType.SolidLayer:
                    return FromSolidLayer((SolidLayer)obj);
                case LottieObjectType.TextLayer:
                    return FromTextLayer((TextLayer)obj);
                case LottieObjectType.Transform:
                    return FromTransform((Transform)obj);
                case LottieObjectType.TrimPath:
                    return FromTrimPath((TrimPath)obj);
            }
            throw new InvalidOperationException();
        }

        XElement FromLottieComposition(LottieComposition lottieComposition)
        {
            return new XElement("LottieComposition", GetContents());
            IEnumerable<XObject> GetContents()
            {
                yield return new XAttribute("Version", lottieComposition.Version.ToString());
                if (!string.IsNullOrWhiteSpace(lottieComposition.Name))
                {
                    yield return new XAttribute("Name", lottieComposition.Name);
                }
                yield return new XAttribute("Width", lottieComposition.Width);
                yield return new XAttribute("Height", lottieComposition.Height);
                yield return new XAttribute("InPoint", lottieComposition.InPoint);
                yield return new XAttribute("OutPoint", lottieComposition.OutPoint);
                yield return FromAssetCollection(lottieComposition.Assets);
                yield return FromLayerComposition(lottieComposition.Layers);
            }
        }


        XElement FromAssetCollection(AssetCollection assets)
        {
            return new XElement("Assets", GetContents());
            IEnumerable<XObject> GetContents()
            {
                foreach (var asset in assets)
                {
                    yield return FromAsset(asset);
                }
            }
        }

        XElement FromAsset(Asset asset)
        {
            switch (asset.Type)
            {
                case Asset.AssetType.LayerCollection:
                    return FromLayersAsset((LayerCollectionAsset)asset);
                default:
                    throw new InvalidOperationException();
            }
        }

        XElement FromLayersAsset(LayerCollectionAsset asset)
        {
            return new XElement("LayerComposition",
                new XAttribute("Id", asset.Id),
                FromLayerComposition(asset.Layers));
        }

        XElement FromLayerComposition(LayerCollection layers)
        {
            return new XElement("Layers", GetContents());
            IEnumerable<XElement> GetContents()
            {
                foreach (var layer in layers.GetLayersBottomToTop().Reverse())
                {
                    yield return FromLayer(layer);
                }
            }
        }

        XElement FromLayer(Layer layer)
        {
            switch (layer.Type)
            {
                case Layer.LayerType.PreComp:
                    return FromPreCompLayer((PreCompLayer)layer);
                case Layer.LayerType.Solid:
                    return FromSolidLayer((SolidLayer)layer);
                case Layer.LayerType.Image:
                    return FromImageLayer((ImageLayer)layer);
                case Layer.LayerType.Null:
                    return FromNullLayer((NullLayer)layer);
                case Layer.LayerType.Shape:
                    return FromShapeLayer((ShapeLayer)layer);
                case Layer.LayerType.Text:
                    return FromTextLayer((TextLayer)layer);
                default:
                    throw new InvalidOperationException();
            }
        }

        IEnumerable<XObject> GetLayerContents(Layer layer)
        {
            yield return new XAttribute("Id", layer.Id);
            yield return new XAttribute("Name", layer.Name);
            if (layer.IsHidden)
            {
                yield return new XAttribute("Hidden", layer.IsHidden);
            }
            yield return new XAttribute("StartTime", layer.StartTime);
            yield return new XAttribute("InPoint", layer.InPoint);
            yield return new XAttribute("OutPoint", layer.OutPoint);

            if (layer.ParentId.HasValue)
            {
                yield return new XAttribute("ParentId", layer.ParentId.Value);
            }
            yield return FromTransform(layer.Transform);

        }

        XElement FromPreCompLayer(PreCompLayer layer)
        {
            return new XElement("PreComp", GetContents());
            IEnumerable<XObject> GetContents()
            {
                foreach (var item in GetLayerContents(layer))
                {
                    yield return item;
                }
                yield return new XAttribute("Width", layer.Width);
                yield return new XAttribute("Height", layer.Height);
                if (!string.IsNullOrWhiteSpace(layer.RefId))
                {
                    yield return new XAttribute("RefId", layer.RefId);
                }
            }
        }

        XElement FromSolidLayer(SolidLayer layer)
        {
            return new XElement("Solid", GetContents());
            IEnumerable<XObject> GetContents()
            {
                foreach (var item in GetLayerContents(layer))
                {
                    yield return item;
                }

                yield return new XAttribute("Width", layer.Width);
                yield return new XAttribute("Height", layer.Height);
                // TODO - don't rely on ToString on color
                yield return new XAttribute("Color", layer.Color);
            }
        }

        XElement FromImageLayer(ImageLayer layer)
        {
            return new XElement("Image", GetContents());
            IEnumerable<XObject> GetContents()
            {
                foreach (var item in GetLayerContents(layer))
                {
                    yield return item;
                }
            }
        }

        XElement FromNullLayer(NullLayer layer)
        {
            return new XElement("Null", GetContents());
            IEnumerable<XObject> GetContents()
            {
                foreach (var item in GetLayerContents(layer))
                {
                    yield return item;
                }
            }
        }

        XElement FromShapeLayer(ShapeLayer layer)
        {
            return new XElement("Shape", GetContents());
            IEnumerable<XObject> GetContents()
            {
                foreach (var item in GetLayerContents(layer))
                {
                    yield return item;
                }

                foreach (var shapeContent in layer.Contents)
                {
                    yield return FromShapeLayerContent(shapeContent);
                }
            }
        }

        XElement FromTextLayer(TextLayer layer)
        {
            return new XElement("Text", GetContents());
            IEnumerable<XObject> GetContents()
            {
                foreach (var item in GetLayerContents(layer))
                {
                    yield return item;
                }
            }
        }

        XElement FromShapeLayerContent(ShapeLayerContent content)
        {
            switch (content.ContentType)
            {
                case ShapeContentType.Group:
                    return FromShapeGroup((ShapeGroup)content);
                case ShapeContentType.SolidColorStroke:
                    return FromSolidColorStroke((SolidColorStroke)content);
                case ShapeContentType.LinearGradientStroke:
                    return FromLinearGradientStroke((LinearGradientStroke)content);
                case ShapeContentType.RadialGradientStroke:
                    return FromRadialGradientStroke((RadialGradientStroke)content);
                case ShapeContentType.SolidColorFill:
                    return FromSolidColorFill((SolidColorFill)content);
                case ShapeContentType.LinearGradientFill:
                    return FromLinearGradientFill((LinearGradientFill)content);
                case ShapeContentType.RadialGradientFill:
                    return FromRadialGradientFill((RadialGradientFill)content);
                case ShapeContentType.Transform:
                    return FromTransform((Transform)content);
                case ShapeContentType.Path:
                    return FromPath((Shape)content);
                case ShapeContentType.Ellipse:
                    return FromEllipse((Ellipse)content);
                case ShapeContentType.Rectangle:
                    return FromRectangle((Rectangle)content);
                case ShapeContentType.Polystar:
                    return FromPolystar((Polystar)content);
                case ShapeContentType.TrimPath:
                    return FromTrimPath((TrimPath)content);
                case ShapeContentType.MergePaths:
                    return FromMergePaths((MergePaths)content);
                case ShapeContentType.Repeater:
                    return FromRepeater((Repeater)content);
                case ShapeContentType.RoundedCorner:
                    return FromRoundedCorner((RoundedCorner)content);
                default:
                    throw new InvalidOperationException();
            }
        }

        XElement FromShapeGroup(ShapeGroup content)
        {
            return new XElement("Group", GetContents());
            IEnumerable<XObject> GetContents()
            {
                foreach (var item in GetShapeLayerContentContents(content))
                {
                    yield return item;
                }

                foreach (var item in content.Items)
                {
                    yield return FromShapeLayerContent(item);
                }
            }
        }

        XElement FromSolidColorStroke(SolidColorStroke content)
        {
            return new XElement("SolidColorStroke", GetContents());
            IEnumerable<XObject> GetContents()
            {
                foreach (var item in GetShapeLayerContentContents(content))
                {
                    yield return item;
                }
            }
        }

        XElement FromLinearGradientStroke(LinearGradientStroke content)
        {
            return new XElement("LinearGradientStroke", GetContents());
            IEnumerable<XObject> GetContents()
            {
                foreach (var item in GetShapeLayerContentContents(content))
                {
                    yield return item;
                }
            }
        }

        XElement FromRadialGradientStroke(RadialGradientStroke content)
        {
            return new XElement("RadialGradientStroke", GetContents());
            IEnumerable<XObject> GetContents()
            {
                foreach (var item in GetShapeLayerContentContents(content))
                {
                    yield return item;
                }
            }
        }

        XElement FromSolidColorFill(SolidColorFill content)
        {
            return new XElement("SolidColorFill", GetContents());
            IEnumerable<XObject> GetContents()
            {
                foreach (var item in GetShapeLayerContentContents(content))
                {
                    yield return item;
                }

                yield return FromAnimatable("Color", content.Color);
                yield return FromAnimatable("OpacityPercent", content.OpacityPercent);

            }
        }

        XElement FromLinearGradientFill(LinearGradientFill content)
        {
            return new XElement("LinearGradientFill", GetContents());
            IEnumerable<XObject> GetContents()
            {
                foreach (var item in GetShapeLayerContentContents(content))
                {
                    yield return item;
                }
            }
        }

        XElement FromRadialGradientFill(RadialGradientFill content)
        {
            return new XElement("RadialGradientFill", GetContents());
            IEnumerable<XObject> GetContents()
            {
                foreach (var item in GetShapeLayerContentContents(content))
                {
                    yield return item;
                }
            }
        }

        XElement FromTransform(Transform content)
        {
            return new XElement("Transform", GetContents());
            IEnumerable<XObject> GetContents()
            {
                foreach (var item in GetShapeLayerContentContents(content))
                {
                    yield return item;
                }

                yield return FromAnimatableVector3(nameof(content.ScalePercent), content.ScalePercent);
                yield return FromAnimatableVector3(nameof(content.Position), content.Position);
                yield return FromAnimatableVector3(nameof(content.Anchor), content.Anchor);
                yield return FromAnimatable(nameof(content.OpacityPercent), content.OpacityPercent);
                yield return FromAnimatable(nameof(content.RotationDegrees), content.RotationDegrees);
            }
        }

        XObject FromAnimatableVector3(string name, IAnimatableVector3 animatable)
        {
            switch (animatable.Type)
            {
                case AnimatableVector3Type.Vector3:
                    return FromAnimatable(name, (AnimatableVector3)animatable);
                case AnimatableVector3Type.XYZ:
                    {

                        var xyz = (AnimatableXYZ)animatable;
                        return new XElement(name,
                            FromAnimatable(nameof(xyz.X), xyz.X),
                            FromAnimatable(nameof(xyz.Y), xyz.Y),
                            FromAnimatable(nameof(xyz.Z), xyz.Z));
                    }
                default:
                    throw new InvalidOperationException();
            }
        }

        XObject FromAnimatable<T>(string name, Animatable<T> animatable) where T : IEquatable<T>
        {
            if (!animatable.IsAnimated)
            {
                // TODO - don't rely on tostring on the value.
                return new XAttribute(name, $"{animatable.InitialValue}");
            }
            else
            {
                // TODO - don't rely on tostring on the value.
                var keyframesString = $"{animatable.InitialValue}{string.Join("", animatable.KeyFrames.Select(kf => $", {kf.Value}@{kf.Frame}"))}";

                return new XAttribute(name, keyframesString);
            }
        }


        XElement FromPath(Shape content)
        {
            return new XElement("Path", GetContents());
            IEnumerable<XObject> GetContents()
            {
                foreach (var item in GetShapeLayerContentContents(content))
                {
                    yield return item;
                }
            }
        }

        XElement FromEllipse(Ellipse content)
        {
            return new XElement("Ellipse", GetContents());
            IEnumerable<XObject> GetContents()
            {
                foreach (var item in GetShapeLayerContentContents(content))
                {
                    yield return item;
                }
                yield return FromAnimatableVector3(nameof(content.Diameter), content.Diameter);
                yield return FromAnimatableVector3(nameof(content.Position), content.Position);
            }
        }

        XElement FromShape(Shape content)
        {
            return new XElement("Shape", GetContents());
            IEnumerable<XObject> GetContents()
            {
                foreach (var item in GetShapeLayerContentContents(content))
                {
                    yield return item;
                }
            }
        }

        XElement FromRectangle(Rectangle content)
        {
            return new XElement("Rectangle", GetContents());
            IEnumerable<XObject> GetContents()
            {
                foreach (var item in GetShapeLayerContentContents(content))
                {
                    yield return item;
                }
            }
        }

        XElement FromPolystar(Polystar content)
        {
            return new XElement("Polystar", GetContents());
            IEnumerable<XObject> GetContents()
            {
                foreach (var item in GetShapeLayerContentContents(content))
                {
                    yield return item;
                }
            }
        }

        XElement FromTrimPath(TrimPath content)
        {
            return new XElement("TrimPath", GetContents());
            IEnumerable<XObject> GetContents()
            {
                foreach (var item in GetShapeLayerContentContents(content))
                {
                    yield return item;
                }
            }
        }

        XElement FromMergePaths(MergePaths content)
        {
            return new XElement("MergePaths", GetContents());
            IEnumerable<XObject> GetContents()
            {
                foreach (var item in GetShapeLayerContentContents(content))
                {
                    yield return item;
                }
            }
        }
        XElement FromRoundedCorner(RoundedCorner content)
        {
            return new XElement("RoundedCorner", GetContents());
            IEnumerable<XObject> GetContents()
            {
                foreach (var item in GetShapeLayerContentContents(content))
                {
                    yield return item;
                }
            }
        }

        XElement FromRepeater(Repeater content)
        {
            return new XElement("Repeater", GetContents());
            IEnumerable<XObject> GetContents()
            {
                foreach (var item in GetShapeLayerContentContents(content))
                {
                    yield return item;
                }
            }
        }

        IEnumerable<XObject> GetShapeLayerContentContents(ShapeLayerContent content)
        {
            if (!string.IsNullOrWhiteSpace(content.Name))
            {
                yield return new XAttribute("Name", content.Name);
            }
            if (!string.IsNullOrWhiteSpace(content.MatchName))
            {
                yield return new XAttribute("MatchName", content.MatchName);
            }
        }
    }
}
