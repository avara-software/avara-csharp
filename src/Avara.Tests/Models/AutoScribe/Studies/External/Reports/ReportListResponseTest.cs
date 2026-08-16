using System;
using System.Text.Json;
using Avara.Core;
using Avara.Models.AutoScribe.Studies.External.Reports;

namespace Avara.Tests.Models.AutoScribe.Studies.External.Reports;

public class ReportListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReportListResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
            HasReportText = true,
            ReportPdfPresent = true,
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            ReaderName = "readerName",
            SignedAt = "signedAt",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedExternalReportID = "ext_1234567890abcdef1234567890abcdef";
        bool expectedHasReportText = true;
        bool expectedReportPdfPresent = true;
        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123";
        string expectedReaderName = "readerName";
        string expectedSignedAt = "signedAt";

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedExternalReportID, model.ExternalReportID);
        Assert.Equal(expectedHasReportText, model.HasReportText);
        Assert.Equal(expectedReportPdfPresent, model.ReportPdfPresent);
        Assert.Equal(expectedStudyID, model.StudyID);
        Assert.Equal(expectedStudyInstanceUid, model.StudyInstanceUid);
        Assert.Equal(expectedReaderName, model.ReaderName);
        Assert.Equal(expectedSignedAt, model.SignedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReportListResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
            HasReportText = true,
            ReportPdfPresent = true,
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            ReaderName = "readerName",
            SignedAt = "signedAt",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReportListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReportListResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
            HasReportText = true,
            ReportPdfPresent = true,
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            ReaderName = "readerName",
            SignedAt = "signedAt",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReportListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedExternalReportID = "ext_1234567890abcdef1234567890abcdef";
        bool expectedHasReportText = true;
        bool expectedReportPdfPresent = true;
        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123";
        string expectedReaderName = "readerName";
        string expectedSignedAt = "signedAt";

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedExternalReportID, deserialized.ExternalReportID);
        Assert.Equal(expectedHasReportText, deserialized.HasReportText);
        Assert.Equal(expectedReportPdfPresent, deserialized.ReportPdfPresent);
        Assert.Equal(expectedStudyID, deserialized.StudyID);
        Assert.Equal(expectedStudyInstanceUid, deserialized.StudyInstanceUid);
        Assert.Equal(expectedReaderName, deserialized.ReaderName);
        Assert.Equal(expectedSignedAt, deserialized.SignedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReportListResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
            HasReportText = true,
            ReportPdfPresent = true,
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            ReaderName = "readerName",
            SignedAt = "signedAt",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ReportListResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
            HasReportText = true,
            ReportPdfPresent = true,
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
        };

        Assert.Null(model.ReaderName);
        Assert.False(model.RawData.ContainsKey("readerName"));
        Assert.Null(model.SignedAt);
        Assert.False(model.RawData.ContainsKey("signedAt"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ReportListResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
            HasReportText = true,
            ReportPdfPresent = true,
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ReportListResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
            HasReportText = true,
            ReportPdfPresent = true,
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",

            ReaderName = null,
            SignedAt = null,
        };

        Assert.Null(model.ReaderName);
        Assert.True(model.RawData.ContainsKey("readerName"));
        Assert.Null(model.SignedAt);
        Assert.True(model.RawData.ContainsKey("signedAt"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ReportListResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
            HasReportText = true,
            ReportPdfPresent = true,
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",

            ReaderName = null,
            SignedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ReportListResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
            HasReportText = true,
            ReportPdfPresent = true,
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            ReaderName = "readerName",
            SignedAt = "signedAt",
        };

        ReportListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
