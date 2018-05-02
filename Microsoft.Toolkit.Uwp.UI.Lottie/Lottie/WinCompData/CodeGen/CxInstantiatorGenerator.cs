using System;

namespace WinCompData.CodeGen
{
#if !WINDOWS_UWP
    public
#endif
    sealed class CxInstantiatorGenerator : InstantiatorGeneratorBase
    {

        CxInstantiatorGenerator(CompositionObject graphRoot, bool setCommentProperties) 
            : base(graphRoot, setCommentProperties, new CppStringifier())
        {
        }

        /// <summary>
        /// Returns the Cx code for a factory that will instantiate the given <see cref="Visual"/> as a
        /// Windows.UI.Composition Visual.
        /// </summary>
        public static string CreateFactoryCode(
            string className,
            Visual rootVisual,
            float width,
            float height,
            CompositionPropertySet progressPropertySet,
            TimeSpan duration)
        {
            var generator = new CxInstantiatorGenerator(rootVisual, false);
            return generator.GenerateCode(className, rootVisual, width, height, progressPropertySet, duration);
        }


        protected override void GenerateNamespaceUsings(CodeBuilder builder, bool requiresD2d)
        {
            if (requiresD2d)
            {
                // TODO: what namespaces does D2D need?
            }
            // TODO: are all of these needed?
            // TODO: are any needed - if we just generate code inline in somebody's class, these don't matter.
            builder.WriteLine("using namespace Platform;");
            builder.WriteLine("using namespace Windows::Foundation;");
            builder.WriteLine("using namespace Windows::UI;");
            builder.WriteLine("using namespace Windows::UI::Composition;");
            builder.WriteLine("using namespace Windows::UI::Xaml;");
        }

    }
}