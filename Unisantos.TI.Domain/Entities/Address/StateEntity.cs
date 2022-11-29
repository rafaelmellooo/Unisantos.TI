namespace Unisantos.TI.Domain.Entities.Address;

public class StateEntity
{
    public required string Id { get; set; }

    public required string Name { get; set; }

    public ICollection<CityEntity> Cities { get; set; } = new List<CityEntity>();
}