namespace Unisantos.TI.Domain.DTO.Company;

public class CompanyDetailsResponseDTO : CompanyResponseDTO
{
    public string Description { get; set; }

    public string Phone { get; set; }

    public string Instagram { get; set; }

    public string Facebook { get; set; }

    public ICollection<BusinessHoursResponseDTO> BusinessHours { get; set; } = new List<BusinessHoursResponseDTO>();

    public ICollection<ProductsSectionResponseDTO> ProductsSections { get; set; } =
        new List<ProductsSectionResponseDTO>();

    public ICollection<RateResponseDTO> Rates { get; set; } = new List<RateResponseDTO>();
}