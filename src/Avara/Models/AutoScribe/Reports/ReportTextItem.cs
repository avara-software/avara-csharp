using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.AutoScribe.Reports;

/// <summary>
/// A report with its plain text content
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ReportTextItem, ReportTextItemFromRaw>))]
public sealed record class ReportTextItem : JsonModel
{
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

    /// <summary>
    /// Plain text content of the report
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
        _ = this.ReportID;
        this.SnapshotMetadata.Validate();
        _ = this.StudyID;
        _ = this.StudyInstanceUid;
        _ = this.PlainText;
    }

    public ReportTextItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReportTextItem(ReportTextItem reportTextItem)
        : base(reportTextItem) { }
#pragma warning restore CS8618

    public ReportTextItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReportTextItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReportTextItemFromRaw.FromRawUnchecked"/>
    public static ReportTextItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReportTextItemFromRaw : IFromRawJson<ReportTextItem>
{
    /// <inheritdoc/>
    public ReportTextItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ReportTextItem.FromRawUnchecked(rawData);
}
