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
    OneByOne,
    OneByTwo,
    OneByThree,
    OneByFour,
    TwoByOne,
    TwoByTwo,
    TwoByThree,
    TwoByFour,
    ThreeByOne,
    ThreeByTwo,
    ThreeByThree,
    ThreeByFour,
    FourByOne,
    FourByTwo,
    FourByThree,
    FourByFour,
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
            "1x1" => ViewerLayout.OneByOne,
            "1x2" => ViewerLayout.OneByTwo,
            "1x3" => ViewerLayout.OneByThree,
            "1x4" => ViewerLayout.OneByFour,
            "2x1" => ViewerLayout.TwoByOne,
            "2x2" => ViewerLayout.TwoByTwo,
            "2x3" => ViewerLayout.TwoByThree,
            "2x4" => ViewerLayout.TwoByFour,
            "3x1" => ViewerLayout.ThreeByOne,
            "3x2" => ViewerLayout.ThreeByTwo,
            "3x3" => ViewerLayout.ThreeByThree,
            "3x4" => ViewerLayout.ThreeByFour,
            "4x1" => ViewerLayout.FourByOne,
            "4x2" => ViewerLayout.FourByTwo,
            "4x3" => ViewerLayout.FourByThree,
            "4x4" => ViewerLayout.FourByFour,
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
                ViewerLayout.OneByOne => "1x1",
                ViewerLayout.OneByTwo => "1x2",
                ViewerLayout.OneByThree => "1x3",
                ViewerLayout.OneByFour => "1x4",
                ViewerLayout.TwoByOne => "2x1",
                ViewerLayout.TwoByTwo => "2x2",
                ViewerLayout.TwoByThree => "2x3",
                ViewerLayout.TwoByFour => "2x4",
                ViewerLayout.ThreeByOne => "3x1",
                ViewerLayout.ThreeByTwo => "3x2",
                ViewerLayout.ThreeByThree => "3x3",
                ViewerLayout.ThreeByFour => "3x4",
                ViewerLayout.FourByOne => "4x1",
                ViewerLayout.FourByTwo => "4x2",
                ViewerLayout.FourByThree => "4x3",
                ViewerLayout.FourByFour => "4x4",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
