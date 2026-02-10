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
[JsonConverter(typeof(JsonModelConverter<UserRetrieveResponse, UserRetrieveResponseFromRaw>))]
public sealed record class UserRetrieveResponse : JsonModel
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
    public required ApiEnum<string, UserRetrieveResponseClinicRole> ClinicRole
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UserRetrieveResponseClinicRole>>(
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
    public required ApiEnum<string, UserRetrieveResponseInvitedSource> InvitedSource
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, UserRetrieveResponseInvitedSource>
            >("invitedSource");
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
    public required ApiEnum<string, UserRetrieveResponseLevel> Level
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UserRetrieveResponseLevel>>(
                "level"
            );
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

    public UserRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserRetrieveResponse(UserRetrieveResponse userRetrieveResponse)
        : base(userRetrieveResponse) { }
#pragma warning restore CS8618

    public UserRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static UserRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserRetrieveResponseFromRaw : IFromRawJson<UserRetrieveResponse>
{
    /// <inheritdoc/>
    public UserRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserRetrieveResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// User's clinical or organizational role
/// </summary>
[JsonConverter(typeof(UserRetrieveResponseClinicRoleConverter))]
public enum UserRetrieveResponseClinicRole
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

sealed class UserRetrieveResponseClinicRoleConverter : JsonConverter<UserRetrieveResponseClinicRole>
{
    public override UserRetrieveResponseClinicRole Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Radiologist" => UserRetrieveResponseClinicRole.Radiologist,
            "Cardiologist" => UserRetrieveResponseClinicRole.Cardiologist,
            "Neurologist" => UserRetrieveResponseClinicRole.Neurologist,
            "Urologist" => UserRetrieveResponseClinicRole.Urologist,
            "Gynecologist" => UserRetrieveResponseClinicRole.Gynecologist,
            "Endocrinologist" => UserRetrieveResponseClinicRole.Endocrinologist,
            "Doctor" => UserRetrieveResponseClinicRole.Doctor,
            "Surgeon" => UserRetrieveResponseClinicRole.Surgeon,
            "Physician" => UserRetrieveResponseClinicRole.Physician,
            "Physician Assistant" => UserRetrieveResponseClinicRole.PhysicianAssistant,
            "Nurse Practitioner" => UserRetrieveResponseClinicRole.NursePractitioner,
            "Registered Nurse" => UserRetrieveResponseClinicRole.RegisteredNurse,
            "Patient Care Coordinator" => UserRetrieveResponseClinicRole.PatientCareCoordinator,
            "Front Desk Operator" => UserRetrieveResponseClinicRole.FrontDeskOperator,
            "Imaging Technologist" => UserRetrieveResponseClinicRole.ImagingTechnologist,
            "PACS Administrator" => UserRetrieveResponseClinicRole.PacsAdministrator,
            "Software Engineer" => UserRetrieveResponseClinicRole.SoftwareEngineer,
            "Revenue Cycle Manager" => UserRetrieveResponseClinicRole.RevenueCycleManager,
            "Administrative Director" => UserRetrieveResponseClinicRole.AdministrativeDirector,
            "Administrative Assistant" => UserRetrieveResponseClinicRole.AdministrativeAssistant,
            "Other" => UserRetrieveResponseClinicRole.Other,
            _ => (UserRetrieveResponseClinicRole)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserRetrieveResponseClinicRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserRetrieveResponseClinicRole.Radiologist => "Radiologist",
                UserRetrieveResponseClinicRole.Cardiologist => "Cardiologist",
                UserRetrieveResponseClinicRole.Neurologist => "Neurologist",
                UserRetrieveResponseClinicRole.Urologist => "Urologist",
                UserRetrieveResponseClinicRole.Gynecologist => "Gynecologist",
                UserRetrieveResponseClinicRole.Endocrinologist => "Endocrinologist",
                UserRetrieveResponseClinicRole.Doctor => "Doctor",
                UserRetrieveResponseClinicRole.Surgeon => "Surgeon",
                UserRetrieveResponseClinicRole.Physician => "Physician",
                UserRetrieveResponseClinicRole.PhysicianAssistant => "Physician Assistant",
                UserRetrieveResponseClinicRole.NursePractitioner => "Nurse Practitioner",
                UserRetrieveResponseClinicRole.RegisteredNurse => "Registered Nurse",
                UserRetrieveResponseClinicRole.PatientCareCoordinator => "Patient Care Coordinator",
                UserRetrieveResponseClinicRole.FrontDeskOperator => "Front Desk Operator",
                UserRetrieveResponseClinicRole.ImagingTechnologist => "Imaging Technologist",
                UserRetrieveResponseClinicRole.PacsAdministrator => "PACS Administrator",
                UserRetrieveResponseClinicRole.SoftwareEngineer => "Software Engineer",
                UserRetrieveResponseClinicRole.RevenueCycleManager => "Revenue Cycle Manager",
                UserRetrieveResponseClinicRole.AdministrativeDirector => "Administrative Director",
                UserRetrieveResponseClinicRole.AdministrativeAssistant =>
                    "Administrative Assistant",
                UserRetrieveResponseClinicRole.Other => "Other",
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
[JsonConverter(typeof(UserRetrieveResponseInvitedSourceConverter))]
public enum UserRetrieveResponseInvitedSource
{
    Dashboard,
    Api,
}

sealed class UserRetrieveResponseInvitedSourceConverter
    : JsonConverter<UserRetrieveResponseInvitedSource>
{
    public override UserRetrieveResponseInvitedSource Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dashboard" => UserRetrieveResponseInvitedSource.Dashboard,
            "api" => UserRetrieveResponseInvitedSource.Api,
            _ => (UserRetrieveResponseInvitedSource)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserRetrieveResponseInvitedSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserRetrieveResponseInvitedSource.Dashboard => "dashboard",
                UserRetrieveResponseInvitedSource.Api => "api",
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
[JsonConverter(typeof(UserRetrieveResponseLevelConverter))]
public enum UserRetrieveResponseLevel
{
    Owner,
    Admin,
    Member,
}

sealed class UserRetrieveResponseLevelConverter : JsonConverter<UserRetrieveResponseLevel>
{
    public override UserRetrieveResponseLevel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "owner" => UserRetrieveResponseLevel.Owner,
            "admin" => UserRetrieveResponseLevel.Admin,
            "member" => UserRetrieveResponseLevel.Member,
            _ => (UserRetrieveResponseLevel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserRetrieveResponseLevel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserRetrieveResponseLevel.Owner => "owner",
                UserRetrieveResponseLevel.Admin => "admin",
                UserRetrieveResponseLevel.Member => "member",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
