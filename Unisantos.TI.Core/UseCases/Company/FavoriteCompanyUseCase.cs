using Microsoft.EntityFrameworkCore;
using Unisantos.TI.Core.Interfaces;
using Unisantos.TI.Domain.DTO.Company;
using Unisantos.TI.Domain.Entities.Company;
using Unisantos.TI.Domain.Exceptions.Company;
using Unisantos.TI.Domain.Providers.Auth;

namespace Unisantos.TI.Core.UseCases.Company;

public class FavoriteCompanyUseCase : IUseCase<FavoriteCompanyInputDTO>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IAuthenticatedUser _authenticatedUser;

    public FavoriteCompanyUseCase(IApplicationDbContext applicationDbContext, IAuthenticatedUser authenticatedUser)
    {
        _applicationDbContext = applicationDbContext;
        _authenticatedUser = authenticatedUser;
    }

    public async Task Execute(FavoriteCompanyInputDTO request, CancellationToken cancellationToken = default)
    {
        var company = await _applicationDbContext.Companies.AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == request.CompanyId, cancellationToken);

        if (company is null)
        {
            throw new CompanyNotFoundException();
        }

        var favorite = new FavoriteEntity
        {
            CompanyId = company.Id,
            UserId = _authenticatedUser.Id.Value
        };

        await _applicationDbContext.Favorites.AddAsync(favorite, cancellationToken);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
    }
}