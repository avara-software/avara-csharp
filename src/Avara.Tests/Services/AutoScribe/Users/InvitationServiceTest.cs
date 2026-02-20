using System.Threading.Tasks;

namespace Avara.Tests.Services.AutoScribe.Users;

public class InvitationServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var invitation = await this.client.AutoScribe.Users.Invitations.Retrieve(
            "inv_1234567890abcdef1234567890abcdef",
            new(),
            TestContext.Current.CancellationToken
        );
        invitation.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var invitation = await this.client.AutoScribe.Users.Invitations.Update(
            "inv_1234567890abcdef1234567890abcdef",
            new(),
            TestContext.Current.CancellationToken
        );
        invitation.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.AutoScribe.Users.Invitations.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Revoke_Works()
    {
        var response = await this.client.AutoScribe.Users.Invitations.Revoke(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
