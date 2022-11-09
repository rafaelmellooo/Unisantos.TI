namespace Unisantos.TI.Domain.Entities.Company;

public class TagsSectionEntity
{
    public byte Id { get; set; }
    
    public string Title { get; set; }
    
    public ICollection<TagEntity> Tags { get; set; } = new List<TagEntity>();
}