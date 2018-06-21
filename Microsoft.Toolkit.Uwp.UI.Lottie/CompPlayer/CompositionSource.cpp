#include "pch.h"
#include "CompositionSource.h"

namespace winrt::CompPlayer::implementation
{
    bool CompositionSource::TryCreateInstance(Windows::UI::Composition::Compositor const& compositor, Windows::UI::Composition::Visual& rootVisual, Windows::Foundation::Numerics::float2& size, Windows::UI::Composition::CompositionPropertySet& progressPropertySet, Windows::Foundation::TimeSpan& duration, Windows::Foundation::IInspectable& diagnostics)
    {
        throw hresult_not_implemented();
    }
}
