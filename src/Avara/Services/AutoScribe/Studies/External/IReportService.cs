using System;
using System.Threading;
using System.Threading.Tasks;
using Avara.Core;
using Avara.Models.AutoScribe.Studies.External.Reports;

namespace Avara.Services.AutoScribe.Studies.External;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IReportService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IReportServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IReportService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Attach or fill missing report fields on an existing external study. Text and
    /// file are write-once. readerName and signedAt overwrite when provided.
    /// </summary>
    Task<ReportCreateResponse> Create(
        ReportCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns snapshot metadata plus report text and/or a short-lived download URL.
    /// Text is what AI priors use; the file is reader-only and is not used for AI.
    /// </summary>
    Task<ReportRetrieveResponse> Retrieve(
        ReportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ReportRetrieveParams, CancellationToken)"/>
    Task<ReportRetrieveResponse> Retrieve(
        string externalReportID,
        ReportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cursor-paginated list of external reports. List items omit report text and
    /// download URLs.
    /// </summary>
    Task<ReportListPage> List(
        ReportListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IReportService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IReportServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IReportServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/autoScribe/studies/external/reports</c>, but is otherwise the
    /// same as <see cref="IReportService.Create(ReportCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ReportCreateResponse>> Create(
        ReportCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/autoScribe/studies/external/reports/{externalReportId}</c>, but is otherwise the
    /// same as <see cref="IReportService.Retrieve(ReportRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ReportRetrieveResponse>> Retrieve(
        ReportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ReportRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ReportRetrieveResponse>> Retrieve(
        string externalReportID,
        ReportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/autoScribe/studies/external/reports</c>, but is otherwise the
    /// same as <see cref="IReportService.List(ReportListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ReportListPage>> List(
        ReportListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
