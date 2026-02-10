using System;
using Avara.Models.AutoScribe.Studies;

namespace Avara.Tests.Models.AutoScribe.Studies;

public class StudyViewerOnlyRerouteUrlParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new StudyViewerOnlyRerouteUrlParams
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            UserID = "usr_1234567890abcdef1234567890abcdef",
        };

        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123";
        string expectedUserID = "usr_1234567890abcdef1234567890abcdef";

        Assert.Equal(expectedStudyID, parameters.StudyID);
        Assert.Equal(expectedStudyInstanceUid, parameters.StudyInstanceUid);
        Assert.Equal(expectedUserID, parameters.UserID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new StudyViewerOnlyRerouteUrlParams { };

        Assert.Null(parameters.StudyID);
        Assert.False(parameters.RawBodyData.ContainsKey("studyId"));
        Assert.Null(parameters.StudyInstanceUid);
        Assert.False(parameters.RawBodyData.ContainsKey("studyInstanceUid"));
        Assert.Null(parameters.UserID);
        Assert.False(parameters.RawBodyData.ContainsKey("userId"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new StudyViewerOnlyRerouteUrlParams
        {
            // Null should be interpreted as omitted for these properties
            StudyID = null,
            StudyInstanceUid = null,
            UserID = null,
        };

        Assert.Null(parameters.StudyID);
        Assert.False(parameters.RawBodyData.ContainsKey("studyId"));
        Assert.Null(parameters.StudyInstanceUid);
        Assert.False(parameters.RawBodyData.ContainsKey("studyInstanceUid"));
        Assert.Null(parameters.UserID);
        Assert.False(parameters.RawBodyData.ContainsKey("userId"));
    }

    [Fact]
    public void Url_Works()
    {
        StudyViewerOnlyRerouteUrlParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.avarasoftware.com/v1/autoScribe/studies/viewer-only-reroute-url"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new StudyViewerOnlyRerouteUrlParams
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            UserID = "usr_1234567890abcdef1234567890abcdef",
        };

        StudyViewerOnlyRerouteUrlParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
