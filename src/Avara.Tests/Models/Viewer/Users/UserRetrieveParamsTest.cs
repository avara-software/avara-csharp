using System;
using Avara.Models.Viewer.Users;

namespace Avara.Tests.Models.Viewer.Users;

public class UserRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserRetrieveParams { UserID = "usr_1234567890abcdef1234567890abcdef" };

        string expectedUserID = "usr_1234567890abcdef1234567890abcdef";

        Assert.Equal(expectedUserID, parameters.UserID);
    }

    [Fact]
    public void Url_Works()
    {
        UserRetrieveParams parameters = new() { UserID = "usr_1234567890abcdef1234567890abcdef" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.avarasoftware.com/v1/viewer/users/usr_1234567890abcdef1234567890abcdef"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserRetrieveParams { UserID = "usr_1234567890abcdef1234567890abcdef" };

        UserRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
