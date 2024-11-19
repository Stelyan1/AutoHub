using AutoHub.Data;
using AutoHub.Data.Models;
using AutoHub.Infrastructure.Repositories.Interfaces;
using AutoHub.Web.ViewModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AutoHub.Controllers
{
    public class ModelController : Controller
    {
        private readonly AutoHubDbContext dbContext;
        private readonly IModelRepository _modelRepository;
        private readonly IBaseRepository<Brand> _brandRepository;

        public ModelController(IModelRepository modelRepository, IBaseRepository<Brand> brandRepository)
        {
            _modelRepository = modelRepository;
            _brandRepository = brandRepository;
        }

        [HttpGet]
        public async Task <IActionResult> Index()
        {
            var models = await _modelRepository.GetAllAsync();

            return View(models);
            //IEnumerable<Model> allModels = this.dbContext
            //    .Models
            //    .ToList();

            //return View(allModels);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create() 
        {
            var brands = await _brandRepository.GetAllAsync();
            

            var modelViewModel = new ModelViewModel
            {
                Brands = brands.ToList()
            };

            return View(modelViewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(ModelViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                var newModel = new Model
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

                await _modelRepository.AddAsync(newModel);
                await _modelRepository.SaveChangesAsync();
               

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

            var model = await _modelRepository.GetIdAndVerifyAsync(guidId);

            if (model == null) 
            {
                return RedirectToAction(nameof(Index));
            }
                
                
            return this.View(model);
        }
    }
}
