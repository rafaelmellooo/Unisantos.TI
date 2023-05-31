using System.ComponentModel.DataAnnotations;

namespace Unisantos.TI.Domain.DTO.Address;

public record AddressInputDTO
{
    public Guid? Id { get; set; }
    
    [Required(ErrorMessage = "A latitude é obrigatória")]
    public double Latitude { get; set; }
    
    [Required(ErrorMessage = "A longitude é obrigatória")]
    public double Longitude { get; set; }
    
    [Required(ErrorMessage = "O CEP é obrigatório")]
    public required string Cep { get; set; }

    [Required(ErrorMessage = "O código da cidade é obrigatório")]
    public required int City { get; set; }
    
    [Required(ErrorMessage = "O bairro é obrigatório")]
    public required string Neighborhood { get; set; }

    [Required(ErrorMessage = "A rua é obrigatória")]
    public required string Street { get; set; }

    [Required(ErrorMessage = "O número da residência é obrigatório")]
    public int Number { get; set; }
    
    public string? Complement { get; set; }
}