using AutoHub.Data;
using AutoHub.Data.Models;
using AutoHub.Web.ViewModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AutoHub.Controllers
{
    public class ModelController : Controller
    {
        private readonly AutoHubDbContext dbContext;

        public ModelController(AutoHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Model> allModels = this.dbContext
                .Models
                .ToList();

            return View(allModels);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create() 
        {
            var brands = dbContext.Brands.ToList();

            var modelViewModel = new ModelViewModel
            {
                Brands = brands
            };

            return View(modelViewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(ModelViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                var newModel = new Model
                {
                    Name = model.Name,
                    Year = model.Year,
                    HorsePower = model.HorsePower,
                    FuelType = model.FuelType,
                    GasConsumption = model.GasConsumption,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl,
                    BrandId = model.SelectedBrand
                };

                dbContext.Models.Add(newModel);
                dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            model.Brands = dbContext.Brands.ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Details(string id) 
        {
            bool isValid = Guid.TryParse(id, out Guid guidId);
            if (!isValid) 
            {
                return this.RedirectToAction(nameof(Index));
            }

            Model? model = this.dbContext
                .Models
                .Include(m => m.Brand)
                .FirstOrDefault(m => m.Id == guidId);

            if (model == null) 
            {
                return RedirectToAction(nameof(Index));
            }
                
                
            return this.View(model);
        }
    }
}
