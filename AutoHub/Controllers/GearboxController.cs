using AutoHub.Data;
using AutoHub.Data.Models;
using AutoHub.Infrastructure.Repositories.Interfaces;
using AutoHub.Web.ViewModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoHub.Controllers
{
    public class GearboxController : Controller
    {
        private readonly IGearboxRepository _gearboxRepository;
        private readonly IBaseRepository<Model> _modelRepository;

        public GearboxController(IGearboxRepository gearboxRepository, IBaseRepository<Model> modelRepository)
        {
            _gearboxRepository = gearboxRepository;
            _modelRepository = modelRepository;    
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var gearboxes = await _gearboxRepository.GetAllAsync();
            return View(gearboxes);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create() 
        {
            var modelApplication = await _modelRepository.GetAllAsync();
            var gearboxViewModel = new GearboxViewModel
            {
                Models = modelApplication.ToList()
            };

            return View(gearboxViewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(GearboxViewModel model) 
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

                await _gearboxRepository.AddAsync(newGearbox);
                await _gearboxRepository.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            model.Models = (await _modelRepository.GetAllAsync()).ToList();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id) 
        {
            bool isValid = Guid.TryParse(id, out Guid guidId);

            if (!isValid) 
            {
                return RedirectToAction(nameof(Index));
            }

            var gearbox = await _gearboxRepository.GetByIdVerifyAsync(guidId);
            
            if (gearbox == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return this.View(gearbox);
        }
    }
}
