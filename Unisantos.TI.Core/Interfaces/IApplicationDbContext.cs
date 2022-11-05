using Microsoft.EntityFrameworkCore;
using Unisantos.TI.Domain.Entities.Address;
using Unisantos.TI.Domain.Entities.Company;
using Unisantos.TI.Domain.Entities.Token;
using Unisantos.TI.Domain.Entities.User;

namespace Unisantos.TI.Core.Interfaces;

public interface IApplicationDbContext
{
    DbSet<UserEntity> Users { get; }

    DbSet<TokenEntity> Tokens { get; }

    DbSet<StateEntity> States { get; }

    DbSet<CityEntity> Cities { get; }

    DbSet<AddressEntity> Addresses { get; }

    DbSet<CompanyEntity> Companies { get; }
    
    DbSet<TagEntity> Tags { get; }

    double Haversine(double latitude1, double longitude1, double latitude2, double longitude2);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}