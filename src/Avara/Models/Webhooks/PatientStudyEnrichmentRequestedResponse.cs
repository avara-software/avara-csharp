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
/// Soft enrichment response. No authorized field — return any subset of fields (including
/// {}). Avara merges per-field with DICOM light metadata then defaults. Optional
/// expressCustomerId: if present and a valid cus_ id for this clinic, Avara sets
/// it on the created study. If present but not usable, Avara ignores it, applies
/// other fields, and logs a warning.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PatientStudyEnrichmentRequestedResponse,
        PatientStudyEnrichmentRequestedResponseFromRaw
    >)
)]
public sealed record class PatientStudyEnrichmentRequestedResponse : JsonModel
{
    /// <summary>
    /// YYYY-MM-DD
    /// </summary>
    public string? DateOfBirth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("dateOfBirth");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("dateOfBirth", value);
        }
    }

    /// <summary>
    /// Optional Express customer to attach to the created study. Format: cus_{32
    /// hex chars}. Must belong to the clinic in the request. Omit to leave the study
    /// unscoped. If present but not usable, Avara ignores this field, applies any
    /// other enrichment fields, and logs a warning on the webhook event.
    /// </summary>
    public string? ExpressCustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("expressCustomerId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("expressCustomerId", value);
        }
    }

    public string? ExternalPatientID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("externalPatientId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("externalPatientId", value);
        }
    }

    public string? FacilityName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("facilityName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("facilityName", value);
        }
    }

    public Height? Height
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Height>("height");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("height", value);
        }
    }

    public string? Mrn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mrn");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mrn", value);
        }
    }

    public string? PatientName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("patientName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("patientName", value);
        }
    }

    public string? Procedure
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("procedure");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("procedure", value);
        }
    }

    public string? ReferringPhysicianName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("referringPhysicianName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("referringPhysicianName", value);
        }
    }

    public ApiEnum<string, Severity>? Severity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Severity>>("severity");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("severity", value);
        }
    }

    public ApiEnum<string, Sex>? Sex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Sex>>("sex");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sex", value);
        }
    }

    /// <summary>
    /// YYYY-MM-DD
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

    /// <summary>
    /// HH:MM or HH:MM:SS[.fff]; Avara may truncate to HH:MM
    /// </summary>
    public string? StudyTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("studyTime");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("studyTime", value);
        }
    }

    public Weight? Weight
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Weight>("weight");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("weight", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DateOfBirth;
        _ = this.ExpressCustomerID;
        _ = this.ExternalPatientID;
        _ = this.FacilityName;
        this.Height?.Validate();
        _ = this.Mrn;
        _ = this.PatientName;
        _ = this.Procedure;
        _ = this.ReferringPhysicianName;
        this.Severity?.Validate();
        this.Sex?.Validate();
        _ = this.StudyDate;
        _ = this.StudyDescription;
        _ = this.StudyTime;
        this.Weight?.Validate();
    }

    public PatientStudyEnrichmentRequestedResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PatientStudyEnrichmentRequestedResponse(
        PatientStudyEnrichmentRequestedResponse patientStudyEnrichmentRequestedResponse
    )
        : base(patientStudyEnrichmentRequestedResponse) { }
#pragma warning restore CS8618

    public PatientStudyEnrichmentRequestedResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PatientStudyEnrichmentRequestedResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PatientStudyEnrichmentRequestedResponseFromRaw.FromRawUnchecked"/>
    public static PatientStudyEnrichmentRequestedResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PatientStudyEnrichmentRequestedResponseFromRaw
    : IFromRawJson<PatientStudyEnrichmentRequestedResponse>
{
    /// <inheritdoc/>
    public PatientStudyEnrichmentRequestedResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PatientStudyEnrichmentRequestedResponse.FromRawUnchecked(rawData);
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

[JsonConverter(typeof(SeverityConverter))]
public enum Severity
{
    Normal,
    High,
    Stat,
}

sealed class SeverityConverter : JsonConverter<Severity>
{
    public override Severity Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "normal" => Severity.Normal,
            "high" => Severity.High,
            "stat" => Severity.Stat,
            _ => (Severity)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Severity value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Severity.Normal => "normal",
                Severity.High => "high",
                Severity.Stat => "stat",
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
