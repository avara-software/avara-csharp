using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Exceptions;

namespace Avara.Models;

/// <summary>
/// Priority level of a study. 'normal' for routine, 'high' for urgent, 'stat' for
/// immediate attention.
/// </summary>
[JsonConverter(typeof(SeverityConverter))]
public enum Severity
{
    Normal,
    High,
    Stat,
}

sealed class SeverityConverter : JsonConverter<Severity>
{
    public override Severity Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "normal" => Severity.Normal,
            "high" => Severity.High,
            "stat" => Severity.Stat,
            _ => (Severity)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Severity value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Severity.Normal => "normal",
                Severity.High => "high",
                Severity.Stat => "stat",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
