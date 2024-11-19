using AutoHub.Data;
using AutoHub.Data.Models;
using AutoHub.Infrastructure.Repositories.Interfaces;
using AutoHub.Web.ViewModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace AutoHub.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandRepository _brandRepository;

        public BrandController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var brands = await _brandRepository.GetAllAsync();

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
                 .TryParseExact(brandModel.FoundedDate, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                 out DateTime foundedDate);

            if (!isFoundedDateValid)
            {
                this.ModelState.AddModelError(nameof(brandModel.FoundedDate), "The date founded must be the following format MM/dd/yyyy");
                return this.View(brandModel);
            }

            Brand brand = new Brand()
            {
                Name = brandModel.Name,
                FoundedBy = brandModel.FoundedBy,
                FoundedDate = foundedDate,
                Description = brandModel.Description,
                ImageUrl = brandModel.ImageUrl
            };

            await _brandRepository.AddAsync(brand);
            await _brandRepository.SaveChangesAsync();

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

            var brand = await _brandRepository.GetIdAndVerifyAsync(guidId);

            if (brand == null) 
            {
                return RedirectToAction(nameof(Index));
            }

            return this.View(brand);
        }
    }
}
