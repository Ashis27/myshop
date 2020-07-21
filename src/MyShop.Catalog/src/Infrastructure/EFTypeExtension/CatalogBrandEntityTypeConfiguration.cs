using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyShop.Catalog.Application.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Catalog.Infrastructure.EFTypeExtension
{
    class CatalogBrandEntityTypeConfiguration: IEntityTypeConfiguration<CatalogBrand>
    {
        public void Configure(EntityTypeBuilder<CatalogBrand> builder)
        {
            builder.ToTable("CatalogBrands");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
                   .UseHiLo("catalog_brand_hilo")
                   .IsRequired();

            builder.Property(cb => cb.Brand)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}
