#pragma once

#include "CompositionSource.g.h"

namespace winrt::CompPlayer::implementation
{
    struct CompositionSource : CompositionSourceT<CompositionSource>
    {
        CompositionSource() = default;

        bool TryCreateInstance(Windows::UI::Composition::Compositor const& compositor, Windows::UI::Composition::Visual& rootVisual, Windows::Foundation::Numerics::float2& size, Windows::UI::Composition::CompositionPropertySet& progressPropertySet, Windows::Foundation::TimeSpan& duration, Windows::Foundation::IInspectable& diagnostics);
    };
}

namespace winrt::CompPlayer::factory_implementation
{
    struct CompositionSource : CompositionSourceT<CompositionSource, implementation::CompositionSource>
    {
    };
}
