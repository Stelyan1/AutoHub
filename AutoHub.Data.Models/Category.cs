using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.Id = Guid.NewGuid();
        }

        [Comment("Identifier of the category")]
        public Guid Id { get; set; }

        [Comment("Name of the category")]
        public string Name { get; set; }

        [Comment("Collection of products to the given category")]
        public virtual ICollection<Product> Products { get; set; }
              = new HashSet<Product>();
    }
}
