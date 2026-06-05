using System.Text.Json;
using Avara.Core;
using Avara.Models.Webhooks;

namespace Avara.Tests.Models.Webhooks;

public class SecondaryCaptureAccessRequestedWebhookEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SecondaryCaptureAccessRequestedWebhookEvent
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
        SecondaryCaptureAccessRequestedWebhookEventData expectedData = new()
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
        var model = new SecondaryCaptureAccessRequestedWebhookEvent
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
        var deserialized = JsonSerializer.Deserialize<SecondaryCaptureAccessRequestedWebhookEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SecondaryCaptureAccessRequestedWebhookEvent
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
        var deserialized = JsonSerializer.Deserialize<SecondaryCaptureAccessRequestedWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "whe_1234567890abcdef1234567890abcdef";
        SecondaryCaptureAccessRequestedWebhookEventData expectedData = new()
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
        var model = new SecondaryCaptureAccessRequestedWebhookEvent
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
        var model = new SecondaryCaptureAccessRequestedWebhookEvent
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

        SecondaryCaptureAccessRequestedWebhookEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SecondaryCaptureAccessRequestedWebhookEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SecondaryCaptureAccessRequestedWebhookEventData
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            SeriesInstanceUid = "1.2.840.113619.2.55.3.1234567890.1",
            SopInstanceUid = "1.2.840.113619.2.55.3.1234567890.1.1",
        };

        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.1234567890";
        string expectedSeriesInstanceUid = "1.2.840.113619.2.55.3.1234567890.1";
        string expectedSopInstanceUid = "1.2.840.113619.2.55.3.1234567890.1.1";

        Assert.Equal(expectedStudyID, model.StudyID);
        Assert.Equal(expectedStudyInstanceUid, model.StudyInstanceUid);
        Assert.Equal(expectedSeriesInstanceUid, model.SeriesInstanceUid);
        Assert.Equal(expectedSopInstanceUid, model.SopInstanceUid);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SecondaryCaptureAccessRequestedWebhookEventData
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            SeriesInstanceUid = "1.2.840.113619.2.55.3.1234567890.1",
            SopInstanceUid = "1.2.840.113619.2.55.3.1234567890.1.1",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SecondaryCaptureAccessRequestedWebhookEventData>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SecondaryCaptureAccessRequestedWebhookEventData
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            SeriesInstanceUid = "1.2.840.113619.2.55.3.1234567890.1",
            SopInstanceUid = "1.2.840.113619.2.55.3.1234567890.1.1",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SecondaryCaptureAccessRequestedWebhookEventData>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.1234567890";
        string expectedSeriesInstanceUid = "1.2.840.113619.2.55.3.1234567890.1";
        string expectedSopInstanceUid = "1.2.840.113619.2.55.3.1234567890.1.1";

        Assert.Equal(expectedStudyID, deserialized.StudyID);
        Assert.Equal(expectedStudyInstanceUid, deserialized.StudyInstanceUid);
        Assert.Equal(expectedSeriesInstanceUid, deserialized.SeriesInstanceUid);
        Assert.Equal(expectedSopInstanceUid, deserialized.SopInstanceUid);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SecondaryCaptureAccessRequestedWebhookEventData
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            SeriesInstanceUid = "1.2.840.113619.2.55.3.1234567890.1",
            SopInstanceUid = "1.2.840.113619.2.55.3.1234567890.1.1",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SecondaryCaptureAccessRequestedWebhookEventData
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
        };

        Assert.Null(model.SeriesInstanceUid);
        Assert.False(model.RawData.ContainsKey("seriesInstanceUid"));
        Assert.Null(model.SopInstanceUid);
        Assert.False(model.RawData.ContainsKey("sopInstanceUid"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SecondaryCaptureAccessRequestedWebhookEventData
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SecondaryCaptureAccessRequestedWebhookEventData
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",

            // Null should be interpreted as omitted for these properties
            SeriesInstanceUid = null,
            SopInstanceUid = null,
        };

        Assert.Null(model.SeriesInstanceUid);
        Assert.False(model.RawData.ContainsKey("seriesInstanceUid"));
        Assert.Null(model.SopInstanceUid);
        Assert.False(model.RawData.ContainsKey("sopInstanceUid"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SecondaryCaptureAccessRequestedWebhookEventData
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",

            // Null should be interpreted as omitted for these properties
            SeriesInstanceUid = null,
            SopInstanceUid = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SecondaryCaptureAccessRequestedWebhookEventData
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            SeriesInstanceUid = "1.2.840.113619.2.55.3.1234567890.1",
            SopInstanceUid = "1.2.840.113619.2.55.3.1234567890.1.1",
        };

        SecondaryCaptureAccessRequestedWebhookEventData copied = new(model);

        Assert.Equal(model, copied);
    }
}
