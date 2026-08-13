using System.Text.Json;
using Avara.Core;
using Avara.Models.Webhooks;

namespace Avara.Tests.Models.Webhooks;

public class ClinicalContextEnrichmentRequestedEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ClinicalContextEnrichmentRequestedEventData
        {
            ClinicID = "123e4567-e89b-12d3-a456-426614174000",
            StudyID = "123e4567-e89b-12d3-a456-426614174111",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            ExternalPatientID = "EHR-999",
            Mrn = "MRN-12345",
        };

        string expectedClinicID = "123e4567-e89b-12d3-a456-426614174000";
        string expectedStudyID = "123e4567-e89b-12d3-a456-426614174111";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.1234567890";
        string expectedExternalPatientID = "EHR-999";
        string expectedMrn = "MRN-12345";

        Assert.Equal(expectedClinicID, model.ClinicID);
        Assert.Equal(expectedStudyID, model.StudyID);
        Assert.Equal(expectedStudyInstanceUid, model.StudyInstanceUid);
        Assert.Equal(expectedExternalPatientID, model.ExternalPatientID);
        Assert.Equal(expectedMrn, model.Mrn);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ClinicalContextEnrichmentRequestedEventData
        {
            ClinicID = "123e4567-e89b-12d3-a456-426614174000",
            StudyID = "123e4567-e89b-12d3-a456-426614174111",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            ExternalPatientID = "EHR-999",
            Mrn = "MRN-12345",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClinicalContextEnrichmentRequestedEventData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ClinicalContextEnrichmentRequestedEventData
        {
            ClinicID = "123e4567-e89b-12d3-a456-426614174000",
            StudyID = "123e4567-e89b-12d3-a456-426614174111",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            ExternalPatientID = "EHR-999",
            Mrn = "MRN-12345",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClinicalContextEnrichmentRequestedEventData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedClinicID = "123e4567-e89b-12d3-a456-426614174000";
        string expectedStudyID = "123e4567-e89b-12d3-a456-426614174111";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.1234567890";
        string expectedExternalPatientID = "EHR-999";
        string expectedMrn = "MRN-12345";

        Assert.Equal(expectedClinicID, deserialized.ClinicID);
        Assert.Equal(expectedStudyID, deserialized.StudyID);
        Assert.Equal(expectedStudyInstanceUid, deserialized.StudyInstanceUid);
        Assert.Equal(expectedExternalPatientID, deserialized.ExternalPatientID);
        Assert.Equal(expectedMrn, deserialized.Mrn);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ClinicalContextEnrichmentRequestedEventData
        {
            ClinicID = "123e4567-e89b-12d3-a456-426614174000",
            StudyID = "123e4567-e89b-12d3-a456-426614174111",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            ExternalPatientID = "EHR-999",
            Mrn = "MRN-12345",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ClinicalContextEnrichmentRequestedEventData
        {
            ClinicID = "123e4567-e89b-12d3-a456-426614174000",
            StudyID = "123e4567-e89b-12d3-a456-426614174111",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
        };

        Assert.Null(model.ExternalPatientID);
        Assert.False(model.RawData.ContainsKey("externalPatientId"));
        Assert.Null(model.Mrn);
        Assert.False(model.RawData.ContainsKey("mrn"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ClinicalContextEnrichmentRequestedEventData
        {
            ClinicID = "123e4567-e89b-12d3-a456-426614174000",
            StudyID = "123e4567-e89b-12d3-a456-426614174111",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ClinicalContextEnrichmentRequestedEventData
        {
            ClinicID = "123e4567-e89b-12d3-a456-426614174000",
            StudyID = "123e4567-e89b-12d3-a456-426614174111",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",

            // Null should be interpreted as omitted for these properties
            ExternalPatientID = null,
            Mrn = null,
        };

        Assert.Null(model.ExternalPatientID);
        Assert.False(model.RawData.ContainsKey("externalPatientId"));
        Assert.Null(model.Mrn);
        Assert.False(model.RawData.ContainsKey("mrn"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ClinicalContextEnrichmentRequestedEventData
        {
            ClinicID = "123e4567-e89b-12d3-a456-426614174000",
            StudyID = "123e4567-e89b-12d3-a456-426614174111",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",

            // Null should be interpreted as omitted for these properties
            ExternalPatientID = null,
            Mrn = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ClinicalContextEnrichmentRequestedEventData
        {
            ClinicID = "123e4567-e89b-12d3-a456-426614174000",
            StudyID = "123e4567-e89b-12d3-a456-426614174111",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            ExternalPatientID = "EHR-999",
            Mrn = "MRN-12345",
        };

        ClinicalContextEnrichmentRequestedEventData copied = new(model);

        Assert.Equal(model, copied);
    }
}
