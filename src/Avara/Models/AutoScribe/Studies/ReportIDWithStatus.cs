using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.AutoScribe.Studies;

/// <summary>
/// A report ID paired with its current status
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ReportIDWithStatus, ReportIDWithStatusFromRaw>))]
public sealed record class ReportIDWithStatus : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.IsCritical;
        _ = this.ReportID;
        this.Status.Validate();
    }

    public ReportIDWithStatus() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReportIDWithStatus(ReportIDWithStatus reportIDWithStatus)
        : base(reportIDWithStatus) { }
#pragma warning restore CS8618

    public ReportIDWithStatus(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReportIDWithStatus(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReportIDWithStatusFromRaw.FromRawUnchecked"/>
    public static ReportIDWithStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReportIDWithStatusFromRaw : IFromRawJson<ReportIDWithStatus>
{
    /// <inheritdoc/>
    public ReportIDWithStatus FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ReportIDWithStatus.FromRawUnchecked(rawData);
}
