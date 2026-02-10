using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;
using Avara.Exceptions;

namespace Avara.Models.AutoScribe;

/// <summary>
/// Patient demographics and scan information for report generation
/// </summary>
[JsonConverter(typeof(JsonModelConverter<StudyReportMetadata, StudyReportMetadataFromRaw>))]
public sealed record class StudyReportMetadata : JsonModel
{
    /// <summary>
    /// Patient's age at time of scan (e.g., '34.5 years', '2 months')
    /// </summary>
    public string? Age
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("age");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("age", value);
        }
    }

    /// <summary>
    /// Patient's date of birth. Format: YYYY-MM-DD (e.g., '1990-05-20')
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
    /// Name of the medical facility where the scan was performed
    /// </summary>
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

    /// <summary>
    /// Patient's height with unit (e.g., {value: 70, unit: 'inches'} or {value: 178,
    /// unit: 'cm'})
    /// </summary>
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

    /// <summary>
    /// Medical Record Number - unique patient identifier
    /// </summary>
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

    /// <summary>
    /// Full name of the patient
    /// </summary>
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

    /// <summary>
    /// Name of the physician who referred the patient for this scan
    /// </summary>
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

    /// <summary>
    /// Date the scan was performed. Format: YYYY-MM-DD (e.g., '2024-01-15')
    /// </summary>
    public string? ScanDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("scanDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("scanDate", value);
        }
    }

    /// <summary>
    /// Time the scan was performed. Format: HH:MM (e.g., '14:30')
    /// </summary>
    public string? ScanTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("scanTime");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("scanTime", value);
        }
    }

    /// <summary>
    /// Type of scan or imaging modality (e.g., 'MRI', 'CT', 'X-Ray', 'Ultrasound')
    /// </summary>
    public string? ScanType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("scanType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("scanType", value);
        }
    }

    /// <summary>
    /// Patient's biological sex
    /// </summary>
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
    /// Patient's weight with unit (e.g., {value: 150, unit: 'lbs'} or {value: 68,
    /// unit: 'kg'})
    /// </summary>
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
        _ = this.Age;
        _ = this.DateOfBirth;
        _ = this.FacilityName;
        this.Height?.Validate();
        _ = this.Mrn;
        _ = this.PatientName;
        _ = this.ReferringPhysicianName;
        _ = this.ScanDate;
        _ = this.ScanTime;
        _ = this.ScanType;
        this.Sex?.Validate();
        this.Weight?.Validate();
    }

    public StudyReportMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyReportMetadata(StudyReportMetadata studyReportMetadata)
        : base(studyReportMetadata) { }
#pragma warning restore CS8618

    public StudyReportMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyReportMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StudyReportMetadataFromRaw.FromRawUnchecked"/>
    public static StudyReportMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StudyReportMetadataFromRaw : IFromRawJson<StudyReportMetadata>
{
    /// <inheritdoc/>
    public StudyReportMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        StudyReportMetadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Patient's height with unit (e.g., {value: 70, unit: 'inches'} or {value: 178,
/// unit: 'cm'})
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Height, HeightFromRaw>))]
public sealed record class Height : JsonModel
{
    /// <summary>
    /// Height unit
    /// </summary>
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

/// <summary>
/// Height unit
/// </summary>
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

/// <summary>
/// Patient's biological sex
/// </summary>
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

/// <summary>
/// Patient's weight with unit (e.g., {value: 150, unit: 'lbs'} or {value: 68, unit: 'kg'})
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Weight, WeightFromRaw>))]
public sealed record class Weight : JsonModel
{
    /// <summary>
    /// Weight unit
    /// </summary>
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

/// <summary>
/// Weight unit
/// </summary>
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
