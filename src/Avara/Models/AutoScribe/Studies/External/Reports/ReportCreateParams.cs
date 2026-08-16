using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Avara.Core;

namespace Avara.Models.AutoScribe.Studies.External.Reports;

/// <summary>
/// Attach or fill missing report fields on an existing external study. Text and file
/// are write-once. readerName and signedAt overwrite when provided.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ReportCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Optional original reader / author name. Shown as-is. May be set on study create
    /// or a later report create; a later create overwrites it when provided.
    /// </summary>
    public string? ReaderName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("readerName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("readerName", value);
        }
    }

    /// <summary>
    /// File name including extension. Required when reportFileUrl is provided. Supported
    /// types: PDF, PNG, JPG, GIF, WEBP.
    /// </summary>
    public string? ReportFileName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("reportFileName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("reportFileName", value);
        }
    }

    /// <summary>
    /// HTTPS download URL for a PDF or image (PNG, JPG, GIF, WEBP). Not used for
    /// AI tooling; the reader can still access it. Avara fetches this URL server-side.
    /// If omitted, you can add it later. Once set, it cannot be edited; delete the
    /// study to remake it. Whitelist https://api.avarasoftware.com on the file host
    /// if the fetch is origin-restricted.
    /// </summary>
    public string? ReportFileUrl
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("reportFileUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("reportFileUrl", value);
        }
    }

    /// <summary>
    /// When this study is used as a prior, report AI tools leverage this text directly.
    /// If omitted, you can add it later via POST /studies/external/reports. Once
    /// set, it cannot be edited; delete the study to remake it.
    /// </summary>
    public string? ReportText
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("reportText");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("reportText", value);
        }
    }

    /// <summary>
    /// Optional original sign-off timestamp or label. Shown as-is with no format
    /// validation. May be set on study create or a later report create; a later create
    /// overwrites it when provided.
    /// </summary>
    public string? SignedAt
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("signedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("signedAt", value);
        }
    }

    /// <summary>
    /// Unique study identifier. Format: stu_{32-hex-chars}
    /// </summary>
    public string? StudyID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("studyId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("studyId", value);
        }
    }

    /// <summary>
    /// DICOM Study Instance UID. Must be a valid DICOM UID format (e.g., '1.2.840.10008.5.1.4.1.1.2')
    /// </summary>
    public string? StudyInstanceUid
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("studyInstanceUid");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("studyInstanceUid", value);
        }
    }

    public ReportCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReportCreateParams(ReportCreateParams reportCreateParams)
        : base(reportCreateParams)
    {
        this._rawBodyData = new(reportCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ReportCreateParams(
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
    ReportCreateParams(
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
    public static ReportCreateParams FromRawUnchecked(
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

    public virtual bool Equals(ReportCreateParams? other)
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
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/autoScribe/studies/external/reports"
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
