using System.Text.Json;
using Avara.Core;
using Avara.Models.Webhooks;

namespace Avara.Tests.Models.Webhooks;

public class ReportDeliveredResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReportDeliveredResponse { Success = true };

        bool expectedSuccess = true;

        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReportDeliveredResponse { Success = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReportDeliveredResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReportDeliveredResponse { Success = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReportDeliveredResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedSuccess = true;

        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReportDeliveredResponse { Success = true };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ReportDeliveredResponse { Success = true };

        ReportDeliveredResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
