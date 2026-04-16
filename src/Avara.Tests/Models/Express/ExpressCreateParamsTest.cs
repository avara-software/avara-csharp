using System;
using System.Collections.Generic;
using Avara.Models.Express;

namespace Avara.Tests.Models.Express;

public class ExpressCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExpressCreateParams
        {
            ExpressCustomerName = "City Medical Center - Radiology Department",
            Metadata = new Dictionary<string, string>()
            {
                { "department", "radiology" },
                { "region", "northeast" },
            },
        };

        string expectedExpressCustomerName = "City Medical Center - Radiology Department";
        Dictionary<string, string> expectedMetadata = new()
        {
            { "department", "radiology" },
            { "region", "northeast" },
        };

        Assert.Equal(expectedExpressCustomerName, parameters.ExpressCustomerName);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExpressCreateParams
        {
            ExpressCustomerName = "City Medical Center - Radiology Department",
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExpressCreateParams
        {
            ExpressCustomerName = "City Medical Center - Radiology Department",

            // Null should be interpreted as omitted for these properties
            Metadata = null,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void Url_Works()
    {
        ExpressCreateParams parameters = new()
        {
            ExpressCustomerName = "City Medical Center - Radiology Department",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.avarasoftware.com/v1/express"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExpressCreateParams
        {
            ExpressCustomerName = "City Medical Center - Radiology Department",
            Metadata = new Dictionary<string, string>()
            {
                { "department", "radiology" },
                { "region", "northeast" },
            },
        };

        ExpressCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
