namespace Unisantos.TI.Domain.DTO.Company;

public record ProductResponseDTO
{
    public Guid Id { get; set; }
    
    public required string Name { get; set; }
    
    public required string Description { get; set; }
    
    public float Price { get; set; }
}