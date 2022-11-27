using System.ComponentModel.DataAnnotations;

namespace Unisantos.TI.Domain.DTO.Address;

public class AddressInputDTO
{
    [Required(ErrorMessage = "O CEP é obrigatório")]
    public string ZipCode { get; set; }

    [Required(ErrorMessage = "O código da cidade é obrigatório")]
    public int City { get; set; }
    
    [Required(ErrorMessage = "O bairro é obrigatório")]
    public string Neighborhood { get; set; }
    
    [Required(ErrorMessage = "A rua é obrigatória")]
    public string Street { get; set; }
    
    [Required(ErrorMessage = "O número da residência é obrigatório")]
    public int Number { get; set; }
    
    public string Complement { get; set; }
}