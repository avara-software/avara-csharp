using System;
using System.Threading;
using System.Threading.Tasks;
using Avara.Core;
using Avara.Models.Viewer.EphemeralSessions;

namespace Avara.Services.Viewer;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IEphemeralSessionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEphemeralSessionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEphemeralSessionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Mints a 30-second tokenized landing URL for a userless, studyless Viewer
    /// session. The token names a customer retrievalId (not an Avara study). Optional
    /// options are echoed verbatim on ephemeral.access_requested (max 3072 bytes JSON).
    /// Optional hangingProtocol applies a single-monitor layout when the viewer loads.
    /// Requires a customer study webhook on the API key.
    /// </summary>
    Task<EphemeralSessionCreateResponse> Create(
        EphemeralSessionCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IEphemeralSessionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEphemeralSessionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEphemeralSessionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/viewer/ephemeral-sessions</c>, but is otherwise the
    /// same as <see cref="IEphemeralSessionService.Create(EphemeralSessionCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EphemeralSessionCreateResponse>> Create(
        EphemeralSessionCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
