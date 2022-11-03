namespace Unisantos.TI.Domain.Entities.Address;

public class StateEntity
{
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public ICollection<CityEntity> Cities { get; set; }
}