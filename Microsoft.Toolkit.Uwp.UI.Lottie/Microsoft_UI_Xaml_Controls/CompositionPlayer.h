#pragma once

#include "CompositionPlayer.g.h"


namespace winrt::Microsoft_UI_Xaml_Controls::implementation
{
    struct CompositionPlayer final : CompositionPlayerT<CompositionPlayer>
    {
        CompositionPlayer();

        Windows::Foundation::IInspectable Diagnostics();
        Windows::Foundation::TimeSpan Duration();
        Microsoft_UI_Xaml_Controls::ICompositionSource Source();
        void Source(Microsoft_UI_Xaml_Controls::ICompositionSource const& value);
        bool AutoPlay();
        void AutoPlay(bool value);
        bool IsCompositionLoaded();
        bool IsLoopingEnabled();
        void IsLoopingEnabled(bool value);
        bool IsPlaying();
        double PlaybackRate();
        void PlaybackRate(double value);
        Windows::UI::Composition::CompositionObject ProgressObject();
        Windows::UI::Xaml::Media::Stretch Stretch();
        void Stretch(Windows::UI::Xaml::Media::Stretch const& value);
        void Pause();
        Windows::Foundation::IAsyncAction PlayAsync(double fromProgress, double toProgress, double playbackRate, bool looped);
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
        static Windows::UI::Xaml::DependencyProperty DiagnosticsProperty() { return s_DiagnosticsProperty; }
        static Windows::UI::Xaml::DependencyProperty DurationProperty() { return s_DurationProperty; }
        static Windows::UI::Xaml::DependencyProperty IsCompositionLoadedProperty() { return s_IsCompositionLoadedProperty; }
        static Windows::UI::Xaml::DependencyProperty IsLoopingEnabledProperty() { return s_IsLoopingEnabledProperty; }
        static Windows::UI::Xaml::DependencyProperty IsPlayingProperty() { return s_IsPlayingProperty; }
        static Windows::UI::Xaml::DependencyProperty PlaybackRateProperty() { return s_PlaybackRateProperty; }
        static Windows::UI::Xaml::DependencyProperty SourceProperty() { return s_SourceProperty; }
        static Windows::UI::Xaml::DependencyProperty StretchProperty() { return s_StretchProperty; }

    private:
        //
        // An awaitable object that is completed when an animation play is completed.
        //
        struct AnimationPlay final
        {
            AnimationPlay(
                CompositionPlayer& owner,
                Windows::UI::Composition::AnimationController const& controller);

            // Sets the playback rate of the animation.
            void SetPlaybackRate(float value);

            // Called to indicate that the play has been completed. Unblocks awaiters.
            void Complete();

            // Awaitable contract.
            bool await_ready() const noexcept;
            void await_suspend(std::experimental::coroutine_handle<> resume);
            void await_resume() const noexcept;

        private:
            //
            // Describes a PTP_WAIT.
            //
            struct PTP_WAIT_traits
            {
                using type = PTP_WAIT;

                static void close(type value) noexcept
                {
                    ::CloseThreadpoolWait(value);
                }

                static constexpr type invalid() noexcept
                {
                    return nullptr;
                }
            };

            CompositionPlayer& _owner;
            Windows::UI::Composition::AnimationController _controller;
            winrt::handle _signal;
            winrt::handle_type<PTP_WAIT_traits> _wait;
        };

        static void OnPlaybackRatePropertyChanged(const Windows::UI::Xaml::DependencyObject& sender, const Windows::UI::Xaml::DependencyPropertyChangedEventArgs& args);
        void OnPlaybackRatePropertyChanged(const Windows::UI::Xaml::DependencyPropertyChangedEventArgs& args);

        static void OnSourcePropertyChanged(const Windows::UI::Xaml::DependencyObject& sender, const Windows::UI::Xaml::DependencyPropertyChangedEventArgs& args);
        void OnSourcePropertyChanged(ICompositionSource const& oldSource, ICompositionSource const& newSource);

        static void OnStretchPropertyChanged(const Windows::UI::Xaml::DependencyObject& sender, const Windows::UI::Xaml::DependencyPropertyChangedEventArgs& args);

        static CompositionPlayer* AsSelf(const Windows::UI::Xaml::DependencyObject& sender);

        void UpdateContent();
        void UnloadComposition();

        static Windows::UI::Xaml::DependencyProperty s_AutoPlayProperty;
        static Windows::UI::Xaml::DependencyProperty s_DiagnosticsProperty;
        static Windows::UI::Xaml::DependencyProperty s_DurationProperty;
        static Windows::UI::Xaml::DependencyProperty s_FromProgressProperty;
        static Windows::UI::Xaml::DependencyProperty s_IsCompositionLoadedProperty;
        static Windows::UI::Xaml::DependencyProperty s_IsLoopingEnabledProperty;
        static Windows::UI::Xaml::DependencyProperty s_IsPlayingProperty;
        static Windows::UI::Xaml::DependencyProperty s_PlaybackRateProperty;
        static Windows::UI::Xaml::DependencyProperty s_SourceProperty;
        static Windows::UI::Xaml::DependencyProperty s_StretchProperty;
        static Windows::UI::Xaml::DependencyProperty s_ToProgressProperty;

        // The size of the current composition. Only valid if _compositionRoot is not nullptr.
        Windows::Foundation::Numerics::float2 _compositionSize;
        Windows::UI::Composition::Visual _compositionRoot = nullptr;
        // A Visual used for clipping and for parenting of _compositionRoot.
        Windows::UI::Composition::SpriteVisual _rootVisual = nullptr;
        // The property set that contains the Progress property that will be used to
        // set the progress of the composition.
        Windows::UI::Composition::CompositionPropertySet _progressPropertySet = nullptr;
        int _playAsyncVersion = 0;
        double _currentPlayFromProgress = 0;
        // The play that will be stopped when Stop() is called.
        std::shared_ptr<AnimationPlay> _nowPlaying = nullptr;
        winrt::event_token _dynamicCompositionInvalidatedToken;
    };

}

namespace winrt::Microsoft_UI_Xaml_Controls::factory_implementation
{
    struct CompositionPlayer : CompositionPlayerT<CompositionPlayer, implementation::CompositionPlayer>
    {
    };
}
