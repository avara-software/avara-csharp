using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.AutoScribe.Reports;

/// <summary>
/// Response containing a list of reports for a study
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ReportListResponse, ReportListResponseFromRaw>))]
public sealed record class ReportListResponse : JsonModel
{
    /// <summary>
    /// Array of report objects with full details
    /// </summary>
    public required IReadOnlyList<Report> Reports
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Report>>("reports");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Report>>(
                "reports",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Study ID the reports belong to. Format: stu_{32-hex-chars}
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
        foreach (var item in this.Reports)
        {
            item.Validate();
        }
        _ = this.StudyID;
        _ = this.StudyInstanceUid;
    }

    public ReportListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReportListResponse(ReportListResponse reportListResponse)
        : base(reportListResponse) { }
#pragma warning restore CS8618

    public ReportListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReportListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReportListResponseFromRaw.FromRawUnchecked"/>
    public static ReportListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReportListResponseFromRaw : IFromRawJson<ReportListResponse>
{
    /// <inheritdoc/>
    public ReportListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ReportListResponse.FromRawUnchecked(rawData);
}

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
