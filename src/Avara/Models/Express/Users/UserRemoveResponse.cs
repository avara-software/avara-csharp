using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.Express.Users;

/// <summary>
/// Standard success response with optional message
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UserRemoveResponse, UserRemoveResponseFromRaw>))]
public sealed record class UserRemoveResponse : JsonModel
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

    public UserRemoveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserRemoveResponse(UserRemoveResponse userRemoveResponse)
        : base(userRemoveResponse) { }
#pragma warning restore CS8618

    public UserRemoveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserRemoveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserRemoveResponseFromRaw.FromRawUnchecked"/>
    public static UserRemoveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UserRemoveResponse(bool success)
        : this()
    {
        this.Success = success;
    }
}

class UserRemoveResponseFromRaw : IFromRawJson<UserRemoveResponse>
{
    /// <inheritdoc/>
    public UserRemoveResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserRemoveResponse.FromRawUnchecked(rawData);
}
