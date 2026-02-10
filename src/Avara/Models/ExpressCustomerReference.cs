using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models;

/// <summary>
/// A reference to an Express customer with basic identifying information
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ExpressCustomerReference, ExpressCustomerReferenceFromRaw>)
)]
public sealed record class ExpressCustomerReference : JsonModel
{
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExpressCustomerID;
        _ = this.ExpressCustomerName;
    }

    public ExpressCustomerReference() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExpressCustomerReference(ExpressCustomerReference expressCustomerReference)
        : base(expressCustomerReference) { }
#pragma warning restore CS8618

    public ExpressCustomerReference(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExpressCustomerReference(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExpressCustomerReferenceFromRaw.FromRawUnchecked"/>
    public static ExpressCustomerReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExpressCustomerReferenceFromRaw : IFromRawJson<ExpressCustomerReference>
{
    /// <inheritdoc/>
    public ExpressCustomerReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExpressCustomerReference.FromRawUnchecked(rawData);
}
