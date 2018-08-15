using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Geometry;
using Microsoft.Graphics.Canvas.Text;
using System;
using System.Numerics;
using Windows.UI;
using Windows.UI.Composition;

namespace Debug
{
    // Creates a Visual that displays the value of an animated scalar property.
    sealed class ScalarPropertyMeter
    {

        internal static Visual CreateMeter(CompositionObject scalarPropertyOwner, string scalarPropertyAccessor, int numberOfDigits = 5)
        {
            var c = scalarPropertyOwner.Compositor;

            var root = c.CreateContainerVisual();

            var shapeVisual = c.CreateShapeVisual();
            shapeVisual.Clip = c.CreateInsetClip();
            shapeVisual.Size = new Vector2(8 * numberOfDigits, 8);
            root.Children.InsertAtTop(shapeVisual);

            // Create a colored background
            var rectangle = c.CreateRectangleGeometry();
            rectangle.Size = shapeVisual.Size * 5;

            var backgroundShape = c.CreateSpriteShape(rectangle);
            shapeVisual.Shapes.Add(backgroundShape);
            backgroundShape.FillBrush = c.CreateColorBrush(Colors.Red);


            var numberStrip = new CompositionPath(CreateNumberStrip());

            for (var i = 0; i < numberOfDigits; i++)
            {
                var digit = c.CreateSpriteShape();
                shapeVisual.Shapes.Add(digit);
                digit.Geometry = c.CreatePathGeometry(numberStrip);
                digit.FillBrush = c.CreateColorBrush(Colors.Green);

                var expression =
                    i < numberOfDigits - 1
                    ? $"Vector2({(i * 8) + 1}, (Floor(Mod(obj.{scalarPropertyAccessor} * {Math.Pow(10, i)}, 10)) * -8.0) - 1.5)"
                    // Treat the final digit specially: don't floor the the value so that it will roll between values.
                    : $"Vector2({(i * 8) + 1}, (Mod(obj.{scalarPropertyAccessor} * {Math.Pow(10, i)}, 10) * -8.0) - 1.5)";

                var animation = c.CreateExpressionAnimation(expression);
                animation.SetReferenceParameter("obj", scalarPropertyOwner);
                digit.StartAnimation("Offset", animation);
            }

            return root;
        }

        static CanvasGeometry CreateNumberStrip()
        {
            // Size seems to be ignored
            const float size = 10;

            var textLayout = new CanvasTextLayout(
                resourceCreator: CanvasDevice.GetSharedDevice(),
                textString: "9\n0\n1\n2\n3\n4\n5\n6\n7\n8\n9\n0",
                textFormat: new CanvasTextFormat() { FontFamily = "Arial", LineSpacing = 8, FontSize = 10 },
                requestedWidth: size,
                requestedHeight: size);
            return CanvasGeometry.CreateText(textLayout);
        }

    }
}
