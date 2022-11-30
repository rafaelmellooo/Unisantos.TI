namespace Unisantos.TI.Domain.DTO.Address;

public record AddressResponseDTO
{
    public Guid Id { get; init; }
    
    public required string ZipCode { get; set; }
    
    public required string State { get; set; }
    
    public required string City { get; set; }
    
    public required string Neighborhood { get; set; }
    
    public required string Street { get; set; }
    
    public int Number { get; set; }
    
    public string? Complement { get; set; }
}