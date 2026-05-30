using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Exceptions;

namespace Avara.Models.AutoScribe;

/// <summary>
/// AutoScribe report workflow status for a study. 'unassigned' = no radiologist assigned,
/// 'assigned' = assigned but not started, 'in_progress' = actively being dictated,
/// 'completed' = report signed, 'addendum_active' = addendum in progress.
/// </summary>
[JsonConverter(typeof(StudyReportStatusConverter))]
public enum StudyReportStatus
{
    Unassigned,
    Assigned,
    InProgress,
    Completed,
    AddendumActive,
}

sealed class StudyReportStatusConverter : JsonConverter<StudyReportStatus>
{
    public override StudyReportStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unassigned" => StudyReportStatus.Unassigned,
            "assigned" => StudyReportStatus.Assigned,
            "in_progress" => StudyReportStatus.InProgress,
            "completed" => StudyReportStatus.Completed,
            "addendum_active" => StudyReportStatus.AddendumActive,
            _ => (StudyReportStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StudyReportStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StudyReportStatus.Unassigned => "unassigned",
                StudyReportStatus.Assigned => "assigned",
                StudyReportStatus.InProgress => "in_progress",
                StudyReportStatus.Completed => "completed",
                StudyReportStatus.AddendumActive => "addendum_active",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
