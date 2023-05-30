using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unisantos.TI.Domain.Entities.Company;

namespace Unisantos.TI.Infrastructure.EntityMapping.Company;

public class ProductSectionEntityMapping : IEntityTypeConfiguration<ProductSectionEntity>
{
    public void Configure(EntityTypeBuilder<ProductSectionEntity> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.Title).IsRequired().HasMaxLength(100);

        builder
            .HasOne(e => e.Company)
            .WithMany(e => e.ProductSections)
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}