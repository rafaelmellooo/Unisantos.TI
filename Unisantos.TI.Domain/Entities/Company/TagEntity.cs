namespace Unisantos.TI.Domain.Entities.Company;

public class TagEntity
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public ICollection<CompanyEntity> Companies { get; set; }
}