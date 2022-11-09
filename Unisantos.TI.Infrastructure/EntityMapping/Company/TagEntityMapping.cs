using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unisantos.TI.Domain.Entities.Company;

namespace Unisantos.TI.Infrastructure.EntityMapping.Company;

public class TagEntityMapping : IEntityTypeConfiguration<TagEntity>
{
    public void Configure(EntityTypeBuilder<TagEntity> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.Name).IsRequired();

        builder.HasOne(e => e.TagsSection).WithMany(e => e.Tags).HasForeignKey(e => e.TagsSectionId)
            .OnDelete(DeleteBehavior.ClientCascade);
    }
}