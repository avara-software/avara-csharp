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
[JsonConverter(typeof(JsonModelConverter<UserAddResponse, UserAddResponseFromRaw>))]
public sealed record class UserAddResponse : JsonModel
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

    public UserAddResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserAddResponse(UserAddResponse userAddResponse)
        : base(userAddResponse) { }
#pragma warning restore CS8618

    public UserAddResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserAddResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserAddResponseFromRaw.FromRawUnchecked"/>
    public static UserAddResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UserAddResponse(bool success)
        : this()
    {
        this.Success = success;
    }
}

class UserAddResponseFromRaw : IFromRawJson<UserAddResponse>
{
    /// <inheritdoc/>
    public UserAddResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserAddResponse.FromRawUnchecked(rawData);
}
