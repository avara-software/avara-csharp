using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.Webhooks;

/// <summary>
/// Event payload containing report and study information
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ReportDeliveredEventData, ReportDeliveredEventDataFromRaw>)
)]
public sealed record class ReportDeliveredEventData : JsonModel
{
    /// <summary>
    /// Whether the report was marked critical at sign-off.
    /// </summary>
    public required bool IsCritical
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isCritical");
        }
        init { this._rawData.Set("isCritical", value); }
    }

    /// <summary>
    /// Presigned URL for PDF download. Time-limited, typically valid for 1 hour.
    /// </summary>
    public required string PresignedUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("presignedUrl");
        }
        init { this._rawData.Set("presignedUrl", value); }
    }

    /// <summary>
    /// Avara report ID. Format: rep_{32-hex-chars}
    /// </summary>
    public required string ReportID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reportId");
        }
        init { this._rawData.Set("reportId", value); }
    }

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
    /// Report plain text content (optional). Contains the full report text.
    /// </summary>
    public string? PlainText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("plainText");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("plainText", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.IsCritical;
        _ = this.PresignedUrl;
        _ = this.ReportID;
        _ = this.StudyID;
        _ = this.StudyInstanceUid;
        _ = this.ExternalPatientID;
        _ = this.PlainText;
    }

    public ReportDeliveredEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReportDeliveredEventData(ReportDeliveredEventData reportDeliveredEventData)
        : base(reportDeliveredEventData) { }
#pragma warning restore CS8618

    public ReportDeliveredEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReportDeliveredEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReportDeliveredEventDataFromRaw.FromRawUnchecked"/>
    public static ReportDeliveredEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReportDeliveredEventDataFromRaw : IFromRawJson<ReportDeliveredEventData>
{
    /// <inheritdoc/>
    public ReportDeliveredEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReportDeliveredEventData.FromRawUnchecked(rawData);
}
