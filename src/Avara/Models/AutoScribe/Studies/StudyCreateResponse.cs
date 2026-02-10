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
[JsonConverter(typeof(JsonModelConverter<StudyCreateResponse, StudyCreateResponseFromRaw>))]
public sealed record class StudyCreateResponse : JsonModel
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
    public required ApiEnum<string, StudyCreateResponseSeverity> Severity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, StudyCreateResponseSeverity>>(
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
    public required ApiEnum<string, StudyCreateResponseStudyReportStatus> StudyReportStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, StudyCreateResponseStudyReportStatus>
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
    public AssignedTo? AssignedTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AssignedTo>("assignedTo");
        }
        init { this._rawData.Set("assignedTo", value); }
    }

    /// <summary>
    /// Reference to the API key used to create this study
    /// </summary>
    public CreatedByApiKey? CreatedByApiKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CreatedByApiKey>("createdByApiKey");
        }
        init { this._rawData.Set("createdByApiKey", value); }
    }

    /// <summary>
    /// Reference to the user who created this study via dashboard
    /// </summary>
    public CreatedByUser? CreatedByUser
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CreatedByUser>("createdByUser");
        }
        init { this._rawData.Set("createdByUser", value); }
    }

    /// <summary>
    /// Reference to the Express customer this study belongs to
    /// </summary>
    public ExpressCustomer? ExpressCustomer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExpressCustomer>("expressCustomer");
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

    public StudyCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyCreateResponse(StudyCreateResponse studyCreateResponse)
        : base(studyCreateResponse) { }
#pragma warning restore CS8618

    public StudyCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StudyCreateResponseFromRaw.FromRawUnchecked"/>
    public static StudyCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StudyCreateResponseFromRaw : IFromRawJson<StudyCreateResponse>
{
    /// <inheritdoc/>
    public StudyCreateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        StudyCreateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Priority level of the study. 'normal' for routine, 'high' for urgent, 'stat'
/// for immediate attention
/// </summary>
[JsonConverter(typeof(StudyCreateResponseSeverityConverter))]
public enum StudyCreateResponseSeverity
{
    Normal,
    High,
    Stat,
}

sealed class StudyCreateResponseSeverityConverter : JsonConverter<StudyCreateResponseSeverity>
{
    public override StudyCreateResponseSeverity Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "normal" => StudyCreateResponseSeverity.Normal,
            "high" => StudyCreateResponseSeverity.High,
            "stat" => StudyCreateResponseSeverity.Stat,
            _ => (StudyCreateResponseSeverity)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StudyCreateResponseSeverity value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StudyCreateResponseSeverity.Normal => "normal",
                StudyCreateResponseSeverity.High => "high",
                StudyCreateResponseSeverity.Stat => "stat",
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
[JsonConverter(typeof(StudyCreateResponseStudyReportStatusConverter))]
public enum StudyCreateResponseStudyReportStatus
{
    Unassigned,
    Assigned,
    InProgress,
    Completed,
    AddendumActive,
}

sealed class StudyCreateResponseStudyReportStatusConverter
    : JsonConverter<StudyCreateResponseStudyReportStatus>
{
    public override StudyCreateResponseStudyReportStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unassigned" => StudyCreateResponseStudyReportStatus.Unassigned,
            "assigned" => StudyCreateResponseStudyReportStatus.Assigned,
            "in_progress" => StudyCreateResponseStudyReportStatus.InProgress,
            "completed" => StudyCreateResponseStudyReportStatus.Completed,
            "addendum_active" => StudyCreateResponseStudyReportStatus.AddendumActive,
            _ => (StudyCreateResponseStudyReportStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StudyCreateResponseStudyReportStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StudyCreateResponseStudyReportStatus.Unassigned => "unassigned",
                StudyCreateResponseStudyReportStatus.Assigned => "assigned",
                StudyCreateResponseStudyReportStatus.InProgress => "in_progress",
                StudyCreateResponseStudyReportStatus.Completed => "completed",
                StudyCreateResponseStudyReportStatus.AddendumActive => "addendum_active",
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
[JsonConverter(typeof(JsonModelConverter<AssignedTo, AssignedToFromRaw>))]
public sealed record class AssignedTo : JsonModel
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

    public AssignedTo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AssignedTo(AssignedTo assignedTo)
        : base(assignedTo) { }
#pragma warning restore CS8618

    public AssignedTo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AssignedTo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AssignedToFromRaw.FromRawUnchecked"/>
    public static AssignedTo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AssignedToFromRaw : IFromRawJson<AssignedTo>
{
    /// <inheritdoc/>
    public AssignedTo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AssignedTo.FromRawUnchecked(rawData);
}

/// <summary>
/// Reference to the API key used to create this study
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CreatedByApiKey, CreatedByApiKeyFromRaw>))]
public sealed record class CreatedByApiKey : JsonModel
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

    public CreatedByApiKey() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreatedByApiKey(CreatedByApiKey createdByApiKey)
        : base(createdByApiKey) { }
#pragma warning restore CS8618

    public CreatedByApiKey(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreatedByApiKey(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreatedByApiKeyFromRaw.FromRawUnchecked"/>
    public static CreatedByApiKey FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreatedByApiKeyFromRaw : IFromRawJson<CreatedByApiKey>
{
    /// <inheritdoc/>
    public CreatedByApiKey FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CreatedByApiKey.FromRawUnchecked(rawData);
}

/// <summary>
/// Reference to the user who created this study via dashboard
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CreatedByUser, CreatedByUserFromRaw>))]
public sealed record class CreatedByUser : JsonModel
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

    public CreatedByUser() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreatedByUser(CreatedByUser createdByUser)
        : base(createdByUser) { }
#pragma warning restore CS8618

    public CreatedByUser(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreatedByUser(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreatedByUserFromRaw.FromRawUnchecked"/>
    public static CreatedByUser FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreatedByUserFromRaw : IFromRawJson<CreatedByUser>
{
    /// <inheritdoc/>
    public CreatedByUser FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CreatedByUser.FromRawUnchecked(rawData);
}

/// <summary>
/// Reference to the Express customer this study belongs to
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ExpressCustomer, ExpressCustomerFromRaw>))]
public sealed record class ExpressCustomer : JsonModel
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

    public ExpressCustomer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExpressCustomer(ExpressCustomer expressCustomer)
        : base(expressCustomer) { }
#pragma warning restore CS8618

    public ExpressCustomer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExpressCustomer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExpressCustomerFromRaw.FromRawUnchecked"/>
    public static ExpressCustomer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExpressCustomerFromRaw : IFromRawJson<ExpressCustomer>
{
    /// <inheritdoc/>
    public ExpressCustomer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExpressCustomer.FromRawUnchecked(rawData);
}
