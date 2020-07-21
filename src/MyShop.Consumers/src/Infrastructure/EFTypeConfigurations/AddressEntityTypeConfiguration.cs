using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyShop.Consumer.Application.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Consumer.Infrastructure.EFTypeConfigurations
{
    public class AddressEntityTypeConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .UseHiLo("Adress_Id")
                   .IsRequired();

            builder.Ignore(p => p.DomainEvents);

            builder.Property(p => p.City)
                   .IsRequired();

            builder.Property(p => p.State)
                   .IsRequired();

            builder.Property(p => p.Country)
            .IsRequired();

            builder.Property(p => p.ZipCode)
                   .IsRequired();

            builder.Property(p => p.Street)
            .IsRequired();

            builder.Property<int>("UserId").IsRequired();
        }
    }
}
