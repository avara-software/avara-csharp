using System.Text.Json;
using Avara.Core;
using Avara.Models.Webhooks;

namespace Avara.Tests.Models.Webhooks;

public class SecondaryCaptureAccessRequestedEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SecondaryCaptureAccessRequestedEvent
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                StudyID = "stu_1234567890abcdef1234567890abcdef",
                StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
                SeriesInstanceUid = "1.2.840.113619.2.55.3.1234567890.1",
                SopInstanceUid = "1.2.840.113619.2.55.3.1234567890.1.1",
            },
        };

        string expectedID = "whe_1234567890abcdef1234567890abcdef";
        SecondaryCaptureAccessRequestedEventData expectedData = new()
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            SeriesInstanceUid = "1.2.840.113619.2.55.3.1234567890.1",
            SopInstanceUid = "1.2.840.113619.2.55.3.1234567890.1.1",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "secondary_capture.access_requested"
        );

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedData, model.Data);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SecondaryCaptureAccessRequestedEvent
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                StudyID = "stu_1234567890abcdef1234567890abcdef",
                StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
                SeriesInstanceUid = "1.2.840.113619.2.55.3.1234567890.1",
                SopInstanceUid = "1.2.840.113619.2.55.3.1234567890.1.1",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SecondaryCaptureAccessRequestedEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SecondaryCaptureAccessRequestedEvent
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                StudyID = "stu_1234567890abcdef1234567890abcdef",
                StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
                SeriesInstanceUid = "1.2.840.113619.2.55.3.1234567890.1",
                SopInstanceUid = "1.2.840.113619.2.55.3.1234567890.1.1",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SecondaryCaptureAccessRequestedEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "whe_1234567890abcdef1234567890abcdef";
        SecondaryCaptureAccessRequestedEventData expectedData = new()
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            SeriesInstanceUid = "1.2.840.113619.2.55.3.1234567890.1",
            SopInstanceUid = "1.2.840.113619.2.55.3.1234567890.1.1",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "secondary_capture.access_requested"
        );

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SecondaryCaptureAccessRequestedEvent
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                StudyID = "stu_1234567890abcdef1234567890abcdef",
                StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
                SeriesInstanceUid = "1.2.840.113619.2.55.3.1234567890.1",
                SopInstanceUid = "1.2.840.113619.2.55.3.1234567890.1.1",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SecondaryCaptureAccessRequestedEvent
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                StudyID = "stu_1234567890abcdef1234567890abcdef",
                StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
                SeriesInstanceUid = "1.2.840.113619.2.55.3.1234567890.1",
                SopInstanceUid = "1.2.840.113619.2.55.3.1234567890.1.1",
            },
        };

        SecondaryCaptureAccessRequestedEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}
