using System;
using Avara.Core;
using Avara.Services.AutoScribe;

namespace Avara.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAutoScribeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAutoScribeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAutoScribeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IStudyService Studies { get; }

    IUserService Users { get; }

    IReportService Reports { get; }
}

/// <summary>
/// A view of <see cref="IAutoScribeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAutoScribeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAutoScribeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IStudyServiceWithRawResponse Studies { get; }

    IUserServiceWithRawResponse Users { get; }

    IReportServiceWithRawResponse Reports { get; }
}
