using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.Express;

/// <summary>
/// Paginated list of Express customers
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ExpressListPageResponse, ExpressListPageResponseFromRaw>))]
public sealed record class ExpressListPageResponse : JsonModel
{
    public required IReadOnlyList<ExpressListResponse> ExpressCustomers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ExpressListResponse>>(
                "expressCustomers"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ExpressListResponse>>(
                "expressCustomers",
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
        foreach (var item in this.ExpressCustomers)
        {
            item.Validate();
        }
        _ = this.HasMore;
        _ = this.Cursor;
    }

    public ExpressListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExpressListPageResponse(ExpressListPageResponse expressListPageResponse)
        : base(expressListPageResponse) { }
#pragma warning restore CS8618

    public ExpressListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExpressListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExpressListPageResponseFromRaw.FromRawUnchecked"/>
    public static ExpressListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExpressListPageResponseFromRaw : IFromRawJson<ExpressListPageResponse>
{
    /// <inheritdoc/>
    public ExpressListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExpressListPageResponse.FromRawUnchecked(rawData);
}
