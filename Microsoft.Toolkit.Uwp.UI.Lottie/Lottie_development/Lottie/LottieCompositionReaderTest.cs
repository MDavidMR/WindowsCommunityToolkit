using LottieData.Serialization;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Storage;

namespace Lottie
{
    public sealed class LottieCompositionReaderTest
    {
        // Parses all the .json files in the given folder and all subfolders and outputs information about the parse to Debug.
        public IAsyncAction TryParseAll(StorageFolder folder)
        {
            return _TryParseAll(folder).AsAsyncAction();
        }

        async Task _TryParseAll(StorageFolder folder)
        {
            foreach (var file in await folder.GetFilesAsync())
            {
                if (file.Name.EndsWith("json", StringComparison.OrdinalIgnoreCase))
                {
                    var contents = await FileIO.ReadTextAsync(file);
                    string[] readerIssues;
                    var composition = LottieCompositionJsonReader.ReadLottieCompositionFromJsonString(contents, out readerIssues);

                    if (composition != null)
                    {
                        Debug.WriteLine($"{file.Path} = {composition.Name}. {string.Join(", ", readerIssues)}");
                    }
                    else
                    {
                        Debug.WriteLine($"{file.Path} = FAILED. {string.Join(", ", readerIssues)}");
                    }
                }
            }

            foreach (var f in await folder.GetFoldersAsync())
            {
                await TryParseAll(f);
            }
        }
    }

}
