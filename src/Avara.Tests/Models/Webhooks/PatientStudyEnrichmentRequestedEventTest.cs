using System.Text.Json;
using Avara.Core;
using Avara.Models.Webhooks;

namespace Avara.Tests.Models.Webhooks;

public class PatientStudyEnrichmentRequestedEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PatientStudyEnrichmentRequestedEvent
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                ClinicID = "123e4567-e89b-12d3-a456-426614174000",
                StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
                AccessionNumber = "ACC-98765",
                PatientID = "MRN-12345",
            },
        };

        string expectedID = "whe_1234567890abcdef1234567890abcdef";
        PatientStudyEnrichmentRequestedEventData expectedData = new()
        {
            ClinicID = "123e4567-e89b-12d3-a456-426614174000",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            AccessionNumber = "ACC-98765",
            PatientID = "MRN-12345",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "patient_study.enrichment_requested"
        );

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedData, model.Data);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PatientStudyEnrichmentRequestedEvent
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                ClinicID = "123e4567-e89b-12d3-a456-426614174000",
                StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
                AccessionNumber = "ACC-98765",
                PatientID = "MRN-12345",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PatientStudyEnrichmentRequestedEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PatientStudyEnrichmentRequestedEvent
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                ClinicID = "123e4567-e89b-12d3-a456-426614174000",
                StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
                AccessionNumber = "ACC-98765",
                PatientID = "MRN-12345",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PatientStudyEnrichmentRequestedEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "whe_1234567890abcdef1234567890abcdef";
        PatientStudyEnrichmentRequestedEventData expectedData = new()
        {
            ClinicID = "123e4567-e89b-12d3-a456-426614174000",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            AccessionNumber = "ACC-98765",
            PatientID = "MRN-12345",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "patient_study.enrichment_requested"
        );

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PatientStudyEnrichmentRequestedEvent
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                ClinicID = "123e4567-e89b-12d3-a456-426614174000",
                StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
                AccessionNumber = "ACC-98765",
                PatientID = "MRN-12345",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PatientStudyEnrichmentRequestedEvent
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                ClinicID = "123e4567-e89b-12d3-a456-426614174000",
                StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
                AccessionNumber = "ACC-98765",
                PatientID = "MRN-12345",
            },
        };

        PatientStudyEnrichmentRequestedEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}
