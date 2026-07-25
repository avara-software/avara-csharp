using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.AutoScribe.ClinicalReferences;

/// <summary>
/// A canonical clinical reference value for study workflow pickers and normalization
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ClinicalReference, ClinicalReferenceFromRaw>))]
public sealed record class ClinicalReference : JsonModel
{
    /// <summary>
    /// Unique clinical reference identifier. Format: ref_{32-hex-chars}
    /// </summary>
    public required string ClinicalReferenceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("clinicalReferenceId");
        }
        init { this._rawData.Set("clinicalReferenceId", value); }
    }

    /// <summary>
    /// Timestamp when the clinical reference was created
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
    /// Whether this reference is active and available for pickers
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
    /// Canonical display name for this reference value
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Category of canonical clinical reference value used for study workflow pickers
    /// and normalization.
    /// </summary>
    public required ApiEnum<string, ClinicalReferenceType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ClinicalReferenceType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Timestamp when the clinical reference was last updated
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
    /// A reference to an Express customer with basic identifying information
    /// </summary>
    public ExpressCustomerReference? ExpressCustomer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExpressCustomerReference>("expressCustomer");
        }
        init { this._rawData.Set("expressCustomer", value); }
    }

    /// <summary>
    /// Integrator-provided stable identifier for mapping inbound data
    /// </summary>
    public string? ExternalReferenceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("externalReferenceId");
        }
        init { this._rawData.Set("externalReferenceId", value); }
    }

    /// <summary>
    /// Optional key-value metadata. Maximum 50 pairs
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
        _ = this.ClinicalReferenceID;
        _ = this.CreatedAt;
        _ = this.IsActive;
        _ = this.Name;
        this.Type.Validate();
        _ = this.UpdatedAt;
        this.ExpressCustomer?.Validate();
        _ = this.ExternalReferenceID;
        _ = this.Metadata;
    }

    public ClinicalReference() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClinicalReference(ClinicalReference clinicalReference)
        : base(clinicalReference) { }
#pragma warning restore CS8618

    public ClinicalReference(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClinicalReference(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ClinicalReferenceFromRaw.FromRawUnchecked"/>
    public static ClinicalReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClinicalReferenceFromRaw : IFromRawJson<ClinicalReference>
{
    /// <inheritdoc/>
    public ClinicalReference FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ClinicalReference.FromRawUnchecked(rawData);
}
