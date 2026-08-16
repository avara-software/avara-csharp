using System;
using Avara.Models.AutoScribe.Studies.External;

namespace Avara.Tests.Models.AutoScribe.Studies.External;

public class ExternalDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExternalDeleteParams
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
        var parameters = new ExternalDeleteParams { };

        Assert.Null(parameters.StudyID);
        Assert.False(parameters.RawBodyData.ContainsKey("studyId"));
        Assert.Null(parameters.StudyInstanceUid);
        Assert.False(parameters.RawBodyData.ContainsKey("studyInstanceUid"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExternalDeleteParams
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
        ExternalDeleteParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.avarasoftware.com/v1/autoScribe/studies/external/delete"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExternalDeleteParams
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
        };

        ExternalDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
