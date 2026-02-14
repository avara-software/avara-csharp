using System;
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
[JsonConverter(typeof(UnsafeUnwrapWebhookEventConverter))]
public record class UnsafeUnwrapWebhookEvent : ModelBase
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
        get { return Match(studyAccessRequested: (x) => x.ID, reportDelivered: (x) => x.ID); }
    }

    public JsonElement Type
    {
        get { return Match(studyAccessRequested: (x) => x.Type, reportDelivered: (x) => x.Type); }
    }

    public UnsafeUnwrapWebhookEvent(StudyAccessRequestedEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(ReportDeliveredEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="StudyAccessRequestedEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
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
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
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
    ///     (StudyAccessRequestedEvent value) => {...},
    ///     (ReportDeliveredEvent value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<StudyAccessRequestedEvent> studyAccessRequested,
        Action<ReportDeliveredEvent> reportDelivered
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
            default:
                throw new AvaraInvalidDataException(
                    "Data did not match any variant of UnsafeUnwrapWebhookEvent"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
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
    ///     (StudyAccessRequestedEvent value) => {...},
    ///     (ReportDeliveredEvent value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<StudyAccessRequestedEvent, T> studyAccessRequested,
        Func<ReportDeliveredEvent, T> reportDelivered
    )
    {
        return this.Value switch
        {
            StudyAccessRequestedEvent value => studyAccessRequested(value),
            ReportDeliveredEvent value => reportDelivered(value),
            _ => throw new AvaraInvalidDataException(
                "Data did not match any variant of UnsafeUnwrapWebhookEvent"
            ),
        };
    }

    public static implicit operator UnsafeUnwrapWebhookEvent(StudyAccessRequestedEvent value) =>
        new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(ReportDeliveredEvent value) =>
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
            throw new AvaraInvalidDataException(
                "Data did not match any variant of UnsafeUnwrapWebhookEvent"
            );
        }
        this.Switch(
            (studyAccessRequested) => studyAccessRequested.Validate(),
            (reportDelivered) => reportDelivered.Validate()
        );
    }

    public virtual bool Equals(UnsafeUnwrapWebhookEvent? other) =>
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
            _ => -1,
        };
    }
}

sealed class UnsafeUnwrapWebhookEventConverter : JsonConverter<UnsafeUnwrapWebhookEvent>
{
    public override UnsafeUnwrapWebhookEvent? Read(
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
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AvaraInvalidDataException)
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
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AvaraInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new UnsafeUnwrapWebhookEvent(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnsafeUnwrapWebhookEvent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
