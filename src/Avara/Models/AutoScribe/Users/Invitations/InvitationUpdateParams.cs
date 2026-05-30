using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Avara.Core;

namespace Avara.Models.AutoScribe.Users.Invitations;

/// <summary>
/// Updates a pending invitation's user details, permissions, and AutoScribe-specific
/// settings before it is accepted. Only valid for invitations that have not expired
/// or been processed. NPI number is required if enabling report creation.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class InvitationUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? InvitationID { get; init; }

    /// <summary>
    /// Whether the invited user can generate and sign radiology reports. Requires
    /// NPI number
    /// </summary>
    public bool? CanCreateReports
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("canCreateReports");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("canCreateReports", value);
        }
    }

    /// <summary>
    /// Whether the invited user will have permission to create, update, and manage studies
    /// </summary>
    public bool? CanManageStudies
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("canManageStudies");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("canManageStudies", value);
        }
    }

    /// <summary>
    /// A user's clinical or organizational role within the clinic.
    /// </summary>
    public ApiEnum<string, ClinicRole>? ClinicRole
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ClinicRole>>("clinicRole");
        }
        init { this._rawBodyData.Set("clinicRole", value); }
    }

    /// <summary>
    /// Invited user's first name
    /// </summary>
    public string? FirstName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("firstName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("firstName", value);
        }
    }

    /// <summary>
    /// Whether the invited user will have dashboard access
    /// </summary>
    public bool? HasDashboardAccess
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("hasDashboardAccess");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("hasDashboardAccess", value);
        }
    }

    /// <summary>
    /// Invited user's last name
    /// </summary>
    public string? LastName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("lastName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("lastName", value);
        }
    }

    /// <summary>
    /// User access level assignable via the API. 'admin' can manage users/settings,
    /// 'member' has standard access. 'owner' is dashboard-only and cannot be assigned
    /// via the API.
    /// </summary>
    public ApiEnum<string, AssignableUserLevel>? Level
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, AssignableUserLevel>>(
                "level"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("level", value);
        }
    }

    public string? MiddleName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("middleName");
        }
        init { this._rawBodyData.Set("middleName", value); }
    }

    public string? NpiNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("npiNumber");
        }
        init { this._rawBodyData.Set("npiNumber", value); }
    }

    public string? PhoneNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("phoneNumber");
        }
        init { this._rawBodyData.Set("phoneNumber", value); }
    }

    public string? Suffix1
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("suffix1");
        }
        init { this._rawBodyData.Set("suffix1", value); }
    }

    public string? Suffix2
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("suffix2");
        }
        init { this._rawBodyData.Set("suffix2", value); }
    }

    public InvitationUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvitationUpdateParams(InvitationUpdateParams invitationUpdateParams)
        : base(invitationUpdateParams)
    {
        this.InvitationID = invitationUpdateParams.InvitationID;

        this._rawBodyData = new(invitationUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public InvitationUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvitationUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string invitationID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.InvitationID = invitationID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static InvitationUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string invitationID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            invitationID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["InvitationID"] = JsonSerializer.SerializeToElement(this.InvitationID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(InvitationUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.InvitationID?.Equals(other.InvitationID) ?? other.InvitationID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/autoScribe/users/invitations/{0}", this.InvitationID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
