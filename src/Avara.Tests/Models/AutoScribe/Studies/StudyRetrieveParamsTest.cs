using System;
using Avara.Models.AutoScribe.Studies;

namespace Avara.Tests.Models.AutoScribe.Studies;

public class StudyRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new StudyRetrieveParams
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
        };

        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";

        Assert.Equal(expectedStudyID, parameters.StudyID);
    }

    [Fact]
    public void Url_Works()
    {
        StudyRetrieveParams parameters = new() { StudyID = "stu_1234567890abcdef1234567890abcdef" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.avarasoftware.com/v1/autoScribe/studies/stu_1234567890abcdef1234567890abcdef"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new StudyRetrieveParams
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
        };

        StudyRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
