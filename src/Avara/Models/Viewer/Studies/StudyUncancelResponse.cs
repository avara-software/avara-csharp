using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.Viewer.Studies;

/// <summary>
/// Response for uncancelling a study in Viewer
/// </summary>
[JsonConverter(typeof(JsonModelConverter<StudyUncancelResponse, StudyUncancelResponseFromRaw>))]
public sealed record class StudyUncancelResponse : JsonModel
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

    public StudyUncancelResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyUncancelResponse(StudyUncancelResponse studyUncancelResponse)
        : base(studyUncancelResponse) { }
#pragma warning restore CS8618

    public StudyUncancelResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyUncancelResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StudyUncancelResponseFromRaw.FromRawUnchecked"/>
    public static StudyUncancelResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public StudyUncancelResponse(bool success)
        : this()
    {
        this.Success = success;
    }
}

class StudyUncancelResponseFromRaw : IFromRawJson<StudyUncancelResponse>
{
    /// <inheritdoc/>
    public StudyUncancelResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StudyUncancelResponse.FromRawUnchecked(rawData);
}
