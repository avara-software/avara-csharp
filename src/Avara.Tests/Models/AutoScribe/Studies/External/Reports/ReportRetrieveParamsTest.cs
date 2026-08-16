using System;
using Avara.Models.AutoScribe.Studies.External.Reports;

namespace Avara.Tests.Models.AutoScribe.Studies.External.Reports;

public class ReportRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ReportRetrieveParams
        {
            ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
        };

        string expectedExternalReportID = "ext_1234567890abcdef1234567890abcdef";

        Assert.Equal(expectedExternalReportID, parameters.ExternalReportID);
    }

    [Fact]
    public void Url_Works()
    {
        ReportRetrieveParams parameters = new()
        {
            ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.avarasoftware.com/v1/autoScribe/studies/external/reports/ext_1234567890abcdef1234567890abcdef"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ReportRetrieveParams
        {
            ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
        };

        ReportRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
