using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;
using Avara.Exceptions;

namespace Avara.Models.Webhooks;

/// <summary>
/// Union of all Avara webhook event types. Use the 'type' field to discriminate between
/// event types. Events: study.access_requested (synchronous), ephemeral.access_requested
/// (synchronous), report.delivered (asynchronous), secondary_capture.access_requested
/// (synchronous), modality_worklist.requested (synchronous), patient_study.enrichment_requested
/// (synchronous soft), clinical_context.enrichment_requested (synchronous soft).
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
                ephemeralAccessRequested: (x) => x.ID,
                reportDelivered: (x) => x.ID,
                secondaryCaptureAccessRequested: (x) => x.ID,
                modalityWorklistRequested: (x) => x.ID,
                patientStudyEnrichmentRequested: (x) => x.ID,
                clinicalContextEnrichmentRequested: (x) => x.ID
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                studyAccessRequested: (x) => x.Type,
                ephemeralAccessRequested: (x) => x.Type,
                reportDelivered: (x) => x.Type,
                secondaryCaptureAccessRequested: (x) => x.Type,
                modalityWorklistRequested: (x) => x.Type,
                patientStudyEnrichmentRequested: (x) => x.Type,
                clinicalContextEnrichmentRequested: (x) => x.Type
            );
        }
    }

    public WebhookEvent(StudyAccessRequestedEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public WebhookEvent(EphemeralAccessRequestedEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public WebhookEvent(ReportDeliveredEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public WebhookEvent(SecondaryCaptureAccessRequestedEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public WebhookEvent(ModalityWorklistRequestedEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public WebhookEvent(PatientStudyEnrichmentRequestedEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public WebhookEvent(ClinicalContextEnrichmentRequestedEvent value, JsonElement? element = null)
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
    /// type <see cref="EphemeralAccessRequestedEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEphemeralAccessRequested(out var value)) {
    ///     // `value` is of type `EphemeralAccessRequestedEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEphemeralAccessRequested(
        [NotNullWhen(true)] out EphemeralAccessRequestedEvent? value
    )
    {
        value = this.Value as EphemeralAccessRequestedEvent;
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
    /// type <see cref="SecondaryCaptureAccessRequestedEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSecondaryCaptureAccessRequested(out var value)) {
    ///     // `value` is of type `SecondaryCaptureAccessRequestedEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSecondaryCaptureAccessRequested(
        [NotNullWhen(true)] out SecondaryCaptureAccessRequestedEvent? value
    )
    {
        value = this.Value as SecondaryCaptureAccessRequestedEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ModalityWorklistRequestedEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickModalityWorklistRequested(out var value)) {
    ///     // `value` is of type `ModalityWorklistRequestedEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickModalityWorklistRequested(
        [NotNullWhen(true)] out ModalityWorklistRequestedEvent? value
    )
    {
        value = this.Value as ModalityWorklistRequestedEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PatientStudyEnrichmentRequestedEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPatientStudyEnrichmentRequested(out var value)) {
    ///     // `value` is of type `PatientStudyEnrichmentRequestedEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPatientStudyEnrichmentRequested(
        [NotNullWhen(true)] out PatientStudyEnrichmentRequestedEvent? value
    )
    {
        value = this.Value as PatientStudyEnrichmentRequestedEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ClinicalContextEnrichmentRequestedEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickClinicalContextEnrichmentRequested(out var value)) {
    ///     // `value` is of type `ClinicalContextEnrichmentRequestedEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickClinicalContextEnrichmentRequested(
        [NotNullWhen(true)] out ClinicalContextEnrichmentRequestedEvent? value
    )
    {
        value = this.Value as ClinicalContextEnrichmentRequestedEvent;
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
    ///     (EphemeralAccessRequestedEvent value) =&gt; {...},
    ///     (ReportDeliveredEvent value) =&gt; {...},
    ///     (SecondaryCaptureAccessRequestedEvent value) =&gt; {...},
    ///     (ModalityWorklistRequestedEvent value) =&gt; {...},
    ///     (PatientStudyEnrichmentRequestedEvent value) =&gt; {...},
    ///     (ClinicalContextEnrichmentRequestedEvent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<StudyAccessRequestedEvent> studyAccessRequested,
        Action<EphemeralAccessRequestedEvent> ephemeralAccessRequested,
        Action<ReportDeliveredEvent> reportDelivered,
        Action<SecondaryCaptureAccessRequestedEvent> secondaryCaptureAccessRequested,
        Action<ModalityWorklistRequestedEvent> modalityWorklistRequested,
        Action<PatientStudyEnrichmentRequestedEvent> patientStudyEnrichmentRequested,
        Action<ClinicalContextEnrichmentRequestedEvent> clinicalContextEnrichmentRequested
    )
    {
        switch (this.Value)
        {
            case StudyAccessRequestedEvent value:
                studyAccessRequested(value);
                break;
            case EphemeralAccessRequestedEvent value:
                ephemeralAccessRequested(value);
                break;
            case ReportDeliveredEvent value:
                reportDelivered(value);
                break;
            case SecondaryCaptureAccessRequestedEvent value:
                secondaryCaptureAccessRequested(value);
                break;
            case ModalityWorklistRequestedEvent value:
                modalityWorklistRequested(value);
                break;
            case PatientStudyEnrichmentRequestedEvent value:
                patientStudyEnrichmentRequested(value);
                break;
            case ClinicalContextEnrichmentRequestedEvent value:
                clinicalContextEnrichmentRequested(value);
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
    ///     (EphemeralAccessRequestedEvent value) =&gt; {...},
    ///     (ReportDeliveredEvent value) =&gt; {...},
    ///     (SecondaryCaptureAccessRequestedEvent value) =&gt; {...},
    ///     (ModalityWorklistRequestedEvent value) =&gt; {...},
    ///     (PatientStudyEnrichmentRequestedEvent value) =&gt; {...},
    ///     (ClinicalContextEnrichmentRequestedEvent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<StudyAccessRequestedEvent, T> studyAccessRequested,
        Func<EphemeralAccessRequestedEvent, T> ephemeralAccessRequested,
        Func<ReportDeliveredEvent, T> reportDelivered,
        Func<SecondaryCaptureAccessRequestedEvent, T> secondaryCaptureAccessRequested,
        Func<ModalityWorklistRequestedEvent, T> modalityWorklistRequested,
        Func<PatientStudyEnrichmentRequestedEvent, T> patientStudyEnrichmentRequested,
        Func<ClinicalContextEnrichmentRequestedEvent, T> clinicalContextEnrichmentRequested
    )
    {
        return this.Value switch
        {
            StudyAccessRequestedEvent value => studyAccessRequested(value),
            EphemeralAccessRequestedEvent value => ephemeralAccessRequested(value),
            ReportDeliveredEvent value => reportDelivered(value),
            SecondaryCaptureAccessRequestedEvent value => secondaryCaptureAccessRequested(value),
            ModalityWorklistRequestedEvent value => modalityWorklistRequested(value),
            PatientStudyEnrichmentRequestedEvent value => patientStudyEnrichmentRequested(value),
            ClinicalContextEnrichmentRequestedEvent value => clinicalContextEnrichmentRequested(
                value
            ),
            _ => throw new AvaraInvalidDataException(
                "Data did not match any variant of WebhookEvent"
            ),
        };
    }

    public static implicit operator WebhookEvent(StudyAccessRequestedEvent value) => new(value);

    public static implicit operator WebhookEvent(EphemeralAccessRequestedEvent value) => new(value);

    public static implicit operator WebhookEvent(ReportDeliveredEvent value) => new(value);

    public static implicit operator WebhookEvent(SecondaryCaptureAccessRequestedEvent value) =>
        new(value);

    public static implicit operator WebhookEvent(ModalityWorklistRequestedEvent value) =>
        new(value);

    public static implicit operator WebhookEvent(PatientStudyEnrichmentRequestedEvent value) =>
        new(value);

    public static implicit operator WebhookEvent(ClinicalContextEnrichmentRequestedEvent value) =>
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
            (ephemeralAccessRequested) => ephemeralAccessRequested.Validate(),
            (reportDelivered) => reportDelivered.Validate(),
            (secondaryCaptureAccessRequested) => secondaryCaptureAccessRequested.Validate(),
            (modalityWorklistRequested) => modalityWorklistRequested.Validate(),
            (patientStudyEnrichmentRequested) => patientStudyEnrichmentRequested.Validate(),
            (clinicalContextEnrichmentRequested) => clinicalContextEnrichmentRequested.Validate()
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
            EphemeralAccessRequestedEvent _ => 1,
            ReportDeliveredEvent _ => 2,
            SecondaryCaptureAccessRequestedEvent _ => 3,
            ModalityWorklistRequestedEvent _ => 4,
            PatientStudyEnrichmentRequestedEvent _ => 5,
            ClinicalContextEnrichmentRequestedEvent _ => 6,
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
            case "ephemeral.access_requested":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<EphemeralAccessRequestedEvent>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<SecondaryCaptureAccessRequestedEvent>(
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
            case "modality_worklist.requested":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ModalityWorklistRequestedEvent>(
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
            case "patient_study.enrichment_requested":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<PatientStudyEnrichmentRequestedEvent>(
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
            case "clinical_context.enrichment_requested":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<ClinicalContextEnrichmentRequestedEvent>(
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
