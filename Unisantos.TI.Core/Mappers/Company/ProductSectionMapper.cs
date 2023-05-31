using Unisantos.TI.Domain.DTO.Company;
using Unisantos.TI.Domain.Entities.Company;

namespace Unisantos.TI.Core.Mappers.Company;

public static class ProductSectionMapper
{
    public static ProductSectionEntity Mapper(ProductSectionInputDTO productSection)
    {
        var productSectionEntity = new ProductSectionEntity
        {
            Title = productSection.Title,
            Products = productSection.Products
                .Select(ProductMapper.Mapper)
                .ToArray()
        };

        if (productSection.Id.HasValue)
        {
            productSectionEntity.Id = productSection.Id.Value;
        }

        return productSectionEntity;
    }
}