using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models;

/// <summary>
/// Optional single-monitor hanging protocol applied when the ephemeral viewer loads.
/// Omitted = no protocol. Invalid shape is rejected.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<EphemeralHangingProtocol, EphemeralHangingProtocolFromRaw>)
)]
public sealed record class EphemeralHangingProtocol : JsonModel
{
    /// <summary>
    /// Viewport grid layout for an ephemeral hanging protocol. Wire values match
    /// first-party viewer layouts ('1x1' through '4x4').
    /// </summary>
    public required ApiEnum<string, ViewerLayout> Layout
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ViewerLayout>>("layout");
        }
        init { this._rawData.Set("layout", value); }
    }

    public required IReadOnlyList<string?> ViewportAssignments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string?>>("viewportAssignments");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string?>>(
                "viewportAssignments",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Layout.Validate();
        _ = this.ViewportAssignments;
    }

    public EphemeralHangingProtocol() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EphemeralHangingProtocol(EphemeralHangingProtocol ephemeralHangingProtocol)
        : base(ephemeralHangingProtocol) { }
#pragma warning restore CS8618

    public EphemeralHangingProtocol(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EphemeralHangingProtocol(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EphemeralHangingProtocolFromRaw.FromRawUnchecked"/>
    public static EphemeralHangingProtocol FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EphemeralHangingProtocolFromRaw : IFromRawJson<EphemeralHangingProtocol>
{
    /// <inheritdoc/>
    public EphemeralHangingProtocol FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EphemeralHangingProtocol.FromRawUnchecked(rawData);
}
