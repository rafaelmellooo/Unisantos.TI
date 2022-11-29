namespace Unisantos.TI.Domain.DTO.Company;

public record TagResponseDTO
{
    public required int Id { get; set; }
    
    public required string Name { get; set; }
}