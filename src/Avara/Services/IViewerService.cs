using System;
using Avara.Core;
using Avara.Services.Viewer;

namespace Avara.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IViewerService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IViewerServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IViewerService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IEphemeralSessionService EphemeralSessions { get; }

    IStudyService Studies { get; }

    IUserService Users { get; }
}

/// <summary>
/// A view of <see cref="IViewerService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IViewerServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IViewerServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IEphemeralSessionServiceWithRawResponse EphemeralSessions { get; }

    IStudyServiceWithRawResponse Studies { get; }

    IUserServiceWithRawResponse Users { get; }
}
