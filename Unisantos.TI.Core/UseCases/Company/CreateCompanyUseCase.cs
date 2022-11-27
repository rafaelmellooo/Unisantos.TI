using Microsoft.EntityFrameworkCore;
using Unisantos.TI.Core.Interfaces;
using Unisantos.TI.Domain.DTO.Company;
using Unisantos.TI.Domain.Entities.Address;
using Unisantos.TI.Domain.Entities.Company;
using Unisantos.TI.Domain.Providers.Auth;

namespace Unisantos.TI.Core.UseCases.Company;

public class CreateCompanyUseCase : IUseCase<CreateCompanyInputDTO, CreateCompanyResponseDTO>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IAuthenticatedUser _authenticatedUser;

    public CreateCompanyUseCase(IApplicationDbContext applicationDbContext, IAuthenticatedUser authenticatedUser)
    {
        _applicationDbContext = applicationDbContext;
        _authenticatedUser = authenticatedUser;
    }

    public async Task<CreateCompanyResponseDTO> Execute(CreateCompanyInputDTO request,
        CancellationToken cancellationToken = default)
    {
        var tags = await _applicationDbContext.Tags.Where(tag => request.Tags.Contains(tag.Id))
            .ToArrayAsync(cancellationToken);

        var company = new CompanyEntity
        {
            Id = new Guid(),
            Name = request.Name,
            Description = request.Description,
            Phone = request.Phone,
            Facebook = request.Facebook,
            ImagePreviewUrl = request.ImagePreviewUrl,
            ImageUrl = request.ImageUrl,
            Instagram = request.Instagram,
            BusinessHours = request.BusinessHours.Select(businessHours => new BusinessHoursEntity
            {
                DayOfWeek = businessHours.DayOfWeek,
                OpeningTime = businessHours.OpeningTime,
                ClosingTime = businessHours.ClosingTime
            }).ToArray(),
            ProductsSections = request.ProductsSections.Select(productsSection => new ProductsSectionEntity
            {
                Title = productsSection.Title,
                Products = productsSection.Products.Select(product => new ProductEntity
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price
                }).ToArray()
            }).ToArray(),
            Address = new AddressEntity
            {
                ZipCode = request.Address.ZipCode,
                CityId = request.Address.City,
                Neighborhood = request.Address.Neighborhood,
                Number = request.Address.Number,
                Complement = request.Address.Complement
            },
            Tags = tags,
            AdminId = _authenticatedUser.Id
        };

        await _applicationDbContext.Companies.AddAsync(company, cancellationToken);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return new CreateCompanyResponseDTO
        {
            Id = company.Id
        };
    }
}