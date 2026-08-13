using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models;

/// <summary>
/// A reference to an API key with basic identifying information
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ApiKeyReference, ApiKeyReferenceFromRaw>))]
public sealed record class ApiKeyReference : JsonModel
{
    /// <summary>
    /// Unique API key identifier (UUIDv4 format)
    /// </summary>
    public required string ApiKeyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("apiKeyId");
        }
        init { this._rawData.Set("apiKeyId", value); }
    }

    /// <summary>
    /// Human-readable description of the API key
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Whether this API key has a clinical-context enrichment webhook configured
    /// </summary>
    public bool? IsClinicalContextEnrichmentEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isClinicalContextEnrichmentEnabled");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isClinicalContextEnrichmentEnabled", value);
        }
    }

    /// <summary>
    /// Whether this API key has access to the Viewer product
    /// </summary>
    public bool? IsViewerEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isViewerEnabled");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isViewerEnabled", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ApiKeyID;
        _ = this.Description;
        _ = this.IsClinicalContextEnrichmentEnabled;
        _ = this.IsViewerEnabled;
    }

    public ApiKeyReference() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiKeyReference(ApiKeyReference apiKeyReference)
        : base(apiKeyReference) { }
#pragma warning restore CS8618

    public ApiKeyReference(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiKeyReference(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiKeyReferenceFromRaw.FromRawUnchecked"/>
    public static ApiKeyReference FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiKeyReferenceFromRaw : IFromRawJson<ApiKeyReference>
{
    /// <inheritdoc/>
    public ApiKeyReference FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ApiKeyReference.FromRawUnchecked(rawData);
}
