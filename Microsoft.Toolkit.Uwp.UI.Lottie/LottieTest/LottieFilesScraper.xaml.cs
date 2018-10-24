// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

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
    public sealed partial class LottieFilesScraper : Page
    {
        static readonly Regex s_contentDispositionRegex = new Regex(".*filename=\"(.*)\"");
        static readonly Regex s_downloadNumberRegex = new Regex(".*/(\\d+)");

        public LottieFilesScraper()
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
            for (var i = 1; ; i++)
            {
                if (!await TryHarvestPageAsync(i, true, folder))
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
        async Task<bool> TryHarvestPageAsync(int pageNumber, bool ignoreExistingFiles, StorageFolder destinationFolder)
        {
            string pageUrl = $"http://lottiefiles.com/?page={pageNumber}";
            Debug.WriteLine($"Harvesting page {pageUrl}");

            var htmlWeb = new HtmlWeb();
            var doc = await htmlWeb.LoadFromWebAsync(pageUrl);

            // Get the cards on the page. Each card describes a Lottie.
            var cards =
                from node in doc.DocumentNode.Descendants("div")
                where node.NodeType == HtmlNodeType.Element
                where node.HasClass("card")
                select node;

            if (!cards.Any())
            {
                // Page has no cards.
                return false;
            }

            var cardCount = 0;
            foreach (var card in cards)
            {
                cardCount++;
                GetDetailsFromCard(card, out var title, out var downloadLink, out var jsonLink);

                Debug.WriteLine($"Downloading file at {downloadLink}");

                await TryDownloadFileAsync(destinationFolder, downloadLink, ignoreExistingFiles);
            }
            return cardCount > 0;
        }

        static async Task<bool> TryDownloadFileAsync(StorageFolder destinationFolder, string downloadLink, bool ignoreExistingFiles)
        {
            var request = WebRequest.CreateHttp(downloadLink);
            try
            {
                using (var response = (HttpWebResponse)await request.GetResponseAsync())
                {
                    var filename = GetFilenameFromContentDisposition(response.Headers["Content-Disposition"]);
                    filename = GetTargetFilenameFromUrlAndFilename(downloadLink, filename);

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

        static string GetTargetFilenameFromUrlAndFilename(string url, string filename)
        {
            var match = s_downloadNumberRegex.Match(url);
            var downloadNumber = int.Parse(match.Groups[1].Value);
            return SanitizeFilename($"{downloadNumber.ToString("0000")}.{filename}");
        }

        static string SanitizeFilename(string filename)
        {
            return filename.Replace(":", "_").Replace("/", "_");
        }


        static string GetFilenameFromContentDisposition(string contentDisposition)
        {
            var match = s_contentDispositionRegex.Match(contentDisposition);
            return match.Groups[1].Value;
        }

        static void GetDetailsFromCard(HtmlNode card, out string title, out string downloadLink, out string jsonLink)
        {
            downloadLink =
                (from link in card.Descendants("a")
                 where link.GetAttributeValue("title", "") == "Download Animation"
                 let address = link.GetAttributeValue("href", "")
                 where address != ""
                 select $"http://lottiefiles.com{address}").SingleOrDefault();

            title =
                (from desc in card.Descendants()
                 where desc.HasClass("item-title")
                 select desc.InnerText).SingleOrDefault();

            jsonLink =
                (from desc in card.Descendants()
                 where desc.HasClass("show_preview")
                 let link = desc.GetAttributeValue("data-filename", "")
                 where link != ""
                 select link).SingleOrDefault();

        }
    }
}
