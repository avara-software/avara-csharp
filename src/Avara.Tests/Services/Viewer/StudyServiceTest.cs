using System.Threading.Tasks;
using Avara.Models.Viewer.Studies;

namespace Avara.Tests.Services.Viewer;

public class StudyServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var study = await this.client.Viewer.Studies.Create(
            new()
            {
                Severity = Severity.High,
                StudyDescription = "CT Chest/Abdomen/Pelvis",
                StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            },
            TestContext.Current.CancellationToken
        );
        study.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var study = await this.client.Viewer.Studies.Retrieve(
            "stu_1234567890abcdef1234567890abcdef",
            new(),
            TestContext.Current.CancellationToken
        );
        study.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var study = await this.client.Viewer.Studies.Update(
            "stu_1234567890abcdef1234567890abcdef",
            new(),
            TestContext.Current.CancellationToken
        );
        study.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Viewer.Studies.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Cancel_Works()
    {
        var response = await this.client.Viewer.Studies.Cancel(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RerouteUrl_Works()
    {
        var response = await this.client.Viewer.Studies.RerouteUrl(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveByUid_Works()
    {
        var response = await this.client.Viewer.Studies.RetrieveByUid(
            "1.2.840.10008.5.1.4.1.1.2",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Uncancel_Works()
    {
        var response = await this.client.Viewer.Studies.Uncancel(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
