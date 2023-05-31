namespace Unisantos.TI.Domain.Entities.Company;

public class ProductEntity
{
    public Guid Id { get; set; }
    
    public Guid ProductSectionId { get; set; }

    public ProductSectionEntity? ProductSection { get; set; }
    
    public required string Name { get; set; }
    
    public required string Description { get; set; }
    
    public float Price { get; set; }
}