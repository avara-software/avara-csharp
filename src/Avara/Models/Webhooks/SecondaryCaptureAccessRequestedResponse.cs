using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.Webhooks;

/// <summary>
/// Response expected by Avara for the secondary capture webhook. Provide presigned
/// PUT URLs the viewer will upload the DICOM to.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SecondaryCaptureAccessRequestedResponse,
        SecondaryCaptureAccessRequestedResponseFromRaw
    >)
)]
public sealed record class SecondaryCaptureAccessRequestedResponse : JsonModel
{
    /// <summary>
    /// Whether the secondary capture upload is authorized for this study
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
    /// Presigned PUT URLs for uploading the secondary capture DICOM. The viewer uploads
    /// the same object to every URL.
    /// </summary>
    public required IReadOnlyList<string> UploadUrls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("uploadUrls");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "uploadUrls",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Optional content creator name. Avara derives this server-side; this field
    /// is ignored if provided.
    /// </summary>
    public string? ContentCreatorName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("contentCreatorName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("contentCreatorName", value);
        }
    }

    /// <summary>
    /// Error message if authorization failed or upload URLs cannot be provided
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Authorized;
        _ = this.UploadUrls;
        _ = this.ContentCreatorName;
        _ = this.Error;
    }

    public SecondaryCaptureAccessRequestedResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SecondaryCaptureAccessRequestedResponse(
        SecondaryCaptureAccessRequestedResponse secondaryCaptureAccessRequestedResponse
    )
        : base(secondaryCaptureAccessRequestedResponse) { }
#pragma warning restore CS8618

    public SecondaryCaptureAccessRequestedResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SecondaryCaptureAccessRequestedResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SecondaryCaptureAccessRequestedResponseFromRaw.FromRawUnchecked"/>
    public static SecondaryCaptureAccessRequestedResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SecondaryCaptureAccessRequestedResponseFromRaw
    : IFromRawJson<SecondaryCaptureAccessRequestedResponse>
{
    /// <inheritdoc/>
    public SecondaryCaptureAccessRequestedResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SecondaryCaptureAccessRequestedResponse.FromRawUnchecked(rawData);
}
