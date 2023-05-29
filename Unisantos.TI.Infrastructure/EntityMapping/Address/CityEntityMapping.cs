using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unisantos.TI.Domain.Entities.Address;

namespace Unisantos.TI.Infrastructure.EntityMapping.Address;

public class CityEntityMapping : IEntityTypeConfiguration<CityEntity>
{
    public void Configure(EntityTypeBuilder<CityEntity> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id);
        builder.Property(e => e.Name).IsRequired();

        builder
            .HasOne(e => e.State)
            .WithMany(e => e.Cities)
            .HasForeignKey(e => e.StateId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}