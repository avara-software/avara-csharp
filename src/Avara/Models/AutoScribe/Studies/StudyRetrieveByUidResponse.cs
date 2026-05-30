using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;
using Avara.Exceptions;

namespace Avara.Models.AutoScribe.Studies;

/// <summary>
/// A study entity in the AutoScribe system with report workflow status
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<StudyRetrieveByUidResponse, StudyRetrieveByUidResponseFromRaw>)
)]
public sealed record class StudyRetrieveByUidResponse : JsonModel
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
    /// Patient demographics and scan information for report generation
    /// </summary>
    public required StudyReportMetadata ReportMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<StudyReportMetadata>("reportMetadata");
        }
        init { this._rawData.Set("reportMetadata", value); }
    }

    /// <summary>
    /// Priority level of the study. 'normal' for routine, 'high' for urgent, 'stat'
    /// for immediate attention
    /// </summary>
    public required ApiEnum<string, StudyRetrieveByUidResponseSeverity> Severity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, StudyRetrieveByUidResponseSeverity>
            >("severity");
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
    /// Report workflow status. 'unassigned' = no radiologist assigned, 'assigned'
    /// = assigned but not started, 'in_progress' = actively being dictated, 'completed'
    /// = report signed, 'addendum_active' = addendum in progress
    /// </summary>
    public required ApiEnum<string, StudyRetrieveByUidResponseStudyReportStatus> StudyReportStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, StudyRetrieveByUidResponseStudyReportStatus>
            >("studyReportStatus");
        }
        init { this._rawData.Set("studyReportStatus", value); }
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
    /// Reference to the assigned radiologist, null if unassigned
    /// </summary>
    public StudyRetrieveByUidResponseAssignedTo? AssignedTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<StudyRetrieveByUidResponseAssignedTo>(
                "assignedTo"
            );
        }
        init { this._rawData.Set("assignedTo", value); }
    }

    /// <summary>
    /// Relevant clinical history for the study
    /// </summary>
    public string? ClinicalHistory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("clinicalHistory");
        }
        init { this._rawData.Set("clinicalHistory", value); }
    }

    /// <summary>
    /// Clinical indication for the study
    /// </summary>
    public string? ClinicalIndication
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("clinicalIndication");
        }
        init { this._rawData.Set("clinicalIndication", value); }
    }

    /// <summary>
    /// Reference to the API key used to create this study
    /// </summary>
    public StudyRetrieveByUidResponseCreatedByApiKey? CreatedByApiKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<StudyRetrieveByUidResponseCreatedByApiKey>(
                "createdByApiKey"
            );
        }
        init { this._rawData.Set("createdByApiKey", value); }
    }

    /// <summary>
    /// Reference to the user who created this study via dashboard
    /// </summary>
    public StudyRetrieveByUidResponseCreatedByUser? CreatedByUser
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<StudyRetrieveByUidResponseCreatedByUser>(
                "createdByUser"
            );
        }
        init { this._rawData.Set("createdByUser", value); }
    }

    /// <summary>
    /// Reference to the Express customer this study belongs to
    /// </summary>
    public StudyRetrieveByUidResponseExpressCustomer? ExpressCustomer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<StudyRetrieveByUidResponseExpressCustomer>(
                "expressCustomer"
            );
        }
        init { this._rawData.Set("expressCustomer", value); }
    }

    /// <summary>
    /// Integrator-provided stable patient identifier for linking studies
    /// </summary>
    public string? ExternalPatientID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("externalPatientId");
        }
        init { this._rawData.Set("externalPatientId", value); }
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

    /// <summary>
    /// Imaging modality for the study (free text)
    /// </summary>
    public string? Modality
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("modality");
        }
        init { this._rawData.Set("modality", value); }
    }

    /// <summary>
    /// External prior reports with metadata and text
    /// </summary>
    public IReadOnlyList<StudyRetrieveByUidResponsePriorReport>? PriorReports
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<StudyRetrieveByUidResponsePriorReport>
            >("priorReports");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<StudyRetrieveByUidResponsePriorReport>?>(
                "priorReports",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Array of report IDs associated with this study, including addendums
    /// </summary>
    public IReadOnlyList<ReportIDWithStatus>? ReportIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ReportIDWithStatus>>("reportIds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ReportIDWithStatus>?>(
                "reportIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Technologist notes for the study
    /// </summary>
    public IReadOnlyList<string>? TechnologistNotes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("technologistNotes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "technologistNotes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Imaging technique description
    /// </summary>
    public string? TechnologistTechnique
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("technologistTechnique");
        }
        init { this._rawData.Set("technologistTechnique", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CancelledAt;
        _ = this.CreatedAt;
        _ = this.IsCancelled;
        this.ReportMetadata.Validate();
        this.Severity.Validate();
        _ = this.StudyDescription;
        _ = this.StudyID;
        _ = this.StudyInstanceUid;
        this.StudyReportStatus.Validate();
        _ = this.UpdatedAt;
        this.AssignedTo?.Validate();
        _ = this.ClinicalHistory;
        _ = this.ClinicalIndication;
        this.CreatedByApiKey?.Validate();
        this.CreatedByUser?.Validate();
        this.ExpressCustomer?.Validate();
        _ = this.ExternalPatientID;
        _ = this.Metadata;
        _ = this.Modality;
        foreach (var item in this.PriorReports ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.ReportIds ?? [])
        {
            item.Validate();
        }
        _ = this.TechnologistNotes;
        _ = this.TechnologistTechnique;
    }

    public StudyRetrieveByUidResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyRetrieveByUidResponse(StudyRetrieveByUidResponse studyRetrieveByUidResponse)
        : base(studyRetrieveByUidResponse) { }
#pragma warning restore CS8618

    public StudyRetrieveByUidResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyRetrieveByUidResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StudyRetrieveByUidResponseFromRaw.FromRawUnchecked"/>
    public static StudyRetrieveByUidResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StudyRetrieveByUidResponseFromRaw : IFromRawJson<StudyRetrieveByUidResponse>
{
    /// <inheritdoc/>
    public StudyRetrieveByUidResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StudyRetrieveByUidResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Priority level of the study. 'normal' for routine, 'high' for urgent, 'stat'
/// for immediate attention
/// </summary>
[JsonConverter(typeof(StudyRetrieveByUidResponseSeverityConverter))]
public enum StudyRetrieveByUidResponseSeverity
{
    Normal,
    High,
    Stat,
}

sealed class StudyRetrieveByUidResponseSeverityConverter
    : JsonConverter<StudyRetrieveByUidResponseSeverity>
{
    public override StudyRetrieveByUidResponseSeverity Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "normal" => StudyRetrieveByUidResponseSeverity.Normal,
            "high" => StudyRetrieveByUidResponseSeverity.High,
            "stat" => StudyRetrieveByUidResponseSeverity.Stat,
            _ => (StudyRetrieveByUidResponseSeverity)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StudyRetrieveByUidResponseSeverity value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StudyRetrieveByUidResponseSeverity.Normal => "normal",
                StudyRetrieveByUidResponseSeverity.High => "high",
                StudyRetrieveByUidResponseSeverity.Stat => "stat",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Report workflow status. 'unassigned' = no radiologist assigned, 'assigned' =
/// assigned but not started, 'in_progress' = actively being dictated, 'completed'
/// = report signed, 'addendum_active' = addendum in progress
/// </summary>
[JsonConverter(typeof(StudyRetrieveByUidResponseStudyReportStatusConverter))]
public enum StudyRetrieveByUidResponseStudyReportStatus
{
    Unassigned,
    Assigned,
    InProgress,
    Completed,
    AddendumActive,
}

sealed class StudyRetrieveByUidResponseStudyReportStatusConverter
    : JsonConverter<StudyRetrieveByUidResponseStudyReportStatus>
{
    public override StudyRetrieveByUidResponseStudyReportStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unassigned" => StudyRetrieveByUidResponseStudyReportStatus.Unassigned,
            "assigned" => StudyRetrieveByUidResponseStudyReportStatus.Assigned,
            "in_progress" => StudyRetrieveByUidResponseStudyReportStatus.InProgress,
            "completed" => StudyRetrieveByUidResponseStudyReportStatus.Completed,
            "addendum_active" => StudyRetrieveByUidResponseStudyReportStatus.AddendumActive,
            _ => (StudyRetrieveByUidResponseStudyReportStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StudyRetrieveByUidResponseStudyReportStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StudyRetrieveByUidResponseStudyReportStatus.Unassigned => "unassigned",
                StudyRetrieveByUidResponseStudyReportStatus.Assigned => "assigned",
                StudyRetrieveByUidResponseStudyReportStatus.InProgress => "in_progress",
                StudyRetrieveByUidResponseStudyReportStatus.Completed => "completed",
                StudyRetrieveByUidResponseStudyReportStatus.AddendumActive => "addendum_active",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Reference to the assigned radiologist, null if unassigned
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        StudyRetrieveByUidResponseAssignedTo,
        StudyRetrieveByUidResponseAssignedToFromRaw
    >)
)]
public sealed record class StudyRetrieveByUidResponseAssignedTo : JsonModel
{
    /// <summary>
    /// User's email address
    /// </summary>
    public required string Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <summary>
    /// Unique user identifier. Format: usr_{32-hex-chars}
    /// </summary>
    public required string UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("userId");
        }
        init { this._rawData.Set("userId", value); }
    }

    /// <summary>
    /// User's first name
    /// </summary>
    public string? FirstName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("firstName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("firstName", value);
        }
    }

    /// <summary>
    /// User's last name
    /// </summary>
    public string? LastName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("lastName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("lastName", value);
        }
    }

    /// <summary>
    /// User's middle name
    /// </summary>
    public string? MiddleName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("middleName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("middleName", value);
        }
    }

    /// <summary>
    /// Name suffix (e.g., 'MD', 'Jr.')
    /// </summary>
    public string? Suffix1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("suffix1");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("suffix1", value);
        }
    }

    /// <summary>
    /// Additional name suffix
    /// </summary>
    public string? Suffix2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("suffix2");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("suffix2", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Email;
        _ = this.UserID;
        _ = this.FirstName;
        _ = this.LastName;
        _ = this.MiddleName;
        _ = this.Suffix1;
        _ = this.Suffix2;
    }

    public StudyRetrieveByUidResponseAssignedTo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyRetrieveByUidResponseAssignedTo(
        StudyRetrieveByUidResponseAssignedTo studyRetrieveByUidResponseAssignedTo
    )
        : base(studyRetrieveByUidResponseAssignedTo) { }
#pragma warning restore CS8618

    public StudyRetrieveByUidResponseAssignedTo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyRetrieveByUidResponseAssignedTo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StudyRetrieveByUidResponseAssignedToFromRaw.FromRawUnchecked"/>
    public static StudyRetrieveByUidResponseAssignedTo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StudyRetrieveByUidResponseAssignedToFromRaw
    : IFromRawJson<StudyRetrieveByUidResponseAssignedTo>
{
    /// <inheritdoc/>
    public StudyRetrieveByUidResponseAssignedTo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StudyRetrieveByUidResponseAssignedTo.FromRawUnchecked(rawData);
}

/// <summary>
/// Reference to the API key used to create this study
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        StudyRetrieveByUidResponseCreatedByApiKey,
        StudyRetrieveByUidResponseCreatedByApiKeyFromRaw
    >)
)]
public sealed record class StudyRetrieveByUidResponseCreatedByApiKey : JsonModel
{
    /// <summary>
    /// Unique API key identifier (UUIDv4 format)
    /// </summary>
    public required string ApiKeyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("apiKeyId");
        }
        init { this._rawData.Set("apiKeyId", value); }
    }

    /// <summary>
    /// Human-readable description of the API key
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Whether this API key has access to the Viewer product
    /// </summary>
    public bool? IsViewerEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isViewerEnabled");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isViewerEnabled", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ApiKeyID;
        _ = this.Description;
        _ = this.IsViewerEnabled;
    }

    public StudyRetrieveByUidResponseCreatedByApiKey() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyRetrieveByUidResponseCreatedByApiKey(
        StudyRetrieveByUidResponseCreatedByApiKey studyRetrieveByUidResponseCreatedByApiKey
    )
        : base(studyRetrieveByUidResponseCreatedByApiKey) { }
#pragma warning restore CS8618

    public StudyRetrieveByUidResponseCreatedByApiKey(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyRetrieveByUidResponseCreatedByApiKey(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StudyRetrieveByUidResponseCreatedByApiKeyFromRaw.FromRawUnchecked"/>
    public static StudyRetrieveByUidResponseCreatedByApiKey FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StudyRetrieveByUidResponseCreatedByApiKeyFromRaw
    : IFromRawJson<StudyRetrieveByUidResponseCreatedByApiKey>
{
    /// <inheritdoc/>
    public StudyRetrieveByUidResponseCreatedByApiKey FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StudyRetrieveByUidResponseCreatedByApiKey.FromRawUnchecked(rawData);
}

/// <summary>
/// Reference to the user who created this study via dashboard
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        StudyRetrieveByUidResponseCreatedByUser,
        StudyRetrieveByUidResponseCreatedByUserFromRaw
    >)
)]
public sealed record class StudyRetrieveByUidResponseCreatedByUser : JsonModel
{
    /// <summary>
    /// User's email address
    /// </summary>
    public required string Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <summary>
    /// Unique user identifier. Format: usr_{32-hex-chars}
    /// </summary>
    public required string UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("userId");
        }
        init { this._rawData.Set("userId", value); }
    }

    /// <summary>
    /// User's first name
    /// </summary>
    public string? FirstName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("firstName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("firstName", value);
        }
    }

    /// <summary>
    /// User's last name
    /// </summary>
    public string? LastName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("lastName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("lastName", value);
        }
    }

    /// <summary>
    /// User's middle name
    /// </summary>
    public string? MiddleName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("middleName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("middleName", value);
        }
    }

    /// <summary>
    /// Name suffix (e.g., 'MD', 'Jr.')
    /// </summary>
    public string? Suffix1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("suffix1");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("suffix1", value);
        }
    }

    /// <summary>
    /// Additional name suffix
    /// </summary>
    public string? Suffix2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("suffix2");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("suffix2", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Email;
        _ = this.UserID;
        _ = this.FirstName;
        _ = this.LastName;
        _ = this.MiddleName;
        _ = this.Suffix1;
        _ = this.Suffix2;
    }

    public StudyRetrieveByUidResponseCreatedByUser() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyRetrieveByUidResponseCreatedByUser(
        StudyRetrieveByUidResponseCreatedByUser studyRetrieveByUidResponseCreatedByUser
    )
        : base(studyRetrieveByUidResponseCreatedByUser) { }
#pragma warning restore CS8618

    public StudyRetrieveByUidResponseCreatedByUser(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyRetrieveByUidResponseCreatedByUser(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StudyRetrieveByUidResponseCreatedByUserFromRaw.FromRawUnchecked"/>
    public static StudyRetrieveByUidResponseCreatedByUser FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StudyRetrieveByUidResponseCreatedByUserFromRaw
    : IFromRawJson<StudyRetrieveByUidResponseCreatedByUser>
{
    /// <inheritdoc/>
    public StudyRetrieveByUidResponseCreatedByUser FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StudyRetrieveByUidResponseCreatedByUser.FromRawUnchecked(rawData);
}

/// <summary>
/// Reference to the Express customer this study belongs to
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        StudyRetrieveByUidResponseExpressCustomer,
        StudyRetrieveByUidResponseExpressCustomerFromRaw
    >)
)]
public sealed record class StudyRetrieveByUidResponseExpressCustomer : JsonModel
{
    /// <summary>
    /// Unique Express customer identifier. Format: cus_{32-hex-chars}
    /// </summary>
    public required string ExpressCustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("expressCustomerId");
        }
        init { this._rawData.Set("expressCustomerId", value); }
    }

    /// <summary>
    /// Name of the Express customer
    /// </summary>
    public required string ExpressCustomerName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("expressCustomerName");
        }
        init { this._rawData.Set("expressCustomerName", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExpressCustomerID;
        _ = this.ExpressCustomerName;
    }

    public StudyRetrieveByUidResponseExpressCustomer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyRetrieveByUidResponseExpressCustomer(
        StudyRetrieveByUidResponseExpressCustomer studyRetrieveByUidResponseExpressCustomer
    )
        : base(studyRetrieveByUidResponseExpressCustomer) { }
#pragma warning restore CS8618

    public StudyRetrieveByUidResponseExpressCustomer(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyRetrieveByUidResponseExpressCustomer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StudyRetrieveByUidResponseExpressCustomerFromRaw.FromRawUnchecked"/>
    public static StudyRetrieveByUidResponseExpressCustomer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StudyRetrieveByUidResponseExpressCustomerFromRaw
    : IFromRawJson<StudyRetrieveByUidResponseExpressCustomer>
{
    /// <inheritdoc/>
    public StudyRetrieveByUidResponseExpressCustomer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StudyRetrieveByUidResponseExpressCustomer.FromRawUnchecked(rawData);
}

/// <summary>
/// External prior report metadata and text stored on a study
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        StudyRetrieveByUidResponsePriorReport,
        StudyRetrieveByUidResponsePriorReportFromRaw
    >)
)]
public sealed record class StudyRetrieveByUidResponsePriorReport : JsonModel
{
    /// <summary>
    /// Full prior report text
    /// </summary>
    public required string ReportText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reportText");
        }
        init { this._rawData.Set("reportText", value); }
    }

    /// <summary>
    /// Integrator's external study identifier
    /// </summary>
    public string? ExternalStudyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("externalStudyId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("externalStudyId", value);
        }
    }

    /// <summary>
    /// Imaging modality for the prior study
    /// </summary>
    public string? Modality
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("modality");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("modality", value);
        }
    }

    /// <summary>
    /// Prior study date (YYYY-MM-DD)
    /// </summary>
    public string? StudyDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("studyDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("studyDate", value);
        }
    }

    /// <summary>
    /// Description of the prior study
    /// </summary>
    public string? StudyDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("studyDescription");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("studyDescription", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ReportText;
        _ = this.ExternalStudyID;
        _ = this.Modality;
        _ = this.StudyDate;
        _ = this.StudyDescription;
    }

    public StudyRetrieveByUidResponsePriorReport() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyRetrieveByUidResponsePriorReport(
        StudyRetrieveByUidResponsePriorReport studyRetrieveByUidResponsePriorReport
    )
        : base(studyRetrieveByUidResponsePriorReport) { }
#pragma warning restore CS8618

    public StudyRetrieveByUidResponsePriorReport(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyRetrieveByUidResponsePriorReport(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StudyRetrieveByUidResponsePriorReportFromRaw.FromRawUnchecked"/>
    public static StudyRetrieveByUidResponsePriorReport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public StudyRetrieveByUidResponsePriorReport(string reportText)
        : this()
    {
        this.ReportText = reportText;
    }
}

class StudyRetrieveByUidResponsePriorReportFromRaw
    : IFromRawJson<StudyRetrieveByUidResponsePriorReport>
{
    /// <inheritdoc/>
    public StudyRetrieveByUidResponsePriorReport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StudyRetrieveByUidResponsePriorReport.FromRawUnchecked(rawData);
}
