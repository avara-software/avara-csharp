using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.AutoScribe.Studies.External.Reports;

/// <summary>
/// Created or updated external report identifiers
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ReportCreateResponse, ReportCreateResponseFromRaw>))]
public sealed record class ReportCreateResponse : JsonModel
{
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExternalReportID;
        _ = this.StudyID;
        _ = this.StudyInstanceUid;
    }

    public ReportCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReportCreateResponse(ReportCreateResponse reportCreateResponse)
        : base(reportCreateResponse) { }
#pragma warning restore CS8618

    public ReportCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReportCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReportCreateResponseFromRaw.FromRawUnchecked"/>
    public static ReportCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReportCreateResponseFromRaw : IFromRawJson<ReportCreateResponse>
{
    /// <inheritdoc/>
    public ReportCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReportCreateResponse.FromRawUnchecked(rawData);
}
