using LottieData.Serialization;
using LottieToWinComp;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using WinCompData;
using WinCompData.CodeGen;

static class Program
{
    static readonly Assembly s_thisAssembly = Assembly.GetExecutingAssembly();

    enum ReturnCode
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
            case ReturnCode.Success:
                return 0;

            case ReturnCode.Failure:
                return 1;

            case ReturnCode.InvalidUsage:
                errorStream.WriteLine();
                ShowUsage(errorStream);
                return 1;

            default:
                // Should never get here.
                throw new InvalidOperationException();
        }
    }

    static ReturnCode Run(CommandLineOptions options, TextWriter infoStream, TextWriter errorStream)
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
            return ReturnCode.InvalidUsage;
        }
        else if (options.HelpRequested)
        {
            ShowHelp(infoStream);
            return ReturnCode.Success;
        }

        // Check for required args
        if (options.InputFile == null)
        {
            WriteError("Lottie file not specified.");
            return ReturnCode.InvalidUsage;
        }

        switch (options.Language)
        {
            case Lang.Unknown:
                WriteError("Invalid language.");
                return ReturnCode.InvalidUsage;
            case Lang.Unspecified:
                WriteError("Language not specified.");
                return ReturnCode.InvalidUsage;
        }

        return TryGenerateCode(
                    options.InputFile,
                    options.OutputFolder ?? ".",    // Default to current directory
                    options.ClassName,
                    options.Language,
                    options.StrictMode,
                    infoStream,
                    errorStream)
                ? ReturnCode.Success
                : ReturnCode.Failure;

        // Helper for writing errors to the error stream.
        void WriteError(string errorMessage)
        {
            errorStream.WriteLine($"Error: {errorMessage}");
        }
    }

    static bool TryGenerateCode(
        string lottieJsonFile,
        string outputFolder,
        string codeGenClassName,
        Lang language,
        bool strictTranslation,
        TextWriter infoStream,
        TextWriter errorStream)
    {
        if (!TryEnsureDirectoryExists(outputFolder))
        {
            errorStream.WriteLine($"Failed to create the output directory: {outputFolder}");
            return false;
        }

        // Read the Lottie .json text.
        var jsonString = TryReadTextFile(lottieJsonFile);

        if (jsonString == null)
        {
            errorStream.WriteLine($"Failed to read Lottie file: {lottieJsonFile}");
            return false;
        }

        // Parse the Lottie.
        var lottieComposition =
            LottieCompositionReader.ReadLottieCompositionFromJsonString(
                jsonString,
                LottieCompositionReader.Options.IgnoreMatchNames,
                out var readerIssues);

        foreach (var issue in readerIssues)
        {
            infoStream.WriteLine(IssueToString(lottieJsonFile, issue));
        }

        if (lottieComposition == null)
        {
            errorStream.WriteLine($"Failed to parse Lottie file: {lottieJsonFile}.");
            return false;
        }

        var translateSucceeded = LottieToWinCompTranslator.TryTranslateLottieComposition(
                    lottieComposition,
                    strictTranslation, // strictTranslation
                    true, // TODO - make this configurable?  !excludeCodegenDescriptions, // add descriptions for codegen commments
                    out var wincompDataRootVisual,
                    out var translationIssues);

        foreach (var issue in translationIssues)
        {
            infoStream.WriteLine(IssueToString(lottieJsonFile, issue));
        }

        if (!translateSucceeded)
        {
            errorStream.WriteLine("Failed to read translate Lottie file.");
            return false;
        }

        // Get an appropriate name for the class.
        string className = SanitizeTypeName(codeGenClassName);
        if (string.IsNullOrWhiteSpace(className))
        {
            // No name was specified. Infer it from the Lottie name.
            className = SanitizeTypeName(lottieComposition.Name);
            if (string.IsNullOrWhiteSpace(className))
            {
                // The Lottie has no name. Use the Lottie file name.
                className = SanitizeTypeName(Path.GetFileNameWithoutExtension(lottieJsonFile));
            }
        }

        bool codeGenSucceeded = false;
        switch (language)
        {
            case Lang.CSharp:
                translateSucceeded = TryGenerateCSharpCode(
                    className,
                    wincompDataRootVisual,
                    (float)lottieComposition.Width,
                    (float)lottieComposition.Height,
                    lottieComposition.Duration,
                    Path.Combine(outputFolder, $"{className}.cs"),
                    infoStream, 
                    errorStream);
                break;

            case Lang.Cx:
                translateSucceeded = TryGenerateCXCode(
                    className,
                    wincompDataRootVisual,
                    (float)lottieComposition.Width,
                    (float)lottieComposition.Height,
                    lottieComposition.Duration,
                    Path.Combine(outputFolder, $"{className}.h"),
                    Path.Combine(outputFolder, $"{className}.cpp"),
                    infoStream,
                    errorStream);
                break;

            default:
                errorStream.WriteLine($"Language {language} is not supported.");
                return false;
        };

        return codeGenSucceeded;
    }

    static bool TryGenerateCSharpCode(
        string className,
        Visual rootVisual,
        float compositionWidth,
        float compositionHeight,
        TimeSpan duration,
        string outputFilePath,
        TextWriter infoStream,
        TextWriter errorStream)
    {

        var code = CSharpInstantiatorGenerator.CreateFactoryCode(
                    className,
                    rootVisual,
                    compositionWidth,
                    compositionHeight,
                    duration);

        if (string.IsNullOrWhiteSpace(code))
        {
            errorStream.WriteLine("Failed to create the C# code.");
            return false;
        }

        if (!TryWriteTextFile(outputFilePath, code))
        {
            errorStream.WriteLine($"Failed to write C# code to {outputFilePath}.");
            return false;
        }

        infoStream.WriteLine($"C# code written to {outputFilePath}.");
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
        TextWriter infoStream,
        TextWriter errorStream)
    {
        CxInstantiatorGenerator.CreateFactoryCode(
                className,
                rootVisual,
                compositionWidth,
                compositionHeight,
                duration,
                className,
                out var cppText,
                out var hText);

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
            errorStream.WriteLine($"Failed to write .h code to {outputHeaderFilePath}.");
            return false;
        }

        if (!TryWriteTextFile(outputCppFilePath, cppText))
        {
            errorStream.WriteLine($"Failed to write .cpp code to {outputCppFilePath}.");
            return false;
        }

        infoStream.WriteLine($"Header code written to {outputHeaderFilePath}.");
        infoStream.WriteLine($"Source code written to {outputCppFilePath}.");
        return true;
    }

    // Makes the given name suitable for use as a class name in C# or C++.
    static string SanitizeTypeName(string name)
    {
        if (name == null)
        {
            return null;
        }

        // If the first character is not a letter, prepend an underscore.
        if (!char.IsLetter(name, 0))
        {
            name = "_" + name;
        }

        // Replace any disallowed character with underscores.
        name =
            new string((from ch in name
                        select char.IsLetterOrDigit(ch) ? ch : '_').ToArray());

        // Remove any duplicated underscores.
        name = name.Replace("__", "_");

        // Capitalize the first letter.
        name = name.ToUpperInvariant().Substring(0, 1) + name.Substring(1);

        return name;
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

    static string TryReadTextFile(string filePath)
    {
        try
        {
            return File.ReadAllText(filePath);
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
       LOTTIEFILE is a Lottie .json file.
       LANG is one of cs, cppcx, or winrtcpp.

       [Other options]

         -Help         Print this help message and exit.
         -ClassName    Uses the given class name for the generated code. If not 
                       specified the name is synthesized from the name in the Lottie 
                       if such a name exists or else the name of the Lottie file.
                       The class name will be sanitized as necessary to be valid for
                       the language and will also be used as the base name of the output 
                       file(s).
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
}
