using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Exceptions;

namespace Avara.Models;

/// <summary>
/// Viewport grid layout for an ephemeral hanging protocol. Wire values match first-party
/// viewer layouts ('1x1' through '4x4').
/// </summary>
[JsonConverter(typeof(ViewerLayoutConverter))]
public enum ViewerLayout
{
    V1x1,
    V1x2,
    V1x3,
    V1x4,
    V2x1,
    V2x2,
    V2x3,
    V2x4,
    V3x1,
    V3x2,
    V3x3,
    V3x4,
    V4x1,
    V4x2,
    V4x3,
    V4x4,
}

sealed class ViewerLayoutConverter : JsonConverter<ViewerLayout>
{
    public override ViewerLayout Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "1x1" => ViewerLayout.V1x1,
            "1x2" => ViewerLayout.V1x2,
            "1x3" => ViewerLayout.V1x3,
            "1x4" => ViewerLayout.V1x4,
            "2x1" => ViewerLayout.V2x1,
            "2x2" => ViewerLayout.V2x2,
            "2x3" => ViewerLayout.V2x3,
            "2x4" => ViewerLayout.V2x4,
            "3x1" => ViewerLayout.V3x1,
            "3x2" => ViewerLayout.V3x2,
            "3x3" => ViewerLayout.V3x3,
            "3x4" => ViewerLayout.V3x4,
            "4x1" => ViewerLayout.V4x1,
            "4x2" => ViewerLayout.V4x2,
            "4x3" => ViewerLayout.V4x3,
            "4x4" => ViewerLayout.V4x4,
            _ => (ViewerLayout)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ViewerLayout value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ViewerLayout.V1x1 => "1x1",
                ViewerLayout.V1x2 => "1x2",
                ViewerLayout.V1x3 => "1x3",
                ViewerLayout.V1x4 => "1x4",
                ViewerLayout.V2x1 => "2x1",
                ViewerLayout.V2x2 => "2x2",
                ViewerLayout.V2x3 => "2x3",
                ViewerLayout.V2x4 => "2x4",
                ViewerLayout.V3x1 => "3x1",
                ViewerLayout.V3x2 => "3x2",
                ViewerLayout.V3x3 => "3x3",
                ViewerLayout.V3x4 => "3x4",
                ViewerLayout.V4x1 => "4x1",
                ViewerLayout.V4x2 => "4x2",
                ViewerLayout.V4x3 => "4x3",
                ViewerLayout.V4x4 => "4x4",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
