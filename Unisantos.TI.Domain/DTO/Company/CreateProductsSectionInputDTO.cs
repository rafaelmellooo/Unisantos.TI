using System.ComponentModel.DataAnnotations;

namespace Unisantos.TI.Domain.DTO.Company;

public class CreateProductsSectionInputDTO
{
    [Required(ErrorMessage = "O título da seção de produtos é obrigatório")]
    public required string Title { get; set; }

    public ICollection<CreateProductInputDTO> Products { get; set; } = new List<CreateProductInputDTO>();
}