using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.AutoScribe.EphemeralSessions;

/// <summary>
/// Tokenized landing URL for an ephemeral AutoScribe viewer session (30-second token).
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EphemeralSessionCreateResponse,
        EphemeralSessionCreateResponseFromRaw
    >)
)]
public sealed record class EphemeralSessionCreateResponse : JsonModel
{
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Url;
    }

    public EphemeralSessionCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EphemeralSessionCreateResponse(
        EphemeralSessionCreateResponse ephemeralSessionCreateResponse
    )
        : base(ephemeralSessionCreateResponse) { }
#pragma warning restore CS8618

    public EphemeralSessionCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EphemeralSessionCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EphemeralSessionCreateResponseFromRaw.FromRawUnchecked"/>
    public static EphemeralSessionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EphemeralSessionCreateResponse(string url)
        : this()
    {
        this.Url = url;
    }
}

class EphemeralSessionCreateResponseFromRaw : IFromRawJson<EphemeralSessionCreateResponse>
{
    /// <inheritdoc/>
    public EphemeralSessionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EphemeralSessionCreateResponse.FromRawUnchecked(rawData);
}
