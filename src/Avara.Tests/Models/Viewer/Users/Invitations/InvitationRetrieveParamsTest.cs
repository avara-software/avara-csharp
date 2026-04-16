using System;
using Avara.Models.Viewer.Users.Invitations;

namespace Avara.Tests.Models.Viewer.Users.Invitations;

public class InvitationRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvitationRetrieveParams
        {
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
        };

        string expectedInvitationID = "inv_1234567890abcdef1234567890abcdef";

        Assert.Equal(expectedInvitationID, parameters.InvitationID);
    }

    [Fact]
    public void Url_Works()
    {
        InvitationRetrieveParams parameters = new()
        {
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.avarasoftware.com/v1/viewer/users/invitations/inv_1234567890abcdef1234567890abcdef"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InvitationRetrieveParams
        {
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
        };

        InvitationRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
