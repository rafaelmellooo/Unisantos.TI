using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unisantos.TI.Domain.Entities.Company;

namespace Unisantos.TI.Infrastructure.EntityMapping.Company;

public class RateEntityMapping : IEntityTypeConfiguration<RateEntity>
{
    public void Configure(EntityTypeBuilder<RateEntity> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.Rate).IsRequired();
        builder.Property(e => e.Comment).IsRequired();

        builder.HasOne(e => e.Company).WithMany(e => e.Rates).HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.ClientCascade);

        builder.HasOne(e => e.User).WithMany(e => e.Rates).HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.ClientCascade);
    }
}