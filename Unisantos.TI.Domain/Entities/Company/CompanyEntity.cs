using Unisantos.TI.Domain.Entities.Address;

namespace Unisantos.TI.Domain.Entities.Company;

public class CompanyEntity
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public Guid AddressId { get; set; }
    
    public AddressEntity Address { get; set; }
    
    public ICollection<TagEntity> Tags { get; set; }
}