using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;
using Avara.Exceptions;

namespace Avara.Models.AutoScribe.Users.Invitations;

/// <summary>
/// A pending user invitation in the AutoScribe system
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<InvitationUpdateResponse, InvitationUpdateResponseFromRaw>)
)]
public sealed record class InvitationUpdateResponse : JsonModel
{
    /// <summary>
    /// Whether the invited user can generate and sign radiology reports. Requires
    /// NPI number
    /// </summary>
    public required bool CanCreateReports
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("canCreateReports");
        }
        init { this._rawData.Set("canCreateReports", value); }
    }

    /// <summary>
    /// Whether the invited user will have permission to create, update, and manage studies
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
    public required ApiEnum<string, InvitationUpdateResponseClinicRole> ClinicRole
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, InvitationUpdateResponseClinicRole>
            >("clinicRole");
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
    public required ApiEnum<string, InvitationUpdateResponseInvitedSource> InvitedSource
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, InvitationUpdateResponseInvitedSource>
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
    public required ApiEnum<string, InvitationUpdateResponseLevel> Level
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InvitationUpdateResponseLevel>>(
                "level"
            );
        }
        init { this._rawData.Set("level", value); }
    }

    /// <summary>
    /// Invitation status
    /// </summary>
    public required ApiEnum<string, InvitationUpdateResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InvitationUpdateResponseStatus>>(
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
    /// National Provider Identifier - required for users who can create reports (10-digit number)
    /// </summary>
    public string? NpiNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("npiNumber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("npiNumber", value);
        }
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
        _ = this.CanCreateReports;
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
        _ = this.NpiNumber;
        _ = this.PhoneNumber;
        _ = this.Suffix1;
        _ = this.Suffix2;
    }

    public InvitationUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvitationUpdateResponse(InvitationUpdateResponse invitationUpdateResponse)
        : base(invitationUpdateResponse) { }
#pragma warning restore CS8618

    public InvitationUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvitationUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvitationUpdateResponseFromRaw.FromRawUnchecked"/>
    public static InvitationUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvitationUpdateResponseFromRaw : IFromRawJson<InvitationUpdateResponse>
{
    /// <inheritdoc/>
    public InvitationUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvitationUpdateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// User's clinical or organizational role
/// </summary>
[JsonConverter(typeof(InvitationUpdateResponseClinicRoleConverter))]
public enum InvitationUpdateResponseClinicRole
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

sealed class InvitationUpdateResponseClinicRoleConverter
    : JsonConverter<InvitationUpdateResponseClinicRole>
{
    public override InvitationUpdateResponseClinicRole Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Radiologist" => InvitationUpdateResponseClinicRole.Radiologist,
            "Cardiologist" => InvitationUpdateResponseClinicRole.Cardiologist,
            "Neurologist" => InvitationUpdateResponseClinicRole.Neurologist,
            "Urologist" => InvitationUpdateResponseClinicRole.Urologist,
            "Gynecologist" => InvitationUpdateResponseClinicRole.Gynecologist,
            "Endocrinologist" => InvitationUpdateResponseClinicRole.Endocrinologist,
            "Doctor" => InvitationUpdateResponseClinicRole.Doctor,
            "Surgeon" => InvitationUpdateResponseClinicRole.Surgeon,
            "Physician" => InvitationUpdateResponseClinicRole.Physician,
            "Physician Assistant" => InvitationUpdateResponseClinicRole.PhysicianAssistant,
            "Nurse Practitioner" => InvitationUpdateResponseClinicRole.NursePractitioner,
            "Registered Nurse" => InvitationUpdateResponseClinicRole.RegisteredNurse,
            "Patient Care Coordinator" => InvitationUpdateResponseClinicRole.PatientCareCoordinator,
            "Front Desk Operator" => InvitationUpdateResponseClinicRole.FrontDeskOperator,
            "Imaging Technologist" => InvitationUpdateResponseClinicRole.ImagingTechnologist,
            "PACS Administrator" => InvitationUpdateResponseClinicRole.PacsAdministrator,
            "Software Engineer" => InvitationUpdateResponseClinicRole.SoftwareEngineer,
            "Revenue Cycle Manager" => InvitationUpdateResponseClinicRole.RevenueCycleManager,
            "Administrative Director" => InvitationUpdateResponseClinicRole.AdministrativeDirector,
            "Administrative Assistant" =>
                InvitationUpdateResponseClinicRole.AdministrativeAssistant,
            "Other" => InvitationUpdateResponseClinicRole.Other,
            _ => (InvitationUpdateResponseClinicRole)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvitationUpdateResponseClinicRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvitationUpdateResponseClinicRole.Radiologist => "Radiologist",
                InvitationUpdateResponseClinicRole.Cardiologist => "Cardiologist",
                InvitationUpdateResponseClinicRole.Neurologist => "Neurologist",
                InvitationUpdateResponseClinicRole.Urologist => "Urologist",
                InvitationUpdateResponseClinicRole.Gynecologist => "Gynecologist",
                InvitationUpdateResponseClinicRole.Endocrinologist => "Endocrinologist",
                InvitationUpdateResponseClinicRole.Doctor => "Doctor",
                InvitationUpdateResponseClinicRole.Surgeon => "Surgeon",
                InvitationUpdateResponseClinicRole.Physician => "Physician",
                InvitationUpdateResponseClinicRole.PhysicianAssistant => "Physician Assistant",
                InvitationUpdateResponseClinicRole.NursePractitioner => "Nurse Practitioner",
                InvitationUpdateResponseClinicRole.RegisteredNurse => "Registered Nurse",
                InvitationUpdateResponseClinicRole.PatientCareCoordinator =>
                    "Patient Care Coordinator",
                InvitationUpdateResponseClinicRole.FrontDeskOperator => "Front Desk Operator",
                InvitationUpdateResponseClinicRole.ImagingTechnologist => "Imaging Technologist",
                InvitationUpdateResponseClinicRole.PacsAdministrator => "PACS Administrator",
                InvitationUpdateResponseClinicRole.SoftwareEngineer => "Software Engineer",
                InvitationUpdateResponseClinicRole.RevenueCycleManager => "Revenue Cycle Manager",
                InvitationUpdateResponseClinicRole.AdministrativeDirector =>
                    "Administrative Director",
                InvitationUpdateResponseClinicRole.AdministrativeAssistant =>
                    "Administrative Assistant",
                InvitationUpdateResponseClinicRole.Other => "Other",
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
[JsonConverter(typeof(InvitationUpdateResponseInvitedSourceConverter))]
public enum InvitationUpdateResponseInvitedSource
{
    Dashboard,
    Api,
}

sealed class InvitationUpdateResponseInvitedSourceConverter
    : JsonConverter<InvitationUpdateResponseInvitedSource>
{
    public override InvitationUpdateResponseInvitedSource Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dashboard" => InvitationUpdateResponseInvitedSource.Dashboard,
            "api" => InvitationUpdateResponseInvitedSource.Api,
            _ => (InvitationUpdateResponseInvitedSource)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvitationUpdateResponseInvitedSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvitationUpdateResponseInvitedSource.Dashboard => "dashboard",
                InvitationUpdateResponseInvitedSource.Api => "api",
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
[JsonConverter(typeof(InvitationUpdateResponseLevelConverter))]
public enum InvitationUpdateResponseLevel
{
    Owner,
    Admin,
    Member,
}

sealed class InvitationUpdateResponseLevelConverter : JsonConverter<InvitationUpdateResponseLevel>
{
    public override InvitationUpdateResponseLevel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "owner" => InvitationUpdateResponseLevel.Owner,
            "admin" => InvitationUpdateResponseLevel.Admin,
            "member" => InvitationUpdateResponseLevel.Member,
            _ => (InvitationUpdateResponseLevel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvitationUpdateResponseLevel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvitationUpdateResponseLevel.Owner => "owner",
                InvitationUpdateResponseLevel.Admin => "admin",
                InvitationUpdateResponseLevel.Member => "member",
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
[JsonConverter(typeof(InvitationUpdateResponseStatusConverter))]
public enum InvitationUpdateResponseStatus
{
    Sent,
    Accepted,
    Rejected,
    Revoked,
}

sealed class InvitationUpdateResponseStatusConverter : JsonConverter<InvitationUpdateResponseStatus>
{
    public override InvitationUpdateResponseStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sent" => InvitationUpdateResponseStatus.Sent,
            "accepted" => InvitationUpdateResponseStatus.Accepted,
            "rejected" => InvitationUpdateResponseStatus.Rejected,
            "revoked" => InvitationUpdateResponseStatus.Revoked,
            _ => (InvitationUpdateResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvitationUpdateResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvitationUpdateResponseStatus.Sent => "sent",
                InvitationUpdateResponseStatus.Accepted => "accepted",
                InvitationUpdateResponseStatus.Rejected => "rejected",
                InvitationUpdateResponseStatus.Revoked => "revoked",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
