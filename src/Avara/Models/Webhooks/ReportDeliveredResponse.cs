using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.Webhooks;

/// <summary>
/// Response expected by Avara for report delivery webhook. Simple acknowledgment.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ReportDeliveredResponse, ReportDeliveredResponseFromRaw>))]
public sealed record class ReportDeliveredResponse : JsonModel
{
    /// <summary>
    /// Acknowledgment of receipt. Return true to confirm delivery.
    /// </summary>
    public required bool Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Success;
    }

    public ReportDeliveredResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReportDeliveredResponse(ReportDeliveredResponse reportDeliveredResponse)
        : base(reportDeliveredResponse) { }
#pragma warning restore CS8618

    public ReportDeliveredResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReportDeliveredResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReportDeliveredResponseFromRaw.FromRawUnchecked"/>
    public static ReportDeliveredResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ReportDeliveredResponse(bool success)
        : this()
    {
        this.Success = success;
    }
}

class ReportDeliveredResponseFromRaw : IFromRawJson<ReportDeliveredResponse>
{
    /// <inheritdoc/>
    public ReportDeliveredResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReportDeliveredResponse.FromRawUnchecked(rawData);
}
