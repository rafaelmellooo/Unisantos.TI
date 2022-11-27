using System.ComponentModel.DataAnnotations;
using Unisantos.TI.Domain.DTO.Address;

namespace Unisantos.TI.Domain.DTO.Company;

public class CreateCompanyInputDTO
{
    [Required(ErrorMessage = "O nome da empresa é obrigatório")]
    public string Name { get; set; }
    
    public string ImagePreviewUrl { get; set; }
    
    public string ImageUrl { get; set; }
    
    [Required(ErrorMessage = "A descrição da empresa é obrigatória")]
    public string Description { get; set; }

    [Required(ErrorMessage = "O telefone da empresa é obrigatório")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "O instagram da empresa é obrigatório")]
    public string Instagram { get; set; }

    [Required(ErrorMessage = "O facebook da empresa é obrigatório")]
    public string Facebook { get; set; }

    public ICollection<ProductsSectionDTO> ProductsSections { get; set; } = new List<ProductsSectionDTO>();

    public ICollection<BusinessHoursDTO> BusinessHours { get; set; } = new List<BusinessHoursDTO>();

    public AddressInputDTO Address { get; set; }

    public ICollection<int> Tags { get; set; } = new List<int>();
}