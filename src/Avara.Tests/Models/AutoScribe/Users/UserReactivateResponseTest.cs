using System.Text.Json;
using Avara.Core;
using Avara.Models.AutoScribe.Users;

namespace Avara.Tests.Models.AutoScribe.Users;

public class UserReactivateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserReactivateResponse
        {
            Success = true,
            Message = "User reactivated successfully",
        };

        bool expectedSuccess = true;
        string expectedMessage = "User reactivated successfully";

        Assert.Equal(expectedSuccess, model.Success);
        Assert.Equal(expectedMessage, model.Message);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserReactivateResponse
        {
            Success = true,
            Message = "User reactivated successfully",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserReactivateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserReactivateResponse
        {
            Success = true,
            Message = "User reactivated successfully",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserReactivateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedSuccess = true;
        string expectedMessage = "User reactivated successfully";

        Assert.Equal(expectedSuccess, deserialized.Success);
        Assert.Equal(expectedMessage, deserialized.Message);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserReactivateResponse
        {
            Success = true,
            Message = "User reactivated successfully",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UserReactivateResponse { Success = true };

        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UserReactivateResponse { Success = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UserReactivateResponse
        {
            Success = true,

            // Null should be interpreted as omitted for these properties
            Message = null,
        };

        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UserReactivateResponse
        {
            Success = true,

            // Null should be interpreted as omitted for these properties
            Message = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UserReactivateResponse
        {
            Success = true,
            Message = "User reactivated successfully",
        };

        UserReactivateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
