using AutoHub.Data;
using AutoHub.Data.Models;
using AutoHub.Web.ViewModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoHub.Controllers
{
    public class EngineController : Controller
    {
        private readonly AutoHubDbContext dbContext;

        public EngineController(AutoHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var engines = dbContext.Engines.ToList();
            return View(engines);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            var brands = dbContext.Brands.ToList();
            var models = dbContext.Models.ToList();

            var engineViewModel = new EngineViewModel
            {
                Brands = brands,
                Models = models
            };
            return View(engineViewModel);
        }

        [HttpPost]
        public IActionResult Create(EngineViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var newEngine = new Engine
                {
                    Name = model.Name,
                    BrandId = model.Manufacturer,
                    ModelId = model.Application,
                    Cylinders = model.Cylinders,
                    ValvetrainDriveSystem = model.ValveTrainDriveSystem,
                    PowerOutput = model.PowerOutput,
                    Torque = model.Torque,
                    Rpm = model.Rpm,
                    ImageUrl = model.ImageUrl,
                    YearsProduction = model.YearsProduction
                };

                dbContext.Engines.Add(newEngine);
                dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            model.Brands = dbContext.Brands.ToList();
            model.Models = dbContext.Models.ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Details(string id) 
        {
            bool isValid = Guid.TryParse(id, out Guid guidId);

            if (!isValid) 
            {
                return RedirectToAction(nameof(Index));
            }
            Engine? engines = this.dbContext.Engines
                .Include(e => e.Brand)
                .Include(e => e.Model)
                .FirstOrDefault(e => e.Id == guidId);

            if (engines == null) 
            {
                return RedirectToAction(nameof(Index));
            }

            return this.View(engines);
        }
    }
}
