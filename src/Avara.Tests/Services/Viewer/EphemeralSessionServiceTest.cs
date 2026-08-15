using System.Threading.Tasks;

namespace Avara.Tests.Services.Viewer;

public class EphemeralSessionServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var ephemeralSession = await this.client.Viewer.EphemeralSessions.Create(
            new() { RetrievalID = "order-12345" },
            TestContext.Current.CancellationToken
        );
        ephemeralSession.Validate();
    }
}
