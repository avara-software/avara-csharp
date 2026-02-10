using System;
using System.Threading;
using System.Threading.Tasks;
using Avara.Core;
using Avara.Models.Viewer.Users;
using Avara.Services.Viewer.Users;

namespace Avara.Services.Viewer;

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

    IInvitationService Invitations { get; }

    /// <summary>
    /// Retrieves a single user by their unique user ID. Returns the complete user
    /// object with all profile information, permissions, and status.
    /// </summary>
    Task<UserRetrieveResponse> Retrieve(
        UserRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(UserRetrieveParams, CancellationToken)"/>
    Task<UserRetrieveResponse> Retrieve(
        string userID,
        UserRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a user's profile information, permissions, and access level. All
    /// fields are optional - only provided fields will be updated. Email cannot
    /// be changed via API.
    /// </summary>
    Task<UserUpdateResponse> Update(
        UserUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(UserUpdateParams, CancellationToken)"/>
    Task<UserUpdateResponse> Update(
        string userID,
        UserUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a paginated list of users with optional filtering by access level,
    /// email, name, and invitation source. Returns up to 100 users per request.
    /// </summary>
    Task<UserListPage> List(
        UserListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new user in the Viewer system and sends them an invitation email.
    /// The user will have the specified permissions and access level. Dashboard access
    /// can be enabled to allow login.
    /// </summary>
    Task<UserInviteResponse> Invite(
        UserInviteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Restores access for a previously deactivated user. The user will regain their
    /// original permissions and be able to log in again.
    /// </summary>
    Task<UserReactivateResponse> Reactivate(
        UserReactivateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deactivates a user's access to the system. The user will no longer be able
    /// to log in or access resources. User data is preserved and can be reactivated later.
    /// </summary>
    Task<UserRevokeAccessResponse> RevokeAccess(
        UserRevokeAccessParams parameters,
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

    IInvitationServiceWithRawResponse Invitations { get; }

    /// <summary>
    /// Returns a raw HTTP response for `get /v1/viewer/users/{userId}`, but is otherwise the
    /// same as <see cref="IUserService.Retrieve(UserRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserRetrieveResponse>> Retrieve(
        UserRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(UserRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<UserRetrieveResponse>> Retrieve(
        string userID,
        UserRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `patch /v1/viewer/users/{userId}`, but is otherwise the
    /// same as <see cref="IUserService.Update(UserUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserUpdateResponse>> Update(
        UserUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(UserUpdateParams, CancellationToken)"/>
    Task<HttpResponse<UserUpdateResponse>> Update(
        string userID,
        UserUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /v1/viewer/users`, but is otherwise the
    /// same as <see cref="IUserService.List(UserListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserListPage>> List(
        UserListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /v1/viewer/users`, but is otherwise the
    /// same as <see cref="IUserService.Invite(UserInviteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserInviteResponse>> Invite(
        UserInviteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /v1/viewer/users/reactivate`, but is otherwise the
    /// same as <see cref="IUserService.Reactivate(UserReactivateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserReactivateResponse>> Reactivate(
        UserReactivateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /v1/viewer/users/revoke-access`, but is otherwise the
    /// same as <see cref="IUserService.RevokeAccess(UserRevokeAccessParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserRevokeAccessResponse>> RevokeAccess(
        UserRevokeAccessParams parameters,
        CancellationToken cancellationToken = default
    );
}
