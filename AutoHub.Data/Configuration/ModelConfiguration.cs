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

            builder.HasData(this.SeedModels());
        }

        private IEnumerable<Model> SeedModels() 
        {
            IEnumerable<Model> models = new List<Model>() 
            {
                new Model()
                {
                    Id = Guid.NewGuid(),
                    Name = "BMW 340i Sedan",
                    Year = 2016,
                    HorsePower = 320,
                    FuelType = "Petrol",
                    GasConsumption = 7.2,
                    Description = "The BMW 340i Sedan offers a powerful engine, refined handling, and luxury features.",
                    ImageUrl = "https://i.pinimg.com/736x/ef/06/9e/ef069ec0aecb59c7858a19508b691b85.jpg",
                    BrandId = new Guid("C5BFF384-4440-480A-B62F-E544EA4B8B05")
                }
            };

            return models;
        }
    }
}
