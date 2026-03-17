using System;
using System.Threading;
using System.Threading.Tasks;
using Avara.Core;
using Avara.Models.Express;
using Avara.Services.Express;

namespace Avara.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IExpressService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IExpressServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExpressService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IUserService Users { get; }

    /// <summary>
    /// Creates a new customer with a unique identifier and name. Customers can be used
    /// to group and manage users, studies, and access permissions across the Avara
    /// platform.
    /// </summary>
    Task<ExpressCreateResponse> Create(
        ExpressCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a single customer by its unique customer ID. Returns the complete
    /// customer object with name, status, and timestamps.
    /// </summary>
    Task<ExpressRetrieveResponse> Retrieve(
        ExpressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ExpressRetrieveParams, CancellationToken)"/>
    Task<ExpressRetrieveResponse> Retrieve(
        string expressCustomerID,
        ExpressRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a customer's properties such as name or other metadata. All fields are
    /// optional - only provided fields will be updated.
    /// </summary>
    Task<ExpressUpdateResponse> Update(
        ExpressUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ExpressUpdateParams, CancellationToken)"/>
    Task<ExpressUpdateResponse> Update(
        string expressCustomerID,
        ExpressUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a paginated list of customers with optional filtering by name. Returns
    /// up to 100 customers per request.
    /// </summary>
    Task<ExpressListPage> List(
        ExpressListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deactivates a customer, preventing it from being used for new studies or user
    /// assignments. Existing data is preserved and the customer can be reactivated
    /// later.
    /// </summary>
    Task<ExpressDeactivateResponse> Deactivate(
        ExpressDeactivateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Deactivate(ExpressDeactivateParams, CancellationToken)"/>
    Task<ExpressDeactivateResponse> Deactivate(
        string expressCustomerID,
        ExpressDeactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Restores a deactivated customer to active status, allowing it to be used for new
    /// studies and user assignments again.
    /// </summary>
    Task<ExpressReactivateResponse> Reactivate(
        ExpressReactivateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Reactivate(ExpressReactivateParams, CancellationToken)"/>
    Task<ExpressReactivateResponse> Reactivate(
        string expressCustomerID,
        ExpressReactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IExpressService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IExpressServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExpressServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IUserServiceWithRawResponse Users { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/express</c>, but is otherwise the
    /// same as <see cref="IExpressService.Create(ExpressCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExpressCreateResponse>> Create(
        ExpressCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/express/{expressCustomerId}</c>, but is otherwise the
    /// same as <see cref="IExpressService.Retrieve(ExpressRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExpressRetrieveResponse>> Retrieve(
        ExpressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ExpressRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ExpressRetrieveResponse>> Retrieve(
        string expressCustomerID,
        ExpressRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v1/express/{expressCustomerId}</c>, but is otherwise the
    /// same as <see cref="IExpressService.Update(ExpressUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExpressUpdateResponse>> Update(
        ExpressUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ExpressUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ExpressUpdateResponse>> Update(
        string expressCustomerID,
        ExpressUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/express</c>, but is otherwise the
    /// same as <see cref="IExpressService.List(ExpressListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExpressListPage>> List(
        ExpressListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/express/{expressCustomerId}/deactivate</c>, but is otherwise the
    /// same as <see cref="IExpressService.Deactivate(ExpressDeactivateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExpressDeactivateResponse>> Deactivate(
        ExpressDeactivateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Deactivate(ExpressDeactivateParams, CancellationToken)"/>
    Task<HttpResponse<ExpressDeactivateResponse>> Deactivate(
        string expressCustomerID,
        ExpressDeactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/express/{expressCustomerId}/reactivate</c>, but is otherwise the
    /// same as <see cref="IExpressService.Reactivate(ExpressReactivateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExpressReactivateResponse>> Reactivate(
        ExpressReactivateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Reactivate(ExpressReactivateParams, CancellationToken)"/>
    Task<HttpResponse<ExpressReactivateResponse>> Reactivate(
        string expressCustomerID,
        ExpressReactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
