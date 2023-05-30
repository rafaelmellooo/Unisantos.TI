namespace Unisantos.TI.Domain.Entities.Company;

public class ProductSectionEntity
{
    public Guid Id { get; set; }
    
    public Guid CompanyId { get; set; }
    
    public CompanyEntity? Company { get; set; }
    
    public required string Title { get; set; }
    
    public ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();
}