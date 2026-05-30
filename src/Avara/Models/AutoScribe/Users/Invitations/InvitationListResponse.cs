using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;

namespace Avara.Models.AutoScribe.Users.Invitations;

/// <summary>
/// A pending user invitation in the AutoScribe system
/// </summary>
[JsonConverter(typeof(JsonModelConverter<InvitationListResponse, InvitationListResponseFromRaw>))]
public sealed record class InvitationListResponse : JsonModel
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
    /// Lifecycle status of an invitation: 'sent', 'accepted', 'rejected', or 'revoked'.
    /// </summary>
    public required ApiEnum<string, InvitationStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InvitationStatus>>("status");
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
