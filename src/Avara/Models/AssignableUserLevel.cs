using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Exceptions;

namespace Avara.Models;

/// <summary>
/// User access level assignable via the API. 'admin' can manage users/settings, 'member'
/// has standard access. 'owner' is dashboard-only and cannot be assigned via the API.
/// </summary>
[JsonConverter(typeof(AssignableUserLevelConverter))]
public enum AssignableUserLevel
{
    Admin,
    Member,
}

sealed class AssignableUserLevelConverter : JsonConverter<AssignableUserLevel>
{
    public override AssignableUserLevel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "admin" => AssignableUserLevel.Admin,
            "member" => AssignableUserLevel.Member,
            _ => (AssignableUserLevel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AssignableUserLevel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AssignableUserLevel.Admin => "admin",
                AssignableUserLevel.Member => "member",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
