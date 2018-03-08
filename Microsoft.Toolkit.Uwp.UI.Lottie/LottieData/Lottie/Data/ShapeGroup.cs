using System.Collections.Generic;

namespace Lottie.Data
{
    public sealed class ShapeGroup : ShapeLayerContent
    {
        public ShapeGroup(
            string name,
            IEnumerable<ShapeLayerContent> items) 
            : base(name)
        {
            Items = items;
        }

        public override ShapeContentType ContentType => ShapeContentType.Group;

        public IEnumerable<ShapeLayerContent> Items { get; }
    }
}
