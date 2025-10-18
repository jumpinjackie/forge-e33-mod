SET ROOT=%CD%

pushd %CD%\tools\CardProcess
dotnet run -- genall --base-directory %ROOT%\custom --output-dir %ROOT%\design
popd

if not exist "%APPDATA%\Forge" mkdir "%APPDATA%\Forge"
if not exist "%APPDATA%\Forge\custom" mkdir "%APPDATA%\Forge\custom"

rd /s /q "%APPDATA%\Forge\custom\cards"
rd /s /q "%APPDATA%\Forge\custom\editions" 
rd /s /q "%APPDATA%\Forge\custom\tokens"

if not exist "%APPDATA%\Forge\custom\cards" mkdir "%APPDATA%\Forge\custom\cards"
if not exist "%APPDATA%\Forge\custom\editions" mkdir "%APPDATA%\Forge\custom\editions"
if not exist "%APPDATA%\Forge\custom\tokens" mkdir "%APPDATA%\Forge\custom\tokens"

xcopy "%CD%\custom\*.*" "%APPDATA%\Forge\custom\" /s /e /y