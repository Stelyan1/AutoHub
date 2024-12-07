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
                   .HasForeignKey(m => m.BrandId)
                   .OnDelete(DeleteBehavior.Cascade);
                   

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
                    BrandId = new Guid("148C36A7-5930-4CE3-8BB0-658FD772C423")
                },

                new Model()
                {
                    Id = Guid.NewGuid(),
                    Name = "Mercedes-Benz C63 AMG",
                    Year = 2012,
                    HorsePower = 487,
                    FuelType = "Petrol",
                    GasConsumption = 13.2,
                    Description = "The output of the AMG 6.3-litre V8 engine is unchanged at 336 kW (457 hp) and can be increased to a maximum of 358 kW (487 hp) with the optional AMG Performance package. Agility, grip and ride comfort have been enhanced as a result of numerous measures to optimise the AMG sports suspension.",
                    ImageUrl = "https://cdn.dealeraccelerate.com/bagauction/1/11/153/1920x1440/2012-mercedes-benz-c63-amg-black-series",
                    BrandId = new Guid("C6D8E95B-D57F-4B15-BC7D-2F1AD38A17A9")
                },

                new Model()
                {
                    Id = Guid.NewGuid(),
                    Name = "Lamborghini Aventador ",
                    Year = 2016,
                    HorsePower = 770,
                    FuelType = "Petrol",
                    GasConsumption = 15.1,
                    Description = "Lamborghini created the Aventador SVJ to embrace challenges head-on, combining cutting-edge technology with extraordinary design, while always refusing to compromise. In a future driven by technology, it’s easy to lose the genuine thrill of driving. But in the future shaped by Lamborghini, this won’t be left behind, because there will always be a driver behind the wheel. ",
                    ImageUrl = "https://supercars.bg/wp-content/uploads/2018/08/Lamborghini-Aventador-SV-R-Nurburgring21.jpg",
                    BrandId = new Guid("60CABA99-72AA-421A-A569-7CB41423A3EE")
                },
            };

            return models;
        }
    }
}
