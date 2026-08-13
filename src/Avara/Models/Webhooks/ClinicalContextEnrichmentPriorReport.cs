using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.Webhooks;

/// <summary>
/// External prior report metadata and text for clinical context
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ClinicalContextEnrichmentPriorReport,
        ClinicalContextEnrichmentPriorReportFromRaw
    >)
)]
public sealed record class ClinicalContextEnrichmentPriorReport : JsonModel
{
    /// <summary>
    /// Full prior report text
    /// </summary>
    public required string ReportText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reportText");
        }
        init { this._rawData.Set("reportText", value); }
    }

    public string? ExternalStudyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("externalStudyId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("externalStudyId", value);
        }
    }

    public string? Modality
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("modality");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("modality", value);
        }
    }

    /// <summary>
    /// YYYY-MM-DD
    /// </summary>
    public string? StudyDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("studyDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("studyDate", value);
        }
    }

    public string? StudyDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("studyDescription");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("studyDescription", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ReportText;
        _ = this.ExternalStudyID;
        _ = this.Modality;
        _ = this.StudyDate;
        _ = this.StudyDescription;
    }

    public ClinicalContextEnrichmentPriorReport() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClinicalContextEnrichmentPriorReport(
        ClinicalContextEnrichmentPriorReport clinicalContextEnrichmentPriorReport
    )
        : base(clinicalContextEnrichmentPriorReport) { }
#pragma warning restore CS8618

    public ClinicalContextEnrichmentPriorReport(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClinicalContextEnrichmentPriorReport(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ClinicalContextEnrichmentPriorReportFromRaw.FromRawUnchecked"/>
    public static ClinicalContextEnrichmentPriorReport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ClinicalContextEnrichmentPriorReport(string reportText)
        : this()
    {
        this.ReportText = reportText;
    }
}

class ClinicalContextEnrichmentPriorReportFromRaw
    : IFromRawJson<ClinicalContextEnrichmentPriorReport>
{
    /// <inheritdoc/>
    public ClinicalContextEnrichmentPriorReport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ClinicalContextEnrichmentPriorReport.FromRawUnchecked(rawData);
}
