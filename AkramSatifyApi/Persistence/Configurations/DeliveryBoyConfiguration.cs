﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    internal sealed class DeliveryBoyConfiguration : IEntityTypeConfiguration<DeliveryBoy>
    {
        public void Configure(EntityTypeBuilder<DeliveryBoy> builder)
        {
            
        }
    }
}
