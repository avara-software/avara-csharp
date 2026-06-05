using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.Webhooks;

/// <summary>
/// Presigned URL for non-DICOM media (images, PDFs, videos)
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<StudyAccessRequestedMediaUrl, StudyAccessRequestedMediaUrlFromRaw>)
)]
public sealed record class StudyAccessRequestedMediaUrl : JsonModel
{
    /// <summary>
    /// MIME type of the media file (e.g., application/pdf, image/jpeg, video/mp4)
    /// </summary>
    public required string MimeType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("mimeType");
        }
        init { this._rawData.Set("mimeType", value); }
    }

    /// <summary>
    /// Presigned URL to download the media file
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

    /// <summary>
    /// Optional display name for the media file
    /// </summary>
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
        _ = this.MimeType;
        _ = this.Url;
        _ = this.FileName;
    }

    public StudyAccessRequestedMediaUrl() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyAccessRequestedMediaUrl(StudyAccessRequestedMediaUrl studyAccessRequestedMediaUrl)
        : base(studyAccessRequestedMediaUrl) { }
#pragma warning restore CS8618

    public StudyAccessRequestedMediaUrl(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyAccessRequestedMediaUrl(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StudyAccessRequestedMediaUrlFromRaw.FromRawUnchecked"/>
    public static StudyAccessRequestedMediaUrl FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StudyAccessRequestedMediaUrlFromRaw : IFromRawJson<StudyAccessRequestedMediaUrl>
{
    /// <inheritdoc/>
    public StudyAccessRequestedMediaUrl FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StudyAccessRequestedMediaUrl.FromRawUnchecked(rawData);
}
