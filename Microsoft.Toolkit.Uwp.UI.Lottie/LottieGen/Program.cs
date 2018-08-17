using LottieData;
using LottieData.Serialization;
using LottieData.Tools;
using LottieToWinComp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using WinCompData;
using WinCompData.CodeGen;
using WinCompData.Tools;

static class Program
{
    static readonly Assembly s_thisAssembly = Assembly.GetExecutingAssembly();

    enum RunResult
    {
        Success,
        InvalidUsage,
        Failure,
    }

    static int Main(string[] args)
    {
        var infoStream = Console.Out;
        var errorStream = Console.Out;

        switch (Run(CommandLineOptions.ParseCommandLine(args), infoStream: infoStream, errorStream: errorStream))
        {
            case RunResult.Success:
                return 0;

            case RunResult.Failure:
                return 1;

            case RunResult.InvalidUsage:
                errorStream.WriteLine();
                ShowUsage(errorStream);
                return 1;

            default:
                // Should never get here.
                throw new InvalidOperationException();
        }
    }


    static IEnumerable<string> ExpandWildcards(string path)
    {
        var directoryPath = Path.GetDirectoryName(path);
        if (string.IsNullOrWhiteSpace(directoryPath))
        {
            directoryPath = ".";
        }
        return Directory.EnumerateFiles(directoryPath, Path.GetFileName(path));
    }

    static RunResult Run(CommandLineOptions options, TextWriter infoStream, TextWriter errorStream)
    {
        // Sign on
        var assemblyVersion = s_thisAssembly.GetName().Version;

        var toolNameAndVersion = $"Lottie for Windows Code Generator version {assemblyVersion}";
        infoStream.WriteLine(toolNameAndVersion);
        infoStream.WriteLine();

        if (options.ErrorDescription != null)
        {
            // Failed to parse the command line.
            WriteError("Invalid arguments.");
            errorStream.WriteLine(options.ErrorDescription);
            return RunResult.InvalidUsage;
        }
        else if (options.HelpRequested)
        {
            ShowHelp(infoStream);
            return RunResult.Success;
        }

        // Check for required args
        if (options.InputFile == null)
        {
            WriteError("Lottie file not specified.");
            return RunResult.InvalidUsage;
        }

        switch (options.Language)
        {
            case Lang.Unknown:
                WriteError("Invalid language.");
                return RunResult.InvalidUsage;
            case Lang.Unspecified:
                WriteError("Language not specified.");
                return RunResult.InvalidUsage;
        }

        // Check that at least one file matches InputFile.
        var matchingInputFiles = ExpandWildcards(options.InputFile).ToArray();
        if (matchingInputFiles.Length == 0)
        {
            WriteError($"File not found: {options.InputFile}");
            return RunResult.Failure;
        }

        var profiler = new Profiler();

        // Get the output folder as an absolute path, defaulting to the current directory
        // if no output folder was specified.
        var outputFolder = MakeAbsolutePath(options.OutputFolder ?? Directory.GetCurrentDirectory());


        // Assume success.
        var result = RunResult.Success;

        foreach (var file in matchingInputFiles)
        {
            // Get the input file as an absolute path.
            var inputFile = MakeAbsolutePath(file);

            LottieData.Tools.Stats lottieStats;
            WinCompData.Tools.Stats beforeOptimizationStats;
            WinCompData.Tools.Stats afterOptimizationStats;

            var codeGenResult = TryGenerateCode(
                        lottieJsonFile: inputFile,
                        outputFolder: outputFolder,
                        codeGenClassName: options.ClassName,
                        language: options.Language,
                        strictTranslation: options.StrictMode,
                        disableCodeGenOptimizer: options.DisableCodeGenOptimizer,
                        disableTranslationOptimizer: options.DisableTranslationOptimizer,
                        infoStream: infoStream,
                        errorStream: errorStream,
                        profiler: profiler,
                        lottieStats: out lottieStats,
                        beforeOptimizationStats: out beforeOptimizationStats,
                        afterOptimizationStats: out afterOptimizationStats)
                    ? RunResult.Success
                    : RunResult.Failure;

            infoStream.WriteLine();
            infoStream.WriteLine(" === Timings ===");
            profiler.WriteReport(infoStream);

            infoStream.WriteLine();
            WriteLottieStatsReport(infoStream, lottieStats);

            infoStream.WriteLine();
            WriteCodeGenStatsReport(infoStream, beforeOptimizationStats, afterOptimizationStats);

            if (result == RunResult.Success && codeGenResult != RunResult.Success)
            {
                result = codeGenResult;
            }
        }
        return result;

        // Helper for writing errors to the error stream.
        void WriteError(string errorMessage)
        {
            errorStream.WriteLine($"Error: {errorMessage}");
        }
    }

    static void WriteLottieStatsReport(
        TextWriter writer,
        LottieData.Tools.Stats stats)
    {
        writer.WriteLine(" === Lottie info ===");
        WriteStatsStringLine("BodyMovin Version", stats.Version.ToString());
        WriteStatsStringLine("Name", stats.Name);
        WriteStatsStringLine("Size", $"{stats.Width} x {stats.Height}");
        WriteStatsStringLine("Duration", $"{stats.Duration.TotalSeconds.ToString("#,##0.0##")} seconds");
        WriteStatsIntLine("PreComps", stats.PreCompLayerCount);
        WriteStatsIntLine("Solids", stats.SolidLayerCount);
        WriteStatsIntLine("Images", stats.ImageLayerCount);
        WriteStatsIntLine("Nulls", stats.NullLayerCount);
        WriteStatsIntLine("Shapes", stats.ShapeLayerCount);
        WriteStatsIntLine("Texts", stats.TextLayerCount);

        const int nameWidth = 19;
        void WriteStatsIntLine(string name, int value)
        {
            if (value > 0)
            {
                writer.WriteLine($"{name,nameWidth}  {value,6:n0}");
            }
        }

        void WriteStatsStringLine(string name, string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                writer.WriteLine($"{name,nameWidth}  {value}");
            }
        }

    }

    static void WriteCodeGenStatsReport(
        TextWriter writer,
        WinCompData.Tools.Stats beforeOptimization,
        WinCompData.Tools.Stats afterOptimization)
    {
        if (beforeOptimization == null)
        {
            return;
        }

        writer.WriteLine(" === Translation output stats ===");

        writer.WriteLine("                      Type   Count  Optimized away");

        if (afterOptimization == null)
        {
            // No optimization was performed. Just report on the before stats.
            afterOptimization = beforeOptimization;
        }

        // Report on the after stats and indicate how much optimization
        // improved things (where it did).
        WriteStatsLine("CanvasGeometry", beforeOptimization.CanvasGeometryCount, afterOptimization.CanvasGeometryCount);
        WriteStatsLine("ColorBrush", beforeOptimization.ColorBrushCount, afterOptimization.ColorBrushCount);
        WriteStatsLine("ColorKeyFrameAnimation", beforeOptimization.ColorKeyFrameAnimationCount, afterOptimization.ColorKeyFrameAnimationCount);
        WriteStatsLine("CompositionPath", beforeOptimization.CompositionPathCount, afterOptimization.CompositionPathCount);
        WriteStatsLine("ContainerShape", beforeOptimization.ContainerShapeCount, afterOptimization.ContainerShapeCount);
        WriteStatsLine("ContainerVisual", beforeOptimization.ContainerVisualCount, afterOptimization.ContainerVisualCount);
        WriteStatsLine("CubicBezierEasingFunction", beforeOptimization.CubicBezierEasingFunctionCount, afterOptimization.CubicBezierEasingFunctionCount);
        WriteStatsLine("EllipseGeometry", beforeOptimization.EllipseGeometryCount, afterOptimization.EllipseGeometryCount);
        WriteStatsLine("ExpressionAnimation", beforeOptimization.ExpressionAnimationCount, afterOptimization.ExpressionAnimationCount);
        WriteStatsLine("GeometricClip", beforeOptimization.GeometricClipCount, afterOptimization.GeometricClipCount);
        WriteStatsLine("InsetClip", beforeOptimization.InsetClipCount, afterOptimization.InsetClipCount);
        WriteStatsLine("LinearEasingFunction", beforeOptimization.LinearEasingFunctionCount, afterOptimization.LinearEasingFunctionCount);
        WriteStatsLine("PathGeometry", beforeOptimization.PathGeometryCount, afterOptimization.PathGeometryCount);
        WriteStatsLine("PathKeyFrameAnimation", beforeOptimization.PathKeyFrameAnimationCount, afterOptimization.PathKeyFrameAnimationCount);
        WriteStatsLine("Property value", beforeOptimization.PropertyCount, afterOptimization.PropertyCount);
        WriteStatsLine("PropertySet", beforeOptimization.PropertySetCount, afterOptimization.PropertySetCount);
        WriteStatsLine("RectangleGeometry", beforeOptimization.RectangleGeometryCount, afterOptimization.RectangleGeometryCount);
        WriteStatsLine("RoundedRectangleGeometry", beforeOptimization.RoundedRectangleGeometryCount, afterOptimization.RoundedRectangleGeometryCount);
        WriteStatsLine("ScalarKeyFrameAnimation", beforeOptimization.ScalarKeyFrameAnimationCount, afterOptimization.ScalarKeyFrameAnimationCount);
        WriteStatsLine("ShapeVisual", beforeOptimization.ShapeVisualCount, afterOptimization.ShapeVisualCount);
        WriteStatsLine("SpriteShape", beforeOptimization.SpriteShapeCount, afterOptimization.SpriteShapeCount);
        WriteStatsLine("StepEasingFunction", beforeOptimization.StepEasingFunctionCount, afterOptimization.StepEasingFunctionCount);
        WriteStatsLine("Vector2KeyFrameAnimation", beforeOptimization.Vector2KeyFrameAnimationCount, afterOptimization.Vector2KeyFrameAnimationCount);
        WriteStatsLine("Vector3KeyFrameAnimation", beforeOptimization.Vector3KeyFrameAnimationCount, afterOptimization.Vector3KeyFrameAnimationCount);
        WriteStatsLine("ViewBox", beforeOptimization.ViewBoxCount, afterOptimization.ViewBoxCount);

        void WriteStatsLine(string name, int before, int after)
        {
            if (after > 0 || before > 0)
            {
                const int nameWidth = 26;
                if (before != after)
                {
                    writer.WriteLine($"{name,nameWidth}  {after,6:n0} {before - after,6:n0}");

                }
                else
                {
                    writer.WriteLine($"{name,nameWidth}  {after,6:n0}");
                }
            }
        }
    }


    static bool TryGenerateCode(
        string lottieJsonFile,
        string outputFolder,
        string codeGenClassName,
        Lang language,
        bool strictTranslation,
        bool disableTranslationOptimizer,
        bool disableCodeGenOptimizer,
        TextWriter infoStream,
        TextWriter errorStream,
        Profiler profiler,
        out LottieData.Tools.Stats lottieStats,
        out WinCompData.Tools.Stats beforeOptimizationStats,
        out WinCompData.Tools.Stats afterOptimizationStats)
    {
        lottieStats = null;
        beforeOptimizationStats = null;
        afterOptimizationStats = null;

        if (!TryEnsureDirectoryExists(outputFolder))
        {
            errorStream.WriteLine($"Failed to create the output directory: {outputFolder}");
            return false;
        }

        // Read the Lottie .json text.
        infoStream.WriteLine($"Reading Lottie file: {lottieJsonFile}");
        var jsonStream = TryReadTextFile(lottieJsonFile);

        if (jsonStream == null)
        {
            errorStream.WriteLine($"Failed to read Lottie file: {lottieJsonFile}");
            return false;
        }

        // Parse the Lottie.
        var lottieComposition =
            LottieCompositionReader.ReadLottieCompositionFromJsonStream(
                jsonStream,
                LottieCompositionReader.Options.IgnoreMatchNames,
                out var readerIssues);

        profiler.OnParseFinished();

        lottieStats = new LottieData.Tools.Stats(lottieComposition);

        foreach (var issue in readerIssues)
        {
            infoStream.WriteLine(IssueToString(lottieJsonFile, issue));
        }

        if (lottieComposition == null)
        {
            errorStream.WriteLine($"Failed to parse Lottie file: {lottieJsonFile}");
            return false;
        }

        bool translateSucceeded = false;
        Visual wincompDataRootVisual = null;

        // LottieXml doesn't need the Lottie to be translated. Everyone else does.
        if (language != Lang.LottieXml)
        {
            translateSucceeded = LottieToWinCompTranslator.TryTranslateLottieComposition(
                        lottieComposition,
                        strictTranslation, // strictTranslation
                        true, // TODO - make this configurable?  !excludeCodegenDescriptions, // add descriptions for codegen commments
                        out wincompDataRootVisual,
                        out var translationIssues);

            profiler.OnTranslateFinished();

            foreach (var issue in translationIssues)
            {
                infoStream.WriteLine(IssueToString(lottieJsonFile, issue));
            }

            if (!translateSucceeded)
            {
                errorStream.WriteLine("Failed to translate Lottie file.");
                return false;
            }
        }

        beforeOptimizationStats = new WinCompData.Tools.Stats(wincompDataRootVisual);
        profiler.OnUnmeasuredFinished();

        // Get an appropriate name for the class.
        string className =
            InstantiatorGeneratorBase.TrySynthesizeClassName(codeGenClassName) ??
            InstantiatorGeneratorBase.TrySynthesizeClassName(Path.GetFileNameWithoutExtension(lottieJsonFile)) ??
            // If all else fails, just call it Lottie.
            InstantiatorGeneratorBase.TrySynthesizeClassName("Lottie");

        // Optimize the code unless told not to.
        Visual optimizedWincompDataRootVisual = wincompDataRootVisual;
        if (!disableTranslationOptimizer)
        {
            optimizedWincompDataRootVisual = Optimizer.Optimize(wincompDataRootVisual, ignoreCommentProperties: true);
            profiler.OnOptimizationFinished();

            afterOptimizationStats = new WinCompData.Tools.Stats(optimizedWincompDataRootVisual);
            profiler.OnUnmeasuredFinished();
        }

        var lottieFileNameBase = Path.GetFileNameWithoutExtension(lottieJsonFile);

        bool codeGenSucceeded = false;
        switch (language)
        {
            case Lang.CSharp:
                codeGenSucceeded = TryGenerateCSharpCode(
                    className,
                    optimizedWincompDataRootVisual,
                    (float)lottieComposition.Width,
                    (float)lottieComposition.Height,
                    lottieComposition.Duration,
                    Path.Combine(outputFolder, $"{lottieFileNameBase}.cs"),
                    disableCodeGenOptimizer: disableCodeGenOptimizer,
                    infoStream: infoStream,
                    errorStream: errorStream);
                profiler.OnCodeGenFinished();
                break;

            case Lang.Cx:
                codeGenSucceeded = TryGenerateCXCode(
                    className,
                    optimizedWincompDataRootVisual,
                    (float)lottieComposition.Width,
                    (float)lottieComposition.Height,
                    lottieComposition.Duration,
                    Path.Combine(outputFolder, $"{lottieFileNameBase}.h"),
                    Path.Combine(outputFolder, $"{lottieFileNameBase}.cpp"),
                    disableCodeGenOptimizer: disableCodeGenOptimizer,
                    infoStream: infoStream,
                    errorStream: errorStream);
                profiler.OnCodeGenFinished();
                break;

            case Lang.LottieXml:
                codeGenSucceeded = TryGenerateLottieXml(
                    lottieComposition,
                    Path.Combine(outputFolder, $"{lottieFileNameBase}.xml"),
                    infoStream,
                    errorStream);
                profiler.OnSerializationFinished();
                break;

            case Lang.WinCompXml:
                codeGenSucceeded = TryGenerateWincompXml(
                    optimizedWincompDataRootVisual,
                    Path.Combine(outputFolder, $"{lottieFileNameBase}.xml"),
                    infoStream,
                    errorStream);
                profiler.OnSerializationFinished();
                break;

            case Lang.WinCompDgml:
                codeGenSucceeded = TryGenerateWincompDgml(
                    optimizedWincompDataRootVisual,
                    Path.Combine(outputFolder, $"{lottieFileNameBase}.dgml"),
                    infoStream: infoStream,
                    errorStream: errorStream);
                profiler.OnSerializationFinished();
                break;

            default:
                errorStream.WriteLine($"Language {language} is not supported.");
                return false;
        };


        return codeGenSucceeded;
    }

    static bool TryGenerateLottieXml(
        LottieComposition lottieComposition,
        string outputFilePath,
        TextWriter infoStream,
        TextWriter errorStream)
    {
        var result = TryWriteTextFile(
            outputFilePath,
            LottieCompositionXmlSerializer.ToXml(lottieComposition).ToString());

        infoStream.WriteLine($"Lottie XML written to {outputFilePath}");

        return result;
    }

    static bool TryGenerateWincompXml(
        Visual rootVisual,
        string outputFilePath,
        TextWriter infoStream,
        TextWriter errorStream)
    {
        var result = TryWriteTextFile(
            outputFilePath,
            CompositionObjectXmlSerializer.ToXml(rootVisual).ToString());

        infoStream.WriteLine($"WinComp XML written to {outputFilePath}");

        return result;
    }

    static bool TryGenerateWincompDgml(
        Visual rootVisual,
        string outputFilePath,
        TextWriter infoStream,
        TextWriter errorStream)
    {
        var result = TryWriteTextFile(
            outputFilePath,
            CompositionObjectDgmlSerializer.ToXml(rootVisual).ToString());

        infoStream.WriteLine($"WinComp DGML written to {outputFilePath}");

        return result;
    }

    static bool TryGenerateCSharpCode(
        string className,
        Visual rootVisual,
        float compositionWidth,
        float compositionHeight,
        TimeSpan duration,
        string outputFilePath,
        bool disableCodeGenOptimizer,
        TextWriter infoStream,
        TextWriter errorStream)
    {

        var code = CSharpInstantiatorGenerator.CreateFactoryCode(
                    className,
                    rootVisual,
                    compositionWidth,
                    compositionHeight,
                    duration,
                    disableCodeGenOptimizer);

        if (string.IsNullOrWhiteSpace(code))
        {
            errorStream.WriteLine("Failed to create the C# code.");
            return false;
        }

        if (!TryWriteTextFile(outputFilePath, code))
        {
            errorStream.WriteLine($"Failed to write C# code to {outputFilePath}");
            return false;
        }

        infoStream.WriteLine($"C# code for class {className} written to {outputFilePath}");
        return true;
    }

    static bool TryGenerateCXCode(
        string className,
        Visual rootVisual,
        float compositionWidth,
        float compositionHeight,
        TimeSpan duration,
        string outputHeaderFilePath,
        string outputCppFilePath,
        bool disableCodeGenOptimizer,
        TextWriter infoStream,
        TextWriter errorStream)
    {
        CxInstantiatorGenerator.CreateFactoryCode(
                className,
                rootVisual,
                compositionWidth,
                compositionHeight,
                duration,
                Path.GetFileName(outputHeaderFilePath),
                out var cppText,
                out var hText,
                disableCodeGenOptimizer);

        if (string.IsNullOrWhiteSpace(cppText))
        {
            errorStream.WriteLine("Failed to generate the .cpp code.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(hText))
        {
            errorStream.WriteLine("Failed to generate the .h code.");
            return false;
        }

        if (!TryWriteTextFile(outputHeaderFilePath, hText))
        {
            errorStream.WriteLine($"Failed to write .h code to {outputHeaderFilePath}");
            return false;
        }

        if (!TryWriteTextFile(outputCppFilePath, cppText))
        {
            errorStream.WriteLine($"Failed to write .cpp code to {outputCppFilePath}");
            return false;
        }

        infoStream.WriteLine($"Header code for class {className} written to {outputHeaderFilePath}");
        infoStream.WriteLine($"Source code for class {className} written to {outputCppFilePath}");
        return true;
    }

    static bool TryEnsureDirectoryExists(string directoryPath)
    {
        try
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }
        catch (Exception)
        {
            return false;
        }
        return true;
    }

    static Stream TryReadTextFile(string filePath)
    {
        try
        {
            return File.OpenRead(filePath);
        }
        catch (Exception)
        {
            return null;
        }
    }

    static bool TryWriteTextFile(string filePath, string contents)
    {
        try
        {
            File.WriteAllText(filePath, contents, Encoding.UTF8);
            return true;
        }
        catch
        {
            return false;
        }
    }

    static string MakeAbsolutePath(string path)
    {
        return Path.IsPathRooted(path) ? path : Path.Combine(Directory.GetCurrentDirectory(), path);
    }

    // Outputs an error or warning message describing the error with the file path, error code, and description.
    // The format is designed to be suitable for parsing by VS.
    static string IssueToString(string originatingFile, (string Code, string Description) issue)
    {
        return $"{originatingFile}: error {issue.Code}: {issue.Description}";
    }

    static void ShowHelp(TextWriter writer)
    {
        writer.WriteLine("Generates source code from Lottie .json files.");
        writer.WriteLine();
        ShowUsage(writer);
    }

    static void ShowUsage(TextWriter writer)
    {
        writer.WriteLine(Usage);
    }

    static string Usage => string.Format(@"
Usage: {0} -InputFile LOTTIEFILE -Language LANG [Other options]

OVERVIEW:
       Generates source code from Lottie files for playing in the CompositionPlayer. 
       LOTTIEFILE is a Lottie .json file. LOTTIEFILE may contain wildcards.
       LANG is one of cs, cppcx, winrtcpp, wincompxml, lottiexml, or dgml.

       [Other options]

         -Help         Print this help message and exit.
         -ClassName    Uses the given class name for the generated code. If not 
                       specified the name is synthesized from the name of the Lottie 
                       file. The class name will be sanitized as necessary to be valid
                       for the language and will also be used as the base name of 
                       the output file(s).
         -DisableTranslationOptimizer  
                       Disables optimization of the translation from Lottie to
                       Windows code. Mainly used to detect bugs in the optimizer.
         -DisableCodeGenOptimizer
                       Disables optimization done by the code generator. This is 
                       useful when the generated code is going to be hacked on.
         -OutputFolder Specifies the output folder for the generated files. If not
                       specified the files will be written to the current directory.
         -Strict       Fails on any parsing or translation issue. If not specified, 
                       a best effort will be made to create valid output, and any 
                       issues will be reported to STDOUT.

EXAMPLES:

       Generate Foo.cpp and Foo.h winrtcpp files in the current directory from the 
       Lottie file Foo.json:

         {0} -InputFile Foo.json -Language winrtcpp


       Keywords can be abbreviated and are case insensitive.
       Generate Grotz.cs in the C:\temp directory from the Lottie file Bar.json:

         {0} -i Bar.json -L cs -ClassName Grotz -o C:\temp", s_thisAssembly.ManifestModule.Name);



    // Measures time spent in each phase.
    sealed class Profiler
    {
        readonly Stopwatch _sw = Stopwatch.StartNew();
        // Bucket of time to dump time we don't want to measure. Never reported.
        TimeSpan _unmeasuredTime;
        TimeSpan _parseTime;
        TimeSpan _translateTime;
        TimeSpan _optimizationTime;
        TimeSpan _codegenTime;
        TimeSpan _serializationTime;

        internal void OnUnmeasuredFinished() => OnPhaseFinished(ref _unmeasuredTime);
        internal void OnParseFinished() => OnPhaseFinished(ref _parseTime);
        internal void OnTranslateFinished() => OnPhaseFinished(ref _translateTime);
        internal void OnOptimizationFinished() => OnPhaseFinished(ref _optimizationTime);
        internal void OnCodeGenFinished() => OnPhaseFinished(ref _codegenTime);
        internal void OnSerializationFinished() => OnPhaseFinished(ref _serializationTime);

        void OnPhaseFinished(ref TimeSpan counter)
        {
            counter = _sw.Elapsed;
            _sw.Restart();
        }

        internal void WriteReport(TextWriter writer)
        {
            WriteReportForPhase(writer, "parse", _parseTime);
            WriteReportForPhase(writer, "translate", _translateTime);
            WriteReportForPhase(writer, "optimization", _optimizationTime);
            WriteReportForPhase(writer, "codegen", _codegenTime);
            WriteReportForPhase(writer, "serialization", _serializationTime);
        }

        void WriteReportForPhase(TextWriter writer, string phaseName, TimeSpan value)
        {
            // Ignore phases that didn't occur.
            if (value > TimeSpan.Zero)
            {
                writer.WriteLine($"{value} spent in {phaseName}.");
            }
        }
    }
}


