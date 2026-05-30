using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Exceptions;

namespace Avara.Models.Viewer;

/// <summary>
/// Viewer completion status for a study. 'incomplete' = not yet finished in the viewer,
/// 'complete' = finished.
/// </summary>
[JsonConverter(typeof(StudyViewerStatusConverter))]
public enum StudyViewerStatus
{
    Incomplete,
    Complete,
}

sealed class StudyViewerStatusConverter : JsonConverter<StudyViewerStatus>
{
    public override StudyViewerStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "incomplete" => StudyViewerStatus.Incomplete,
            "complete" => StudyViewerStatus.Complete,
            _ => (StudyViewerStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StudyViewerStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StudyViewerStatus.Incomplete => "incomplete",
                StudyViewerStatus.Complete => "complete",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
