using Microsoft.EntityFrameworkCore;
using Unisantos.TI.Core.Interfaces;
using Unisantos.TI.Domain.DTO.Address;
using Unisantos.TI.Domain.DTO.Admin;
using Unisantos.TI.Domain.DTO.Company;
using Unisantos.TI.Domain.Providers.Auth;

namespace Unisantos.TI.Core.UseCases.Admin;

public class GetAdminCompaniesUseCase : IUseCase<GetAdminCompaniesInputDTO, CompanyResponseDTO[]>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IAuthenticatedUser _authenticatedUser;

    public GetAdminCompaniesUseCase(IApplicationDbContext applicationDbContext, IAuthenticatedUser authenticatedUser)
    {
        _applicationDbContext = applicationDbContext;
        _authenticatedUser = authenticatedUser;
    }

    public Task<CompanyResponseDTO[]> Execute(GetAdminCompaniesInputDTO request, CancellationToken cancellationToken = default)
    {
        var query = from company in _applicationDbContext.Companies
            let address = company.Address
            where company.AdminId == _authenticatedUser.Id
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
                    State = address.City.State.Id,
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