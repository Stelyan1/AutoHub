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
    public class EngineController : Controller
    {
        private readonly IEngineService _engineService;
        private readonly IBaseRepository<Model> _modelRepository;
        private readonly IBaseRepository<Brand> _brandRepository;

        public EngineController(IEngineService engineService, IBaseRepository<Model> modelRepository, IBaseRepository<Brand> brandRepository)
        {
            _engineService = engineService;
            _modelRepository = modelRepository;
            _brandRepository = brandRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var engines = await _engineService.GetAllEnginesAsync();
            return View(engines);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create() 
        {
            var brands = await _brandRepository.GetAllAsync();
            var models = await _modelRepository.GetAllAsync();

            var engineViewModel = new EngineViewModel
            {
                Brands = brands.ToList(),
                Models = models.ToList()
            };
            return View(engineViewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(EngineViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var engineDto = new EngineDto
                {
                    Name = model.Name,
                    BrandId = model.Manufacturer,
                    ModelId = model.Application,
                    Cylinders = model.Cylinders,
                    ValveTrainDriveSystem = model.ValveTrainDriveSystem,
                    PowerOutput = model.PowerOutput,
                    Torque = model.Torque,
                    Rpm = model.Rpm,
                    ImageUrl = model.ImageUrl,
                    YearsProduction = model.YearsProduction
                };

                await _engineService.AddEngineAsync(engineDto);
                
                return RedirectToAction(nameof(Index));
            }

            model.Brands = (await _brandRepository.GetAllAsync()).ToList();
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
            
            var engines = await _engineService.GetEngineByIdAsync(guidId);

            if (engines == null) 
            {
                return RedirectToAction(nameof(Index));
            }

            return View(engines);
        }
    }
}
