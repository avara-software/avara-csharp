using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Avara.Core;

namespace Avara.Models.AutoScribe.Users;

/// <summary>
/// Creates a new user in the AutoScribe system and sends them an invitation email.
/// The user will have the specified permissions including report creation and study
/// management capabilities. NPI number is required for users who can create reports.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class UserInviteParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required bool CanCreateReports
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<bool>("canCreateReports");
        }
        init { this._rawBodyData.Set("canCreateReports", value); }
    }

    public required bool CanManageStudies
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<bool>("canManageStudies");
        }
        init { this._rawBodyData.Set("canManageStudies", value); }
    }

    /// <summary>
    /// A user's clinical or organizational role within the clinic.
    /// </summary>
    public required ApiEnum<string, ClinicRole> ClinicRole
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, ClinicRole>>("clinicRole");
        }
        init { this._rawBodyData.Set("clinicRole", value); }
    }

    /// <summary>
    /// User's email address for login and notifications
    /// </summary>
    public required string Email
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("email");
        }
        init { this._rawBodyData.Set("email", value); }
    }

    /// <summary>
    /// User's first name
    /// </summary>
    public required string FirstName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("firstName");
        }
        init { this._rawBodyData.Set("firstName", value); }
    }

    public required bool HasDashboardAccess
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<bool>("hasDashboardAccess");
        }
        init { this._rawBodyData.Set("hasDashboardAccess", value); }
    }

    /// <summary>
    /// User's last name
    /// </summary>
    public required string LastName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("lastName");
        }
        init { this._rawBodyData.Set("lastName", value); }
    }

    /// <summary>
    /// User access level assignable via the API. 'admin' can manage users/settings,
    /// 'member' has standard access. 'owner' is dashboard-only and cannot be assigned
    /// via the API.
    /// </summary>
    public required ApiEnum<string, AssignableUserLevel> Level
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, AssignableUserLevel>>("level");
        }
        init { this._rawBodyData.Set("level", value); }
    }

    /// <summary>
    /// User's middle name (optional)
    /// </summary>
    public string? MiddleName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("middleName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("middleName", value);
        }
    }

    public string? NpiNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("npiNumber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("npiNumber", value);
        }
    }

    /// <summary>
    /// User's phone number (10-15 digits, optional)
    /// </summary>
    public string? PhoneNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("phoneNumber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("phoneNumber", value);
        }
    }

    /// <summary>
    /// Name suffix (e.g., 'Jr.', 'Sr.', 'III') - optional
    /// </summary>
    public string? Suffix1
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("suffix1");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("suffix1", value);
        }
    }

    /// <summary>
    /// Additional name suffix (optional)
    /// </summary>
    public string? Suffix2
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("suffix2");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("suffix2", value);
        }
    }

    public UserInviteParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserInviteParams(UserInviteParams userInviteParams)
        : base(userInviteParams)
    {
        this._rawBodyData = new(userInviteParams._rawBodyData);
    }
#pragma warning restore CS8618

    public UserInviteParams(
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
    UserInviteParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static UserInviteParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
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

    public virtual bool Equals(UserInviteParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/autoScribe/users")
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
