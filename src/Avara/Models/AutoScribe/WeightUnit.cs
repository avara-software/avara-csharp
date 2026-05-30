using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Exceptions;

namespace Avara.Models.AutoScribe;

/// <summary>
/// Unit of measure for a weight value. 'lbs' = pounds, 'kg' = kilograms.
/// </summary>
[JsonConverter(typeof(WeightUnitConverter))]
public enum WeightUnit
{
    Lbs,
    Kg,
}

sealed class WeightUnitConverter : JsonConverter<WeightUnit>
{
    public override WeightUnit Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "lbs" => WeightUnit.Lbs,
            "kg" => WeightUnit.Kg,
            _ => (WeightUnit)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WeightUnit value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WeightUnit.Lbs => "lbs",
                WeightUnit.Kg => "kg",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
