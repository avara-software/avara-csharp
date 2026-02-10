using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;
using Avara.Exceptions;

namespace Avara.Models.AutoScribe.Users;

/// <summary>
/// Response for inviting a user to AutoScribe. Level is restricted to admin/member
/// since owners cannot be invited via API.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UserInviteResponse, UserInviteResponseFromRaw>))]
public sealed record class UserInviteResponse : JsonModel
{
    /// <summary>
    /// Whether the user can generate and sign radiology reports. Requires NPI number
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
    /// Whether the user has permission to create, update, and manage studies
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
    /// User's clinical or organizational role
    /// </summary>
    public required ApiEnum<string, UserInviteResponseClinicRole> ClinicRole
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UserInviteResponseClinicRole>>(
                "clinicRole"
            );
        }
        init { this._rawData.Set("clinicRole", value); }
    }

    /// <summary>
    /// Timestamp when the user was created
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
    /// User's email address for login and notifications
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
    /// User's first name
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
    /// Whether the user can access the dashboard interface. Required for admin users
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
    /// How the user was invited - via dashboard UI or API
    /// </summary>
    public required ApiEnum<string, UserInviteResponseInvitedSource> InvitedSource
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UserInviteResponseInvitedSource>>(
                "invitedSource"
            );
        }
        init { this._rawData.Set("invitedSource", value); }
    }

    /// <summary>
    /// Timestamp of user's last login, null if never logged in
    /// </summary>
    public required DateTimeOffset? LastLoginAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("lastLoginAt");
        }
        init { this._rawData.Set("lastLoginAt", value); }
    }

    /// <summary>
    /// User's last name
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
    /// User access level. 'admin' can manage users/settings, 'member' has standard access
    /// </summary>
    public required ApiEnum<string, UserInviteResponseLevel> Level
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UserInviteResponseLevel>>("level");
        }
        init { this._rawData.Set("level", value); }
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
    /// User's middle name (optional)
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
    /// User's phone number (10-15 digits, optional)
    /// </summary>
    public string? PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phoneNumber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phoneNumber", value);
        }
    }

    /// <summary>
    /// Name suffix (e.g., 'Jr.', 'Sr.', 'III') - optional
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
    /// Additional name suffix (optional)
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
        _ = this.CanCreateReports;
        _ = this.CanManageStudies;
        this.ClinicRole.Validate();
        _ = this.CreatedAt;
        _ = this.Email;
        _ = this.FirstName;
        _ = this.HasDashboardAccess;
        this.InvitedSource.Validate();
        _ = this.LastLoginAt;
        _ = this.LastName;
        this.Level.Validate();
        _ = this.UserID;
        _ = this.MiddleName;
        _ = this.NpiNumber;
        _ = this.PhoneNumber;
        _ = this.Suffix1;
        _ = this.Suffix2;
    }

    public UserInviteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserInviteResponse(UserInviteResponse userInviteResponse)
        : base(userInviteResponse) { }
#pragma warning restore CS8618

    public UserInviteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserInviteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserInviteResponseFromRaw.FromRawUnchecked"/>
    public static UserInviteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserInviteResponseFromRaw : IFromRawJson<UserInviteResponse>
{
    /// <inheritdoc/>
    public UserInviteResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserInviteResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// User's clinical or organizational role
/// </summary>
[JsonConverter(typeof(UserInviteResponseClinicRoleConverter))]
public enum UserInviteResponseClinicRole
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

sealed class UserInviteResponseClinicRoleConverter : JsonConverter<UserInviteResponseClinicRole>
{
    public override UserInviteResponseClinicRole Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Radiologist" => UserInviteResponseClinicRole.Radiologist,
            "Cardiologist" => UserInviteResponseClinicRole.Cardiologist,
            "Neurologist" => UserInviteResponseClinicRole.Neurologist,
            "Urologist" => UserInviteResponseClinicRole.Urologist,
            "Gynecologist" => UserInviteResponseClinicRole.Gynecologist,
            "Endocrinologist" => UserInviteResponseClinicRole.Endocrinologist,
            "Doctor" => UserInviteResponseClinicRole.Doctor,
            "Surgeon" => UserInviteResponseClinicRole.Surgeon,
            "Physician" => UserInviteResponseClinicRole.Physician,
            "Physician Assistant" => UserInviteResponseClinicRole.PhysicianAssistant,
            "Nurse Practitioner" => UserInviteResponseClinicRole.NursePractitioner,
            "Registered Nurse" => UserInviteResponseClinicRole.RegisteredNurse,
            "Patient Care Coordinator" => UserInviteResponseClinicRole.PatientCareCoordinator,
            "Front Desk Operator" => UserInviteResponseClinicRole.FrontDeskOperator,
            "Imaging Technologist" => UserInviteResponseClinicRole.ImagingTechnologist,
            "PACS Administrator" => UserInviteResponseClinicRole.PacsAdministrator,
            "Software Engineer" => UserInviteResponseClinicRole.SoftwareEngineer,
            "Revenue Cycle Manager" => UserInviteResponseClinicRole.RevenueCycleManager,
            "Administrative Director" => UserInviteResponseClinicRole.AdministrativeDirector,
            "Administrative Assistant" => UserInviteResponseClinicRole.AdministrativeAssistant,
            "Other" => UserInviteResponseClinicRole.Other,
            _ => (UserInviteResponseClinicRole)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserInviteResponseClinicRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserInviteResponseClinicRole.Radiologist => "Radiologist",
                UserInviteResponseClinicRole.Cardiologist => "Cardiologist",
                UserInviteResponseClinicRole.Neurologist => "Neurologist",
                UserInviteResponseClinicRole.Urologist => "Urologist",
                UserInviteResponseClinicRole.Gynecologist => "Gynecologist",
                UserInviteResponseClinicRole.Endocrinologist => "Endocrinologist",
                UserInviteResponseClinicRole.Doctor => "Doctor",
                UserInviteResponseClinicRole.Surgeon => "Surgeon",
                UserInviteResponseClinicRole.Physician => "Physician",
                UserInviteResponseClinicRole.PhysicianAssistant => "Physician Assistant",
                UserInviteResponseClinicRole.NursePractitioner => "Nurse Practitioner",
                UserInviteResponseClinicRole.RegisteredNurse => "Registered Nurse",
                UserInviteResponseClinicRole.PatientCareCoordinator => "Patient Care Coordinator",
                UserInviteResponseClinicRole.FrontDeskOperator => "Front Desk Operator",
                UserInviteResponseClinicRole.ImagingTechnologist => "Imaging Technologist",
                UserInviteResponseClinicRole.PacsAdministrator => "PACS Administrator",
                UserInviteResponseClinicRole.SoftwareEngineer => "Software Engineer",
                UserInviteResponseClinicRole.RevenueCycleManager => "Revenue Cycle Manager",
                UserInviteResponseClinicRole.AdministrativeDirector => "Administrative Director",
                UserInviteResponseClinicRole.AdministrativeAssistant => "Administrative Assistant",
                UserInviteResponseClinicRole.Other => "Other",
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
[JsonConverter(typeof(UserInviteResponseInvitedSourceConverter))]
public enum UserInviteResponseInvitedSource
{
    Dashboard,
    Api,
}

sealed class UserInviteResponseInvitedSourceConverter
    : JsonConverter<UserInviteResponseInvitedSource>
{
    public override UserInviteResponseInvitedSource Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dashboard" => UserInviteResponseInvitedSource.Dashboard,
            "api" => UserInviteResponseInvitedSource.Api,
            _ => (UserInviteResponseInvitedSource)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserInviteResponseInvitedSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserInviteResponseInvitedSource.Dashboard => "dashboard",
                UserInviteResponseInvitedSource.Api => "api",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// User access level. 'admin' can manage users/settings, 'member' has standard access
/// </summary>
[JsonConverter(typeof(UserInviteResponseLevelConverter))]
public enum UserInviteResponseLevel
{
    Admin,
    Member,
}

sealed class UserInviteResponseLevelConverter : JsonConverter<UserInviteResponseLevel>
{
    public override UserInviteResponseLevel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "admin" => UserInviteResponseLevel.Admin,
            "member" => UserInviteResponseLevel.Member,
            _ => (UserInviteResponseLevel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserInviteResponseLevel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserInviteResponseLevel.Admin => "admin",
                UserInviteResponseLevel.Member => "member",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
