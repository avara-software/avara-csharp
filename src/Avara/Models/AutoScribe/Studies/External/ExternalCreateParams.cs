using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Avara.Core;

namespace Avara.Models.AutoScribe.Studies.External;

/// <summary>
/// Creates an archive (external) AutoScribe study. Clinical context fields are not
/// accepted. If no report fields are sent, no report row is created. Study create
/// is all-or-nothing, including file ingest.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ExternalCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Patient demographics and scan information for report generation
    /// </summary>
    public required StudyReportMetadata ReportMetadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<StudyReportMetadata>("reportMetadata");
        }
        init { this._rawBodyData.Set("reportMetadata", value); }
    }

    /// <summary>
    /// Priority level of a study. 'normal' for routine, 'high' for urgent, 'stat'
    /// for immediate attention.
    /// </summary>
    public required ApiEnum<string, Severity> Severity
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, Severity>>("severity");
        }
        init { this._rawBodyData.Set("severity", value); }
    }

    /// <summary>
    /// Description of the study/scan (e.g., 'Brain MRI with Contrast', 'Chest CT')
    /// </summary>
    public required string StudyDescription
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("studyDescription");
        }
        init { this._rawBodyData.Set("studyDescription", value); }
    }

    /// <summary>
    /// DICOM Study Instance UID. Must be a valid DICOM UID format (e.g., '1.2.840.10008.5.1.4.1.1.2')
    /// </summary>
    public required string StudyInstanceUid
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("studyInstanceUid");
        }
        init { this._rawBodyData.Set("studyInstanceUid", value); }
    }

    public string? ExpressCustomerID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("expressCustomerId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("expressCustomerId", value);
        }
    }

    /// <summary>
    /// Strongly recommended if you want to leverage priors functionality for future
    /// reads for this patient.
    /// </summary>
    public string? ExternalPatientID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("externalPatientId");
        }
        init { this._rawBodyData.Set("externalPatientId", value); }
    }

    /// <summary>
    /// Custom key-value metadata for the study. Maximum 50 pairs, keys up to 100
    /// chars, values up to 1000 chars
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string? Modality
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("modality");
        }
        init { this._rawBodyData.Set("modality", value); }
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

    public ExternalCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalCreateParams(ExternalCreateParams externalCreateParams)
        : base(externalCreateParams)
    {
        this._rawBodyData = new(externalCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ExternalCreateParams(
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
    ExternalCreateParams(
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
    public static ExternalCreateParams FromRawUnchecked(
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

    public virtual bool Equals(ExternalCreateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/autoScribe/studies/external"
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
