using Microsoft.EntityFrameworkCore;
using Unisantos.TI.Core.Helpers;
using Unisantos.TI.Core.Interfaces;
using Unisantos.TI.Domain.DTO.Address;
using Unisantos.TI.Domain.DTO.Company;

namespace Unisantos.TI.Core.UseCases.Company;

public class GetCompaniesUseCase : IUseCase<GetCompaniesInputDTO, CompanyResponseDTO[]>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetCompaniesUseCase(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public Task<CompanyResponseDTO[]> Execute(GetCompaniesInputDTO request,
        CancellationToken cancellationToken = default)
    {
        var query = from company in _applicationDbContext.Companies
            let address = company.Address
            where DbFunctionHelpers.Haversine(address.Latitude, address.Longitude, request.Latitude,
                      request.Longitude) <= request.Distance &&
                  (!request.Tags.Any() || company.Tags.Any(tag => request.Tags.Contains(tag.Id)))
            select new CompanyResponseDTO
            {
                Id = company.Id,
                Name = company.Name,
                ImagePreviewUrl = company.ImagePreviewUrl,
                Rating = company.Rating,
                Address = new AddressResponseDTO
                {
                    Id = address.Id,
                    Cep = address.Cep,
                    Latitude = address.Latitude,
                    Longitude = address.Longitude,
                    State = new StateResponseDTO
                    {
                        Id = address.City.State.Id,
                        Name = address.City.State.Name
                    },
                    City = new CityResponseDTO
                    {
                        Id = address.City.Id,
                        Name = address.City.Name
                    },
                    Street = address.Street,
                    Neighborhood = address.Neighborhood,
                    Number = address.Number,
                    Complement = address.Complement
                },
                Tags = company.Tags.Select(tag => new TagResponseDTO
                {
                    Id = tag.Id,
                    Name = tag.Name
                }).ToArray()
            };

        return query.ToArrayAsync(cancellationToken);
    }
}