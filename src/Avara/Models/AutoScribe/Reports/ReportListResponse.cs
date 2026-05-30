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
