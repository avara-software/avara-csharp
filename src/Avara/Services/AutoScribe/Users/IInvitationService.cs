using System;
using System.Threading;
using System.Threading.Tasks;
using Avara.Core;
using Avara.Models.AutoScribe.Users.Invitations;

namespace Avara.Services.AutoScribe.Users;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IInvitationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInvitationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInvitationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieves a single invitation by its unique invitation ID. Returns the complete
    /// invitation details including status, expiration, associated user information,
    /// and AutoScribe-specific permissions.
    /// </summary>
    Task<InvitationRetrieveResponse> Retrieve(
        InvitationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(InvitationRetrieveParams, CancellationToken)"/>
    Task<InvitationRetrieveResponse> Retrieve(
        string invitationID,
        InvitationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a pending invitation's user details, permissions, and AutoScribe-specific
    /// settings before it is accepted. Only valid for invitations that have not expired
    /// or been processed. NPI number is required if enabling report creation.
    /// </summary>
    Task<InvitationUpdateResponse> Update(
        InvitationUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(InvitationUpdateParams, CancellationToken)"/>
    Task<InvitationUpdateResponse> Update(
        string invitationID,
        InvitationUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a paginated list of user invitations with optional filtering by
    /// status, expiration, date range, and user ID. Returns up to 100 invitations
    /// per request.
    /// </summary>
    Task<InvitationListPage> List(
        InvitationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Revokes a pending invitation, preventing it from being accepted. Can revoke
    /// by invitation ID, user ID, or both. Useful for cancelling invitations sent
    /// in error.
    /// </summary>
    Task<InvitationRevokeResponse> Revoke(
        InvitationRevokeParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IInvitationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInvitationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInvitationServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /v1/autoScribe/users/invitations/{invitationId}`, but is otherwise the
    /// same as <see cref="IInvitationService.Retrieve(InvitationRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InvitationRetrieveResponse>> Retrieve(
        InvitationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(InvitationRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<InvitationRetrieveResponse>> Retrieve(
        string invitationID,
        InvitationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `patch /v1/autoScribe/users/invitations/{invitationId}`, but is otherwise the
    /// same as <see cref="IInvitationService.Update(InvitationUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InvitationUpdateResponse>> Update(
        InvitationUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(InvitationUpdateParams, CancellationToken)"/>
    Task<HttpResponse<InvitationUpdateResponse>> Update(
        string invitationID,
        InvitationUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /v1/autoScribe/users/invitations`, but is otherwise the
    /// same as <see cref="IInvitationService.List(InvitationListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InvitationListPage>> List(
        InvitationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /v1/autoScribe/users/invitations/revoke`, but is otherwise the
    /// same as <see cref="IInvitationService.Revoke(InvitationRevokeParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InvitationRevokeResponse>> Revoke(
        InvitationRevokeParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
