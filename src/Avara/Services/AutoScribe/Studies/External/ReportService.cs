using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Avara.Core;
using Avara.Exceptions;
using Avara.Models.AutoScribe.Studies.External.Reports;

namespace Avara.Services.AutoScribe.Studies.External;

/// <inheritdoc/>
public sealed class ReportService : IReportService
{
    readonly Lazy<IReportServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IReportServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAvaraClient _client;

    /// <inheritdoc/>
    public IReportService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ReportService(this._client.WithOptions(modifier));
    }

    public ReportService(IAvaraClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ReportServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ReportCreateResponse> Create(
        ReportCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ReportRetrieveResponse> Retrieve(
        ReportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ReportRetrieveResponse> Retrieve(
        string externalReportID,
        ReportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                ExternalReportID = externalReportID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<ReportListPage> List(
        ReportListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ReportServiceWithRawResponse : IReportServiceWithRawResponse
{
    readonly IAvaraClientWithRawResponse _client;

    /// <inheritdoc/>
    public IReportServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ReportServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ReportServiceWithRawResponse(IAvaraClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ReportCreateResponse>> Create(
        ReportCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ReportCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var report = await response
                    .Deserialize<ReportCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    report.Validate();
                }
                return report;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ReportRetrieveResponse>> Retrieve(
        ReportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExternalReportID == null)
        {
            throw new AvaraInvalidDataException("'parameters.ExternalReportID' cannot be null");
        }

        HttpRequest<ReportRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var report = await response
                    .Deserialize<ReportRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    report.Validate();
                }
                return report;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ReportRetrieveResponse>> Retrieve(
        string externalReportID,
        ReportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                ExternalReportID = externalReportID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ReportListPage>> List(
        ReportListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ReportListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<ReportListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ReportListPage(this, parameters, page);
            }
        );
    }
}
