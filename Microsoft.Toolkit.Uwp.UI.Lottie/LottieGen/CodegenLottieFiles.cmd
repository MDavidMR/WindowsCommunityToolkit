:: Example cmd script for generating code for a folder.
for %%f in (..\lottiefiles\Corpus\lottiefiles.com\*.json) do lottiegen -i %%f -l cs -o temp\Compositions -c %%~nf