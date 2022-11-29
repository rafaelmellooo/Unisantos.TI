namespace Unisantos.TI.Domain.DTO.Company;

public record ProductsSectionDTO
{
    public required string Title { get; set; }

    public ICollection<ProductDTO> Products { get; set; } = new List<ProductDTO>();
}