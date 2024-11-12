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
    using static AutoHub.Common.EntityValidationConstants.Category;

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(CategoryNameMaxLength);

            builder.HasData(this.SeedCategories());
        }

        private IEnumerable<Category> SeedCategories() 
        {
            IEnumerable<Category> categories = new List<Category>()
            {
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Motor Oil"
                },

                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Filters"
                },

                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Steering System"
                },

                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Braking System"
                },

                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Engine Parts"
                },

                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Cooling System"
                }
            };
            return categories;
        }
    }
}
