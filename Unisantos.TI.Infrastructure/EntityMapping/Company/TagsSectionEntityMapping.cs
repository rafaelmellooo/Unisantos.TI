using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unisantos.TI.Domain.Entities.Company;

namespace Unisantos.TI.Infrastructure.EntityMapping.Company;

public class TagsSectionEntityMapping : IEntityTypeConfiguration<TagsSectionEntity>
{
    public void Configure(EntityTypeBuilder<TagsSectionEntity> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.Title).IsRequired();
    }
}