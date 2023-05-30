using System.ComponentModel.DataAnnotations;
using Unisantos.TI.Domain.DTO.Address;

namespace Unisantos.TI.Domain.DTO.Company;

public record CreateCompanyInputDTO
{
    [Required(ErrorMessage = "O nome da empresa é obrigatório")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "A prévia da imagem da empresa é obrigatória")]
    public required string ImagePreviewUrl { get; set; }

    [Required(ErrorMessage = "A imagem da empresa é obrigatória")]
    public required string ImageUrl { get; set; }

    [Required(ErrorMessage = "A descrição da empresa é obrigatória")]
    public required string Description { get; set; }

    [Required(ErrorMessage = "O telefone da empresa é obrigatório")]
    public required string Phone { get; set; }

    public string? Instagram { get; set; }

    public string? Facebook { get; set; }

    public ICollection<CreateProductSectionInputDTO> ProductSections { get; set; } =
        new List<CreateProductSectionInputDTO>();

    public ICollection<CreateBusinessHoursInputDTO> BusinessHours { get; set; } =
        new List<CreateBusinessHoursInputDTO>();

    public required AddressInputDTO Address { get; set; }

    public ICollection<int> Tags { get; set; } = new List<int>();
}