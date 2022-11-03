using Microsoft.EntityFrameworkCore;
using Unisantos.TI.Domain.Entities.Token;
using Unisantos.TI.Domain.Entities.User;

namespace Unisantos.TI.Core.Interfaces;

public interface IApplicationDbContext
{
    DbSet<UserEntity> Users { get; }
    
    DbSet<TokenEntity> Tokens { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}