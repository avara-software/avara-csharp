using System;
using System.Threading;
using System.Threading.Tasks;
using Avara.Core;
using Avara.Models.AutoScribe.Studies.External;
using External = Avara.Services.AutoScribe.Studies.External;

namespace Avara.Services.AutoScribe.Studies;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IExternalService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IExternalServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExternalService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    External::IReportService Reports { get; }

    /// <summary>
    /// Creates an archive (external) AutoScribe study. Clinical context fields are not
    /// accepted. If no report fields are sent, no report row is created. Study create
    /// is all-or-nothing, including file ingest.
    /// </summary>
    Task<ExternalCreateResponse> Create(
        ExternalCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Soft-deletes an external study. This is one-way; POST /studies/uncancel cannot
    /// reverse it.
    /// </summary>
    Task<ExternalDeleteResponse> Delete(
        ExternalDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IExternalService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IExternalServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExternalServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    External::IReportServiceWithRawResponse Reports { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/autoScribe/studies/external</c>, but is otherwise the
    /// same as <see cref="IExternalService.Create(ExternalCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExternalCreateResponse>> Create(
        ExternalCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/autoScribe/studies/external/delete</c>, but is otherwise the
    /// same as <see cref="IExternalService.Delete(ExternalDeleteParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExternalDeleteResponse>> Delete(
        ExternalDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
