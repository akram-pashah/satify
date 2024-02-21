using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static Domain.Helpers.Enums;

namespace Persistence.Configurations
{
    internal sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);

            builder
                .HasOne(o => o.Address)
                .WithMany()
                .HasForeignKey(o => o.AddressId);

            builder
                .HasOne(o => o.Seller)
                .WithMany()
                .HasForeignKey(o => o.SellerId);

            builder
                .Property(o => o.Status)
                .HasConversion(
                    status => (int)status,
                    value => (OrderStatus)value);

            builder
                .Property(o => o.PaymentStatus)
                .HasConversion(
                    status => (int)status,
                    value => (PaymentStatus)value);

            builder
                .HasOne(o => o.DeliveryBoy)
                .WithMany(d => d.Orders)
                .HasForeignKey(o => o.DeliveryBoyId);
        }
    }
}
