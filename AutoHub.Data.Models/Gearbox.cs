using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Data.Models
{
    public class Gearbox
    {

        public Gearbox()
        {
            this.Id = Guid.NewGuid();
        }

        [Comment("Identification of the gearbox")]
        public Guid Id { get; set; }

        [Comment("Name of the gearbox")]
        public string Name { get; set; } = null!;

        [Comment("Type of the transmission manual or automatic")]
        public string TransmissionType { get; set; } = null!;

        [Comment("How much speeds does it have from 5 to 8")]
        public int Speeds { get; set; } 

        [Comment("Years produced")]
        public string YearsProduced { get; set; } = null!;

        [Comment("Manufacturer of the gearbox")]
        public string Manufacturer { get; set; } = null!;

        [Comment("Description about the gearbox")]
        public string Descritpion { get; set; } = null!;

        [Comment("Image of the gearbox")]
        public string ImageUrl { get; set; } = null!;

        [Comment("Model vehicle that has it")]
        public Guid Application {  get; set; }
        public virtual Model Model { get; set; } = null!;

    }
}
