using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;
using Avara.Exceptions;

namespace Avara.Models.Viewer.Users.Invitations;

/// <summary>
/// A pending user invitation in the Viewer system
/// </summary>
[JsonConverter(typeof(JsonModelConverter<InvitationListResponse, InvitationListResponseFromRaw>))]
public sealed record class InvitationListResponse : JsonModel
{
    /// <summary>
    /// Whether the invited user will have permission to manage studies
    /// </summary>
    public required bool CanManageStudies
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("canManageStudies");
        }
        init { this._rawData.Set("canManageStudies", value); }
    }

    /// <summary>
    /// UUID of the clinic this invitation belongs to
    /// </summary>
    public required string ClinicID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("clinicId");
        }
        init { this._rawData.Set("clinicId", value); }
    }

    /// <summary>
    /// User's clinical or organizational role
    /// </summary>
    public required ApiEnum<string, InvitationListResponseClinicRole> ClinicRole
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InvitationListResponseClinicRole>>(
                "clinicRole"
            );
        }
        init { this._rawData.Set("clinicRole", value); }
    }

    /// <summary>
    /// Timestamp when the invitation was created
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
    /// Email address the invitation was sent to
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
    /// When the invitation expires, null if no expiration
    /// </summary>
    public required DateTimeOffset? Expiry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("expiry");
        }
        init { this._rawData.Set("expiry", value); }
    }

    /// <summary>
    /// Invited user's first name
    /// </summary>
    public required string FirstName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("firstName");
        }
        init { this._rawData.Set("firstName", value); }
    }

    /// <summary>
    /// Whether the invited user will have dashboard access
    /// </summary>
    public required bool HasDashboardAccess
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("hasDashboardAccess");
        }
        init { this._rawData.Set("hasDashboardAccess", value); }
    }

    /// <summary>
    /// Unique invitation identifier. Format: inv_{32-hex-chars}
    /// </summary>
    public required string InvitationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("invitationId");
        }
        init { this._rawData.Set("invitationId", value); }
    }

    /// <summary>
    /// How the user was invited - via dashboard UI or API
    /// </summary>
    public required ApiEnum<string, InvitationListResponseInvitedSource> InvitedSource
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, InvitationListResponseInvitedSource>
            >("invitedSource");
        }
        init { this._rawData.Set("invitedSource", value); }
    }

    /// <summary>
    /// User ID of the person who sent the invitation. Format: usr_{32-hex-chars}.
    /// Null if invited via API
    /// </summary>
    public required string InviterID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("inviterId");
        }
        init { this._rawData.Set("inviterId", value); }
    }

    /// <summary>
    /// Invited user's last name
    /// </summary>
    public required string LastName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("lastName");
        }
        init { this._rawData.Set("lastName", value); }
    }

    /// <summary>
    /// User access level
    /// </summary>
    public required ApiEnum<string, InvitationListResponseLevel> Level
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InvitationListResponseLevel>>(
                "level"
            );
        }
        init { this._rawData.Set("level", value); }
    }

    /// <summary>
    /// Invitation status
    /// </summary>
    public required ApiEnum<string, InvitationListResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InvitationListResponseStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Timestamp when the invitation was last updated
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
    /// Pre-generated user ID for this invitation. Format: usr_{32-hex-chars}. This
    /// ID is assigned at invitation creation and will become the user's permanent
    /// ID upon acceptance
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
    /// UUID of the API key used to send this invitation. Null if sent via dashboard
    /// </summary>
    public string? InvitedByApiKeyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invitedByApiKeyId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("invitedByApiKeyId", value);
        }
    }

    /// <summary>
    /// Invited user's middle name (optional)
    /// </summary>
    public string? MiddleName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("middleName");
        }
        init { this._rawData.Set("middleName", value); }
    }

    /// <summary>
    /// Invited user's phone number (optional)
    /// </summary>
    public string? PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phoneNumber");
        }
        init { this._rawData.Set("phoneNumber", value); }
    }

    /// <summary>
    /// Name suffix (e.g., 'Jr.', 'MD') - optional
    /// </summary>
    public string? Suffix1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("suffix1");
        }
        init { this._rawData.Set("suffix1", value); }
    }

    /// <summary>
    /// Additional name suffix - optional
    /// </summary>
    public string? Suffix2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("suffix2");
        }
        init { this._rawData.Set("suffix2", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CanManageStudies;
        _ = this.ClinicID;
        this.ClinicRole.Validate();
        _ = this.CreatedAt;
        _ = this.Email;
        _ = this.Expiry;
        _ = this.FirstName;
        _ = this.HasDashboardAccess;
        _ = this.InvitationID;
        this.InvitedSource.Validate();
        _ = this.InviterID;
        _ = this.LastName;
        this.Level.Validate();
        this.Status.Validate();
        _ = this.UpdatedAt;
        _ = this.UserID;
        _ = this.InvitedByApiKeyID;
        _ = this.MiddleName;
        _ = this.PhoneNumber;
        _ = this.Suffix1;
        _ = this.Suffix2;
    }

    public InvitationListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvitationListResponse(InvitationListResponse invitationListResponse)
        : base(invitationListResponse) { }
#pragma warning restore CS8618

    public InvitationListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvitationListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvitationListResponseFromRaw.FromRawUnchecked"/>
    public static InvitationListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvitationListResponseFromRaw : IFromRawJson<InvitationListResponse>
{
    /// <inheritdoc/>
    public InvitationListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvitationListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// User's clinical or organizational role
/// </summary>
[JsonConverter(typeof(InvitationListResponseClinicRoleConverter))]
public enum InvitationListResponseClinicRole
{
    Radiologist,
    Cardiologist,
    Neurologist,
    Urologist,
    Gynecologist,
    Endocrinologist,
    Doctor,
    Surgeon,
    Physician,
    PhysicianAssistant,
    NursePractitioner,
    RegisteredNurse,
    PatientCareCoordinator,
    FrontDeskOperator,
    ImagingTechnologist,
    PacsAdministrator,
    SoftwareEngineer,
    RevenueCycleManager,
    AdministrativeDirector,
    AdministrativeAssistant,
    Other,
}

sealed class InvitationListResponseClinicRoleConverter
    : JsonConverter<InvitationListResponseClinicRole>
{
    public override InvitationListResponseClinicRole Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Radiologist" => InvitationListResponseClinicRole.Radiologist,
            "Cardiologist" => InvitationListResponseClinicRole.Cardiologist,
            "Neurologist" => InvitationListResponseClinicRole.Neurologist,
            "Urologist" => InvitationListResponseClinicRole.Urologist,
            "Gynecologist" => InvitationListResponseClinicRole.Gynecologist,
            "Endocrinologist" => InvitationListResponseClinicRole.Endocrinologist,
            "Doctor" => InvitationListResponseClinicRole.Doctor,
            "Surgeon" => InvitationListResponseClinicRole.Surgeon,
            "Physician" => InvitationListResponseClinicRole.Physician,
            "Physician Assistant" => InvitationListResponseClinicRole.PhysicianAssistant,
            "Nurse Practitioner" => InvitationListResponseClinicRole.NursePractitioner,
            "Registered Nurse" => InvitationListResponseClinicRole.RegisteredNurse,
            "Patient Care Coordinator" => InvitationListResponseClinicRole.PatientCareCoordinator,
            "Front Desk Operator" => InvitationListResponseClinicRole.FrontDeskOperator,
            "Imaging Technologist" => InvitationListResponseClinicRole.ImagingTechnologist,
            "PACS Administrator" => InvitationListResponseClinicRole.PacsAdministrator,
            "Software Engineer" => InvitationListResponseClinicRole.SoftwareEngineer,
            "Revenue Cycle Manager" => InvitationListResponseClinicRole.RevenueCycleManager,
            "Administrative Director" => InvitationListResponseClinicRole.AdministrativeDirector,
            "Administrative Assistant" => InvitationListResponseClinicRole.AdministrativeAssistant,
            "Other" => InvitationListResponseClinicRole.Other,
            _ => (InvitationListResponseClinicRole)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvitationListResponseClinicRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvitationListResponseClinicRole.Radiologist => "Radiologist",
                InvitationListResponseClinicRole.Cardiologist => "Cardiologist",
                InvitationListResponseClinicRole.Neurologist => "Neurologist",
                InvitationListResponseClinicRole.Urologist => "Urologist",
                InvitationListResponseClinicRole.Gynecologist => "Gynecologist",
                InvitationListResponseClinicRole.Endocrinologist => "Endocrinologist",
                InvitationListResponseClinicRole.Doctor => "Doctor",
                InvitationListResponseClinicRole.Surgeon => "Surgeon",
                InvitationListResponseClinicRole.Physician => "Physician",
                InvitationListResponseClinicRole.PhysicianAssistant => "Physician Assistant",
                InvitationListResponseClinicRole.NursePractitioner => "Nurse Practitioner",
                InvitationListResponseClinicRole.RegisteredNurse => "Registered Nurse",
                InvitationListResponseClinicRole.PatientCareCoordinator =>
                    "Patient Care Coordinator",
                InvitationListResponseClinicRole.FrontDeskOperator => "Front Desk Operator",
                InvitationListResponseClinicRole.ImagingTechnologist => "Imaging Technologist",
                InvitationListResponseClinicRole.PacsAdministrator => "PACS Administrator",
                InvitationListResponseClinicRole.SoftwareEngineer => "Software Engineer",
                InvitationListResponseClinicRole.RevenueCycleManager => "Revenue Cycle Manager",
                InvitationListResponseClinicRole.AdministrativeDirector =>
                    "Administrative Director",
                InvitationListResponseClinicRole.AdministrativeAssistant =>
                    "Administrative Assistant",
                InvitationListResponseClinicRole.Other => "Other",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// How the user was invited - via dashboard UI or API
/// </summary>
[JsonConverter(typeof(InvitationListResponseInvitedSourceConverter))]
public enum InvitationListResponseInvitedSource
{
    Dashboard,
    Api,
}

sealed class InvitationListResponseInvitedSourceConverter
    : JsonConverter<InvitationListResponseInvitedSource>
{
    public override InvitationListResponseInvitedSource Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dashboard" => InvitationListResponseInvitedSource.Dashboard,
            "api" => InvitationListResponseInvitedSource.Api,
            _ => (InvitationListResponseInvitedSource)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvitationListResponseInvitedSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvitationListResponseInvitedSource.Dashboard => "dashboard",
                InvitationListResponseInvitedSource.Api => "api",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// User access level
/// </summary>
[JsonConverter(typeof(InvitationListResponseLevelConverter))]
public enum InvitationListResponseLevel
{
    Owner,
    Admin,
    Member,
}

sealed class InvitationListResponseLevelConverter : JsonConverter<InvitationListResponseLevel>
{
    public override InvitationListResponseLevel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "owner" => InvitationListResponseLevel.Owner,
            "admin" => InvitationListResponseLevel.Admin,
            "member" => InvitationListResponseLevel.Member,
            _ => (InvitationListResponseLevel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvitationListResponseLevel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvitationListResponseLevel.Owner => "owner",
                InvitationListResponseLevel.Admin => "admin",
                InvitationListResponseLevel.Member => "member",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Invitation status
/// </summary>
[JsonConverter(typeof(InvitationListResponseStatusConverter))]
public enum InvitationListResponseStatus
{
    Sent,
    Accepted,
    Rejected,
    Revoked,
}

sealed class InvitationListResponseStatusConverter : JsonConverter<InvitationListResponseStatus>
{
    public override InvitationListResponseStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sent" => InvitationListResponseStatus.Sent,
            "accepted" => InvitationListResponseStatus.Accepted,
            "rejected" => InvitationListResponseStatus.Rejected,
            "revoked" => InvitationListResponseStatus.Revoked,
            _ => (InvitationListResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvitationListResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvitationListResponseStatus.Sent => "sent",
                InvitationListResponseStatus.Accepted => "accepted",
                InvitationListResponseStatus.Rejected => "rejected",
                InvitationListResponseStatus.Revoked => "revoked",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
