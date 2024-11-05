using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Data.Models
{
    public class Model
    {
        public Model()
        {
            this.Id = Guid.NewGuid();
        }

        [Comment("Identifier of the model")]
        public Guid Id { get; set; }

        [Comment("Name of the model")]
        public string Name { get; set; } = null!;

        [Comment("Year the model was released")]
        public int Year { get; set; }

        [Comment("Horsepower of the vehicle")]
        public int HorsePower { get; set; }

        [Comment("Fuel type of the vehicle")]
        public string FuelType { get; set; } = null!;

        [Comment("Gas consumption per 100km")]
        [Range(4, 12)]
        public double GasConsumption { get; set; }

        [Comment("Description about the model")]
        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        [Comment("Foreign Key to Brand one model can have one brand")]
        public Guid BrandId { get; set; }
        public virtual Brand Brand { get; set; } = null!;

        [Comment("Every Brand have an engine they manufactured")]
        public virtual ICollection<Engine> Engines { get; set; }
            = new HashSet<Engine>();

    }
}
