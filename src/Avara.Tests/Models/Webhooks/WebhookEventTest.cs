using System.Text.Json;
using Avara.Core;
using Avara.Models.Webhooks;

namespace Avara.Tests.Models.Webhooks;

public class WebhookEventTest : TestBase
{
    [Fact]
    public void StudyAccessRequestedValidationWorks()
    {
        WebhookEvent value = new StudyAccessRequestedEvent()
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                StudyID = "stu_1234567890abcdef1234567890abcdef",
                StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            },
        };
        value.Validate();
    }

    [Fact]
    public void ReportDeliveredValidationWorks()
    {
        WebhookEvent value = new ReportDeliveredEvent()
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                IsCritical = false,
                PresignedUrl =
                    "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=xyz789",
                ReportID = "rep_1234567890abcdef1234567890abcdef",
                StudyID = "stu_1234567890abcdef1234567890abcdef",
                PlainText = "FINDINGS: Normal brain MRI. No acute intracranial abnormality...",
            },
        };
        value.Validate();
    }

    [Fact]
    public void SecondaryCaptureAccessRequestedValidationWorks()
    {
        WebhookEvent value = new SecondaryCaptureAccessRequestedEvent()
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
        value.Validate();
    }

    [Fact]
    public void ModalityWorklistRequestedValidationWorks()
    {
        WebhookEvent value = new ModalityWorklistRequestedEvent()
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                CallingAe = "CT_SCANNER_01",
                ClinicID = "123e4567-e89b-12d3-a456-426614174000",
                DateEnd = "2026-08-13",
                DateStart = "2026-08-13",
                SourceIP = "10.0.0.25",
                Modality = "CT",
            },
        };
        value.Validate();
    }

    [Fact]
    public void PatientStudyEnrichmentRequestedValidationWorks()
    {
        WebhookEvent value = new PatientStudyEnrichmentRequestedEvent()
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
        value.Validate();
    }

    [Fact]
    public void ClinicalContextEnrichmentRequestedValidationWorks()
    {
        WebhookEvent value = new ClinicalContextEnrichmentRequestedEvent()
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                ClinicID = "123e4567-e89b-12d3-a456-426614174000",
                StudyID = "123e4567-e89b-12d3-a456-426614174111",
                StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
                ExternalPatientID = "EHR-999",
                Mrn = "MRN-12345",
            },
        };
        value.Validate();
    }

    [Fact]
    public void StudyAccessRequestedSerializationRoundtripWorks()
    {
        WebhookEvent value = new StudyAccessRequestedEvent()
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                StudyID = "stu_1234567890abcdef1234567890abcdef",
                StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ReportDeliveredSerializationRoundtripWorks()
    {
        WebhookEvent value = new ReportDeliveredEvent()
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                IsCritical = false,
                PresignedUrl =
                    "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=xyz789",
                ReportID = "rep_1234567890abcdef1234567890abcdef",
                StudyID = "stu_1234567890abcdef1234567890abcdef",
                PlainText = "FINDINGS: Normal brain MRI. No acute intracranial abnormality...",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SecondaryCaptureAccessRequestedSerializationRoundtripWorks()
    {
        WebhookEvent value = new SecondaryCaptureAccessRequestedEvent()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ModalityWorklistRequestedSerializationRoundtripWorks()
    {
        WebhookEvent value = new ModalityWorklistRequestedEvent()
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                CallingAe = "CT_SCANNER_01",
                ClinicID = "123e4567-e89b-12d3-a456-426614174000",
                DateEnd = "2026-08-13",
                DateStart = "2026-08-13",
                SourceIP = "10.0.0.25",
                Modality = "CT",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PatientStudyEnrichmentRequestedSerializationRoundtripWorks()
    {
        WebhookEvent value = new PatientStudyEnrichmentRequestedEvent()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ClinicalContextEnrichmentRequestedSerializationRoundtripWorks()
    {
        WebhookEvent value = new ClinicalContextEnrichmentRequestedEvent()
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                ClinicID = "123e4567-e89b-12d3-a456-426614174000",
                StudyID = "123e4567-e89b-12d3-a456-426614174111",
                StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
                ExternalPatientID = "EHR-999",
                Mrn = "MRN-12345",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
