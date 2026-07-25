using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Avara.Core;

namespace Avara.Models.AutoScribe.ClinicalReferences;

/// <summary>
/// Retrieves a single clinical reference by its integrator-provided external reference identifier.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ClinicalReferenceRetrieveByExternalReferenceIDParams : ParamsBase
{
    public string? ExternalReferenceID { get; init; }

    public ClinicalReferenceRetrieveByExternalReferenceIDParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClinicalReferenceRetrieveByExternalReferenceIDParams(
        ClinicalReferenceRetrieveByExternalReferenceIDParams clinicalReferenceRetrieveByExternalReferenceIDParams
    )
        : base(clinicalReferenceRetrieveByExternalReferenceIDParams)
    {
        this.ExternalReferenceID =
            clinicalReferenceRetrieveByExternalReferenceIDParams.ExternalReferenceID;
    }
#pragma warning restore CS8618

    public ClinicalReferenceRetrieveByExternalReferenceIDParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClinicalReferenceRetrieveByExternalReferenceIDParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string externalReferenceID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.ExternalReferenceID = externalReferenceID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ClinicalReferenceRetrieveByExternalReferenceIDParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string externalReferenceID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            externalReferenceID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ExternalReferenceID"] = JsonSerializer.SerializeToElement(
                        this.ExternalReferenceID
                    ),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ClinicalReferenceRetrieveByExternalReferenceIDParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.ExternalReferenceID?.Equals(other.ExternalReferenceID)
                ?? other.ExternalReferenceID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/autoScribe/clinicalReferences/byExternalReferenceId/{0}",
                    this.ExternalReferenceID
                )
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
