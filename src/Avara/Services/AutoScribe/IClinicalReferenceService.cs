using System;
using System.Threading;
using System.Threading.Tasks;
using Avara.Core;
using Avara.Models.AutoScribe.ClinicalReferences;

namespace Avara.Services.AutoScribe;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IClinicalReferenceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IClinicalReferenceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IClinicalReferenceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a canonical clinical reference value for study workflow pickers and
    /// normalization.
    /// </summary>
    Task<ClinicalReference> Create(
        ClinicalReferenceCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a single clinical reference by its unique identifier.
    /// </summary>
    Task<ClinicalReference> Retrieve(
        ClinicalReferenceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ClinicalReferenceRetrieveParams, CancellationToken)"/>
    Task<ClinicalReference> Retrieve(
        string clinicalReferenceID,
        ClinicalReferenceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates name, metadata, and Express customer assignment. Type is immutable after
    /// create.
    /// </summary>
    Task<ClinicalReference> Update(
        ClinicalReferenceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ClinicalReferenceUpdateParams, CancellationToken)"/>
    Task<ClinicalReference> Update(
        string clinicalReferenceID,
        ClinicalReferenceUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists clinical references with cursor-based pagination and optional filters.
    /// </summary>
    Task<ClinicalReferenceListPage> List(
        ClinicalReferenceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Soft-deletes a clinical reference by setting isActive to false and suffixing the
    /// name to free the unique constraint.
    /// </summary>
    Task<ClinicalReference> Delete(
        ClinicalReferenceDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ClinicalReferenceDeleteParams, CancellationToken)"/>
    Task<ClinicalReference> Delete(
        string clinicalReferenceID,
        ClinicalReferenceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a single clinical reference by its integrator-provided external
    /// reference identifier.
    /// </summary>
    Task<ClinicalReference> RetrieveByExternalReferenceID(
        ClinicalReferenceRetrieveByExternalReferenceIDParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveByExternalReferenceID(ClinicalReferenceRetrieveByExternalReferenceIDParams, CancellationToken)"/>
    Task<ClinicalReference> RetrieveByExternalReferenceID(
        string externalReferenceID,
        ClinicalReferenceRetrieveByExternalReferenceIDParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IClinicalReferenceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IClinicalReferenceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IClinicalReferenceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/autoScribe/clinicalReferences</c>, but is otherwise the
    /// same as <see cref="IClinicalReferenceService.Create(ClinicalReferenceCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ClinicalReference>> Create(
        ClinicalReferenceCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/autoScribe/clinicalReferences/{clinicalReferenceId}</c>, but is otherwise the
    /// same as <see cref="IClinicalReferenceService.Retrieve(ClinicalReferenceRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ClinicalReference>> Retrieve(
        ClinicalReferenceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ClinicalReferenceRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ClinicalReference>> Retrieve(
        string clinicalReferenceID,
        ClinicalReferenceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v1/autoScribe/clinicalReferences/{clinicalReferenceId}</c>, but is otherwise the
    /// same as <see cref="IClinicalReferenceService.Update(ClinicalReferenceUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ClinicalReference>> Update(
        ClinicalReferenceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ClinicalReferenceUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ClinicalReference>> Update(
        string clinicalReferenceID,
        ClinicalReferenceUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/autoScribe/clinicalReferences</c>, but is otherwise the
    /// same as <see cref="IClinicalReferenceService.List(ClinicalReferenceListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ClinicalReferenceListPage>> List(
        ClinicalReferenceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/autoScribe/clinicalReferences/{clinicalReferenceId}/delete</c>, but is otherwise the
    /// same as <see cref="IClinicalReferenceService.Delete(ClinicalReferenceDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ClinicalReference>> Delete(
        ClinicalReferenceDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ClinicalReferenceDeleteParams, CancellationToken)"/>
    Task<HttpResponse<ClinicalReference>> Delete(
        string clinicalReferenceID,
        ClinicalReferenceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/autoScribe/clinicalReferences/byExternalReferenceId/{externalReferenceId}</c>, but is otherwise the
    /// same as <see cref="IClinicalReferenceService.RetrieveByExternalReferenceID(ClinicalReferenceRetrieveByExternalReferenceIDParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ClinicalReference>> RetrieveByExternalReferenceID(
        ClinicalReferenceRetrieveByExternalReferenceIDParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveByExternalReferenceID(ClinicalReferenceRetrieveByExternalReferenceIDParams, CancellationToken)"/>
    Task<HttpResponse<ClinicalReference>> RetrieveByExternalReferenceID(
        string externalReferenceID,
        ClinicalReferenceRetrieveByExternalReferenceIDParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
