using System.Text.Json;
using Avara.Core;
using Avara.Exceptions;
using Avara.Models;

namespace Avara.Tests.Models;

public class AssignableUserLevelTest : TestBase
{
    [Theory]
    [InlineData(AssignableUserLevel.Admin)]
    [InlineData(AssignableUserLevel.Member)]
    public void Validation_Works(AssignableUserLevel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AssignableUserLevel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AssignableUserLevel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AssignableUserLevel.Admin)]
    [InlineData(AssignableUserLevel.Member)]
    public void SerializationRoundtrip_Works(AssignableUserLevel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AssignableUserLevel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AssignableUserLevel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AssignableUserLevel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AssignableUserLevel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
