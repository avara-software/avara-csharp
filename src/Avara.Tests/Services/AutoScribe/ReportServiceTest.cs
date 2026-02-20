using System.Threading.Tasks;

namespace Avara.Tests.Services.AutoScribe;

public class ReportServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var reports = await this.client.AutoScribe.Reports.List(
            new(),
            TestContext.Current.CancellationToken
        );
        reports.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Addendum_Works()
    {
        var response = await this.client.AutoScribe.Reports.Addendum(
            "rep_1234567890abcdef1234567890abcdef",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task CancelAddendum_Works()
    {
        var response = await this.client.AutoScribe.Reports.CancelAddendum(
            "rep_1234567890abcdef1234567890abcdef",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Pdf_Works()
    {
        var response = await this.client.AutoScribe.Reports.Pdf(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Text_Works()
    {
        var response = await this.client.AutoScribe.Reports.Text(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
