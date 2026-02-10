using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;
using Avara.Exceptions;

namespace Avara.Models.Viewer.Users;

/// <summary>
/// A user in the Viewer system with study management permissions
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UserListResponse, UserListResponseFromRaw>))]
public sealed record class UserListResponse : JsonModel
{
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
    public required ApiEnum<string, UserListResponseClinicRole> ClinicRole
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UserListResponseClinicRole>>(
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
    public required ApiEnum<string, UserListResponseInvitedSource> InvitedSource
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UserListResponseInvitedSource>>(
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
    /// User access level
    /// </summary>
    public required ApiEnum<string, UserListResponseLevel> Level
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UserListResponseLevel>>("level");
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
        _ = this.PhoneNumber;
        _ = this.Suffix1;
        _ = this.Suffix2;
    }

    public UserListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserListResponse(UserListResponse userListResponse)
        : base(userListResponse) { }
#pragma warning restore CS8618

    public UserListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserListResponseFromRaw.FromRawUnchecked"/>
    public static UserListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserListResponseFromRaw : IFromRawJson<UserListResponse>
{
    /// <inheritdoc/>
    public UserListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// User's clinical or organizational role
/// </summary>
[JsonConverter(typeof(UserListResponseClinicRoleConverter))]
public enum UserListResponseClinicRole
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

sealed class UserListResponseClinicRoleConverter : JsonConverter<UserListResponseClinicRole>
{
    public override UserListResponseClinicRole Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Radiologist" => UserListResponseClinicRole.Radiologist,
            "Cardiologist" => UserListResponseClinicRole.Cardiologist,
            "Neurologist" => UserListResponseClinicRole.Neurologist,
            "Urologist" => UserListResponseClinicRole.Urologist,
            "Gynecologist" => UserListResponseClinicRole.Gynecologist,
            "Endocrinologist" => UserListResponseClinicRole.Endocrinologist,
            "Doctor" => UserListResponseClinicRole.Doctor,
            "Surgeon" => UserListResponseClinicRole.Surgeon,
            "Physician" => UserListResponseClinicRole.Physician,
            "Physician Assistant" => UserListResponseClinicRole.PhysicianAssistant,
            "Nurse Practitioner" => UserListResponseClinicRole.NursePractitioner,
            "Registered Nurse" => UserListResponseClinicRole.RegisteredNurse,
            "Patient Care Coordinator" => UserListResponseClinicRole.PatientCareCoordinator,
            "Front Desk Operator" => UserListResponseClinicRole.FrontDeskOperator,
            "Imaging Technologist" => UserListResponseClinicRole.ImagingTechnologist,
            "PACS Administrator" => UserListResponseClinicRole.PacsAdministrator,
            "Software Engineer" => UserListResponseClinicRole.SoftwareEngineer,
            "Revenue Cycle Manager" => UserListResponseClinicRole.RevenueCycleManager,
            "Administrative Director" => UserListResponseClinicRole.AdministrativeDirector,
            "Administrative Assistant" => UserListResponseClinicRole.AdministrativeAssistant,
            "Other" => UserListResponseClinicRole.Other,
            _ => (UserListResponseClinicRole)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserListResponseClinicRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserListResponseClinicRole.Radiologist => "Radiologist",
                UserListResponseClinicRole.Cardiologist => "Cardiologist",
                UserListResponseClinicRole.Neurologist => "Neurologist",
                UserListResponseClinicRole.Urologist => "Urologist",
                UserListResponseClinicRole.Gynecologist => "Gynecologist",
                UserListResponseClinicRole.Endocrinologist => "Endocrinologist",
                UserListResponseClinicRole.Doctor => "Doctor",
                UserListResponseClinicRole.Surgeon => "Surgeon",
                UserListResponseClinicRole.Physician => "Physician",
                UserListResponseClinicRole.PhysicianAssistant => "Physician Assistant",
                UserListResponseClinicRole.NursePractitioner => "Nurse Practitioner",
                UserListResponseClinicRole.RegisteredNurse => "Registered Nurse",
                UserListResponseClinicRole.PatientCareCoordinator => "Patient Care Coordinator",
                UserListResponseClinicRole.FrontDeskOperator => "Front Desk Operator",
                UserListResponseClinicRole.ImagingTechnologist => "Imaging Technologist",
                UserListResponseClinicRole.PacsAdministrator => "PACS Administrator",
                UserListResponseClinicRole.SoftwareEngineer => "Software Engineer",
                UserListResponseClinicRole.RevenueCycleManager => "Revenue Cycle Manager",
                UserListResponseClinicRole.AdministrativeDirector => "Administrative Director",
                UserListResponseClinicRole.AdministrativeAssistant => "Administrative Assistant",
                UserListResponseClinicRole.Other => "Other",
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
[JsonConverter(typeof(UserListResponseInvitedSourceConverter))]
public enum UserListResponseInvitedSource
{
    Dashboard,
    Api,
}

sealed class UserListResponseInvitedSourceConverter : JsonConverter<UserListResponseInvitedSource>
{
    public override UserListResponseInvitedSource Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dashboard" => UserListResponseInvitedSource.Dashboard,
            "api" => UserListResponseInvitedSource.Api,
            _ => (UserListResponseInvitedSource)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserListResponseInvitedSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserListResponseInvitedSource.Dashboard => "dashboard",
                UserListResponseInvitedSource.Api => "api",
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
[JsonConverter(typeof(UserListResponseLevelConverter))]
public enum UserListResponseLevel
{
    Owner,
    Admin,
    Member,
}

sealed class UserListResponseLevelConverter : JsonConverter<UserListResponseLevel>
{
    public override UserListResponseLevel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "owner" => UserListResponseLevel.Owner,
            "admin" => UserListResponseLevel.Admin,
            "member" => UserListResponseLevel.Member,
            _ => (UserListResponseLevel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserListResponseLevel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserListResponseLevel.Owner => "owner",
                UserListResponseLevel.Admin => "admin",
                UserListResponseLevel.Member => "member",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
