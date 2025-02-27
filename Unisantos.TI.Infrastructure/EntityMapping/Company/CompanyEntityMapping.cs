﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unisantos.TI.Domain.Entities.Company;

namespace Unisantos.TI.Infrastructure.EntityMapping.Company;

public class CompanyEntityMapping : IEntityTypeConfiguration<CompanyEntity>
{
    public void Configure(EntityTypeBuilder<CompanyEntity> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.Name).IsRequired();
        builder.Property(e => e.Description).IsRequired().HasMaxLength(500);
        builder.Property(e => e.Phone).HasMaxLength(15).IsRequired();
        builder.Property(e => e.Instagram);
        builder.Property(e => e.Facebook);
        builder.Property(e => e.Rating);
        builder.Property(e => e.ImageUrl);
        builder.Property(e => e.ImagePreviewUrl);

        builder
            .HasOne(e => e.Address)
            .WithOne(e => e.Company)
            .HasForeignKey<CompanyEntity>(e => e.AddressId)
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasOne(e => e.Admin)
            .WithMany(e => e.Company)
            .HasForeignKey(e => e.AdminId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(e => e.Tags)
            .WithMany(e => e.Companies)
            .UsingEntity(
                "CompanyTag",
                l => l.HasOne(typeof(TagEntity)).WithMany().OnDelete(DeleteBehavior.Cascade),
                r => r.HasOne(typeof(CompanyEntity)).WithMany().OnDelete(DeleteBehavior.Cascade)
            );
    }
}