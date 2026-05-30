using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Avara.Core;

namespace Avara.Models.Viewer.Studies;

/// <summary>
/// Retrieves a paginated list of studies with optional filtering by assignment, severity,
/// description, cancellation status, and viewer status. Returns up to 100 studies
/// per request.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class StudyListParams : ParamsBase
{
    /// <summary>
    /// Filter by assigned user ID (null = explicitly unassigned). Format: usr_&lt;32-hex-chars&gt;
    /// </summary>
    public string? AssignedTo
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("assignedTo");
        }
        init { this._rawQueryData.Set("assignedTo", value); }
    }

    /// <summary>
    /// Base64 encoded cursor from previous response
    /// </summary>
    public string? Cursor
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("cursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("cursor", value);
        }
    }

    /// <summary>
    /// Filter by Express customer ID (null = studies with no customer). Format: cus_{32-hex-chars}
    /// </summary>
    public string? ExpressCustomerID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("expressCustomerId");
        }
        init { this._rawQueryData.Set("expressCustomerId", value); }
    }

    /// <summary>
    /// Filter by cancellation status
    /// </summary>
    public bool? IsCancelled
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("isCancelled");
        }
        init { this._rawQueryData.Set("isCancelled", value); }
    }

    /// <summary>
    /// Number of results to return (1-100)
    /// </summary>
    public double? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<double>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    /// <summary>
    /// Filter by study severity
    /// </summary>
    public ApiEnum<string, Severity>? Severity
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Severity>>("severity");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("severity", value);
        }
    }

    /// <summary>
    /// Filter by study description (contains match)
    /// </summary>
    public string? StudyDescription
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("studyDescription");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("studyDescription", value);
        }
    }

    /// <summary>
    /// Filter by study viewer status
    /// </summary>
    public ApiEnum<string, StudyViewerStatus>? StudyViewerStatus
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, StudyViewerStatus>>(
                "studyViewerStatus"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("studyViewerStatus", value);
        }
    }

    public StudyListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyListParams(StudyListParams studyListParams)
        : base(studyListParams) { }
#pragma warning restore CS8618

    public StudyListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static StudyListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
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
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(StudyListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/viewer/studies")
        {
            Query = this.QueryString(options),
        }.Uri;
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
