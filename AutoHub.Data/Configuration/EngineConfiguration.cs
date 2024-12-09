using AutoHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Data.Configuration
{
    using static AutoHub.Common.EntityValidationConstants.Engine;
    public class EngineConfiguration : IEntityTypeConfiguration<Engine>
    {
        public void Configure(EntityTypeBuilder<Engine> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Brand)
                   .WithMany(b => b.Engines)
                   .HasForeignKey(e => e.BrandId);



            builder.HasOne(e => e.Model)
                   .WithMany(m => m.Engines)
                   .HasForeignKey(e => e.ModelId);
                   
                   

            builder.Property(e => e.Id)
                   .IsRequired();

            builder.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(EngineNameMaxLength);

            builder.Property(e => e.Cylinders)
                   .IsRequired();

            builder.Property(e => e.ValvetrainDriveSystem)
                   .IsRequired()
                   .HasMaxLength(ValveTrainMaxLength);

            builder.Property(e => e.PowerOutput)
                   .IsRequired()
                   .HasMaxLength(PowerOutputMaxLength);

            builder.Property(e => e.Torque)
                   .IsRequired()
                   .HasMaxLength(TorqueMaxLength);

            builder.Property(e => e.Rpm)
                   .IsRequired()
                   .HasMaxLength(RpmMaxLength);

            builder.Property(e => e.ImageUrl)
                   .IsRequired();

            builder.Property(e => e.YearsProduction)
                   .IsRequired()
                   .HasMaxLength(YearsProductionMaxLength);

            builder.HasData(this.SeedEngine());
        }

        private IEnumerable<Engine> SeedEngine()
        {
            
            IEnumerable<Engine> engines = new List<Engine>()
            {

                new Engine()
                {
                    Id = Guid.NewGuid(),
                    Name = "B58",
                    BrandId = new Guid("148C36A7-5930-4CE3-8BB0-658FD772C423"),
                    ModelId = new Guid("79A4D785-273D-488D-B7FE-F9AB58C405BF"),
                    Cylinders = 6,
                    ValvetrainDriveSystem = "Chain",
                    PowerOutput = "322-385hp",
                    Torque = "450-500Nm",
                    Rpm = "7000",
                    ImageUrl = "https://fsc.codes/cdn/shop/articles/BMW-B58.jpg?v=1703197166",
                    YearsProduction = "2015-Present"
                }
            };

            return engines;
        }
    }
}
