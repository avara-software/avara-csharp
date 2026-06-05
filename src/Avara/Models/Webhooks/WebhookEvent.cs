using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;
using Avara.Exceptions;

namespace Avara.Models.Webhooks;

/// <summary>
/// Union of all Avara webhook event types. Use the 'type' field to discriminate between
/// event types. Events: study.access_requested (synchronous), report.delivered (asynchronous),
/// secondary_capture.access_requested (synchronous).
/// </summary>
[JsonConverter(typeof(WebhookEventConverter))]
public record class WebhookEvent : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string ID
    {
        get
        {
            return Match(
                studyAccessRequested: (x) => x.ID,
                reportDelivered: (x) => x.ID,
                secondaryCaptureAccessRequested: (x) => x.ID
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                studyAccessRequested: (x) => x.Type,
                reportDelivered: (x) => x.Type,
                secondaryCaptureAccessRequested: (x) => x.Type
            );
        }
    }

    public WebhookEvent(StudyAccessRequestedEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public WebhookEvent(ReportDeliveredEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public WebhookEvent(SecondaryCaptureAccessRequested value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public WebhookEvent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="StudyAccessRequestedEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickStudyAccessRequested(out var value)) {
    ///     // `value` is of type `StudyAccessRequestedEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickStudyAccessRequested(
        [NotNullWhen(true)] out StudyAccessRequestedEvent? value
    )
    {
        value = this.Value as StudyAccessRequestedEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ReportDeliveredEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickReportDelivered(out var value)) {
    ///     // `value` is of type `ReportDeliveredEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickReportDelivered([NotNullWhen(true)] out ReportDeliveredEvent? value)
    {
        value = this.Value as ReportDeliveredEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SecondaryCaptureAccessRequested"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSecondaryCaptureAccessRequested(out var value)) {
    ///     // `value` is of type `SecondaryCaptureAccessRequested`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSecondaryCaptureAccessRequested(
        [NotNullWhen(true)] out SecondaryCaptureAccessRequested? value
    )
    {
        value = this.Value as SecondaryCaptureAccessRequested;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="AvaraInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (StudyAccessRequestedEvent value) =&gt; {...},
    ///     (ReportDeliveredEvent value) =&gt; {...},
    ///     (SecondaryCaptureAccessRequested value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<StudyAccessRequestedEvent> studyAccessRequested,
        Action<ReportDeliveredEvent> reportDelivered,
        Action<SecondaryCaptureAccessRequested> secondaryCaptureAccessRequested
    )
    {
        switch (this.Value)
        {
            case StudyAccessRequestedEvent value:
                studyAccessRequested(value);
                break;
            case ReportDeliveredEvent value:
                reportDelivered(value);
                break;
            case SecondaryCaptureAccessRequested value:
                secondaryCaptureAccessRequested(value);
                break;
            default:
                throw new AvaraInvalidDataException(
                    "Data did not match any variant of WebhookEvent"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="AvaraInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (StudyAccessRequestedEvent value) =&gt; {...},
    ///     (ReportDeliveredEvent value) =&gt; {...},
    ///     (SecondaryCaptureAccessRequested value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<StudyAccessRequestedEvent, T> studyAccessRequested,
        Func<ReportDeliveredEvent, T> reportDelivered,
        Func<SecondaryCaptureAccessRequested, T> secondaryCaptureAccessRequested
    )
    {
        return this.Value switch
        {
            StudyAccessRequestedEvent value => studyAccessRequested(value),
            ReportDeliveredEvent value => reportDelivered(value),
            SecondaryCaptureAccessRequested value => secondaryCaptureAccessRequested(value),
            _ => throw new AvaraInvalidDataException(
                "Data did not match any variant of WebhookEvent"
            ),
        };
    }

    public static implicit operator WebhookEvent(StudyAccessRequestedEvent value) => new(value);

    public static implicit operator WebhookEvent(ReportDeliveredEvent value) => new(value);

    public static implicit operator WebhookEvent(SecondaryCaptureAccessRequested value) =>
        new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="AvaraInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new AvaraInvalidDataException("Data did not match any variant of WebhookEvent");
        }
        this.Switch(
            (studyAccessRequested) => studyAccessRequested.Validate(),
            (reportDelivered) => reportDelivered.Validate(),
            (secondaryCaptureAccessRequested) => secondaryCaptureAccessRequested.Validate()
        );
    }

    public virtual bool Equals(WebhookEvent? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            StudyAccessRequestedEvent _ => 0,
            ReportDeliveredEvent _ => 1,
            SecondaryCaptureAccessRequested _ => 2,
            _ => -1,
        };
    }
}

sealed class WebhookEventConverter : JsonConverter<WebhookEvent>
{
    public override WebhookEvent? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "study.access_requested":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<StudyAccessRequestedEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "report.delivered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ReportDeliveredEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "secondary_capture.access_requested":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SecondaryCaptureAccessRequested>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new WebhookEvent(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookEvent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Webhook event sent when Avara needs presigned UPLOAD URLs for a secondary capture
/// DICOM. This is a synchronous webhook - you must respond with the upload URLs within
/// the request timeout.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SecondaryCaptureAccessRequested,
        SecondaryCaptureAccessRequestedFromRaw
    >)
)]
public sealed record class SecondaryCaptureAccessRequested : JsonModel
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
                JsonSerializer.SerializeToElement("secondary_capture.access_requested")
            )
        )
        {
            throw new AvaraInvalidDataException("Invalid value given for constant");
        }
    }

    public SecondaryCaptureAccessRequested()
    {
        this.Type = JsonSerializer.SerializeToElement("secondary_capture.access_requested");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SecondaryCaptureAccessRequested(
        SecondaryCaptureAccessRequested secondaryCaptureAccessRequested
    )
        : base(secondaryCaptureAccessRequested) { }
#pragma warning restore CS8618

    public SecondaryCaptureAccessRequested(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("secondary_capture.access_requested");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SecondaryCaptureAccessRequested(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SecondaryCaptureAccessRequestedFromRaw.FromRawUnchecked"/>
    public static SecondaryCaptureAccessRequested FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SecondaryCaptureAccessRequestedFromRaw : IFromRawJson<SecondaryCaptureAccessRequested>
{
    /// <inheritdoc/>
    public SecondaryCaptureAccessRequested FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SecondaryCaptureAccessRequested.FromRawUnchecked(rawData);
}

/// <summary>
/// Event payload containing study + (optional) series/SOP information for a secondary
/// capture upload
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
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
