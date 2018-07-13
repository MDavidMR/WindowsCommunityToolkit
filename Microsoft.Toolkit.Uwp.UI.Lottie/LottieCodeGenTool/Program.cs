using LottieData;
using LottieData.Serialization.Net;
using LottieToWinComp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using WinCompData;
using WinCompData.CodeGen;

static class Program
{
    internal enum ReturnCodes
    {
        Success = 0,
        Failure = 1,
    };

    static int Main(string[] args)
    {
        string inputFolder = string.Empty;
        string inputFile = string.Empty;
        string outputFolder = string.Empty;
        string codeGenClassName = string.Empty;
        string codeGenFileLanguage = string.Empty;
        string outputFileName = string.Empty;
        bool strictTranslation = false;
        bool excludeCodegenDescriptions = false;

        var toolNameAndVersion = "Lottie to Composition Code Generator Version " +
            Assembly.GetEntryAssembly().GetName().Version;
        if (args.Length == 0)
        {
            Console.WriteLine(toolNameAndVersion);
            Console.WriteLine("Use /? or /help to display accepted command line parameters.");
            return (int)ReturnCodes.Failure;
        }

        for (int i = 0; i < args.Length; i++)
        {
            switch (args[i])
            {
                case "/inputFile":
                    if (++i == args.Length)
                    {
                        LogError("final argument missing required value.");
                        return (int)ReturnCodes.Failure;
                    }
                    inputFile = args[i];
                    if (!File.Exists(inputFile))
                    {
                        LogError("Input file was not found.");
                        return (int)ReturnCodes.Failure;
                    }
                    break;
                case "/outputFolder":
                    if (++i == args.Length)
                    {
                        LogError("final argument missing required value.");
                        return (int)ReturnCodes.Failure;
                    }
                    outputFolder = args[i];
                    break;
                case "/className":
                    if (++i == args.Length)
                    {
                        LogError("final argument missing required value.");
                        return (int)ReturnCodes.Failure;
                    }
                    codeGenClassName = args[i];
                    break;
                case "/language":
                    if (++i == args.Length)
                    {
                        LogError("final argument missing required value.");
                        return (int)ReturnCodes.Failure;
                    }
                    codeGenFileLanguage = args[i];
                    if (codeGenFileLanguage != "cs" &&
                        codeGenFileLanguage != "cx")
                    {
                        LogError("Language specified was not valid.");
                        return (int)ReturnCodes.Failure;
                    }
                    break;
                case "/outputFileName":
                    if (++i == args.Length)
                    {
                        LogError("final argument missing required value.");
                        return (int)ReturnCodes.Failure;
                    }
                    outputFileName = args[i];
                    if (outputFileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                    {
                        LogError("Output file name must be a valid file name.");
                        return (int)ReturnCodes.Failure;
                    }
                    break;
                case "/strictTranslation":
                    strictTranslation = true;
                    break;
                case "/excludeCodegenDescriptions":
                    excludeCodegenDescriptions = true;
                    break;
                case "/?":
                case "/help":
                    Console.WriteLine(toolNameAndVersion);
                    Console.WriteLine("/className name of the generated class. If not specified, this will default to the name in the Lottie file if it can be used, otherwise the input file name will be used.");
                    Console.WriteLine("/language language of the generated code file. Options are 'cs' for C# and 'cx' for C++/CX.");
                    Console.WriteLine("/inputFile path to the input .json lottie file.");
                    Console.WriteLine("/outputFileName name of the genered code file(s). This does not include the file extension. If not specified, this will default to the name in the Lottie file if it can be used, otherwise the input file name will be used.");
                    Console.WriteLine("/outputFolder folder where the generated code will be placed.");
                    Console.WriteLine("/strictTranslation fail translation when an issue occurs.");
                    Console.WriteLine("/excludeCodegenDescriptions excludes descriptions to objects for comments on generated code.");
                    Console.WriteLine("The /inputFile, /outputFolder, and /language parameters are required.");
                    break;
                default:
                    LogError("Invalid cmd line argument " + args[i]);
                    return (int)ReturnCodes.Failure;
            }
        }

        // Check for required args
        if (inputFile == string.Empty)
        {
            LogError("Input file must be specified.");
            return (int)ReturnCodes.Failure;
        }

        if (outputFolder == string.Empty)
        {
            LogError("Output folder must be specified.");
            return (int)ReturnCodes.Failure;
        }

        if (codeGenFileLanguage == string.Empty)
        {
            LogError("Extension must be specified.");
            return (int)ReturnCodes.Failure;
        }

        try
        {
            // If output folder does not exist then create it
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }
        }
        catch (Exception ex)
        {
            LogError("An exception occured while trying to create ouput directory: " + outputFolder + ", exception: " + ex.Message);
            return (int)ReturnCodes.Failure;
        }

        if (!TryGenerateCode(
            inputFile,
            outputFolder,
            codeGenClassName,
            codeGenFileLanguage,
            outputFileName,
            strictTranslation,
            excludeCodegenDescriptions,
            out var issue))
        {
            LogError(issue);
            return (int)ReturnCodes.Failure;
        }

        return (int)ReturnCodes.Success;
    }

    static bool TryGenerateCode(
        string file, 
        string outputFolder, 
        string codeGenClassName, 
        string codeGenFileLanguage, 
        string outputFileName, 
        bool strictTranslation, 
        bool excludeCodegenDescriptions,
        out string issue)
    {
        issue = string.Empty;

        var jsonString = File.ReadAllText(file);

        // Parse the Lottie
        var lottieComposition =
            LottieCompositionReader.ReadLottieCompositionFromJsonString(
                jsonString,
                LottieCompositionReader.Options.IgnoreMatchNames,
                out var readerIssues);

        if (lottieComposition == null)
        {
            issue = IssuesToString("Reading Lottie failed", file, readerIssues);
            return false;
        }

        var translateSucceeded = LottieToWinCompTranslator.TryTranslateLottieComposition(
                    lottieComposition,
                    strictTranslation, // strictTranslation
                    !excludeCodegenDescriptions, // add descriptions for codegen commments
                    out var wincompDataRootVisual,
                    out var translationIssues);

        if (!translateSucceeded)
        {
            issue = IssuesToString("Translation of lottie to win comp failed", file, translationIssues);
            return false;
        }

        // The default code gen name used for the file path or class name
        // use the lottie composition name if possible. Otherwise use the input
        // file name.
        var defaultCodeGenName = lottieComposition.Name;
        if (string.IsNullOrEmpty(defaultCodeGenName) ||
            defaultCodeGenName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
        {
            defaultCodeGenName = Path.GetFileNameWithoutExtension(file);
        }

        var className = string.IsNullOrEmpty(codeGenClassName) ? MakeNameSuitableForTypeName(defaultCodeGenName) : codeGenClassName;
        var fileName = string.IsNullOrEmpty(outputFileName) ? defaultCodeGenName : outputFileName;

        switch (codeGenFileLanguage)
        {
            case "cs":
                if (!TryGenerateCSharpCode(
                    className,
                    wincompDataRootVisual,
                    (float)lottieComposition.Width,
                    (float)lottieComposition.Height,
                    lottieComposition.Duration,
                    Path.Combine(outputFolder, fileName + ".cs"),
                    out var csCodeGenIssue))
                {
                    issue = csCodeGenIssue;
                    return false;
                }
                break;
            case "cx":
                if (!TryGenerateCXCode(
                    className,
                    wincompDataRootVisual,
                    (float)lottieComposition.Width,
                    (float)lottieComposition.Height,
                    lottieComposition.Duration,
                    Path.Combine(outputFolder, fileName + ".h"),
                    Path.Combine(outputFolder, fileName + ".cpp"),
                    out var cxCodeGenIssue))
                {
                    issue = cxCodeGenIssue;
                    return false;
                }
                break;
            default:
                issue = "Unsupported code generation file extension specified.";
                return false;
        };

        return true;
    }

    static bool TryGenerateCSharpCode(
        string className, 
        Visual rootVisual, 
        float compositionWidth, 
        float compositionHeight, 
        TimeSpan duration, 
        string outputFilePath,
        out string issue)
    {
        issue = string.Empty;

        var code = CSharpInstantiatorGenerator.CreateFactoryCode(
                    className,
                    rootVisual,
                    compositionWidth,
                    compositionHeight,
                    duration);

        if (string.IsNullOrEmpty(code))
        {
            issue = "Failed to create the cs code.";
            return false;
        }

        try
        {
            using (StreamWriter outputFile = new StreamWriter(outputFilePath))
            {
                outputFile.Write(code);
            }
        }
        catch (Exception ex)
        {
            issue = "Exception occured attempting to write the code file. Exception message: " + ex.Message;
            return false;
        }

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
        out string issue)
    {
        issue = string.Empty;

        WinCompData.CodeGen.CxInstantiatorGenerator.CreateFactoryCode(
                className,
                rootVisual,
                compositionWidth,
                compositionHeight,
                duration,
                className,
                out var cppText,
                out var hText);

        if (string.IsNullOrEmpty(cppText))
        {
            issue = "Failed to create the cpp code.";
            return false;
        }

        if (string.IsNullOrEmpty(hText))
        {
            issue = "Failed to create the header code.";
            return false;
        }

        try
        {
            using (StreamWriter outputFile = new StreamWriter(outputHeaderFilePath))
            {
                outputFile.Write(hText);
            }
        }
        catch(Exception ex)
        {
            issue = "Exception occured attempting to write the header file. Exception message: " + ex.Message;
            return false;
        }

        try
        {
            using (StreamWriter outputFile = new StreamWriter(outputCppFilePath))
            {
                outputFile.Write(cppText);
            }
        }
        catch (Exception ex)
        {
            issue = "Exception occured attempting to write the cpp file. Exception message: " + ex.Message;
            return false;
        }       

        return true;
    }

    static string MakeNameSuitableForTypeName(string name)
    {
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

    static string IssuesToString(string description, string issueFilePath, (string Code, string Description)[] issues)
    {
        string logString = issueFilePath + ", " + description;
        foreach (var (Code, Description) in issues)
        {
            logString += ", " + Code + " : " + Description;
        }
        return logString;
    }

    static void LogError(string errorMessage)
    {
        Console.WriteLine("Error: " + errorMessage);
    }
}
