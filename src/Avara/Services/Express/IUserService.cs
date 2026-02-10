using System;
using System.Threading;
using System.Threading.Tasks;
using Avara.Core;
using Avara.Models.Express.Users;

namespace Avara.Services.Express;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IUserServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Associates an existing user with a customer, granting them access to customer-specific
    /// resources and studies.
    /// </summary>
    Task<UserAddResponse> Add(
        UserAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Add(UserAddParams, CancellationToken)"/>
    Task<UserAddResponse> Add(
        string expressCustomerID,
        UserAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Removes a user's association with a customer, revoking their access to customer-specific
    /// resources. The user account remains active but is no longer linked to this customer.
    /// </summary>
    Task<UserRemoveResponse> Remove(
        UserRemoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Remove(UserRemoveParams, CancellationToken)"/>
    Task<UserRemoveResponse> Remove(
        string expressCustomerID,
        UserRemoveParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IUserService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IUserServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /v1/express/{expressCustomerId}/users`, but is otherwise the
    /// same as <see cref="IUserService.Add(UserAddParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserAddResponse>> Add(
        UserAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Add(UserAddParams, CancellationToken)"/>
    Task<HttpResponse<UserAddResponse>> Add(
        string expressCustomerID,
        UserAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /v1/express/{expressCustomerId}/users`, but is otherwise the
    /// same as <see cref="IUserService.Remove(UserRemoveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserRemoveResponse>> Remove(
        UserRemoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Remove(UserRemoveParams, CancellationToken)"/>
    Task<HttpResponse<UserRemoveResponse>> Remove(
        string expressCustomerID,
        UserRemoveParams parameters,
        CancellationToken cancellationToken = default
    );
}
