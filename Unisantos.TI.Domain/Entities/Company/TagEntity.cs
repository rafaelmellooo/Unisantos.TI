namespace Unisantos.TI.Domain.Entities.Company;

public class TagEntity
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public byte TagSectionId { get; set; }

    public required TagSectionEntity TagSection { get; set; }

    public ICollection<CompanyEntity> Companies { get; set; } = new List<CompanyEntity>();
}