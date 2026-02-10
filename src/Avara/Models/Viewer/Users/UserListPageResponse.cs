using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.Viewer.Users;

/// <summary>
/// Paginated list of Viewer users
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UserListPageResponse, UserListPageResponseFromRaw>))]
public sealed record class UserListPageResponse : JsonModel
{
    public required bool HasMore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("hasMore");
        }
        init { this._rawData.Set("hasMore", value); }
    }

    public required IReadOnlyList<UserListResponse> Users
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<UserListResponse>>("users");
        }
        init
        {
            this._rawData.Set<ImmutableArray<UserListResponse>>(
                "users",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Cursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cursor", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HasMore;
        foreach (var item in this.Users)
        {
            item.Validate();
        }
        _ = this.Cursor;
    }

    public UserListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserListPageResponse(UserListPageResponse userListPageResponse)
        : base(userListPageResponse) { }
#pragma warning restore CS8618

    public UserListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserListPageResponseFromRaw.FromRawUnchecked"/>
    public static UserListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserListPageResponseFromRaw : IFromRawJson<UserListPageResponse>
{
    /// <inheritdoc/>
    public UserListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserListPageResponse.FromRawUnchecked(rawData);
}
