using System.Collections.Generic;
using System.Text.Json;
using Avara.Core;
using Avara.Models.Webhooks;

namespace Avara.Tests.Models.Webhooks;

public class ClinicalContextEnrichmentDocumentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ClinicalContextEnrichmentDocument
        {
            Content = ["Patient presents with chest pain."],
            FileName = "order-notes.txt",
        };

        List<string> expectedContent = ["Patient presents with chest pain."];
        string expectedFileName = "order-notes.txt";

        Assert.Equal(expectedContent.Count, model.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], model.Content[i]);
        }
        Assert.Equal(expectedFileName, model.FileName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ClinicalContextEnrichmentDocument
        {
            Content = ["Patient presents with chest pain."],
            FileName = "order-notes.txt",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClinicalContextEnrichmentDocument>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ClinicalContextEnrichmentDocument
        {
            Content = ["Patient presents with chest pain."],
            FileName = "order-notes.txt",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClinicalContextEnrichmentDocument>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedContent = ["Patient presents with chest pain."];
        string expectedFileName = "order-notes.txt";

        Assert.Equal(expectedContent.Count, deserialized.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], deserialized.Content[i]);
        }
        Assert.Equal(expectedFileName, deserialized.FileName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ClinicalContextEnrichmentDocument
        {
            Content = ["Patient presents with chest pain."],
            FileName = "order-notes.txt",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ClinicalContextEnrichmentDocument
        {
            Content = ["Patient presents with chest pain."],
            FileName = "order-notes.txt",
        };

        ClinicalContextEnrichmentDocument copied = new(model);

        Assert.Equal(model, copied);
    }
}
