using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.Webhooks;

/// <summary>
/// Synchronous response with presigned DICOM URLs and optionally non-DICOM media.
/// Optionally include a manifests array (one study per item) to improve progressive
/// loading of legacy DICOM; it is not required.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EphemeralAccessRequestedResponse,
        EphemeralAccessRequestedResponseFromRaw
    >)
)]
public sealed record class EphemeralAccessRequestedResponse : JsonModel
{
    /// <summary>
    /// Whether access is authorized for this ephemeral session
    /// </summary>
    public required bool Authorized
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("authorized");
        }
        init { this._rawData.Set("authorized", value); }
    }

    /// <summary>
    /// Flat list of presigned URLs for DICOM images across the session.
    /// </summary>
    public required IReadOnlyList<string> Urls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("urls");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "urls",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Error message if authorization failed or URLs cannot be provided
    /// </summary>
    public string? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("error", value);
        }
    }

    /// <summary>
    /// Optional sidecars, one study per item (an array, not a single object). Not
    /// required — omit if you do not have them. Recommended when you can provide
    /// them, especially for very large or multi-study legacy DICOM. Enables progressive
    /// loading so readers can scroll before every file is parsed. Invalid or incomplete
    /// values are ignored; URLs still load.
    /// </summary>
    public IReadOnlyList<StudyAccessRequestedManifest>? Manifests
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<StudyAccessRequestedManifest>>(
                "manifests"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<StudyAccessRequestedManifest>?>(
                "manifests",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Optional presigned URLs for non-DICOM media (images, PDFs, videos).
    /// </summary>
    public IReadOnlyList<StudyAccessRequestedMediaUrl>? MediaUrls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<StudyAccessRequestedMediaUrl>>(
                "mediaUrls"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<StudyAccessRequestedMediaUrl>?>(
                "mediaUrls",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Authorized;
        _ = this.Urls;
        _ = this.Error;
        foreach (var item in this.Manifests ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.MediaUrls ?? [])
        {
            item.Validate();
        }
    }

    public EphemeralAccessRequestedResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EphemeralAccessRequestedResponse(
        EphemeralAccessRequestedResponse ephemeralAccessRequestedResponse
    )
        : base(ephemeralAccessRequestedResponse) { }
#pragma warning restore CS8618

    public EphemeralAccessRequestedResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EphemeralAccessRequestedResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EphemeralAccessRequestedResponseFromRaw.FromRawUnchecked"/>
    public static EphemeralAccessRequestedResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EphemeralAccessRequestedResponseFromRaw : IFromRawJson<EphemeralAccessRequestedResponse>
{
    /// <inheritdoc/>
    public EphemeralAccessRequestedResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EphemeralAccessRequestedResponse.FromRawUnchecked(rawData);
}
