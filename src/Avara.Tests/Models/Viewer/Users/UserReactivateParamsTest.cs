using System;
using Avara.Models.Viewer.Users;

namespace Avara.Tests.Models.Viewer.Users;

public class UserReactivateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserReactivateParams
        {
            UserID = "usr_1234567890abcdef1234567890abcdef",
        };

        string expectedUserID = "usr_1234567890abcdef1234567890abcdef";

        Assert.Equal(expectedUserID, parameters.UserID);
    }

    [Fact]
    public void Url_Works()
    {
        UserReactivateParams parameters = new() { UserID = "usr_1234567890abcdef1234567890abcdef" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.avarasoftware.com/v1/viewer/users/reactivate"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserReactivateParams
        {
            UserID = "usr_1234567890abcdef1234567890abcdef",
        };

        UserReactivateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
