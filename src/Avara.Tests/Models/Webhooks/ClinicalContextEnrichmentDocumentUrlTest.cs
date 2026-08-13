using System.Text.Json;
using Avara.Core;
using Avara.Models.Webhooks;

namespace Avara.Tests.Models.Webhooks;

public class ClinicalContextEnrichmentDocumentUrlTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ClinicalContextEnrichmentDocumentUrl
        {
            Url = "https://ehr.example.com/docs/note.pdf",
            FileName = "clinical-note.pdf",
        };

        string expectedUrl = "https://ehr.example.com/docs/note.pdf";
        string expectedFileName = "clinical-note.pdf";

        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedFileName, model.FileName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ClinicalContextEnrichmentDocumentUrl
        {
            Url = "https://ehr.example.com/docs/note.pdf",
            FileName = "clinical-note.pdf",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClinicalContextEnrichmentDocumentUrl>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ClinicalContextEnrichmentDocumentUrl
        {
            Url = "https://ehr.example.com/docs/note.pdf",
            FileName = "clinical-note.pdf",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClinicalContextEnrichmentDocumentUrl>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedUrl = "https://ehr.example.com/docs/note.pdf";
        string expectedFileName = "clinical-note.pdf";

        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedFileName, deserialized.FileName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ClinicalContextEnrichmentDocumentUrl
        {
            Url = "https://ehr.example.com/docs/note.pdf",
            FileName = "clinical-note.pdf",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ClinicalContextEnrichmentDocumentUrl
        {
            Url = "https://ehr.example.com/docs/note.pdf",
        };

        Assert.Null(model.FileName);
        Assert.False(model.RawData.ContainsKey("fileName"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ClinicalContextEnrichmentDocumentUrl
        {
            Url = "https://ehr.example.com/docs/note.pdf",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ClinicalContextEnrichmentDocumentUrl
        {
            Url = "https://ehr.example.com/docs/note.pdf",

            // Null should be interpreted as omitted for these properties
            FileName = null,
        };

        Assert.Null(model.FileName);
        Assert.False(model.RawData.ContainsKey("fileName"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ClinicalContextEnrichmentDocumentUrl
        {
            Url = "https://ehr.example.com/docs/note.pdf",

            // Null should be interpreted as omitted for these properties
            FileName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ClinicalContextEnrichmentDocumentUrl
        {
            Url = "https://ehr.example.com/docs/note.pdf",
            FileName = "clinical-note.pdf",
        };

        ClinicalContextEnrichmentDocumentUrl copied = new(model);

        Assert.Equal(model, copied);
    }
}
