using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.AutoScribe.Reports;

/// <summary>
/// Response for creating a report addendum
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ReportAddendumResponse, ReportAddendumResponseFromRaw>))]
public sealed record class ReportAddendumResponse : JsonModel
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

    public ReportAddendumResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReportAddendumResponse(ReportAddendumResponse reportAddendumResponse)
        : base(reportAddendumResponse) { }
#pragma warning restore CS8618

    public ReportAddendumResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReportAddendumResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReportAddendumResponseFromRaw.FromRawUnchecked"/>
    public static ReportAddendumResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ReportAddendumResponse(bool success)
        : this()
    {
        this.Success = success;
    }
}

class ReportAddendumResponseFromRaw : IFromRawJson<ReportAddendumResponse>
{
    /// <inheritdoc/>
    public ReportAddendumResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReportAddendumResponse.FromRawUnchecked(rawData);
}
