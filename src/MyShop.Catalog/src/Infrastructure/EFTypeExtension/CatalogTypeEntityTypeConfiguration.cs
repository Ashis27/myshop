using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyShop.Catalog.Application.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Catalog.Infrastructure.EFTypeExtension
{
    class CatalogTypeEntityTypeConfiguration : IEntityTypeConfiguration<CatalogType>
    {
        public void Configure(EntityTypeBuilder<CatalogType> builder)
        {
            builder.ToTable("CatalogTypes");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
                   .UseHiLo("catalog_type_hilo")
                   .IsRequired();

            builder.Property(cb => cb.Type)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}
