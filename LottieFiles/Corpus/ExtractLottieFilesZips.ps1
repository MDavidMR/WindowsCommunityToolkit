# Extracts the JSON files out of the lottiefiles.com zip files and gives them names
# matching their download numbers.
#
# NOTE: this will fail on some ZIP files because of naming issues. Most will succeed however.

$lottiefilesDirectory = 'lottiefiles.com'

Add-Type -AssemblyName System.IO.Compression.FileSystem

function Unzip
{
    param([string]$zipfile, [string]$outpath)

    echo $zipFile $outPath

    # NOTE: this will fail with "Illegal characters in path." on some filenames.
    [System.IO.Compression.ZipFile]::ExtractToDirectory($zipFile, $outpath)
}

function ExtractAndRenameJsons
{
    param($zipPath)

    $filename = split-path $zipPath -leaf
    $n = $fileName -replace '(\d+)(.*)','$1'

    mkdir -f $n
    Unzip $zipPath ".\$n"

    # Move all of the JSON files, ignoring the metadata files in the __MACOSX directories.
    $m = 0
    dir -r "$n\*.json" | ?{$_.FullName -notlike '*\__MACOSX\*'} | 
           %{$m++;mv $_.FullName "$lottiefilesDirectory\$n.$m.$($_.name)"}

    rmdir -fo -r $n
}


dir $lottiefilesDirectory\*.zip | %{ExtractAndRenameJsons $_.FullName}



# 0782.check_mark_-_success.zip