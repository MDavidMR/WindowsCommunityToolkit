#include "pch.h"
#include "CompositionPlayer.h"
#include "Hacks.h"
#include <winrt/Windows.UI.Core.h>
using namespace winrt::Windows::UI::Core;

namespace winrt::Microsoft_UI_Xaml_Controls::implementation
{
    winrt::DependencyProperty CompositionPlayer::s_AutoPlayProperty = nullptr;
    winrt::DependencyProperty CompositionPlayer::s_DiagnosticsProperty = nullptr;
    winrt::DependencyProperty CompositionPlayer::s_DurationProperty = nullptr;
    winrt::DependencyProperty CompositionPlayer::s_IsCompositionLoadedProperty = nullptr;
    winrt::DependencyProperty CompositionPlayer::s_IsLoopingEnabledProperty = nullptr;
    winrt::DependencyProperty CompositionPlayer::s_IsPlayingProperty = nullptr;
    winrt::DependencyProperty CompositionPlayer::s_PlaybackRateProperty = nullptr;
    winrt::DependencyProperty CompositionPlayer::s_SourceProperty = nullptr;
    winrt::DependencyProperty CompositionPlayer::s_StretchProperty = nullptr;


    static winrt::DependencyProperty InitializeDependencyProperty(
        std::wstring_view const& propertyNameString,
        std::wstring_view const& propertyTypeNameString,
        winrt::IInspectable defaultValue,
        winrt::PropertyChangedCallback propertyChangedCallback = nullptr)
    {
        auto propertyType = winrt::Interop::TypeName();
        propertyType.Name = propertyTypeNameString;
        propertyType.Kind = winrt::Interop::TypeKind::Metadata;

        auto ownerType = winrt::Interop::TypeName();
        ownerType.Name = winrt::name_of<winrt::Microsoft_UI_Xaml_Controls::CompositionPlayer>();
        ownerType.Kind = winrt::Interop::TypeKind::Metadata;

        auto propertyMetadata = winrt::PropertyMetadata(defaultValue, propertyChangedCallback);

        return winrt::DependencyProperty::Register(propertyNameString, propertyType, ownerType, propertyMetadata);
    }

    static void __stdcall CoroutineCompletedCallback(PTP_CALLBACK_INSTANCE, void* context, PTP_WAIT, TP_WAIT_RESULT) noexcept
    {
        // Resumes anyone waiting on the awaitable.
        std::experimental::coroutine_handle<>::from_address(context)();
    }

    CompositionPlayer::AnimationPlay::AnimationPlay(
        CompositionPlayer& owner,
        AnimationController const& controller)
        : _owner{ owner }
        , _controller{ controller }
    {
        _signal.attach(::CreateEvent(nullptr, true, false, nullptr));
    }

    void CompositionPlayer::AnimationPlay::SetPlaybackRate(float value)
    {
        _controller.PlaybackRate(value);
    }

    void CompositionPlayer::AnimationPlay::Complete()
    {
        // Allow the play to complete.
        ::SetEvent(_signal.get());

        // If this play is the one that is currently associated with the player,
        // diassociate it from the player and update the player's IsPlaying property.
        if ( &*(_owner._nowPlaying) == this)
        {
            _owner._nowPlaying.reset();
            _owner.SetValue(CompositionPlayer::s_IsPlayingProperty, box_value(false));
        }
    }

    // Blocks until the awaitable is completed.
    bool CompositionPlayer::AnimationPlay::await_ready() const noexcept
    {
        return ::WaitForSingleObject(_signal.get(), 0) == 0;
    }

    void CompositionPlayer::AnimationPlay::await_suspend(std::experimental::coroutine_handle<> resume)
    {
        _wait.attach(
            winrt::check_pointer(
                ::CreateThreadpoolWait(CoroutineCompletedCallback, resume.address(), nullptr)
            )
        );
        ::SetThreadpoolWait(_wait.get(), _signal.get(), nullptr);
    }

    // Called to get the value of the awaitable. This awaitable has no value, 
    // so nothing to do.
    void CompositionPlayer::AnimationPlay::await_resume() const noexcept { }


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
                auto measuredSize = (heightScale < widthScale)
                    ? Size{ availableSize.Width, _compositionSize.y * widthScale }
                    : Size{ _compositionSize.x * heightScale, availableSize.Height };

                // Clip the size to the available size.
                measuredSize = Size{ 
                                std::min(measuredSize.Width, availableSize.Width), 
                                std::min(measuredSize.Height, availableSize.Height) 
                };

                return measuredSize;
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
        s_DiagnosticsProperty = nullptr;
        s_DurationProperty = nullptr;
        s_IsCompositionLoadedProperty = nullptr;
        s_IsLoopingEnabledProperty = nullptr;
        s_IsPlayingProperty = nullptr;
        s_PlaybackRateProperty = nullptr;
        s_SourceProperty = nullptr;
        s_StretchProperty = nullptr;
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
                box_value(true));

        s_DiagnosticsProperty =
            InitializeDependencyProperty(
                L"Diagnostics",
                winrt::name_of<IInspectable>(),
                nullptr,
                nullptr);

        s_DurationProperty =
            InitializeDependencyProperty(
                L"Duration",
                winrt::name_of<TimeSpan>(),
                box_value(winrt::TimeSpan{ 0 }));

        s_IsCompositionLoadedProperty =
            InitializeDependencyProperty(
                L"IsCompositionloaded",
                winrt::name_of<bool>(),
                box_value(false));

        s_IsLoopingEnabledProperty =
            InitializeDependencyProperty(
                L"IsLoopingEnabled",
                winrt::name_of<bool>(),
                box_value(true));

        s_IsPlayingProperty =
            InitializeDependencyProperty(
                L"IsPlaying",
                winrt::name_of<bool>(),
                box_value(false));

        s_PlaybackRateProperty =
            InitializeDependencyProperty(
                L"PlaybackRate",
                winrt::name_of<double>(),
                box_value(1.0),
                winrt::PropertyChangedCallback(&CompositionPlayer::OnPlaybackRatePropertyChanged));

        s_SourceProperty =
            InitializeDependencyProperty(
                L"Source",
                winrt::name_of<ICompositionSource>(),
                nullptr,    // initial value
                winrt::PropertyChangedCallback(&CompositionPlayer::OnSourcePropertyChanged));

        s_StretchProperty =
            InitializeDependencyProperty(
                L"Stretch",
                winrt::name_of<winrt::Stretch>(),
                box_value(winrt::Stretch::Uniform),
                winrt::PropertyChangedCallback(&CompositionPlayer::OnStretchPropertyChanged));
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

    winrt::IAsyncAction CompositionPlayer::PlayAsync(double fromProgress, double toProgress, double playbackRate, bool looped)
    {
        // Used to detect reentrance.
        auto version = ++_playAsyncVersion;

        // Cause any other tasks waiting in this method to return. This call may
        // cause reentrance.
        Stop();

        if (version != _playAsyncVersion)
        {
            // The call was overtaken by another call due to reentrance.
            co_return;
        }

        // Sanitize the progress values.
        auto from = std::clamp(static_cast<float>(fromProgress), 0.0F, 1.0F);
        auto to = std::clamp(static_cast<float>(toProgress), 0.0F, 1.0F);

        // Save the starting point of the animations so that when the animation is stopped
        // we will return to that point.
        _currentPlayFromProgress = from;

        if (from == to)
        {
            // Nothing to play. But jump to the from position.
            Stop();
            co_return;
        }

        auto durationAsProgress = from < to ? (to - from) : ((1 - from) + to);
        auto duration = std::chrono::duration_cast<TimeSpan>(Duration() * durationAsProgress);

        // Sanity-check the duration: if it's really short, don't bother trying animate.
        if (std::chrono::duration_cast<std::chrono::milliseconds>(duration) < std::chrono::milliseconds(20))
        {
            // Nothing to play. But jump to the from position.
            Stop();
            co_return;
        }

        // Create an animation to drive the Progress property.
        auto compositor = Window::Current().Compositor();
        auto animation = compositor.CreateScalarKeyFrameAnimation();
        animation.Duration(duration);
        auto linearEasing = compositor.CreateLinearEasingFunction();

        animation.InsertKeyFrame(1, static_cast<float>(toProgress), linearEasing);


        // Play from fromProgress to toProgress.
        animation.InsertKeyFrame(0, from);
        if (from > to)
        {
            // Play to the end
            auto timeToEnd = (1 - from) / ((1 - from) + to);
            animation.InsertKeyFrame(timeToEnd, 1, linearEasing);
            // Jump to the beginning
            animation.InsertKeyFrame(timeToEnd + FLT_EPSILON, 0, linearEasing);
        }
        animation.InsertKeyFrame(1, to, linearEasing);

        if (looped)
        {
            animation.IterationBehavior(AnimationIterationBehavior::Forever);
        }
        else
        {
			animation.IterationBehavior(AnimationIterationBehavior::Count);
            animation.IterationCount(1);
        }

		// RS4 has a problem with negative PlaybackRate (it will loop instead of playing once). Work around
		// it by setting the direction to Reverse and using a positive PlaybackRate.
		if (playbackRate < 0)
		{
			animation.Direction(AnimationDirection::Reverse);
		}

        // Create a batch so that we can know when the animation finishes. This only
        // works for non-looping animations (the batch completes immediately
        // for looping animations).
        CompositionScopedBatch batch = looped
            ? nullptr
            : compositor.CreateScopedBatch(CompositionBatchTypes::Animation);

        _progressPropertySet.StartAnimation(L"Progress", animation);

        auto nowPlaying = std::make_shared<AnimationPlay>(
            *this, 
            _progressPropertySet.TryGetAnimationController(L"Progress"));

        // Set the playback rate.
		// RS4 has a problem with negative PlaybackRate (it will loop instead of playing once). Work around
		// it by setting the direction to Reverse and using a positive PlaybackRate.
        nowPlaying->SetPlaybackRate(static_cast<float>(abs(playbackRate)));

        event_token batchCompletedToken{};

        if (batch != nullptr)
        {
            // Subscribe to the batch completed event.
            batchCompletedToken = batch.Completed([nowPlaying](IInspectable const&, CompositionBatchCompletedEventArgs const&)
            {
                nowPlaying->Complete();
            });
            // Indicate that nothing else is going into the batch.
            batch.End();
        }

        // Hold onto nowPlaying so it can be completed if Stop is called or the progress
        // is set.
        _nowPlaying = nowPlaying;

		// Capture the context so we can finish in the calling thread.
		apartment_context calling_thread;

        // Await the current play. The await will complete when the animation completes
        // or Stop() is called.
        co_await *nowPlaying;

        // Get back to the calling thread.
        // This is necessary to unregister from batch.Completed, and because callers
        // from the dispatcher thread will expect to continue on the dispatcher thread.
		co_await calling_thread;

        if (batchCompletedToken)
        {
            // Unsubscribe from batch.Completed.
            batch.Completed(batchCompletedToken);
        }
    }

    void CompositionPlayer::Resume()
    {
        throw hresult_not_implemented();
    }

    void CompositionPlayer::SetProgress(double progress)
    {
        auto clampedProgress = std::clamp(static_cast<float>(progress), 0.0F, 1.0F);

        // Setting the progress value will stop the current play. Ensure the current playing
        // task is completed.
        if (_nowPlaying != nullptr)
        {
            _nowPlaying->Complete();
        }
        _progressPropertySet.InsertScalar(L"Progress", static_cast<float>(clampedProgress));
        _currentPlayFromProgress = clampedProgress;
    }

    void CompositionPlayer::Stop()
    {
        if (_nowPlaying != nullptr)
        {
            // Stop the animation by setting the Progress value to the fromProgress of the
            // most recent play.
            SetProgress(_currentPlayFromProgress);
        }
    }

    void CompositionPlayer::OnSourcePropertyChanged(
        const winrt::DependencyObject& sender,
        const winrt::DependencyPropertyChangedEventArgs& args)
    {
        auto oldValue = args.OldValue();
        auto newValue = args.NewValue();

        AsSelf(sender)->OnSourcePropertyChanged(
            (oldValue != nullptr) ? oldValue.as<ICompositionSource>() : nullptr,
            (newValue != nullptr) ? newValue.as<ICompositionSource>() : nullptr);
    }

    void CompositionPlayer::OnSourcePropertyChanged(ICompositionSource const& oldSource, ICompositionSource const& newSource)
    {
        IDynamicCompositionSource oldDynamicSource;
        if ((oldSource != nullptr)&& oldSource.try_as<IDynamicCompositionSource>(oldDynamicSource))
        {
            // Disconnect from the update notifications of the old source.
            oldDynamicSource.CompositionInvalidated(_dynamicCompositionInvalidatedToken);
        }

        IDynamicCompositionSource newDynamicSource;
        if ((newSource != nullptr) && newSource.try_as<IDynamicCompositionSource>(newDynamicSource))
        {
            // Connect to the update notifications of the new source.
            _dynamicCompositionInvalidatedToken = newDynamicSource.CompositionInvalidated([this](IInspectable const&)
            {
                UpdateContent();
            });
        }

        if (newSource != nullptr)
        {
            UpdateContent();
        }
    }

    void CompositionPlayer::UpdateContent()
    {
        // Unload the current composition (if any).
        UnloadComposition();

        TimeSpan duration{};
        IInspectable diagnostics{};

        auto success = Source().TryCreateInstance(
            Window::Current().Compositor(),
            _compositionRoot,
            _compositionSize,
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

        // Tie the composition's Progress property to the player Progress with an ExpressionAnimation.
        auto compositor = _rootVisual.Compositor();
        auto progressAnimation = compositor.CreateExpressionAnimation(L"my.Progress");
        progressAnimation.SetReferenceParameter(L"my", _progressPropertySet);
        _compositionRoot.Properties().StartAnimation(L"Progress", progressAnimation);

        if (AutoPlay())
        {
            // Start playing immediately.
            PlayAsync(0 /* from */, 1 /* to */, 1 /* playback rate */, IsLoopingEnabled() /* looped */);
        }
    }

    void CompositionPlayer::UnloadComposition()
    {
        if (_compositionRoot != nullptr)
        {
            Stop();

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

    void CompositionPlayer::OnPlaybackRatePropertyChanged(
        const winrt::DependencyObject& sender,
        const winrt::DependencyPropertyChangedEventArgs& args)
    {
        AsSelf(sender)->OnPlaybackRatePropertyChanged(args);
    }

    void CompositionPlayer::OnPlaybackRatePropertyChanged(const winrt::DependencyPropertyChangedEventArgs& args)
    {
        if (_nowPlaying != nullptr)
        {
            _nowPlaying->SetPlaybackRate(static_cast<float>(unbox_value<double>(args.NewValue())));
        }
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
