using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Exceptions;

namespace Avara.Models;

/// <summary>
/// User access level. 'owner' has full control (dashboard-only, not assignable via
/// API), 'admin' can manage users/settings, 'member' has standard access.
/// </summary>
[JsonConverter(typeof(UserLevelConverter))]
public enum UserLevel
{
    Owner,
    Admin,
    Member,
}

sealed class UserLevelConverter : JsonConverter<UserLevel>
{
    public override UserLevel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "owner" => UserLevel.Owner,
            "admin" => UserLevel.Admin,
            "member" => UserLevel.Member,
            _ => (UserLevel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserLevel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserLevel.Owner => "owner",
                UserLevel.Admin => "admin",
                UserLevel.Member => "member",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
