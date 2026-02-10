using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.Viewer.Users.Invitations;

/// <summary>
/// Paginated list of Viewer invitations
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<InvitationListPageResponse, InvitationListPageResponseFromRaw>)
)]
public sealed record class InvitationListPageResponse : JsonModel
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

    public required IReadOnlyList<InvitationListResponse> Invitations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<InvitationListResponse>>(
                "invitations"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<InvitationListResponse>>(
                "invitations",
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
        foreach (var item in this.Invitations)
        {
            item.Validate();
        }
        _ = this.Cursor;
    }

    public InvitationListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvitationListPageResponse(InvitationListPageResponse invitationListPageResponse)
        : base(invitationListPageResponse) { }
#pragma warning restore CS8618

    public InvitationListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvitationListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvitationListPageResponseFromRaw.FromRawUnchecked"/>
    public static InvitationListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvitationListPageResponseFromRaw : IFromRawJson<InvitationListPageResponse>
{
    /// <inheritdoc/>
    public InvitationListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvitationListPageResponse.FromRawUnchecked(rawData);
}
