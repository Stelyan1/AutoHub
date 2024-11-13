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
    public class ProductClientConfiguration : IEntityTypeConfiguration<ProductClient>
    {
        public void Configure(EntityTypeBuilder<ProductClient> builder)
        {
            builder.HasKey(pc => new { pc.ProductId, pc.ClientId });

            builder.HasOne(pc => pc.Product)
                   .WithMany()
                   .HasForeignKey(pc => pc.ProductId)
                   .IsRequired();

            builder.HasOne(pc => pc.Client)
                   .WithMany()
                   .HasForeignKey(pc => pc.ClientId)
                   .IsRequired();

            builder.Property(pc => pc.HasBought)
                   .IsRequired();
        }
    }
}
