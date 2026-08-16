using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.AutoScribe.Studies.External.Reports;

/// <summary>
/// Paginated list of external reports without text or file URLs
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ReportListPageResponse, ReportListPageResponseFromRaw>))]
public sealed record class ReportListPageResponse : JsonModel
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

    public required IReadOnlyList<ReportListResponse> Reports
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ReportListResponse>>("reports");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ReportListResponse>>(
                "reports",
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
        foreach (var item in this.Reports)
        {
            item.Validate();
        }
        _ = this.Cursor;
    }

    public ReportListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReportListPageResponse(ReportListPageResponse reportListPageResponse)
        : base(reportListPageResponse) { }
#pragma warning restore CS8618

    public ReportListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReportListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReportListPageResponseFromRaw.FromRawUnchecked"/>
    public static ReportListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReportListPageResponseFromRaw : IFromRawJson<ReportListPageResponse>
{
    /// <inheritdoc/>
    public ReportListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReportListPageResponse.FromRawUnchecked(rawData);
}
