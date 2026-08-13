using System.Text.Json;
using Avara.Core;
using Avara.Models.Webhooks;

namespace Avara.Tests.Models.Webhooks;

public class ClinicalContextEnrichmentPriorReportTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ClinicalContextEnrichmentPriorReport
        {
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
            ExternalStudyID = "EXT-2024-001",
            Modality = "CT",
            StudyDate = "2024-01-15",
            StudyDescription = "CT Chest without contrast",
        };

        string expectedReportText = "IMPRESSION: No acute cardiopulmonary process.";
        string expectedExternalStudyID = "EXT-2024-001";
        string expectedModality = "CT";
        string expectedStudyDate = "2024-01-15";
        string expectedStudyDescription = "CT Chest without contrast";

        Assert.Equal(expectedReportText, model.ReportText);
        Assert.Equal(expectedExternalStudyID, model.ExternalStudyID);
        Assert.Equal(expectedModality, model.Modality);
        Assert.Equal(expectedStudyDate, model.StudyDate);
        Assert.Equal(expectedStudyDescription, model.StudyDescription);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ClinicalContextEnrichmentPriorReport
        {
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
            ExternalStudyID = "EXT-2024-001",
            Modality = "CT",
            StudyDate = "2024-01-15",
            StudyDescription = "CT Chest without contrast",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClinicalContextEnrichmentPriorReport>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ClinicalContextEnrichmentPriorReport
        {
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
            ExternalStudyID = "EXT-2024-001",
            Modality = "CT",
            StudyDate = "2024-01-15",
            StudyDescription = "CT Chest without contrast",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClinicalContextEnrichmentPriorReport>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedReportText = "IMPRESSION: No acute cardiopulmonary process.";
        string expectedExternalStudyID = "EXT-2024-001";
        string expectedModality = "CT";
        string expectedStudyDate = "2024-01-15";
        string expectedStudyDescription = "CT Chest without contrast";

        Assert.Equal(expectedReportText, deserialized.ReportText);
        Assert.Equal(expectedExternalStudyID, deserialized.ExternalStudyID);
        Assert.Equal(expectedModality, deserialized.Modality);
        Assert.Equal(expectedStudyDate, deserialized.StudyDate);
        Assert.Equal(expectedStudyDescription, deserialized.StudyDescription);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ClinicalContextEnrichmentPriorReport
        {
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
            ExternalStudyID = "EXT-2024-001",
            Modality = "CT",
            StudyDate = "2024-01-15",
            StudyDescription = "CT Chest without contrast",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ClinicalContextEnrichmentPriorReport
        {
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
        };

        Assert.Null(model.ExternalStudyID);
        Assert.False(model.RawData.ContainsKey("externalStudyId"));
        Assert.Null(model.Modality);
        Assert.False(model.RawData.ContainsKey("modality"));
        Assert.Null(model.StudyDate);
        Assert.False(model.RawData.ContainsKey("studyDate"));
        Assert.Null(model.StudyDescription);
        Assert.False(model.RawData.ContainsKey("studyDescription"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ClinicalContextEnrichmentPriorReport
        {
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ClinicalContextEnrichmentPriorReport
        {
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",

            // Null should be interpreted as omitted for these properties
            ExternalStudyID = null,
            Modality = null,
            StudyDate = null,
            StudyDescription = null,
        };

        Assert.Null(model.ExternalStudyID);
        Assert.False(model.RawData.ContainsKey("externalStudyId"));
        Assert.Null(model.Modality);
        Assert.False(model.RawData.ContainsKey("modality"));
        Assert.Null(model.StudyDate);
        Assert.False(model.RawData.ContainsKey("studyDate"));
        Assert.Null(model.StudyDescription);
        Assert.False(model.RawData.ContainsKey("studyDescription"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ClinicalContextEnrichmentPriorReport
        {
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",

            // Null should be interpreted as omitted for these properties
            ExternalStudyID = null,
            Modality = null,
            StudyDate = null,
            StudyDescription = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ClinicalContextEnrichmentPriorReport
        {
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
            ExternalStudyID = "EXT-2024-001",
            Modality = "CT",
            StudyDate = "2024-01-15",
            StudyDescription = "CT Chest without contrast",
        };

        ClinicalContextEnrichmentPriorReport copied = new(model);

        Assert.Equal(model, copied);
    }
}
