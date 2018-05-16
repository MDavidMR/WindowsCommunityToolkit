//
// MainPage.xaml.cpp
// Implementation of the MainPage class.
//

#include "pch.h"
#include "MainPage.xaml.h"
#include "MyComposition.cpp"

using namespace LottieCPPTest;

using namespace Platform;
using namespace Windows::Foundation;
using namespace Windows::Foundation::Collections;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::UI::Xaml::Controls::Primitives;
using namespace Windows::UI::Xaml::Data;
using namespace Windows::UI::Xaml::Input;
using namespace Windows::UI::Xaml::Media;
using namespace Windows::UI::Xaml::Navigation;
using namespace Compositions;


MainPage::MainPage()
{
    InitializeComponent();

    auto const comp = Window::Current->Compositor;
    Visual^ rootVisual;
    float2 size;
    CompositionPropertySet^ progressPropertySet;
    TimeSpan duration;
    Object^ diagnostics;

    // Allocating on the heap is optional - it can also be used on the stack. Allocating
    // on the heap here to ensure it works correctly in that mode.
    auto compositionFactory = ref new MyComposition();
    compositionFactory->TryCreateInstance(comp, &rootVisual, &size, &progressPropertySet, &duration, &diagnostics);

    auto rootShape = comp->CreateSpriteVisual();
    Windows::UI::Xaml::Hosting::ElementCompositionPreview::SetElementChildVisual(animGrid, rootShape);

    rootShape->Children->InsertAtTop(rootVisual);

    progressPropertySet->InsertScalar("Progress", 0);

    auto m_playAnimation = comp->CreateScalarKeyFrameAnimation();
    auto lin = comp->CreateLinearEasingFunction();
    m_playAnimation->Duration = duration;
    m_playAnimation->InsertKeyFrame(0, 0);
    m_playAnimation->InsertKeyFrame(1, 1, lin);
    m_playAnimation->IterationBehavior = AnimationIterationBehavior::Forever;
    progressPropertySet->StartAnimation("Progress", m_playAnimation);
}