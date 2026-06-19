using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using Cogwheel;
using CommunityToolkit.Mvvm.ComponentModel;
using DiscordChatExporter.Core.Discord;
using DiscordChatExporter.Core.Exporting;
using DiscordChatExporter.Gui.Framework;
using DiscordChatExporter.Gui.Models;

namespace DiscordChatExporter.Gui.Services;

[ObservableObject]
public partial class SettingsService()
    : SettingsBase(
        Path.Combine(AppContext.BaseDirectory, "Settings.dat"),
        SerializerContext.Default
    )
{
    [ObservableProperty]
    public partial bool IsUkraineSupportMessageEnabled { get; set; } = true;

    [ObservableProperty]
    public partial ThemeVariant Theme { get; set; }

    [ObservableProperty]
    public partial bool IsAutoUpdateEnabled { get; set; } = true;

    [ObservableProperty]
    public partial bool IsTokenPersisted { get; set; } = true;

    [ObservableProperty]
    public partial RateLimitPreference RateLimitPreference { get; set; } =
        RateLimitPreference.RespectAll;

    [ObservableProperty]
    public partial ThreadInclusionMode ThreadInclusionMode { get; set; }

    [ObservableProperty]
    public partial string? Locale { get; set; }

    [ObservableProperty]
    public partial bool IsUtcNormalizationEnabled { get; set; }

    [ObservableProperty]
    public partial int ParallelLimit { get; set; } = 1;

    [ObservableProperty]
    public partial string? LastToken { get; set; }

    [ObservableProperty]
    public partial ExportFormat LastExportFormat { get; set; } = ExportFormat.HtmlDark;

    [ObservableProperty]
    public partial string? LastPartitionLimitValue { get; set; }

    [ObservableProperty]
    public partial string? LastMessageFilterValue { get; set; }

    [ObservableProperty]
    public partial bool LastShouldFormatMarkdown { get; set; } = true;

    [ObservableProperty]
    public partial bool LastShouldDownloadAssets { get; set; }

    [ObservableProperty]
    public partial bool LastShouldReuseAssets { get; set; }

    [ObservableProperty]
    public partial string? LastAssetsDirPath { get; set; }

    /// <summary>
    /// Stores the list of favorited channels.
    /// Key: Channel ID (string)
    /// Value: Guild ID (string) - We store the Guild ID to efficiently group fetching by server.
    /// </summary>
    public Dictionary<string, string> FavoriteChannels { get; set; } = [];

    public bool IsChannelFavorited(Snowflake channelId) =>
        FavoriteChannels.ContainsKey(channelId.ToString());

    public void ToggleFavoriteChannel(Snowflake channelId, Snowflake guildId)
    {
        var key = channelId.ToString();
        var value = guildId.ToString();

        if (FavoriteChannels.ContainsKey(key))
            FavoriteChannels.Remove(key);
        else
            FavoriteChannels[key] = value;

        Save();
    }

    public void ToggleFavoriteChannel(Snowflake channelId, Snowflake guildId, bool isFavorited)
    {
        var key = channelId.ToString();
        var value = guildId.ToString();

        if (isFavorited)
            FavoriteChannels[key] = value;
        else
            FavoriteChannels.Remove(key);

        Save();
    }

    public override void Save()
    {
        // Clear the token if it's not supposed to be persisted
        var lastToken = LastToken;
        if (!IsTokenPersisted)
            LastToken = null;

        base.Save();

        LastToken = lastToken;
    }
}

public partial class SettingsService
{
    [JsonSerializable(typeof(SettingsService))]
    [JsonSerializable(typeof(Dictionary<string, string>))]
    private partial class SerializerContext : JsonSerializerContext;
}
