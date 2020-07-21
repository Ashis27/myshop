using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyShop.Consumer.Application.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Consumer.Infrastructure.EFTypeConfigurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<Application.Domain.User>
    {
        public void Configure(EntityTypeBuilder<Application.Domain.User> builder)
        {
            builder.ToTable("Users");

            var navigation = builder.Metadata.FindNavigation(nameof(Application.Domain.User.Address));

            // DDD Patterns comment:
            //Set as field (New since EF 1.1) to access the OrderItem collection property through its field
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasKey(p => p.UId);

            builder.Ignore(p => p.DomainEvents);

            builder.Property(p => p.FirstName)
                   .IsRequired();

            builder.Property(p => p.FirstName)
                   .IsRequired();
        }
    }
}
