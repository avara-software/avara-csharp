using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;
using Avara.Exceptions;

namespace Avara.Models.Webhooks;

/// <summary>
/// Soft synchronous webhook sent when AutoScribe needs clinical context from the
/// partner EHR. Failures / timeouts / invalid bodies are treated as empty enrichment.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ClinicalContextEnrichmentRequestedEvent,
        ClinicalContextEnrichmentRequestedEventFromRaw
    >)
)]
public sealed record class ClinicalContextEnrichmentRequestedEvent : JsonModel
{
    /// <summary>
    /// Unique webhook event ID. Format: whe_{32-hex-chars}
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Event payload for soft clinical context enrichment when AutoScribe needs
    /// EHR context for a study
    /// </summary>
    public required ClinicalContextEnrichmentRequestedEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ClinicalContextEnrichmentRequestedEventData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Event type identifier
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Data.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("clinical_context.enrichment_requested")
            )
        )
        {
            throw new AvaraInvalidDataException("Invalid value given for constant");
        }
    }

    public ClinicalContextEnrichmentRequestedEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("clinical_context.enrichment_requested");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClinicalContextEnrichmentRequestedEvent(
        ClinicalContextEnrichmentRequestedEvent clinicalContextEnrichmentRequestedEvent
    )
        : base(clinicalContextEnrichmentRequestedEvent) { }
#pragma warning restore CS8618

    public ClinicalContextEnrichmentRequestedEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("clinical_context.enrichment_requested");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClinicalContextEnrichmentRequestedEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ClinicalContextEnrichmentRequestedEventFromRaw.FromRawUnchecked"/>
    public static ClinicalContextEnrichmentRequestedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClinicalContextEnrichmentRequestedEventFromRaw
    : IFromRawJson<ClinicalContextEnrichmentRequestedEvent>
{
    /// <inheritdoc/>
    public ClinicalContextEnrichmentRequestedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ClinicalContextEnrichmentRequestedEvent.FromRawUnchecked(rawData);
}
