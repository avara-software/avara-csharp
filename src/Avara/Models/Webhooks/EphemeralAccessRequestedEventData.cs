using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.Webhooks;

/// <summary>
/// Event payload for an ephemeral viewer session. retrievalId is the customer handle
/// from mint. options is echoed verbatim when present; Avara does not read or edit it.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EphemeralAccessRequestedEventData,
        EphemeralAccessRequestedEventDataFromRaw
    >)
)]
public sealed record class EphemeralAccessRequestedEventData : JsonModel
{
    /// <summary>
    /// Opaque customer handle for this view session. Not an Avara study ID.
    /// </summary>
    public required string RetrievalID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("retrievalId");
        }
        init { this._rawData.Set("retrievalId", value); }
    }

    /// <summary>
    /// Optional JSON object echoed verbatim from mint. Avara does not read or edit
    /// it. Examples: studyInstanceUids or internal ids for multi-study reads. Not
    /// for URLs or manifests.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Options
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("options");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "options",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RetrievalID;
        _ = this.Options;
    }

    public EphemeralAccessRequestedEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EphemeralAccessRequestedEventData(
        EphemeralAccessRequestedEventData ephemeralAccessRequestedEventData
    )
        : base(ephemeralAccessRequestedEventData) { }
#pragma warning restore CS8618

    public EphemeralAccessRequestedEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EphemeralAccessRequestedEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EphemeralAccessRequestedEventDataFromRaw.FromRawUnchecked"/>
    public static EphemeralAccessRequestedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EphemeralAccessRequestedEventData(string retrievalID)
        : this()
    {
        this.RetrievalID = retrievalID;
    }
}

class EphemeralAccessRequestedEventDataFromRaw : IFromRawJson<EphemeralAccessRequestedEventData>
{
    /// <inheritdoc/>
    public EphemeralAccessRequestedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EphemeralAccessRequestedEventData.FromRawUnchecked(rawData);
}
