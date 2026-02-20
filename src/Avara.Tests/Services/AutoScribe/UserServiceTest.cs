using System.Threading.Tasks;
using Avara.Models.AutoScribe.Users;

namespace Avara.Tests.Services.AutoScribe;

public class UserServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var user = await this.client.AutoScribe.Users.Retrieve(
            "usr_1234567890abcdef1234567890abcdef",
            new(),
            TestContext.Current.CancellationToken
        );
        user.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var user = await this.client.AutoScribe.Users.Update(
            "usr_1234567890abcdef1234567890abcdef",
            new(),
            TestContext.Current.CancellationToken
        );
        user.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.AutoScribe.Users.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Invite_Works()
    {
        var response = await this.client.AutoScribe.Users.Invite(
            new()
            {
                CanCreateReports = true,
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
        var response = await this.client.AutoScribe.Users.Reactivate(
            new() { UserID = "usr_1234567890abcdef1234567890abcdef" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RevokeAccess_Works()
    {
        var response = await this.client.AutoScribe.Users.RevokeAccess(
            new() { UserID = "usr_1234567890abcdef1234567890abcdef" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
