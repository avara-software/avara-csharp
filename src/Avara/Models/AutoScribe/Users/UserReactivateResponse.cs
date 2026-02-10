using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.AutoScribe.Users;

/// <summary>
/// Response for reactivating a user in AutoScribe
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UserReactivateResponse, UserReactivateResponseFromRaw>))]
public sealed record class UserReactivateResponse : JsonModel
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

    public UserReactivateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserReactivateResponse(UserReactivateResponse userReactivateResponse)
        : base(userReactivateResponse) { }
#pragma warning restore CS8618

    public UserReactivateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserReactivateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserReactivateResponseFromRaw.FromRawUnchecked"/>
    public static UserReactivateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UserReactivateResponse(bool success)
        : this()
    {
        this.Success = success;
    }
}

class UserReactivateResponseFromRaw : IFromRawJson<UserReactivateResponse>
{
    /// <inheritdoc/>
    public UserReactivateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserReactivateResponse.FromRawUnchecked(rawData);
}
