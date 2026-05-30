using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;
using Avara.Exceptions;

namespace Avara.Models.Webhooks;

/// <summary>
/// Webhook event sent when a report is completed. This is an asynchronous notification
/// - respond with a simple acknowledgment.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ReportDeliveredEvent, ReportDeliveredEventFromRaw>))]
public sealed record class ReportDeliveredEvent : JsonModel
{
    /// <summary>
    /// Unique webhook event ID. Format: whe_{32-hex-chars}
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Event payload containing report and study information
    /// </summary>
    public required ReportDeliveredEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ReportDeliveredEventData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Event type identifier
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Data.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("report.delivered")
            )
        )
        {
            throw new AvaraInvalidDataException("Invalid value given for constant");
        }
    }

    public ReportDeliveredEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("report.delivered");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReportDeliveredEvent(ReportDeliveredEvent reportDeliveredEvent)
        : base(reportDeliveredEvent) { }
#pragma warning restore CS8618

    public ReportDeliveredEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("report.delivered");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReportDeliveredEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReportDeliveredEventFromRaw.FromRawUnchecked"/>
    public static ReportDeliveredEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReportDeliveredEventFromRaw : IFromRawJson<ReportDeliveredEvent>
{
    /// <inheritdoc/>
    public ReportDeliveredEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReportDeliveredEvent.FromRawUnchecked(rawData);
}
