namespace Unisantos.TI.Domain.DTO;

public record PaginatedResponseDTO<TData>
{
    public required TData Data { get; set; }

    public int Total { get; set; }

    public int PerPage { get; set; }

    public int PageCount { get; set; }

    public int CurrentPage { get; set; }

    public int? NextPage { get; set; }

    public int? PreviousPage { get; set; }

    public bool HasNextPage { get; set; }

    public bool HasPreviousPage { get; set; }
}