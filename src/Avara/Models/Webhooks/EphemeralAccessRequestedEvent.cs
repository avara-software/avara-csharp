using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;
using Avara.Exceptions;

namespace Avara.Models.Webhooks;

/// <summary>
/// Webhook event sent when Avara needs presigned URLs for an ephemeral viewer session.
/// This is a synchronous webhook — you must respond with the URLs within the request
/// timeout. There is no Avara study; use retrievalId (and optional options) to resolve images.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<EphemeralAccessRequestedEvent, EphemeralAccessRequestedEventFromRaw>)
)]
public sealed record class EphemeralAccessRequestedEvent : JsonModel
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
    /// Event payload for an ephemeral viewer session. retrievalId is the customer
    /// handle from mint. options is echoed verbatim when present; Avara does not
    /// read or edit it.
    /// </summary>
    public required EphemeralAccessRequestedEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EphemeralAccessRequestedEventData>("data");
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
                JsonSerializer.SerializeToElement("ephemeral.access_requested")
            )
        )
        {
            throw new AvaraInvalidDataException("Invalid value given for constant");
        }
    }

    public EphemeralAccessRequestedEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("ephemeral.access_requested");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EphemeralAccessRequestedEvent(
        EphemeralAccessRequestedEvent ephemeralAccessRequestedEvent
    )
        : base(ephemeralAccessRequestedEvent) { }
#pragma warning restore CS8618

    public EphemeralAccessRequestedEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("ephemeral.access_requested");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EphemeralAccessRequestedEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EphemeralAccessRequestedEventFromRaw.FromRawUnchecked"/>
    public static EphemeralAccessRequestedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EphemeralAccessRequestedEventFromRaw : IFromRawJson<EphemeralAccessRequestedEvent>
{
    /// <inheritdoc/>
    public EphemeralAccessRequestedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EphemeralAccessRequestedEvent.FromRawUnchecked(rawData);
}
