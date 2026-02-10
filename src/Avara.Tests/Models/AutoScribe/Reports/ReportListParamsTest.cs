using System;
using Avara.Models.AutoScribe.Reports;

namespace Avara.Tests.Models.AutoScribe.Reports;

public class ReportListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ReportListParams
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.10008.5.1.4.1.1.2",
        };

        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedStudyInstanceUid = "1.2.840.10008.5.1.4.1.1.2";

        Assert.Equal(expectedStudyID, parameters.StudyID);
        Assert.Equal(expectedStudyInstanceUid, parameters.StudyInstanceUid);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ReportListParams { };

        Assert.Null(parameters.StudyID);
        Assert.False(parameters.RawQueryData.ContainsKey("studyId"));
        Assert.Null(parameters.StudyInstanceUid);
        Assert.False(parameters.RawQueryData.ContainsKey("studyInstanceUid"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ReportListParams
        {
            // Null should be interpreted as omitted for these properties
            StudyID = null,
            StudyInstanceUid = null,
        };

        Assert.Null(parameters.StudyID);
        Assert.False(parameters.RawQueryData.ContainsKey("studyId"));
        Assert.Null(parameters.StudyInstanceUid);
        Assert.False(parameters.RawQueryData.ContainsKey("studyInstanceUid"));
    }

    [Fact]
    public void Url_Works()
    {
        ReportListParams parameters = new()
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.10008.5.1.4.1.1.2",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.avarasoftware.com/v1/autoScribe/reports?studyId=stu_1234567890abcdef1234567890abcdef&studyInstanceUid=1.2.840.10008.5.1.4.1.1.2"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ReportListParams
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.10008.5.1.4.1.1.2",
        };

        ReportListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
