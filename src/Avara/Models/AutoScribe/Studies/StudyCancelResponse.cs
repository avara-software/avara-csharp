using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.AutoScribe.Studies;

/// <summary>
/// Response for cancelling a study in AutoScribe
/// </summary>
[JsonConverter(typeof(JsonModelConverter<StudyCancelResponse, StudyCancelResponseFromRaw>))]
public sealed record class StudyCancelResponse : JsonModel
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

    public StudyCancelResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyCancelResponse(StudyCancelResponse studyCancelResponse)
        : base(studyCancelResponse) { }
#pragma warning restore CS8618

    public StudyCancelResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyCancelResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StudyCancelResponseFromRaw.FromRawUnchecked"/>
    public static StudyCancelResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public StudyCancelResponse(bool success)
        : this()
    {
        this.Success = success;
    }
}

class StudyCancelResponseFromRaw : IFromRawJson<StudyCancelResponse>
{
    /// <inheritdoc/>
    public StudyCancelResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        StudyCancelResponse.FromRawUnchecked(rawData);
}
