using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Avara.Core;

namespace Avara.Models.AutoScribe.Reports;

/// <summary>
/// Retrieves the text content of a report. Can fetch a single report by report ID,
/// or all reports for a study by study ID/DICOM UID. Returns plain text report content.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ReportTextParams : ParamsBase
{
    /// <summary>
    /// Unique report identifier. Format: rep_{32-hex-chars}
    /// </summary>
    public string? ReportID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("reportId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("reportId", value);
        }
    }

    /// <summary>
    /// Unique study identifier. Format: stu_{32-hex-chars}
    /// </summary>
    public string? StudyID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("studyId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("studyId", value);
        }
    }

    /// <summary>
    /// DICOM Study Instance UID. Must be a valid DICOM UID format (e.g., '1.2.840.10008.5.1.4.1.1.2')
    /// </summary>
    public string? StudyInstanceUid
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("studyInstanceUid");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("studyInstanceUid", value);
        }
    }

    public ReportTextParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReportTextParams(ReportTextParams reportTextParams)
        : base(reportTextParams) { }
#pragma warning restore CS8618

    public ReportTextParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReportTextParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static ReportTextParams FromRawUnchecked(
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

    public virtual bool Equals(ReportTextParams? other)
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
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/autoScribe/reports/text"
        )
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
