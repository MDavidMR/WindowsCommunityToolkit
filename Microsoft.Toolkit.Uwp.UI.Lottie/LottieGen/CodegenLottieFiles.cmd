:: Example cmd script for generating code for a folder.

for /r ..\..\..\..\lottiefiles\Corpus\ %%f in (*.json) do lottiegen -i "%%f" -l cs -o temp\optimizerOn\Compositions -c "%%~nf"

for /r ..\..\..\..\lottiefiles\Corpus\ %%f in (*.json) do lottiegen -_disableOpt -i "%%f" -l cs -o temp\optimizerOff\Compositions -c "%%~nf"



