using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unisantos.TI.Domain.Entities.Company;

namespace Unisantos.TI.Infrastructure.EntityMapping.Company;

public class ProductsSectionEntityMapping : IEntityTypeConfiguration<ProductsSectionEntity>
{
    public void Configure(EntityTypeBuilder<ProductsSectionEntity> builder)
    {
        builder.HasKey(e => new {e.Id, e.CompanyId});

        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.Title).IsRequired().HasMaxLength(100);

        builder.HasOne(e => e.Company).WithMany(e => e.ProductsSections).HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.ClientCascade);
    }
}