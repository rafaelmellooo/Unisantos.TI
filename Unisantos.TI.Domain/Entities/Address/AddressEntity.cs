using Unisantos.TI.Domain.Entities.Company;

namespace Unisantos.TI.Domain.Entities.Address;

public class AddressEntity
{
    public Guid Id { get; set; }

    public int CityId { get; set; }
    
    public CityEntity? City { get; set; }

    public required string ZipCode { get; set; }

    public required string Street { get; set; }

    public required string Neighborhood { get; set; }

    public int Number { get; set; }

    public string? Complement { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }
    
    public CompanyEntity? Company { get; set; }
}