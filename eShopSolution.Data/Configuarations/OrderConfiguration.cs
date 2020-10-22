using eShopSolution.Data.Entities;
using eShopSolution.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace eShopSolution.Data.Configuarations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ShipName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.ShipAddress).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ShipEmail).IsRequired().HasMaxLength(50).IsUnicode(false);
            builder.Property(x => x.ShipPhoneNumber).IsRequired().HasMaxLength(11);
            builder.Property(x => x.Status).HasDefaultValue(OrderStatus.Canceled);


        }
    }
}
