@echo off
SETLOCAL ENABLEEXTENSIONS

SET ROOT=%CD%

where dotnet >nul 2>nul
if errorlevel 1 (
	echo Error: dotnet SDK not found in PATH. Install .NET SDK 10.0 or higher.
	exit /b 1
)

set "DOTNET_VERSION="
for /f "usebackq delims=" %%v in (`dotnet --version 2^>nul`) do set "DOTNET_VERSION=%%v"
if not defined DOTNET_VERSION (
	echo Error: Unable to determine dotnet SDK version. Expected .NET SDK 10.0 or higher.
	exit /b 1
)

for /f "tokens=1 delims=." %%m in ("%DOTNET_VERSION%") do set "DOTNET_MAJOR=%%m"
2>nul set /a DOTNET_MAJOR_NUM=%DOTNET_MAJOR%
if errorlevel 1 (
	echo Error: Unable to parse dotnet major version from "%DOTNET_VERSION%". Expected .NET SDK 10.0 or higher.
	exit /b 1
)
if %DOTNET_MAJOR_NUM% LSS 10 (
	echo Error: .NET SDK 10.0 or higher is required for "dotnet run --file". Found: %DOTNET_VERSION%
	exit /b 1
)

dotnet run --file %ROOT%\card_process.cs -- genall --base-directory %ROOT%\custom --output-dir %ROOT%\design

if not exist "%APPDATA%\Forge" mkdir "%APPDATA%\Forge"
if not exist "%APPDATA%\Forge\custom" mkdir "%APPDATA%\Forge\custom"

rd /s /q "%APPDATA%\Forge\custom\cards"
rd /s /q "%APPDATA%\Forge\custom\editions" 
rd /s /q "%APPDATA%\Forge\custom\tokens"

if not exist "%APPDATA%\Forge\custom\cards" mkdir "%APPDATA%\Forge\custom\cards"
if not exist "%APPDATA%\Forge\custom\editions" mkdir "%APPDATA%\Forge\custom\editions"
if not exist "%APPDATA%\Forge\custom\tokens" mkdir "%APPDATA%\Forge\custom\tokens"

xcopy "%CD%\custom\*.*" "%APPDATA%\Forge\custom\" /s /e /y