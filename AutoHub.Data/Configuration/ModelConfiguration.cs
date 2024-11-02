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
    using static AutoHub.Common.EntityValidationConstants.Model;

    public class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            //Relation
            builder.HasKey(m => m.Id);

            builder.HasOne(m => m.Brand)
                   .WithMany(b => b.Models)
                   .HasForeignKey(m => m.BrandId);

            //Initialize
            builder.Property(m => m.Id)
                   .IsRequired();

            builder.Property(m => m.Name)
                   .IsRequired()
                   .HasMaxLength(ModelNameMaxLength);

            builder.Property(m => m.Year)
                   .IsRequired();

            builder.Property(m => m.HorsePower)
                   .IsRequired();

            builder.Property(m => m.FuelType)
                   .IsRequired()
                   .HasMaxLength(FuelTypeMaxLength);

            builder.Property(m => m.GasConsumption)
                   .IsRequired()
                   .HasColumnType("decimal(5, 2)");

            builder.Property(m => m.Description)
                   .IsRequired()
                   .HasMaxLength(DescriptionMaxLength);

            builder.Property(m => m.ImageUrl)
                   .IsRequired();
        }
    }
}
