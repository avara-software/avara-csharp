using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Avara.Core;
using Avara.Exceptions;
using Avara.Services;

namespace Avara.Models.Express;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IExpressService.List(ExpressListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class ExpressListPage(
    IExpressServiceWithRawResponse service,
    ExpressListParams parameters,
    ExpressListPageResponse response
) : IPage<ExpressListResponse>
{
    /// <inheritdoc/>
    public IReadOnlyList<ExpressListResponse> Items
    {
        get { return response.ExpressCustomers; }
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
    async Task<IPage<ExpressListResponse>> IPage<ExpressListResponse>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<ExpressListPage> Next(CancellationToken cancellationToken = default)
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
        if (obj is not ExpressListPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}
