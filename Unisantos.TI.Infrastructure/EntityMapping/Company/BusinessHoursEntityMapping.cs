using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unisantos.TI.Domain.Entities.Company;

namespace Unisantos.TI.Infrastructure.EntityMapping.Company;

public class BusinessHoursEntityMapping : IEntityTypeConfiguration<BusinessHoursEntity>
{
    public void Configure(EntityTypeBuilder<BusinessHoursEntity> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.OpeningTime).IsRequired();
        builder.Property(e => e.ClosingTime).IsRequired();
        builder.Property(e => e.DayOfWeek).IsRequired();

        builder.HasOne(e => e.Company).WithMany(e => e.BusinessHours).HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}