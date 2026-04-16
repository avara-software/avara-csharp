using System;
using Avara.Models.AutoScribe.Users;

namespace Avara.Tests.Models.AutoScribe.Users;

public class UserRevokeAccessParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserRevokeAccessParams
        {
            UserID = "usr_1234567890abcdef1234567890abcdef",
        };

        string expectedUserID = "usr_1234567890abcdef1234567890abcdef";

        Assert.Equal(expectedUserID, parameters.UserID);
    }

    [Fact]
    public void Url_Works()
    {
        UserRevokeAccessParams parameters = new()
        {
            UserID = "usr_1234567890abcdef1234567890abcdef",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.avarasoftware.com/v1/autoScribe/users/revoke-access"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserRevokeAccessParams
        {
            UserID = "usr_1234567890abcdef1234567890abcdef",
        };

        UserRevokeAccessParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
