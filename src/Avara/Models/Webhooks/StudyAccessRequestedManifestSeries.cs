using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;
using Avara.Exceptions;

namespace Avara.Models.Webhooks;

/// <summary>
/// One series in the optional study manifest. Secondary capture should be omitted.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        StudyAccessRequestedManifestSeries,
        StudyAccessRequestedManifestSeriesFromRaw
    >)
)]
public sealed record class StudyAccessRequestedManifestSeries : JsonModel
{
    /// <summary>
    /// DICOM modality (e.g. CT, MR)
    /// </summary>
    public required string Modality
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("modality");
        }
        init { this._rawData.Set("modality", value); }
    }

    /// <summary>
    /// Series description shown in the viewer sidebar
    /// </summary>
    public required string SeriesDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("seriesDescription");
        }
        init { this._rawData.Set("seriesDescription", value); }
    }

    /// <summary>
    /// DICOM Series Instance UID
    /// </summary>
    public required string SeriesInstanceUid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("seriesInstanceUID");
        }
        init { this._rawData.Set("seriesInstanceUID", value); }
    }

    /// <summary>
    /// Series number (string or number)
    /// </summary>
    public required SeriesNumber SeriesNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SeriesNumber>("seriesNumber");
        }
        init { this._rawData.Set("seriesNumber", value); }
    }

    public required IReadOnlyList<StudyAccessRequestedManifestSop> Sops
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<StudyAccessRequestedManifestSop>>(
                "sops"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<StudyAccessRequestedManifestSop>>(
                "sops",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Modality;
        _ = this.SeriesDescription;
        _ = this.SeriesInstanceUid;
        this.SeriesNumber.Validate();
        foreach (var item in this.Sops)
        {
            item.Validate();
        }
    }

    public StudyAccessRequestedManifestSeries() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyAccessRequestedManifestSeries(
        StudyAccessRequestedManifestSeries studyAccessRequestedManifestSeries
    )
        : base(studyAccessRequestedManifestSeries) { }
#pragma warning restore CS8618

    public StudyAccessRequestedManifestSeries(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyAccessRequestedManifestSeries(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StudyAccessRequestedManifestSeriesFromRaw.FromRawUnchecked"/>
    public static StudyAccessRequestedManifestSeries FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StudyAccessRequestedManifestSeriesFromRaw : IFromRawJson<StudyAccessRequestedManifestSeries>
{
    /// <inheritdoc/>
    public StudyAccessRequestedManifestSeries FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StudyAccessRequestedManifestSeries.FromRawUnchecked(rawData);
}

/// <summary>
/// Series number (string or number)
/// </summary>
[JsonConverter(typeof(SeriesNumberConverter))]
public record class SeriesNumber : ModelBase
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

    public SeriesNumber(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SeriesNumber(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SeriesNumber(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
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
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<string> @string, Action<double> @double)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            default:
                throw new AvaraInvalidDataException(
                    "Data did not match any variant of SeriesNumber"
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
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<string, T> @string, Func<double, T> @double)
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            _ => throw new AvaraInvalidDataException(
                "Data did not match any variant of SeriesNumber"
            ),
        };
    }

    public static implicit operator SeriesNumber(string value) => new(value);

    public static implicit operator SeriesNumber(double value) => new(value);

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
            throw new AvaraInvalidDataException("Data did not match any variant of SeriesNumber");
        }
    }

    public virtual bool Equals(SeriesNumber? other) =>
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
            string _ => 0,
            double _ => 1,
            _ => -1,
        };
    }
}

sealed class SeriesNumberConverter : JsonConverter<SeriesNumber>
{
    public override SeriesNumber? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is AvaraInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is AvaraInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        SeriesNumber value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
