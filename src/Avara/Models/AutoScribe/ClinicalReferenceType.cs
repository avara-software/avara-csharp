using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Exceptions;

namespace Avara.Models.AutoScribe;

/// <summary>
/// Category of canonical clinical reference value used for study workflow pickers
/// and normalization.
/// </summary>
[JsonConverter(typeof(ClinicalReferenceTypeConverter))]
public enum ClinicalReferenceType
{
    Facility,
    ReferringProvider,
    StudyDescription,
    ImagingProtocol,
}

sealed class ClinicalReferenceTypeConverter : JsonConverter<ClinicalReferenceType>
{
    public override ClinicalReferenceType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "facility" => ClinicalReferenceType.Facility,
            "referring_provider" => ClinicalReferenceType.ReferringProvider,
            "study_description" => ClinicalReferenceType.StudyDescription,
            "imaging_protocol" => ClinicalReferenceType.ImagingProtocol,
            _ => (ClinicalReferenceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ClinicalReferenceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ClinicalReferenceType.Facility => "facility",
                ClinicalReferenceType.ReferringProvider => "referring_provider",
                ClinicalReferenceType.StudyDescription => "study_description",
                ClinicalReferenceType.ImagingProtocol => "imaging_protocol",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
