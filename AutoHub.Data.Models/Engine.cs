using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Data.Models
{
    public class Engine
    {
        public Engine()
        {
            this.Id = Guid.NewGuid();
        }

        [Comment("Identifier of engine")]
        public Guid Id { get; set; }

        [Comment("Name of engine")]
        public string Name { get; set; } = null!;

        [Comment("FK Manufacturer of engine")]
        public Guid BrandId { get; set; } 
        public Brand Brand { get; set; } = null!;

        [Comment("Cylinder of engine")]
        public string Cylinders { get; set; } = null!;

        [Comment("Chain")]
        public string ValvetrainDriveSystem {  get; set; } = null!;

        [Comment("Identifier of engine")]
        public string PowerOutput { get; set; } = null!;

        [Comment("Torque of engine")]
        public string Torque { get; set; } = null!;

        [Comment("Maximum output of engine")]
        public string Rpm { get; set; } = null!;

        [Comment("Image of engine")]
        public string ImageUrl { get; set; } = null!;

        [Comment("Date started and ended of engine")]
        public string YearsProduction { get; set; } = null!;

        [Comment("Foreign Key to model")]
        public Guid ModelId { get; set; } 
        public Model Model { get; set; } = null!;
    }
}
