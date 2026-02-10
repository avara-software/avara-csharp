using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Avara.Core;
using Avara.Exceptions;
using Avara.Models.Viewer.Studies;

namespace Avara.Services.Viewer;

/// <inheritdoc/>
public sealed class StudyService : IStudyService
{
    readonly Lazy<IStudyServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IStudyServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAvaraClient _client;

    /// <inheritdoc/>
    public IStudyService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new StudyService(this._client.WithOptions(modifier));
    }

    public StudyService(IAvaraClient client)
    {
        _client = client;

        _withRawResponse = new(() => new StudyServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<StudyCreateResponse> Create(
        StudyCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<StudyRetrieveResponse> Retrieve(
        StudyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<StudyRetrieveResponse> Retrieve(
        string studyID,
        StudyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { StudyID = studyID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<StudyUpdateResponse> Update(
        StudyUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<StudyUpdateResponse> Update(
        string studyID,
        StudyUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { StudyID = studyID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<StudyListPage> List(
        StudyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<StudyCancelResponse> Cancel(
        StudyCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<StudyRerouteUrlResponse> RerouteUrl(
        StudyRerouteUrlParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RerouteUrl(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<StudyRetrieveByUidResponse> RetrieveByUid(
        StudyRetrieveByUidParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveByUid(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<StudyRetrieveByUidResponse> RetrieveByUid(
        string studyInstanceUid,
        StudyRetrieveByUidParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveByUid(
            parameters with
            {
                StudyInstanceUid = studyInstanceUid,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<StudyUncancelResponse> Uncancel(
        StudyUncancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Uncancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class StudyServiceWithRawResponse : IStudyServiceWithRawResponse
{
    readonly IAvaraClientWithRawResponse _client;

    /// <inheritdoc/>
    public IStudyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new StudyServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public StudyServiceWithRawResponse(IAvaraClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<StudyCreateResponse>> Create(
        StudyCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<StudyCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var study = await response
                    .Deserialize<StudyCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    study.Validate();
                }
                return study;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<StudyRetrieveResponse>> Retrieve(
        StudyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.StudyID == null)
        {
            throw new AvaraInvalidDataException("'parameters.StudyID' cannot be null");
        }

        HttpRequest<StudyRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var study = await response
                    .Deserialize<StudyRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    study.Validate();
                }
                return study;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<StudyRetrieveResponse>> Retrieve(
        string studyID,
        StudyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { StudyID = studyID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<StudyUpdateResponse>> Update(
        StudyUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.StudyID == null)
        {
            throw new AvaraInvalidDataException("'parameters.StudyID' cannot be null");
        }

        HttpRequest<StudyUpdateParams> request = new()
        {
            Method = AvaraClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var study = await response
                    .Deserialize<StudyUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    study.Validate();
                }
                return study;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<StudyUpdateResponse>> Update(
        string studyID,
        StudyUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { StudyID = studyID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<StudyListPage>> List(
        StudyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<StudyListParams> request = new()
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
                    .Deserialize<StudyListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new StudyListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<StudyCancelResponse>> Cancel(
        StudyCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<StudyCancelParams> request = new()
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
                    .Deserialize<StudyCancelResponse>(token)
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
    public async Task<HttpResponse<StudyRerouteUrlResponse>> RerouteUrl(
        StudyRerouteUrlParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<StudyRerouteUrlParams> request = new()
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
                    .Deserialize<StudyRerouteUrlResponse>(token)
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
    public async Task<HttpResponse<StudyRetrieveByUidResponse>> RetrieveByUid(
        StudyRetrieveByUidParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.StudyInstanceUid == null)
        {
            throw new AvaraInvalidDataException("'parameters.StudyInstanceUid' cannot be null");
        }

        HttpRequest<StudyRetrieveByUidParams> request = new()
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
                    .Deserialize<StudyRetrieveByUidResponse>(token)
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
    public Task<HttpResponse<StudyRetrieveByUidResponse>> RetrieveByUid(
        string studyInstanceUid,
        StudyRetrieveByUidParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveByUid(
            parameters with
            {
                StudyInstanceUid = studyInstanceUid,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<StudyUncancelResponse>> Uncancel(
        StudyUncancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<StudyUncancelParams> request = new()
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
                    .Deserialize<StudyUncancelResponse>(token)
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
