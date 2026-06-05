using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;
using Avara.Exceptions;

namespace Avara.Models.Webhooks;

/// <summary>
/// Webhook event sent when Avara needs presigned UPLOAD URLs for a secondary capture
/// DICOM. This is a synchronous webhook - you must respond with the upload URLs within
/// the request timeout.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SecondaryCaptureAccessRequestedEvent,
        SecondaryCaptureAccessRequestedEventFromRaw
    >)
)]
public sealed record class SecondaryCaptureAccessRequestedEvent : JsonModel
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
    /// Event payload containing study + (optional) series/SOP information for a
    /// secondary capture upload
    /// </summary>
    public required SecondaryCaptureAccessRequestedEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SecondaryCaptureAccessRequestedEventData>("data");
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
                JsonSerializer.SerializeToElement("secondary_capture.access_requested")
            )
        )
        {
            throw new AvaraInvalidDataException("Invalid value given for constant");
        }
    }

    public SecondaryCaptureAccessRequestedEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("secondary_capture.access_requested");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SecondaryCaptureAccessRequestedEvent(
        SecondaryCaptureAccessRequestedEvent secondaryCaptureAccessRequestedEvent
    )
        : base(secondaryCaptureAccessRequestedEvent) { }
#pragma warning restore CS8618

    public SecondaryCaptureAccessRequestedEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("secondary_capture.access_requested");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SecondaryCaptureAccessRequestedEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SecondaryCaptureAccessRequestedEventFromRaw.FromRawUnchecked"/>
    public static SecondaryCaptureAccessRequestedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SecondaryCaptureAccessRequestedEventFromRaw
    : IFromRawJson<SecondaryCaptureAccessRequestedEvent>
{
    /// <inheritdoc/>
    public SecondaryCaptureAccessRequestedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SecondaryCaptureAccessRequestedEvent.FromRawUnchecked(rawData);
}
