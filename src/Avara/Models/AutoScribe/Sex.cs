using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Exceptions;

namespace Avara.Models.AutoScribe;

/// <summary>
/// Patient's biological sex. Options: 'male', 'female', 'other'
/// </summary>
[JsonConverter(typeof(SexConverter))]
public enum Sex
{
    Male,
    Female,
    Other,
}

sealed class SexConverter : JsonConverter<Sex>
{
    public override Sex Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "male" => Sex.Male,
            "female" => Sex.Female,
            "other" => Sex.Other,
            _ => (Sex)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Sex value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Sex.Male => "male",
                Sex.Female => "female",
                Sex.Other => "other",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
