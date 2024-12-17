using AutoHub.Data;
using AutoHub.Data.Models;
using AutoHub.Infrastructure.DTOs;
using AutoHub.Infrastructure.Models;
using AutoHub.Infrastructure.Repositories.Interfaces;
using AutoHub.Infrastructure.Services;
using AutoHub.Infrastructure.Services.Interfaces;
using AutoHub.Web.ViewModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace AutoHub.Controllers
{
    public class ModelController : Controller
    {
        private readonly IModelService _modelService;
        private readonly IBrandRepository _brandRepository;
        private readonly IEngineRepository _engineRepository;

        public ModelController(IModelService modelService,IBrandRepository brandRepository, IEngineRepository engineRepository)
        {
            _modelService = modelService;
            _brandRepository = brandRepository;
            _engineRepository = engineRepository;
        }

        [HttpGet]
        public async Task <IActionResult> Index(string? searchQuery, string? selectedBrand, int currentPage = 1)
        {
            
            var models = await _modelService.GetAllModelsAsync();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                models = models.Where(m => m.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(selectedBrand))
            {
                models = models.Where(m => m.BrandId.ToString() == selectedBrand);
            }

            var brands = await _brandRepository.GetAllAsync();

            int entitiesPerPage = 3;
            int totalModels = models.Count();
            var pagedModels = models.Skip((currentPage - 1) * entitiesPerPage)
                                    .Take(entitiesPerPage);

            var viewModel = new SearchPagination
            {
                Models = pagedModels.Select(m => new ModelDto
                {
                   Id = m.Id,
                   Name = m.Name,
                   Year = m.Year,
                   HorsePower = m.HorsePower,
                   FuelType = m.FuelType,
                   GasConsumption = m.GasConsumption,
                   Description = m.Description,
                   ImageUrl = m.ImageUrl,
                   BrandId = m.BrandId,
                   BrandName = m.BrandName
                }),
                SearchQuery = searchQuery,
                SelectedBrand = selectedBrand,
                Brands = brands.Select(b => new BrandDto
                {
                    Id = b.Id,
                    Name = b.Name
                }),
                CurrentPage = currentPage,
                EntitiesPerPage = entitiesPerPage,
                TotalPages = (int)Math.Ceiling((double)totalModels / entitiesPerPage)
            };

            return View(viewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete (string id)
        {
            bool isIdValid = Guid.TryParse(id, out Guid guidId);
            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            var model = await _modelService.GetModelByIdAsync(guidId);

            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var modelDto = new ModelDto
            {
                Id = model.Id,
                Name = model.Name,
                Year = model.Year,
                HorsePower = model.HorsePower,
                FuelType = model.FuelType,
                GasConsumption = model.GasConsumption,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                BrandId = model.BrandId,
                BrandName = model.BrandName
            };
            return View(modelDto);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var engines = await _modelService.GetEnginesByModelIdAsync(id);
            var gearboxes = await _modelService.GetGearboxesByModelIdAsync(id);

            foreach (var engine in engines)
            {
                await _modelService.DeleteEngineAsync(engine);
            }

            foreach (var gearbox in gearboxes)
            {
                await _modelService.DeleteGearboxAsync(gearbox);
            }

            try
            {
                await _modelService.DeleteModelAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id)
        {
            bool isIdValid = Guid.TryParse(id, out Guid guidId);
            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Index));
            }


            var model = await _modelService.GetModelByIdAsync(guidId);
            var brands = await _brandRepository.GetAllAsync();


            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var brandViewModel = new ModelViewModel
            {
                Brands = brands.ToList()
            };

            var modelDto = new ModelViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Year = model.Year,
                HorsePower = model.HorsePower,
                FuelType = model.FuelType,
                GasConsumption = model.GasConsumption,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                SelectedBrand = model.BrandId,
                Brands = brands.ToList()
            };

            return View(modelDto);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(ModelViewModel model)
        {
            if (ModelState.IsValid)
            {
                var modelUpdate = new ModelDto
                {
                    Id = model.Id,
                    Name = model.Name,
                    Year = model.Year,
                    HorsePower = model.HorsePower,
                    FuelType = model.FuelType,
                    GasConsumption = model.GasConsumption,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl,
                    BrandId = model.SelectedBrand
                };

                await _modelService.UpdateModelAsync(modelUpdate);
                return RedirectToAction("Details", new { id = model.Id });
            }
            return View(model);
        }
    }
}
