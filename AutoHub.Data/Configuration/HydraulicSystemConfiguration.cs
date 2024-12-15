using AutoHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Data.Configuration
{
    using static Common.EntityValidationConstants.HydaraulicSystem;

    public class HydraulicSystemConfiguration : IEntityTypeConfiguration<HydraulicSystem>
    {

        public void Configure(EntityTypeBuilder<HydraulicSystem> builder)
        {
            builder.HasKey(p => p.Id);

            builder
                .Property(p => p.partName)
                .IsRequired()
                .HasMaxLength(PartNameMaxLength);

            builder
                .Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(DescriptionMaxLength);

            builder
                .Property(p => p.ImageUrl)
                .IsRequired();
        }
    }
}
