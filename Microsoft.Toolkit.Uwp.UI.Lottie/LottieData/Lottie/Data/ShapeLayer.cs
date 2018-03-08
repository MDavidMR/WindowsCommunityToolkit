using System.Collections.Generic;
using System.Linq;

namespace Lottie.Data
{
    public sealed class ShapeLayer : Layer
    {
        readonly IEnumerable<ShapeLayerContent> _shapes;

        public ShapeLayer(
            string name,
            IEnumerable<ShapeLayerContent> shapes,
            int layerId,
            int? parentId,
            string refId,
            AnimatableTransform transform,
            float timeStretch,
            float startProgress,
            float inFrame,
            float outFrame)
         : base(
             name,
             layerId,
             parentId,
             refId,
             transform,
             timeStretch,
             startProgress,
             inFrame,
             outFrame)
        {
            _shapes = shapes;
        }


        public IEnumerable<ShapeLayerContent> Contents => _shapes.AsEnumerable();

        public override LayerType Type => LayerType.Shape;

    }
}
