using AutoHub.Data;
using AutoHub.Data.Models;
using AutoHub.Infrastructure.DTOs;
using AutoHub.Infrastructure.Repositories.Interfaces;
using AutoHub.Infrastructure.Services.Interfaces;
using AutoHub.Web.ViewModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoHub.Controllers
{
    public class GearboxController : Controller
    {
        private readonly IGearboxService _gearboxService;
        private readonly IBaseRepository<Model> _modelRepository;

        public GearboxController(IGearboxService gearboxService, IBaseRepository<Model> modelRepository)
        {
            _gearboxService = gearboxService;
            _modelRepository = modelRepository;    
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var gearboxes = await _gearboxService.GetAllGearboxesAsync();
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
                var gearboxDto = new GearboxDto
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

                await _gearboxService.AddGearboxAsync(gearboxDto);
            
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

            var gearbox = await _gearboxService.GetGearboxesByIdAsync(guidId);
            
            if (gearbox == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return this.View(gearbox);
        }
    }
}
