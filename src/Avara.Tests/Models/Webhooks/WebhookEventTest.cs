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
}
