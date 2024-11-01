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
                    ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fen.wikipedia.org%2Fwiki%2FLamborghini&psig=AOvVaw3CXwortwq3tXlmsmsiEvwG&ust=1730511694438000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCJDv_MiAuokDFQAAAAAdAAAAABAE"
                }
            };

            return brands;
        }
    }
}
