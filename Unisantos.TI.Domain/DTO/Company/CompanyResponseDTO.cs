using Unisantos.TI.Domain.DTO.Address;

namespace Unisantos.TI.Domain.DTO.Company;

public record CompanyResponseDTO
{
    public Guid Id { get; set; }
    
    public required string Name { get; set; }
    
    public double Latitude { get; set; }
    
    public double Longitude { get; set; }
    
    public required string ImagePreviewUrl { get; set; }
    
    public float? Rating { get; set; }
    
    public required AddressResponseDTO Address { get; set; }
    
    public ICollection<string> Tags { get; set; } = new List<string>();
}