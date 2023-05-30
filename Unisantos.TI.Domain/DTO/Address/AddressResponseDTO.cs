namespace Unisantos.TI.Domain.DTO.Address;

public record AddressResponseDTO
{
    public Guid Id { get; init; }
    
    public required string Cep { get; set; }
    
    public double Latitude { get; set; }

    public double Longitude { get; set; }
    
    public required string State { get; set; }
    
    public required string City { get; set; }
    
    public required string Neighborhood { get; set; }
    
    public required string Street { get; set; }
    
    public int Number { get; set; }
    
    public string? Complement { get; set; }
}