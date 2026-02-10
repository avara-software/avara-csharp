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
    /// Report workflow status
    /// </summary>
    public required ApiEnum<string, StudyListResponseStudyReportStatus> StudyReportStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, StudyListResponseStudyReportStatus>
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
    public StudyListResponseAssignedTo? AssignedTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<StudyListResponseAssignedTo>("assignedTo");
        }
        init { this._rawData.Set("assignedTo", value); }
    }

    /// <summary>
    /// Reference to the API key used to create this study
    /// </summary>
    public StudyListResponseCreatedByApiKey? CreatedByApiKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<StudyListResponseCreatedByApiKey>(
                "createdByApiKey"
            );
        }
        init { this._rawData.Set("createdByApiKey", value); }
    }

    /// <summary>
    /// Reference to the user who created this study via dashboard
    /// </summary>
    public StudyListResponseCreatedByUser? CreatedByUser
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<StudyListResponseCreatedByUser>("createdByUser");
        }
        init { this._rawData.Set("createdByUser", value); }
    }

    /// <summary>
    /// Reference to the Express customer this study belongs to
    /// </summary>
    public StudyListResponseExpressCustomer? ExpressCustomer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<StudyListResponseExpressCustomer>(
                "expressCustomer"
            );
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

    /// <summary>
    /// Array of prior report texts to provide clinical context
    /// </summary>
    public IReadOnlyList<string>? PriorReportTexts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("priorReportTexts");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "priorReportTexts",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Array of prior study IDs for comparison context (format: stu_{32-hex-chars})
    /// </summary>
    public IReadOnlyList<string>? PriorStudyIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("priorStudyIds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "priorStudyIds",
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
        this.CreatedByApiKey?.Validate();
        this.CreatedByUser?.Validate();
        this.ExpressCustomer?.Validate();
        _ = this.Metadata;
        _ = this.PriorReportTexts;
        _ = this.PriorStudyIds;
        foreach (var item in this.ReportIds ?? [])
        {
            item.Validate();
        }
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
/// Report workflow status
/// </summary>
[JsonConverter(typeof(StudyListResponseStudyReportStatusConverter))]
public enum StudyListResponseStudyReportStatus
{
    Unassigned,
    Assigned,
    InProgress,
    Completed,
    AddendumActive,
}

sealed class StudyListResponseStudyReportStatusConverter
    : JsonConverter<StudyListResponseStudyReportStatus>
{
    public override StudyListResponseStudyReportStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unassigned" => StudyListResponseStudyReportStatus.Unassigned,
            "assigned" => StudyListResponseStudyReportStatus.Assigned,
            "in_progress" => StudyListResponseStudyReportStatus.InProgress,
            "completed" => StudyListResponseStudyReportStatus.Completed,
            "addendum_active" => StudyListResponseStudyReportStatus.AddendumActive,
            _ => (StudyListResponseStudyReportStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StudyListResponseStudyReportStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StudyListResponseStudyReportStatus.Unassigned => "unassigned",
                StudyListResponseStudyReportStatus.Assigned => "assigned",
                StudyListResponseStudyReportStatus.InProgress => "in_progress",
                StudyListResponseStudyReportStatus.Completed => "completed",
                StudyListResponseStudyReportStatus.AddendumActive => "addendum_active",
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
    typeof(JsonModelConverter<StudyListResponseAssignedTo, StudyListResponseAssignedToFromRaw>)
)]
public sealed record class StudyListResponseAssignedTo : JsonModel
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

    public StudyListResponseAssignedTo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyListResponseAssignedTo(StudyListResponseAssignedTo studyListResponseAssignedTo)
        : base(studyListResponseAssignedTo) { }
#pragma warning restore CS8618

    public StudyListResponseAssignedTo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyListResponseAssignedTo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StudyListResponseAssignedToFromRaw.FromRawUnchecked"/>
    public static StudyListResponseAssignedTo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StudyListResponseAssignedToFromRaw : IFromRawJson<StudyListResponseAssignedTo>
{
    /// <inheritdoc/>
    public StudyListResponseAssignedTo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StudyListResponseAssignedTo.FromRawUnchecked(rawData);
}

/// <summary>
/// Reference to the API key used to create this study
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        StudyListResponseCreatedByApiKey,
        StudyListResponseCreatedByApiKeyFromRaw
    >)
)]
public sealed record class StudyListResponseCreatedByApiKey : JsonModel
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

    public StudyListResponseCreatedByApiKey() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyListResponseCreatedByApiKey(
        StudyListResponseCreatedByApiKey studyListResponseCreatedByApiKey
    )
        : base(studyListResponseCreatedByApiKey) { }
#pragma warning restore CS8618

    public StudyListResponseCreatedByApiKey(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyListResponseCreatedByApiKey(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StudyListResponseCreatedByApiKeyFromRaw.FromRawUnchecked"/>
    public static StudyListResponseCreatedByApiKey FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StudyListResponseCreatedByApiKeyFromRaw : IFromRawJson<StudyListResponseCreatedByApiKey>
{
    /// <inheritdoc/>
    public StudyListResponseCreatedByApiKey FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StudyListResponseCreatedByApiKey.FromRawUnchecked(rawData);
}

/// <summary>
/// Reference to the user who created this study via dashboard
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        StudyListResponseCreatedByUser,
        StudyListResponseCreatedByUserFromRaw
    >)
)]
public sealed record class StudyListResponseCreatedByUser : JsonModel
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

    public StudyListResponseCreatedByUser() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyListResponseCreatedByUser(
        StudyListResponseCreatedByUser studyListResponseCreatedByUser
    )
        : base(studyListResponseCreatedByUser) { }
#pragma warning restore CS8618

    public StudyListResponseCreatedByUser(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyListResponseCreatedByUser(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StudyListResponseCreatedByUserFromRaw.FromRawUnchecked"/>
    public static StudyListResponseCreatedByUser FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StudyListResponseCreatedByUserFromRaw : IFromRawJson<StudyListResponseCreatedByUser>
{
    /// <inheritdoc/>
    public StudyListResponseCreatedByUser FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StudyListResponseCreatedByUser.FromRawUnchecked(rawData);
}

/// <summary>
/// Reference to the Express customer this study belongs to
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        StudyListResponseExpressCustomer,
        StudyListResponseExpressCustomerFromRaw
    >)
)]
public sealed record class StudyListResponseExpressCustomer : JsonModel
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

    public StudyListResponseExpressCustomer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyListResponseExpressCustomer(
        StudyListResponseExpressCustomer studyListResponseExpressCustomer
    )
        : base(studyListResponseExpressCustomer) { }
#pragma warning restore CS8618

    public StudyListResponseExpressCustomer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyListResponseExpressCustomer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StudyListResponseExpressCustomerFromRaw.FromRawUnchecked"/>
    public static StudyListResponseExpressCustomer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StudyListResponseExpressCustomerFromRaw : IFromRawJson<StudyListResponseExpressCustomer>
{
    /// <inheritdoc/>
    public StudyListResponseExpressCustomer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StudyListResponseExpressCustomer.FromRawUnchecked(rawData);
}
