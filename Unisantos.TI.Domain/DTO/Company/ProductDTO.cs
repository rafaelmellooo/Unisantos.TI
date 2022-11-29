namespace Unisantos.TI.Domain.DTO.Company;

public record ProductDTO
{
    public required string Name { get; set; }
    
    public required string Description { get; set; }
    
    public float Price { get; set; }
}