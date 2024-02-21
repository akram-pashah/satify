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
    internal sealed class UserOfferConfiguration : IEntityTypeConfiguration<UserOffer>
    {
        public void Configure(EntityTypeBuilder<UserOffer> builder)
        {
            builder
                .HasKey(uo => new { uo.UserId, uo.OfferId });

            builder
                .HasOne(uo => uo.User)
                .WithMany(u => u.UserOffers)
                .HasForeignKey(uo => uo.UserId);

            builder
                .HasOne(uo => uo.Offer)
                .WithMany()
                .HasForeignKey(uo => uo.OfferId);
        }
    }
}
