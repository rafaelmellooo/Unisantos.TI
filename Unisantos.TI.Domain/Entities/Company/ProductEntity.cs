namespace Unisantos.TI.Domain.Entities.Company;

public class ProductEntity
{
    public Guid Id { get; set; }
    
    public Guid ProductsSectionId { get; set; }
    
    public Guid CompanyId { get; set; }
    
    public ProductsSectionEntity? ProductsSection { get; set; }
    
    public required string Name { get; set; }
    
    public required string Description { get; set; }
    
    public float Price { get; set; }
}