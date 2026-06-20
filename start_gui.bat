@echo off
echo Starting DiscordChatExporter GUI...
"C:\Program Files\dotnet\dotnet.exe" build DiscordChatExporter.Gui\DiscordChatExporter.Gui.csproj --configuration Release
if %errorlevel% neq 0 (
    echo Build failed.
    pause
    exit /b %errorlevel%
)
"C:\Program Files\dotnet\dotnet.exe" exec "DiscordChatExporter.Gui\bin\Release\net10.0\DiscordChatExporter.dll"
pause
