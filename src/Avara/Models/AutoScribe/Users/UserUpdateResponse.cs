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
/// A user in the AutoScribe system with report creation permissions
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UserUpdateResponse, UserUpdateResponseFromRaw>))]
public sealed record class UserUpdateResponse : JsonModel
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
    public required ApiEnum<string, UserUpdateResponseClinicRole> ClinicRole
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UserUpdateResponseClinicRole>>(
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
    public required ApiEnum<string, UserUpdateResponseInvitedSource> InvitedSource
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UserUpdateResponseInvitedSource>>(
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
    /// User access level. 'owner' has full control, 'admin' can manage users/settings,
    /// 'member' has standard access
    /// </summary>
    public required ApiEnum<string, UserUpdateResponseLevel> Level
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UserUpdateResponseLevel>>("level");
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

    public UserUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserUpdateResponse(UserUpdateResponse userUpdateResponse)
        : base(userUpdateResponse) { }
#pragma warning restore CS8618

    public UserUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserUpdateResponseFromRaw.FromRawUnchecked"/>
    public static UserUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserUpdateResponseFromRaw : IFromRawJson<UserUpdateResponse>
{
    /// <inheritdoc/>
    public UserUpdateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserUpdateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// User's clinical or organizational role
/// </summary>
[JsonConverter(typeof(UserUpdateResponseClinicRoleConverter))]
public enum UserUpdateResponseClinicRole
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

sealed class UserUpdateResponseClinicRoleConverter : JsonConverter<UserUpdateResponseClinicRole>
{
    public override UserUpdateResponseClinicRole Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Radiologist" => UserUpdateResponseClinicRole.Radiologist,
            "Cardiologist" => UserUpdateResponseClinicRole.Cardiologist,
            "Neurologist" => UserUpdateResponseClinicRole.Neurologist,
            "Urologist" => UserUpdateResponseClinicRole.Urologist,
            "Gynecologist" => UserUpdateResponseClinicRole.Gynecologist,
            "Endocrinologist" => UserUpdateResponseClinicRole.Endocrinologist,
            "Doctor" => UserUpdateResponseClinicRole.Doctor,
            "Surgeon" => UserUpdateResponseClinicRole.Surgeon,
            "Physician" => UserUpdateResponseClinicRole.Physician,
            "Physician Assistant" => UserUpdateResponseClinicRole.PhysicianAssistant,
            "Nurse Practitioner" => UserUpdateResponseClinicRole.NursePractitioner,
            "Registered Nurse" => UserUpdateResponseClinicRole.RegisteredNurse,
            "Patient Care Coordinator" => UserUpdateResponseClinicRole.PatientCareCoordinator,
            "Front Desk Operator" => UserUpdateResponseClinicRole.FrontDeskOperator,
            "Imaging Technologist" => UserUpdateResponseClinicRole.ImagingTechnologist,
            "PACS Administrator" => UserUpdateResponseClinicRole.PacsAdministrator,
            "Software Engineer" => UserUpdateResponseClinicRole.SoftwareEngineer,
            "Revenue Cycle Manager" => UserUpdateResponseClinicRole.RevenueCycleManager,
            "Administrative Director" => UserUpdateResponseClinicRole.AdministrativeDirector,
            "Administrative Assistant" => UserUpdateResponseClinicRole.AdministrativeAssistant,
            "Other" => UserUpdateResponseClinicRole.Other,
            _ => (UserUpdateResponseClinicRole)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserUpdateResponseClinicRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserUpdateResponseClinicRole.Radiologist => "Radiologist",
                UserUpdateResponseClinicRole.Cardiologist => "Cardiologist",
                UserUpdateResponseClinicRole.Neurologist => "Neurologist",
                UserUpdateResponseClinicRole.Urologist => "Urologist",
                UserUpdateResponseClinicRole.Gynecologist => "Gynecologist",
                UserUpdateResponseClinicRole.Endocrinologist => "Endocrinologist",
                UserUpdateResponseClinicRole.Doctor => "Doctor",
                UserUpdateResponseClinicRole.Surgeon => "Surgeon",
                UserUpdateResponseClinicRole.Physician => "Physician",
                UserUpdateResponseClinicRole.PhysicianAssistant => "Physician Assistant",
                UserUpdateResponseClinicRole.NursePractitioner => "Nurse Practitioner",
                UserUpdateResponseClinicRole.RegisteredNurse => "Registered Nurse",
                UserUpdateResponseClinicRole.PatientCareCoordinator => "Patient Care Coordinator",
                UserUpdateResponseClinicRole.FrontDeskOperator => "Front Desk Operator",
                UserUpdateResponseClinicRole.ImagingTechnologist => "Imaging Technologist",
                UserUpdateResponseClinicRole.PacsAdministrator => "PACS Administrator",
                UserUpdateResponseClinicRole.SoftwareEngineer => "Software Engineer",
                UserUpdateResponseClinicRole.RevenueCycleManager => "Revenue Cycle Manager",
                UserUpdateResponseClinicRole.AdministrativeDirector => "Administrative Director",
                UserUpdateResponseClinicRole.AdministrativeAssistant => "Administrative Assistant",
                UserUpdateResponseClinicRole.Other => "Other",
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
[JsonConverter(typeof(UserUpdateResponseInvitedSourceConverter))]
public enum UserUpdateResponseInvitedSource
{
    Dashboard,
    Api,
}

sealed class UserUpdateResponseInvitedSourceConverter
    : JsonConverter<UserUpdateResponseInvitedSource>
{
    public override UserUpdateResponseInvitedSource Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dashboard" => UserUpdateResponseInvitedSource.Dashboard,
            "api" => UserUpdateResponseInvitedSource.Api,
            _ => (UserUpdateResponseInvitedSource)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserUpdateResponseInvitedSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserUpdateResponseInvitedSource.Dashboard => "dashboard",
                UserUpdateResponseInvitedSource.Api => "api",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// User access level. 'owner' has full control, 'admin' can manage users/settings,
/// 'member' has standard access
/// </summary>
[JsonConverter(typeof(UserUpdateResponseLevelConverter))]
public enum UserUpdateResponseLevel
{
    Owner,
    Admin,
    Member,
}

sealed class UserUpdateResponseLevelConverter : JsonConverter<UserUpdateResponseLevel>
{
    public override UserUpdateResponseLevel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "owner" => UserUpdateResponseLevel.Owner,
            "admin" => UserUpdateResponseLevel.Admin,
            "member" => UserUpdateResponseLevel.Member,
            _ => (UserUpdateResponseLevel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserUpdateResponseLevel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserUpdateResponseLevel.Owner => "owner",
                UserUpdateResponseLevel.Admin => "admin",
                UserUpdateResponseLevel.Member => "member",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
