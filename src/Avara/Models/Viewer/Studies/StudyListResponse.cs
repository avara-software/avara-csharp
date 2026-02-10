using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;
using Avara.Exceptions;

namespace Avara.Models.Viewer.Studies;

/// <summary>
/// A study entity in the Viewer system with viewing status
/// </summary>
[JsonConverter(typeof(JsonModelConverter<StudyListResponse, StudyListResponseFromRaw>))]
public sealed record class StudyListResponse : JsonModel
{
    /// <summary>
    /// Timestamp when the study was cancelled, null if not cancelled
    /// </summary>
    public required DateTimeOffset? CancelledAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("cancelledAt");
        }
        init { this._rawData.Set("cancelledAt", value); }
    }

    /// <summary>
    /// Timestamp when the study was created
    /// </summary>
    public required DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// Whether the study has been cancelled
    /// </summary>
    public required bool IsCancelled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isCancelled");
        }
        init { this._rawData.Set("isCancelled", value); }
    }

    /// <summary>
    /// Priority level of the study. 'normal' for routine, 'high' for urgent, 'stat'
    /// for immediate attention
    /// </summary>
    public required ApiEnum<string, StudyListResponseSeverity> Severity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, StudyListResponseSeverity>>(
                "severity"
            );
        }
        init { this._rawData.Set("severity", value); }
    }

    /// <summary>
    /// Description of the study/scan (e.g., 'Brain MRI with Contrast', 'Chest CT')
    /// </summary>
    public required string StudyDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("studyDescription");
        }
        init { this._rawData.Set("studyDescription", value); }
    }

    /// <summary>
    /// Unique study identifier. Format: stu_{32-hex-chars}
    /// </summary>
    public required string StudyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("studyId");
        }
        init { this._rawData.Set("studyId", value); }
    }

    /// <summary>
    /// DICOM Study Instance UID. Must be a valid DICOM UID format (e.g., '1.2.840.10008.5.1.4.1.1.2')
    /// </summary>
    public required string StudyInstanceUid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("studyInstanceUid");
        }
        init { this._rawData.Set("studyInstanceUid", value); }
    }

    /// <summary>
    /// Study viewer completion status
    /// </summary>
    public required ApiEnum<string, StudyListResponseStudyViewerStatus> StudyViewerStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, StudyListResponseStudyViewerStatus>
            >("studyViewerStatus");
        }
        init { this._rawData.Set("studyViewerStatus", value); }
    }

    /// <summary>
    /// Timestamp when the study was last updated
    /// </summary>
    public required DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    /// <summary>
    /// A reference to a user with basic identifying information
    /// </summary>
    public UserReference? AssignedTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserReference>("assignedTo");
        }
        init { this._rawData.Set("assignedTo", value); }
    }

    /// <summary>
    /// A reference to an API key with basic identifying information
    /// </summary>
    public ApiKeyReference? CreatedByApiKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiKeyReference>("createdByApiKey");
        }
        init { this._rawData.Set("createdByApiKey", value); }
    }

    /// <summary>
    /// A reference to a user with basic identifying information
    /// </summary>
    public UserReference? CreatedByUser
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserReference>("createdByUser");
        }
        init { this._rawData.Set("createdByUser", value); }
    }

    /// <summary>
    /// A reference to an Express customer with basic identifying information
    /// </summary>
    public ExpressCustomerReference? ExpressCustomer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExpressCustomerReference>("expressCustomer");
        }
        init { this._rawData.Set("expressCustomer", value); }
    }

    /// <summary>
    /// Custom key-value metadata for the study. Maximum 50 pairs, keys up to 100
    /// chars, values up to 1000 chars
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CancelledAt;
        _ = this.CreatedAt;
        _ = this.IsCancelled;
        this.Severity.Validate();
        _ = this.StudyDescription;
        _ = this.StudyID;
        _ = this.StudyInstanceUid;
        this.StudyViewerStatus.Validate();
        _ = this.UpdatedAt;
        this.AssignedTo?.Validate();
        this.CreatedByApiKey?.Validate();
        this.CreatedByUser?.Validate();
        this.ExpressCustomer?.Validate();
        _ = this.Metadata;
    }

    public StudyListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyListResponse(StudyListResponse studyListResponse)
        : base(studyListResponse) { }
#pragma warning restore CS8618

    public StudyListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StudyListResponseFromRaw.FromRawUnchecked"/>
    public static StudyListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StudyListResponseFromRaw : IFromRawJson<StudyListResponse>
{
    /// <inheritdoc/>
    public StudyListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        StudyListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Priority level of the study. 'normal' for routine, 'high' for urgent, 'stat'
/// for immediate attention
/// </summary>
[JsonConverter(typeof(StudyListResponseSeverityConverter))]
public enum StudyListResponseSeverity
{
    Normal,
    High,
    Stat,
}

sealed class StudyListResponseSeverityConverter : JsonConverter<StudyListResponseSeverity>
{
    public override StudyListResponseSeverity Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "normal" => StudyListResponseSeverity.Normal,
            "high" => StudyListResponseSeverity.High,
            "stat" => StudyListResponseSeverity.Stat,
            _ => (StudyListResponseSeverity)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StudyListResponseSeverity value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StudyListResponseSeverity.Normal => "normal",
                StudyListResponseSeverity.High => "high",
                StudyListResponseSeverity.Stat => "stat",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Study viewer completion status
/// </summary>
[JsonConverter(typeof(StudyListResponseStudyViewerStatusConverter))]
public enum StudyListResponseStudyViewerStatus
{
    Incomplete,
    Complete,
}

sealed class StudyListResponseStudyViewerStatusConverter
    : JsonConverter<StudyListResponseStudyViewerStatus>
{
    public override StudyListResponseStudyViewerStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "incomplete" => StudyListResponseStudyViewerStatus.Incomplete,
            "complete" => StudyListResponseStudyViewerStatus.Complete,
            _ => (StudyListResponseStudyViewerStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StudyListResponseStudyViewerStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StudyListResponseStudyViewerStatus.Incomplete => "incomplete",
                StudyListResponseStudyViewerStatus.Complete => "complete",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
