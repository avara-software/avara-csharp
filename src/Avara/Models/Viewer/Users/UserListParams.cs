using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;
using Avara.Exceptions;

namespace Avara.Models.Viewer.Users;

/// <summary>
/// Retrieves a paginated list of users with optional filtering by access level,
/// email, name, and invitation source. Returns up to 100 users per request.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class UserListParams : ParamsBase
{
    /// <summary>
    /// Base64 encoded cursor from previous response
    /// </summary>
    public string? Cursor
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("cursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("cursor", value);
        }
    }

    /// <summary>
    /// Filter by exact email match
    /// </summary>
    public string? Email
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("email", value);
        }
    }

    /// <summary>
    /// Filter by first name (contains match)
    /// </summary>
    public string? FirstName
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("firstName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("firstName", value);
        }
    }

    /// <summary>
    /// Filter by invitation source
    /// </summary>
    public ApiEnum<string, InvitedSource>? InvitedSource
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, InvitedSource>>(
                "invitedSource"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("invitedSource", value);
        }
    }

    /// <summary>
    /// Filter by last name (contains match)
    /// </summary>
    public string? LastName
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("lastName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("lastName", value);
        }
    }

    /// <summary>
    /// Filter by user level
    /// </summary>
    public ApiEnum<string, UserListParamsLevel>? Level
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, UserListParamsLevel>>(
                "level"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("level", value);
        }
    }

    /// <summary>
    /// Number of results to return (1-100)
    /// </summary>
    public double? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<double>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    public UserListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserListParams(UserListParams userListParams)
        : base(userListParams) { }
#pragma warning restore CS8618

    public UserListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static UserListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(UserListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/viewer/users")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// Filter by invitation source
/// </summary>
[JsonConverter(typeof(InvitedSourceConverter))]
public enum InvitedSource
{
    Dashboard,
    Api,
}

sealed class InvitedSourceConverter : JsonConverter<InvitedSource>
{
    public override InvitedSource Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dashboard" => InvitedSource.Dashboard,
            "api" => InvitedSource.Api,
            _ => (InvitedSource)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvitedSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvitedSource.Dashboard => "dashboard",
                InvitedSource.Api => "api",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Filter by user level
/// </summary>
[JsonConverter(typeof(UserListParamsLevelConverter))]
public enum UserListParamsLevel
{
    Owner,
    Admin,
    Member,
}

sealed class UserListParamsLevelConverter : JsonConverter<UserListParamsLevel>
{
    public override UserListParamsLevel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "owner" => UserListParamsLevel.Owner,
            "admin" => UserListParamsLevel.Admin,
            "member" => UserListParamsLevel.Member,
            _ => (UserListParamsLevel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserListParamsLevel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserListParamsLevel.Owner => "owner",
                UserListParamsLevel.Admin => "admin",
                UserListParamsLevel.Member => "member",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
