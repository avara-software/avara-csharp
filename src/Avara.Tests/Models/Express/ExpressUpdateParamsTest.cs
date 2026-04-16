using System;
using System.Collections.Generic;
using Avara.Models.Express;

namespace Avara.Tests.Models.Express;

public class ExpressUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExpressUpdateParams
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center - Radiology & Imaging",
            Metadata = new Dictionary<string, string>()
            {
                { "department", "radiology" },
                { "region", "northeast" },
                { "wing", "Building A" },
            },
        };

        string expectedExpressCustomerID = "cus_1234567890abcdef1234567890abcdef";
        string expectedExpressCustomerName = "City Medical Center - Radiology & Imaging";
        Dictionary<string, string> expectedMetadata = new()
        {
            { "department", "radiology" },
            { "region", "northeast" },
            { "wing", "Building A" },
        };

        Assert.Equal(expectedExpressCustomerID, parameters.ExpressCustomerID);
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
        var parameters = new ExpressUpdateParams
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            Metadata = new Dictionary<string, string>()
            {
                { "department", "radiology" },
                { "region", "northeast" },
                { "wing", "Building A" },
            },
        };

        Assert.Null(parameters.ExpressCustomerName);
        Assert.False(parameters.RawBodyData.ContainsKey("expressCustomerName"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExpressUpdateParams
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            Metadata = new Dictionary<string, string>()
            {
                { "department", "radiology" },
                { "region", "northeast" },
                { "wing", "Building A" },
            },

            // Null should be interpreted as omitted for these properties
            ExpressCustomerName = null,
        };

        Assert.Null(parameters.ExpressCustomerName);
        Assert.False(parameters.RawBodyData.ContainsKey("expressCustomerName"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExpressUpdateParams
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center - Radiology & Imaging",
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ExpressUpdateParams
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center - Radiology & Imaging",

            Metadata = null,
        };

        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void Url_Works()
    {
        ExpressUpdateParams parameters = new()
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.avarasoftware.com/v1/express/cus_1234567890abcdef1234567890abcdef"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExpressUpdateParams
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center - Radiology & Imaging",
            Metadata = new Dictionary<string, string>()
            {
                { "department", "radiology" },
                { "region", "northeast" },
                { "wing", "Building A" },
            },
        };

        ExpressUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
