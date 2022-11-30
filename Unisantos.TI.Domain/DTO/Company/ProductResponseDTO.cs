namespace Unisantos.TI.Domain.DTO.Company;

public record ProductResponseDTO
{
    public short Id { get; set; }
    
    public required string Name { get; set; }
    
    public required string Description { get; set; }
    
    public float Price { get; set; }
}