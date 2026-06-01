using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.AutoScribe.Reports;

/// <summary>
/// A radiology report in the AutoScribe system
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Report, ReportFromRaw>))]
public sealed record class Report : JsonModel
{
    /// <summary>
    /// Timestamp when the report was created
    /// </summary>
    public required DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// Whether this report is an addendum to a previous report
    /// </summary>
    public required bool IsAddendum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isAddendum");
        }
        init { this._rawData.Set("isAddendum", value); }
    }

    /// <summary>
    /// Whether the report was marked critical at sign-out. null when the report
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
    /// Timestamp when the report was signed, null if not yet signed
    /// </summary>
    public required DateTimeOffset? SignedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("signedAt");
        }
        init { this._rawData.Set("signedAt", value); }
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
    /// Status of an individual report. 'in_progress' = actively being dictated,
    /// 'completed' = signed.
    /// </summary>
    public required ApiEnum<string, ReportStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ReportStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
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
    /// Timestamp when the report was last updated
    /// </summary>
    public required DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    /// <summary>
    /// User ID of the radiologist who created/signed this report. Format: usr_{32-hex-chars}
    /// </summary>
    public required string UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("userId");
        }
        init { this._rawData.Set("userId", value); }
    }

    /// <summary>
    /// Plain text content of the report
    /// </summary>
    public string? ReportPlainText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reportPlainText");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("reportPlainText", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.IsAddendum;
        _ = this.IsCritical;
        _ = this.ReportID;
        _ = this.SignedAt;
        this.SnapshotMetadata.Validate();
        this.Status.Validate();
        _ = this.StudyID;
        _ = this.UpdatedAt;
        _ = this.UserID;
        _ = this.ReportPlainText;
    }

    public Report() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Report(Report report)
        : base(report) { }
#pragma warning restore CS8618

    public Report(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Report(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReportFromRaw.FromRawUnchecked"/>
    public static Report FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReportFromRaw : IFromRawJson<Report>
{
    /// <inheritdoc/>
    public Report FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Report.FromRawUnchecked(rawData);
}
