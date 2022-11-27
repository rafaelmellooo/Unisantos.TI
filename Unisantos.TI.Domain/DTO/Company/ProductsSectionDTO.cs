namespace Unisantos.TI.Domain.DTO.Company;

public class ProductsSectionDTO
{
    public string Title { get; set; }

    public ICollection<ProductDTO> Products { get; set; } = new List<ProductDTO>();
}