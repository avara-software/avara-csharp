using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.AutoScribe.ClinicalReferences;

/// <summary>
/// Paginated list of clinical references
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ClinicalReferenceListPageResponse,
        ClinicalReferenceListPageResponseFromRaw
    >)
)]
public sealed record class ClinicalReferenceListPageResponse : JsonModel
{
    public required IReadOnlyList<ClinicalReference> ClinicalReferences
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ClinicalReference>>(
                "clinicalReferences"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ClinicalReference>>(
                "clinicalReferences",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required bool HasMore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("hasMore");
        }
        init { this._rawData.Set("hasMore", value); }
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
        foreach (var item in this.ClinicalReferences)
        {
            item.Validate();
        }
        _ = this.HasMore;
        _ = this.Cursor;
    }

    public ClinicalReferenceListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClinicalReferenceListPageResponse(
        ClinicalReferenceListPageResponse clinicalReferenceListPageResponse
    )
        : base(clinicalReferenceListPageResponse) { }
#pragma warning restore CS8618

    public ClinicalReferenceListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClinicalReferenceListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ClinicalReferenceListPageResponseFromRaw.FromRawUnchecked"/>
    public static ClinicalReferenceListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClinicalReferenceListPageResponseFromRaw : IFromRawJson<ClinicalReferenceListPageResponse>
{
    /// <inheritdoc/>
    public ClinicalReferenceListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ClinicalReferenceListPageResponse.FromRawUnchecked(rawData);
}
