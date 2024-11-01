using AutoHub.Data;
using AutoHub.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoHub.Controllers
{
    public class BrandController : Controller
    {
        private readonly AutoHubDbContext dbContext;

        public BrandController(AutoHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Brand> allBrands = this.dbContext
                .Brands
                .ToList();

            return View(allBrands);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Brand brand) 
        {
            return View(brand);
        }
    }
}
