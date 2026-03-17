using System;
using System.Threading;
using System.Threading.Tasks;
using Avara.Core;
using Avara.Models.AutoScribe.Reports;

namespace Avara.Services.AutoScribe;

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
    /// Retrieves all reports (including versions and addendums) for a specific study.
    /// Must provide either study ID or DICOM Study Instance UID. Returns report
    /// metadata including status, version, and timestamps.
    /// </summary>
    Task<ReportListResponse> List(
        ReportListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Initiates the creation of an addendum to an existing completed report. The study
    /// status will change to 'addendum_active' allowing the radiologist to dictate
    /// additional findings.
    /// </summary>
    Task<ReportAddendumResponse> Addendum(
        ReportAddendumParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Addendum(ReportAddendumParams, CancellationToken)"/>
    Task<ReportAddendumResponse> Addendum(
        string reportID,
        ReportAddendumParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancels an in-progress addendum and reverts the study status to 'completed'. The
    /// original report remains unchanged. Only valid for active addendums.
    /// </summary>
    Task<ReportCancelAddendumResponse> CancelAddendum(
        ReportCancelAddendumParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CancelAddendum(ReportCancelAddendumParams, CancellationToken)"/>
    Task<ReportCancelAddendumResponse> CancelAddendum(
        string reportID,
        ReportCancelAddendumParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves presigned URLs for accessing report PDFs. Can fetch a single report by
    /// report ID, or all reports for a study by study ID/DICOM UID. URLs are
    /// time-limited for security.
    /// </summary>
    Task<ReportPdfResponse> Pdf(
        ReportPdfParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves the text content of a report. Can fetch a single report by report ID,
    /// or all reports for a study by study ID/DICOM UID. Returns plain text report
    /// content.
    /// </summary>
    Task<ReportTextResponse> Text(
        ReportTextParams? parameters = null,
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
    /// Returns a raw HTTP response for <c>get /v1/autoScribe/reports</c>, but is otherwise the
    /// same as <see cref="IReportService.List(ReportListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ReportListResponse>> List(
        ReportListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/autoScribe/reports/{reportId}/addendum</c>, but is otherwise the
    /// same as <see cref="IReportService.Addendum(ReportAddendumParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ReportAddendumResponse>> Addendum(
        ReportAddendumParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Addendum(ReportAddendumParams, CancellationToken)"/>
    Task<HttpResponse<ReportAddendumResponse>> Addendum(
        string reportID,
        ReportAddendumParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/autoScribe/reports/{reportId}/cancel-addendum</c>, but is otherwise the
    /// same as <see cref="IReportService.CancelAddendum(ReportCancelAddendumParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ReportCancelAddendumResponse>> CancelAddendum(
        ReportCancelAddendumParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CancelAddendum(ReportCancelAddendumParams, CancellationToken)"/>
    Task<HttpResponse<ReportCancelAddendumResponse>> CancelAddendum(
        string reportID,
        ReportCancelAddendumParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/autoScribe/reports/pdf</c>, but is otherwise the
    /// same as <see cref="IReportService.Pdf(ReportPdfParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ReportPdfResponse>> Pdf(
        ReportPdfParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/autoScribe/reports/text</c>, but is otherwise the
    /// same as <see cref="IReportService.Text(ReportTextParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ReportTextResponse>> Text(
        ReportTextParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
