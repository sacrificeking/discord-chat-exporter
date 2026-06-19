using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Onova;
using Onova.Services;

namespace DiscordChatExporter.Gui.Services;

[SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
public class UpdateService : IDisposable
{
    private readonly SettingsService _settingsService;
    private readonly IUpdateManager _updateManager;

    public UpdateService(SettingsService settingsService)
    {
        _settingsService = settingsService;

        _updateManager = new UpdateManager(
            new GithubPackageResolver(
                "sacrificeking",
                "DiscordChatExporter",
                "DiscordChatExporter.zip"
            ),
            new ZipPackageExtractor()
        );
    }

    public async Task<Version?> CheckForUpdatesAsync()
    {
        try
        {
            if (!_settingsService.IsAutoUpdateEnabled)
                return null;

            var result = await _updateManager.CheckForUpdatesAsync();
            return result.CanUpdate ? result.LastVersion : null;
        }
        catch (Exception)
        {
            // Ignore errors
            return null;
        }
    }

    public async Task PrepareUpdateAsync(Version version)
    {
        try
        {
            await _updateManager.PrepareUpdateAsync(version);
        }
        catch (Exception)
        {
            // Ignore errors
        }
    }

    public void FinalizeUpdate(bool needRestart)
    {
        try
        {
            _updateManager.LaunchUpdater(version: new Version(0, 0, 0), needRestart);
        }
        catch (Exception)
        {
            // Ignore errors
        }
    }

    public void Dispose() => _updateManager.Dispose();
}
