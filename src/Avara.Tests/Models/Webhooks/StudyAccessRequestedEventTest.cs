using System.Text.Json;
using Avara.Core;
using Avara.Models.Webhooks;

namespace Avara.Tests.Models.Webhooks;

public class StudyAccessRequestedEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StudyAccessRequestedEvent
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                StudyID = "stu_1234567890abcdef1234567890abcdef",
                StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            },
        };

        string expectedID = "whe_1234567890abcdef1234567890abcdef";
        StudyAccessRequestedEventData expectedData = new()
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("study.access_requested");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedData, model.Data);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StudyAccessRequestedEvent
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                StudyID = "stu_1234567890abcdef1234567890abcdef",
                StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyAccessRequestedEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StudyAccessRequestedEvent
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                StudyID = "stu_1234567890abcdef1234567890abcdef",
                StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyAccessRequestedEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "whe_1234567890abcdef1234567890abcdef";
        StudyAccessRequestedEventData expectedData = new()
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("study.access_requested");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StudyAccessRequestedEvent
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                StudyID = "stu_1234567890abcdef1234567890abcdef",
                StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new StudyAccessRequestedEvent
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                StudyID = "stu_1234567890abcdef1234567890abcdef",
                StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            },
        };

        StudyAccessRequestedEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StudyAccessRequestedEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StudyAccessRequestedEventData
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
        };

        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.1234567890";

        Assert.Equal(expectedStudyID, model.StudyID);
        Assert.Equal(expectedStudyInstanceUid, model.StudyInstanceUid);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StudyAccessRequestedEventData
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyAccessRequestedEventData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StudyAccessRequestedEventData
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyAccessRequestedEventData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.1234567890";

        Assert.Equal(expectedStudyID, deserialized.StudyID);
        Assert.Equal(expectedStudyInstanceUid, deserialized.StudyInstanceUid);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StudyAccessRequestedEventData
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new StudyAccessRequestedEventData
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
        };

        StudyAccessRequestedEventData copied = new(model);

        Assert.Equal(model, copied);
    }
}
