using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unisantos.TI.Domain.Entities.Address;

namespace Unisantos.TI.Infrastructure.EntityMapping.Address;

public class StateEntityMapping : IEntityTypeConfiguration<StateEntity>
{
    public void Configure(EntityTypeBuilder<StateEntity> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasMaxLength(2).IsFixedLength();
        builder.Property(e => e.Name).IsRequired();
    }
}