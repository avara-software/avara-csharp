using System.Text.Json;
using Avara.Core;
using Avara.Exceptions;
using Avara.Models;

namespace Avara.Tests.Models;

public class ViewerLayoutTest : TestBase
{
    [Theory]
    [InlineData(ViewerLayout.V1x1)]
    [InlineData(ViewerLayout.V1x2)]
    [InlineData(ViewerLayout.V1x3)]
    [InlineData(ViewerLayout.V1x4)]
    [InlineData(ViewerLayout.V2x1)]
    [InlineData(ViewerLayout.V2x2)]
    [InlineData(ViewerLayout.V2x3)]
    [InlineData(ViewerLayout.V2x4)]
    [InlineData(ViewerLayout.V3x1)]
    [InlineData(ViewerLayout.V3x2)]
    [InlineData(ViewerLayout.V3x3)]
    [InlineData(ViewerLayout.V3x4)]
    [InlineData(ViewerLayout.V4x1)]
    [InlineData(ViewerLayout.V4x2)]
    [InlineData(ViewerLayout.V4x3)]
    [InlineData(ViewerLayout.V4x4)]
    public void Validation_Works(ViewerLayout rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ViewerLayout> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ViewerLayout>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ViewerLayout.V1x1)]
    [InlineData(ViewerLayout.V1x2)]
    [InlineData(ViewerLayout.V1x3)]
    [InlineData(ViewerLayout.V1x4)]
    [InlineData(ViewerLayout.V2x1)]
    [InlineData(ViewerLayout.V2x2)]
    [InlineData(ViewerLayout.V2x3)]
    [InlineData(ViewerLayout.V2x4)]
    [InlineData(ViewerLayout.V3x1)]
    [InlineData(ViewerLayout.V3x2)]
    [InlineData(ViewerLayout.V3x3)]
    [InlineData(ViewerLayout.V3x4)]
    [InlineData(ViewerLayout.V4x1)]
    [InlineData(ViewerLayout.V4x2)]
    [InlineData(ViewerLayout.V4x3)]
    [InlineData(ViewerLayout.V4x4)]
    public void SerializationRoundtrip_Works(ViewerLayout rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ViewerLayout> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ViewerLayout>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ViewerLayout>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ViewerLayout>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
