using Microsoft.EntityFrameworkCore;
using Unisantos.TI.Core.Interfaces;
using Unisantos.TI.Domain.DTO.Address;
using Unisantos.TI.Domain.DTO.Company;
using Unisantos.TI.Domain.Exceptions.Company;
using Unisantos.TI.Domain.Providers.Auth;

namespace Unisantos.TI.Core.UseCases.Company;

public class GetCompanyDetailsUseCase : IUseCase<GetCompanyDetailsInputDTO, CompanyDetailsResponseDTO>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IAuthenticatedUser _authenticatedUser;

    public GetCompanyDetailsUseCase(IApplicationDbContext applicationDbContext, IAuthenticatedUser authenticatedUser)
    {
        _applicationDbContext = applicationDbContext;
        _authenticatedUser = authenticatedUser;
    }

    public async Task<CompanyDetailsResponseDTO> Execute(GetCompanyDetailsInputDTO request,
        CancellationToken cancellationToken = default)
    {
        var query = from company in _applicationDbContext.Companies
            let address = company.Address
            where company.Id == request.Id
            select new CompanyDetailsResponseDTO
            {
                Name = company.Name,
                Latitude = address.Latitude,
                Longitude = address.Longitude,
                ImageUrl = company.ImageUrl,
                Rating = company.Rating,
                IsFavorited = _authenticatedUser.Id.HasValue
                    ? company.Favorites.Any(favorite => favorite.UserId == _authenticatedUser.Id.Value)
                    : null,
                Phone = company.Phone,
                Facebook = company.Facebook,
                Instagram = company.Instagram,
                Description = company.Description,
                BusinessHours = company.BusinessHours.Select(businessHours => new BusinessHoursResponseDTO
                {
                    Id = businessHours.Id,
                    DayOfWeek = businessHours.DayOfWeek,
                    OpeningTime = businessHours.OpeningTime,
                    ClosingTime = businessHours.ClosingTime
                }).ToArray(),
                Address = new AddressResponseDTO
                {
                    Id = address.Id,
                    ZipCode = address.ZipCode,
                    State = address.City.State.Id,
                    City = address.City.Name,
                    Street = address.Street,
                    Neighborhood = address.Neighborhood,
                    Number = address.Number,
                    Complement = address.Complement
                },
                Tags = company.Tags.Select(tag => tag.Name).ToArray(),
                Rates = company.Rates.Select(rate => new RateResponseDTO
                {
                    Id = rate.Id,
                    User = rate.User.Name,
                    Rate = rate.Rate,
                    Comment = rate.Comment
                }).ToArray(),
                ProductsSections = company.ProductsSections.Select(productsSection => new ProductsSectionResponseDTO
                {
                    Id = productsSection.Id,
                    Title = productsSection.Title,
                    Products = productsSection.Products.Select(product => new ProductResponseDTO
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price
                    }).ToArray()
                }).ToArray()
            };

        var companyDetails = await query.FirstOrDefaultAsync(cancellationToken);

        if (companyDetails is null)
        {
            throw new CompanyNotFoundException();
        }

        return companyDetails;
    }
}