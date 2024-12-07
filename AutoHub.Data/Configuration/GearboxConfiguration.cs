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
    using static AutoHub.Common.EntityValidationConstants.Gearbox;
    public class GearboxConfiguration : IEntityTypeConfiguration<Gearbox>
    {
      
        public void Configure(EntityTypeBuilder<Gearbox> builder)
        {
            builder.HasKey(gb => gb.Id);

            builder.HasOne(gb => gb.Model)
                   .WithMany(m => m.Gearboxes)
                   .HasForeignKey(gb => gb.Application);

            builder.Property(gb => gb.Id)
                   .IsRequired();

            builder.Property(gb => gb.Name)
                   .IsRequired()
                   .HasMaxLength(GearboxNameMaxLength);

            builder.Property(gb => gb.TransmissionType)
                   .IsRequired()
                   .HasMaxLength(TransmissionTypeMaxLength);

            builder.Property(gb => gb.YearsProduced)
                   .IsRequired()
                   .HasMaxLength(YearsProducedMaxLength);

            builder.Property(gb => gb.Manufacturer)
                   .IsRequired()
                   .HasMaxLength(ManufacturerMaxLength);

            builder.Property(gb => gb.Description)
                   .IsRequired()
                   .HasMaxLength(DescriptionMaxLength);

            builder.Property(gb => gb.ImageUrl)
                   .IsRequired();

            builder.HasData(this.SeedGearbox());
        }

        private IEnumerable<Gearbox> SeedGearbox() 
        {

            IEnumerable<Gearbox> gearboxes = new List<Gearbox>() 
            {
                new Gearbox()
                {
                    Id = Guid.NewGuid(),
                    Name = "ZF 8HP Transmission",
                    TransmissionType = "Automatic",
                    Speeds = 8,
                    YearsProduced = "2008-Present",
                    Manufacturer = "ZF Friedrichshafen",
                    Description = "The ZF 8HP transmission is ZF Friedrichshafen AG's trademark name for its 8-speed automatic transmission models for longitudinal engine applications. The name is short for 8-speed transmission with hydraulic converter and planetary gearsets. Designed and first built by ZF's subsidiary in Saarbrücken, Germany, it debuted in 2008 on the BMW 7 Series (F01) 760Li sedan fitted with the V12 engine. BMW remains a major customer for the transmission.",
                    ImageUrl = "https://hips.hearstapps.com/hmg-prod/images/zf-8-speed-trans-1538511984.jpg",
                    Application = new Guid("79A4D785-273D-488D-B7FE-F9AB58C405BF")
                }
            };
            return gearboxes;
        }
    }
}
