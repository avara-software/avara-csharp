using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.Webhooks;

/// <summary>
/// Scheduled procedure step used to construct DICOM MWL datasets
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ModalityWorklistScheduledStep, ModalityWorklistScheduledStepFromRaw>)
)]
public sealed record class ModalityWorklistScheduledStep : JsonModel
{
    /// <summary>
    /// Modality for this scheduled step
    /// </summary>
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
    /// Human-readable description of the scheduled step
    /// </summary>
    public required string ScheduledProcedureStepDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("ScheduledProcedureStepDescription");
        }
        init { this._rawData.Set("ScheduledProcedureStepDescription", value); }
    }

    /// <summary>
    /// Scheduled procedure step identifier
    /// </summary>
    public required string ScheduledProcedureStepID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("ScheduledProcedureStepID");
        }
        init { this._rawData.Set("ScheduledProcedureStepID", value); }
    }

    /// <summary>
    /// Scheduled start date (DICOM DA-compatible string)
    /// </summary>
    public required string ScheduledProcedureStepStartDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("ScheduledProcedureStepStartDate");
        }
        init { this._rawData.Set("ScheduledProcedureStepStartDate", value); }
    }

    /// <summary>
    /// Scheduled start time (DICOM TM-compatible string)
    /// </summary>
    public required string ScheduledProcedureStepStartTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("ScheduledProcedureStepStartTime");
        }
        init { this._rawData.Set("ScheduledProcedureStepStartTime", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Modality;
        _ = this.ScheduledProcedureStepDescription;
        _ = this.ScheduledProcedureStepID;
        _ = this.ScheduledProcedureStepStartDate;
        _ = this.ScheduledProcedureStepStartTime;
    }

    public ModalityWorklistScheduledStep() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ModalityWorklistScheduledStep(
        ModalityWorklistScheduledStep modalityWorklistScheduledStep
    )
        : base(modalityWorklistScheduledStep) { }
#pragma warning restore CS8618

    public ModalityWorklistScheduledStep(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModalityWorklistScheduledStep(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ModalityWorklistScheduledStepFromRaw.FromRawUnchecked"/>
    public static ModalityWorklistScheduledStep FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ModalityWorklistScheduledStepFromRaw : IFromRawJson<ModalityWorklistScheduledStep>
{
    /// <inheritdoc/>
    public ModalityWorklistScheduledStep FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ModalityWorklistScheduledStep.FromRawUnchecked(rawData);
}
