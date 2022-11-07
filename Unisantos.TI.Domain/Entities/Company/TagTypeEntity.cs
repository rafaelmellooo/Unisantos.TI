namespace Unisantos.TI.Domain.Entities.Company;

public class TagTypeEntity
{
    public byte Id { get; set; }
    
    public string Name { get; set; }
    
    public ICollection<TagEntity> Tags { get; set; } = new List<TagEntity>();
}