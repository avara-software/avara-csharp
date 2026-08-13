using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;
using Avara.Exceptions;

namespace Avara.Models.Webhooks;

/// <summary>
/// Webhook event sent when an on-prem modality issues a C-FIND MWL. This is a synchronous
/// webhook - you must respond with authorized + items within the request timeout.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ModalityWorklistRequestedEvent,
        ModalityWorklistRequestedEventFromRaw
    >)
)]
public sealed record class ModalityWorklistRequestedEvent : JsonModel
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
    /// Event payload for a modality worklist (C-FIND MWL) request
    /// </summary>
    public required ModalityWorklistRequestedEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ModalityWorklistRequestedEventData>("data");
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
                JsonSerializer.SerializeToElement("modality_worklist.requested")
            )
        )
        {
            throw new AvaraInvalidDataException("Invalid value given for constant");
        }
    }

    public ModalityWorklistRequestedEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("modality_worklist.requested");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ModalityWorklistRequestedEvent(
        ModalityWorklistRequestedEvent modalityWorklistRequestedEvent
    )
        : base(modalityWorklistRequestedEvent) { }
#pragma warning restore CS8618

    public ModalityWorklistRequestedEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("modality_worklist.requested");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModalityWorklistRequestedEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ModalityWorklistRequestedEventFromRaw.FromRawUnchecked"/>
    public static ModalityWorklistRequestedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ModalityWorklistRequestedEventFromRaw : IFromRawJson<ModalityWorklistRequestedEvent>
{
    /// <inheritdoc/>
    public ModalityWorklistRequestedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ModalityWorklistRequestedEvent.FromRawUnchecked(rawData);
}
