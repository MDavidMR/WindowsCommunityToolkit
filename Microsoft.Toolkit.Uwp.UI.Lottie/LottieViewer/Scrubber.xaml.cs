using Windows.Foundation;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Hosting;


namespace LottieViewer
{
    public sealed partial class Scrubber : UserControl
    {
        readonly SpriteVisual _progressRectangle;

        public event RangeBaseValueChangedEventHandler ValueChanged;

        public Scrubber()
        {
            this.InitializeComponent();
            _slider.ValueChanged += (sender, e) => ValueChanged?.Invoke(sender, e);

            var c = Window.Current.Compositor;
            var progressRectangle = c.CreateSpriteVisual();
            _progressRectangle = progressRectangle;

            // Move the rect into the horizontal track of the slider.
            progressRectangle.Offset = new System.Numerics.Vector3(1, 18, 0);

            var scrubberEnabledBrush = c.CreateColorBrush((Color)App.Current.Resources["LottieBasic"]);
            var scrubberDisabledBrush = c.CreateColorBrush((Color)App.Current.Resources["DisabledColor"]);
            progressRectangle.Brush = scrubberEnabledBrush;
            progressRectangle.Properties.InsertScalar("Width", 0);
            ElementCompositionPreview.SetElementChildVisual(_slider, progressRectangle);

            IsEnabledChanged += (sender, e) =>
            {
                if ((bool)e.NewValue)
                {
                    // Becoming enabled.
                    progressRectangle.Brush = scrubberEnabledBrush;
                }
                else
                {
                    // Becoming disabled.
                    progressRectangle.Brush = scrubberDisabledBrush;
                }
            };
        }


        internal void SetAnimatedCompositionObject(CompositionObject obj)
        {
            var c = Window.Current.Compositor;
            var rectAnim = c.CreateExpressionAnimation("Vector2(comp.Progress * our.Width, 2)");
            rectAnim.SetReferenceParameter("comp", obj);
            rectAnim.SetReferenceParameter("our", _progressRectangle.Properties);
            _progressRectangle.StartAnimation("Size", rectAnim);
        }

        public double Value
        {
            get => _slider.Value;
            set => _slider.Value = value;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            // Update the size of the progress rectangle.
            _progressRectangle.Properties.InsertScalar("Width", (float)finalSize.Width - 2);

            return base.ArrangeOverride(finalSize);
        }

    }
}
