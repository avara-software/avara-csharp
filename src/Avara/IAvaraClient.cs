using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Avara.Core;
using Avara.Services;

namespace Avara;

/// <summary>
/// A client for interacting with the Avara REST API.
///
/// <para>This client performs best when you create a single instance and reuse it
/// for all interactions with the REST API. This is because each client holds its
/// own connection pool and thread pools. Reusing connections and threads reduces
/// latency and saves memory.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAvaraClient : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    /// <summary>
    /// API key authentication. Format: sk_live_{32-hex-chars}. Example: sk_live_1234567890abcdef1234567890abcdef
    /// </summary>
    string ApiKey { get; init; }

    /// <summary>
    /// Webhook signing JWT secret for signature verification. Format: whsec_{base64}.
    /// Get this from your Avara dashboard under API Keys &gt; View JWT Secret.
    /// </summary>
    string? WebhookKey { get; init; }

    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAvaraClientWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAvaraClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IAutoScribeService AutoScribe { get; }

    IViewerService Viewer { get; }

    IExpressService Express { get; }

    IWebhookService Webhooks { get; }
}

/// <summary>
/// A view of <see cref="IAvaraClient"/> that provides access to raw HTTP responses for each method.
/// </summary>
public interface IAvaraClientWithRawResponse : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    /// <summary>
    /// API key authentication. Format: sk_live_{32-hex-chars}. Example: sk_live_1234567890abcdef1234567890abcdef
    /// </summary>
    string ApiKey { get; init; }

    /// <summary>
    /// Webhook signing JWT secret for signature verification. Format: whsec_{base64}.
    /// Get this from your Avara dashboard under API Keys &gt; View JWT Secret.
    /// </summary>
    string? WebhookKey { get; init; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAvaraClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IAutoScribeServiceWithRawResponse AutoScribe { get; }

    IViewerServiceWithRawResponse Viewer { get; }

    IExpressServiceWithRawResponse Express { get; }

    IWebhookServiceWithRawResponse Webhooks { get; }

    /// <summary>
    /// Sends a request to the Avara REST API.
    /// </summary>
    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
