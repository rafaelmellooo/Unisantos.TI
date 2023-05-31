using Unisantos.TI.Domain.DTO.Address;

namespace Unisantos.TI.Domain.DTO.Company;

public record CompanyResponseDTO
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required string ImagePreviewUrl { get; set; }

    public float? Rating { get; set; }

    public required AddressResponseDTO Address { get; set; }

    public ICollection<TagResponseDTO> Tags { get; set; } = new List<TagResponseDTO>();
}