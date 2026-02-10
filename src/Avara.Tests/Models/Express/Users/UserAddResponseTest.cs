using System.Text.Json;
using Avara.Core;
using Avara.Models.Express.Users;

namespace Avara.Tests.Models.Express.Users;

public class UserAddResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserAddResponse
        {
            Success = true,
            Message = "Operation completed successfully",
        };

        bool expectedSuccess = true;
        string expectedMessage = "Operation completed successfully";

        Assert.Equal(expectedSuccess, model.Success);
        Assert.Equal(expectedMessage, model.Message);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserAddResponse
        {
            Success = true,
            Message = "Operation completed successfully",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserAddResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserAddResponse
        {
            Success = true,
            Message = "Operation completed successfully",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserAddResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedSuccess = true;
        string expectedMessage = "Operation completed successfully";

        Assert.Equal(expectedSuccess, deserialized.Success);
        Assert.Equal(expectedMessage, deserialized.Message);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserAddResponse
        {
            Success = true,
            Message = "Operation completed successfully",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UserAddResponse { Success = true };

        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UserAddResponse { Success = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UserAddResponse
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
        var model = new UserAddResponse
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
        var model = new UserAddResponse
        {
            Success = true,
            Message = "Operation completed successfully",
        };

        UserAddResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
