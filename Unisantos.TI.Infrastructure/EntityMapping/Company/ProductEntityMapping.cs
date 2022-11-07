using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unisantos.TI.Domain.Entities.Company;

namespace Unisantos.TI.Infrastructure.EntityMapping.Company;

public class ProductEntityMapping : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.HasKey(e => new {e.Id, e.ProductsSectionId, e.CompanyId});

        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Description).IsRequired().HasMaxLength(500);
        builder.Property(e => e.Price).IsRequired();

        builder.HasOne(e => e.ProductsSection).WithMany(e => e.Products)
            .HasForeignKey(e => new {e.ProductsSectionId, e.CompanyId}).OnDelete(DeleteBehavior.ClientCascade);
    }
}