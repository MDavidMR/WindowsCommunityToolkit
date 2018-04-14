namespace WinCompData.CodeGen
{
#if !WINDOWS_UWP
    public
#endif
    sealed class CompositionObjectFactoryGenerator
    {

        /// <summary>
        /// Returns the C# code for a factory that will instantiate the given <see cref="Visual"/> as a
        /// Windows.UI.Composition Visual.
        /// </summary>
        public static string CreateFactoryCode(Visual visual)
        {
            return @"
using Windows.UI.Composition;

namespace MyNameSpace
{
    sealed class MyFactory
    {
        internal static Visual CreateVisual(Compositor compositor)
        {
            return compositor.CreateVisual();
        }
    }
}
";
        }
    }
}
