using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unisantos.TI.Domain.Entities.Token;

namespace Unisantos.TI.Infrastructure.EntityMapping.Token;

public class TokenEntityMapping : IEntityTypeConfiguration<TokenEntity>
{
    public void Configure(EntityTypeBuilder<TokenEntity> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.Value).IsRequired();
        builder.Property(e => e.JwtId).IsRequired();
        builder.Property(e => e.Type).IsRequired();
        builder.Property(e => e.IsUsed).HasDefaultValue(false);
        builder.Property(e => e.IsRevoked).HasDefaultValue(false);
        builder.Property(e => e.ExpiryAt).IsRequired();

        builder.HasOne(e => e.User).WithMany(e => e.Tokens).HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.ClientCascade);
    }
}