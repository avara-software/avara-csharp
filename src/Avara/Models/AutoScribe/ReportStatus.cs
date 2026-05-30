using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Exceptions;

namespace Avara.Models.AutoScribe;

/// <summary>
/// Status of an individual report. 'in_progress' = actively being dictated, 'completed'
/// = signed.
/// </summary>
[JsonConverter(typeof(ReportStatusConverter))]
public enum ReportStatus
{
    InProgress,
    Completed,
}

sealed class ReportStatusConverter : JsonConverter<ReportStatus>
{
    public override ReportStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "in_progress" => ReportStatus.InProgress,
            "completed" => ReportStatus.Completed,
            _ => (ReportStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReportStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReportStatus.InProgress => "in_progress",
                ReportStatus.Completed => "completed",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
