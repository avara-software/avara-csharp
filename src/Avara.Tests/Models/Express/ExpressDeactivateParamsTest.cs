using System;
using Avara.Models.Express;

namespace Avara.Tests.Models.Express;

public class ExpressDeactivateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExpressDeactivateParams
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
        };

        string expectedExpressCustomerID = "cus_1234567890abcdef1234567890abcdef";

        Assert.Equal(expectedExpressCustomerID, parameters.ExpressCustomerID);
    }

    [Fact]
    public void Url_Works()
    {
        ExpressDeactivateParams parameters = new()
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.avarasoftware.com/v1/express/cus_1234567890abcdef1234567890abcdef/deactivate"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExpressDeactivateParams
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
        };

        ExpressDeactivateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
