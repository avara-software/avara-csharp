using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Exceptions;

namespace Avara.Models.AutoScribe;

/// <summary>
/// Unit of measure for a height value. 'in' = inches, 'cm' = centimeters.
/// </summary>
[JsonConverter(typeof(HeightUnitConverter))]
public enum HeightUnit
{
    In,
    Cm,
}

sealed class HeightUnitConverter : JsonConverter<HeightUnit>
{
    public override HeightUnit Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "in" => HeightUnit.In,
            "cm" => HeightUnit.Cm,
            _ => (HeightUnit)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        HeightUnit value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                HeightUnit.In => "in",
                HeightUnit.Cm => "cm",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
