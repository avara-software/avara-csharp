using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;
using Avara.Exceptions;

namespace Avara.Models.Webhooks;

/// <summary>
/// Soft synchronous webhook sent after Avara PACS seeds a study so the partner can
/// enrich demographics and report headers. Failures / timeouts / invalid bodies are
/// treated as empty enrichment.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PatientStudyEnrichmentRequestedEvent,
        PatientStudyEnrichmentRequestedEventFromRaw
    >)
)]
public sealed record class PatientStudyEnrichmentRequestedEvent : JsonModel
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
    /// Event payload for soft patient/study enrichment after Avara PACS seeds a study
    /// </summary>
    public required PatientStudyEnrichmentRequestedEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PatientStudyEnrichmentRequestedEventData>("data");
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
                JsonSerializer.SerializeToElement("patient_study.enrichment_requested")
            )
        )
        {
            throw new AvaraInvalidDataException("Invalid value given for constant");
        }
    }

    public PatientStudyEnrichmentRequestedEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("patient_study.enrichment_requested");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PatientStudyEnrichmentRequestedEvent(
        PatientStudyEnrichmentRequestedEvent patientStudyEnrichmentRequestedEvent
    )
        : base(patientStudyEnrichmentRequestedEvent) { }
#pragma warning restore CS8618

    public PatientStudyEnrichmentRequestedEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("patient_study.enrichment_requested");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PatientStudyEnrichmentRequestedEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PatientStudyEnrichmentRequestedEventFromRaw.FromRawUnchecked"/>
    public static PatientStudyEnrichmentRequestedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PatientStudyEnrichmentRequestedEventFromRaw
    : IFromRawJson<PatientStudyEnrichmentRequestedEvent>
{
    /// <inheritdoc/>
    public PatientStudyEnrichmentRequestedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PatientStudyEnrichmentRequestedEvent.FromRawUnchecked(rawData);
}
