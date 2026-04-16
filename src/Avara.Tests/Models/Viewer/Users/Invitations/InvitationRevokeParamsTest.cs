using System;
using Avara.Models.Viewer.Users.Invitations;

namespace Avara.Tests.Models.Viewer.Users.Invitations;

public class InvitationRevokeParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvitationRevokeParams
        {
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            UserID = "usr_1234567890abcdef1234567890abcdef",
        };

        string expectedInvitationID = "inv_1234567890abcdef1234567890abcdef";
        string expectedUserID = "usr_1234567890abcdef1234567890abcdef";

        Assert.Equal(expectedInvitationID, parameters.InvitationID);
        Assert.Equal(expectedUserID, parameters.UserID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InvitationRevokeParams { };

        Assert.Null(parameters.InvitationID);
        Assert.False(parameters.RawBodyData.ContainsKey("invitationId"));
        Assert.Null(parameters.UserID);
        Assert.False(parameters.RawBodyData.ContainsKey("userId"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InvitationRevokeParams
        {
            // Null should be interpreted as omitted for these properties
            InvitationID = null,
            UserID = null,
        };

        Assert.Null(parameters.InvitationID);
        Assert.False(parameters.RawBodyData.ContainsKey("invitationId"));
        Assert.Null(parameters.UserID);
        Assert.False(parameters.RawBodyData.ContainsKey("userId"));
    }

    [Fact]
    public void Url_Works()
    {
        InvitationRevokeParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.avarasoftware.com/v1/viewer/users/invitations/revoke"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InvitationRevokeParams
        {
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            UserID = "usr_1234567890abcdef1234567890abcdef",
        };

        InvitationRevokeParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
