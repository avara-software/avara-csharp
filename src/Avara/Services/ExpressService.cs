using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Avara.Core;
using Avara.Exceptions;
using Avara.Models.Express;
using Avara.Services.Express;

namespace Avara.Services;

/// <inheritdoc/>
public sealed class ExpressService : IExpressService
{
    readonly Lazy<IExpressServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IExpressServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAvaraClient _client;

    /// <inheritdoc/>
    public IExpressService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ExpressService(this._client.WithOptions(modifier));
    }

    public ExpressService(IAvaraClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ExpressServiceWithRawResponse(client.WithRawResponse));
        _users = new(() => new UserService(client));
    }

    readonly Lazy<IUserService> _users;
    public IUserService Users
    {
        get { return _users.Value; }
    }

    /// <inheritdoc/>
    public async Task<ExpressCreateResponse> Create(
        ExpressCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ExpressRetrieveResponse> Retrieve(
        ExpressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ExpressRetrieveResponse> Retrieve(
        string expressCustomerID,
        ExpressRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                ExpressCustomerID = expressCustomerID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<ExpressUpdateResponse> Update(
        ExpressUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ExpressUpdateResponse> Update(
        string expressCustomerID,
        ExpressUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(
            parameters with
            {
                ExpressCustomerID = expressCustomerID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<ExpressListPage> List(
        ExpressListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ExpressDeactivateResponse> Deactivate(
        ExpressDeactivateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Deactivate(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ExpressDeactivateResponse> Deactivate(
        string expressCustomerID,
        ExpressDeactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Deactivate(
            parameters with
            {
                ExpressCustomerID = expressCustomerID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<ExpressReactivateResponse> Reactivate(
        ExpressReactivateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Reactivate(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ExpressReactivateResponse> Reactivate(
        string expressCustomerID,
        ExpressReactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Reactivate(
            parameters with
            {
                ExpressCustomerID = expressCustomerID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class ExpressServiceWithRawResponse : IExpressServiceWithRawResponse
{
    readonly IAvaraClientWithRawResponse _client;

    /// <inheritdoc/>
    public IExpressServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ExpressServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ExpressServiceWithRawResponse(IAvaraClientWithRawResponse client)
    {
        _client = client;

        _users = new(() => new UserServiceWithRawResponse(client));
    }

    readonly Lazy<IUserServiceWithRawResponse> _users;
    public IUserServiceWithRawResponse Users
    {
        get { return _users.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExpressCreateResponse>> Create(
        ExpressCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExpressCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var express = await response
                    .Deserialize<ExpressCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    express.Validate();
                }
                return express;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExpressRetrieveResponse>> Retrieve(
        ExpressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExpressCustomerID == null)
        {
            throw new AvaraInvalidDataException("'parameters.ExpressCustomerID' cannot be null");
        }

        HttpRequest<ExpressRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var express = await response
                    .Deserialize<ExpressRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    express.Validate();
                }
                return express;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ExpressRetrieveResponse>> Retrieve(
        string expressCustomerID,
        ExpressRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                ExpressCustomerID = expressCustomerID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExpressUpdateResponse>> Update(
        ExpressUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExpressCustomerID == null)
        {
            throw new AvaraInvalidDataException("'parameters.ExpressCustomerID' cannot be null");
        }

        HttpRequest<ExpressUpdateParams> request = new()
        {
            Method = AvaraClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var express = await response
                    .Deserialize<ExpressUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    express.Validate();
                }
                return express;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ExpressUpdateResponse>> Update(
        string expressCustomerID,
        ExpressUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(
            parameters with
            {
                ExpressCustomerID = expressCustomerID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExpressListPage>> List(
        ExpressListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ExpressListParams> request = new()
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
                    .Deserialize<ExpressListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ExpressListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExpressDeactivateResponse>> Deactivate(
        ExpressDeactivateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExpressCustomerID == null)
        {
            throw new AvaraInvalidDataException("'parameters.ExpressCustomerID' cannot be null");
        }

        HttpRequest<ExpressDeactivateParams> request = new()
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
                    .Deserialize<ExpressDeactivateResponse>(token)
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
    public Task<HttpResponse<ExpressDeactivateResponse>> Deactivate(
        string expressCustomerID,
        ExpressDeactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Deactivate(
            parameters with
            {
                ExpressCustomerID = expressCustomerID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExpressReactivateResponse>> Reactivate(
        ExpressReactivateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExpressCustomerID == null)
        {
            throw new AvaraInvalidDataException("'parameters.ExpressCustomerID' cannot be null");
        }

        HttpRequest<ExpressReactivateParams> request = new()
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
                    .Deserialize<ExpressReactivateResponse>(token)
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
    public Task<HttpResponse<ExpressReactivateResponse>> Reactivate(
        string expressCustomerID,
        ExpressReactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Reactivate(
            parameters with
            {
                ExpressCustomerID = expressCustomerID,
            },
            cancellationToken
        );
    }
}
