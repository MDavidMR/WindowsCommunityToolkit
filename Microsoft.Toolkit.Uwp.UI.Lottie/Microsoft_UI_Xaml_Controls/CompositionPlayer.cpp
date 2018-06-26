#include "pch.h"
#include "CompositionPlayer.h"
#include "Hacks.h"

namespace winrt::Microsoft_UI_Xaml_Controls::implementation
{
    winrt::DependencyProperty CompositionPlayer::s_AutoPlayProperty = nullptr;
    winrt::DependencyProperty CompositionPlayer::s_BackgroundColorProperty = nullptr;
    winrt::DependencyProperty CompositionPlayer::s_DiagnosticsProperty = nullptr;
    winrt::DependencyProperty CompositionPlayer::s_DurationProperty = nullptr;
    winrt::DependencyProperty CompositionPlayer::s_FromProgressProperty = nullptr;
    winrt::DependencyProperty CompositionPlayer::s_IsCompositionLoadedProperty = nullptr;
    winrt::DependencyProperty CompositionPlayer::s_IsLoopingEnabledProperty = nullptr;
    winrt::DependencyProperty CompositionPlayer::s_IsPlayingProperty = nullptr;
    winrt::DependencyProperty CompositionPlayer::s_PlaybackRateProperty = nullptr;
    winrt::DependencyProperty CompositionPlayer::s_ReverseAnimationProperty = nullptr;
    winrt::DependencyProperty CompositionPlayer::s_SourceProperty = nullptr;
    winrt::DependencyProperty CompositionPlayer::s_StretchProperty = nullptr;
    winrt::DependencyProperty CompositionPlayer::s_ToProgressProperty = nullptr;

    CompositionPlayer::CompositionPlayer()
    {
        EnsureProperties();

        auto compositor = Window::Current().Compositor();
        _rootVisual = compositor.CreateSpriteVisual();
        _progressPropertySet = _rootVisual.Properties();

        ElementCompositionPreview::SetElementChildVisual(*this, _rootVisual);

        // Set an initial value for the Progress property.
        _progressPropertySet.InsertScalar(L"Progress", 0);

        // Ensure the content can't render outside the bounds of the element.
        _rootVisual.Clip(compositor.CreateInsetClip());

        _backgroundBrush = compositor.CreateColorBrush(BackgroundColor());
    }

    // Overrides FrameworkElement::MeasureOverride. Returns the size that is needed to display the
    // composition within the available size and respecting the Stretch property.
    winrt::Size CompositionPlayer::MeasureOverride(winrt::Size availableSize)
    {
        if ((_compositionRoot == nullptr) || (_compositionSize == float2::zero()))
        {
            return { 0, 0 };
        }

        switch (Stretch())
        {
        case Stretch::None:
            // No scaling will be done.
            return min(_compositionSize, availableSize);
        case Stretch::Fill:
            // Both height and width will be scaled to fill the available space.
            if (availableSize.Width != INFINITY && availableSize.Height != INFINITY)
            {
                // We will scale both dimensions to fill all available space.
                return availableSize;
            }
            // One of the dimensions is infinite and we can't fill infinite dimensions, so
            // fall back to Uniform so at least the non-infinite dimension will be filled.
            break;
        case Stretch::UniformToFill:
            // Height and width will be scaled by the same amount such that there is no space
            // around the edges.
            if (availableSize.Width != INFINITY && availableSize.Height != INFINITY)
            {
                // Scale so there is no space around the edge.
                auto widthScale = availableSize.Width / _compositionSize.x;
                auto heightScale = availableSize.Height / _compositionSize.y;
                return (heightScale < widthScale)
                    ? Size{ availableSize.Width, _compositionSize.y * widthScale }
                : Size{ _compositionSize.x * heightScale, availableSize.Height };
            }
            // One of the dimensions is infinite and we can't fill infinite dimensions, so
            // fall back to Uniform so at least the non-infinite dimension will be filled.
            break;
        } // end switch

          // Uniform scaling.
          // Scale so that one dimension fits exactly and no dimension exceeds the boundary.
        auto widthScale = ((availableSize.Width == INFINITY) ? FLT_MAX : availableSize.Width) / _compositionSize.x;
        auto heightScale = ((availableSize.Height == INFINITY) ? FLT_MAX : availableSize.Height) / _compositionSize.y;
        return (heightScale > widthScale)
            ? Size{ availableSize.Width, _compositionSize.y * widthScale }
        : Size{ _compositionSize.x * heightScale, availableSize.Height };
    }

    // Overrides FrameworkElement::ArrangeOverride. Scales to fit the composition into finalSize 
    // respecting the current Stretch and returns the size actually used.
    winrt::Size CompositionPlayer::ArrangeOverride(winrt::Size finalSize)
    {
        float2 scale;
        float2 arrangedSize;

        if (_compositionRoot == nullptr)
        {
            // No content. 0 size.
            scale = { 1, 1 };
            arrangedSize = { 0,0 };
        }
        else
        {
            auto stretch = Stretch();
            if (stretch == Stretch::None)
            {
                // Do not scale, do not center.
                scale = { 1, 1 };
                arrangedSize = {
                    std::min(finalSize.Width, _compositionSize.x),
                    std::min(finalSize.Height, _compositionSize.y)
                };
            }
            else
            {
                scale = finalSize / _compositionSize;

                switch (stretch)
                {
                case Stretch::Uniform:
                    // Scale both dimensions by the same amount.
                    if (scale.x < scale.y)
                    {
                        scale.y = scale.x;
                    }
                    else
                    {
                        scale.x = scale.y;
                    }
                    break;
                case Stretch::UniformToFill:
                    // Scale both dimensions by the same amount and leave no gaps around the edges.
                    if (scale.x > scale.y)
                    {
                        scale.y = scale.x;
                    }
                    else
                    {
                        scale.x = scale.y;
                    }
                    break;
                }

                // A size needs to be set because there's an InsetClip applied, and without a 
                // size the clip will prevent anything from being visible.
                arrangedSize = {
                    std::min(finalSize.Width / scale.x, _compositionSize.x),
                    std::min(finalSize.Height / scale.y, _compositionSize.y)
                };

                // Center the animation within the available space.
                auto offset = (finalSize - (_compositionSize * scale)) / 2;
                _rootVisual.Offset({ offset, 0 /* z */ });

                // Adjust the position of the clip.
                _rootVisual.Clip().Offset(
                    (stretch == Stretch::UniformToFill)
                    ? -(offset / scale)
                    : float2::zero()
                );
            }
        }

        _rootVisual.Size(arrangedSize);
        _rootVisual.Scale({ scale, 1 /* z */ });

        return finalSize;
    }

    // Dependency properties
    void CompositionPlayer::ClearProperties()
    {
        s_BackgroundColorProperty = nullptr;
        s_DiagnosticsProperty = nullptr;
        s_DurationProperty = nullptr;
        s_FromProgressProperty = nullptr;
        s_IsCompositionLoadedProperty = nullptr;
        s_IsLoopingEnabledProperty = nullptr;
        s_IsPlayingProperty = nullptr;
        s_PlaybackRateProperty = nullptr;
        s_ReverseAnimationProperty = nullptr;
        s_SourceProperty = nullptr;
        s_StretchProperty = nullptr;
        s_ToProgressProperty = nullptr;
    }


    void CompositionPlayer::EnsureProperties()
    {
        if (s_AutoPlayProperty)
        {
            // If one of the DependencyProperty's is initialized, they all are.
            return;
        }

        s_AutoPlayProperty =
            InitializeDependencyProperty(
                L"AutoPlay",
                winrt::name_of<bool>(),
                winrt::name_of<CompositionPlayer>(),
                false,
                box_value(true),
                nullptr);

        s_BackgroundColorProperty =
            InitializeDependencyProperty(
                L"BackgroundColor",
                winrt::name_of<Windows::UI::Color>(),
                winrt::name_of<CompositionPlayer>(),
                false,
                box_value(Windows::UI::Colors::Transparent()),
                winrt::PropertyChangedCallback(&CompositionPlayer::OnBackgroundColorPropertyChanged));

        s_DiagnosticsProperty =
            InitializeDependencyProperty(
                L"Diagnostics",
                winrt::name_of<IInspectable>(),
                winrt::name_of<CompositionPlayer>(),
                false,
                nullptr,
                nullptr);

        s_DurationProperty =
            InitializeDependencyProperty(
                L"Duration",
                winrt::name_of<TimeSpan>(),
                winrt::name_of<CompositionPlayer>(),
                false,
                box_value(winrt::TimeSpan{ 0 }),
                nullptr);

        s_FromProgressProperty =
            InitializeDependencyProperty(
                L"FromProgress",
                winrt::name_of<double>(),
                winrt::name_of<CompositionPlayer>(),
                false,
                box_value(0.0),
                nullptr);

        s_IsCompositionLoadedProperty =
            InitializeDependencyProperty(
                L"IsCompositionloaded",
                winrt::name_of<bool>(),
                winrt::name_of<CompositionPlayer>(),
                false,
                box_value(false),
                nullptr);

        s_IsLoopingEnabledProperty =
            InitializeDependencyProperty(
                L"IsLoopingEnabled",
                winrt::name_of<bool>(),
                winrt::name_of<CompositionPlayer>(),
                false,
                box_value(false),
                nullptr);

        s_IsPlayingProperty =
            InitializeDependencyProperty(
                L"IsPlaying",
                winrt::name_of<bool>(),
                winrt::name_of<CompositionPlayer>(),
                false,
                box_value(false),
                nullptr);

        s_PlaybackRateProperty =
            InitializeDependencyProperty(
                L"PlaybackRate",
                winrt::name_of<double>(),
                winrt::name_of<CompositionPlayer>(),
                false,
                box_value(1.0),
                nullptr);

        s_ReverseAnimationProperty =
            InitializeDependencyProperty(
                L"ReverseAnimation",
                winrt::name_of<bool>(),
                winrt::name_of<CompositionPlayer>(),
                false,
                box_value(false),
                nullptr);

        s_SourceProperty =
            InitializeDependencyProperty(
                L"Source",
                winrt::name_of<ICompositionSource>(),
                winrt::name_of<CompositionPlayer>(),
                false,      // isAttached
                nullptr,    // initial value
                winrt::PropertyChangedCallback(&CompositionPlayer::OnSourcePropertyChanged));

        s_StretchProperty =
            InitializeDependencyProperty(
                L"Stretch",
                winrt::name_of<winrt::Stretch>(),
                winrt::name_of<CompositionPlayer>(),
                false,
                box_value(winrt::Stretch::Uniform),
                winrt::PropertyChangedCallback(&CompositionPlayer::OnStretchPropertyChanged));

        s_ToProgressProperty =
            InitializeDependencyProperty(
                L"ToProgress",
                winrt::name_of<double>(),
                winrt::name_of<CompositionPlayer>(),
                false,
                box_value(1.0),
                nullptr);
    }

    winrt::IInspectable CompositionPlayer::Diagnostics()
    {
        return safe_cast<winrt::IInspectable>(GetValue(s_DiagnosticsProperty));
    }

    winrt::TimeSpan CompositionPlayer::Duration()
    {
        return unbox_value<winrt::TimeSpan>(GetValue(s_DurationProperty));
    }

    Microsoft_UI_Xaml_Controls::ICompositionSource CompositionPlayer::Source()
    {
        return safe_cast<Microsoft_UI_Xaml_Controls::ICompositionSource>(GetValue(s_SourceProperty));
    }

    void CompositionPlayer::Source(Microsoft_UI_Xaml_Controls::ICompositionSource const& value)
    {
        SetValue(s_SourceProperty, value);
    }

    double CompositionPlayer::FromProgress()
    {
        return unbox_value<double>(GetValue(s_FromProgressProperty));
    }

    void CompositionPlayer::FromProgress(double value)
    {
        SetValue(s_FromProgressProperty, box_value(value));
    }

    double CompositionPlayer::ToProgress()
    {
        return unbox_value<double>(GetValue(s_ToProgressProperty));
    }

    void CompositionPlayer::ToProgress(double value)
    {
        SetValue(s_ToProgressProperty, box_value(value));
    }

    bool CompositionPlayer::AutoPlay()
    {
        return unbox_value<bool>(GetValue(s_AutoPlayProperty));
    }

    void CompositionPlayer::AutoPlay(bool value)
    {
        SetValue(s_AutoPlayProperty, box_value(value));
    }

    bool CompositionPlayer::IsCompositionLoaded()
    {
        return unbox_value<bool>(GetValue(s_IsCompositionLoadedProperty));
    }

    bool CompositionPlayer::IsLoopingEnabled()
    {
        return unbox_value<bool>(GetValue(s_IsLoopingEnabledProperty));
    }

    void CompositionPlayer::IsLoopingEnabled(bool value)
    {
        SetValue(s_IsLoopingEnabledProperty, box_value(value));
    }

    bool CompositionPlayer::IsPlaying()
    {
        return unbox_value<bool>(GetValue(s_IsPlayingProperty));
    }

    bool CompositionPlayer::ReverseAnimation()
    {
        return unbox_value<bool>(GetValue(s_ReverseAnimationProperty));
    }

    double CompositionPlayer::PlaybackRate()
    {
        return unbox_value<double>(GetValue(s_PlaybackRateProperty));
    }

    void CompositionPlayer::PlaybackRate(double value)
    {
        SetValue(s_PlaybackRateProperty, box_value(value));
    }

    Windows::UI::Composition::CompositionObject CompositionPlayer::ProgressObject()
    {
        return _progressPropertySet;
    }

    Windows::UI::Color CompositionPlayer::BackgroundColor()
    {
        return unbox_value<Windows::UI::Color>(GetValue(s_BackgroundColorProperty));
    }

    void CompositionPlayer::BackgroundColor(Windows::UI::Color const& value)
    {
        SetValue(s_BackgroundColorProperty, box_value(value));
    }

    winrt::Stretch CompositionPlayer::Stretch()
    {
        return unbox_value<winrt::Stretch>(GetValue(s_StretchProperty));
    }

    void CompositionPlayer::Stretch(winrt::Stretch const& value)
    {
        SetValue(s_StretchProperty, box_value(value));
    }

    void CompositionPlayer::Pause()
    {
        throw hresult_not_implemented();
    }

    void CompositionPlayer::Play()
    {
        throw hresult_not_implemented();
    }

    winrt::IAsyncAction CompositionPlayer::PlayAsync()
    {
        throw hresult_not_implemented();
    }

    winrt::IAsyncAction CompositionPlayer::PlayAsync(Microsoft_UI_Xaml_Controls::CompositionSegment const segment)
    {
        throw hresult_not_implemented();
    }

    void CompositionPlayer::Resume()
    {
        throw hresult_not_implemented();
    }

    void CompositionPlayer::SetProgress(double progress)
    {
        throw hresult_not_implemented();
    }

    void CompositionPlayer::Stop()
    {
        throw hresult_not_implemented();
    }

    void CompositionPlayer::OnPropertyChanged(const winrt::DependencyPropertyChangedEventArgs& args)
    {
        winrt::IDependencyProperty property = args.Property();
        if (property == s_AutoPlayProperty)
        {

        }
        else if (property == s_FromProgressProperty)
        {

        }
        else if (property == s_IsLoopingEnabledProperty)
        {

        }
        else if (property == s_IsPlayingProperty)
        {

        }
        else if (property == s_PlaybackRateProperty)
        {

        }
        else if (property == s_ReverseAnimationProperty)
        {

        }
        else if (property == s_ToProgressProperty)
        {

        }
        else
        {
            assert(false);
        }
    }

    void CompositionPlayer::OnPropertyChanged(
        const winrt::DependencyObject& sender,
        const winrt::DependencyPropertyChangedEventArgs& args)
    {
        AsSelf(sender)->OnPropertyChanged(args);
    }


    void CompositionPlayer::OnSourcePropertyChanged(
        const winrt::DependencyObject& sender,
        const winrt::DependencyPropertyChangedEventArgs& args)
    {
        AsSelf(sender)->UpdateContent(args.NewValue().as<ICompositionSource>());
    }

    void CompositionPlayer::UpdateContent(ICompositionSource const& newSource)
    {
        // Unload the current composition (if any).
        UnloadComposition();

        if (newSource == nullptr)
        {
            return;
        }

        CompositionPropertySet progressPropertySet = nullptr;
        TimeSpan duration{};
        IInspectable diagnostics{};

        auto success = newSource.TryCreateInstance(
            Window::Current().Compositor(),
            _compositionRoot,
            _compositionSize,
            progressPropertySet,
            duration,
            diagnostics);

        // Update the Diagnostics property.
        SetValue(s_DiagnosticsProperty, diagnostics);

        if (!success)
        {
            return;
        }

        // Update the Duration property.
        SetValue(s_DurationProperty, box_value(duration));

        SetValue(s_IsCompositionLoadedProperty, box_value(true));

        // Size has probably changed. Tell XAML to re-measure.
        InvalidateMeasure();

        auto rootChildren = _rootVisual.Children();
        rootChildren.InsertAtTop(_compositionRoot);

        // Tie the composition's Progress property to the player Progress.
        auto compositor = _rootVisual.Compositor();
        auto progressAnimation = compositor.CreateExpressionAnimation(L"my.Progress");
        progressAnimation.SetReferenceParameter(L"my", _progressPropertySet);
        progressPropertySet.StartAnimation(L"Progress", progressAnimation);

        // TODO - HACK - start playing immediately so we can see something.
        auto animation = compositor.CreateScalarKeyFrameAnimation();
        animation.Duration(duration);
        auto easing = compositor.CreateLinearEasingFunction();
        animation.InsertKeyFrame(1, 1, easing);
        animation.IterationBehavior(AnimationIterationBehavior::Forever);
        _progressPropertySet.StartAnimation(L"Progress", animation);
    }

    void CompositionPlayer::UnloadComposition()
    {
        if (_compositionRoot != nullptr)
        {
            //            Stop();

            // Stop the animation by setting the Progress value to 0.
            _progressPropertySet.InsertScalar(L"Progress", 0);

            // Remove the old composition (if any).
            _rootVisual.Children().RemoveAll();

            _compositionRoot = nullptr;

            SetValue(s_DurationProperty, nullptr);
            SetValue(s_DiagnosticsProperty, nullptr);
            SetValue(s_IsCompositionLoadedProperty, box_value(false));

            // Size has changed. Tell XAML to re-measure.
            InvalidateMeasure();
        }
    }


    void CompositionPlayer::OnBackgroundColorPropertyChanged(
        const winrt::DependencyObject& sender,
        const winrt::DependencyPropertyChangedEventArgs& args)
    {
        AsSelf(sender)->OnBackgroundColorPropertyChanged(args);
    }

    void CompositionPlayer::OnBackgroundColorPropertyChanged(const winrt::DependencyPropertyChangedEventArgs& args)
    {
        auto newColor = unbox_value<Windows::UI::Color>(args.NewValue());
        _backgroundBrush.Color(newColor);
    }

    void CompositionPlayer::OnStretchPropertyChanged(
        const winrt::DependencyObject& sender,
        const winrt::DependencyPropertyChangedEventArgs&)
    {
        AsSelf(sender)->InvalidateMeasure();
    }

    CompositionPlayer* CompositionPlayer::AsSelf(const winrt::Windows::UI::Xaml::DependencyObject& sender)
    {
        return winrt::from_abi<CompositionPlayer>(sender.as<winrt::Microsoft_UI_Xaml_Controls::CompositionPlayer>());
    }


}
