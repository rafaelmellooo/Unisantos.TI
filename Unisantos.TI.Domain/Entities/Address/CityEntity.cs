namespace Unisantos.TI.Domain.Entities.Address;

public class CityEntity
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string StateId { get; set; }
    
    public StateEntity State { get; set; }
    
    public ICollection<AddressEntity> Addresses { get; set; }
}