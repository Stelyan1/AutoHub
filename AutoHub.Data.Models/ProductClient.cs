using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Data.Models
{
    public class ProductClient
    {
        public ProductClient()
        {
            this.ProductId = Guid.NewGuid();
        }

        [Comment("Identifier of the product")]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        [Comment("Identifier of the client")]
        public string ClientId { get; set; }
        public IdentityUser Client { get; set; }
    }
}
