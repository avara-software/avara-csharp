using System.Text.Json;
using Avara.Core;
using Avara.Models.Webhooks;

namespace Avara.Tests.Models.Webhooks;

public class ModalityWorklistRequestedEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ModalityWorklistRequestedEvent
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                CallingAe = "CT_SCANNER_01",
                ClinicID = "123e4567-e89b-12d3-a456-426614174000",
                DateEnd = "2026-08-13",
                DateStart = "2026-08-13",
                SourceIP = "10.0.0.25",
                Modality = "CT",
            },
        };

        string expectedID = "whe_1234567890abcdef1234567890abcdef";
        ModalityWorklistRequestedEventData expectedData = new()
        {
            CallingAe = "CT_SCANNER_01",
            ClinicID = "123e4567-e89b-12d3-a456-426614174000",
            DateEnd = "2026-08-13",
            DateStart = "2026-08-13",
            SourceIP = "10.0.0.25",
            Modality = "CT",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("modality_worklist.requested");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedData, model.Data);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ModalityWorklistRequestedEvent
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                CallingAe = "CT_SCANNER_01",
                ClinicID = "123e4567-e89b-12d3-a456-426614174000",
                DateEnd = "2026-08-13",
                DateStart = "2026-08-13",
                SourceIP = "10.0.0.25",
                Modality = "CT",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModalityWorklistRequestedEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ModalityWorklistRequestedEvent
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                CallingAe = "CT_SCANNER_01",
                ClinicID = "123e4567-e89b-12d3-a456-426614174000",
                DateEnd = "2026-08-13",
                DateStart = "2026-08-13",
                SourceIP = "10.0.0.25",
                Modality = "CT",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModalityWorklistRequestedEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "whe_1234567890abcdef1234567890abcdef";
        ModalityWorklistRequestedEventData expectedData = new()
        {
            CallingAe = "CT_SCANNER_01",
            ClinicID = "123e4567-e89b-12d3-a456-426614174000",
            DateEnd = "2026-08-13",
            DateStart = "2026-08-13",
            SourceIP = "10.0.0.25",
            Modality = "CT",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("modality_worklist.requested");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ModalityWorklistRequestedEvent
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                CallingAe = "CT_SCANNER_01",
                ClinicID = "123e4567-e89b-12d3-a456-426614174000",
                DateEnd = "2026-08-13",
                DateStart = "2026-08-13",
                SourceIP = "10.0.0.25",
                Modality = "CT",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ModalityWorklistRequestedEvent
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                CallingAe = "CT_SCANNER_01",
                ClinicID = "123e4567-e89b-12d3-a456-426614174000",
                DateEnd = "2026-08-13",
                DateStart = "2026-08-13",
                SourceIP = "10.0.0.25",
                Modality = "CT",
            },
        };

        ModalityWorklistRequestedEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}
