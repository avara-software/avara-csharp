using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Avara.Core;
using Avara.Exceptions;
using Avara.Services.AutoScribe;

namespace Avara.Models.AutoScribe.Studies;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IStudyService.List(StudyListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class StudyListPage(
    IStudyServiceWithRawResponse service,
    StudyListParams parameters,
    StudyListPageResponse response
) : IPage<StudyListResponse>
{
    /// <inheritdoc/>
    public IReadOnlyList<StudyListResponse> Items
    {
        get { return response.Studies; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        try
        {
            return this.Items.Count > 0 && response.Cursor != null;
        }
        catch (AvaraInvalidDataException)
        {
            // If accessing the response data to determine if there's a next page failed, then just
            // assume there's no next page.
            return false;
        }
    }

    /// <inheritdoc/>
    async Task<IPage<StudyListResponse>> IPage<StudyListResponse>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<StudyListPage> Next(CancellationToken cancellationToken = default)
    {
        var nextCursor =
            response.Cursor ?? throw new InvalidOperationException("Cannot request next page");
        using var nextResponse = await service
            .List(parameters with { Cursor = nextCursor }, cancellationToken)
            .ConfigureAwait(false);
        return await nextResponse.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public void Validate()
    {
        response.Validate();
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this.Items)),
            ModelBase.ToStringSerializerOptions
        );

    public override bool Equals(object? obj)
    {
        if (obj is not StudyListPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}
