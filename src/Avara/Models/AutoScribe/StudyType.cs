using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Exceptions;

namespace Avara.Models.AutoScribe;

/// <summary>
/// Kind of study. 'standard' is a live AutoScribe reading-workflow study. 'external'
/// is an imported archive study.
/// </summary>
[JsonConverter(typeof(StudyTypeConverter))]
public enum StudyType
{
    Standard,
    External,
}

sealed class StudyTypeConverter : JsonConverter<StudyType>
{
    public override StudyType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "standard" => StudyType.Standard,
            "external" => StudyType.External,
            _ => (StudyType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StudyType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StudyType.Standard => "standard",
                StudyType.External => "external",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
