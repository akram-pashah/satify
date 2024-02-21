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
    internal sealed class MediaFileConfiguration : IEntityTypeConfiguration<MediaFile>
    {
        public void Configure(EntityTypeBuilder<MediaFile> builder)
        {
            builder
                .HasOne(mf => mf.Product)
                .WithMany(p => p.MediaFiles)
                .HasForeignKey(mf => mf.ProductId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
