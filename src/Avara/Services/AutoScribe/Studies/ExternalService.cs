using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Avara.Core;
using Avara.Models.AutoScribe.Studies.External;
using External = Avara.Services.AutoScribe.Studies.External;

namespace Avara.Services.AutoScribe.Studies;

/// <inheritdoc/>
public sealed class ExternalService : IExternalService
{
    readonly Lazy<IExternalServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IExternalServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAvaraClient _client;

    /// <inheritdoc/>
    public IExternalService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ExternalService(this._client.WithOptions(modifier));
    }

    public ExternalService(IAvaraClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ExternalServiceWithRawResponse(client.WithRawResponse));
        _reports = new(() => new External::ReportService(client));
    }

    readonly Lazy<External::IReportService> _reports;
    public External::IReportService Reports
    {
        get { return _reports.Value; }
    }

    /// <inheritdoc/>
    public async Task<ExternalCreateResponse> Create(
        ExternalCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ExternalDeleteResponse> Delete(
        ExternalDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ExternalServiceWithRawResponse : IExternalServiceWithRawResponse
{
    readonly IAvaraClientWithRawResponse _client;

    /// <inheritdoc/>
    public IExternalServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ExternalServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ExternalServiceWithRawResponse(IAvaraClientWithRawResponse client)
    {
        _client = client;

        _reports = new(() => new External::ReportServiceWithRawResponse(client));
    }

    readonly Lazy<External::IReportServiceWithRawResponse> _reports;
    public External::IReportServiceWithRawResponse Reports
    {
        get { return _reports.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExternalCreateResponse>> Create(
        ExternalCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExternalCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var external = await response
                    .Deserialize<ExternalCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    external.Validate();
                }
                return external;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExternalDeleteResponse>> Delete(
        ExternalDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ExternalDeleteParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var external = await response
                    .Deserialize<ExternalDeleteResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    external.Validate();
                }
                return external;
            }
        );
    }
}
