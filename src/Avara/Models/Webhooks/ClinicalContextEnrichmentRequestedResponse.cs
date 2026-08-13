using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.Webhooks;

/// <summary>
/// Soft enrichment response. No authorized field — return any subset of fields (including {}).
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ClinicalContextEnrichmentRequestedResponse,
        ClinicalContextEnrichmentRequestedResponseFromRaw
    >)
)]
public sealed record class ClinicalContextEnrichmentRequestedResponse : JsonModel
{
    public string? ClinicalIndication
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("clinicalIndication");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("clinicalIndication", value);
        }
    }

    public IReadOnlyList<ClinicalContextEnrichmentDocument>? Documents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ClinicalContextEnrichmentDocument>
            >("documents");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ClinicalContextEnrichmentDocument>?>(
                "documents",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<ClinicalContextEnrichmentDocumentUrl>? DocumentUrls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ClinicalContextEnrichmentDocumentUrl>
            >("documentUrls");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ClinicalContextEnrichmentDocumentUrl>?>(
                "documentUrls",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<ClinicalContextEnrichmentPriorReport>? PriorReports
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ClinicalContextEnrichmentPriorReport>
            >("priorReports");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ClinicalContextEnrichmentPriorReport>?>(
                "priorReports",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<string>? TechnologistNotes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("technologistNotes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "technologistNotes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? TechnologistTechnique
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("technologistTechnique");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("technologistTechnique", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ClinicalIndication;
        foreach (var item in this.Documents ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.DocumentUrls ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.PriorReports ?? [])
        {
            item.Validate();
        }
        _ = this.TechnologistNotes;
        _ = this.TechnologistTechnique;
    }

    public ClinicalContextEnrichmentRequestedResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClinicalContextEnrichmentRequestedResponse(
        ClinicalContextEnrichmentRequestedResponse clinicalContextEnrichmentRequestedResponse
    )
        : base(clinicalContextEnrichmentRequestedResponse) { }
#pragma warning restore CS8618

    public ClinicalContextEnrichmentRequestedResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClinicalContextEnrichmentRequestedResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ClinicalContextEnrichmentRequestedResponseFromRaw.FromRawUnchecked"/>
    public static ClinicalContextEnrichmentRequestedResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClinicalContextEnrichmentRequestedResponseFromRaw
    : IFromRawJson<ClinicalContextEnrichmentRequestedResponse>
{
    /// <inheritdoc/>
    public ClinicalContextEnrichmentRequestedResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ClinicalContextEnrichmentRequestedResponse.FromRawUnchecked(rawData);
}
