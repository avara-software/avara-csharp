using System;
using Avara.Models.AutoScribe.Studies.External.Reports;

namespace Avara.Tests.Models.AutoScribe.Studies.External.Reports;

public class ReportCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ReportCreateParams
        {
            ReaderName = "x",
            ReportFileName = "x",
            ReportFileUrl = "https://example.com",
            ReportText = "x",
            SignedAt = "x",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
        };

        string expectedReaderName = "x";
        string expectedReportFileName = "x";
        string expectedReportFileUrl = "https://example.com";
        string expectedReportText = "x";
        string expectedSignedAt = "x";
        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123";

        Assert.Equal(expectedReaderName, parameters.ReaderName);
        Assert.Equal(expectedReportFileName, parameters.ReportFileName);
        Assert.Equal(expectedReportFileUrl, parameters.ReportFileUrl);
        Assert.Equal(expectedReportText, parameters.ReportText);
        Assert.Equal(expectedSignedAt, parameters.SignedAt);
        Assert.Equal(expectedStudyID, parameters.StudyID);
        Assert.Equal(expectedStudyInstanceUid, parameters.StudyInstanceUid);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ReportCreateParams { };

        Assert.Null(parameters.ReaderName);
        Assert.False(parameters.RawBodyData.ContainsKey("readerName"));
        Assert.Null(parameters.ReportFileName);
        Assert.False(parameters.RawBodyData.ContainsKey("reportFileName"));
        Assert.Null(parameters.ReportFileUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("reportFileUrl"));
        Assert.Null(parameters.ReportText);
        Assert.False(parameters.RawBodyData.ContainsKey("reportText"));
        Assert.Null(parameters.SignedAt);
        Assert.False(parameters.RawBodyData.ContainsKey("signedAt"));
        Assert.Null(parameters.StudyID);
        Assert.False(parameters.RawBodyData.ContainsKey("studyId"));
        Assert.Null(parameters.StudyInstanceUid);
        Assert.False(parameters.RawBodyData.ContainsKey("studyInstanceUid"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ReportCreateParams
        {
            // Null should be interpreted as omitted for these properties
            ReaderName = null,
            ReportFileName = null,
            ReportFileUrl = null,
            ReportText = null,
            SignedAt = null,
            StudyID = null,
            StudyInstanceUid = null,
        };

        Assert.Null(parameters.ReaderName);
        Assert.False(parameters.RawBodyData.ContainsKey("readerName"));
        Assert.Null(parameters.ReportFileName);
        Assert.False(parameters.RawBodyData.ContainsKey("reportFileName"));
        Assert.Null(parameters.ReportFileUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("reportFileUrl"));
        Assert.Null(parameters.ReportText);
        Assert.False(parameters.RawBodyData.ContainsKey("reportText"));
        Assert.Null(parameters.SignedAt);
        Assert.False(parameters.RawBodyData.ContainsKey("signedAt"));
        Assert.Null(parameters.StudyID);
        Assert.False(parameters.RawBodyData.ContainsKey("studyId"));
        Assert.Null(parameters.StudyInstanceUid);
        Assert.False(parameters.RawBodyData.ContainsKey("studyInstanceUid"));
    }

    [Fact]
    public void Url_Works()
    {
        ReportCreateParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.avarasoftware.com/v1/autoScribe/studies/external/reports"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ReportCreateParams
        {
            ReaderName = "x",
            ReportFileName = "x",
            ReportFileUrl = "https://example.com",
            ReportText = "x",
            SignedAt = "x",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
        };

        ReportCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
