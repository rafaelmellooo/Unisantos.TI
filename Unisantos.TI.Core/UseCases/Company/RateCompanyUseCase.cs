using Microsoft.EntityFrameworkCore;
using Unisantos.TI.Core.Interfaces;
using Unisantos.TI.Domain.DTO.Company;
using Unisantos.TI.Domain.Entities.Company;
using Unisantos.TI.Domain.Exceptions.Company;
using Unisantos.TI.Domain.Providers.Auth;

namespace Unisantos.TI.Core.UseCases.Company;

public class RateCompanyUseCase : IUseCase<RateCompanyInputDTO, RateResponseDTO>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IAuthenticatedUser _authenticatedUser;

    public RateCompanyUseCase(IApplicationDbContext applicationDbContext, IAuthenticatedUser authenticatedUser)
    {
        _applicationDbContext = applicationDbContext;
        _authenticatedUser = authenticatedUser;
    }

    public async Task<RateResponseDTO> Execute(RateCompanyInputDTO request,
        CancellationToken cancellationToken = default)
    {
        var company = await _applicationDbContext.Companies.AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == request.CompanyId, cancellationToken);

        if (company is null)
        {
            throw new CompanyNotFoundException();
        }

        var rate = new RateEntity
        {
            CompanyId = company.Id,
            UserId = _authenticatedUser.Id.Value,
            Rate = request.Rate,
            Comment = request.Comment
        };

        var rateAdded = await _applicationDbContext.Rates.AddAsync(rate, cancellationToken);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return new RateResponseDTO
        {
            Id = rateAdded.Entity.Id,
            Rate = rateAdded.Entity.Rate,
            Comment = rateAdded.Entity.Comment,
            User = _authenticatedUser.Name
        };
    }
}