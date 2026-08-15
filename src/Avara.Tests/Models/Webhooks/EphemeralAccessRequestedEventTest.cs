using System.Collections.Generic;
using System.Text.Json;
using Avara.Core;
using Avara.Models.Webhooks;

namespace Avara.Tests.Models.Webhooks;

public class EphemeralAccessRequestedEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EphemeralAccessRequestedEvent
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                RetrievalID = "order-12345",
                Options = new Dictionary<string, JsonElement>()
                {
                    { "studyInstanceUids", JsonSerializer.SerializeToElement("bar") },
                },
            },
        };

        string expectedID = "whe_1234567890abcdef1234567890abcdef";
        EphemeralAccessRequestedEventData expectedData = new()
        {
            RetrievalID = "order-12345",
            Options = new Dictionary<string, JsonElement>()
            {
                { "studyInstanceUids", JsonSerializer.SerializeToElement("bar") },
            },
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("ephemeral.access_requested");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedData, model.Data);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EphemeralAccessRequestedEvent
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                RetrievalID = "order-12345",
                Options = new Dictionary<string, JsonElement>()
                {
                    { "studyInstanceUids", JsonSerializer.SerializeToElement("bar") },
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EphemeralAccessRequestedEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EphemeralAccessRequestedEvent
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                RetrievalID = "order-12345",
                Options = new Dictionary<string, JsonElement>()
                {
                    { "studyInstanceUids", JsonSerializer.SerializeToElement("bar") },
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EphemeralAccessRequestedEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "whe_1234567890abcdef1234567890abcdef";
        EphemeralAccessRequestedEventData expectedData = new()
        {
            RetrievalID = "order-12345",
            Options = new Dictionary<string, JsonElement>()
            {
                { "studyInstanceUids", JsonSerializer.SerializeToElement("bar") },
            },
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("ephemeral.access_requested");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EphemeralAccessRequestedEvent
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                RetrievalID = "order-12345",
                Options = new Dictionary<string, JsonElement>()
                {
                    { "studyInstanceUids", JsonSerializer.SerializeToElement("bar") },
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EphemeralAccessRequestedEvent
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                RetrievalID = "order-12345",
                Options = new Dictionary<string, JsonElement>()
                {
                    { "studyInstanceUids", JsonSerializer.SerializeToElement("bar") },
                },
            },
        };

        EphemeralAccessRequestedEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}
