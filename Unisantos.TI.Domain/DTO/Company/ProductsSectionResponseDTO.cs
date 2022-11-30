namespace Unisantos.TI.Domain.DTO.Company;

public record ProductsSectionResponseDTO
{
    public byte Id { get; set; }

    public required string Title { get; set; }

    public ICollection<ProductResponseDTO> Products { get; set; } = new List<ProductResponseDTO>();
}