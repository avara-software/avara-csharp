using System.Text.Json;
using Avara.Core;
using Avara.Exceptions;
using Avara.Models.AutoScribe;

namespace Avara.Tests.Models.AutoScribe;

public class SexTest : TestBase
{
    [Theory]
    [InlineData(Sex.Male)]
    [InlineData(Sex.Female)]
    [InlineData(Sex.Other)]
    public void Validation_Works(Sex rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Sex> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Sex>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Sex.Male)]
    [InlineData(Sex.Female)]
    [InlineData(Sex.Other)]
    public void SerializationRoundtrip_Works(Sex rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Sex> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Sex>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Sex>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Sex>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
