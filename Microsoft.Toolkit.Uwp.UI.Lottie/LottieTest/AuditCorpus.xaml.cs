// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using LottieData;
using LottieData.Serialization;
using LottieToWinComp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using WinCompData.CodeGen;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Search;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LottieTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AuditCorpus : Page
    {
        public AuditCorpus()
        {
            this.InitializeComponent();
        }

        int _progressCounter;

        async void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            button.IsEnabled = false;
            await CreateAuditReport();
            button.IsEnabled = true;
        }

        async Task CreateAuditReport()
        {
            _progressCounter = 0;
            _txtProgressCounter.Text = "0";
            _txtProgressTotal.Text = "0";
            StorageFolder folder;
            var folderPicker = new FolderPicker
            {
                ViewMode = PickerViewMode.List,
                SuggestedStartLocation = PickerLocationId.Downloads,
            };

            folderPicker.FileTypeFilter.Add(".json");

            folder = await folderPicker.PickSingleFolderAsync();

            // Get the files. This gets all .json files in the directory and subdirectories.
            var files = (await folder.CreateFileQueryWithOptions(new QueryOptions(CommonFileQuery.OrderByName, new[] { ".json" })).GetFilesAsync()).ToArray();

            // Audit the files.
            var lottieInfos = await AuditFiles(files);

            // Ask the user where to save the result.
            var savePicker = new FileSavePicker
            {
                DefaultFileExtension = ".csv",
                SuggestedStartLocation = PickerLocationId.Desktop,
                SuggestedFileName = "LottieIssues.csv"
            };

            savePicker.FileTypeChoices.Add(new KeyValuePair<string, IList<string>>("CSV file", new[] { ".csv" }));
            var saveFile = await savePicker.PickSaveFileAsync();
            if (saveFile == null)
            {
                return;
            }

            // Write to the CSV.
            await FileIO.WriteLinesAsync(saveFile, ToCsv(lottieInfos));
        }


        IEnumerable<string> ToCsv(IEnumerable<LottieInfo> lottieInfos)
        {
            var allIssues =
                (from lottieInfo in lottieInfos
                 from issue in lottieInfo.AllIssues
                     // Remove any commas - they confuse Excel even inside quotes.
                 select issue.Replace(',', ' ')).Distinct().OrderBy(a => a).ToArray();

            const string separator = ", ";
            // Output the header.
            yield return string.Join(separator, allIssues.Prepend("LottieFile"));

            // Output each row.
            foreach (var lottie in lottieInfos)
            {
                var row = ToCsvRow(allIssues, lottie).ToArray();
                yield return string.Join(separator, row);
            }
        }

        IEnumerable<string> ToCsvRow(string[] allIssues, LottieInfo lottie)
        {
            var issuesSet = new HashSet<string>(lottie.AllIssues);
            yield return $"\"{lottie.FileName}\"";
            foreach (var issue in allIssues)
            {
                yield return issuesSet.Contains(issue) ? "True" : "False";
            }
        }

        async Task<LottieInfo[]> AuditFiles(IEnumerable<StorageFile> files)
        {
            _txtProgressTotal.Text = files.Count().ToString();

            var lottieInfos = new List<LottieInfo>();
            var paths = new List<string>();
            // Parse each file in the corpus.
            foreach (var file in files)
            {
                _progressCounter++;
                _txtProgressCounter.Text = _progressCounter.ToString();
                _txtCurrentFile.Text = file.Name;

                var lottieInfo = new LottieInfo
                {
                    FileName = file.Name
                };

                lottieInfos.Add(lottieInfo);

                var jsonString = await FileIO.ReadTextAsync(file);

                // Parse the Lottie
                var lottieComposition =
                    LottieCompositionJsonReader.ReadLottieCompositionFromJsonString(
                        jsonString,
                        LottieCompositionJsonReader.Options.IgnoreMatchNames,
                        out var readerIssues);

                lottieInfo.ReaderIssues = readerIssues;

                if (lottieComposition == null)
                {
                    // Failed to parse. Go to the next one.
                    continue;
                }

                // Validate the Lottie
                lottieInfo.ValidationIssues = LottieCompositionValidator.Validate(lottieComposition);

                if (lottieInfo.ValidationIssues.Length > 0)
                {
                    // Invalid Lottie. Go to the next one.
                    continue;
                }

                // Translate the Lottie
                var translateSucceeded = LottieToWinCompTranslator.TryTranslateLottieComposition(
                        lottieComposition,
                        false, // strictTranslation
                        true, // annotate
                        true, // add descriptions for codegen commments
                        out var wincompDataRootVisual,
                        out var translationIssues);

                lottieInfo.TranslationIssues = translationIssues;

                // Codegen the Lottie
                var code = CSharpInstantiatorGenerator.CreateFactoryCode(
                    "AuditedComposition", 
                    wincompDataRootVisual, 
                    (float)lottieComposition.Width, 
                    (float)lottieComposition.Height, 
                    wincompDataRootVisual.Properties, 
                    lottieComposition.Duration);

                // Collect the paths that are used in the file.
                paths.AddRange(PathsGenerator.GeneratePaths(wincompDataRootVisual));
            }

            var allPaths = string.Join("\r\n", paths);
            return lottieInfos.ToArray();
        }

        sealed class LottieInfo
        {
            static readonly string[] s_emptyStrings = new string[0];
            internal string FileName { get; set; }
            internal string[] ValidationIssues { get; set; } = s_emptyStrings;
            internal string[] ReaderIssues { get; set; } = s_emptyStrings;
            internal (string Code, string Description)[] TranslationIssues { get; set; } = new (string, string)[0];

            internal string[] AllIssues =>
                ReaderIssues.Concat(TranslationIssues.Select(i => i.Description)).Concat(ValidationIssues).ToArray();
        }
    }
}
