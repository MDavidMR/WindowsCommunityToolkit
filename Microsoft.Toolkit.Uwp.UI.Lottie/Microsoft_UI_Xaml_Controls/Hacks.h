#pragma once
#include <winrt\base.h>

#include <winrt\Windows.UI.Xaml.Hosting.h>

namespace winrt
{
    using namespace Windows::UI::Xaml;
    using namespace Windows::UI::Xaml::Hosting;
    using namespace Windows::Foundation;
    using namespace Windows::UI::Composition;
    using namespace Windows::UI::Xaml::Media;
    using namespace Windows::Foundation::Numerics;
}

// Copied from CastHelpers.h
template <typename T, typename U>
T safe_cast(const U& value)
{
    if (value)
    {
        return value.as<T>();
    }
    return nullptr;
}

template <typename T, typename U>
T safe_try_cast(const U& value)
{
    if (value)
    {
        return value.try_as<T>();
    }
    return nullptr;
}

struct auto_cast
{
    explicit auto_cast(winrt::IInspectable const& value) : m_value(value)
    {
    }

    template <typename T>
    operator T() const
    {
        return safe_cast<T>(m_value);
    }

private:
    winrt::IInspectable const& m_value;
};