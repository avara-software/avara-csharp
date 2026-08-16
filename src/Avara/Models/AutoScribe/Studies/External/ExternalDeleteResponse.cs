using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.AutoScribe.Studies.External;

/// <summary>
/// Result of deleting an external study
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ExternalDeleteResponse, ExternalDeleteResponseFromRaw>))]
public sealed record class ExternalDeleteResponse : JsonModel
{
    public required bool Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Success;
        _ = this.Message;
    }

    public ExternalDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalDeleteResponse(ExternalDeleteResponse externalDeleteResponse)
        : base(externalDeleteResponse) { }
#pragma warning restore CS8618

    public ExternalDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExternalDeleteResponseFromRaw.FromRawUnchecked"/>
    public static ExternalDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ExternalDeleteResponse(bool success)
        : this()
    {
        this.Success = success;
    }
}

class ExternalDeleteResponseFromRaw : IFromRawJson<ExternalDeleteResponse>
{
    /// <inheritdoc/>
    public ExternalDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExternalDeleteResponse.FromRawUnchecked(rawData);
}
