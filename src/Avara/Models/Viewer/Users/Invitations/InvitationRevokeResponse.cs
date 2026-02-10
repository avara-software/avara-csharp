using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.Viewer.Users.Invitations;

/// <summary>
/// Response for revoking an invitation in Viewer
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<InvitationRevokeResponse, InvitationRevokeResponseFromRaw>)
)]
public sealed record class InvitationRevokeResponse : JsonModel
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

    public InvitationRevokeResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvitationRevokeResponse(InvitationRevokeResponse invitationRevokeResponse)
        : base(invitationRevokeResponse) { }
#pragma warning restore CS8618

    public InvitationRevokeResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvitationRevokeResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvitationRevokeResponseFromRaw.FromRawUnchecked"/>
    public static InvitationRevokeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public InvitationRevokeResponse(bool success)
        : this()
    {
        this.Success = success;
    }
}

class InvitationRevokeResponseFromRaw : IFromRawJson<InvitationRevokeResponse>
{
    /// <inheritdoc/>
    public InvitationRevokeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvitationRevokeResponse.FromRawUnchecked(rawData);
}
