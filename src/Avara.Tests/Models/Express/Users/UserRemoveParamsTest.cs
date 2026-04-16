using System;
using Avara.Models.Express.Users;

namespace Avara.Tests.Models.Express.Users;

public class UserRemoveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserRemoveParams
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            UserID = "usr_1234567890abcdef1234567890abcdef",
        };

        string expectedExpressCustomerID = "cus_1234567890abcdef1234567890abcdef";
        string expectedUserID = "usr_1234567890abcdef1234567890abcdef";

        Assert.Equal(expectedExpressCustomerID, parameters.ExpressCustomerID);
        Assert.Equal(expectedUserID, parameters.UserID);
    }

    [Fact]
    public void Url_Works()
    {
        UserRemoveParams parameters = new()
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            UserID = "usr_1234567890abcdef1234567890abcdef",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.avarasoftware.com/v1/express/cus_1234567890abcdef1234567890abcdef/users"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserRemoveParams
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            UserID = "usr_1234567890abcdef1234567890abcdef",
        };

        UserRemoveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
