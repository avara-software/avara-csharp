using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.Viewer.Users;

/// <summary>
/// A user in the Viewer system with study management permissions
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UserUpdateResponse, UserUpdateResponseFromRaw>))]
public sealed record class UserUpdateResponse : JsonModel
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
    /// A user's clinical or organizational role within the clinic.
    /// </summary>
    public required ApiEnum<string, ClinicRole> ClinicRole
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ClinicRole>>("clinicRole");
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
    /// How a user/invitation was created - via the dashboard UI ('dashboard') or
    /// the API ('api').
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
    /// User access level. 'owner' has full control (dashboard-only, not assignable
    /// via API), 'admin' can manage users/settings, 'member' has standard access.
    /// </summary>
    public required ApiEnum<string, UserLevel> Level
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UserLevel>>("level");
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
