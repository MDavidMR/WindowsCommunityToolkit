REM
REM Builds the nuget package for CompositionPlayer.
REM
REM Must be run from a VS2017 command prompt.
REM
REM Before running, update the version number in the .nuspec file.
REM
REM To push the package, update the version number below, and:
REM  nuget.exe push -Source "CompositionPlayer" -ApiKey VSTS Microsoft_UI_Xaml_Controls_CompositionPlayer.0.1.0.6.nupkg

setlocal
set thisdir=%~dp0

:: Build the binaries.
call :buildBinaries arm
call :buildBinaries x86
call :buildBinaries x64

:: Copy the binaries.
call :copyBinaries ARM\Release arm
call :copyBinaries Release x86
call :copyBinaries x64\Release x64

call :copyWinmd

set nugetexe=%thisdir%..\nuget\nuget.exe 
%nugetexe% pack nuget\Microsoft_UI_Xaml_Controls.nuspec
exit /b 0


:buildBinaries
setlocal
set srcType=%1
cd %thisdir%
msbuild /p:Configuration=Release;Platform=%srcType%
exit /b 0


:copyBinaries
setlocal
cd %thisdir%
set srcDir=%1
set targetType=%2
set binaryExts=dll exp ilk lib pdb pri
set binaryBase=Microsoft_UI_Xaml_Controls
mkdir nuget\runtimes\win10-%targetType% 2> NUL
for %%e in (%binaryExts%) do copy %srcDir%\%binaryBase%\%binaryBase%.%%e %thisdir%nuget\runtimes\win10-%targetType%\native
exit /b 0


:copyWinmd
setlocal
cd %thisdir%
mkdir nuget\lib\uap10.0 2> NUL
copy Release\Microsoft_UI_Xaml_Controls\Microsoft_UI_Xaml_Controls.winmd nuget\lib\uap10.0
exit /b 0
