using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Avara.Core;

namespace Avara.Models.AutoScribe.EphemeralSessions;

/// <summary>
/// Mints a 30-second tokenized landing URL for a userless, studyless AutoScribe viewer
/// session. The token names a customer retrievalId (not an Avara study). Optional
/// options are echoed verbatim on ephemeral.access_requested (max 3072 bytes JSON).
/// Optional hangingProtocol applies a single-monitor layout when the viewer loads.
/// Requires a customer study webhook on the API key.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EphemeralSessionCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Opaque customer handle for this view session. Avara stores and echoes it;
    /// it is not an Avara study ID.
    /// </summary>
    public required string RetrievalID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("retrievalId");
        }
        init { this._rawBodyData.Set("retrievalId", value); }
    }

    /// <summary>
    /// Optional single-monitor hanging protocol applied when the ephemeral viewer
    /// loads. Omitted = no protocol. Invalid shape is rejected.
    /// </summary>
    public EphemeralHangingProtocol? HangingProtocol
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<EphemeralHangingProtocol>("hangingProtocol");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("hangingProtocol", value);
        }
    }

    /// <summary>
    /// Optional JSON object echoed verbatim on ephemeral.access_requested. Avara
    /// does not read or edit it. Hard cap 3072 bytes on JSON.stringify. Examples:
    /// studyInstanceUids or internal ids for multi-study reads. Not for URLs or manifests.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Options
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "options"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, JsonElement>?>(
                "options",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public EphemeralSessionCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EphemeralSessionCreateParams(EphemeralSessionCreateParams ephemeralSessionCreateParams)
        : base(ephemeralSessionCreateParams)
    {
        this._rawBodyData = new(ephemeralSessionCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public EphemeralSessionCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EphemeralSessionCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static EphemeralSessionCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(EphemeralSessionCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/autoScribe/ephemeral-sessions"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
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
