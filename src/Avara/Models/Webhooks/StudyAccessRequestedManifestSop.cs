using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.Webhooks;

/// <summary>
/// One SOP in the optional study manifest. Identity is required. Image geometry
/// (rows, columns, bitsAllocated, photometricInterpretation, samplesPerPixel) is
/// required to preallocate a volume; rescale and float flags are optional.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        StudyAccessRequestedManifestSop,
        StudyAccessRequestedManifestSopFromRaw
    >)
)]
public sealed record class StudyAccessRequestedManifestSop : JsonModel
{
    /// <summary>
    /// DICOM SOP Class UID (e.g. Legacy CT Image Storage)
    /// </summary>
    public required string SopClassUid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("sopClassUID");
        }
        init { this._rawData.Set("sopClassUID", value); }
    }

    /// <summary>
    /// DICOM SOP Instance UID
    /// </summary>
    public required string SopInstanceUid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("sopInstanceUID");
        }
        init { this._rawData.Set("sopInstanceUID", value); }
    }

    public double? BitsAllocated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("bitsAllocated");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("bitsAllocated", value);
        }
    }

    public double? BitsStored
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("bitsStored");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("bitsStored", value);
        }
    }

    public double? Columns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("columns");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("columns", value);
        }
    }

    public double? HighBit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("highBit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("highBit", value);
        }
    }

    public double? InstanceNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("instanceNumber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("instanceNumber", value);
        }
    }

    public bool? IsDoubleFloatPixelData
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isDoubleFloatPixelData");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isDoubleFloatPixelData", value);
        }
    }

    public bool? IsFloatPixelData
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isFloatPixelData");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isFloatPixelData", value);
        }
    }

    public double? NumberOfFrames
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("numberOfFrames");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("numberOfFrames", value);
        }
    }

    public string? PhotometricInterpretation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("photometricInterpretation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("photometricInterpretation", value);
        }
    }

    public double? PixelRepresentation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("pixelRepresentation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pixelRepresentation", value);
        }
    }

    public double? RescaleIntercept
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("rescaleIntercept");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("rescaleIntercept", value);
        }
    }

    public double? RescaleSlope
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("rescaleSlope");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("rescaleSlope", value);
        }
    }

    public double? Rows
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("rows");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("rows", value);
        }
    }

    public double? SamplesPerPixel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("samplesPerPixel");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("samplesPerPixel", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SopClassUid;
        _ = this.SopInstanceUid;
        _ = this.BitsAllocated;
        _ = this.BitsStored;
        _ = this.Columns;
        _ = this.HighBit;
        _ = this.InstanceNumber;
        _ = this.IsDoubleFloatPixelData;
        _ = this.IsFloatPixelData;
        _ = this.NumberOfFrames;
        _ = this.PhotometricInterpretation;
        _ = this.PixelRepresentation;
        _ = this.RescaleIntercept;
        _ = this.RescaleSlope;
        _ = this.Rows;
        _ = this.SamplesPerPixel;
    }

    public StudyAccessRequestedManifestSop() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyAccessRequestedManifestSop(
        StudyAccessRequestedManifestSop studyAccessRequestedManifestSop
    )
        : base(studyAccessRequestedManifestSop) { }
#pragma warning restore CS8618

    public StudyAccessRequestedManifestSop(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyAccessRequestedManifestSop(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StudyAccessRequestedManifestSopFromRaw.FromRawUnchecked"/>
    public static StudyAccessRequestedManifestSop FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StudyAccessRequestedManifestSopFromRaw : IFromRawJson<StudyAccessRequestedManifestSop>
{
    /// <inheritdoc/>
    public StudyAccessRequestedManifestSop FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StudyAccessRequestedManifestSop.FromRawUnchecked(rawData);
}
