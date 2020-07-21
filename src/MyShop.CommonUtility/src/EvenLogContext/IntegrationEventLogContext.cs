using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyShop.CommonUtility.EvenLogContext.Domain;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MyShop.CommonUtility.EvenLogContext
{
    public class IntegrationEventLogContext : DbContext
    {
        public IntegrationEventLogContext(DbContextOptions<IntegrationEventLogContext> options) : base(options)
        {

        }

        public DbSet<IntegrationEventLogEntry> IntegrationEventLogs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConfigureIntegrationEventLogEntry());
        }

        private class ConfigureIntegrationEventLogEntry : IEntityTypeConfiguration<IntegrationEventLogEntry>
        {
            public void Configure(EntityTypeBuilder<IntegrationEventLogEntry> builder)
            {
                builder.ToTable("IntegrationEventLog");

                builder.HasKey(e => e.EventId);

                builder.Property(e => e.EventId)
                .IsRequired();

                builder.Property(e => e.Content)
                    .IsRequired();

                builder.Property(e => e.CreatedAt)
                    .IsRequired();

                builder.Property(e => e.State)
                    .IsRequired();

                builder.Property(e => e.EventTypeName)
                    .IsRequired();
            }
        }
    }
}
