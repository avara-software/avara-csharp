using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.Webhooks;

/// <summary>
/// Event payload for a modality worklist (C-FIND MWL) request
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ModalityWorklistRequestedEventData,
        ModalityWorklistRequestedEventDataFromRaw
    >)
)]
public sealed record class ModalityWorklistRequestedEventData : JsonModel
{
    /// <summary>
    /// Calling AE title from the modality
    /// </summary>
    public required string CallingAe
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("callingAe");
        }
        init { this._rawData.Set("callingAe", value); }
    }

    /// <summary>
    /// Clinic UUID that owns the modality / worklist query
    /// </summary>
    public required string ClinicID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("clinicId");
        }
        init { this._rawData.Set("clinicId", value); }
    }

    /// <summary>
    /// Inclusive worklist window end date (YYYY-MM-DD)
    /// </summary>
    public required string DateEnd
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("dateEnd");
        }
        init { this._rawData.Set("dateEnd", value); }
    }

    /// <summary>
    /// Inclusive worklist window start date (YYYY-MM-DD)
    /// </summary>
    public required string DateStart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("dateStart");
        }
        init { this._rawData.Set("dateStart", value); }
    }

    /// <summary>
    /// Source IP observed by Avara for the modality request
    /// </summary>
    public required string SourceIP
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("sourceIp");
        }
        init { this._rawData.Set("sourceIp", value); }
    }

    /// <summary>
    /// Present when the modality C-FIND included a modality filter
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallingAe;
        _ = this.ClinicID;
        _ = this.DateEnd;
        _ = this.DateStart;
        _ = this.SourceIP;
        _ = this.Modality;
    }

    public ModalityWorklistRequestedEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ModalityWorklistRequestedEventData(
        ModalityWorklistRequestedEventData modalityWorklistRequestedEventData
    )
        : base(modalityWorklistRequestedEventData) { }
#pragma warning restore CS8618

    public ModalityWorklistRequestedEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModalityWorklistRequestedEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ModalityWorklistRequestedEventDataFromRaw.FromRawUnchecked"/>
    public static ModalityWorklistRequestedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ModalityWorklistRequestedEventDataFromRaw : IFromRawJson<ModalityWorklistRequestedEventData>
{
    /// <inheritdoc/>
    public ModalityWorklistRequestedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ModalityWorklistRequestedEventData.FromRawUnchecked(rawData);
}
