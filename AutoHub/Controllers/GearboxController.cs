using AutoHub.Data;
using AutoHub.Data.Models;
using AutoHub.Web.ViewModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoHub.Controllers
{
    public class GearboxController : Controller
    {
        private readonly AutoHubDbContext dbContext;

        public GearboxController(AutoHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var gearBoxes = this.dbContext
                .Gearboxes.ToList();

            return View(gearBoxes);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create() 
        {
            var modelApplication = this.dbContext.Models.ToList();

            var gearboxViewModel = new GearboxViewModel 
            { 
                Models = modelApplication 
            };

            return View(gearboxViewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(GearboxViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                var newGearbox = new Gearbox
                {
                    Name = model.Name,
                    TransmissionType = model.TransmissionType,
                    Speeds = model.Speeds,
                    YearsProduced = model.YearsProduced,
                    Manufacturer = model.Manufacturer,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl,
                    Application = model.Application
                };

                dbContext.Gearboxes.Add(newGearbox);
                dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

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

            Gearbox? gearbox = this.dbContext
                .Gearboxes
                .Include(g => g.Model)
                .FirstOrDefault(g => g.Id == guidId);
            
            if (gearbox == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return this.View(gearbox);
        }
    }
}
