namespace Unisantos.TI.Domain.Entities.Company;

public class TagEntity
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public byte TagsSectionId { get; set; }

    public required TagsSectionEntity TagsSection { get; set; }

    public ICollection<CompanyEntity> Companies { get; set; } = new List<CompanyEntity>();
}