using System.Collections.Generic;
using System.Text.Json;
using Avara.Core;
using Avara.Models.Webhooks;

namespace Avara.Tests.Models.Webhooks;

public class EphemeralAccessRequestedEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EphemeralAccessRequestedEventData
        {
            RetrievalID = "order-12345",
            Options = new Dictionary<string, JsonElement>()
            {
                { "studyInstanceUids", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string expectedRetrievalID = "order-12345";
        Dictionary<string, JsonElement> expectedOptions = new()
        {
            { "studyInstanceUids", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedRetrievalID, model.RetrievalID);
        Assert.NotNull(model.Options);
        Assert.Equal(expectedOptions.Count, model.Options.Count);
        foreach (var item in expectedOptions)
        {
            Assert.True(model.Options.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Options[item.Key]));
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EphemeralAccessRequestedEventData
        {
            RetrievalID = "order-12345",
            Options = new Dictionary<string, JsonElement>()
            {
                { "studyInstanceUids", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EphemeralAccessRequestedEventData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EphemeralAccessRequestedEventData
        {
            RetrievalID = "order-12345",
            Options = new Dictionary<string, JsonElement>()
            {
                { "studyInstanceUids", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EphemeralAccessRequestedEventData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedRetrievalID = "order-12345";
        Dictionary<string, JsonElement> expectedOptions = new()
        {
            { "studyInstanceUids", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedRetrievalID, deserialized.RetrievalID);
        Assert.NotNull(deserialized.Options);
        Assert.Equal(expectedOptions.Count, deserialized.Options.Count);
        foreach (var item in expectedOptions)
        {
            Assert.True(deserialized.Options.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Options[item.Key]));
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EphemeralAccessRequestedEventData
        {
            RetrievalID = "order-12345",
            Options = new Dictionary<string, JsonElement>()
            {
                { "studyInstanceUids", JsonSerializer.SerializeToElement("bar") },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EphemeralAccessRequestedEventData { RetrievalID = "order-12345" };

        Assert.Null(model.Options);
        Assert.False(model.RawData.ContainsKey("options"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EphemeralAccessRequestedEventData { RetrievalID = "order-12345" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EphemeralAccessRequestedEventData
        {
            RetrievalID = "order-12345",

            // Null should be interpreted as omitted for these properties
            Options = null,
        };

        Assert.Null(model.Options);
        Assert.False(model.RawData.ContainsKey("options"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EphemeralAccessRequestedEventData
        {
            RetrievalID = "order-12345",

            // Null should be interpreted as omitted for these properties
            Options = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EphemeralAccessRequestedEventData
        {
            RetrievalID = "order-12345",
            Options = new Dictionary<string, JsonElement>()
            {
                { "studyInstanceUids", JsonSerializer.SerializeToElement("bar") },
            },
        };

        EphemeralAccessRequestedEventData copied = new(model);

        Assert.Equal(model, copied);
    }
}
