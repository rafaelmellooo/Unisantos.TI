using Microsoft.EntityFrameworkCore;
using Unisantos.TI.Core.Interfaces;
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
            where _applicationDbContext.Haversine(address.Latitude, address.Longitude, request.Latitude,
                request.Longitude) <= request.Distance && company.Tags.Any(tag => request.Tags.Contains(tag.Id))
            select new CompanyResponseDTO
            {
                Id = company.Id,
                Name = company.Name,
                Latitude = address.Latitude,
                Longitude = address.Longitude,
                ImagePreviewUrl = company.ImagePreviewUrl,
                Rating = company.Rates.Sum(rate => rate.Rate) / company.Rates.Count,
                Address =
                    $"{address.Street}, {address.Number} - {address.Neighborhood}, {address.City.Name} - {address.City.State.Id}, {address.ZipCode}",
                Tags = company.Tags.Select(tag => tag.Name).ToArray()
            };

        return query.ToArrayAsync(cancellationToken);
    }
}