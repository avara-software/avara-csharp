using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avara.Core;
using Avara.Exceptions;

namespace Avara.Models.Viewer.Users;

/// <summary>
/// Updates a user's profile information, permissions, and access level. All fields
/// are optional - only provided fields will be updated. Email cannot be changed
/// via API.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class UserUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? UserID { get; init; }

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
    /// User's first name
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
    /// Whether the user can access the dashboard interface. Required for admin users
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
    /// User's last name
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

    public ApiEnum<string, Level>? Level
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Level>>("level");
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

    public UserUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserUpdateParams(UserUpdateParams userUpdateParams)
        : base(userUpdateParams)
    {
        this.UserID = userUpdateParams.UserID;

        this._rawBodyData = new(userUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public UserUpdateParams(
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
    UserUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string userID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.UserID = userID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static UserUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string userID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            userID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["UserID"] = JsonSerializer.SerializeToElement(this.UserID),
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

    public virtual bool Equals(UserUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.UserID?.Equals(other.UserID) ?? other.UserID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/viewer/users/{0}", this.UserID)
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

[JsonConverter(typeof(ClinicRoleConverter))]
public enum ClinicRole
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

sealed class ClinicRoleConverter : JsonConverter<ClinicRole>
{
    public override ClinicRole Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Radiologist" => ClinicRole.Radiologist,
            "Cardiologist" => ClinicRole.Cardiologist,
            "Neurologist" => ClinicRole.Neurologist,
            "Urologist" => ClinicRole.Urologist,
            "Gynecologist" => ClinicRole.Gynecologist,
            "Endocrinologist" => ClinicRole.Endocrinologist,
            "Doctor" => ClinicRole.Doctor,
            "Surgeon" => ClinicRole.Surgeon,
            "Physician" => ClinicRole.Physician,
            "Physician Assistant" => ClinicRole.PhysicianAssistant,
            "Nurse Practitioner" => ClinicRole.NursePractitioner,
            "Registered Nurse" => ClinicRole.RegisteredNurse,
            "Patient Care Coordinator" => ClinicRole.PatientCareCoordinator,
            "Front Desk Operator" => ClinicRole.FrontDeskOperator,
            "Imaging Technologist" => ClinicRole.ImagingTechnologist,
            "PACS Administrator" => ClinicRole.PacsAdministrator,
            "Software Engineer" => ClinicRole.SoftwareEngineer,
            "Revenue Cycle Manager" => ClinicRole.RevenueCycleManager,
            "Administrative Director" => ClinicRole.AdministrativeDirector,
            "Administrative Assistant" => ClinicRole.AdministrativeAssistant,
            "Other" => ClinicRole.Other,
            _ => (ClinicRole)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ClinicRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ClinicRole.Radiologist => "Radiologist",
                ClinicRole.Cardiologist => "Cardiologist",
                ClinicRole.Neurologist => "Neurologist",
                ClinicRole.Urologist => "Urologist",
                ClinicRole.Gynecologist => "Gynecologist",
                ClinicRole.Endocrinologist => "Endocrinologist",
                ClinicRole.Doctor => "Doctor",
                ClinicRole.Surgeon => "Surgeon",
                ClinicRole.Physician => "Physician",
                ClinicRole.PhysicianAssistant => "Physician Assistant",
                ClinicRole.NursePractitioner => "Nurse Practitioner",
                ClinicRole.RegisteredNurse => "Registered Nurse",
                ClinicRole.PatientCareCoordinator => "Patient Care Coordinator",
                ClinicRole.FrontDeskOperator => "Front Desk Operator",
                ClinicRole.ImagingTechnologist => "Imaging Technologist",
                ClinicRole.PacsAdministrator => "PACS Administrator",
                ClinicRole.SoftwareEngineer => "Software Engineer",
                ClinicRole.RevenueCycleManager => "Revenue Cycle Manager",
                ClinicRole.AdministrativeDirector => "Administrative Director",
                ClinicRole.AdministrativeAssistant => "Administrative Assistant",
                ClinicRole.Other => "Other",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(LevelConverter))]
public enum Level
{
    Admin,
    Member,
}

sealed class LevelConverter : JsonConverter<Level>
{
    public override Level Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "admin" => Level.Admin,
            "member" => Level.Member,
            _ => (Level)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Level value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Level.Admin => "admin",
                Level.Member => "member",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
