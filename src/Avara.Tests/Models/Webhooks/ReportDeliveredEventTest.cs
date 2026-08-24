using System.Text.Json;
using Avara.Core;
using Avara.Models.Webhooks;

namespace Avara.Tests.Models.Webhooks;

public class ReportDeliveredEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReportDeliveredEvent
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                IsCritical = false,
                PresignedUrl =
                    "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=xyz789",
                ReportID = "rep_1234567890abcdef1234567890abcdef",
                StudyID = "stu_1234567890abcdef1234567890abcdef",
                StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
                ExternalPatientID = "EHR-999",
                PlainText = "FINDINGS: Normal brain MRI. No acute intracranial abnormality...",
            },
        };

        string expectedID = "whe_1234567890abcdef1234567890abcdef";
        ReportDeliveredEventData expectedData = new()
        {
            IsCritical = false,
            PresignedUrl = "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=xyz789",
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            ExternalPatientID = "EHR-999",
            PlainText = "FINDINGS: Normal brain MRI. No acute intracranial abnormality...",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("report.delivered");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedData, model.Data);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReportDeliveredEvent
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                IsCritical = false,
                PresignedUrl =
                    "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=xyz789",
                ReportID = "rep_1234567890abcdef1234567890abcdef",
                StudyID = "stu_1234567890abcdef1234567890abcdef",
                StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
                ExternalPatientID = "EHR-999",
                PlainText = "FINDINGS: Normal brain MRI. No acute intracranial abnormality...",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReportDeliveredEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReportDeliveredEvent
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                IsCritical = false,
                PresignedUrl =
                    "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=xyz789",
                ReportID = "rep_1234567890abcdef1234567890abcdef",
                StudyID = "stu_1234567890abcdef1234567890abcdef",
                StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
                ExternalPatientID = "EHR-999",
                PlainText = "FINDINGS: Normal brain MRI. No acute intracranial abnormality...",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReportDeliveredEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "whe_1234567890abcdef1234567890abcdef";
        ReportDeliveredEventData expectedData = new()
        {
            IsCritical = false,
            PresignedUrl = "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=xyz789",
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            ExternalPatientID = "EHR-999",
            PlainText = "FINDINGS: Normal brain MRI. No acute intracranial abnormality...",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("report.delivered");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReportDeliveredEvent
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                IsCritical = false,
                PresignedUrl =
                    "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=xyz789",
                ReportID = "rep_1234567890abcdef1234567890abcdef",
                StudyID = "stu_1234567890abcdef1234567890abcdef",
                StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
                ExternalPatientID = "EHR-999",
                PlainText = "FINDINGS: Normal brain MRI. No acute intracranial abnormality...",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ReportDeliveredEvent
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                IsCritical = false,
                PresignedUrl =
                    "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=xyz789",
                ReportID = "rep_1234567890abcdef1234567890abcdef",
                StudyID = "stu_1234567890abcdef1234567890abcdef",
                StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
                ExternalPatientID = "EHR-999",
                PlainText = "FINDINGS: Normal brain MRI. No acute intracranial abnormality...",
            },
        };

        ReportDeliveredEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}
