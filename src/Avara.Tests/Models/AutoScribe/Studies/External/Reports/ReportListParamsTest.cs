using System;
using Avara.Models.AutoScribe.Studies.External.Reports;

namespace Avara.Tests.Models.AutoScribe.Studies.External.Reports;

public class ReportListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ReportListParams
        {
            Cursor = "cursor",
            Limit = 20,
            StudyID = "stu_1234567890abcdef1234567890abcdef",
        };

        string expectedCursor = "cursor";
        double expectedLimit = 20;
        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedStudyID, parameters.StudyID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ReportListParams { };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.StudyID);
        Assert.False(parameters.RawQueryData.ContainsKey("studyId"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ReportListParams
        {
            // Null should be interpreted as omitted for these properties
            Cursor = null,
            Limit = null,
            StudyID = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.StudyID);
        Assert.False(parameters.RawQueryData.ContainsKey("studyId"));
    }

    [Fact]
    public void Url_Works()
    {
        ReportListParams parameters = new()
        {
            Cursor = "cursor",
            Limit = 20,
            StudyID = "stu_1234567890abcdef1234567890abcdef",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.avarasoftware.com/v1/autoScribe/studies/external/reports?cursor=cursor&limit=20&studyId=stu_1234567890abcdef1234567890abcdef"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ReportListParams
        {
            Cursor = "cursor",
            Limit = 20,
            StudyID = "stu_1234567890abcdef1234567890abcdef",
        };

        ReportListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
