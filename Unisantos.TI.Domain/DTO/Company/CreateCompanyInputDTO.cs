using System.ComponentModel.DataAnnotations;
using Unisantos.TI.Domain.DTO.Address;

namespace Unisantos.TI.Domain.DTO.Company;

public record CreateCompanyInputDTO
{
    [Required(ErrorMessage = "O nome da empresa é obrigatório")]
    public required string Name { get; set; }

    public required string ImagePreviewUrl { get; set; }

    public required string ImageUrl { get; set; }

    [Required(ErrorMessage = "A descrição da empresa é obrigatória")]
    public required string Description { get; set; }

    public string? Phone { get; set; }

    public string? Instagram { get; set; }

    public string? Facebook { get; set; }

    public ICollection<ProductsSectionDTO> ProductsSections { get; set; } = new List<ProductsSectionDTO>();

    public ICollection<BusinessHoursDTO> BusinessHours { get; set; } = new List<BusinessHoursDTO>();

    public required AddressInputDTO Address { get; set; }

    public ICollection<int> Tags { get; set; } = new List<int>();
}