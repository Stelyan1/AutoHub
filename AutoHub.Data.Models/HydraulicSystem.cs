using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Data.Models
{
    public class HydraulicSystem
    {
        [Comment("Identifier of the part")]
        public Guid Id { get; set; }
        [Comment("Name of the part")]
        public string partName { get; set; } = null!;
        [Comment("Description of the part")]
        public string Description { get; set; } = null!;
        [Comment("Image of the part")]
        public string ImageUrl { get; set; } = null!;
    }
}
