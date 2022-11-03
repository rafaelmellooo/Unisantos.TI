using Microsoft.EntityFrameworkCore;
using Unisantos.TI.Domain.DTO;

namespace Unisantos.TI.Core.Helpers;

public static class PaginationHelpers
{
    public static async Task<PaginatedResponseDTO<T[]>> Paginate<T>(this IQueryable<T> query, int page, int perPage,
        CancellationToken cancellationToken = default) where T : class
    {
        var total = await query.CountAsync(cancellationToken);

        var entriesToSkip = (page - 1) * perPage;

        var hasNextPage = total > entriesToSkip + perPage;

        var hasPreviousPage = page > 1;

        var pageCount = (int) Math.Ceiling((decimal) total / perPage);

        var data = await query.Skip(entriesToSkip).Take(perPage).AsNoTracking().ToArrayAsync(cancellationToken);

        return new PaginatedResponseDTO<T[]>
        {
            Data = data,
            Total = total,
            CurrentPage = page,
            NextPage = hasNextPage ? page + 1 : null,
            PreviousPage = hasPreviousPage ? page - 1 : null,
            PageCount = pageCount,
            PerPage = perPage,
            HasNextPage = hasNextPage,
            HasPreviousPage = hasPreviousPage
        };
    }
}