using AutoHub.Data;
using AutoHub.Data.Models;
using AutoHub.Web.ViewModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AutoHub.Controllers
{
    public class ProductController : Controller
    {
        private readonly AutoHubDbContext dbContext;

        public ProductController(AutoHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            IEnumerable<Product> allProducts = this.dbContext
                .Products.ToList();

            return View(allProducts);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create() 
        {
            var categories = this.dbContext
                .Categories.ToList();

            var productViewModel = new ProductViewModel
            {
                Categories = categories
            };

            return View(productViewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var products = new Product
                {
                    ProductName = model.ProductName,
                    Manufacturer = model.Manufacturer,
                    CategoryId = model.CategoryId,
                    CarsApplication = model.CarsApplication,
                    Description = model.Description,
                    Price = model.Price,
                    ImageUrl = model.ImageUrl,
                    SellerId = GetSellerId() ?? string.Empty,
                    AddedOn = model.AddedOn
                };

                dbContext.Products.Add(products);
                dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            model.Categories = dbContext.Categories.ToList();

            return View(model);
        }

        private string GetSellerId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
