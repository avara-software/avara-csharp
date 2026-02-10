using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.AutoScribe.Studies;

/// <summary>
/// Response containing the generated reroute URL for AutoScribe (viewer + dictation)
/// </summary>
[JsonConverter(typeof(JsonModelConverter<StudyRerouteUrlResponse, StudyRerouteUrlResponseFromRaw>))]
public sealed record class StudyRerouteUrlResponse : JsonModel
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

    public StudyRerouteUrlResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyRerouteUrlResponse(StudyRerouteUrlResponse studyRerouteUrlResponse)
        : base(studyRerouteUrlResponse) { }
#pragma warning restore CS8618

    public StudyRerouteUrlResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyRerouteUrlResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StudyRerouteUrlResponseFromRaw.FromRawUnchecked"/>
    public static StudyRerouteUrlResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public StudyRerouteUrlResponse(string url)
        : this()
    {
        this.Url = url;
    }
}

class StudyRerouteUrlResponseFromRaw : IFromRawJson<StudyRerouteUrlResponse>
{
    /// <inheritdoc/>
    public StudyRerouteUrlResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StudyRerouteUrlResponse.FromRawUnchecked(rawData);
}
