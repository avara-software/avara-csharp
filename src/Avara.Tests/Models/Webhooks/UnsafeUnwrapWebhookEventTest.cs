using System.Text.Json;
using Avara.Core;
using Avara.Models.Webhooks;

namespace Avara.Tests.Models.Webhooks;

public class UnsafeUnwrapWebhookEventTest : TestBase
{
    [Fact]
    public void StudyAccessRequestedValidationWorks()
    {
        UnsafeUnwrapWebhookEvent value = new StudyAccessRequestedEvent()
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
        UnsafeUnwrapWebhookEvent value = new ReportDeliveredEvent()
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
        UnsafeUnwrapWebhookEvent value = new SecondaryCaptureAccessRequestedWebhookEvent()
        {
            STAINLESS_FIXME_ID = "whe_1234567890abcdef1234567890abcdef",
            STAINLESS_FIXME_Data = new()
            {
                STAINLESS_FIXME_StudyID = "stu_1234567890abcdef1234567890abcdef",
                STAINLESS_FIXME_StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
                STAINLESS_FIXME_SeriesInstanceUid = "1.2.840.113619.2.55.3.1234567890.1",
                STAINLESS_FIXME_SopInstanceUid = "1.2.840.113619.2.55.3.1234567890.1.1",
            },
        };
        value.Validate();
    }

    [Fact]
    public void StudyAccessRequestedSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new StudyAccessRequestedEvent()
        {
            ID = "whe_1234567890abcdef1234567890abcdef",
            Data = new()
            {
                StudyID = "stu_1234567890abcdef1234567890abcdef",
                StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ReportDeliveredSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new ReportDeliveredEvent()
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
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SecondaryCaptureAccessRequestedSerializationRoundtripWorks()
    {
        UnsafeUnwrapWebhookEvent value = new SecondaryCaptureAccessRequestedWebhookEvent()
        {
            STAINLESS_FIXME_ID = "whe_1234567890abcdef1234567890abcdef",
            STAINLESS_FIXME_Data = new()
            {
                STAINLESS_FIXME_StudyID = "stu_1234567890abcdef1234567890abcdef",
                STAINLESS_FIXME_StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
                STAINLESS_FIXME_SeriesInstanceUid = "1.2.840.113619.2.55.3.1234567890.1",
                STAINLESS_FIXME_SopInstanceUid = "1.2.840.113619.2.55.3.1234567890.1.1",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnsafeUnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
