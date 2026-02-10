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
[JsonConverter(
    typeof(JsonModelConverter<InvitationRetrieveResponse, InvitationRetrieveResponseFromRaw>)
)]
public sealed record class InvitationRetrieveResponse : JsonModel
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
    public required ApiEnum<string, InvitationRetrieveResponseClinicRole> ClinicRole
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, InvitationRetrieveResponseClinicRole>
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
    public required ApiEnum<string, InvitedSource> InvitedSource
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InvitedSource>>("invitedSource");
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
    public required ApiEnum<string, InvitationRetrieveResponseLevel> Level
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InvitationRetrieveResponseLevel>>(
                "level"
            );
        }
        init { this._rawData.Set("level", value); }
    }

    /// <summary>
    /// Invitation status
    /// </summary>
    public required ApiEnum<string, InvitationRetrieveResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InvitationRetrieveResponseStatus>>(
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

    public InvitationRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvitationRetrieveResponse(InvitationRetrieveResponse invitationRetrieveResponse)
        : base(invitationRetrieveResponse) { }
#pragma warning restore CS8618

    public InvitationRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvitationRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvitationRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static InvitationRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvitationRetrieveResponseFromRaw : IFromRawJson<InvitationRetrieveResponse>
{
    /// <inheritdoc/>
    public InvitationRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvitationRetrieveResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// User's clinical or organizational role
/// </summary>
[JsonConverter(typeof(InvitationRetrieveResponseClinicRoleConverter))]
public enum InvitationRetrieveResponseClinicRole
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

sealed class InvitationRetrieveResponseClinicRoleConverter
    : JsonConverter<InvitationRetrieveResponseClinicRole>
{
    public override InvitationRetrieveResponseClinicRole Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Radiologist" => InvitationRetrieveResponseClinicRole.Radiologist,
            "Cardiologist" => InvitationRetrieveResponseClinicRole.Cardiologist,
            "Neurologist" => InvitationRetrieveResponseClinicRole.Neurologist,
            "Urologist" => InvitationRetrieveResponseClinicRole.Urologist,
            "Gynecologist" => InvitationRetrieveResponseClinicRole.Gynecologist,
            "Endocrinologist" => InvitationRetrieveResponseClinicRole.Endocrinologist,
            "Doctor" => InvitationRetrieveResponseClinicRole.Doctor,
            "Surgeon" => InvitationRetrieveResponseClinicRole.Surgeon,
            "Physician" => InvitationRetrieveResponseClinicRole.Physician,
            "Physician Assistant" => InvitationRetrieveResponseClinicRole.PhysicianAssistant,
            "Nurse Practitioner" => InvitationRetrieveResponseClinicRole.NursePractitioner,
            "Registered Nurse" => InvitationRetrieveResponseClinicRole.RegisteredNurse,
            "Patient Care Coordinator" =>
                InvitationRetrieveResponseClinicRole.PatientCareCoordinator,
            "Front Desk Operator" => InvitationRetrieveResponseClinicRole.FrontDeskOperator,
            "Imaging Technologist" => InvitationRetrieveResponseClinicRole.ImagingTechnologist,
            "PACS Administrator" => InvitationRetrieveResponseClinicRole.PacsAdministrator,
            "Software Engineer" => InvitationRetrieveResponseClinicRole.SoftwareEngineer,
            "Revenue Cycle Manager" => InvitationRetrieveResponseClinicRole.RevenueCycleManager,
            "Administrative Director" =>
                InvitationRetrieveResponseClinicRole.AdministrativeDirector,
            "Administrative Assistant" =>
                InvitationRetrieveResponseClinicRole.AdministrativeAssistant,
            "Other" => InvitationRetrieveResponseClinicRole.Other,
            _ => (InvitationRetrieveResponseClinicRole)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvitationRetrieveResponseClinicRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvitationRetrieveResponseClinicRole.Radiologist => "Radiologist",
                InvitationRetrieveResponseClinicRole.Cardiologist => "Cardiologist",
                InvitationRetrieveResponseClinicRole.Neurologist => "Neurologist",
                InvitationRetrieveResponseClinicRole.Urologist => "Urologist",
                InvitationRetrieveResponseClinicRole.Gynecologist => "Gynecologist",
                InvitationRetrieveResponseClinicRole.Endocrinologist => "Endocrinologist",
                InvitationRetrieveResponseClinicRole.Doctor => "Doctor",
                InvitationRetrieveResponseClinicRole.Surgeon => "Surgeon",
                InvitationRetrieveResponseClinicRole.Physician => "Physician",
                InvitationRetrieveResponseClinicRole.PhysicianAssistant => "Physician Assistant",
                InvitationRetrieveResponseClinicRole.NursePractitioner => "Nurse Practitioner",
                InvitationRetrieveResponseClinicRole.RegisteredNurse => "Registered Nurse",
                InvitationRetrieveResponseClinicRole.PatientCareCoordinator =>
                    "Patient Care Coordinator",
                InvitationRetrieveResponseClinicRole.FrontDeskOperator => "Front Desk Operator",
                InvitationRetrieveResponseClinicRole.ImagingTechnologist => "Imaging Technologist",
                InvitationRetrieveResponseClinicRole.PacsAdministrator => "PACS Administrator",
                InvitationRetrieveResponseClinicRole.SoftwareEngineer => "Software Engineer",
                InvitationRetrieveResponseClinicRole.RevenueCycleManager => "Revenue Cycle Manager",
                InvitationRetrieveResponseClinicRole.AdministrativeDirector =>
                    "Administrative Director",
                InvitationRetrieveResponseClinicRole.AdministrativeAssistant =>
                    "Administrative Assistant",
                InvitationRetrieveResponseClinicRole.Other => "Other",
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
[JsonConverter(typeof(InvitedSourceConverter))]
public enum InvitedSource
{
    Dashboard,
    Api,
}

sealed class InvitedSourceConverter : JsonConverter<InvitedSource>
{
    public override InvitedSource Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dashboard" => InvitedSource.Dashboard,
            "api" => InvitedSource.Api,
            _ => (InvitedSource)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvitedSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvitedSource.Dashboard => "dashboard",
                InvitedSource.Api => "api",
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
[JsonConverter(typeof(InvitationRetrieveResponseLevelConverter))]
public enum InvitationRetrieveResponseLevel
{
    Owner,
    Admin,
    Member,
}

sealed class InvitationRetrieveResponseLevelConverter
    : JsonConverter<InvitationRetrieveResponseLevel>
{
    public override InvitationRetrieveResponseLevel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "owner" => InvitationRetrieveResponseLevel.Owner,
            "admin" => InvitationRetrieveResponseLevel.Admin,
            "member" => InvitationRetrieveResponseLevel.Member,
            _ => (InvitationRetrieveResponseLevel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvitationRetrieveResponseLevel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvitationRetrieveResponseLevel.Owner => "owner",
                InvitationRetrieveResponseLevel.Admin => "admin",
                InvitationRetrieveResponseLevel.Member => "member",
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
[JsonConverter(typeof(InvitationRetrieveResponseStatusConverter))]
public enum InvitationRetrieveResponseStatus
{
    Sent,
    Accepted,
    Rejected,
    Revoked,
}

sealed class InvitationRetrieveResponseStatusConverter
    : JsonConverter<InvitationRetrieveResponseStatus>
{
    public override InvitationRetrieveResponseStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sent" => InvitationRetrieveResponseStatus.Sent,
            "accepted" => InvitationRetrieveResponseStatus.Accepted,
            "rejected" => InvitationRetrieveResponseStatus.Rejected,
            "revoked" => InvitationRetrieveResponseStatus.Revoked,
            _ => (InvitationRetrieveResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvitationRetrieveResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvitationRetrieveResponseStatus.Sent => "sent",
                InvitationRetrieveResponseStatus.Accepted => "accepted",
                InvitationRetrieveResponseStatus.Rejected => "rejected",
                InvitationRetrieveResponseStatus.Revoked => "revoked",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
