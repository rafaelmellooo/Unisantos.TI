namespace Unisantos.TI.Domain.DTO.Company;

public record CompanyDetailsResponseDTO : CompanyResponseDTO
{
    public bool? IsFavorited { get; set; }

    public required string Description { get; set; }

    public string? Phone { get; set; }

    public string? Instagram { get; set; }

    public string? Facebook { get; set; }

    public required string ImageUrl { get; set; }

    public ICollection<BusinessHoursResponseDTO> BusinessHours { get; set; } = new List<BusinessHoursResponseDTO>();

    public ICollection<ProductSectionResponseDTO> ProductSections { get; set; } = new List<ProductSectionResponseDTO>();

    public ICollection<RateResponseDTO> Rates { get; set; } = new List<RateResponseDTO>();
}