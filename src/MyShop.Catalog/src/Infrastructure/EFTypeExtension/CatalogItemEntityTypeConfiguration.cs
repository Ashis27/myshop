using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyShop.Catalog.Application.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Catalog.Infrastructure.Extension
{
    class CatalogItemEntityTypeConfiguration : IEntityTypeConfiguration<CatalogItem>
    {
        public void Configure(EntityTypeBuilder<CatalogItem> builder)
        {
            builder.ToTable("CatalogItems");

            builder.HasKey(ci => ci.Id);

            builder.Ignore(ci => ci.DomainEvents);

            builder.Property(ci => ci.Id)
                   .UseHiLo("catalog_hilo")
                   .IsRequired();

            builder.Property(ci => ci.Name)
                   .IsRequired(true)
                   .HasMaxLength(50);

            builder.Property(ci => ci.Price)
                   .IsRequired(true)
                   .HasColumnType("decimal(18,4)");

            builder.Property(ci => ci.PictureFileName)
                   .IsRequired(false);

            builder.Property<int>("CatalogStatusId").IsRequired();

            builder.HasOne(p => p.CatalogBrand)
                           .WithMany()
                           .IsRequired(true)
                           .HasForeignKey(c => c.CatalogBrandId)
                           .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.CatalogType)
                           .WithMany()
                           .IsRequired(true)
                           .HasForeignKey(p => p.CatalogTypeId)
                           .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
