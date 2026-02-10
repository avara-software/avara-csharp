using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;
using Avara.Exceptions;

namespace Avara.Models.AutoScribe.Studies;

/// <summary>
/// A report ID paired with its current status
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ReportIDWithStatus, ReportIDWithStatusFromRaw>))]
public sealed record class ReportIDWithStatus : JsonModel
{
    /// <summary>
    /// Unique report identifier. Format: rep_{32-hex-chars}
    /// </summary>
    public required string ReportID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reportId");
        }
        init { this._rawData.Set("reportId", value); }
    }

    /// <summary>
    /// Current status of the report
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ReportID;
        this.Status.Validate();
    }

    public ReportIDWithStatus() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReportIDWithStatus(ReportIDWithStatus reportIDWithStatus)
        : base(reportIDWithStatus) { }
#pragma warning restore CS8618

    public ReportIDWithStatus(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReportIDWithStatus(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReportIDWithStatusFromRaw.FromRawUnchecked"/>
    public static ReportIDWithStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReportIDWithStatusFromRaw : IFromRawJson<ReportIDWithStatus>
{
    /// <inheritdoc/>
    public ReportIDWithStatus FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ReportIDWithStatus.FromRawUnchecked(rawData);
}

/// <summary>
/// Current status of the report
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    InProgress,
    Completed,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "in_progress" => Status.InProgress,
            "completed" => Status.Completed,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.InProgress => "in_progress",
                Status.Completed => "completed",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
