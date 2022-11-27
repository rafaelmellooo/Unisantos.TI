using Unisantos.TI.Domain.DTO.Address;

namespace Unisantos.TI.Domain.DTO.Company;

public class CompanyDetailsResponseDTO
{
    public string Name { get; set; }
    
    public double Latitude { get; set; }
    
    public double Longitude { get; set; }

    public float? Rating { get; set; }
    
    public AddressResponseDTO Address { get; set; }
    
    public ICollection<string> Tags { get; set; } = new List<string>();
    
    public string Description { get; set; }

    public string Phone { get; set; }

    public string Instagram { get; set; }

    public string Facebook { get; set; }
    
    public string ImageUrl { get; set; }

    public ICollection<BusinessHoursDTO> BusinessHours { get; set; } = new List<BusinessHoursDTO>();

    public ICollection<ProductsSectionDTO> ProductsSections { get; set; } =
        new List<ProductsSectionDTO>();

    public ICollection<RateResponseDTO> Rates { get; set; } = new List<RateResponseDTO>();
}