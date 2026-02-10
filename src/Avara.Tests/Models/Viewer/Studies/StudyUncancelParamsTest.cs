using System;
using Avara.Models.Viewer.Studies;

namespace Avara.Tests.Models.Viewer.Studies;

public class StudyUncancelParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new StudyUncancelParams
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
        };

        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123";

        Assert.Equal(expectedStudyID, parameters.StudyID);
        Assert.Equal(expectedStudyInstanceUid, parameters.StudyInstanceUid);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new StudyUncancelParams { };

        Assert.Null(parameters.StudyID);
        Assert.False(parameters.RawBodyData.ContainsKey("studyId"));
        Assert.Null(parameters.StudyInstanceUid);
        Assert.False(parameters.RawBodyData.ContainsKey("studyInstanceUid"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new StudyUncancelParams
        {
            // Null should be interpreted as omitted for these properties
            StudyID = null,
            StudyInstanceUid = null,
        };

        Assert.Null(parameters.StudyID);
        Assert.False(parameters.RawBodyData.ContainsKey("studyId"));
        Assert.Null(parameters.StudyInstanceUid);
        Assert.False(parameters.RawBodyData.ContainsKey("studyInstanceUid"));
    }

    [Fact]
    public void Url_Works()
    {
        StudyUncancelParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.avarasoftware.com/v1/viewer/studies/uncancel"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new StudyUncancelParams
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
        };

        StudyUncancelParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
