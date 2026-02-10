using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Avara.Core;
using Avara.Exceptions;
using Avara.Models.Express.Users;

namespace Avara.Services.Express;

/// <inheritdoc/>
public sealed class UserService : IUserService
{
    readonly Lazy<IUserServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IUserServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAvaraClient _client;

    /// <inheritdoc/>
    public IUserService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UserService(this._client.WithOptions(modifier));
    }

    public UserService(IAvaraClient client)
    {
        _client = client;

        _withRawResponse = new(() => new UserServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<UserAddResponse> Add(
        UserAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Add(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<UserAddResponse> Add(
        string expressCustomerID,
        UserAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Add(
            parameters with
            {
                ExpressCustomerID = expressCustomerID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<UserRemoveResponse> Remove(
        UserRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Remove(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<UserRemoveResponse> Remove(
        string expressCustomerID,
        UserRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Remove(
            parameters with
            {
                ExpressCustomerID = expressCustomerID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class UserServiceWithRawResponse : IUserServiceWithRawResponse
{
    readonly IAvaraClientWithRawResponse _client;

    /// <inheritdoc/>
    public IUserServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UserServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public UserServiceWithRawResponse(IAvaraClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserAddResponse>> Add(
        UserAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExpressCustomerID == null)
        {
            throw new AvaraInvalidDataException("'parameters.ExpressCustomerID' cannot be null");
        }

        HttpRequest<UserAddParams> request = new()
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
                    .Deserialize<UserAddResponse>(token)
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
    public Task<HttpResponse<UserAddResponse>> Add(
        string expressCustomerID,
        UserAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Add(
            parameters with
            {
                ExpressCustomerID = expressCustomerID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserRemoveResponse>> Remove(
        UserRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExpressCustomerID == null)
        {
            throw new AvaraInvalidDataException("'parameters.ExpressCustomerID' cannot be null");
        }

        HttpRequest<UserRemoveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var user = await response
                    .Deserialize<UserRemoveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    user.Validate();
                }
                return user;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<UserRemoveResponse>> Remove(
        string expressCustomerID,
        UserRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Remove(
            parameters with
            {
                ExpressCustomerID = expressCustomerID,
            },
            cancellationToken
        );
    }
}
