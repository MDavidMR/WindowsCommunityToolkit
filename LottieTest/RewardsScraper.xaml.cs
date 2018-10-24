using HtmlAgilityPack;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace LottieTest
{
    public sealed partial class RewardsScraper : Page
    {
        static readonly Regex s_contentDispositionRegex = new Regex(".*filename=\"(.*)\"");
        static readonly Regex s_downloadNumberRegex = new Regex(".*/(\\d+)");

        public RewardsScraper()
        {
            this.InitializeComponent();
        }


        async void Button_Click(object sender, RoutedEventArgs e)
        {
            _btnStartScraping.IsEnabled = false;
            try
            {
                await StartHarvestingPages();
            }
            finally
            {
                _btnStartScraping.IsEnabled = true;
            }
        }

        int _harvestPagesVersion;

        async Task StartHarvestingPages()
        {
            var version = ++_harvestPagesVersion;

            // Choose the folder to save to.
            var folderPicker = new FolderPicker
            {
                ViewMode = PickerViewMode.List,
                SuggestedStartLocation = PickerLocationId.Downloads,
            };
            folderPicker.FileTypeFilter.Add(".json");

            var folder = await folderPicker.PickSingleFolderAsync();

            // Start scraping.
            foreach (var pageUrl in new[] {
                // Daily offers
                "http://rewards2017dailyoffer.azurewebsites.net/index.html",
                // Promo banners
                "http://rewards2017dailyoffer.azurewebsites.net/z_banners.html",
                // First run experience
                "http://rewards2017dailyoffer.azurewebsites.net/z_fre.html",
                // Point transfers and streaks
                "http://rewards2017dailyoffer.azurewebsites.net/z_points_streak.html"})
            {
                if (!await TryHarvestPageAsync(pageUrl, true, folder))
                {
                    // Page had no cards on it. Give up.
                    break;
                }

                if (version != _harvestPagesVersion)
                {
                    // Another call replaced this one.
                    Debug.WriteLine("Canceling call to StartHarvestingPages()");
                    break;
                }
            }
        }

        // Returns true if any files were harvested.
        async Task<bool> TryHarvestPageAsync(string pageUrl, bool ignoreExistingFiles, StorageFolder destinationFolder)
        {
            Debug.WriteLine($"Harvesting page {pageUrl}");

            var htmlWeb = new HtmlWeb();
            var doc = await htmlWeb.LoadFromWebAsync(pageUrl);

            // Get json filename for each Lottie on the page.
            var filenames =
                from node in doc.DocumentNode.Descendants("div")
                where node.NodeType == HtmlNodeType.Element
                where node.HasClass("bodymovin")
                let filename= node.GetAttributeValue("data-file", null)
                where filename != null
                select filename;

            if (!filenames.Any())
            {
                // Page has no Lotties.
                return false;
            }

            int counter = 0;
            foreach (var filename in filenames)
            {
                counter++;
                var downloadLink = $"http://rewards2017dailyoffer.azurewebsites.net/animation/{filename}";

                Debug.WriteLine($"Downloading file at {downloadLink}");

                await TryDownloadFileAsync(destinationFolder, downloadLink, filename, ignoreExistingFiles);
            }
            return counter> 0;
        }

        static async Task<bool> TryDownloadFileAsync(StorageFolder destinationFolder, string downloadLink, string filename, bool ignoreExistingFiles)
        {
            var request = WebRequest.CreateHttp(downloadLink);
            try
            {
                using (var response = (HttpWebResponse)await request.GetResponseAsync())
                {
                    Debug.WriteLine($"{downloadLink} {filename}");

                    if (ignoreExistingFiles)
                    {
                        var existingFile = await destinationFolder.TryGetItemAsync(filename);
                        if (existingFile != null)
                        {
                            var properties = await existingFile.GetBasicPropertiesAsync();
                            if (properties.Size > 0)
                            {
                                Debug.WriteLine($"Ignoring existing file: {filename}");
                                return false;
                            }
                        }
                    }

                    // Download.
                    var file = await destinationFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);

                    // TODO - figure out how to set the timestamps so they match what's on the server.
                    using (var writeStream = await file.OpenStreamForWriteAsync())
                    using (var contentStream = response.GetResponseStream())
                    {
                        await contentStream.CopyToAsync(writeStream);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Downloading failed: {e}");
                return false;
            }

        }

    }
}
