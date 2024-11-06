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
    using static Common.EntityValidationConstants.Brand;

    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            //Fluent API
            builder.HasKey(b => b.Id);

            builder
                .Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(BrandNameMaxLength);

            builder
                .Property(b => b.FoundedBy)
                .IsRequired()
                .HasMaxLength(FounderMaxLength);

            builder
                .Property(b => b.Description)
                .IsRequired()
                .HasMaxLength(DescriptionMaxLength);

            builder
                .Property(b => b.ImageUrl)
                .IsRequired();

            builder.HasData(this.SeedBrands());
        }

        private List<Brand> SeedBrands()
        {
            List<Brand> brands = new List<Brand>() 
            {
                new Brand()
                {
                    Name = "Lamborghini",
                    Description = "Automobili Lamborghini is an Italian manufacturer of luxury sports cars and SUVs based in Sant'Agata Bolognese. The company is owned by the Volkswagen Group through its subsidiary Audi.",
                    FoundedBy = "Ferruccio Lamborghini",
                    FoundedDate = new DateTime(1963, 05, 07),
                    ImageUrl = "https://www.brandcrowd.com/blog/wp-content/uploads/2023/05/Lamborghini-logo-1-1024x819.jpg"
                },

                new Brand()
                {
                    Name = "BMW",
                    Description = "BMW is a German company with activities covering the production and sale of motor vehicles, spare parts and accessories for motor vehicles, engineering products, as well as related services.",
                    FoundedBy = "Karl Rapp , Gustav Otto , Camillo Castiglioni , Franz Josef Pop",
                    FoundedDate = new DateTime(1916, 03, 07),
                    ImageUrl = "https://www.carmonkey.co.uk/images/logos/Bmw-logo.svg"
                },

                 new Brand()
                {
                    Name = "Mercedes-Benz",
                    Description = "Mercedes-Benz is a trademark and a company of the same name - a manufacturer of premium cars, trucks, buses and other vehicles, which is part of the German concern \"Mercedes-Benz Group\". It is one of the most recognizable car brands in the world.",
                    FoundedBy = "Karl Benz, Gottlieb Daimler, Wilhelm Maybach and Emil Jellinek",
                    FoundedDate = new DateTime(1926, 06, 28),
                    ImageUrl = "https://1000logos.net/wp-content/uploads/2018/04/Symbol-Mercedes-Benz.png"
                },
            };

            return brands;
        }
    }
}
