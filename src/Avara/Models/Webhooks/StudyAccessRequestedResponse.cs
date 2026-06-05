using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.Webhooks;

/// <summary>
/// Response expected by Avara for study access webhook. Provide presigned URLs for
/// DICOM images and optionally for non-DICOM media.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<StudyAccessRequestedResponse, StudyAccessRequestedResponseFromRaw>)
)]
public sealed record class StudyAccessRequestedResponse : JsonModel
{
    /// <summary>
    /// Whether access is authorized for this study
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
    /// Flat list of presigned URLs for DICOM images. Include all image URLs for the study.
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
    /// Optional presigned URLs for non-DICOM media (images, PDFs, videos) associated
    /// with the study.
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
        foreach (var item in this.MediaUrls ?? [])
        {
            item.Validate();
        }
    }

    public StudyAccessRequestedResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyAccessRequestedResponse(StudyAccessRequestedResponse studyAccessRequestedResponse)
        : base(studyAccessRequestedResponse) { }
#pragma warning restore CS8618

    public StudyAccessRequestedResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyAccessRequestedResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StudyAccessRequestedResponseFromRaw.FromRawUnchecked"/>
    public static StudyAccessRequestedResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StudyAccessRequestedResponseFromRaw : IFromRawJson<StudyAccessRequestedResponse>
{
    /// <inheritdoc/>
    public StudyAccessRequestedResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StudyAccessRequestedResponse.FromRawUnchecked(rawData);
}
