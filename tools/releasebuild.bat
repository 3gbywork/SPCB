@echo off

set slnPath=..\SPBrowser.sln
set msbuildParam=/m /p:Configuration=Release "/p:Platform=Any CPU" /t:Rebuild /nologo

".\nuget.exe" restore "%slnPath%"

"D:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe" %slnPath% %msbuildParam%
REM "%windir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe" %slnPath% %msbuildParam%
@IF %ERRORLEVEL% NEQ 0 GOTO err
@Exit /B 0
:err
@PAUSE
@Exit /B 1