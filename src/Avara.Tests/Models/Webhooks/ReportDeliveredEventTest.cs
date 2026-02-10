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
                PresignedUrl =
                    "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=xyz789",
                ReportID = "rep_1234567890abcdef1234567890abcdef",
                StudyID = "stu_1234567890abcdef1234567890abcdef",
                PlainText = "FINDINGS: Normal brain MRI. No acute intracranial abnormality...",
            },
        };

        string expectedID = "whe_1234567890abcdef1234567890abcdef";
        Data expectedData = new()
        {
            PresignedUrl = "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=xyz789",
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
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
                PresignedUrl =
                    "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=xyz789",
                ReportID = "rep_1234567890abcdef1234567890abcdef",
                StudyID = "stu_1234567890abcdef1234567890abcdef",
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
                PresignedUrl =
                    "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=xyz789",
                ReportID = "rep_1234567890abcdef1234567890abcdef",
                StudyID = "stu_1234567890abcdef1234567890abcdef",
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
        Data expectedData = new()
        {
            PresignedUrl = "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=xyz789",
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
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
                PresignedUrl =
                    "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=xyz789",
                ReportID = "rep_1234567890abcdef1234567890abcdef",
                StudyID = "stu_1234567890abcdef1234567890abcdef",
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
                PresignedUrl =
                    "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=xyz789",
                ReportID = "rep_1234567890abcdef1234567890abcdef",
                StudyID = "stu_1234567890abcdef1234567890abcdef",
                PlainText = "FINDINGS: Normal brain MRI. No acute intracranial abnormality...",
            },
        };

        ReportDeliveredEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
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
        var model = new Data
        {
            PresignedUrl = "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=xyz789",
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            PlainText = "FINDINGS: Normal brain MRI. No acute intracranial abnormality...",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data
        {
            PresignedUrl = "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=xyz789",
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            PlainText = "FINDINGS: Normal brain MRI. No acute intracranial abnormality...",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
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
        var model = new Data
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
        var model = new Data
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
        var model = new Data
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
        var model = new Data
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
        var model = new Data
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
        var model = new Data
        {
            PresignedUrl = "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=xyz789",
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            PlainText = "FINDINGS: Normal brain MRI. No acute intracranial abnormality...",
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}
