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
    using static AutoHub.Common.EntityValidationConstants.Product;
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Seller)
                   .WithMany()
                   .HasForeignKey(p => p.SellerId)
                   .IsRequired();

            builder.HasOne(p => p.Category)
                   .WithMany()
                   .HasForeignKey(p => p.CategoryId)
                   .IsRequired();


            builder.Property(p => p.ProductName)
                   .IsRequired()
                   .HasMaxLength(ProductNameMaxLength);

            builder.Property(p => p.Manufacturer)
                   .IsRequired()
                   .HasMaxLength(ManufacturerMaxLength);

            builder.Property(p => p.CarsApplication)
                   .IsRequired()
                   .HasMaxLength(CarsApplicationMaxLength);

            builder.Property(p => p.Description)
                   .IsRequired()
                   .HasMaxLength(DescriptionMaxLength);

            builder.Property(p => p.Price)
                   .IsRequired();

            builder.Property(p => p.ImageUrl)
                   .IsRequired();

            builder.Property(p => p.AddedOn)
                   .IsRequired();

            builder.Property(p => p.IsDeleted)
                   .IsRequired();
        }
    }
}
