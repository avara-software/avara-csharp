using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.AutoScribe.Studies;

/// <summary>
/// A study entity in the AutoScribe system with report workflow status
/// </summary>
[JsonConverter(typeof(JsonModelConverter<StudyRetrieveResponse, StudyRetrieveResponseFromRaw>))]
public sealed record class StudyRetrieveResponse : JsonModel
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
    /// Priority level of a study. 'normal' for routine, 'high' for urgent, 'stat'
    /// for immediate attention.
    /// </summary>
    public required ApiEnum<string, Severity> Severity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Severity>>("severity");
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
    /// AutoScribe report workflow status for a study. 'unassigned' = no radiologist
    /// assigned, 'assigned' = assigned but not started, 'in_progress' = actively
    /// being dictated, 'completed' = report signed, 'addendum_active' = addendum
    /// in progress.
    /// </summary>
    public required ApiEnum<string, StudyReportStatus> StudyReportStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, StudyReportStatus>>(
                "studyReportStatus"
            );
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
    public StudyRetrieveResponseAssignedTo? AssignedTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<StudyRetrieveResponseAssignedTo>("assignedTo");
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
    public StudyRetrieveResponseCreatedByApiKey? CreatedByApiKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<StudyRetrieveResponseCreatedByApiKey>(
                "createdByApiKey"
            );
        }
        init { this._rawData.Set("createdByApiKey", value); }
    }

    /// <summary>
    /// Reference to the user who created this study via dashboard
    /// </summary>
    public StudyRetrieveResponseCreatedByUser? CreatedByUser
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<StudyRetrieveResponseCreatedByUser>(
                "createdByUser"
            );
        }
        init { this._rawData.Set("createdByUser", value); }
    }

    /// <summary>
    /// Reference to the Express customer this study belongs to
    /// </summary>
    public StudyRetrieveResponseExpressCustomer? ExpressCustomer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<StudyRetrieveResponseExpressCustomer>(
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
    public IReadOnlyList<PriorReport>? PriorReports
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PriorReport>>("priorReports");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<PriorReport>?>(
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

    public StudyRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyRetrieveResponse(StudyRetrieveResponse studyRetrieveResponse)
        : base(studyRetrieveResponse) { }
#pragma warning restore CS8618

    public StudyRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StudyRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static StudyRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StudyRetrieveResponseFromRaw : IFromRawJson<StudyRetrieveResponse>
{
    /// <inheritdoc/>
    public StudyRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StudyRetrieveResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Reference to the assigned radiologist, null if unassigned
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        StudyRetrieveResponseAssignedTo,
        StudyRetrieveResponseAssignedToFromRaw
    >)
)]
public sealed record class StudyRetrieveResponseAssignedTo : JsonModel
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

    public StudyRetrieveResponseAssignedTo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyRetrieveResponseAssignedTo(
        StudyRetrieveResponseAssignedTo studyRetrieveResponseAssignedTo
    )
        : base(studyRetrieveResponseAssignedTo) { }
#pragma warning restore CS8618

    public StudyRetrieveResponseAssignedTo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyRetrieveResponseAssignedTo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StudyRetrieveResponseAssignedToFromRaw.FromRawUnchecked"/>
    public static StudyRetrieveResponseAssignedTo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StudyRetrieveResponseAssignedToFromRaw : IFromRawJson<StudyRetrieveResponseAssignedTo>
{
    /// <inheritdoc/>
    public StudyRetrieveResponseAssignedTo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StudyRetrieveResponseAssignedTo.FromRawUnchecked(rawData);
}

/// <summary>
/// Reference to the API key used to create this study
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        StudyRetrieveResponseCreatedByApiKey,
        StudyRetrieveResponseCreatedByApiKeyFromRaw
    >)
)]
public sealed record class StudyRetrieveResponseCreatedByApiKey : JsonModel
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

    public StudyRetrieveResponseCreatedByApiKey() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyRetrieveResponseCreatedByApiKey(
        StudyRetrieveResponseCreatedByApiKey studyRetrieveResponseCreatedByApiKey
    )
        : base(studyRetrieveResponseCreatedByApiKey) { }
#pragma warning restore CS8618

    public StudyRetrieveResponseCreatedByApiKey(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyRetrieveResponseCreatedByApiKey(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StudyRetrieveResponseCreatedByApiKeyFromRaw.FromRawUnchecked"/>
    public static StudyRetrieveResponseCreatedByApiKey FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StudyRetrieveResponseCreatedByApiKeyFromRaw
    : IFromRawJson<StudyRetrieveResponseCreatedByApiKey>
{
    /// <inheritdoc/>
    public StudyRetrieveResponseCreatedByApiKey FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StudyRetrieveResponseCreatedByApiKey.FromRawUnchecked(rawData);
}

/// <summary>
/// Reference to the user who created this study via dashboard
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        StudyRetrieveResponseCreatedByUser,
        StudyRetrieveResponseCreatedByUserFromRaw
    >)
)]
public sealed record class StudyRetrieveResponseCreatedByUser : JsonModel
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

    public StudyRetrieveResponseCreatedByUser() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyRetrieveResponseCreatedByUser(
        StudyRetrieveResponseCreatedByUser studyRetrieveResponseCreatedByUser
    )
        : base(studyRetrieveResponseCreatedByUser) { }
#pragma warning restore CS8618

    public StudyRetrieveResponseCreatedByUser(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyRetrieveResponseCreatedByUser(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StudyRetrieveResponseCreatedByUserFromRaw.FromRawUnchecked"/>
    public static StudyRetrieveResponseCreatedByUser FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StudyRetrieveResponseCreatedByUserFromRaw : IFromRawJson<StudyRetrieveResponseCreatedByUser>
{
    /// <inheritdoc/>
    public StudyRetrieveResponseCreatedByUser FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StudyRetrieveResponseCreatedByUser.FromRawUnchecked(rawData);
}

/// <summary>
/// Reference to the Express customer this study belongs to
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        StudyRetrieveResponseExpressCustomer,
        StudyRetrieveResponseExpressCustomerFromRaw
    >)
)]
public sealed record class StudyRetrieveResponseExpressCustomer : JsonModel
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

    public StudyRetrieveResponseExpressCustomer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyRetrieveResponseExpressCustomer(
        StudyRetrieveResponseExpressCustomer studyRetrieveResponseExpressCustomer
    )
        : base(studyRetrieveResponseExpressCustomer) { }
#pragma warning restore CS8618

    public StudyRetrieveResponseExpressCustomer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyRetrieveResponseExpressCustomer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StudyRetrieveResponseExpressCustomerFromRaw.FromRawUnchecked"/>
    public static StudyRetrieveResponseExpressCustomer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StudyRetrieveResponseExpressCustomerFromRaw
    : IFromRawJson<StudyRetrieveResponseExpressCustomer>
{
    /// <inheritdoc/>
    public StudyRetrieveResponseExpressCustomer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StudyRetrieveResponseExpressCustomer.FromRawUnchecked(rawData);
}
