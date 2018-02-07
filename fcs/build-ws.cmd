@echo off

setlocal
cd fcs

if errorlevel 1 (
  endlocal
  exit /b %errorlevel%
)

cd fcs-websharper\codegen
dotnet restore
cd ..\..

.paket\paket.exe restore
if errorlevel 1 (
  endlocal
  exit /b %errorlevel%
)

packages\FAKE\tools\FAKE.exe build-ws.fsx %*
if errorlevel 1 (
  endlocal
  exit /b %errorlevel%
)
endlocal
exit /b 0
