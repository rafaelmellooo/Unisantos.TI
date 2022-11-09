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
            where _applicationDbContext.Haversine(company.Address.Latitude, company.Address.Longitude, request.Latitude,
                request.Longitude) <= request.Distance && company.Tags.Any(tag => request.Tags.Contains(tag.Id))
            select new CompanyResponseDTO
            {
                Name = company.Name,
                Latitude = company.Address.Latitude,
                Longitude = company.Address.Longitude,
                ImagePreviewUrl = company.ImagePreviewUrl,
                Tags = company.Tags.Select(tag => tag.Name).ToArray()
            };

        return query.ToArrayAsync(cancellationToken);
    }
}