using CleanArchitectureBlazor.Application.Common.Models;

namespace CleanArchitectureBlazor.Application.Common.Extensions;

public static class PaginationExtensions
{
    public static Task<PaginatedList<T>> ToPaginatedListAsync<T>(this IQueryable<T> queryable, int pageNumber, int pageSize) where T : class
        => PaginatedList<T>.CreateAsync(queryable, pageNumber, pageSize);
}
