using Microsoft.EntityFrameworkCore;
using Unisantos.TI.Core.Helpers;
using Unisantos.TI.Core.Interfaces;
using Unisantos.TI.Domain.DTO.Address;
using Unisantos.TI.Domain.DTO.Company;
using Unisantos.TI.Domain.Providers.Auth;

namespace Unisantos.TI.Core.UseCases.Company;

public class GetFavoriteCompaniesUseCase : IUseCase<GetFavoriteCompaniesInputDTO, CompanyResponseDTO[]>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IAuthenticatedUser _authenticatedUser;

    public GetFavoriteCompaniesUseCase(IApplicationDbContext applicationDbContext, IAuthenticatedUser authenticatedUser)
    {
        _applicationDbContext = applicationDbContext;
        _authenticatedUser = authenticatedUser;
    }

    public Task<CompanyResponseDTO[]> Execute(GetFavoriteCompaniesInputDTO request,
        CancellationToken cancellationToken = default)
    {
        var query = from company in _applicationDbContext.Companies
            let address = company.Address
            where DbFunctionHelpers.Haversine(address.Latitude, address.Longitude, request.Latitude,
                      request.Longitude) <= request.Distance &&
                  company.Favorites.Any(favorite => favorite.UserId == _authenticatedUser.Id)
            select new CompanyResponseDTO
            {
                Id = company.Id,
                Name = company.Name,
                Latitude = address.Latitude,
                Longitude = address.Longitude,
                ImagePreviewUrl = company.ImagePreviewUrl,
                Rating = company.Rating,
                Address = new AddressResponseDTO
                {
                    ZipCode = address.ZipCode,
                    State = address.City.State.Id,
                    City = address.City.Name,
                    Street = address.Street,
                    Neighborhood = address.Neighborhood,
                    Number = address.Number,
                    Complement = address.Complement
                },
                Tags = company.Tags.Select(tag => tag.Name).ToArray()
            };

        return query.ToArrayAsync(cancellationToken);
    }
}