using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Avara.Core;
using Avara.Exceptions;
using Avara.Models.AutoScribe.Reports;

namespace Avara.Services.AutoScribe;

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
    public async Task<ReportListResponse> List(
        ReportListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ReportAddendumResponse> Addendum(
        ReportAddendumParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Addendum(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ReportAddendumResponse> Addendum(
        string reportID,
        ReportAddendumParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Addendum(parameters with { ReportID = reportID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ReportCancelAddendumResponse> CancelAddendum(
        ReportCancelAddendumParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CancelAddendum(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ReportCancelAddendumResponse> CancelAddendum(
        string reportID,
        ReportCancelAddendumParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CancelAddendum(parameters with { ReportID = reportID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ReportPdfResponse> Pdf(
        ReportPdfParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Pdf(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ReportTextResponse> Text(
        ReportTextParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Text(parameters, cancellationToken)
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
    public async Task<HttpResponse<ReportListResponse>> List(
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
                var reports = await response
                    .Deserialize<ReportListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    reports.Validate();
                }
                return reports;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ReportAddendumResponse>> Addendum(
        ReportAddendumParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ReportID == null)
        {
            throw new AvaraInvalidDataException("'parameters.ReportID' cannot be null");
        }

        HttpRequest<ReportAddendumParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<ReportAddendumResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ReportAddendumResponse>> Addendum(
        string reportID,
        ReportAddendumParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Addendum(parameters with { ReportID = reportID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ReportCancelAddendumResponse>> CancelAddendum(
        ReportCancelAddendumParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ReportID == null)
        {
            throw new AvaraInvalidDataException("'parameters.ReportID' cannot be null");
        }

        HttpRequest<ReportCancelAddendumParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<ReportCancelAddendumResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ReportCancelAddendumResponse>> CancelAddendum(
        string reportID,
        ReportCancelAddendumParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CancelAddendum(parameters with { ReportID = reportID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ReportPdfResponse>> Pdf(
        ReportPdfParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ReportPdfParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<ReportPdfResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ReportTextResponse>> Text(
        ReportTextParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ReportTextParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<ReportTextResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
