using System.Text.Json;
using Avara.Core;
using Avara.Exceptions;
using Avara.Models;

namespace Avara.Tests.Models;

public class UserLevelTest : TestBase
{
    [Theory]
    [InlineData(UserLevel.Owner)]
    [InlineData(UserLevel.Admin)]
    [InlineData(UserLevel.Member)]
    public void Validation_Works(UserLevel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserLevel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserLevel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UserLevel.Owner)]
    [InlineData(UserLevel.Admin)]
    [InlineData(UserLevel.Member)]
    public void SerializationRoundtrip_Works(UserLevel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserLevel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserLevel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserLevel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserLevel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
