using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unisantos.TI.Domain.Entities.Company;

namespace Unisantos.TI.Infrastructure.EntityMapping.Company;

public class CompanyTypeEntityMapping : IEntityTypeConfiguration<CompanyTypeEntity>
{
    public void Configure(EntityTypeBuilder<CompanyTypeEntity> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Description).IsRequired().HasMaxLength(500);
    }
}