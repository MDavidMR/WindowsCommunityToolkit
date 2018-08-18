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

sealed class Program
{
    static readonly Assembly s_thisAssembly = Assembly.GetExecutingAssembly();
    readonly CommandLineOptions _options;
    readonly TextWriter _infoStream;
    readonly TextWriter _errorStream;
    readonly Profiler _profiler;

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

    // Helper for writing errors to the error stream with a standard format
    void WriteError(string errorMessage)
    {
        _errorStream.WriteLine($"Error: {errorMessage}");
    }

    Program(CommandLineOptions options, TextWriter infoStream, TextWriter errorStream)
    {
        _options = options;
        _infoStream = infoStream;
        _errorStream = errorStream;
        _profiler = new Profiler();
    }

    static RunResult Run(CommandLineOptions options, TextWriter infoStream, TextWriter errorStream)
    {
        return new Program(options, infoStream, errorStream).Run();
    }

    RunResult Run()
    {
        // Sign on
        var assemblyVersion = s_thisAssembly.GetName().Version;

        var toolNameAndVersion = $"Lottie for Windows Code Generator version {assemblyVersion}";
        _infoStream.WriteLine(toolNameAndVersion);
        _infoStream.WriteLine();

        if (_options.ErrorDescription != null)
        {
            // Failed to parse the command line.
            WriteError("Invalid arguments.");
            _errorStream.WriteLine(_options.ErrorDescription);
            return RunResult.InvalidUsage;
        }
        else if (_options.HelpRequested)
        {
            ShowHelp(_infoStream);
            return RunResult.Success;
        }

        // Check for required args
        if (_options.InputFile == null)
        {
            WriteError("Lottie file not specified.");
            return RunResult.InvalidUsage;
        }

        switch (_options.Language)
        {
            case Lang.Unknown:
                WriteError("Invalid language.");
                return RunResult.InvalidUsage;
            case Lang.Unspecified:
                WriteError("Language not specified.");
                return RunResult.InvalidUsage;
        }

        // Check that at least one file matches InputFile.
        var matchingInputFiles = ExpandWildcards(_options.InputFile).ToArray();
        if (matchingInputFiles.Length == 0)
        {
            WriteError($"File not found: {_options.InputFile}");
            return RunResult.Failure;
        }

        // Get the output folder as an absolute path, defaulting to the current directory
        // if no output folder was specified.
        var outputFolder = MakeAbsolutePath(_options.OutputFolder ?? Directory.GetCurrentDirectory());


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
                        codeGenClassName: _options.ClassName,
                        strictTranslation: _options.StrictMode,
                        lottieStats: out lottieStats,
                        beforeOptimizationStats: out beforeOptimizationStats,
                        afterOptimizationStats: out afterOptimizationStats)
                    ? RunResult.Success
                    : RunResult.Failure;

            if (_profiler.HasAnyResults)
            {
                _infoStream.WriteLine();
                _infoStream.WriteLine(" === Timings ===");
                _profiler.WriteReport(_infoStream);
            }

            if (lottieStats != null)
            {
                _infoStream.WriteLine();
                WriteLottieStatsReport(_infoStream, lottieStats);
            }

            if (beforeOptimizationStats != null && afterOptimizationStats != null)
            {
                _infoStream.WriteLine();
                WriteCodeGenStatsReport(_infoStream, beforeOptimizationStats, afterOptimizationStats);
            }

            if (result == RunResult.Success && codeGenResult != RunResult.Success)
            {
                result = codeGenResult;
            }
        }
        return result;
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
        WriteStatsIntLine("Images", stats.ImageLayerCount);
        WriteStatsIntLine("PreComps", stats.PreCompLayerCount);
        WriteStatsIntLine("Shapes", stats.ShapeLayerCount);
        WriteStatsIntLine("Solids", stats.SolidLayerCount);
        WriteStatsIntLine("Nulls", stats.NullLayerCount);
        WriteStatsIntLine("Texts", stats.TextLayerCount);
        WriteStatsIntLine("Masks", stats.MaskCount);
        WriteStatsIntLine("MaskAdditive", stats.MaskAdditiveCount);
        WriteStatsIntLine("MaskDarken", stats.MaskDarkenCount);
        WriteStatsIntLine("MaskDifference", stats.MaskDifferenceCount);
        WriteStatsIntLine("MaskIntersect", stats.MaskIntersectCount);
        WriteStatsIntLine("MaskLighten", stats.MaskLightenCount);
        WriteStatsIntLine("MaskSubtract", stats.MaskSubtractCount);

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


    bool TryGenerateCode(
        string lottieJsonFile,
        string outputFolder,
        string codeGenClassName,
        bool strictTranslation,
        out LottieData.Tools.Stats lottieStats,
        out WinCompData.Tools.Stats beforeOptimizationStats,
        out WinCompData.Tools.Stats afterOptimizationStats)
    {
        lottieStats = null;
        beforeOptimizationStats = null;
        afterOptimizationStats = null;

        if (!TryEnsureDirectoryExists(outputFolder))
        {
            WriteError($"Failed to create the output directory: {outputFolder}");
            return false;
        }

        // Read the Lottie .json text.
        _infoStream.WriteLine($"Reading Lottie file: {lottieJsonFile}");
        var jsonStream = TryReadTextFile(lottieJsonFile);

        if (jsonStream == null)
        {
            WriteError($"Failed to read Lottie file: {lottieJsonFile}");
            return false;
        }

        // Parse the Lottie.
        var lottieComposition =
            LottieCompositionReader.ReadLottieCompositionFromJsonStream(
                jsonStream,
                LottieCompositionReader.Options.IgnoreMatchNames,
                out var readerIssues);

        _profiler.OnParseFinished();

        foreach (var issue in readerIssues)
        {
            _infoStream.WriteLine(IssueToString(lottieJsonFile, issue));
        }

        if (lottieComposition == null)
        {
            WriteError($"Failed to parse Lottie file: {lottieJsonFile}");
            return false;
        }

        lottieStats = new LottieData.Tools.Stats(lottieComposition);

        bool translateSucceeded = false;
        Visual wincompDataRootVisual = null;

        // LottieXml doesn't need the Lottie to be translated. Everyone else does.
        if (_options.Language != Lang.LottieXml)
        {
            translateSucceeded = LottieToWinCompTranslator.TryTranslateLottieComposition(
                        lottieComposition,
                        strictTranslation, // strictTranslation
                        true, // TODO - make this configurable?  !excludeCodegenDescriptions, // add descriptions for codegen commments
                        out wincompDataRootVisual,
                        out var translationIssues);

            _profiler.OnTranslateFinished();

            foreach (var issue in translationIssues)
            {
                _infoStream.WriteLine(IssueToString(lottieJsonFile, issue));
            }

            if (!translateSucceeded)
            {
                WriteError("Failed to translate Lottie file.");
                return false;
            }
        }

        beforeOptimizationStats = new WinCompData.Tools.Stats(wincompDataRootVisual);
        _profiler.OnUnmeasuredFinished();

        // Get an appropriate name for the class.
        string className =
            InstantiatorGeneratorBase.TrySynthesizeClassName(codeGenClassName) ??
            InstantiatorGeneratorBase.TrySynthesizeClassName(Path.GetFileNameWithoutExtension(lottieJsonFile)) ??
            // If all else fails, just call it Lottie.
            InstantiatorGeneratorBase.TrySynthesizeClassName("Lottie");

        // Optimize the code unless told not to.
        Visual optimizedWincompDataRootVisual = wincompDataRootVisual;
        if (!_options.DisableTranslationOptimizer)
        {
            optimizedWincompDataRootVisual = Optimizer.Optimize(wincompDataRootVisual, ignoreCommentProperties: true);
            _profiler.OnOptimizationFinished();

            afterOptimizationStats = new WinCompData.Tools.Stats(optimizedWincompDataRootVisual);
            _profiler.OnUnmeasuredFinished();
        }

        var lottieFileNameBase = Path.GetFileNameWithoutExtension(lottieJsonFile);

        bool codeGenSucceeded = false;
        switch (_options.Language)
        {
            case Lang.CSharp:
                codeGenSucceeded = TryGenerateCSharpCode(
                    className,
                    optimizedWincompDataRootVisual,
                    (float)lottieComposition.Width,
                    (float)lottieComposition.Height,
                    lottieComposition.Duration,
                    Path.Combine(outputFolder, $"{lottieFileNameBase}.cs"));
                _profiler.OnCodeGenFinished();
                break;

            case Lang.Cx:
                codeGenSucceeded = TryGenerateCXCode(
                    className,
                    optimizedWincompDataRootVisual,
                    (float)lottieComposition.Width,
                    (float)lottieComposition.Height,
                    lottieComposition.Duration,
                    Path.Combine(outputFolder, $"{lottieFileNameBase}.h"),
                    Path.Combine(outputFolder, $"{lottieFileNameBase}.cpp"));
                _profiler.OnCodeGenFinished();
                break;

            case Lang.LottieXml:
                codeGenSucceeded = TryGenerateLottieXml(
                    lottieComposition,
                    Path.Combine(outputFolder, $"{lottieFileNameBase}.xml"));
                _profiler.OnSerializationFinished();
                break;

            case Lang.WinCompXml:
                codeGenSucceeded = TryGenerateWincompXml(
                    optimizedWincompDataRootVisual,
                    Path.Combine(outputFolder, $"{lottieFileNameBase}.xml"));
                _profiler.OnSerializationFinished();
                break;

            case Lang.WinCompDgml:
                codeGenSucceeded = TryGenerateWincompDgml(
                    optimizedWincompDataRootVisual,
                    Path.Combine(outputFolder, $"{lottieFileNameBase}.dgml"));
                _profiler.OnSerializationFinished();
                break;

            default:
                WriteError($"Language {_options.Language} is not supported.");
                return false;
        };


        return codeGenSucceeded;
    }

    bool TryGenerateLottieXml(
        LottieComposition lottieComposition,
        string outputFilePath)
    {
        var result = TryWriteTextFile(
            outputFilePath,
            LottieCompositionXmlSerializer.ToXml(lottieComposition).ToString());

        _infoStream.WriteLine($"Lottie XML written to {outputFilePath}");

        return result;
    }

    bool TryGenerateWincompXml(
        Visual rootVisual,
        string outputFilePath)
    {
        var result = TryWriteTextFile(
            outputFilePath,
            CompositionObjectXmlSerializer.ToXml(rootVisual).ToString());

        _infoStream.WriteLine($"WinComp XML written to {outputFilePath}");

        return result;
    }

    bool TryGenerateWincompDgml(
        Visual rootVisual,
        string outputFilePath)
    {
        var result = TryWriteTextFile(
            outputFilePath,
            CompositionObjectDgmlSerializer.ToXml(rootVisual).ToString());

        _infoStream.WriteLine($"WinComp DGML written to {outputFilePath}");

        return result;
    }

    bool TryGenerateCSharpCode(
        string className,
        Visual rootVisual,
        float compositionWidth,
        float compositionHeight,
        TimeSpan duration,
        string outputFilePath)
    {

        var code = CSharpInstantiatorGenerator.CreateFactoryCode(
                    className,
                    rootVisual,
                    compositionWidth,
                    compositionHeight,
                    duration,
                    _options.DisableCodeGenOptimizer);

        if (string.IsNullOrWhiteSpace(code))
        {
            WriteError("Failed to create the C# code.");
            return false;
        }

        if (!TryWriteTextFile(outputFilePath, code))
        {
            WriteError($"Failed to write C# code to {outputFilePath}");
            return false;
        }

        _infoStream.WriteLine($"C# code for class {className} written to {outputFilePath}");
        return true;
    }

    bool TryGenerateCXCode(
        string className,
        Visual rootVisual,
        float compositionWidth,
        float compositionHeight,
        TimeSpan duration,
        string outputHeaderFilePath,
        string outputCppFilePath)
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
                _options.DisableCodeGenOptimizer);

        if (string.IsNullOrWhiteSpace(cppText))
        {
            WriteError("Failed to generate the .cpp code.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(hText))
        {
            WriteError("Failed to generate the .h code.");
            return false;
        }

        if (!TryWriteTextFile(outputHeaderFilePath, hText))
        {
            WriteError($"Failed to write .h code to {outputHeaderFilePath}");
            return false;
        }

        if (!TryWriteTextFile(outputCppFilePath, cppText))
        {
            WriteError($"Failed to write .cpp code to {outputCppFilePath}");
            return false;
        }

        _infoStream.WriteLine($"Header code for class {className} written to {outputHeaderFilePath}");
        _infoStream.WriteLine($"Source code for class {className} written to {outputCppFilePath}");
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

        // True if there is at least one time value.
        internal bool HasAnyResults
            => new[] {
                _parseTime,
                _translateTime,
                _optimizationTime,
                _codegenTime,
                _serializationTime
            }.Any(ts => ts > TimeSpan.Zero);

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


