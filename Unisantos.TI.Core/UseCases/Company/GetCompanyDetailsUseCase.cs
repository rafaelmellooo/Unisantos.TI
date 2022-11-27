using Microsoft.EntityFrameworkCore;
using Unisantos.TI.Core.Interfaces;
using Unisantos.TI.Domain.DTO.Address;
using Unisantos.TI.Domain.DTO.Company;

namespace Unisantos.TI.Core.UseCases.Company;

public class GetCompanyDetailsUseCase : IUseCase<GetCompanyDetailsInputDTO, CompanyDetailsResponseDTO>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetCompanyDetailsUseCase(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public Task<CompanyDetailsResponseDTO> Execute(GetCompanyDetailsInputDTO request,
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
                Rating = company.Rates.Any() ? company.Rates.Sum(rate => rate.Rate) / company.Rates.Count : null,
                Phone = company.Phone,
                Facebook = company.Facebook,
                Instagram = company.Instagram,
                Description = company.Description,
                BusinessHours = company.BusinessHours.Select(businessHours => new BusinessHoursDTO
                {
                    DayOfWeek = businessHours.DayOfWeek,
                    OpeningTime = businessHours.OpeningTime,
                    ClosingTime = businessHours.ClosingTime
                }).ToArray(),
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
                Tags = company.Tags.Select(tag => tag.Name).ToArray(),
                Rates = company.Rates.Select(rate => new RateResponseDTO
                {
                    User = rate.User.Name,
                    Rate = rate.Rate,
                    Comment = rate.Comment
                }).ToArray(),
                ProductsSections = company.ProductsSections.Select(productsSection => new ProductsSectionDTO
                {
                    Title = productsSection.Title,
                    Products = productsSection.Products.Select(product => new ProductDTO
                    {
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price
                    }).ToArray()
                }).ToArray()
            };

        return query.FirstAsync(cancellationToken);
    }
}