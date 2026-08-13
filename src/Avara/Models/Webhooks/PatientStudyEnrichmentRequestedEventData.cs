using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.Webhooks;

/// <summary>
/// Event payload for soft patient/study enrichment after Avara PACS seeds a study
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PatientStudyEnrichmentRequestedEventData,
        PatientStudyEnrichmentRequestedEventDataFromRaw
    >)
)]
public sealed record class PatientStudyEnrichmentRequestedEventData : JsonModel
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
    /// Accession number from DICOM when available
    /// </summary>
    public string? AccessionNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("accessionNumber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("accessionNumber", value);
        }
    }

    /// <summary>
    /// Patient ID from DICOM when available
    /// </summary>
    public string? PatientID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("patientId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("patientId", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ClinicID;
        _ = this.StudyInstanceUid;
        _ = this.AccessionNumber;
        _ = this.PatientID;
    }

    public PatientStudyEnrichmentRequestedEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PatientStudyEnrichmentRequestedEventData(
        PatientStudyEnrichmentRequestedEventData patientStudyEnrichmentRequestedEventData
    )
        : base(patientStudyEnrichmentRequestedEventData) { }
#pragma warning restore CS8618

    public PatientStudyEnrichmentRequestedEventData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PatientStudyEnrichmentRequestedEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PatientStudyEnrichmentRequestedEventDataFromRaw.FromRawUnchecked"/>
    public static PatientStudyEnrichmentRequestedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PatientStudyEnrichmentRequestedEventDataFromRaw
    : IFromRawJson<PatientStudyEnrichmentRequestedEventData>
{
    /// <inheritdoc/>
    public PatientStudyEnrichmentRequestedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PatientStudyEnrichmentRequestedEventData.FromRawUnchecked(rawData);
}
