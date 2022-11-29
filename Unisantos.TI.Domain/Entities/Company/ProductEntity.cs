namespace Unisantos.TI.Domain.Entities.Company;

public class ProductEntity
{
    public short Id { get; set; }
    
    public byte ProductsSectionId { get; set; }
    
    public Guid CompanyId { get; set; }
    
    public ProductsSectionEntity? ProductsSection { get; set; }
    
    public required string Name { get; set; }
    
    public required string Description { get; set; }
    
    public float Price { get; set; }
}