using AutoHub.Data;
using AutoHub.Data.Models;
using AutoHub.Infrastructure.DTOs;
using AutoHub.Infrastructure.Repositories.Interfaces;
using AutoHub.Infrastructure.Services.Interfaces;
using AutoHub.Web.ViewModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AutoHub.Controllers
{
    public class ModelController : Controller
    {
        private readonly IModelService _modelService;
        private readonly IBrandRepository _brandRepository;

        public ModelController(IModelService modelService,IBrandRepository brandRepository)
        {
            _modelService = modelService;
            _brandRepository = brandRepository;
        }

        [HttpGet]
        public async Task <IActionResult> Index()
        {
            var models = await _modelService.GetAllModelsAsync();

            return View(models);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create() 
        {
            var brands = await _brandRepository.GetAllAsync();

            var brandViewModel = new ModelViewModel
            {
                Brands = brands.ToList()
            };
            return View(brandViewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(ModelViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                var modelDto = new ModelDto
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
               
                await _modelService.AddModelAsync(modelDto);
                
                return RedirectToAction(nameof(Index));
            }

            model.Brands = (await _brandRepository.GetAllAsync()).ToList();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id) 
        {
            bool isValid = Guid.TryParse(id, out Guid guidId);
            if (!isValid) 
            {
                return this.RedirectToAction(nameof(Index));
            }

            var model = await _modelService.GetModelByIdAsync(guidId);

            if (model == null) 
            {
                return RedirectToAction(nameof(Index));
            }
                
                
            return this.View(model);
        }
    }
}
