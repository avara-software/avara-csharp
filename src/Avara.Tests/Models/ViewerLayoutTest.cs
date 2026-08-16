using System.Text.Json;
using Avara.Core;
using Avara.Exceptions;
using Avara.Models;

namespace Avara.Tests.Models;

public class ViewerLayoutTest : TestBase
{
    [Theory]
    [InlineData(ViewerLayout.OneByOne)]
    [InlineData(ViewerLayout.OneByTwo)]
    [InlineData(ViewerLayout.OneByThree)]
    [InlineData(ViewerLayout.OneByFour)]
    [InlineData(ViewerLayout.TwoByOne)]
    [InlineData(ViewerLayout.TwoByTwo)]
    [InlineData(ViewerLayout.TwoByThree)]
    [InlineData(ViewerLayout.TwoByFour)]
    [InlineData(ViewerLayout.ThreeByOne)]
    [InlineData(ViewerLayout.ThreeByTwo)]
    [InlineData(ViewerLayout.ThreeByThree)]
    [InlineData(ViewerLayout.ThreeByFour)]
    [InlineData(ViewerLayout.FourByOne)]
    [InlineData(ViewerLayout.FourByTwo)]
    [InlineData(ViewerLayout.FourByThree)]
    [InlineData(ViewerLayout.FourByFour)]
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
    [InlineData(ViewerLayout.OneByOne)]
    [InlineData(ViewerLayout.OneByTwo)]
    [InlineData(ViewerLayout.OneByThree)]
    [InlineData(ViewerLayout.OneByFour)]
    [InlineData(ViewerLayout.TwoByOne)]
    [InlineData(ViewerLayout.TwoByTwo)]
    [InlineData(ViewerLayout.TwoByThree)]
    [InlineData(ViewerLayout.TwoByFour)]
    [InlineData(ViewerLayout.ThreeByOne)]
    [InlineData(ViewerLayout.ThreeByTwo)]
    [InlineData(ViewerLayout.ThreeByThree)]
    [InlineData(ViewerLayout.ThreeByFour)]
    [InlineData(ViewerLayout.FourByOne)]
    [InlineData(ViewerLayout.FourByTwo)]
    [InlineData(ViewerLayout.FourByThree)]
    [InlineData(ViewerLayout.FourByFour)]
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
