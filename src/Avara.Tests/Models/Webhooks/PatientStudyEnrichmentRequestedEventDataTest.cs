using System.Text.Json;
using Avara.Core;
using Avara.Models.Webhooks;

namespace Avara.Tests.Models.Webhooks;

public class PatientStudyEnrichmentRequestedEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PatientStudyEnrichmentRequestedEventData
        {
            ClinicID = "123e4567-e89b-12d3-a456-426614174000",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            AccessionNumber = "ACC-98765",
            PatientID = "MRN-12345",
        };

        string expectedClinicID = "123e4567-e89b-12d3-a456-426614174000";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.1234567890";
        string expectedAccessionNumber = "ACC-98765";
        string expectedPatientID = "MRN-12345";

        Assert.Equal(expectedClinicID, model.ClinicID);
        Assert.Equal(expectedStudyInstanceUid, model.StudyInstanceUid);
        Assert.Equal(expectedAccessionNumber, model.AccessionNumber);
        Assert.Equal(expectedPatientID, model.PatientID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PatientStudyEnrichmentRequestedEventData
        {
            ClinicID = "123e4567-e89b-12d3-a456-426614174000",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            AccessionNumber = "ACC-98765",
            PatientID = "MRN-12345",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PatientStudyEnrichmentRequestedEventData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PatientStudyEnrichmentRequestedEventData
        {
            ClinicID = "123e4567-e89b-12d3-a456-426614174000",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            AccessionNumber = "ACC-98765",
            PatientID = "MRN-12345",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PatientStudyEnrichmentRequestedEventData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedClinicID = "123e4567-e89b-12d3-a456-426614174000";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.1234567890";
        string expectedAccessionNumber = "ACC-98765";
        string expectedPatientID = "MRN-12345";

        Assert.Equal(expectedClinicID, deserialized.ClinicID);
        Assert.Equal(expectedStudyInstanceUid, deserialized.StudyInstanceUid);
        Assert.Equal(expectedAccessionNumber, deserialized.AccessionNumber);
        Assert.Equal(expectedPatientID, deserialized.PatientID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PatientStudyEnrichmentRequestedEventData
        {
            ClinicID = "123e4567-e89b-12d3-a456-426614174000",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            AccessionNumber = "ACC-98765",
            PatientID = "MRN-12345",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PatientStudyEnrichmentRequestedEventData
        {
            ClinicID = "123e4567-e89b-12d3-a456-426614174000",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
        };

        Assert.Null(model.AccessionNumber);
        Assert.False(model.RawData.ContainsKey("accessionNumber"));
        Assert.Null(model.PatientID);
        Assert.False(model.RawData.ContainsKey("patientId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PatientStudyEnrichmentRequestedEventData
        {
            ClinicID = "123e4567-e89b-12d3-a456-426614174000",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PatientStudyEnrichmentRequestedEventData
        {
            ClinicID = "123e4567-e89b-12d3-a456-426614174000",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",

            // Null should be interpreted as omitted for these properties
            AccessionNumber = null,
            PatientID = null,
        };

        Assert.Null(model.AccessionNumber);
        Assert.False(model.RawData.ContainsKey("accessionNumber"));
        Assert.Null(model.PatientID);
        Assert.False(model.RawData.ContainsKey("patientId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PatientStudyEnrichmentRequestedEventData
        {
            ClinicID = "123e4567-e89b-12d3-a456-426614174000",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",

            // Null should be interpreted as omitted for these properties
            AccessionNumber = null,
            PatientID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PatientStudyEnrichmentRequestedEventData
        {
            ClinicID = "123e4567-e89b-12d3-a456-426614174000",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            AccessionNumber = "ACC-98765",
            PatientID = "MRN-12345",
        };

        PatientStudyEnrichmentRequestedEventData copied = new(model);

        Assert.Equal(model, copied);
    }
}
