namespace Unisantos.TI.Domain.DTO.Company;

public class ProductsSectionResponseDTO
{
    public string Title { get; set; }

    public ICollection<ProductResponseDTO> Products { get; set; } = new List<ProductResponseDTO>();
}