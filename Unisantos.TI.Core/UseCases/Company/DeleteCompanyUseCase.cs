using Microsoft.EntityFrameworkCore;
using Unisantos.TI.Core.Interfaces;
using Unisantos.TI.Domain.DTO.Company;
using Unisantos.TI.Domain.Exceptions.Company;
using Unisantos.TI.Domain.Providers.Auth;

namespace Unisantos.TI.Core.UseCases.Company;

public class DeleteCompanyUseCase : IUseCase<DeleteCompanyInputDTO>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IAuthenticatedUser _authenticatedUser;

    public DeleteCompanyUseCase(IApplicationDbContext applicationDbContext, IAuthenticatedUser authenticatedUser)
    {
        _applicationDbContext = applicationDbContext;
        _authenticatedUser = authenticatedUser;
    }

    public async Task Execute(DeleteCompanyInputDTO request, CancellationToken cancellationToken = default)
    {
        var company = await _applicationDbContext.Companies.FirstOrDefaultAsync(
            company => company.Id == request.Id && company.AdminId == _authenticatedUser.Id, cancellationToken);

        if (company is null)
        {
            throw new CompanyNotFoundException();
        }

        _applicationDbContext.Companies.Remove(company);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
    }
}