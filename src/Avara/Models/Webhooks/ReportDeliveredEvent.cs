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
    public required Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>("data");
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

/// <summary>
/// Event payload containing report and study information
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Presigned URL for PDF download. Time-limited, typically valid for 1 hour.
    /// </summary>
    public required string PresignedUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("presignedUrl");
        }
        init { this._rawData.Set("presignedUrl", value); }
    }

    /// <summary>
    /// Avara report ID. Format: rep_{32-hex-chars}
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
    /// Avara study ID. Format: stu_{32-hex-chars}
    /// </summary>
    public required string StudyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("studyId");
        }
        init { this._rawData.Set("studyId", value); }
    }

    /// <summary>
    /// Report plain text content (optional). Contains the full report text.
    /// </summary>
    public string? PlainText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("plainText");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("plainText", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PresignedUrl;
        _ = this.ReportID;
        _ = this.StudyID;
        _ = this.PlainText;
    }

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data(Data data)
        : base(data) { }
#pragma warning restore CS8618

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}
