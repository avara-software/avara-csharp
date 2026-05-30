using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Exceptions;

namespace Avara.Models;

/// <summary>
/// Filter by expiration status
/// </summary>
[JsonConverter(typeof(InvitationExpiredFilterConverter))]
public enum InvitationExpiredFilter
{
    All,
    Expired,
    NotExpired,
}

sealed class InvitationExpiredFilterConverter : JsonConverter<InvitationExpiredFilter>
{
    public override InvitationExpiredFilter Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "all" => InvitationExpiredFilter.All,
            "expired" => InvitationExpiredFilter.Expired,
            "not-expired" => InvitationExpiredFilter.NotExpired,
            _ => (InvitationExpiredFilter)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvitationExpiredFilter value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvitationExpiredFilter.All => "all",
                InvitationExpiredFilter.Expired => "expired",
                InvitationExpiredFilter.NotExpired => "not-expired",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
