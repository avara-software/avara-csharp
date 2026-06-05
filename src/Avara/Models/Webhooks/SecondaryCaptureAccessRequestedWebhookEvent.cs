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
        SecondaryCaptureAccessRequestedWebhookEvent,
        SecondaryCaptureAccessRequestedWebhookEventFromRaw
    >)
)]
public sealed record class SecondaryCaptureAccessRequestedWebhookEvent : JsonModel
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
    public required SecondaryCaptureAccessRequestedWebhookEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SecondaryCaptureAccessRequestedWebhookEventData>(
                "data"
            );
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

    public SecondaryCaptureAccessRequestedWebhookEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("secondary_capture.access_requested");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SecondaryCaptureAccessRequestedWebhookEvent(
        SecondaryCaptureAccessRequestedWebhookEvent secondaryCaptureAccessRequestedWebhookEvent
    )
        : base(secondaryCaptureAccessRequestedWebhookEvent) { }
#pragma warning restore CS8618

    public SecondaryCaptureAccessRequestedWebhookEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("secondary_capture.access_requested");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SecondaryCaptureAccessRequestedWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SecondaryCaptureAccessRequestedWebhookEventFromRaw.FromRawUnchecked"/>
    public static SecondaryCaptureAccessRequestedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SecondaryCaptureAccessRequestedWebhookEventFromRaw
    : IFromRawJson<SecondaryCaptureAccessRequestedWebhookEvent>
{
    /// <inheritdoc/>
    public SecondaryCaptureAccessRequestedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SecondaryCaptureAccessRequestedWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Event payload containing study + (optional) series/SOP information for a secondary
/// capture upload
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SecondaryCaptureAccessRequestedWebhookEventData,
        SecondaryCaptureAccessRequestedWebhookEventDataFromRaw
    >)
)]
public sealed record class SecondaryCaptureAccessRequestedWebhookEventData : JsonModel
{
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
    /// DICOM Study Instance UID. Must be a valid DICOM UID format (e.g., '1.2.840.10008.5.1.4.1.1.2')
    /// </summary>
    public required string StudyInstanceUid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("studyInstanceUid");
        }
        init { this._rawData.Set("studyInstanceUid", value); }
    }

    /// <summary>
    /// DICOM Series Instance UID generated for the new secondary capture series (when available).
    /// </summary>
    public string? SeriesInstanceUid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("seriesInstanceUid");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("seriesInstanceUid", value);
        }
    }

    /// <summary>
    /// DICOM SOP Instance UID generated for the new secondary capture object (when available).
    /// </summary>
    public string? SopInstanceUid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sopInstanceUid");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sopInstanceUid", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.StudyID;
        _ = this.StudyInstanceUid;
        _ = this.SeriesInstanceUid;
        _ = this.SopInstanceUid;
    }

    public SecondaryCaptureAccessRequestedWebhookEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SecondaryCaptureAccessRequestedWebhookEventData(
        SecondaryCaptureAccessRequestedWebhookEventData secondaryCaptureAccessRequestedWebhookEventData
    )
        : base(secondaryCaptureAccessRequestedWebhookEventData) { }
#pragma warning restore CS8618

    public SecondaryCaptureAccessRequestedWebhookEventData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SecondaryCaptureAccessRequestedWebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SecondaryCaptureAccessRequestedWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static SecondaryCaptureAccessRequestedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SecondaryCaptureAccessRequestedWebhookEventDataFromRaw
    : IFromRawJson<SecondaryCaptureAccessRequestedWebhookEventData>
{
    /// <inheritdoc/>
    public SecondaryCaptureAccessRequestedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SecondaryCaptureAccessRequestedWebhookEventData.FromRawUnchecked(rawData);
}
