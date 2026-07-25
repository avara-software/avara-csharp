using System.Text.Json;
using Avara.Exceptions;
using Avara.Models;
using Avara.Models.AutoScribe;
using Avara.Models.Viewer;

namespace Avara.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    protected ModelBase(ModelBase modelBase)
    {
        // Nothing to copy. Just so that subclasses can define copy constructors.
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new FrozenDictionaryConverterFactory(),
            new ApiEnumConverter<string, AssignableUserLevel>(),
            new ApiEnumConverter<string, ClinicRole>(),
            new ApiEnumConverter<string, InvitationExpiredFilter>(),
            new ApiEnumConverter<string, InvitationStatus>(),
            new ApiEnumConverter<string, InvitedSource>(),
            new ApiEnumConverter<string, Severity>(),
            new ApiEnumConverter<string, UserLevel>(),
            new ApiEnumConverter<string, ClinicalReferenceType>(),
            new ApiEnumConverter<string, HeightUnit>(),
            new ApiEnumConverter<string, ReportStatus>(),
            new ApiEnumConverter<string, Sex>(),
            new ApiEnumConverter<string, StudyReportStatus>(),
            new ApiEnumConverter<string, WeightUnit>(),
            new ApiEnumConverter<string, StudyViewerStatus>(),
        },
    };

    internal static readonly JsonSerializerOptions ToStringSerializerOptions = new(
        SerializerOptions
    )
    {
        WriteIndented = true,
    };

    /// <summary>
    /// Validates that all required fields are set and that each field's value is of the expected type.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="AvaraInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}
