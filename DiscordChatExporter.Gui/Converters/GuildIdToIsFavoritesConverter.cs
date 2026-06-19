using System;
using System.Globalization;
using Avalonia.Data.Converters;
using DiscordChatExporter.Core.Discord;

namespace DiscordChatExporter.Gui.Converters;

/// <summary>
/// Checks if a given Guild ID corresponds to the virtual "Favorites" guild.
/// This is used in the UI to switch between the standard server icon and the special Favorites star icon.
/// </summary>
public class GuildIdToIsFavoritesConverter : IValueConverter
{
    public static GuildIdToIsFavoritesConverter Instance { get; } = new();

    /// <summary>
    /// Converts a Snowflake ID to a boolean indicating if it is the Favorites Guild.
    /// </summary>
    /// <param name="value">The Guild ID (Snowflake) to check.</param>
    /// <param name="targetType">Target type (ignored).</param>
    /// <param name="parameter">Optional boolean. If set to 'False', the result is inverted (returns true if it IS NOT the favorites guild).</param>
    /// <param name="culture">Culture (ignored).</param>
    /// <returns>True if it is the favorites guild (or the inverse if parameter is false).</returns>
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var isFavorites = value is Snowflake snowflake && snowflake.Value == ulong.MaxValue;

        // If parameter is bool and false, we invert the result (Is NOT Favorites)
        if (parameter is bool b && !b)
            return !isFavorites;

        // Also handle string "False" just in case x:False implementation details vary
        if (parameter is string s && bool.TryParse(s, out var sb) && !sb)
            return !isFavorites;

        return isFavorites;
    }

    public object ConvertBack(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    ) => throw new NotSupportedException();
}
