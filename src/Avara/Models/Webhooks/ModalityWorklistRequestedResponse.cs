using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.Webhooks;

/// <summary>
/// Response expected by Avara for modality worklist webhook. authorized:false surfaces
/// as worklist failure; authorized:true with empty items means no scheduled exams.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ModalityWorklistRequestedResponse,
        ModalityWorklistRequestedResponseFromRaw
    >)
)]
public sealed record class ModalityWorklistRequestedResponse : JsonModel
{
    /// <summary>
    /// Whether the worklist query is authorized
    /// </summary>
    public required bool Authorized
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("authorized");
        }
        init { this._rawData.Set("authorized", value); }
    }

    /// <summary>
    /// Worklist items for the requested date window
    /// </summary>
    public required IReadOnlyList<ModalityWorklistItem> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ModalityWorklistItem>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ModalityWorklistItem>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Error message if authorization failed
    /// </summary>
    public string? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("error", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Authorized;
        foreach (var item in this.Items)
        {
            item.Validate();
        }
        _ = this.Error;
    }

    public ModalityWorklistRequestedResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ModalityWorklistRequestedResponse(
        ModalityWorklistRequestedResponse modalityWorklistRequestedResponse
    )
        : base(modalityWorklistRequestedResponse) { }
#pragma warning restore CS8618

    public ModalityWorklistRequestedResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModalityWorklistRequestedResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ModalityWorklistRequestedResponseFromRaw.FromRawUnchecked"/>
    public static ModalityWorklistRequestedResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ModalityWorklistRequestedResponseFromRaw : IFromRawJson<ModalityWorklistRequestedResponse>
{
    /// <inheritdoc/>
    public ModalityWorklistRequestedResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ModalityWorklistRequestedResponse.FromRawUnchecked(rawData);
}
