using System.Text.Json;
using Avara.Core;
using Avara.Models.AutoScribe.Reports;

namespace Avara.Tests.Models.AutoScribe.Reports;

public class ReportCancelAddendumResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReportCancelAddendumResponse { Success = true, Message = "message" };

        bool expectedSuccess = true;
        string expectedMessage = "message";

        Assert.Equal(expectedSuccess, model.Success);
        Assert.Equal(expectedMessage, model.Message);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReportCancelAddendumResponse { Success = true, Message = "message" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReportCancelAddendumResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReportCancelAddendumResponse { Success = true, Message = "message" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReportCancelAddendumResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedSuccess = true;
        string expectedMessage = "message";

        Assert.Equal(expectedSuccess, deserialized.Success);
        Assert.Equal(expectedMessage, deserialized.Message);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReportCancelAddendumResponse { Success = true, Message = "message" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ReportCancelAddendumResponse { Success = true };

        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ReportCancelAddendumResponse { Success = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ReportCancelAddendumResponse
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
        var model = new ReportCancelAddendumResponse
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
        var model = new ReportCancelAddendumResponse { Success = true, Message = "message" };

        ReportCancelAddendumResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
