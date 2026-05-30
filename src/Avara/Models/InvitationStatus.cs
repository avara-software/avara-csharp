using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Exceptions;

namespace Avara.Models;

/// <summary>
/// Lifecycle status of an invitation: 'sent', 'accepted', 'rejected', or 'revoked'.
/// </summary>
[JsonConverter(typeof(InvitationStatusConverter))]
public enum InvitationStatus
{
    Sent,
    Accepted,
    Rejected,
    Revoked,
}

sealed class InvitationStatusConverter : JsonConverter<InvitationStatus>
{
    public override InvitationStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sent" => InvitationStatus.Sent,
            "accepted" => InvitationStatus.Accepted,
            "rejected" => InvitationStatus.Rejected,
            "revoked" => InvitationStatus.Revoked,
            _ => (InvitationStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvitationStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvitationStatus.Sent => "sent",
                InvitationStatus.Accepted => "accepted",
                InvitationStatus.Rejected => "rejected",
                InvitationStatus.Revoked => "revoked",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
