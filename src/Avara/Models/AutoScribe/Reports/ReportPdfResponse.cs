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
/// Response containing a single report with its PDF download URL
/// </summary>
[JsonConverter(typeof(ReportPdfResponseConverter))]
public record class ReportPdfResponse : ModelBase
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

    public ReportPdfResponse(SingleReportPdfResponse value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReportPdfResponse(ListReportsPdfResponse value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReportPdfResponse(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SingleReportPdfResponse"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSingle(out var value)) {
    ///     // `value` is of type `SingleReportPdfResponse`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSingle([NotNullWhen(true)] out SingleReportPdfResponse? value)
    {
        value = this.Value as SingleReportPdfResponse;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ListReportsPdfResponse"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickListReports(out var value)) {
    ///     // `value` is of type `ListReportsPdfResponse`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickListReports([NotNullWhen(true)] out ListReportsPdfResponse? value)
    {
        value = this.Value as ListReportsPdfResponse;
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
    ///     (SingleReportPdfResponse value) =&gt; {...},
    ///     (ListReportsPdfResponse value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<SingleReportPdfResponse> single,
        Action<ListReportsPdfResponse> listReports
    )
    {
        switch (this.Value)
        {
            case SingleReportPdfResponse value:
                single(value);
                break;
            case ListReportsPdfResponse value:
                listReports(value);
                break;
            default:
                throw new AvaraInvalidDataException(
                    "Data did not match any variant of ReportPdfResponse"
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
    ///     (SingleReportPdfResponse value) =&gt; {...},
    ///     (ListReportsPdfResponse value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<SingleReportPdfResponse, T> single,
        Func<ListReportsPdfResponse, T> listReports
    )
    {
        return this.Value switch
        {
            SingleReportPdfResponse value => single(value),
            ListReportsPdfResponse value => listReports(value),
            _ => throw new AvaraInvalidDataException(
                "Data did not match any variant of ReportPdfResponse"
            ),
        };
    }

    public static implicit operator ReportPdfResponse(SingleReportPdfResponse value) => new(value);

    public static implicit operator ReportPdfResponse(ListReportsPdfResponse value) => new(value);

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
                "Data did not match any variant of ReportPdfResponse"
            );
        }
        this.Switch((single) => single.Validate(), (listReports) => listReports.Validate());
    }

    public virtual bool Equals(ReportPdfResponse? other) =>
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
            SingleReportPdfResponse _ => 0,
            ListReportsPdfResponse _ => 1,
            _ => -1,
        };
    }
}

sealed class ReportPdfResponseConverter : JsonConverter<ReportPdfResponse>
{
    public override ReportPdfResponse? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<ListReportsPdfResponse>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<SingleReportPdfResponse>(
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
        ReportPdfResponse value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Response containing a single report with its PDF download URL
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SingleReportPdfResponse, SingleReportPdfResponseFromRaw>))]
public sealed record class SingleReportPdfResponse : JsonModel
{
    /// <summary>
    /// Whether the report was marked critical at sign-off. null when the report
    /// is not yet completed; true/false once completed.
    /// </summary>
    public required bool? IsCritical
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isCritical");
        }
        init { this._rawData.Set("isCritical", value); }
    }

    /// <summary>
    /// Time-limited presigned URL to download the PDF (expires after 1 hour)
    /// </summary>
    public required string PresignedUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("presignedUrl");
        }
        init { this._rawData.Set("presignedUrl", value); }
    }

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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.IsCritical;
        _ = this.PresignedUrl;
        _ = this.ReportID;
        this.SnapshotMetadata.Validate();
        _ = this.StudyID;
        _ = this.StudyInstanceUid;
    }

    public SingleReportPdfResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SingleReportPdfResponse(SingleReportPdfResponse singleReportPdfResponse)
        : base(singleReportPdfResponse) { }
#pragma warning restore CS8618

    public SingleReportPdfResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SingleReportPdfResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SingleReportPdfResponseFromRaw.FromRawUnchecked"/>
    public static SingleReportPdfResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SingleReportPdfResponseFromRaw : IFromRawJson<SingleReportPdfResponse>
{
    /// <inheritdoc/>
    public SingleReportPdfResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SingleReportPdfResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Response containing a list of reports with their PDF download URLs
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ListReportsPdfResponse, ListReportsPdfResponseFromRaw>))]
public sealed record class ListReportsPdfResponse : JsonModel
{
    /// <summary>
    /// Array of report PDF items with download URLs
    /// </summary>
    public required IReadOnlyList<ReportPdfItem> Reports
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ReportPdfItem>>("reports");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ReportPdfItem>>(
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

    public ListReportsPdfResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ListReportsPdfResponse(ListReportsPdfResponse listReportsPdfResponse)
        : base(listReportsPdfResponse) { }
#pragma warning restore CS8618

    public ListReportsPdfResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ListReportsPdfResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ListReportsPdfResponseFromRaw.FromRawUnchecked"/>
    public static ListReportsPdfResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ListReportsPdfResponseFromRaw : IFromRawJson<ListReportsPdfResponse>
{
    /// <inheritdoc/>
    public ListReportsPdfResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ListReportsPdfResponse.FromRawUnchecked(rawData);
}
