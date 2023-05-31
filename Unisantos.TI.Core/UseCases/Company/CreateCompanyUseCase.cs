using Microsoft.EntityFrameworkCore;
using Unisantos.TI.Core.Interfaces;
using Unisantos.TI.Core.Mappers.Address;
using Unisantos.TI.Core.Mappers.Company;
using Unisantos.TI.Domain.DTO.Company;
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
        var tags = await _applicationDbContext.Tags
            .Where(tag => request.Tags.Contains(tag.Id))
            .ToArrayAsync(cancellationToken);

        var company = new CompanyEntity
        {
            Name = request.Name,
            Description = request.Description,
            Phone = request.Phone,
            Facebook = request.Facebook,
            ImagePreviewUrl = request.ImagePreviewUrl,
            ImageUrl = request.ImageUrl,
            Instagram = request.Instagram,

            BusinessHours = request.BusinessHours
                .Select(businessHours => BusinessHoursMapper.Mapper(businessHours))
                .ToArray(),

            ProductSections = request.ProductSections
                .Select(productSection => ProductSectionMapper.Mapper(productSection))
                .ToArray(),

            Address = AddressMapper.Mapper(request.Address),

            AdminId = _authenticatedUser.Id.Value
        };
        
        foreach (var tag in tags)
        {
            company.Tags.Add(tag);
        }

        var companyAdded = await _applicationDbContext.Companies.AddAsync(company, cancellationToken);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return new CreateCompanyResponseDTO
        {
            Id = companyAdded.Entity.Id
        };
    }
}