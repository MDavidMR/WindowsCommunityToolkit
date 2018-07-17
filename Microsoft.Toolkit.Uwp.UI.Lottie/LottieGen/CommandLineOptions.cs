using System;

sealed class CommandLineOptions
{
    string _lottieFile;
    string _language;
    string _className;
    string _outputFolder;

    // The parse error, or null if the parse succeeded.
    internal string ErrorDescription { get; private set; }
    internal string LottieFile => _lottieFile;
    internal string Language => _language;
    internal string ClassName => _className;
    internal string OutputFolder => _outputFolder;
    internal bool StrictMode { get; private set; }
    internal bool HelpRequested { get; private set; }

    enum Keyword
    {
        None,
        Ambiguous,
        Help,
        LottieFile,
        Language,
        ClassName,
        OutputFolder,
        Strict,

    }

    // Returns the parsed command line. If ErrorDescription is non-null, then the parse failed.
    internal static CommandLineOptions ParseCommandLine(string[] args)
    {
        var result = new CommandLineOptions();

        // Define the keywords accepted on the command line.
        var tokenizer = new CommandlineTokenizer<Keyword>(Keyword.Ambiguous)
            .AddPrefixedKeyword("?", Keyword.Help)
            .AddPrefixedKeyword("help", Keyword.Help)
            .AddPrefixedKeyword("lottiefile", Keyword.LottieFile)
            .AddPrefixedKeyword("language", Keyword.Language)
            .AddPrefixedKeyword("classname", Keyword.ClassName)
            .AddPrefixedKeyword("outputfolder", Keyword.OutputFolder)
            .AddPrefixedKeyword("strict", Keyword.Strict);

        // Sentinel to indicate that there is no parameter expected for the current argument.
        string noParameter = "sentinel";
        ref string argParameter = ref noParameter;

        foreach (var (keyword, arg) in tokenizer.Tokenize(args))
        {
            switch (keyword)
            {
                case Keyword.Ambiguous:
                case Keyword.None:
                    if (ReferenceEquals(argParameter, noParameter))
                    {
                        if (keyword == Keyword.Ambiguous)
                        {
                            result.ErrorDescription = $"Ambiguous: {arg}";
                        }
                        else
                        {
                            result.ErrorDescription = $"Unexpected: {arg}";
                        }
                    }
                    else
                    {
                        argParameter = arg;
                        argParameter = ref noParameter;
                    }
                    break;
                case Keyword.Help:
                    result.HelpRequested = true;
                    break;
                case Keyword.LottieFile:
                    argParameter = ref result._lottieFile;
                    break;
                case Keyword.Language:
                    argParameter = ref result._language;
                    break;
                case Keyword.ClassName:
                    argParameter = ref result._className;
                    break;
                case Keyword.OutputFolder:
                    argParameter = ref result._outputFolder;
                    break;
                case Keyword.Strict:
                    result.StrictMode = true;
                    break;
                default:
                    throw new InvalidOperationException();
            }

            if (!ReferenceEquals(argParameter, noParameter) && argParameter != null)
            {
                result.ErrorDescription = $"{arg} specified more than once";
            }

            if (result.ErrorDescription != null || result.HelpRequested)
            {
                // Give up parsing on the first error or if help was requested.
                break;
            }
        }

        return result;
    }
}
