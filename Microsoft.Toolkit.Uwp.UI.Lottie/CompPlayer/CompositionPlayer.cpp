#include "pch.h"
#include "CompositionPlayer.h"
#include "Hacks.h"

namespace winrt::CompPlayer::implementation
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
    }

    // Overrides FrameworkElement::MeasureOverride
    winrt::Size CompositionPlayer::MeasureOverride(winrt::Size availableSize)
    {
        winrt::Size measuredSize{ 0,0 };
        if (_compositionRoot != nullptr)
        {
            measuredSize = _compositionSize;
        }

        return measuredSize;
    }

    // Overrides FrameworkElement::ArrangeOverride
    winrt::Size CompositionPlayer::ArrangeOverride(winrt::Size finalSize)
    {
        winrt::Size result{ 0,0 };
        if (_compositionRoot != nullptr)
        {
            result = _compositionSize;
        }
        return result;
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
                nullptr);

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
                winrt::PropertyChangedCallback(&CompositionPlayer::OnPropertyChanged));

        s_StretchProperty =
            InitializeDependencyProperty(
                L"Stretch",
                winrt::name_of<winrt::Stretch>(),
                winrt::name_of<CompositionPlayer>(),
                false,
                box_value(winrt::Stretch::Uniform),
                nullptr);

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

    CompPlayer::ICompositionSource CompositionPlayer::Source()
    {
        return safe_cast<CompPlayer::ICompositionSource>(GetValue(s_SourceProperty));
    }

    void CompositionPlayer::Source(CompPlayer::ICompositionSource const& value)
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
        return nullptr;
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

    winrt::IAsyncAction CompositionPlayer::PlayAsync(CompPlayer::CompositionSegment const& segment)
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
        else if (property == s_BackgroundColorProperty)
        {

        }
        else if (property == s_DiagnosticsProperty)
        {

        }
        else if (property == s_DurationProperty)
        {

        }
        else if (property == s_FromProgressProperty)
        {

        }
        else if (property == s_IsCompositionLoadedProperty)
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
        else if (property == s_SourceProperty)
        {
            auto newValue = args.NewValue();
            auto foo = newValue.as<ICompositionSource>();
            CompositionPropertySet progressPropertySet = nullptr;
            TimeSpan duration{};
            IInspectable diagnostics{};
            auto success = foo.TryCreateInstance(
                Window::Current().Compositor(),
                _compositionRoot,
                _compositionSize,
                progressPropertySet,
                duration,
                diagnostics);
            // TODO - don't ignore the result.

            ElementCompositionPreview::SetElementChildVisual(*this, _compositionRoot);

            // Size has changed. Tell XAML to re-measure.
            InvalidateMeasure();
        }
        else if (property == s_StretchProperty)
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
        // TODO - from_abi is renamed to get_self in newer SDK
        winrt::from_abi<CompositionPlayer>(sender.as<winrt::CompPlayer::CompositionPlayer>())->OnPropertyChanged(args);
    }
}
