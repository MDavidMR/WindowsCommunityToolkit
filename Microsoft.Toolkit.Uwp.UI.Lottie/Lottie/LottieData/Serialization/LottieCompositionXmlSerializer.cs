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
        public static XDocument ToXml(LottieComposition lottieComposition)
        {
            return new LottieCompositionXmlSerializer().ToXDocument(lottieComposition);
        }

        XDocument ToXDocument(LottieComposition lottieComposition)
        {
            return new XDocument(FromLottieComposition(lottieComposition));
        }

        XElement FromLottieComposition(LottieComposition lottieComposition)
        {
            return new XElement("LottieComposition", GetContents());
            IEnumerable<XObject> GetContents()
            {
                if (!string.IsNullOrWhiteSpace(lottieComposition.Name))
                {
                    yield return new XAttribute("Name", lottieComposition.Name);
                }
                yield return new XAttribute("Width", lottieComposition.Width);
                yield return new XAttribute("Height", lottieComposition.Height);
                yield return FromAssetCollection(lottieComposition.Assets);
                yield return FromLayerCollection(lottieComposition.Layers);
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
            return new XElement("LayerCollection",
                new XAttribute("Id", asset.Id),
                FromLayerCollection(asset.Layers));
        }

        XElement FromLayerCollection(LayerCollection layers)
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
            yield return new XAttribute("Hidden", layer.IsHidden);
            if (layer.ParentId.HasValue)
            {
                yield return new XAttribute("ParentId", layer.ParentId.Value);
            }
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
                case ShapeLayerContent.ShapeContentType.Group:
                    return FromShapeGroup((ShapeGroup)content);
                case ShapeLayerContent.ShapeContentType.SolidColorStroke:
                    return FromSolidColorStroke((SolidColorStroke)content);
                case ShapeLayerContent.ShapeContentType.LinearGradientStroke:
                    return FromLinearGradientStroke((LinearGradientStroke)content);
                case ShapeLayerContent.ShapeContentType.RadialGradientStroke:
                    return FromRadialGradientStroke((RadialGradientStroke)content);
                case ShapeLayerContent.ShapeContentType.SolidColorFill:
                    return FromSolidColorFill((SolidColorFill)content);
                case ShapeLayerContent.ShapeContentType.LinearGradientFill:
                    return FromLinearGradientFill((LinearGradientFill)content);
                case ShapeLayerContent.ShapeContentType.RadialGradientFill:
                    return FromRadialGradientFill((RadialGradientFill)content);
                case ShapeLayerContent.ShapeContentType.Transform:
                    return FromTransform((Transform)content);
                case ShapeLayerContent.ShapeContentType.Path:
                    return FromPath((Shape)content);
                case ShapeLayerContent.ShapeContentType.Ellipse:
                    return FromEllipse((Ellipse)content);
                case ShapeLayerContent.ShapeContentType.Rectangle:
                    return FromRectangle((Rectangle)content);
                case ShapeLayerContent.ShapeContentType.Polystar:
                    return FromPolystar((Polystar)content);
                case ShapeLayerContent.ShapeContentType.TrimPath:
                    return FromTrimPath((TrimPath)content);
                case ShapeLayerContent.ShapeContentType.MergePaths:
                    return FromMergePaths((MergePaths)content);
                case ShapeLayerContent.ShapeContentType.Repeater:
                    return FromRepeater((Repeater)content);
                case ShapeLayerContent.ShapeContentType.RoundedCorner:
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
