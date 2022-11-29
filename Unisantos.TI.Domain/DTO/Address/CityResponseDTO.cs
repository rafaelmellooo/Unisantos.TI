namespace Unisantos.TI.Domain.DTO.Address;

public record CityResponseDTO
{
    public int Id { get; set; }
    
    public required string Name { get; set; }
}