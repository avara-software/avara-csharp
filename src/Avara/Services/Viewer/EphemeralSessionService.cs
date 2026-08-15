using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Avara.Core;
using Avara.Models.Viewer.EphemeralSessions;

namespace Avara.Services.Viewer;

/// <inheritdoc/>
public sealed class EphemeralSessionService : IEphemeralSessionService
{
    readonly Lazy<IEphemeralSessionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEphemeralSessionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAvaraClient _client;

    /// <inheritdoc/>
    public IEphemeralSessionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EphemeralSessionService(this._client.WithOptions(modifier));
    }

    public EphemeralSessionService(IAvaraClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new EphemeralSessionServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<EphemeralSessionCreateResponse> Create(
        EphemeralSessionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class EphemeralSessionServiceWithRawResponse : IEphemeralSessionServiceWithRawResponse
{
    readonly IAvaraClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEphemeralSessionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new EphemeralSessionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EphemeralSessionServiceWithRawResponse(IAvaraClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EphemeralSessionCreateResponse>> Create(
        EphemeralSessionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EphemeralSessionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var ephemeralSession = await response
                    .Deserialize<EphemeralSessionCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    ephemeralSession.Validate();
                }
                return ephemeralSession;
            }
        );
    }
}
