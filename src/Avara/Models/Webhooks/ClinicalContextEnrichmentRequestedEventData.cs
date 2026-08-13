using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.Webhooks;

/// <summary>
/// Event payload for soft clinical context enrichment when AutoScribe needs EHR context
/// for a study
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ClinicalContextEnrichmentRequestedEventData,
        ClinicalContextEnrichmentRequestedEventDataFromRaw
    >)
)]
public sealed record class ClinicalContextEnrichmentRequestedEventData : JsonModel
{
    /// <summary>
    /// Clinic UUID
    /// </summary>
    public required string ClinicID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("clinicId");
        }
        init { this._rawData.Set("clinicId", value); }
    }

    /// <summary>
    /// Raw study UUID v4 (not branded stu_…)
    /// </summary>
    public required string StudyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("studyId");
        }
        init { this._rawData.Set("studyId", value); }
    }

    /// <summary>
    /// DICOM Study Instance UID
    /// </summary>
    public required string StudyInstanceUid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("studyInstanceUid");
        }
        init { this._rawData.Set("studyInstanceUid", value); }
    }

    /// <summary>
    /// External patient identifier when available
    /// </summary>
    public string? ExternalPatientID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("externalPatientId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("externalPatientId", value);
        }
    }

    /// <summary>
    /// Medical record number when available
    /// </summary>
    public string? Mrn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mrn");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mrn", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ClinicID;
        _ = this.StudyID;
        _ = this.StudyInstanceUid;
        _ = this.ExternalPatientID;
        _ = this.Mrn;
    }

    public ClinicalContextEnrichmentRequestedEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClinicalContextEnrichmentRequestedEventData(
        ClinicalContextEnrichmentRequestedEventData clinicalContextEnrichmentRequestedEventData
    )
        : base(clinicalContextEnrichmentRequestedEventData) { }
#pragma warning restore CS8618

    public ClinicalContextEnrichmentRequestedEventData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClinicalContextEnrichmentRequestedEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ClinicalContextEnrichmentRequestedEventDataFromRaw.FromRawUnchecked"/>
    public static ClinicalContextEnrichmentRequestedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClinicalContextEnrichmentRequestedEventDataFromRaw
    : IFromRawJson<ClinicalContextEnrichmentRequestedEventData>
{
    /// <inheritdoc/>
    public ClinicalContextEnrichmentRequestedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ClinicalContextEnrichmentRequestedEventData.FromRawUnchecked(rawData);
}
