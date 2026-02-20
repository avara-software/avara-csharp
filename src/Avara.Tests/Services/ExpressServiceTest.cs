using System.Threading.Tasks;

namespace Avara.Tests.Services;

public class ExpressServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var express = await this.client.Express.Create(
            new() { ExpressCustomerName = "City Medical Center - Radiology Department" },
            TestContext.Current.CancellationToken
        );
        express.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var express = await this.client.Express.Retrieve(
            "cus_1234567890abcdef1234567890abcdef",
            new(),
            TestContext.Current.CancellationToken
        );
        express.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var express = await this.client.Express.Update(
            "cus_1234567890abcdef1234567890abcdef",
            new(),
            TestContext.Current.CancellationToken
        );
        express.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Express.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Deactivate_Works()
    {
        var response = await this.client.Express.Deactivate(
            "cus_1234567890abcdef1234567890abcdef",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Reactivate_Works()
    {
        var response = await this.client.Express.Reactivate(
            "cus_1234567890abcdef1234567890abcdef",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
