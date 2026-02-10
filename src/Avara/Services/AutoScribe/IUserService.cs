using System;
using System.Threading;
using System.Threading.Tasks;
using Avara.Core;
using Avara.Models.AutoScribe.Users;
using Avara.Services.AutoScribe.Users;

namespace Avara.Services.AutoScribe;

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
    /// object with all profile information, permissions, AutoScribe-specific settings,
    /// and status.
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
    /// Updates a user's profile information, permissions, and AutoScribe-specific
    /// settings. All fields are optional - only provided fields will be updated.
    /// Email cannot be changed via API. NPI number is required if enabling report
    /// creation capability.
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
    /// email, name, invitation source, and report creation capability. Returns up
    /// to 100 users per request.
    /// </summary>
    Task<UserListPage> List(
        UserListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new user in the AutoScribe system and sends them an invitation email.
    /// The user will have the specified permissions including report creation and
    /// study management capabilities. NPI number is required for users who can create reports.
    /// </summary>
    Task<UserInviteResponse> Invite(
        UserInviteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Restores access for a previously deactivated user. The user will regain their
    /// original permissions including report creation and study management capabilities.
    /// </summary>
    Task<UserReactivateResponse> Reactivate(
        UserReactivateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deactivates a user's access to the system. The user will no longer be able
    /// to log in, create reports, or access studies. User data is preserved and can
    /// be reactivated later.
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
    /// Returns a raw HTTP response for `get /v1/autoScribe/users/{userId}`, but is otherwise the
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
    /// Returns a raw HTTP response for `patch /v1/autoScribe/users/{userId}`, but is otherwise the
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
    /// Returns a raw HTTP response for `get /v1/autoScribe/users`, but is otherwise the
    /// same as <see cref="IUserService.List(UserListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserListPage>> List(
        UserListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /v1/autoScribe/users`, but is otherwise the
    /// same as <see cref="IUserService.Invite(UserInviteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserInviteResponse>> Invite(
        UserInviteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /v1/autoScribe/users/reactivate`, but is otherwise the
    /// same as <see cref="IUserService.Reactivate(UserReactivateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserReactivateResponse>> Reactivate(
        UserReactivateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /v1/autoScribe/users/revoke-access`, but is otherwise the
    /// same as <see cref="IUserService.RevokeAccess(UserRevokeAccessParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserRevokeAccessResponse>> RevokeAccess(
        UserRevokeAccessParams parameters,
        CancellationToken cancellationToken = default
    );
}
