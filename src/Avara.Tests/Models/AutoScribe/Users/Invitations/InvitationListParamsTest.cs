using System;
using System.Collections.Generic;
using Avara.Core;
using Avara.Models;
using Avara.Models.AutoScribe.Users.Invitations;

namespace Avara.Tests.Models.AutoScribe.Users.Invitations;

public class InvitationListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvitationListParams
        {
            Cursor = "eyJvZmZzZXQiOjIwfQ==",
            EndDate = "2024-12-31",
            Expired = InvitationExpiredFilter.NotExpired,
            Limit = 20,
            StartDate = "2024-01-01",
            Status = [InvitationStatus.Sent],
            UserID = "usr_1234567890abcdef1234567890abcdef",
        };

        string expectedCursor = "eyJvZmZzZXQiOjIwfQ==";
        string expectedEndDate = "2024-12-31";
        ApiEnum<string, InvitationExpiredFilter> expectedExpired =
            InvitationExpiredFilter.NotExpired;
        double expectedLimit = 20;
        string expectedStartDate = "2024-01-01";
        List<ApiEnum<string, InvitationStatus>> expectedStatus = [InvitationStatus.Sent];
        string expectedUserID = "usr_1234567890abcdef1234567890abcdef";

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedEndDate, parameters.EndDate);
        Assert.Equal(expectedExpired, parameters.Expired);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedStartDate, parameters.StartDate);
        Assert.NotNull(parameters.Status);
        Assert.Equal(expectedStatus.Count, parameters.Status.Count);
        for (int i = 0; i < expectedStatus.Count; i++)
        {
            Assert.Equal(expectedStatus[i], parameters.Status[i]);
        }
        Assert.Equal(expectedUserID, parameters.UserID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InvitationListParams { };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.EndDate);
        Assert.False(parameters.RawQueryData.ContainsKey("endDate"));
        Assert.Null(parameters.Expired);
        Assert.False(parameters.RawQueryData.ContainsKey("expired"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.StartDate);
        Assert.False(parameters.RawQueryData.ContainsKey("startDate"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.UserID);
        Assert.False(parameters.RawQueryData.ContainsKey("userId"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InvitationListParams
        {
            // Null should be interpreted as omitted for these properties
            Cursor = null,
            EndDate = null,
            Expired = null,
            Limit = null,
            StartDate = null,
            Status = null,
            UserID = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.EndDate);
        Assert.False(parameters.RawQueryData.ContainsKey("endDate"));
        Assert.Null(parameters.Expired);
        Assert.False(parameters.RawQueryData.ContainsKey("expired"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.StartDate);
        Assert.False(parameters.RawQueryData.ContainsKey("startDate"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.UserID);
        Assert.False(parameters.RawQueryData.ContainsKey("userId"));
    }

    [Fact]
    public void Url_Works()
    {
        InvitationListParams parameters = new()
        {
            Cursor = "eyJvZmZzZXQiOjIwfQ==",
            EndDate = "2024-12-31",
            Expired = InvitationExpiredFilter.NotExpired,
            Limit = 20,
            StartDate = "2024-01-01",
            Status = [InvitationStatus.Sent],
            UserID = "usr_1234567890abcdef1234567890abcdef",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.avarasoftware.com/v1/autoScribe/users/invitations?cursor=eyJvZmZzZXQiOjIwfQ%3d%3d&endDate=2024-12-31&expired=not-expired&limit=20&startDate=2024-01-01&status=sent&userId=usr_1234567890abcdef1234567890abcdef"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InvitationListParams
        {
            Cursor = "eyJvZmZzZXQiOjIwfQ==",
            EndDate = "2024-12-31",
            Expired = InvitationExpiredFilter.NotExpired,
            Limit = 20,
            StartDate = "2024-01-01",
            Status = [InvitationStatus.Sent],
            UserID = "usr_1234567890abcdef1234567890abcdef",
        };

        InvitationListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
