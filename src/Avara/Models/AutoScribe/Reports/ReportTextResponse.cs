using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;
using Avara.Exceptions;

namespace Avara.Models.AutoScribe.Reports;

/// <summary>
/// Response containing a single report with its plain text
/// </summary>
[JsonConverter(typeof(ReportTextResponseConverter))]
public record class ReportTextResponse : ModelBase
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

    public string StudyID
    {
        get { return Match(single: (x) => x.StudyID, listReports: (x) => x.StudyID); }
    }

    public string StudyInstanceUid
    {
        get
        {
            return Match(single: (x) => x.StudyInstanceUid, listReports: (x) => x.StudyInstanceUid);
        }
    }

    public ReportTextResponse(SingleReportTextResponse value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReportTextResponse(ListReportsTextResponse value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReportTextResponse(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SingleReportTextResponse"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSingle(out var value)) {
    ///     // `value` is of type `SingleReportTextResponse`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSingle([NotNullWhen(true)] out SingleReportTextResponse? value)
    {
        value = this.Value as SingleReportTextResponse;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ListReportsTextResponse"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickListReports(out var value)) {
    ///     // `value` is of type `ListReportsTextResponse`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickListReports([NotNullWhen(true)] out ListReportsTextResponse? value)
    {
        value = this.Value as ListReportsTextResponse;
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
    ///     (SingleReportTextResponse value) =&gt; {...},
    ///     (ListReportsTextResponse value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<SingleReportTextResponse> single,
        Action<ListReportsTextResponse> listReports
    )
    {
        switch (this.Value)
        {
            case SingleReportTextResponse value:
                single(value);
                break;
            case ListReportsTextResponse value:
                listReports(value);
                break;
            default:
                throw new AvaraInvalidDataException(
                    "Data did not match any variant of ReportTextResponse"
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
    ///     (SingleReportTextResponse value) =&gt; {...},
    ///     (ListReportsTextResponse value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<SingleReportTextResponse, T> single,
        Func<ListReportsTextResponse, T> listReports
    )
    {
        return this.Value switch
        {
            SingleReportTextResponse value => single(value),
            ListReportsTextResponse value => listReports(value),
            _ => throw new AvaraInvalidDataException(
                "Data did not match any variant of ReportTextResponse"
            ),
        };
    }

    public static implicit operator ReportTextResponse(SingleReportTextResponse value) =>
        new(value);

    public static implicit operator ReportTextResponse(ListReportsTextResponse value) => new(value);

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
                "Data did not match any variant of ReportTextResponse"
            );
        }
        this.Switch((single) => single.Validate(), (listReports) => listReports.Validate());
    }

    public virtual bool Equals(ReportTextResponse? other) =>
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
            SingleReportTextResponse _ => 0,
            ListReportsTextResponse _ => 1,
            _ => -1,
        };
    }
}

sealed class ReportTextResponseConverter : JsonConverter<ReportTextResponse>
{
    public override ReportTextResponse? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<SingleReportTextResponse>(
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

        try
        {
            var deserialized = JsonSerializer.Deserialize<ListReportsTextResponse>(
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

    public override void Write(
        Utf8JsonWriter writer,
        ReportTextResponse value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Response containing a single report with its plain text
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<SingleReportTextResponse, SingleReportTextResponseFromRaw>)
)]
public sealed record class SingleReportTextResponse : JsonModel
{
    /// <summary>
    /// Unique report identifier. Format: rep_{32-hex-chars}
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
    /// Patient demographics and scan information for report generation
    /// </summary>
    public required StudyReportMetadata SnapshotMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<StudyReportMetadata>("snapshotMetadata");
        }
        init { this._rawData.Set("snapshotMetadata", value); }
    }

    /// <summary>
    /// Study ID this report belongs to. Format: stu_{32-hex-chars}
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
    /// Plain text content of the report
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
        _ = this.ReportID;
        this.SnapshotMetadata.Validate();
        _ = this.StudyID;
        _ = this.StudyInstanceUid;
        _ = this.PlainText;
    }

    public SingleReportTextResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SingleReportTextResponse(SingleReportTextResponse singleReportTextResponse)
        : base(singleReportTextResponse) { }
#pragma warning restore CS8618

    public SingleReportTextResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SingleReportTextResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SingleReportTextResponseFromRaw.FromRawUnchecked"/>
    public static SingleReportTextResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SingleReportTextResponseFromRaw : IFromRawJson<SingleReportTextResponse>
{
    /// <inheritdoc/>
    public SingleReportTextResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SingleReportTextResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Response containing a list of reports with their plain text
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ListReportsTextResponse, ListReportsTextResponseFromRaw>))]
public sealed record class ListReportsTextResponse : JsonModel
{
    /// <summary>
    /// Array of report text items
    /// </summary>
    public required IReadOnlyList<ReportTextItem> Reports
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ReportTextItem>>("reports");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ReportTextItem>>(
                "reports",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Study ID the reports belong to. Format: stu_{32-hex-chars}
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
        foreach (var item in this.Reports)
        {
            item.Validate();
        }
        _ = this.StudyID;
        _ = this.StudyInstanceUid;
    }

    public ListReportsTextResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ListReportsTextResponse(ListReportsTextResponse listReportsTextResponse)
        : base(listReportsTextResponse) { }
#pragma warning restore CS8618

    public ListReportsTextResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ListReportsTextResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ListReportsTextResponseFromRaw.FromRawUnchecked"/>
    public static ListReportsTextResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ListReportsTextResponseFromRaw : IFromRawJson<ListReportsTextResponse>
{
    /// <inheritdoc/>
    public ListReportsTextResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ListReportsTextResponse.FromRawUnchecked(rawData);
}
