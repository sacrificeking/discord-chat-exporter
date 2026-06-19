using System.Collections.Generic;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DiscordChatExporter.Core.Discord;
using DiscordChatExporter.Core.Discord.Data;
using DiscordChatExporter.Gui.Services;

namespace DiscordChatExporter.Gui.ViewModels.Components;

public partial class ChannelViewModel : ObservableObject
{
    private readonly SettingsService _settingsService;

    public Channel Channel { get; }
    public IReadOnlyList<ChannelViewModel> Children { get; }

    /// <summary>
    /// Represents a channel in the UI.
    /// Wraps the core text channel data and adds UI-specific state like whether it is selected or favorited.
    /// </summary>
    public ChannelViewModel(
        Channel channel,
        IReadOnlyList<ChannelViewModel> children,
        SettingsService settingsService
    )
    {
        Channel = channel;
        Children = children;
        _settingsService = settingsService;
    }

    /// <summary>
    /// Gets or sets whether this channel is marked as a favorite.
    /// Changes are automatically saved to the persistent settings.
    /// </summary>
    public bool IsFavorite
    {
        get => _settingsService.IsChannelFavorited(Channel.Id);
        set
        {
            _settingsService.ToggleFavoriteChannel(Channel.Id, Channel.GuildId, value);
            OnPropertyChanged();
        }
    }

    [RelayCommand]
    private void ToggleFavorite()
    {
        IsFavorite = !IsFavorite;
    }
}
