using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.Webhooks;

/// <summary>
/// One SOP in the optional study manifest. Identity (sopInstanceUID, sopClassUID)
/// is always required. For image SOPs, also include rows, columns, bitsAllocated,
/// photometricInterpretation, and samplesPerPixel or that SOP is dropped. SR / PR
/// / KO do not need geometry. Wrong types or missing required fields drop that SOP
/// only; sibling SOPs and URLs still load.
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
    /// DICOM SOP Class UID. Progressive load uses legacy single-frame image classes.
    /// Common: CT 1.2.840.10008.5.1.4.1.1.2, MR 1.2.840.10008.5.1.4.1.1.4, plus CR
    /// / DX / US / XA / PT. Enhanced multi-frame classes already load progressively
    /// from the single SOP — the sidecar is not used for them. SR / PR / KO do not
    /// need geometry.
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
    /// DICOM SOP Instance UID. Non-empty string.
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

    /// <summary>
    /// Required on image SOPs. Planner uses 8, 16, or 32 (or the float flags). Typical
    /// CT/MR: 16.
    /// </summary>
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

    /// <summary>
    /// Optional. Typical CT/MR: 12 or 16.
    /// </summary>
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

    /// <summary>
    /// Image columns. Required on image SOPs. Positive integer. Common: 256, 512, 1024.
    /// </summary>
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

    /// <summary>
    /// Optional. Typical 16-bit: 15.
    /// </summary>
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

    /// <summary>
    /// Slice order (DICOM Instance Number). Omit or 0 if unknown; UID is the tie-break.
    /// </summary>
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

    /// <summary>
    /// Set true only if pixel data is 64-bit float.
    /// </summary>
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

    /// <summary>
    /// Set true only if pixel data is 32-bit float.
    /// </summary>
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

    /// <summary>
    /// 1 for single-frame files. Greater than 1 only if this SOP is multi-frame.
    /// </summary>
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

    /// <summary>
    /// Required non-empty string on image SOPs. Common: MONOCHROME2 (CT/MR), MONOCHROME1
    /// (often MG, inverted), RGB, PALETTE COLOR, YBR_FULL, YBR_FULL_422. Unknown
    /// strings are kept and treated as mono unless samplesPerPixel is 3. Wrong type
    /// (number/null) drops that SOP from optimized path.
    /// </summary>
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

    /// <summary>
    /// 0 unsigned, 1 signed. Typical CT: 0.
    /// </summary>
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

    /// <summary>
    /// Optional. Typical CT: -1024. Safe to omit.
    /// </summary>
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

    /// <summary>
    /// Optional. Typical CT: 1. Safe to omit.
    /// </summary>
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

    /// <summary>
    /// Image rows. Required on image SOPs. Positive integer. Common: 256, 512, 1024.
    /// </summary>
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

    /// <summary>
    /// Required on image SOPs. 1 grayscale, 3 color. 3 is treated as color even
    /// if photometric is unusual.
    /// </summary>
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
