using AutoHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Infrastructure.DTOs
{
    public class ModelDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int HorsePower { get; set; }
        public string FuelType { get; set; }
        public double GasConsumption { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid BrandId { get; set; }
        public string BrandName { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
    }
}
