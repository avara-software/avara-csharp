using System.Text.Json;
using Avara.Core;
using Avara.Exceptions;
using Avara.Models;

namespace Avara.Tests.Models;

public class InvitationStatusTest : TestBase
{
    [Theory]
    [InlineData(InvitationStatus.Sent)]
    [InlineData(InvitationStatus.Accepted)]
    [InlineData(InvitationStatus.Rejected)]
    [InlineData(InvitationStatus.Revoked)]
    public void Validation_Works(InvitationStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitationStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvitationStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InvitationStatus.Sent)]
    [InlineData(InvitationStatus.Accepted)]
    [InlineData(InvitationStatus.Rejected)]
    [InlineData(InvitationStatus.Revoked)]
    public void SerializationRoundtrip_Works(InvitationStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitationStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InvitationStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvitationStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InvitationStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
