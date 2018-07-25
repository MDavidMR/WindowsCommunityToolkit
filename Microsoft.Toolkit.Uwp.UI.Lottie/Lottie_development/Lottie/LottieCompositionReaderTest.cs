// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using LottieData.Serialization;
using System;
using System.Diagnostics;
using System.IO;
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
                    var contents = await file.OpenReadAsync();
                    var composition = LottieCompositionReader.ReadLottieCompositionFromJsonStream(contents.AsStreamForRead(), LottieCompositionReader.Options.None, out var readerIssues);

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
