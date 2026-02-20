using System.Threading.Tasks;
using Avara.Models.Viewer.Users;

namespace Avara.Tests.Services.Viewer;

public class UserServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var user = await this.client.Viewer.Users.Retrieve(
            "usr_1234567890abcdef1234567890abcdef",
            new(),
            TestContext.Current.CancellationToken
        );
        user.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var user = await this.client.Viewer.Users.Update(
            "usr_1234567890abcdef1234567890abcdef",
            new(),
            TestContext.Current.CancellationToken
        );
        user.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Viewer.Users.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Invite_Works()
    {
        var response = await this.client.Viewer.Users.Invite(
            new()
            {
                CanManageStudies = true,
                ClinicRole = UserInviteParamsClinicRole.Radiologist,
                Email = "dr.johnson@hospital.org",
                FirstName = "Sarah",
                HasDashboardAccess = true,
                LastName = "Johnson",
                Level = UserInviteParamsLevel.Member,
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Reactivate_Works()
    {
        var response = await this.client.Viewer.Users.Reactivate(
            new() { UserID = "usr_1234567890abcdef1234567890abcdef" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RevokeAccess_Works()
    {
        var response = await this.client.Viewer.Users.RevokeAccess(
            new() { UserID = "usr_1234567890abcdef1234567890abcdef" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
