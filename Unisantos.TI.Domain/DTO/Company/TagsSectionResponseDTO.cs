namespace Unisantos.TI.Domain.DTO.Company;

public class TagsSectionResponseDTO
{
    public string Title { get; set; }

    public ICollection<TagResponseDTO> Tags { get; set; } = new List<TagResponseDTO>();
}