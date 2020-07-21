using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyShop.Identity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Identity.Infrastructure.EFTypeConfiguration
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                    .UseHiLo("Identity_Hilo")
                    .IsRequired(true);

            //builder.Ignore(i => i.FirstName);
            //builder.Ignore(i => i.LastName);
            builder.Ignore(i => i.DomainEvents);
        }
    }
}
