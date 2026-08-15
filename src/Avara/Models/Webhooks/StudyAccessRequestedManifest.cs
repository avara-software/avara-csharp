using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.Webhooks;

/// <summary>
/// Optional sidecar for this one study (one object, not an array). Not required —
/// omit if you do not have it. Recommended when you can provide it, especially for
/// very large studies. Enables progressive loading of legacy multi-SOP DICOM so
/// readers can scroll before every file is parsed. Include only this study. Series
/// you cannot describe can be left out. Invalid or incomplete values are ignored;
/// URLs still load.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<StudyAccessRequestedManifest, StudyAccessRequestedManifestFromRaw>)
)]
public sealed record class StudyAccessRequestedManifest : JsonModel
{
    /// <summary>
    /// Planable series in this study. At least one must survive validation.
    /// </summary>
    public required IReadOnlyList<StudyAccessRequestedManifestSeries> Series
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<StudyAccessRequestedManifestSeries>
            >("series");
        }
        init
        {
            this._rawData.Set<ImmutableArray<StudyAccessRequestedManifestSeries>>(
                "series",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// DICOM Study Instance UID for this study. Non-empty string. Must match the
    /// study being requested.
    /// </summary>
    public required string StudyInstanceUid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("studyInstanceUID");
        }
        init { this._rawData.Set("studyInstanceUID", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Series)
        {
            item.Validate();
        }
        _ = this.StudyInstanceUid;
    }

    public StudyAccessRequestedManifest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyAccessRequestedManifest(StudyAccessRequestedManifest studyAccessRequestedManifest)
        : base(studyAccessRequestedManifest) { }
#pragma warning restore CS8618

    public StudyAccessRequestedManifest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyAccessRequestedManifest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StudyAccessRequestedManifestFromRaw.FromRawUnchecked"/>
    public static StudyAccessRequestedManifest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StudyAccessRequestedManifestFromRaw : IFromRawJson<StudyAccessRequestedManifest>
{
    /// <inheritdoc/>
    public StudyAccessRequestedManifest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StudyAccessRequestedManifest.FromRawUnchecked(rawData);
}
