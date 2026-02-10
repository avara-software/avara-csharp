using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.Viewer.Studies;

/// <summary>
/// Paginated list of Viewer studies
/// </summary>
[JsonConverter(typeof(JsonModelConverter<StudyListPageResponse, StudyListPageResponseFromRaw>))]
public sealed record class StudyListPageResponse : JsonModel
{
    public required bool HasMore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("hasMore");
        }
        init { this._rawData.Set("hasMore", value); }
    }

    public required IReadOnlyList<StudyListResponse> Studies
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<StudyListResponse>>("studies");
        }
        init
        {
            this._rawData.Set<ImmutableArray<StudyListResponse>>(
                "studies",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Cursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cursor", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HasMore;
        foreach (var item in this.Studies)
        {
            item.Validate();
        }
        _ = this.Cursor;
    }

    public StudyListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyListPageResponse(StudyListPageResponse studyListPageResponse)
        : base(studyListPageResponse) { }
#pragma warning restore CS8618

    public StudyListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StudyListPageResponseFromRaw.FromRawUnchecked"/>
    public static StudyListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StudyListPageResponseFromRaw : IFromRawJson<StudyListPageResponse>
{
    /// <inheritdoc/>
    public StudyListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StudyListPageResponse.FromRawUnchecked(rawData);
}
