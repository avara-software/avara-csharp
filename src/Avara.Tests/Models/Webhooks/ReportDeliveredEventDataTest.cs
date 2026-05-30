using System.Text.Json;
using Avara.Core;
using Avara.Models.Webhooks;

namespace Avara.Tests.Models.Webhooks;

public class ReportDeliveredEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReportDeliveredEventData
        {
            PresignedUrl = "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=xyz789",
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            PlainText = "FINDINGS: Normal brain MRI. No acute intracranial abnormality...",
        };

        string expectedPresignedUrl =
            "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=xyz789";
        string expectedReportID = "rep_1234567890abcdef1234567890abcdef";
        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedPlainText =
            "FINDINGS: Normal brain MRI. No acute intracranial abnormality...";

        Assert.Equal(expectedPresignedUrl, model.PresignedUrl);
        Assert.Equal(expectedReportID, model.ReportID);
        Assert.Equal(expectedStudyID, model.StudyID);
        Assert.Equal(expectedPlainText, model.PlainText);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReportDeliveredEventData
        {
            PresignedUrl = "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=xyz789",
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            PlainText = "FINDINGS: Normal brain MRI. No acute intracranial abnormality...",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReportDeliveredEventData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReportDeliveredEventData
        {
            PresignedUrl = "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=xyz789",
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            PlainText = "FINDINGS: Normal brain MRI. No acute intracranial abnormality...",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReportDeliveredEventData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPresignedUrl =
            "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=xyz789";
        string expectedReportID = "rep_1234567890abcdef1234567890abcdef";
        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedPlainText =
            "FINDINGS: Normal brain MRI. No acute intracranial abnormality...";

        Assert.Equal(expectedPresignedUrl, deserialized.PresignedUrl);
        Assert.Equal(expectedReportID, deserialized.ReportID);
        Assert.Equal(expectedStudyID, deserialized.StudyID);
        Assert.Equal(expectedPlainText, deserialized.PlainText);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReportDeliveredEventData
        {
            PresignedUrl = "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=xyz789",
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            PlainText = "FINDINGS: Normal brain MRI. No acute intracranial abnormality...",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ReportDeliveredEventData
        {
            PresignedUrl = "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=xyz789",
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
        };

        Assert.Null(model.PlainText);
        Assert.False(model.RawData.ContainsKey("plainText"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ReportDeliveredEventData
        {
            PresignedUrl = "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=xyz789",
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ReportDeliveredEventData
        {
            PresignedUrl = "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=xyz789",
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            StudyID = "stu_1234567890abcdef1234567890abcdef",

            // Null should be interpreted as omitted for these properties
            PlainText = null,
        };

        Assert.Null(model.PlainText);
        Assert.False(model.RawData.ContainsKey("plainText"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ReportDeliveredEventData
        {
            PresignedUrl = "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=xyz789",
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            StudyID = "stu_1234567890abcdef1234567890abcdef",

            // Null should be interpreted as omitted for these properties
            PlainText = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ReportDeliveredEventData
        {
            PresignedUrl = "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=xyz789",
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            PlainText = "FINDINGS: Normal brain MRI. No acute intracranial abnormality...",
        };

        ReportDeliveredEventData copied = new(model);

        Assert.Equal(model, copied);
    }
}
