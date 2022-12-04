using Unisantos.TI.Core.Interfaces;
using Unisantos.TI.Domain.DTO.Company;

namespace Unisantos.TI.Core.UseCases.Company;

public class GetFavoriteCompaniesUseCase : IUseCase<GetFavoriteCompaniesInputDTO>
{
    public Task Execute(GetFavoriteCompaniesInputDTO request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}