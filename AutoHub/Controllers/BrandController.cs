using AutoHub.Data;
using AutoHub.Data.Models;
using AutoHub.Web.ViewModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

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
        [Authorize]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(BrandViewModel brandModel) 
        {
            if (!ModelState.IsValid) 
            {
                return View(brandModel);
            }

            bool isFoundedDateValid = DateTime
                 .TryParseExact(brandModel.FoundedDate, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                 out DateTime foundedDate);

            if (!isFoundedDateValid)
            {
                this.ModelState.AddModelError(nameof(brandModel.FoundedDate), "The date founded must be the following format MM/dd/yyyy");
                return this.View(brandModel);
            }

            Brand brand = new Brand()
            {
                Name = brandModel.Name,
                FoundedBy = brandModel.FoundedBy,
                FoundedDate = foundedDate,
                Description = brandModel.Description,
                ImageUrl = brandModel.ImageUrl
            };


            this.dbContext.Brands.Add(brand);
            this.dbContext.SaveChanges();

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(string id) 
        {
            bool isIdValid = Guid.TryParse(id, out Guid guidId);
            if (!isIdValid) 
            {
                return this.RedirectToAction(nameof(Index));
            }

            Brand? brand = this.dbContext
                .Brands.FirstOrDefault(b => b.Id == guidId);

            if (brand == null) 
            {
                return RedirectToAction(nameof(Index));
            }

            return this.View(brand);
        }
    }
}
