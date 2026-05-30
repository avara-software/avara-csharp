using System.Text.Json;
using Avara.Core;
using Avara.Exceptions;
using Avara.Models.AutoScribe;

namespace Avara.Tests.Models.AutoScribe;

public class WeightUnitTest : TestBase
{
    [Theory]
    [InlineData(WeightUnit.Lbs)]
    [InlineData(WeightUnit.Kg)]
    public void Validation_Works(WeightUnit rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WeightUnit> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WeightUnit>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WeightUnit.Lbs)]
    [InlineData(WeightUnit.Kg)]
    public void SerializationRoundtrip_Works(WeightUnit rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WeightUnit> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WeightUnit>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WeightUnit>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WeightUnit>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
