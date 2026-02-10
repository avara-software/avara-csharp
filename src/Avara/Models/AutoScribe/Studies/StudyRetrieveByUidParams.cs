using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Avara.Core;

namespace Avara.Models.AutoScribe.Studies;

/// <summary>
/// Retrieves a single study by its DICOM Study Instance UID. This is useful when
/// you have the DICOM UID but not the Avara study ID.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class StudyRetrieveByUidParams : ParamsBase
{
    public string? StudyInstanceUid { get; init; }

    public StudyRetrieveByUidParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyRetrieveByUidParams(StudyRetrieveByUidParams studyRetrieveByUidParams)
        : base(studyRetrieveByUidParams)
    {
        this.StudyInstanceUid = studyRetrieveByUidParams.StudyInstanceUid;
    }
#pragma warning restore CS8618

    public StudyRetrieveByUidParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StudyRetrieveByUidParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static StudyRetrieveByUidParams FromRawUnchecked(
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
            new Dictionary<string, object?>()
            {
                ["StudyInstanceUid"] = this.StudyInstanceUid,
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(StudyRetrieveByUidParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.StudyInstanceUid?.Equals(other.StudyInstanceUid)
                ?? other.StudyInstanceUid == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/autoScribe/studies/by-uid/{0}", this.StudyInstanceUid)
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
