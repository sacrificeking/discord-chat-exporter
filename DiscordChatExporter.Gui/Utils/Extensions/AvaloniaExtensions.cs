using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.VisualTree;

namespace DiscordChatExporter.Gui.Utils.Extensions;

internal static class AvaloniaExtensions
{
    public static Window? TryGetMainWindow(this IApplicationLifetime lifetime) =>
        lifetime is IClassicDesktopStyleApplicationLifetime desktopLifetime
            ? desktopLifetime.MainWindow
            : null;

    public static TopLevel? TryGetTopLevel(this IApplicationLifetime lifetime) =>
        lifetime.TryGetMainWindow()
        ?? (
            lifetime is ISingleViewApplicationLifetime singleView && singleView.MainView is not null
                ? TopLevel.GetTopLevel(singleView.MainView)
                : null
        );

    public static bool TryShutdown(this IApplicationLifetime lifetime, int exitCode = 0)
    {
        if (lifetime is IClassicDesktopStyleApplicationLifetime desktopLifetime)
        {
            return desktopLifetime.TryShutdown(exitCode);
        }

        if (lifetime is IControlledApplicationLifetime controlledLifetime)
        {
            controlledLifetime.Shutdown(exitCode);
            return true;
        }

        return false;
    }
}
