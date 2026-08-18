using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.Webhooks;

/// <summary>
/// One worklist item shaped for direct DICOM Dataset construction on the on-prem
/// box. Field names are PascalCase DICOM-style intentionally.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ModalityWorklistItem, ModalityWorklistItemFromRaw>))]
public sealed record class ModalityWorklistItem : JsonModel
{
    /// <summary>
    /// Accession number (DICOM SH, max 16)
    /// </summary>
    public required string AccessionNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("AccessionNumber");
        }
        init { this._rawData.Set("AccessionNumber", value); }
    }

    public required string Modality
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("Modality");
        }
        init { this._rawData.Set("Modality", value); }
    }

    /// <summary>
    /// Patient birth date (DICOM DA: YYYYMMDD)
    /// </summary>
    public required string PatientBirthDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("PatientBirthDate");
        }
        init { this._rawData.Set("PatientBirthDate", value); }
    }

    public required string PatientID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("PatientID");
        }
        init { this._rawData.Set("PatientID", value); }
    }

    /// <summary>
    /// DICOM PN / HL7 format: LAST^FIRST[^MIDDLE^PREFIX^SUFFIX]
    /// </summary>
    public required string PatientName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("PatientName");
        }
        init { this._rawData.Set("PatientName", value); }
    }

    /// <summary>
    /// DICOM PatientSex: M, F, or O
    /// </summary>
    public required string PatientSex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("PatientSex");
        }
        init { this._rawData.Set("PatientSex", value); }
    }

    /// <summary>
    /// Height in meters. Empty string allowed; if set must be numeric (typical range 0.4–2.5).
    /// </summary>
    public required string PatientSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("PatientSize");
        }
        init { this._rawData.Set("PatientSize", value); }
    }

    /// <summary>
    /// Weight in kilograms. Empty string allowed; if set must be numeric (typical
    /// range 1–400).
    /// </summary>
    public required string PatientWeight
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("PatientWeight");
        }
        init { this._rawData.Set("PatientWeight", value); }
    }

    public required string ProtocolName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("ProtocolName");
        }
        init { this._rawData.Set("ProtocolName", value); }
    }

    public required string RequestedProcedureDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("RequestedProcedureDescription");
        }
        init { this._rawData.Set("RequestedProcedureDescription", value); }
    }

    /// <summary>
    /// Scheduled procedure steps for this worklist item. Most appointments/studies
    /// have a single step; include additional steps only when the RIS schedules multiple.
    /// </summary>
    public required IReadOnlyList<ModalityWorklistScheduledStep> ScheduledProcedureStepSequence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ModalityWorklistScheduledStep>>(
                "ScheduledProcedureStepSequence"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ModalityWorklistScheduledStep>>(
                "ScheduledProcedureStepSequence",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required string StudyDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("StudyDescription");
        }
        init { this._rawData.Set("StudyDescription", value); }
    }

    /// <summary>
    /// Required from partner RIS today; do not omit.
    /// </summary>
    public required string StudyInstanceUid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("StudyInstanceUID");
        }
        init { this._rawData.Set("StudyInstanceUID", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccessionNumber;
        _ = this.Modality;
        _ = this.PatientBirthDate;
        _ = this.PatientID;
        _ = this.PatientName;
        _ = this.PatientSex;
        _ = this.PatientSize;
        _ = this.PatientWeight;
        _ = this.ProtocolName;
        _ = this.RequestedProcedureDescription;
        foreach (var item in this.ScheduledProcedureStepSequence)
        {
            item.Validate();
        }
        _ = this.StudyDescription;
        _ = this.StudyInstanceUid;
    }

    public ModalityWorklistItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ModalityWorklistItem(ModalityWorklistItem modalityWorklistItem)
        : base(modalityWorklistItem) { }
#pragma warning restore CS8618

    public ModalityWorklistItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModalityWorklistItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ModalityWorklistItemFromRaw.FromRawUnchecked"/>
    public static ModalityWorklistItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ModalityWorklistItemFromRaw : IFromRawJson<ModalityWorklistItem>
{
    /// <inheritdoc/>
    public ModalityWorklistItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ModalityWorklistItem.FromRawUnchecked(rawData);
}
