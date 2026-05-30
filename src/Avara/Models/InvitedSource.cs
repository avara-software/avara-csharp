using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Exceptions;

namespace Avara.Models;

/// <summary>
/// How a user/invitation was created - via the dashboard UI ('dashboard') or the
/// API ('api').
/// </summary>
[JsonConverter(typeof(InvitedSourceConverter))]
public enum InvitedSource
{
    Dashboard,
    Api,
}

sealed class InvitedSourceConverter : JsonConverter<InvitedSource>
{
    public override InvitedSource Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dashboard" => InvitedSource.Dashboard,
            "api" => InvitedSource.Api,
            _ => (InvitedSource)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvitedSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvitedSource.Dashboard => "dashboard",
                InvitedSource.Api => "api",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
