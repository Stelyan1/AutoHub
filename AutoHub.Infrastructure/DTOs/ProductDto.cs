using AutoHub.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Infrastructure.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string Manufacturer { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public string CarsApplication {  get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string SellerId { get; set; }
        public string SellerName { get; set; }
        public IdentityUser Seller {  get; set; }
        public bool IsSeller { get; set; }
        public bool HasBought { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime AddedOn { get; set; }
    }
}
