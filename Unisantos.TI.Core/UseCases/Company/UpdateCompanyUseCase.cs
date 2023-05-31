using Microsoft.EntityFrameworkCore;
using Unisantos.TI.Core.Interfaces;
using Unisantos.TI.Core.Mappers.Address;
using Unisantos.TI.Core.Mappers.Company;
using Unisantos.TI.Domain.DTO.Company;
using Unisantos.TI.Domain.Exceptions.Company;
using Unisantos.TI.Domain.Providers.Auth;

namespace Unisantos.TI.Core.UseCases.Company;

public class UpdateCompanyUseCase : IUseCase<UpdateCompanyInputDTO>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IAuthenticatedUser _authenticatedUser;

    public UpdateCompanyUseCase(IApplicationDbContext applicationDbContext, IAuthenticatedUser authenticatedUser)
    {
        _applicationDbContext = applicationDbContext;
        _authenticatedUser = authenticatedUser;
    }

    public async Task Execute(UpdateCompanyInputDTO request, CancellationToken cancellationToken = default)
    {
        var company = await _applicationDbContext.Companies
            .Include(company => company.Tags)
            .FirstOrDefaultAsync(company => company.Id == request.Id && company.AdminId == _authenticatedUser.Id,
                cancellationToken);

        if (company is null)
        {
            throw new CompanyNotFoundException();
        }

        var tags = await _applicationDbContext.Tags
            .Where(tag => request.Tags.Contains(tag.Id))
            .ToArrayAsync(cancellationToken);

        company.Name = request.Name;
        company.Description = request.Description;
        company.Phone = request.Phone;
        company.Facebook = request.Facebook;
        company.ImagePreviewUrl = request.ImagePreviewUrl;
        company.ImageUrl = request.ImageUrl;
        company.Instagram = request.Instagram;

        company.BusinessHours = request.BusinessHours
            .Select(businessHours => BusinessHoursMapper.Mapper(businessHours))
            .ToArray();

        company.ProductSections = request.ProductSections
            .Select(productSection => ProductSectionMapper.Mapper(productSection))
            .ToArray();

        company.Address = AddressMapper.Mapper(request.Address);

        var tagsToRemove = company.Tags
            .Where(tag => !tags.Contains(tag))
            .ToArray();

        var tagsToAdd = tags
            .Where(tag => !company.Tags.Contains(tag))
            .ToArray();

        foreach (var tag in tagsToRemove)
        {
            company.Tags.Remove(tag);
        }

        foreach (var tag in tagsToAdd)
        {
            company.Tags.Add(tag);
        }

        var businessHoursToRemove = await _applicationDbContext.BusinessHours
            .Where(businessHours => request.RemovedBusinessHours.Contains(businessHours.Id))
            .ToArrayAsync(cancellationToken);

        _applicationDbContext.BusinessHours.RemoveRange(businessHoursToRemove);

        var productsToRemove = await _applicationDbContext.Products
            .Where(product => request.RemovedProducts.Contains(product.Id) &&
                              !request.RemovedProductSections.Contains(product.ProductSectionId))
            .ToArrayAsync(cancellationToken);

        _applicationDbContext.Products.RemoveRange(productsToRemove);

        var productSectionsToRemove = await _applicationDbContext.ProductSections
            .Where(productSection => request.RemovedProductSections.Contains(productSection.Id))
            .ToArrayAsync(cancellationToken);

        _applicationDbContext.ProductSections.RemoveRange(productSectionsToRemove);

        _applicationDbContext.Companies.Update(company);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
    }
}