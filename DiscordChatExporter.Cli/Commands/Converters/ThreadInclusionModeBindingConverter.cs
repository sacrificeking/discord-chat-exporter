using System;
using System.Collections.Generic;
using System.Linq;
using CliFx.Activation;
using DiscordChatExporter.Cli.Commands.Shared;

namespace DiscordChatExporter.Cli.Commands.Converters;

internal class ThreadInclusionModeBindingConverter : InputConverter<ThreadInclusionMode>
{
    public override bool CanConvertSequence => false;

    public override ThreadInclusionMode Convert(IReadOnlyList<string> rawValues)
    {
        var rawValue = rawValues.LastOrDefault();

        // Empty or unset value is treated as 'active' to match the previous behavior
        if (string.IsNullOrWhiteSpace(rawValue))
            return ThreadInclusionMode.Active;

        // Boolean 'true' is treated as 'active', boolean 'false' is treated as 'none'
        if (bool.TryParse(rawValue, out var boolValue))
            return boolValue ? ThreadInclusionMode.Active : ThreadInclusionMode.None;

        // Otherwise, fall back to regular enum parsing
        return Enum.Parse<ThreadInclusionMode>(rawValue, true);
    }
}
