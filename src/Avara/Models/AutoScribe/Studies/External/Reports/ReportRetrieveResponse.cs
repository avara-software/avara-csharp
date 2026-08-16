using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.AutoScribe.Studies.External.Reports;

/// <summary>
/// External report snapshot including text and/or a presigned file URL
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ReportRetrieveResponse, ReportRetrieveResponseFromRaw>))]
public sealed record class ReportRetrieveResponse : JsonModel
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

    /// <summary>
    /// Short-lived download URL for the attached PDF or image. Not used for AI tooling;
    /// the reader can still access it.
    /// </summary>
    public string? PresignedUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("presignedUrl");
        }
        init { this._rawData.Set("presignedUrl", value); }
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

    /// <summary>
    /// When this study is used as a prior, report AI tools leverage this text directly.
    /// </summary>
    public string? ReportText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reportText");
        }
        init { this._rawData.Set("reportText", value); }
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

    /// <summary>
    /// Patient demographics and scan information for report generation
    /// </summary>
    public StudyReportMetadata? SnapshotMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<StudyReportMetadata>("snapshotMetadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("snapshotMetadata", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.ExternalReportID;
        _ = this.StudyID;
        _ = this.StudyInstanceUid;
        _ = this.PresignedUrl;
        _ = this.ReaderName;
        _ = this.ReportText;
        _ = this.SignedAt;
        this.SnapshotMetadata?.Validate();
    }

    public ReportRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReportRetrieveResponse(ReportRetrieveResponse reportRetrieveResponse)
        : base(reportRetrieveResponse) { }
#pragma warning restore CS8618

    public ReportRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReportRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReportRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ReportRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReportRetrieveResponseFromRaw : IFromRawJson<ReportRetrieveResponse>
{
    /// <inheritdoc/>
    public ReportRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReportRetrieveResponse.FromRawUnchecked(rawData);
}
