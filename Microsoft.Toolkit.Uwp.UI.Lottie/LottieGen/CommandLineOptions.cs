using System;

internal enum Lang
{
    // Language wasn't recognized.
    Unknown,
    // Language specified was ambigious.
    Ambiguous,
    // Language wasn't specified.
    Unspecified,

    CSharp,
    Cx,
    WinrtCpp,
    LottieXml,
    WinCompXml,
}

sealed class CommandLineOptions
{
    string _inputFile;
    string _className;
    string _outputFolder;
    string _language;

    // The parse error, or null if the parse succeeded.
    internal string ErrorDescription { get; private set; }
    internal string InputFile => _inputFile;
    internal Lang Language { get; private set; } = Lang.Unspecified;
    internal string ClassName => _className;
    internal string OutputFolder => _outputFolder;
    internal bool StrictMode { get; private set; }
    internal bool HelpRequested { get; private set; }

    enum Keyword
    {
        None,
        Ambiguous,
        Help,
        InputFile,
        Language,
        ClassName,
        OutputFolder,
        Strict,
    }

    // Returns the parsed command line. If ErrorDescription is non-null, then the parse failed.
    internal static CommandLineOptions ParseCommandLine(string[] args)
    {
        var result = new CommandLineOptions();
        result.ParseCommandLineStrings(args);

        // Convert the language string to a language value.
        if (result._language != null)
        {
            // Parse the language string.
            var languageTokenizer = new CommandlineTokenizer<Lang>(Lang.Ambiguous)
                    .AddKeyword("csharp", Lang.CSharp)
                    .AddKeyword("cppcx", Lang.Cx)
                    .AddKeyword("cx", Lang.Cx)
                    .AddKeyword("winrtcpp", Lang.WinrtCpp)
                    .AddKeyword("lottiexml", Lang.LottieXml)
                    .AddKeyword("wincompxml", Lang.WinCompXml);

            languageTokenizer.TryMatchKeyword(result._language, out var language);
            result.Language = language;
            switch (language)
            {
                case Lang.Unknown:
                    result.ErrorDescription = $"Unrecognized language: {result._language}";
                    break;
                case Lang.Ambiguous:
                    result.ErrorDescription = $"Ambiguous language: {result._language}";
                    break;
            }
        }

        return result;
    }

    void ParseCommandLineStrings(string[] args)
    {
        // Define the keywords accepted on the command line.
        var tokenizer = new CommandlineTokenizer<Keyword>(Keyword.Ambiguous)
            .AddPrefixedKeyword("?", Keyword.Help)
            .AddPrefixedKeyword("help", Keyword.Help)
            .AddPrefixedKeyword("inputfile", Keyword.InputFile)
            .AddPrefixedKeyword("language", Keyword.Language)
            .AddPrefixedKeyword("classname", Keyword.ClassName)
            .AddPrefixedKeyword("outputfolder", Keyword.OutputFolder)
            .AddPrefixedKeyword("strict", Keyword.Strict);

        // Sentinel to indicate that there is no parameter expected for the current argument.
        string noParameterSentinel = "noParameterSentinel";
        ref string argParameter = ref noParameterSentinel;

        foreach (var (keyword, arg) in tokenizer.Tokenize(args))
        {
            switch (keyword)
            {
                case Keyword.Ambiguous:
                case Keyword.None:
                    if (ReferenceEquals(argParameter, noParameterSentinel))
                    {
                        if (keyword == Keyword.Ambiguous)
                        {
                            ErrorDescription = $"Ambiguous: {arg}";
                            return;
                        }
                        else
                        {
                            ErrorDescription = $"Unexpected: {arg}";
                            return;
                        }
                    }
                    else
                    {
                        // Save the parameter
                        argParameter = arg;
                        // Clear the parameter.
                        argParameter = ref noParameterSentinel;
                    }
                    break;
                case Keyword.Help:
                    HelpRequested = true;
                    return;
                case Keyword.InputFile:
                    argParameter = ref _inputFile;
                    break;
                case Keyword.Language:
                    argParameter = ref _language;
                    break;
                case Keyword.ClassName:
                    argParameter = ref _className;
                    break;
                case Keyword.OutputFolder:
                    argParameter = ref _outputFolder;
                    break;
                case Keyword.Strict:
                    StrictMode = true;
                    break;
                default:
                    // Should never get here.
                    throw new InvalidOperationException();
            }

            if (!ReferenceEquals(argParameter, noParameterSentinel) &&
                argParameter != null)
            {
                ErrorDescription = $"{arg} specified more than once";
                return;
            }
        }

        if (!ReferenceEquals(argParameter, noParameterSentinel))
        {
            ErrorDescription = "Missing value";
        }
    }
}

