using Unisantos.TI.Domain.DTO.Address;
using Unisantos.TI.Domain.Entities.Address;

namespace Unisantos.TI.Core.Mappers.Address;

public static class AddressMapper
{
    public static AddressEntity Mapper(AddressInputDTO address)
    {
        var addressEntity = new AddressEntity
        {
            Latitude = address.Latitude,
            Longitude = address.Longitude,
            Cep = address.Cep,
            CityId = address.City,
            Neighborhood = address.Neighborhood,
            Street = address.Street,
            Number = address.Number,
            Complement = address.Complement
        };

        if (address.Id.HasValue)
        {
            addressEntity.Id = address.Id.Value;
        }

        return addressEntity;
    }
}