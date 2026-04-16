using System;
using System.Collections.Generic;
using System.Text.Json;
using Avara.Core;
using Avara.Exceptions;
using Avara.Models.Viewer.Users.Invitations;

namespace Avara.Tests.Models.Viewer.Users.Invitations;

public class InvitationListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvitationListParams
        {
            Cursor = "eyJvZmZzZXQiOjIwfQ==",
            EndDate = "2024-12-31",
            Expired = Expired.NotExpired,
            Limit = 20,
            StartDate = "2024-01-01",
            Status = [Status.Sent],
            UserID = "usr_1234567890abcdef1234567890abcdef",
        };

        string expectedCursor = "eyJvZmZzZXQiOjIwfQ==";
        string expectedEndDate = "2024-12-31";
        ApiEnum<string, Expired> expectedExpired = Expired.NotExpired;
        double expectedLimit = 20;
        string expectedStartDate = "2024-01-01";
        List<ApiEnum<string, Status>> expectedStatus = [Status.Sent];
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
            Expired = Expired.NotExpired,
            Limit = 20,
            StartDate = "2024-01-01",
            Status = [Status.Sent],
            UserID = "usr_1234567890abcdef1234567890abcdef",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.avarasoftware.com/v1/viewer/users/invitations?cursor=eyJvZmZzZXQiOjIwfQ%3d%3d&endDate=2024-12-31&expired=not-expired&limit=20&startDate=2024-01-01&status=sent&userId=usr_1234567890abcdef1234567890abcdef"
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
            Expired = Expired.NotExpired,
            Limit = 20,
            StartDate = "2024-01-01",
            Status = [Status.Sent],
            UserID = "usr_1234567890abcdef1234567890abcdef",
        };

        InvitationListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ExpiredTest : TestBase
{
    [Theory]
    [InlineData(Expired.All)]
    [InlineData(Expired.Expired1)]
    [InlineData(Expired.NotExpired)]
    public void Validation_Works(Expired rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Expired> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Expired>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Expired.All)]
    [InlineData(Expired.Expired1)]
    [InlineData(Expired.NotExpired)]
    public void SerializationRoundtrip_Works(Expired rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Expired> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Expired>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Expired>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Expired>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Sent)]
    [InlineData(Status.Accepted)]
    [InlineData(Status.Rejected)]
    [InlineData(Status.Revoked)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Sent)]
    [InlineData(Status.Accepted)]
    [InlineData(Status.Rejected)]
    [InlineData(Status.Revoked)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
