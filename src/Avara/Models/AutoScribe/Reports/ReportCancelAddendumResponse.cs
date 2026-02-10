using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.AutoScribe.Reports;

/// <summary>
/// Response for cancelling a report addendum
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ReportCancelAddendumResponse, ReportCancelAddendumResponseFromRaw>)
)]
public sealed record class ReportCancelAddendumResponse : JsonModel
{
    public required bool Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Success;
        _ = this.Message;
    }

    public ReportCancelAddendumResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReportCancelAddendumResponse(ReportCancelAddendumResponse reportCancelAddendumResponse)
        : base(reportCancelAddendumResponse) { }
#pragma warning restore CS8618

    public ReportCancelAddendumResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReportCancelAddendumResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReportCancelAddendumResponseFromRaw.FromRawUnchecked"/>
    public static ReportCancelAddendumResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ReportCancelAddendumResponse(bool success)
        : this()
    {
        this.Success = success;
    }
}

class ReportCancelAddendumResponseFromRaw : IFromRawJson<ReportCancelAddendumResponse>
{
    /// <inheritdoc/>
    public ReportCancelAddendumResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReportCancelAddendumResponse.FromRawUnchecked(rawData);
}
