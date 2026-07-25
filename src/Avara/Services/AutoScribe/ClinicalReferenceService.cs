using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Avara.Core;
using Avara.Exceptions;
using Avara.Models.AutoScribe.ClinicalReferences;

namespace Avara.Services.AutoScribe;

/// <inheritdoc/>
public sealed class ClinicalReferenceService : IClinicalReferenceService
{
    readonly Lazy<IClinicalReferenceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IClinicalReferenceServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAvaraClient _client;

    /// <inheritdoc/>
    public IClinicalReferenceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ClinicalReferenceService(this._client.WithOptions(modifier));
    }

    public ClinicalReferenceService(IAvaraClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new ClinicalReferenceServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<ClinicalReference> Create(
        ClinicalReferenceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ClinicalReference> Retrieve(
        ClinicalReferenceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ClinicalReference> Retrieve(
        string clinicalReferenceID,
        ClinicalReferenceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                ClinicalReferenceID = clinicalReferenceID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<ClinicalReference> Update(
        ClinicalReferenceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ClinicalReference> Update(
        string clinicalReferenceID,
        ClinicalReferenceUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(
            parameters with
            {
                ClinicalReferenceID = clinicalReferenceID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<ClinicalReferenceListPage> List(
        ClinicalReferenceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ClinicalReference> Delete(
        ClinicalReferenceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ClinicalReference> Delete(
        string clinicalReferenceID,
        ClinicalReferenceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(
            parameters with
            {
                ClinicalReferenceID = clinicalReferenceID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<ClinicalReference> RetrieveByExternalReferenceID(
        ClinicalReferenceRetrieveByExternalReferenceIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveByExternalReferenceID(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ClinicalReference> RetrieveByExternalReferenceID(
        string externalReferenceID,
        ClinicalReferenceRetrieveByExternalReferenceIDParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveByExternalReferenceID(
            parameters with
            {
                ExternalReferenceID = externalReferenceID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class ClinicalReferenceServiceWithRawResponse
    : IClinicalReferenceServiceWithRawResponse
{
    readonly IAvaraClientWithRawResponse _client;

    /// <inheritdoc/>
    public IClinicalReferenceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ClinicalReferenceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ClinicalReferenceServiceWithRawResponse(IAvaraClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ClinicalReference>> Create(
        ClinicalReferenceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ClinicalReferenceCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var clinicalReference = await response
                    .Deserialize<ClinicalReference>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    clinicalReference.Validate();
                }
                return clinicalReference;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ClinicalReference>> Retrieve(
        ClinicalReferenceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ClinicalReferenceID == null)
        {
            throw new AvaraInvalidDataException("'parameters.ClinicalReferenceID' cannot be null");
        }

        HttpRequest<ClinicalReferenceRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var clinicalReference = await response
                    .Deserialize<ClinicalReference>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    clinicalReference.Validate();
                }
                return clinicalReference;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ClinicalReference>> Retrieve(
        string clinicalReferenceID,
        ClinicalReferenceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                ClinicalReferenceID = clinicalReferenceID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ClinicalReference>> Update(
        ClinicalReferenceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ClinicalReferenceID == null)
        {
            throw new AvaraInvalidDataException("'parameters.ClinicalReferenceID' cannot be null");
        }

        HttpRequest<ClinicalReferenceUpdateParams> request = new()
        {
            Method = AvaraClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var clinicalReference = await response
                    .Deserialize<ClinicalReference>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    clinicalReference.Validate();
                }
                return clinicalReference;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ClinicalReference>> Update(
        string clinicalReferenceID,
        ClinicalReferenceUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(
            parameters with
            {
                ClinicalReferenceID = clinicalReferenceID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ClinicalReferenceListPage>> List(
        ClinicalReferenceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ClinicalReferenceListParams> request = new()
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
                    .Deserialize<ClinicalReferenceListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ClinicalReferenceListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ClinicalReference>> Delete(
        ClinicalReferenceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ClinicalReferenceID == null)
        {
            throw new AvaraInvalidDataException("'parameters.ClinicalReferenceID' cannot be null");
        }

        HttpRequest<ClinicalReferenceDeleteParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var clinicalReference = await response
                    .Deserialize<ClinicalReference>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    clinicalReference.Validate();
                }
                return clinicalReference;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ClinicalReference>> Delete(
        string clinicalReferenceID,
        ClinicalReferenceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(
            parameters with
            {
                ClinicalReferenceID = clinicalReferenceID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ClinicalReference>> RetrieveByExternalReferenceID(
        ClinicalReferenceRetrieveByExternalReferenceIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExternalReferenceID == null)
        {
            throw new AvaraInvalidDataException("'parameters.ExternalReferenceID' cannot be null");
        }

        HttpRequest<ClinicalReferenceRetrieveByExternalReferenceIDParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var clinicalReference = await response
                    .Deserialize<ClinicalReference>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    clinicalReference.Validate();
                }
                return clinicalReference;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ClinicalReference>> RetrieveByExternalReferenceID(
        string externalReferenceID,
        ClinicalReferenceRetrieveByExternalReferenceIDParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveByExternalReferenceID(
            parameters with
            {
                ExternalReferenceID = externalReferenceID,
            },
            cancellationToken
        );
    }
}
