namespace Unisantos.TI.Domain.Entities.Company;

public class CompanyTypeEntity
{
    public byte Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
    
    public ICollection<CompanyEntity> Companies { get; set; } = new List<CompanyEntity>();
}