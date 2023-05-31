using Unisantos.TI.Domain.DTO.Company;
using Unisantos.TI.Domain.Entities.Company;

namespace Unisantos.TI.Core.Mappers.Company;

public static class ProductMapper
{
    public static ProductEntity Mapper(ProductInputDTO product)
    {
        var productEntity = new ProductEntity
        {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price
        };

        if (product.Id.HasValue)
        {
            productEntity.Id = product.Id.Value;
        }

        return productEntity;
    }
}