using AutoHub.Infrastructure.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Infrastructure.Models
{
    public class SearchPagination
    {
        public string? SearchQuery { get; set; }

        public int CurrentPage { get; set; } = 1;
        public int EntitiesPerPage = 3;
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int PageCount { get; set; }

        public IEnumerable<BrandDto> Brands { get; set; } = new List<BrandDto>();
        public IEnumerable<ModelDto> Models { get; set; } = new List<ModelDto>();
        public IEnumerable<EngineDto> Engines { get; set; } = new List<EngineDto>();
        public IEnumerable<GearboxDto> GearBoxes { get; set; } = new List<GearboxDto>();
        public IEnumerable<ProductDto> Products { get; set; } = new List<ProductDto>();
        public IEnumerable<HydraulicSystemDto> hydraulicSystems { get; set; } = new List<HydraulicSystemDto>();
    }
}
