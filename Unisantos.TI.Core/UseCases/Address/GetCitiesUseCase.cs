using Microsoft.EntityFrameworkCore;
using Unisantos.TI.Core.Interfaces;
using Unisantos.TI.Domain.DTO.Address;

namespace Unisantos.TI.Core.UseCases.Address;

public class GetCitiesUseCase : IUseCase<GetCitiesInputDTO, CityResponseDTO[]>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetCitiesUseCase(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public Task<CityResponseDTO[]> Execute(GetCitiesInputDTO request, CancellationToken cancellationToken = default)
    {
        return _applicationDbContext.Cities.Where(city => city.StateId == request.State).Select(city =>
            new CityResponseDTO
            {
                Id = city.Id,
                Name = city.Name
            }).ToArrayAsync(cancellationToken);
    }
}