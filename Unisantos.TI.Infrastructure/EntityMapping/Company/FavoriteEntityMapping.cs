using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unisantos.TI.Domain.Entities.Company;

namespace Unisantos.TI.Infrastructure.EntityMapping.Company;

public class FavoriteEntityMapping : IEntityTypeConfiguration<FavoriteEntity>
{
    public void Configure(EntityTypeBuilder<FavoriteEntity> builder)
    {
        builder.HasKey(e => new {e.CompanyId, e.UserId});

        builder
            .HasOne(e => e.User)
            .WithMany(e => e.Favorites)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Company)
            .WithMany(e => e.Favorites)
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(e => e.CreatedAt).IsRequired();
    }
}