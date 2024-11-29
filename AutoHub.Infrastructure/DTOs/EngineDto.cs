using AutoHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Infrastructure.DTOs
{
    public class EngineDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid BrandId { get; set; }
        public string BrandName { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public Guid ModelId { get; set; }
        public string ModelName { get; set; }
        public IEnumerable<Model> Models { get; set; }
        public int Cylinders {  get; set; }
        public string ValveTrainDriveSystem { get; set; }
        public string PowerOutput {  get; set; }
        public string Torque {  get; set; }
        public string Rpm { get; set; }
        public string ImageUrl { get; set; }
        public string YearsProduction { get; set; }
    }
}
