using System.ComponentModel;

namespace Unisantos.TI.Domain.DTO;

public class PaginationInputDTO
{
    [DefaultValue(1)]
    public int Page { get; set; }
    
    [DefaultValue(14)]
    public int PerPage { get; set; }
}