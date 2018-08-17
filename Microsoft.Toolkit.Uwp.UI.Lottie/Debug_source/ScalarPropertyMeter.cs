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
        const float digitHeight = 8;
        const float digitWidth = 8;

        static readonly CanvasTextFormat s_textFormat =
            new CanvasTextFormat()
            {
                FontFamily = "Arial",
                LineSpacing = digitHeight,
                FontSize = 10,
                HorizontalAlignment = CanvasHorizontalAlignment.Center
            };

        readonly Compositor _c;
        // Caches the geometry for the number strip.
        static CanvasGeometry s_numberStrip;
        // The number of meters added so far.
        int _meterCount;

        public ScalarPropertyMeter(Compositor compositor)
        {
            _c = compositor;
            Root = _c.CreateContainerVisual();
        }

        public ContainerVisual Root { get; }

        internal void Add(CompositionObject propertyOwner, string scalarPropertyAccessor, int numberOfDigits, int numberOfDecimalPlaces = 0)
        {
            var numberOfDigitsToLeftOfDecimalPlace = numberOfDigits - numberOfDecimalPlaces;

            if (numberOfDigits < 1 || numberOfDecimalPlaces < 0 || numberOfDigitsToLeftOfDecimalPlace < 0)
            {
                throw new ArgumentException();
            }

            var shapeVisual = _c.CreateShapeVisual();
            shapeVisual.Clip = _c.CreateInsetClip();
            shapeVisual.Size = new Vector2(digitWidth * numberOfDigits, digitHeight);
            shapeVisual.Offset = new Vector3(0, _meterCount * digitHeight * 1.1F, 0);
            Root.Children.InsertAtTop(shapeVisual);

            // Create a colored background
            var backgroundRectangle = _c.CreateRectangleGeometry();
            backgroundRectangle.Size = shapeVisual.Size;
            var backgroundShape = _c.CreateSpriteShape(backgroundRectangle);
            shapeVisual.Shapes.Add(backgroundShape);
            backgroundShape.FillBrush = _c.CreateColorBrush(Colors.Black);


            const string objectReference = "_";

            var rawValue = $"({objectReference}.{scalarPropertyAccessor})";
            var absoluteRawValue = $"Abs({objectReference}.{scalarPropertyAccessor})";

            // Animate the foreground color so it changes when the value is negative.
            var foregroundBrush = _c.CreateColorBrush();
            {
                // Red or white. Note that ColorRgb expressions seem to be broken, but
                // ColorHsl works. Animates between red and white.
                var expression = $"{rawValue}<0?ColorHsl(0,1,0.5):ColorHsl(0,0,1)";
                var brushColorAnimation = _c.CreateExpressionAnimation(expression);
                brushColorAnimation.SetReferenceParameter(objectReference, propertyOwner);
                foregroundBrush.StartAnimation(nameof(foregroundBrush.Color), brushColorAnimation);
            }

            // Create the minus sign.
            var minusGeometry = _c.CreateRectangleGeometry();
            minusGeometry.Size = new Vector2(2, 1);
            var minusShape = _c.CreateSpriteShape(minusGeometry);
            minusShape.FillBrush = foregroundBrush;
            shapeVisual.Shapes.Add(minusShape);

            // Animate the minus sign so that it only appears if the value is negative, and it moves to
            // account for the number of digits visible to the left of the decimal place.
            // When the value is positive the minus sign is hidden by offseting it outside
            // the clip of the containing ShapeVisual.
            {
                var expression = $"{rawValue}<0?Vector2({digitWidth}*({numberOfDigitsToLeftOfDecimalPlace - 1}-({absoluteRawValue}<1?0:(Floor(Log10({absoluteRawValue}))))),{DoubleToString((digitHeight - minusGeometry.Size.Y) / 2)}):Vector2(-100,-100)";
                var animation = _c.CreateExpressionAnimation(expression);
                animation.SetReferenceParameter(objectReference, propertyOwner);
                minusShape.StartAnimation(nameof(minusShape.Offset), animation);
            }

            // Create the decimal point
            var decimalPoint = _c.CreateSpriteShape();
            var dot = _c.CreateEllipseGeometry();
            dot.Radius = new Vector2(0.7F);
            decimalPoint.Geometry = dot;
            decimalPoint.FillBrush = foregroundBrush;
            decimalPoint.Offset = new Vector2(((numberOfDigits - numberOfDecimalPlaces + 0.09F) * digitWidth), digitHeight * 0.9F);
            shapeVisual.Shapes.Add(decimalPoint);

            // Create the digits
            var numberStrip = _c.CreatePathGeometry(new CompositionPath(CreateNumberStrip()));

            for (var i = 0; i < numberOfDigits; i++)
            {
                // The far right digit is treated specially - it rolls over continuously and has no
                // decimal point.
                var isFarRightDigit = i == numberOfDigits - 1;


                var digit = _c.CreateSpriteShape();
                shapeVisual.Shapes.Add(digit);
                digit.Geometry = numberStrip;
                digit.FillBrush = foregroundBrush;

                // Animate the scale so that the digit disappears if it is a leading 0.
                if (i < numberOfDigitsToLeftOfDecimalPlace - 1)
                {
                    // The digit is a leading (and therefore unnecessary) 0 if the absolute raw value
                    // is less than this:
                    var minValueForDigit = Math.Pow(10, numberOfDigitsToLeftOfDecimalPlace - i - 1);
                    var expression = $"{absoluteRawValue}<{minValueForDigit}?Vector2(0,0):Vector2(1,1)";
                    var animation = _c.CreateExpressionAnimation(expression);
                    animation.SetReferenceParameter(objectReference, propertyOwner);
                    digit.StartAnimation(nameof(digit.Scale), animation);
                }

                // Expression to get the value for the digit. The evaluated value is [0..10). The further to the
                // right the digit is, the more the value is scaled up.
                var scaledValue = $"{absoluteRawValue}*{Pow10(i - numberOfDigitsToLeftOfDecimalPlace + 1)}";

                var moddedValue = $"Mod({scaledValue},10)";

                string digitValue;

                if (isFarRightDigit)
                {
                    digitValue = moddedValue;
                }
                else
                {
                    // Counts from numberOfDigits-1 down to 0
                    var compI = numberOfDigits - i - 1;

                    // When this digit overflows from 9 to 0, during the last 1/10th of the far right digit 
                    // (when the far right digit is rolling over 9 back to 0), allow this digit to roll as 
                    // if it is being pushed by the far right value.

                    // Evaluates to true if the digit is in its transition zone.
                    var transitionTest = $"Floor({moddedValue}+{Pow10(-compI)})!=Floor({moddedValue})";

                    // Prevent the digit from rolling when not in its transition zone. Make it snap to whole values.
                    var normalValue = $"Floor({moddedValue})";

                    // During transition, ramp up to the next value.
                    var transitionValue = $"{normalValue}+Mod({scaledValue}*{Pow10(compI)}, 1)";

                    digitValue = $"({transitionTest}?{transitionValue}:{normalValue})";
                }

                // Offset x to place the digit in the correct position, offset y to display the correct value in the number strip.
                var offsetExpression = $"Vector2({i * digitWidth},({digitValue}*-{digitHeight}) - 1.5)";

                var digitOffsetAnimation = _c.CreateExpressionAnimation(offsetExpression);
                digitOffsetAnimation.SetReferenceParameter(objectReference, propertyOwner);

                // Animate the offset of the number string for this digit.
                digit.StartAnimation(nameof(digit.Offset), digitOffsetAnimation);
            }

            // Create a message to indicate overflow. This will sit on top
            // of the digits if there is an overflow detected.
            var overflowContainer = _c.CreateContainerShape();
            shapeVisual.Shapes.Add(overflowContainer);

            var overflowBackgroundShape = _c.CreateSpriteShape(backgroundRectangle);
            overflowBackgroundShape.FillBrush = _c.CreateColorBrush(Colors.Black);
            overflowContainer.Shapes.Add(overflowBackgroundShape);

            var overflowGeometry = numberStrip;
            var overflowShape = _c.CreateSpriteShape(overflowGeometry);
            overflowContainer.Shapes.Add(overflowShape);

            overflowShape.FillBrush = foregroundBrush;
            // 11 is the offset for the "E" character in the number strip.
            overflowShape.Offset = new Vector2(0, (11 * -digitHeight) - 1.5F);

            // Hide the overflow indicator as long as the value is within range.
            {
                var expression = $"{absoluteRawValue}<{Pow10(numberOfDigitsToLeftOfDecimalPlace)}?Vector2(0,0):Vector2(1,1)";
                var animation = _c.CreateExpressionAnimation(expression);
                animation.SetReferenceParameter(objectReference, propertyOwner);
                overflowContainer.StartAnimation(nameof(overflowContainer.Scale), animation);
            }

            // Increment the meter count so the next meter will be offset below this one.
            _meterCount++;
        }

        static CanvasGeometry CreateNumberStrip()
        {
            if (s_numberStrip == null)
            {
                s_numberStrip = CreateText("9\n0\n1\n2\n3\n4\n5\n6\n7\n8\n9\n0\nE");
            }
            return s_numberStrip;
        }

        static CanvasGeometry CreateText(string text)
        {
            // Size seems to be ignored
            const float size = 10;

            var textLayout = new CanvasTextLayout(
                resourceCreator: CanvasDevice.GetSharedDevice(),
                textString: text,
                textFormat: s_textFormat,
                requestedWidth: size,
                requestedHeight: size);
            return CanvasGeometry.CreateText(textLayout);
        }

        // Returns the value of 10 raised to the given value, as a string that can be used in a Composition animation expression.
        static string Pow10(double value) => DoubleToString(Math.Pow(10, value));


        // Converts a floating point value to a string suitable for a Composition animation expression.
        static string DoubleToString(double value)
        {
            var fValue = (float)value;
            return Math.Floor(fValue) == fValue
                ? fValue.ToString("0")
                : fValue.ToString("0.0####################");
        }
    }
}
