namespace Unisantos.TI.Domain.DTO.Company;

public record TagsSectionResponseDTO
{
    public required string Title { get; set; }

    public ICollection<TagResponseDTO> Tags { get; set; } = new List<TagResponseDTO>();
}