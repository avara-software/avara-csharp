using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.Webhooks;

/// <summary>
/// Event payload containing study + (optional) series/SOP information for a secondary
/// capture upload
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SecondaryCaptureAccessRequestedEventData,
        SecondaryCaptureAccessRequestedEventDataFromRaw
    >)
)]
public sealed record class SecondaryCaptureAccessRequestedEventData : JsonModel
{
    /// <summary>
    /// Avara study ID. Format: stu_{32-hex-chars}
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
    /// DICOM Study Instance UID. Must be a valid DICOM UID format (e.g., '1.2.840.10008.5.1.4.1.1.2')
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
    /// DICOM Series Instance UID generated for the new secondary capture series (when available).
    /// </summary>
    public string? SeriesInstanceUid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("seriesInstanceUid");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("seriesInstanceUid", value);
        }
    }

    /// <summary>
    /// DICOM SOP Instance UID generated for the new secondary capture object (when available).
    /// </summary>
    public string? SopInstanceUid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sopInstanceUid");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sopInstanceUid", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.StudyID;
        _ = this.StudyInstanceUid;
        _ = this.SeriesInstanceUid;
        _ = this.SopInstanceUid;
    }

    public SecondaryCaptureAccessRequestedEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SecondaryCaptureAccessRequestedEventData(
        SecondaryCaptureAccessRequestedEventData secondaryCaptureAccessRequestedEventData
    )
        : base(secondaryCaptureAccessRequestedEventData) { }
#pragma warning restore CS8618

    public SecondaryCaptureAccessRequestedEventData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SecondaryCaptureAccessRequestedEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SecondaryCaptureAccessRequestedEventDataFromRaw.FromRawUnchecked"/>
    public static SecondaryCaptureAccessRequestedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SecondaryCaptureAccessRequestedEventDataFromRaw
    : IFromRawJson<SecondaryCaptureAccessRequestedEventData>
{
    /// <inheritdoc/>
    public SecondaryCaptureAccessRequestedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SecondaryCaptureAccessRequestedEventData.FromRawUnchecked(rawData);
}
