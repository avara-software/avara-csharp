using System.Threading.Tasks;

namespace Avara.Tests.Services.Express;

public class UserServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Add_Works()
    {
        var response = await this.client.Express.Users.Add(
            "cus_1234567890abcdef1234567890abcdef",
            new() { UserID = "usr_1234567890abcdef1234567890abcdef" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Remove_Works()
    {
        var user = await this.client.Express.Users.Remove(
            "cus_1234567890abcdef1234567890abcdef",
            new() { UserID = "usr_1234567890abcdef1234567890abcdef" },
            TestContext.Current.CancellationToken
        );
        user.Validate();
    }
}
