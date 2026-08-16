using System;
using System.Threading;
using System.Threading.Tasks;
using Avara.Core;
using Avara.Models.AutoScribe.Studies;
using Avara.Services.AutoScribe.Studies;

namespace Avara.Services.AutoScribe;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IStudyService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IStudyServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IStudyService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IExternalService External { get; }

    /// <summary>
    /// Creates a new study in the AutoScribe system with DICOM metadata and report
    /// generation information. The study can include patient demographics, scan
    /// details, clinical context (indication, history, technologist technique/notes),
    /// an imaging modality, an external patient identifier for linking studies, and
    /// external prior reports for comparison context.
    /// </summary>
    Task<StudyCreateResponse> Create(
        StudyCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a single study by its unique study ID. Returns the complete study
    /// object with all metadata, report status, and patient information.
    /// </summary>
    Task<StudyRetrieveResponse> Retrieve(
        StudyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(StudyRetrieveParams, CancellationToken)"/>
    Task<StudyRetrieveResponse> Retrieve(
        string studyID,
        StudyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a study's properties including description, severity, assignment,
    /// organization, metadata, and report metadata. All fields are optional - only
    /// provided fields will be updated.
    /// </summary>
    Task<StudyUpdateResponse> Update(
        StudyUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(StudyUpdateParams, CancellationToken)"/>
    Task<StudyUpdateResponse> Update(
        string studyID,
        StudyUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a paginated list of studies with optional filtering by assignment,
    /// severity, description, cancellation status, and report status. Returns up to 100
    /// studies per request.
    /// </summary>
    Task<StudyListPage> List(
        StudyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Marks a study as cancelled. Cancelled studies are preserved but flagged as
    /// inactive. Can be identified by either study ID or DICOM Study Instance UID.
    /// </summary>
    Task<StudyCancelResponse> Cancel(
        StudyCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Generates a tokenized URL that redirects users to the AutoScribe interface
    /// (viewer + dictation) for the specified study and user. The URL includes
    /// authentication and is time-limited for security.
    /// </summary>
    Task<StudyRerouteUrlResponse> RerouteUrl(
        StudyRerouteUrlParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a single study by its DICOM Study Instance UID. This is useful when
    /// you have the DICOM UID but not the Avara study ID.
    /// </summary>
    Task<StudyRetrieveByUidResponse> RetrieveByUid(
        StudyRetrieveByUidParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveByUid(StudyRetrieveByUidParams, CancellationToken)"/>
    Task<StudyRetrieveByUidResponse> RetrieveByUid(
        string studyInstanceUid,
        StudyRetrieveByUidParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Restores a cancelled study to active status. The study must have been previously
    /// cancelled. Can be identified by either study ID or DICOM Study Instance UID.
    /// </summary>
    Task<StudyUncancelResponse> Uncancel(
        StudyUncancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Generates a tokenized URL that redirects users to the viewer interface only (no
    /// dictation) for the specified study. Useful for read-only access or referring
    /// physicians. The URL includes authentication and is time-limited.
    /// </summary>
    Task<StudyViewerOnlyRerouteUrlResponse> ViewerOnlyRerouteUrl(
        StudyViewerOnlyRerouteUrlParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IStudyService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IStudyServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IStudyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IExternalServiceWithRawResponse External { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/autoScribe/studies</c>, but is otherwise the
    /// same as <see cref="IStudyService.Create(StudyCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<StudyCreateResponse>> Create(
        StudyCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/autoScribe/studies/{studyId}</c>, but is otherwise the
    /// same as <see cref="IStudyService.Retrieve(StudyRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<StudyRetrieveResponse>> Retrieve(
        StudyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(StudyRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<StudyRetrieveResponse>> Retrieve(
        string studyID,
        StudyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v1/autoScribe/studies/{studyId}</c>, but is otherwise the
    /// same as <see cref="IStudyService.Update(StudyUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<StudyUpdateResponse>> Update(
        StudyUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(StudyUpdateParams, CancellationToken)"/>
    Task<HttpResponse<StudyUpdateResponse>> Update(
        string studyID,
        StudyUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/autoScribe/studies</c>, but is otherwise the
    /// same as <see cref="IStudyService.List(StudyListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<StudyListPage>> List(
        StudyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/autoScribe/studies/cancel</c>, but is otherwise the
    /// same as <see cref="IStudyService.Cancel(StudyCancelParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<StudyCancelResponse>> Cancel(
        StudyCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/autoScribe/studies/reroute-url</c>, but is otherwise the
    /// same as <see cref="IStudyService.RerouteUrl(StudyRerouteUrlParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<StudyRerouteUrlResponse>> RerouteUrl(
        StudyRerouteUrlParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/autoScribe/studies/by-uid/{studyInstanceUid}</c>, but is otherwise the
    /// same as <see cref="IStudyService.RetrieveByUid(StudyRetrieveByUidParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<StudyRetrieveByUidResponse>> RetrieveByUid(
        StudyRetrieveByUidParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveByUid(StudyRetrieveByUidParams, CancellationToken)"/>
    Task<HttpResponse<StudyRetrieveByUidResponse>> RetrieveByUid(
        string studyInstanceUid,
        StudyRetrieveByUidParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/autoScribe/studies/uncancel</c>, but is otherwise the
    /// same as <see cref="IStudyService.Uncancel(StudyUncancelParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<StudyUncancelResponse>> Uncancel(
        StudyUncancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/autoScribe/studies/viewer-only-reroute-url</c>, but is otherwise the
    /// same as <see cref="IStudyService.ViewerOnlyRerouteUrl(StudyViewerOnlyRerouteUrlParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<StudyViewerOnlyRerouteUrlResponse>> ViewerOnlyRerouteUrl(
        StudyViewerOnlyRerouteUrlParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
