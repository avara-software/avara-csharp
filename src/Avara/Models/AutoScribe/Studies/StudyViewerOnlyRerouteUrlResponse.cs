using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.AutoScribe.Studies;

/// <summary>
/// Response containing the generated viewer-only reroute URL. Requires viewer to
/// be configured.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        StudyViewerOnlyRerouteUrlResponse,
        StudyViewerOnlyRerouteUrlResponseFromRaw
    >)
)]
public sealed record class StudyViewerOnlyRerouteUrlResponse : JsonModel
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

    public StudyViewerOnlyRerouteUrlResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyViewerOnlyRerouteUrlResponse(
        StudyViewerOnlyRerouteUrlResponse studyViewerOnlyRerouteUrlResponse
    )
        : base(studyViewerOnlyRerouteUrlResponse) { }
#pragma warning restore CS8618

    public StudyViewerOnlyRerouteUrlResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyViewerOnlyRerouteUrlResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StudyViewerOnlyRerouteUrlResponseFromRaw.FromRawUnchecked"/>
    public static StudyViewerOnlyRerouteUrlResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public StudyViewerOnlyRerouteUrlResponse(string url)
        : this()
    {
        this.Url = url;
    }
}

class StudyViewerOnlyRerouteUrlResponseFromRaw : IFromRawJson<StudyViewerOnlyRerouteUrlResponse>
{
    /// <inheritdoc/>
    public StudyViewerOnlyRerouteUrlResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StudyViewerOnlyRerouteUrlResponse.FromRawUnchecked(rawData);
}
