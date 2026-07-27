using System.Text.Json;
using Avara.Core;
using Avara.Exceptions;
using Avara.Models.AutoScribe;

namespace Avara.Tests.Models.AutoScribe;

public class ClinicalReferenceTypeTest : TestBase
{
    [Theory]
    [InlineData(ClinicalReferenceType.Facility)]
    [InlineData(ClinicalReferenceType.ReferringProvider)]
    [InlineData(ClinicalReferenceType.StudyDescription)]
    [InlineData(ClinicalReferenceType.Procedure)]
    public void Validation_Works(ClinicalReferenceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ClinicalReferenceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ClinicalReferenceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ClinicalReferenceType.Facility)]
    [InlineData(ClinicalReferenceType.ReferringProvider)]
    [InlineData(ClinicalReferenceType.StudyDescription)]
    [InlineData(ClinicalReferenceType.Procedure)]
    public void SerializationRoundtrip_Works(ClinicalReferenceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ClinicalReferenceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ClinicalReferenceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ClinicalReferenceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ClinicalReferenceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
