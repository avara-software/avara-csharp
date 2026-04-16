using System;
using Avara.Models.Express;

namespace Avara.Tests.Models.Express;

public class ExpressListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExpressListParams { Cursor = "eyJvZmZzZXQiOjIwfQ==", Limit = 20 };

        string expectedCursor = "eyJvZmZzZXQiOjIwfQ==";
        double expectedLimit = 20;

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExpressListParams { };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExpressListParams
        {
            // Null should be interpreted as omitted for these properties
            Cursor = null,
            Limit = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        ExpressListParams parameters = new() { Cursor = "eyJvZmZzZXQiOjIwfQ==", Limit = 20 };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.avarasoftware.com/v1/express?cursor=eyJvZmZzZXQiOjIwfQ%3d%3d&limit=20"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExpressListParams { Cursor = "eyJvZmZzZXQiOjIwfQ==", Limit = 20 };

        ExpressListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
