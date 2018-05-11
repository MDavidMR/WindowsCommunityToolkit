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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

#define OOBE_MAIN_STARTFRAME 0
#define OOBE_MAIN_HI_FRAME 360
#define OOBE_MAIN_ENDFRAME 592

MainPage::MainPage()
{
    InitializeComponent();

    auto const comp = Window::Current->Compositor;
    Visual^ rootVisual;
    float2 size;
    CompositionPropertySet^ progressPropertySet;
    TimeSpan duration;

    Oobe_hi compositionFactory;
    compositionFactory.TryCreateInstance(comp, rootVisual, size, progressPropertySet, duration);
	
    auto rootShape = comp->CreateSpriteVisual();
    Windows::UI::Xaml::Hosting::ElementCompositionPreview::SetElementChildVisual(animGrid, rootShape);

    rootShape->Children->InsertAtTop(rootVisual);
    progressPropertySet->InsertScalar("Progress", 0);

    auto m_playAnimation = comp->CreateScalarKeyFrameAnimation();
    auto lin = comp->CreateLinearEasingFunction();
    m_playAnimation->Duration = duration;
    m_playAnimation->InsertKeyFrame(0, OOBE_MAIN_STARTFRAME / OOBE_MAIN_ENDFRAME);
    m_playAnimation->InsertKeyFrame(1, OOBE_MAIN_ENDFRAME / OOBE_MAIN_ENDFRAME, lin);
    m_playAnimation->IterationBehavior = AnimationIterationBehavior::Forever;
    progressPropertySet->StartAnimation("Progress", m_playAnimation);
}