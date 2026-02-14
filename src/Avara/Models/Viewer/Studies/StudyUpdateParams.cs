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

namespace Avara.Models.Viewer.Studies;

/// <summary>
/// Updates a study's properties including description, severity, assignment, organization,
/// and metadata. All fields are optional - only provided fields will be updated.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class StudyUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? StudyID { get; init; }

    /// <summary>
    /// User ID to assign the study to, or null to unassign. Format: usr_{32-hex-chars}
    /// </summary>
    public string? AssignedTo
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("assignedTo");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("assignedTo", value);
        }
    }

    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Priority level of the study. 'normal' for routine, 'high' for urgent, 'stat'
    /// for immediate attention
    /// </summary>
    public ApiEnum<string, StudyUpdateParamsSeverity>? Severity
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, StudyUpdateParamsSeverity>>(
                "severity"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("severity", value);
        }
    }

    /// <summary>
    /// Description of the study/scan (e.g., 'Brain MRI with Contrast', 'Chest CT')
    /// </summary>
    public string? StudyDescription
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("studyDescription");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("studyDescription", value);
        }
    }

    public ApiEnum<string, StudyViewerStatus>? StudyViewerStatus
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, StudyViewerStatus>>(
                "studyViewerStatus"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("studyViewerStatus", value);
        }
    }

    public StudyUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StudyUpdateParams(StudyUpdateParams studyUpdateParams)
        : base(studyUpdateParams)
    {
        this.StudyID = studyUpdateParams.StudyID;

        this._rawBodyData = new(studyUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public StudyUpdateParams(
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
    StudyUpdateParams(
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

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static StudyUpdateParams FromRawUnchecked(
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
                    ["StudyID"] = JsonSerializer.SerializeToElement(this.StudyID),
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

    public virtual bool Equals(StudyUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.StudyID?.Equals(other.StudyID) ?? other.StudyID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/viewer/studies/{0}", this.StudyID)
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

/// <summary>
/// Priority level of the study. 'normal' for routine, 'high' for urgent, 'stat'
/// for immediate attention
/// </summary>
[JsonConverter(typeof(StudyUpdateParamsSeverityConverter))]
public enum StudyUpdateParamsSeverity
{
    Normal,
    High,
    Stat,
}

sealed class StudyUpdateParamsSeverityConverter : JsonConverter<StudyUpdateParamsSeverity>
{
    public override StudyUpdateParamsSeverity Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "normal" => StudyUpdateParamsSeverity.Normal,
            "high" => StudyUpdateParamsSeverity.High,
            "stat" => StudyUpdateParamsSeverity.Stat,
            _ => (StudyUpdateParamsSeverity)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StudyUpdateParamsSeverity value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StudyUpdateParamsSeverity.Normal => "normal",
                StudyUpdateParamsSeverity.High => "high",
                StudyUpdateParamsSeverity.Stat => "stat",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(StudyViewerStatusConverter))]
public enum StudyViewerStatus
{
    Incomplete,
    Complete,
}

sealed class StudyViewerStatusConverter : JsonConverter<StudyViewerStatus>
{
    public override StudyViewerStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "incomplete" => StudyViewerStatus.Incomplete,
            "complete" => StudyViewerStatus.Complete,
            _ => (StudyViewerStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StudyViewerStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StudyViewerStatus.Incomplete => "incomplete",
                StudyViewerStatus.Complete => "complete",
                _ => throw new AvaraInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
