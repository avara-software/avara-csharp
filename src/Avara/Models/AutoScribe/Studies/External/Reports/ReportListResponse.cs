using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.AutoScribe.Studies.External.Reports;

[JsonConverter(typeof(JsonModelConverter<ReportListResponse, ReportListResponseFromRaw>))]
public sealed record class ReportListResponse : JsonModel
{
    public required DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    public required string ExternalReportID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("externalReportId");
        }
        init { this._rawData.Set("externalReportId", value); }
    }

    public required bool HasReportText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("hasReportText");
        }
        init { this._rawData.Set("hasReportText", value); }
    }

    public required bool ReportPdfPresent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("reportPdfPresent");
        }
        init { this._rawData.Set("reportPdfPresent", value); }
    }

    public required string StudyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("studyId");
        }
        init { this._rawData.Set("studyId", value); }
    }

    public required string StudyInstanceUid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("studyInstanceUid");
        }
        init { this._rawData.Set("studyInstanceUid", value); }
    }

    public string? ReaderName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("readerName");
        }
        init { this._rawData.Set("readerName", value); }
    }

    public string? SignedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("signedAt");
        }
        init { this._rawData.Set("signedAt", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.ExternalReportID;
        _ = this.HasReportText;
        _ = this.ReportPdfPresent;
        _ = this.StudyID;
        _ = this.StudyInstanceUid;
        _ = this.ReaderName;
        _ = this.SignedAt;
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
