using System;
using Avara.Models.AutoScribe.Users;

namespace Avara.Tests.Models.AutoScribe.Users;

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

        Assert.Equal(
            new Uri(
                "https://api.avarasoftware.com/v1/autoScribe/users/usr_1234567890abcdef1234567890abcdef"
            ),
            url
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
