using System;
using Avara.Models.AutoScribe.Reports;

namespace Avara.Tests.Models.AutoScribe.Reports;

public class ReportCancelAddendumParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ReportCancelAddendumParams
        {
            ReportID = "rep_1234567890abcdef1234567890abcdef",
        };

        string expectedReportID = "rep_1234567890abcdef1234567890abcdef";

        Assert.Equal(expectedReportID, parameters.ReportID);
    }

    [Fact]
    public void Url_Works()
    {
        ReportCancelAddendumParams parameters = new()
        {
            ReportID = "rep_1234567890abcdef1234567890abcdef",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.avarasoftware.com/v1/autoScribe/reports/rep_1234567890abcdef1234567890abcdef/cancel-addendum"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ReportCancelAddendumParams
        {
            ReportID = "rep_1234567890abcdef1234567890abcdef",
        };

        ReportCancelAddendumParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
