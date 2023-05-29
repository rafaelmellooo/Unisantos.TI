using Microsoft.EntityFrameworkCore;
using Unisantos.TI.Core.Interfaces;
using Unisantos.TI.Domain.DTO.Address;

namespace Unisantos.TI.Core.UseCases.Address;

public class GetStatesUseCase : IUseCase<GetStatesInputDTO, StateResponseDTO[]>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetStatesUseCase(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public Task<StateResponseDTO[]> Execute(GetStatesInputDTO request, CancellationToken cancellationToken = default)
    {
        return _applicationDbContext.States.Select(state => new StateResponseDTO
        {
            Id = state.Id,
            Name = state.Name
        }).ToArrayAsync(cancellationToken);
    }
}