using System.Threading.Tasks;

namespace Avara.Tests.Services.AutoScribe.Studies.External;

public class ReportServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var report = await this.client.AutoScribe.Studies.External.Reports.Create(
            new(),
            TestContext.Current.CancellationToken
        );
        report.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var report = await this.client.AutoScribe.Studies.External.Reports.Retrieve(
            "ext_1234567890abcdef1234567890abcdef",
            new(),
            TestContext.Current.CancellationToken
        );
        report.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.AutoScribe.Studies.External.Reports.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
