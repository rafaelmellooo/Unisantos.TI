using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unisantos.TI.Domain.Entities.Address;

namespace Unisantos.TI.Infrastructure.EntityMapping.Address;

public class AddressEntityMapping : IEntityTypeConfiguration<AddressEntity>
{
    public void Configure(EntityTypeBuilder<AddressEntity> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.Street).IsRequired();
        builder.Property(e => e.ZipCode).HasMaxLength(9).IsFixedLength().IsRequired();
        builder.Property(e => e.Neighborhood).IsRequired();
        builder.Property(e => e.Number).IsRequired();
        builder.Property(e => e.Complement);
        builder.Property(e => e.Latitude).IsRequired();
        builder.Property(e => e.Longitude).IsRequired();

        builder
            .HasOne(e => e.City)
            .WithMany(e => e.Addresses)
            .HasForeignKey(e => e.CityId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}