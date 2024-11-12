using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Data.Models
{
    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid();
        }

        [Comment("Identifier of the product")]
        public Guid Id { get; set; }

        [Comment("Name of the product")]
        public string ProductName { get; set; }

        [Comment("Name of the manufacturer")]
        public string Manufacturer { get; set; }

        [Comment("Cars that product can be used for")]
        public string CarsApplication { get; set; }

        [Comment("Description about the product")]
        public string Description { get; set; }

        [Comment("Price of the product")]
        [Range(1.00, 2500.00)]
        public decimal Price { get; set; }

        [Comment("Image of the product")]
        public string ImageUrl { get; set; }

        [Comment("Identifier of the Seller")]
        public string SellerId { get; set; }
        public IdentityUser Seller { get; set; }

        [Comment("Date the product was added")]
        public DateTime AddedOn { get; set; }

        [Comment("Identifier of the category")]
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Comment("Bool to check if the product is deleted")]
        public bool IsDeleted { get; set; } = false;

        [Comment("Products and clients")]
        public virtual ICollection<ProductClient> ProductsClients { get; set;} 
            = new HashSet<ProductClient>();
    }
}
