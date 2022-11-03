using Unisantos.TI.Domain.DTO;

namespace Unisantos.TI.Server.Responses;

public class PaginatedResponse<TData> : SuccessResponse<TData>
{
    public PaginatedResponse(PaginatedResponseDTO<TData> response) : base(response.Data)
    {
        Total = response.Total;
        PerPage = response.PerPage;
        PageCount = response.PageCount;
        CurrentPage = response.CurrentPage;
        NextPage = response.NextPage;
        PreviousPage = response.PreviousPage;
        HasNextPage = response.HasNextPage;
        HasPreviousPage = response.HasPreviousPage;
    }

    public int Total { get; }

    public int PerPage { get; }

    public int PageCount { get; }

    public int CurrentPage { get; }

    public int? NextPage { get; }

    public int? PreviousPage { get; }

    public bool HasNextPage { get; }

    public bool HasPreviousPage { get; }
}