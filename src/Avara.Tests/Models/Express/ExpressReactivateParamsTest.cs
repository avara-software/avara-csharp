using System;
using Avara.Models.Express;

namespace Avara.Tests.Models.Express;

public class ExpressReactivateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExpressReactivateParams
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
        };

        string expectedExpressCustomerID = "cus_1234567890abcdef1234567890abcdef";

        Assert.Equal(expectedExpressCustomerID, parameters.ExpressCustomerID);
    }

    [Fact]
    public void Url_Works()
    {
        ExpressReactivateParams parameters = new()
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.avarasoftware.com/v1/express/cus_1234567890abcdef1234567890abcdef/reactivate"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExpressReactivateParams
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
        };

        ExpressReactivateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
