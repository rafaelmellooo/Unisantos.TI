using System.ComponentModel;

namespace Unisantos.TI.Domain.DTO;

public record PaginationInputDTO
{
    [DefaultValue(1)]
    public int Page { get; set; }
    
    [DefaultValue(14)]
    public int PerPage { get; set; }
}