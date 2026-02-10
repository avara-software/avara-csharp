using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.AutoScribe.Users;

/// <summary>
/// Response for revoking user access in AutoScribe
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<UserRevokeAccessResponse, UserRevokeAccessResponseFromRaw>)
)]
public sealed record class UserRevokeAccessResponse : JsonModel
{
    public required bool Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Success;
        _ = this.Message;
    }

    public UserRevokeAccessResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserRevokeAccessResponse(UserRevokeAccessResponse userRevokeAccessResponse)
        : base(userRevokeAccessResponse) { }
#pragma warning restore CS8618

    public UserRevokeAccessResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserRevokeAccessResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserRevokeAccessResponseFromRaw.FromRawUnchecked"/>
    public static UserRevokeAccessResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UserRevokeAccessResponse(bool success)
        : this()
    {
        this.Success = success;
    }
}

class UserRevokeAccessResponseFromRaw : IFromRawJson<UserRevokeAccessResponse>
{
    /// <inheritdoc/>
    public UserRevokeAccessResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserRevokeAccessResponse.FromRawUnchecked(rawData);
}
