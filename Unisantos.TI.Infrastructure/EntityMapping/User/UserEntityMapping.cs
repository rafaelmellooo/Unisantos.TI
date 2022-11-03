using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unisantos.TI.Domain.Entities.User;

namespace Unisantos.TI.Infrastructure.EntityMapping.User;

public class UserEntityMapping : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        
        builder.Property(e => e.Email).IsRequired();
        builder.HasIndex(e => e.Email).IsUnique();
        
        builder.Property(e => e.Password).IsRequired();
        builder.Property(e => e.Type).IsRequired();
        builder.Property(e => e.Name).IsRequired();
        builder.Property(e => e.CreatedAt).IsRequired();
    }
}