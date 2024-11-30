using AutoHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Infrastructure.DTOs
{
    public class GearboxDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string TransmissionType { get; set; }
        public int Speeds { get; set; }
        public string YearsProduced { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid Application {  get; set; }
        public string ApplicationName { get; set; }
        public IEnumerable<Model> Models { get; set; }
    }
}
