using System.Text.Json;
using Avara.Core;
using Avara.Exceptions;
using Avara.Models;

namespace Avara.Tests.Models;

public class InvitationExpiredFilterTest : TestBase
{
    [Theory]
    [InlineData(InvitationExpiredFilter.All)]
    [InlineData(InvitationExpiredFilter.Expired)]
    [InlineData(InvitationExpiredFilter.NotExpired)]
    public void Validation_Works(InvitationExpiredFilter rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitationExpiredFilter> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvitationExpiredFilter>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InvitationExpiredFilter.All)]
    [InlineData(InvitationExpiredFilter.Expired)]
    [InlineData(InvitationExpiredFilter.NotExpired)]
    public void SerializationRoundtrip_Works(InvitationExpiredFilter rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitationExpiredFilter> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InvitationExpiredFilter>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvitationExpiredFilter>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InvitationExpiredFilter>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
