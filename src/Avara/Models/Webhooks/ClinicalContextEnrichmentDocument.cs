using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.Webhooks;

/// <summary>
/// Inline text document for clinical history synthesize
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ClinicalContextEnrichmentDocument,
        ClinicalContextEnrichmentDocumentFromRaw
    >)
)]
public sealed record class ClinicalContextEnrichmentDocument : JsonModel
{
    /// <summary>
    /// Text chunks for the document
    /// </summary>
    public required IReadOnlyList<string> Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("content");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "content",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required string FileName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("fileName");
        }
        init { this._rawData.Set("fileName", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        _ = this.FileName;
    }

    public ClinicalContextEnrichmentDocument() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClinicalContextEnrichmentDocument(
        ClinicalContextEnrichmentDocument clinicalContextEnrichmentDocument
    )
        : base(clinicalContextEnrichmentDocument) { }
#pragma warning restore CS8618

    public ClinicalContextEnrichmentDocument(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClinicalContextEnrichmentDocument(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ClinicalContextEnrichmentDocumentFromRaw.FromRawUnchecked"/>
    public static ClinicalContextEnrichmentDocument FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClinicalContextEnrichmentDocumentFromRaw : IFromRawJson<ClinicalContextEnrichmentDocument>
{
    /// <inheritdoc/>
    public ClinicalContextEnrichmentDocument FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ClinicalContextEnrichmentDocument.FromRawUnchecked(rawData);
}
