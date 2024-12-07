using AutoHub.Data;
using AutoHub.Data.Models;
using AutoHub.Infrastructure.DTOs;
using AutoHub.Infrastructure.Repositories.Interfaces;
using AutoHub.Infrastructure.Services.Interfaces;
using AutoHub.Web.ViewModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace AutoHub.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var brands = await _brandService.GetAllBrandsAsync();

            return View(brands);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(BrandViewModel brandModel) 
        {
            if (!ModelState.IsValid) 
            {
                return View(brandModel);
            }

            bool isFoundedDateValid = DateTime
                 .TryParseExact(
                brandModel.FoundedDate, 
                "MM/dd/yyyy", 
                CultureInfo.InvariantCulture, 
                DateTimeStyles.None,
                out DateTime foundedDate);

            if (!isFoundedDateValid)
            {
                this.ModelState.AddModelError(nameof(brandModel.FoundedDate), "The date founded must be the following format MM/dd/yyyy");
                return this.View(brandModel);
            }

            var brandDto = new BrandDto
            {
                Name = brandModel.Name,
                FoundedBy = brandModel.FoundedBy,
                FoundedDate = foundedDate,
                Description = brandModel.Description,
                ImageUrl = brandModel.ImageUrl
            };

            await _brandService.AddBrandAsync(brandDto);
           
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

            var brand = await _brandService.GetBrandByIdAsync(guidId);

            if (brand == null) 
            {
                return RedirectToAction(nameof(Index));
            }

            return View(brand);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete (string id)
        {
            bool isIdValid = Guid.TryParse(id, out Guid guidId);
            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            var brand = await _brandService.GetBrandByIdAsync(guidId);

            if (brand == null) 
            {
                return RedirectToAction(nameof(Index));
            }

            var brandModel = new BrandDto
            {
                Id = brand.Id,
                Name = brand.Name,
                FoundedBy = brand.FoundedBy,
                FoundedDate = brand.FoundedDate,
                Description = brand.Description,
                ImageUrl = brand.ImageUrl
            };

            return View(brandModel);
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete (Guid id)
        {
            try
            {
                await _brandService.DeleteBrandAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
