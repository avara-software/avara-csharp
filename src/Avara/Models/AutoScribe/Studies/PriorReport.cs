using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.AutoScribe.Studies;

/// <summary>
/// External prior report metadata and text stored on a study
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PriorReport, PriorReportFromRaw>))]
public sealed record class PriorReport : JsonModel
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

    /// <summary>
    /// Integrator's external study identifier
    /// </summary>
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

    /// <summary>
    /// Imaging modality for the prior study
    /// </summary>
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
    /// Prior study date (YYYY-MM-DD)
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

    /// <summary>
    /// Description of the prior study
    /// </summary>
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

    public PriorReport() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PriorReport(PriorReport priorReport)
        : base(priorReport) { }
#pragma warning restore CS8618

    public PriorReport(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriorReport(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriorReportFromRaw.FromRawUnchecked"/>
    public static PriorReport FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PriorReport(string reportText)
        : this()
    {
        this.ReportText = reportText;
    }
}

class PriorReportFromRaw : IFromRawJson<PriorReport>
{
    /// <inheritdoc/>
    public PriorReport FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PriorReport.FromRawUnchecked(rawData);
}
