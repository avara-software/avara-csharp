using System;
using Avara.Models.Viewer.Studies;

namespace Avara.Tests.Models.Viewer.Studies;

public class StudyRetrieveByUidParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new StudyRetrieveByUidParams
        {
            StudyInstanceUid = "1.2.840.10008.5.1.4.1.1.2",
        };

        string expectedStudyInstanceUid = "1.2.840.10008.5.1.4.1.1.2";

        Assert.Equal(expectedStudyInstanceUid, parameters.StudyInstanceUid);
    }

    [Fact]
    public void Url_Works()
    {
        StudyRetrieveByUidParams parameters = new()
        {
            StudyInstanceUid = "1.2.840.10008.5.1.4.1.1.2",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.avarasoftware.com/v1/viewer/studies/by-uid/1.2.840.10008.5.1.4.1.1.2"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new StudyRetrieveByUidParams
        {
            StudyInstanceUid = "1.2.840.10008.5.1.4.1.1.2",
        };

        StudyRetrieveByUidParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
