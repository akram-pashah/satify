using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    internal sealed class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder
                .HasKey(ci => new { ci.CartId, ci.ProductId });

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id).ValueGeneratedOnAdd();
        }
    }
}
