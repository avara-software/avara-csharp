using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.Express;

/// <summary>
/// An Express customer entity that groups users and studies
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ExpressReactivateResponse, ExpressReactivateResponseFromRaw>)
)]
public sealed record class ExpressReactivateResponse : JsonModel
{
    /// <summary>
    /// Timestamp when the Express customer was created
    /// </summary>
    public required DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// Unique Express customer identifier. Format: cus_{32-hex-chars}
    /// </summary>
    public required string ExpressCustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("expressCustomerId");
        }
        init { this._rawData.Set("expressCustomerId", value); }
    }

    /// <summary>
    /// Name of the Express customer
    /// </summary>
    public required string ExpressCustomerName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("expressCustomerName");
        }
        init { this._rawData.Set("expressCustomerName", value); }
    }

    /// <summary>
    /// Whether the Express customer is currently active
    /// </summary>
    public required bool IsActive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isActive");
        }
        init { this._rawData.Set("isActive", value); }
    }

    /// <summary>
    /// Timestamp when the Express customer was last updated
    /// </summary>
    public required DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    /// <summary>
    /// Number of users currently in this Express customer
    /// </summary>
    public required long UserCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("userCount");
        }
        init { this._rawData.Set("userCount", value); }
    }

    /// <summary>
    /// UUID of the API key used to create this Express customer, for audit tracking
    /// </summary>
    public string? CreatedByApiKeyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("createdByApiKeyId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdByApiKeyId", value);
        }
    }

    /// <summary>
    /// User ID who created this Express customer via dashboard, null if created
    /// via API key
    /// </summary>
    public string? CreatedByUserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("createdByUserId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdByUserId", value);
        }
    }

    /// <summary>
    /// Custom key-value metadata for the Express customer. Maximum 50 pairs, keys
    /// up to 100 chars, values up to 1000 chars
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.ExpressCustomerID;
        _ = this.ExpressCustomerName;
        _ = this.IsActive;
        _ = this.UpdatedAt;
        _ = this.UserCount;
        _ = this.CreatedByApiKeyID;
        _ = this.CreatedByUserID;
        _ = this.Metadata;
    }

    public ExpressReactivateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExpressReactivateResponse(ExpressReactivateResponse expressReactivateResponse)
        : base(expressReactivateResponse) { }
#pragma warning restore CS8618

    public ExpressReactivateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExpressReactivateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExpressReactivateResponseFromRaw.FromRawUnchecked"/>
    public static ExpressReactivateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExpressReactivateResponseFromRaw : IFromRawJson<ExpressReactivateResponse>
{
    /// <inheritdoc/>
    public ExpressReactivateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExpressReactivateResponse.FromRawUnchecked(rawData);
}
