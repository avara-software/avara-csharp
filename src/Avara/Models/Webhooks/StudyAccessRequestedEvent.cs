using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;
using Avara.Exceptions;

namespace Avara.Models.Webhooks;

/// <summary>
/// Webhook event sent when Avara needs presigned URLs for DICOM images. This is a
/// synchronous webhook - you must respond with the URLs within the request timeout.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<StudyAccessRequestedEvent, StudyAccessRequestedEventFromRaw>)
)]
public sealed record class StudyAccessRequestedEvent : JsonModel
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
    /// Event payload containing study information
    /// </summary>
    public required StudyAccessRequestedEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<StudyAccessRequestedEventData>("data");
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
                JsonSerializer.SerializeToElement("study.access_requested")
            )
        )
        {
            throw new AvaraInvalidDataException("Invalid value given for constant");
        }
    }

    public StudyAccessRequestedEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("study.access_requested");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyAccessRequestedEvent(StudyAccessRequestedEvent studyAccessRequestedEvent)
        : base(studyAccessRequestedEvent) { }
#pragma warning restore CS8618

    public StudyAccessRequestedEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("study.access_requested");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyAccessRequestedEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StudyAccessRequestedEventFromRaw.FromRawUnchecked"/>
    public static StudyAccessRequestedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StudyAccessRequestedEventFromRaw : IFromRawJson<StudyAccessRequestedEvent>
{
    /// <inheritdoc/>
    public StudyAccessRequestedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StudyAccessRequestedEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Event payload containing study information
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<StudyAccessRequestedEventData, StudyAccessRequestedEventDataFromRaw>)
)]
public sealed record class StudyAccessRequestedEventData : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.StudyID;
        _ = this.StudyInstanceUid;
    }

    public StudyAccessRequestedEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyAccessRequestedEventData(
        StudyAccessRequestedEventData studyAccessRequestedEventData
    )
        : base(studyAccessRequestedEventData) { }
#pragma warning restore CS8618

    public StudyAccessRequestedEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyAccessRequestedEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StudyAccessRequestedEventDataFromRaw.FromRawUnchecked"/>
    public static StudyAccessRequestedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StudyAccessRequestedEventDataFromRaw : IFromRawJson<StudyAccessRequestedEventData>
{
    /// <inheritdoc/>
    public StudyAccessRequestedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StudyAccessRequestedEventData.FromRawUnchecked(rawData);
}
