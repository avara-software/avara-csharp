using System;
using System.Text.Json;
using Avara.Core;
using Avara.Exceptions;
using Avara.Models.Viewer.Users;

namespace Avara.Tests.Models.Viewer.Users;

public class UserListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserListParams
        {
            Cursor = "eyJvZmZzZXQiOjIwfQ==",
            Email = "user@example.com",
            FirstName = "John",
            InvitedSource = InvitedSource.Api,
            LastName = "Doe",
            Level = UserListParamsLevel.Member,
            Limit = 20,
        };

        string expectedCursor = "eyJvZmZzZXQiOjIwfQ==";
        string expectedEmail = "user@example.com";
        string expectedFirstName = "John";
        ApiEnum<string, InvitedSource> expectedInvitedSource = InvitedSource.Api;
        string expectedLastName = "Doe";
        ApiEnum<string, UserListParamsLevel> expectedLevel = UserListParamsLevel.Member;
        double expectedLimit = 20;

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedEmail, parameters.Email);
        Assert.Equal(expectedFirstName, parameters.FirstName);
        Assert.Equal(expectedInvitedSource, parameters.InvitedSource);
        Assert.Equal(expectedLastName, parameters.LastName);
        Assert.Equal(expectedLevel, parameters.Level);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UserListParams { };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Email);
        Assert.False(parameters.RawQueryData.ContainsKey("email"));
        Assert.Null(parameters.FirstName);
        Assert.False(parameters.RawQueryData.ContainsKey("firstName"));
        Assert.Null(parameters.InvitedSource);
        Assert.False(parameters.RawQueryData.ContainsKey("invitedSource"));
        Assert.Null(parameters.LastName);
        Assert.False(parameters.RawQueryData.ContainsKey("lastName"));
        Assert.Null(parameters.Level);
        Assert.False(parameters.RawQueryData.ContainsKey("level"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UserListParams
        {
            // Null should be interpreted as omitted for these properties
            Cursor = null,
            Email = null,
            FirstName = null,
            InvitedSource = null,
            LastName = null,
            Level = null,
            Limit = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Email);
        Assert.False(parameters.RawQueryData.ContainsKey("email"));
        Assert.Null(parameters.FirstName);
        Assert.False(parameters.RawQueryData.ContainsKey("firstName"));
        Assert.Null(parameters.InvitedSource);
        Assert.False(parameters.RawQueryData.ContainsKey("invitedSource"));
        Assert.Null(parameters.LastName);
        Assert.False(parameters.RawQueryData.ContainsKey("lastName"));
        Assert.Null(parameters.Level);
        Assert.False(parameters.RawQueryData.ContainsKey("level"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        UserListParams parameters = new()
        {
            Cursor = "eyJvZmZzZXQiOjIwfQ==",
            Email = "user@example.com",
            FirstName = "John",
            InvitedSource = InvitedSource.Api,
            LastName = "Doe",
            Level = UserListParamsLevel.Member,
            Limit = 20,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.avarasoftware.com/v1/viewer/users?cursor=eyJvZmZzZXQiOjIwfQ%3d%3d&email=user%40example.com&firstName=John&invitedSource=api&lastName=Doe&level=member&limit=20"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserListParams
        {
            Cursor = "eyJvZmZzZXQiOjIwfQ==",
            Email = "user@example.com",
            FirstName = "John",
            InvitedSource = InvitedSource.Api,
            LastName = "Doe",
            Level = UserListParamsLevel.Member,
            Limit = 20,
        };

        UserListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class InvitedSourceTest : TestBase
{
    [Theory]
    [InlineData(InvitedSource.Dashboard)]
    [InlineData(InvitedSource.Api)]
    public void Validation_Works(InvitedSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitedSource> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvitedSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InvitedSource.Dashboard)]
    [InlineData(InvitedSource.Api)]
    public void SerializationRoundtrip_Works(InvitedSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitedSource> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InvitedSource>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvitedSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InvitedSource>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UserListParamsLevelTest : TestBase
{
    [Theory]
    [InlineData(UserListParamsLevel.Owner)]
    [InlineData(UserListParamsLevel.Admin)]
    [InlineData(UserListParamsLevel.Member)]
    public void Validation_Works(UserListParamsLevel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserListParamsLevel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserListParamsLevel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UserListParamsLevel.Owner)]
    [InlineData(UserListParamsLevel.Admin)]
    [InlineData(UserListParamsLevel.Member)]
    public void SerializationRoundtrip_Works(UserListParamsLevel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserListParamsLevel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserListParamsLevel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserListParamsLevel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserListParamsLevel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
