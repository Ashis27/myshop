using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyShop.Orders.Application.Domain;
using MyShop.Orders.Infrastructure;

namespace Ordering.Infrastructure.EntityConfigurations
{
    class BuyerEntityTypeConfiguration
        : IEntityTypeConfiguration<Buyer>
    {
        public void Configure(EntityTypeBuilder<Buyer> buyerConfiguration)
        {
            buyerConfiguration.ToTable("buyers", OrderingContext.DEFAULT_SCHEMA);

            buyerConfiguration.HasKey(b => b.Id);

            buyerConfiguration.Ignore(b => b.DomainEvents);

            buyerConfiguration.Property(b => b.Id)
                .UseHiLo("buyerseq", OrderingContext.DEFAULT_SCHEMA);

            buyerConfiguration.Property(b => b.UserId)
                .HasMaxLength(200)
                .IsRequired();

            buyerConfiguration.HasIndex("UserId")
              .IsUnique(true);

            buyerConfiguration.Property(b => b.Name);

            buyerConfiguration.HasMany(b => b.PaymentMethods)
               .WithOne()
               .HasForeignKey("BuyerId")
               .OnDelete(DeleteBehavior.Cascade);

            var navigation = buyerConfiguration.Metadata.FindNavigation(nameof(Buyer.PaymentMethods));

            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
