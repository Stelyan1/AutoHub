using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Infrastructure.DTOs
{
    public class BrandDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FoundedBy { get; set; }
        public DateTime FoundedDate { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
