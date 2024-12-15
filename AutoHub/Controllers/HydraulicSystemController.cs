using AutoHub.Infrastructure.DTOs;
using AutoHub.Infrastructure.Models;
using AutoHub.Infrastructure.Services;
using AutoHub.Infrastructure.Services.Interfaces;
using AutoHub.Web.ViewModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoHub.Controllers
{
    public class HydraulicSystemController : Controller
    {
        private readonly IHydraulicSystemService _hydraulicSystemService;

        public HydraulicSystemController(IHydraulicSystemService hydraulicSystemService)
        {
            _hydraulicSystemService = hydraulicSystemService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? searchQuery, int currentPage = 1)
        {
            var hydraulicPart = await _hydraulicSystemService.GetAllHydraulicPartsAsync();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                hydraulicPart = hydraulicPart.Where(hp => hp.partName.Contains(searchQuery, StringComparison.OrdinalIgnoreCase));
            }

            int entitiesPerPage = 3;
            int totalHydraulicParts = hydraulicPart.Count();
            var pagedHydraulicParts = hydraulicPart.Skip((currentPage - 1) * entitiesPerPage)
                                    .Take(entitiesPerPage);

            var viewModel = new SearchPagination
            {
                hydraulicSystems = pagedHydraulicParts.Select(hp => new HydraulicSystemDto
                {
                    Id = hp.Id,
                    partName = hp.partName,
                    Description = hp.Description,
                    ImageUrl = hp.ImageUrl
                }),
                SearchQuery = searchQuery,
                CurrentPage = currentPage,
                EntitiesPerPage = entitiesPerPage,
                TotalPages = (int)Math.Ceiling((double)totalHydraulicParts / entitiesPerPage),
            };
            return View(viewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(HydraulicSystemViewModel hydraulicPartModel)
        {
            if (!ModelState.IsValid)
            {
                return View(hydraulicPartModel);
            }

            var hydraulicPartDto = new HydraulicSystemDto
            {
                partName = hydraulicPartModel.partName,
                Description = hydraulicPartModel.Description,
                ImageUrl = hydraulicPartModel.ImageUrl
            };

            await _hydraulicSystemService.AddHydarulicPartAsync(hydraulicPartDto);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            bool isIdValid = Guid.TryParse(id, out Guid guidId);
            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            var hydraulicPart = await _hydraulicSystemService.GetHydraulicPartByIdAsync(guidId);

            if (hydraulicPart == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(hydraulicPart);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            bool isIdValid = Guid.TryParse(id, out Guid guidId);
            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            var hydraulicPart = await _hydraulicSystemService.GetHydraulicPartByIdAsync(guidId);

            if (hydraulicPart == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var hydraulicPartModel = new HydraulicSystemDto
            {
                partName = hydraulicPart.partName,
                Description = hydraulicPart.Description,
                ImageUrl = hydraulicPart.ImageUrl
            };

            return View(hydraulicPartModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _hydraulicSystemService.DeleteHydraulicPartAsync(id);
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

            var hydraulicPart = await _hydraulicSystemService.GetHydraulicPartByIdAsync(guidId);

            if (hydraulicPart == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var hydraulicPartModel = new HydraulicSystemViewModel
            {
                partName = hydraulicPart.partName,
                Description = hydraulicPart.Description,
                ImageUrl = hydraulicPart.ImageUrl
            };

            return View(hydraulicPartModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(HydraulicSystemViewModel hydraulicSystemViewModel)
        {
            if (ModelState.IsValid)
            {
                var hydraulicPartModelUpdate = new HydraulicSystemDto
                {
                    Id = hydraulicSystemViewModel.Id,
                    partName = hydraulicSystemViewModel.partName,
                    Description = hydraulicSystemViewModel.Description,
                    ImageUrl = hydraulicSystemViewModel.ImageUrl
                };

                await _hydraulicSystemService.UpdateHydraulicPartAsync(hydraulicPartModelUpdate);
                return RedirectToAction("Details", new { id = hydraulicSystemViewModel.Id});
            }
            return View(hydraulicSystemViewModel);
        }
    }
}
