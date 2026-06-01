using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.AutoScribe.Reports;

/// <summary>
/// A report with its PDF download URL
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ReportPdfItem, ReportPdfItemFromRaw>))]
public sealed record class ReportPdfItem : JsonModel
{
    /// <summary>
    /// Whether the report was marked critical at sign-off. null when the report
    /// is not yet completed; true/false once completed.
    /// </summary>
    public required bool? IsCritical
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isCritical");
        }
        init { this._rawData.Set("isCritical", value); }
    }

    /// <summary>
    /// Time-limited presigned URL to download the PDF (expires after 1 hour)
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
    /// Unique report identifier. Format: rep_{32-hex-chars}
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
    /// Patient demographics and scan information for report generation
    /// </summary>
    public required StudyReportMetadata SnapshotMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<StudyReportMetadata>("snapshotMetadata");
        }
        init { this._rawData.Set("snapshotMetadata", value); }
    }

    /// <summary>
    /// Study ID this report belongs to. Format: stu_{32-hex-chars}
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.IsCritical;
        _ = this.PresignedUrl;
        _ = this.ReportID;
        this.SnapshotMetadata.Validate();
        _ = this.StudyID;
        _ = this.StudyInstanceUid;
    }

    public ReportPdfItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReportPdfItem(ReportPdfItem reportPdfItem)
        : base(reportPdfItem) { }
#pragma warning restore CS8618

    public ReportPdfItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReportPdfItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReportPdfItemFromRaw.FromRawUnchecked"/>
    public static ReportPdfItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReportPdfItemFromRaw : IFromRawJson<ReportPdfItem>
{
    /// <inheritdoc/>
    public ReportPdfItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ReportPdfItem.FromRawUnchecked(rawData);
}
