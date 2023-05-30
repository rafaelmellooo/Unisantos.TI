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
    
    DbSet<TagSectionEntity> TagSections { get; }
    
    DbSet<TagEntity> Tags { get; }

    DbSet<FavoriteEntity> Favorites { get; }
    
    DbSet<BusinessHoursEntity> BusinessHours { get; }
    
    DbSet<RateEntity> Rates { get; }
    
    DbSet<ProductSectionEntity> ProductSections { get; }
    
    DbSet<ProductEntity> Products { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}