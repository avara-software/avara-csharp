using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Avara.Core;
using Avara.Exceptions;
using Avara.Services.AutoScribe.Studies.External;

namespace Avara.Models.AutoScribe.Studies.External.Reports;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IReportService.List(ReportListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class ReportListPage(
    IReportServiceWithRawResponse service,
    ReportListParams parameters,
    ReportListPageResponse response
) : IPage<ReportListResponse>
{
    /// <inheritdoc/>
    public IReadOnlyList<ReportListResponse> Items
    {
        get { return response.Reports; }
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
    async Task<IPage<ReportListResponse>> IPage<ReportListResponse>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<ReportListPage> Next(CancellationToken cancellationToken = default)
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
        if (obj is not ReportListPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}
