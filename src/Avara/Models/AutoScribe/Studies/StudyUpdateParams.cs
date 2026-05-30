using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;
using Avara.Exceptions;

namespace Avara.Models.AutoScribe.Studies;

/// <summary>
/// Updates a study's properties including description, severity, assignment, organization,
/// metadata, and report metadata. All fields are optional - only provided fields
/// will be updated.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class StudyUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? StudyID { get; init; }

    /// <summary>
    /// User ID to assign the study to, or null to unassign. Format: usr_{32-hex-chars}
    /// </summary>
    public string? AssignedTo
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("assignedTo");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("assignedTo", value);
        }
    }

    /// <summary>
    /// Relevant clinical history for the patient/study. Null clears.
    /// </summary>
    public string? ClinicalHistory
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("clinicalHistory");
        }
        init { this._rawBodyData.Set("clinicalHistory", value); }
    }

    /// <summary>
    /// Clinical indication for the study. Null clears.
    /// </summary>
    public string? ClinicalIndication
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("clinicalIndication");
        }
        init { this._rawBodyData.Set("clinicalIndication", value); }
    }

    /// <summary>
    /// Express Customer ID for the study, or null to remove. Format: cus_{32-hex-chars}
    /// </summary>
    public string? ExpressCustomerID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("expressCustomerId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("expressCustomerId", value);
        }
    }

    /// <summary>
    /// Integrator-provided stable patient identifier used to link studies for the
    /// same patient. Null clears.
    /// </summary>
    public string? ExternalPatientID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("externalPatientId");
        }
        init { this._rawBodyData.Set("externalPatientId", value); }
    }

    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Imaging modality for the study (free text). Null clears.
    /// </summary>
    public string? Modality
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("modality");
        }
        init { this._rawBodyData.Set("modality", value); }
    }

    /// <summary>
    /// External prior reports (metadata + full report text) for comparison context.
    /// Null clears; an array replaces the existing set. Maximum 50 items
    /// </summary>
    public IReadOnlyList<StudyUpdateParamsPriorReport>? PriorReports
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<StudyUpdateParamsPriorReport>
            >("priorReports");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<StudyUpdateParamsPriorReport>?>(
                "priorReports",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ReportMetadata? ReportMetadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ReportMetadata>("reportMetadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("reportMetadata", value);
        }
    }

    /// <summary>
    /// Priority level of the study. 'normal' for routine, 'high' for urgent, 'stat'
    /// for immediate attention
    /// </summary>
    public ApiEnum<string, StudyUpdateParamsSeverity>? Severity
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, StudyUpdateParamsSeverity>>(
                "severity"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("severity", value);
        }
    }

    /// <summary>
    /// Description of the study/scan (e.g., 'Brain MRI with Contrast', 'Chest CT')
    /// </summary>
    public string? StudyDescription
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("studyDescription");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("studyDescription", value);
        }
    }

    /// <summary>
    /// Technologist notes for the study. Null clears; an array replaces the existing
    /// set. Maximum 50 items, each up to 1000 characters
    /// </summary>
    public IReadOnlyList<string>? TechnologistNotes
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("technologistNotes");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "technologistNotes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Imaging technique description provided by the technologist. Null clears.
    /// </summary>
    public string? TechnologistTechnique
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("technologistTechnique");
        }
        init { this._rawBodyData.Set("technologistTechnique", value); }
    }

    public StudyUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyUpdateParams(StudyUpdateParams studyUpdateParams)
        : base(studyUpdateParams)
    {
        this.StudyID = studyUpdateParams.StudyID;

        this._rawBodyData = new(studyUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public StudyUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string studyID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.StudyID = studyID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static StudyUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string studyID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            studyID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["StudyID"] = JsonSerializer.SerializeToElement(this.StudyID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(StudyUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.StudyID?.Equals(other.StudyID) ?? other.StudyID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/autoScribe/studies/{0}", this.StudyID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// External prior report metadata and text stored on a study
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<StudyUpdateParamsPriorReport, StudyUpdateParamsPriorReportFromRaw>)
)]
public sealed record class StudyUpdateParamsPriorReport : JsonModel
{
    /// <summary>
    /// Full prior report text
    /// </summary>
    public required string ReportText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reportText");
        }
        init { this._rawData.Set("reportText", value); }
    }

    /// <summary>
    /// Integrator's external study identifier
    /// </summary>
    public string? ExternalStudyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("externalStudyId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("externalStudyId", value);
        }
    }

    /// <summary>
    /// Imaging modality for the prior study
    /// </summary>
    public string? Modality
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("modality");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("modality", value);
        }
    }

    /// <summary>
    /// Prior study date (YYYY-MM-DD)
    /// </summary>
    public string? StudyDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("studyDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("studyDate", value);
        }
    }

    /// <summary>
    /// Description of the prior study
    /// </summary>
    public string? StudyDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("studyDescription");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("studyDescription", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ReportText;
        _ = this.ExternalStudyID;
        _ = this.Modality;
        _ = this.StudyDate;
        _ = this.StudyDescription;
    }

    public StudyUpdateParamsPriorReport() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyUpdateParamsPriorReport(StudyUpdateParamsPriorReport studyUpdateParamsPriorReport)
        : base(studyUpdateParamsPriorReport) { }
#pragma warning restore CS8618

    public StudyUpdateParamsPriorReport(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyUpdateParamsPriorReport(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StudyUpdateParamsPriorReportFromRaw.FromRawUnchecked"/>
    public static StudyUpdateParamsPriorReport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public StudyUpdateParamsPriorReport(string reportText)
        : this()
    {
        this.ReportText = reportText;
    }
}

class StudyUpdateParamsPriorReportFromRaw : IFromRawJson<StudyUpdateParamsPriorReport>
{
    /// <inheritdoc/>
    public StudyUpdateParamsPriorReport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StudyUpdateParamsPriorReport.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ReportMetadata, ReportMetadataFromRaw>))]
public sealed record class ReportMetadata : JsonModel
{
    public string? Age
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("age");
        }
        init { this._rawData.Set("age", value); }
    }

    public string? DateOfBirth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("dateOfBirth");
        }
        init { this._rawData.Set("dateOfBirth", value); }
    }

    public string? FacilityName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("facilityName");
        }
        init { this._rawData.Set("facilityName", value); }
    }

    public Height? Height
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Height>("height");
        }
        init { this._rawData.Set("height", value); }
    }

    public string? Mrn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mrn");
        }
        init { this._rawData.Set("mrn", value); }
    }

    public string? PatientName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("patientName");
        }
        init { this._rawData.Set("patientName", value); }
    }

    /// <summary>
    /// Procedure or study type. Nullable on PATCH. Maps to DB scan_type and report_header.scan_type.
    /// </summary>
    public string? Procedure
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("procedure");
        }
        init { this._rawData.Set("procedure", value); }
    }

    public string? ReferringPhysicianName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("referringPhysicianName");
        }
        init { this._rawData.Set("referringPhysicianName", value); }
    }

    public ApiEnum<string, Sex>? Sex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Sex>>("sex");
        }
        init { this._rawData.Set("sex", value); }
    }

    /// <summary>
    /// Study date (YYYY-MM-DD). Nullable on PATCH. Maps to DB scan_date and report_header.scan_date.
    /// </summary>
    public string? StudyDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("studyDate");
        }
        init { this._rawData.Set("studyDate", value); }
    }

    /// <summary>
    /// Study time (HH:MM). Nullable on PATCH. Maps to DB scan_time and report_header.scan_time.
    /// </summary>
    public string? StudyTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("studyTime");
        }
        init { this._rawData.Set("studyTime", value); }
    }

    public Weight? Weight
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Weight>("weight");
        }
        init { this._rawData.Set("weight", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Age;
        _ = this.DateOfBirth;
        _ = this.FacilityName;
        this.Height?.Validate();
        _ = this.Mrn;
        _ = this.PatientName;
        _ = this.Procedure;
        _ = this.ReferringPhysicianName;
        this.Sex?.Validate();
        _ = this.StudyDate;
        _ = this.StudyTime;
        this.Weight?.Validate();
    }

    public ReportMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReportMetadata(ReportMetadata reportMetadata)
        : base(reportMetadata) { }
#pragma warning restore CS8618

    public ReportMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReportMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReportMetadataFromRaw.FromRawUnchecked"/>
    public static ReportMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReportMetadataFromRaw : IFromRawJson<ReportMetadata>
{
    /// <inheritdoc/>
    public ReportMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ReportMetadata.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Height, HeightFromRaw>))]
public sealed record class Height : JsonModel
{
    public required ApiEnum<string, Unit> Unit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Unit>>("unit");
        }
        init { this._rawData.Set("unit", value); }
    }

    public required double Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Unit.Validate();
        _ = this.Value;
    }

    public Height() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Height(Height height)
        : base(height) { }
#pragma warning restore CS8618

    public Height(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Height(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="HeightFromRaw.FromRawUnchecked"/>
    public static Height FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class HeightFromRaw : IFromRawJson<Height>
{
    /// <inheritdoc/>
    public Height FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Height.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(UnitConverter))]
public enum Unit
{
    In,
    Cm,
}

sealed class UnitConverter : JsonConverter<Unit>
{
    public override Unit Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "in" => Unit.In,
            "cm" => Unit.Cm,
            _ => (Unit)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Unit value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Unit.In => "in",
                Unit.Cm => "cm",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(SexConverter))]
public enum Sex
{
    Male,
    Female,
    Other,
}

sealed class SexConverter : JsonConverter<Sex>
{
    public override Sex Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "male" => Sex.Male,
            "female" => Sex.Female,
            "other" => Sex.Other,
            _ => (Sex)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Sex value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Sex.Male => "male",
                Sex.Female => "female",
                Sex.Other => "other",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Weight, WeightFromRaw>))]
public sealed record class Weight : JsonModel
{
    public required ApiEnum<string, WeightUnit> Unit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, WeightUnit>>("unit");
        }
        init { this._rawData.Set("unit", value); }
    }

    public required double Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Unit.Validate();
        _ = this.Value;
    }

    public Weight() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Weight(Weight weight)
        : base(weight) { }
#pragma warning restore CS8618

    public Weight(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Weight(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WeightFromRaw.FromRawUnchecked"/>
    public static Weight FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WeightFromRaw : IFromRawJson<Weight>
{
    /// <inheritdoc/>
    public Weight FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Weight.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(WeightUnitConverter))]
public enum WeightUnit
{
    Lbs,
    Kg,
}

sealed class WeightUnitConverter : JsonConverter<WeightUnit>
{
    public override WeightUnit Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "lbs" => WeightUnit.Lbs,
            "kg" => WeightUnit.Kg,
            _ => (WeightUnit)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WeightUnit value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WeightUnit.Lbs => "lbs",
                WeightUnit.Kg => "kg",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Priority level of the study. 'normal' for routine, 'high' for urgent, 'stat'
/// for immediate attention
/// </summary>
[JsonConverter(typeof(StudyUpdateParamsSeverityConverter))]
public enum StudyUpdateParamsSeverity
{
    Normal,
    High,
    Stat,
}

sealed class StudyUpdateParamsSeverityConverter : JsonConverter<StudyUpdateParamsSeverity>
{
    public override StudyUpdateParamsSeverity Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "normal" => StudyUpdateParamsSeverity.Normal,
            "high" => StudyUpdateParamsSeverity.High,
            "stat" => StudyUpdateParamsSeverity.Stat,
            _ => (StudyUpdateParamsSeverity)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StudyUpdateParamsSeverity value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StudyUpdateParamsSeverity.Normal => "normal",
                StudyUpdateParamsSeverity.High => "high",
                StudyUpdateParamsSeverity.Stat => "stat",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
