#pragma once

#include "CompositionPlayer.g.h"

namespace winrt::CompPlayer::implementation
{
    struct CompositionPlayer : CompositionPlayerT<CompositionPlayer>
    {
        CompositionPlayer();

        Windows::Foundation::IInspectable Diagnostics();
        Windows::Foundation::TimeSpan Duration();
        CompPlayer::ICompositionSource Source();
        void Source(CompPlayer::ICompositionSource const& value);
        double FromProgress();
        void FromProgress(double value);
        double ToProgress();
        void ToProgress(double value);
        bool AutoPlay();
        void AutoPlay(bool value);
        bool IsCompositionLoaded();
        bool IsLoopingEnabled();
        void IsLoopingEnabled(bool value);
        bool IsPlaying();
        bool ReverseAnimation();
        double PlaybackRate();
        void PlaybackRate(double value);
        Windows::UI::Composition::CompositionObject ProgressObject();
        Windows::UI::Color BackgroundColor();
        void BackgroundColor(Windows::UI::Color const& value);
        Windows::UI::Xaml::Media::Stretch Stretch();
        void Stretch(Windows::UI::Xaml::Media::Stretch const& value);
        void Pause();
        void Play();
        Windows::Foundation::IAsyncAction PlayAsync();
        Windows::Foundation::IAsyncAction PlayAsync(CompPlayer::CompositionSegment const& segment);
        void Resume();
        void SetProgress(double progress);
        void Stop();

        // FrameworkElement overrides
        Windows::Foundation::Size MeasureOverride(Windows::Foundation::Size availableSize);
        Windows::Foundation::Size ArrangeOverride(Windows::Foundation::Size finalSize);

        static void ClearProperties();
        static void EnsureProperties();

        // Dependency properties
        static Windows::UI::Xaml::DependencyProperty AutoPlayProperty() { return s_AutoPlayProperty; }
        static Windows::UI::Xaml::DependencyProperty BackgroundColorProperty() { return s_BackgroundColorProperty; }
        static Windows::UI::Xaml::DependencyProperty DiagnosticsProperty() { return s_DiagnosticsProperty; }
        static Windows::UI::Xaml::DependencyProperty DurationProperty() { return s_DurationProperty; }
        static Windows::UI::Xaml::DependencyProperty FromProgressProperty() { return s_FromProgressProperty; }
        static Windows::UI::Xaml::DependencyProperty IsCompositionLoadedProperty() { return s_IsCompositionLoadedProperty; }
        static Windows::UI::Xaml::DependencyProperty IsLoopingEnabledProperty() { return s_IsLoopingEnabledProperty; }
        static Windows::UI::Xaml::DependencyProperty IsPlayingProperty() { return s_IsPlayingProperty; }
        static Windows::UI::Xaml::DependencyProperty PlaybackRateProperty() { return s_PlaybackRateProperty; }
        static Windows::UI::Xaml::DependencyProperty ReverseAnimationProperty() { return s_ReverseAnimationProperty; }
        static Windows::UI::Xaml::DependencyProperty SourceProperty() { return s_SourceProperty; }
        static Windows::UI::Xaml::DependencyProperty StretchProperty() { return s_StretchProperty; }
        static Windows::UI::Xaml::DependencyProperty ToProgressProperty() { return s_ToProgressProperty; }

    private:
        static void OnPropertyChanged(const Windows::UI::Xaml::DependencyObject& sender, const Windows::UI::Xaml::DependencyPropertyChangedEventArgs& args);
        void OnPropertyChanged(const Windows::UI::Xaml::DependencyPropertyChangedEventArgs& args);

       //void OnSourcePropertyChanged(const winrt::DependencyPropertyChangedEventArgs& args);

        static Windows::UI::Xaml::DependencyProperty s_AutoPlayProperty;
        static Windows::UI::Xaml::DependencyProperty s_BackgroundColorProperty;
        static Windows::UI::Xaml::DependencyProperty s_DiagnosticsProperty;
        static Windows::UI::Xaml::DependencyProperty s_DurationProperty;
        static Windows::UI::Xaml::DependencyProperty s_FromProgressProperty;
        static Windows::UI::Xaml::DependencyProperty s_IsCompositionLoadedProperty;
        static Windows::UI::Xaml::DependencyProperty s_IsLoopingEnabledProperty;
        static Windows::UI::Xaml::DependencyProperty s_IsPlayingProperty;
        static Windows::UI::Xaml::DependencyProperty s_PlaybackRateProperty;
        static Windows::UI::Xaml::DependencyProperty s_ReverseAnimationProperty;
        static Windows::UI::Xaml::DependencyProperty s_SourceProperty;
        static Windows::UI::Xaml::DependencyProperty s_StretchProperty;
        static Windows::UI::Xaml::DependencyProperty s_ToProgressProperty;

        // The size of the current composition. Only valid if _compositionRoot is not nullptr.
        Windows::Foundation::Numerics::float2 _compositionSize;
        Windows::UI::Composition::Visual _compositionRoot = nullptr;

    };

}

namespace winrt::CompPlayer::factory_implementation
{
    struct CompositionPlayer : CompositionPlayerT<CompositionPlayer, implementation::CompositionPlayer>
    {
    };
}
