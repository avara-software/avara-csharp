using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.Webhooks;

/// <summary>
/// Remote document URL (https) for Avara to fetch/summarize
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ClinicalContextEnrichmentDocumentUrl,
        ClinicalContextEnrichmentDocumentUrlFromRaw
    >)
)]
public sealed record class ClinicalContextEnrichmentDocumentUrl : JsonModel
{
    /// <summary>
    /// Must use https://
    /// </summary>
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    public string? FileName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("fileName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fileName", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Url;
        _ = this.FileName;
    }

    public ClinicalContextEnrichmentDocumentUrl() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClinicalContextEnrichmentDocumentUrl(
        ClinicalContextEnrichmentDocumentUrl clinicalContextEnrichmentDocumentUrl
    )
        : base(clinicalContextEnrichmentDocumentUrl) { }
#pragma warning restore CS8618

    public ClinicalContextEnrichmentDocumentUrl(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClinicalContextEnrichmentDocumentUrl(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ClinicalContextEnrichmentDocumentUrlFromRaw.FromRawUnchecked"/>
    public static ClinicalContextEnrichmentDocumentUrl FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ClinicalContextEnrichmentDocumentUrl(string url)
        : this()
    {
        this.Url = url;
    }
}

class ClinicalContextEnrichmentDocumentUrlFromRaw
    : IFromRawJson<ClinicalContextEnrichmentDocumentUrl>
{
    /// <inheritdoc/>
    public ClinicalContextEnrichmentDocumentUrl FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ClinicalContextEnrichmentDocumentUrl.FromRawUnchecked(rawData);
}
