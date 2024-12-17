using AutoHub.Data;
using AutoHub.Data.Models;
using AutoHub.Infrastructure.DTOs;
using AutoHub.Infrastructure.Models;
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
        public async Task<IActionResult> Index(string? searchQuery, string? selectedBrand, int currentPage = 1)
        {
            var gearboxes = await _gearboxService.GetAllGearboxesAsync();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                gearboxes = gearboxes.Where(g => g.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase));
            }


            int entitiesPerPage = 3;
            int totalBrands = gearboxes.Count();
            var pagedBrands = gearboxes.Skip((currentPage - 1) * entitiesPerPage)
                                    .Take(entitiesPerPage);


            var viewModel = new SearchPagination
            {
                GearBoxes = pagedBrands.Select(g => new GearboxDto
                {
                    Id = g.Id,
                    Manufacturer = g.Manufacturer,
                    Name = g.Name,
                    Application = g.Application,
                    ApplicationName = g.ApplicationName,
                    TransmissionType = g.TransmissionType,
                    Speeds = g.Speeds,
                    YearsProduced = g.YearsProduced,
                    Description = g.Description,
                    ImageUrl = g.ImageUrl
                }),
                SearchQuery = searchQuery,
                CurrentPage = currentPage,
                EntitiesPerPage = entitiesPerPage,
                TotalPages = (int)Math.Ceiling((double)totalBrands / entitiesPerPage),
            };

            return View(viewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            bool isValid = Guid.TryParse(id, out Guid guidId);

            if (!isValid)
            {
                return RedirectToAction(nameof(Index));
            }

            var gearbox = await _gearboxService.GetGearboxesByIdAsync(guidId);

            if (gearbox == null) 
            {
                throw new ArgumentException("Gearbox not found");
            }

            var gearboxDto = new GearboxDto
                {
                 Id = gearbox.Id,
                 Name = gearbox.Name,
                 ApplicationName = gearbox.ApplicationName
                };

            return View(gearboxDto);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try 
            {
                await _gearboxService.DeleteGearboxAsync(id);
                return RedirectToAction(nameof(Index));
            } 
            catch (Exception) 
            {
                throw new ArgumentException("Gearbox not found");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit (string id)
        {
            bool isValid = Guid.TryParse (id, out Guid guidId);

            if (!isValid)
            {
                return RedirectToAction(nameof(Index));
            }

            var gearbox = await _gearboxService.GetGearboxesByIdAsync(guidId);
            var models =  await _modelRepository.GetAllAsync();

            if (gearbox == null) 
            {
                throw new ArgumentException("Gearbox not found");
            }

            var gearboxModel = new GearboxViewModel
            {
                Id = gearbox.Id,
                Name = gearbox.Name,
                Manufacturer = gearbox.Manufacturer,
                Application = gearbox.Application,
                Models = models.ToList(),
                TransmissionType = gearbox.TransmissionType,
                Speeds = gearbox.Speeds,
                YearsProduced = gearbox.YearsProduced,
                Description = gearbox.Description,
                ImageUrl = gearbox.ImageUrl
            };

            return View(gearboxModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit (GearboxViewModel gearboxModel)
        {
            if (ModelState.IsValid) 
            {
                var gearbox = new GearboxDto
                {
                    Id = gearboxModel.Id,
                    Name = gearboxModel.Name,
                    Manufacturer = gearboxModel.Manufacturer,
                    Application = gearboxModel.Application,
                    TransmissionType = gearboxModel.TransmissionType,
                    Speeds = gearboxModel.Speeds,
                    YearsProduced = gearboxModel.YearsProduced,
                    Description = gearboxModel.Description,
                    ImageUrl = gearboxModel.ImageUrl
                };

                await _gearboxService.UpdateGearboxAsync(gearbox);
                return RedirectToAction("Details", new { id = gearboxModel.Id });
            }
            return View(gearboxModel);
        }
    }
}
