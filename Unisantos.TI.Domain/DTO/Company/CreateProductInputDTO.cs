using System.ComponentModel.DataAnnotations;

namespace Unisantos.TI.Domain.DTO.Company;

public class CreateProductInputDTO
{
    [Required(ErrorMessage = "O nome do produto é obrigatório")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "A descrição do produto é obrigatória")]
    public required string Description { get; set; }

    [Required(ErrorMessage = "O preço do produto é obrigatório")]
    public float Price { get; set; }
}