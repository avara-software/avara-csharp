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
