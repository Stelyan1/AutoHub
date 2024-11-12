using AutoHub.Data;
using AutoHub.Data.Models;
using AutoHub.Web.ViewModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var product = dbContext.Products
                .ToList();

            return View(product);
        }

        [HttpGet]
        public IActionResult Create() 
        {

            var categories = dbContext.Categories
                .ToList();

            var productViewModel = new ProductViewModel
            {
                Categories = categories
            };

            return View(productViewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(ProductViewModel productModel)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    ProductName = productModel.ProductName,
                    Manufacturer = productModel.Manufacturer,
                    CarsApplication = productModel.CarsApplication,
                    Description = productModel.Description,
                    Price = productModel.Price,
                    ImageUrl = productModel.ImageUrl,
                    SellerId = GetSellerId() ?? string.Empty,
                    AddedOn = productModel.AddedOn,
                    CategoryId = productModel.CategoryId
                };

                dbContext.Products.Add(product);
                dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

           return View(productModel);
        }

        [HttpGet]
        public IActionResult Details(string id) 
        {
			bool isValid = Guid.TryParse(id, out Guid guidId);
			if (!isValid)
			{
				return RedirectToAction(nameof(Index));
			}

			var model = dbContext.Products
		        .Where(p => p.Id == guidId)
		        .Include(p => p.Category)
		        .Include(p => p.ProductsClients)
		        .Select(p => new ProductViewModel
		        {
			     ProductName = p.ProductName,
			     Manufacturer = p.Manufacturer,
			     CarsApplication = p.CarsApplication,
			     Description = p.Description,
			     Price = p.Price,
			     ImageUrl = p.ImageUrl,
			     CategoryId = p.CategoryId,
                 CategoryName = p.Category,
			     AddedOn = p.AddedOn,
			     Seller = p.Seller.UserName ?? string.Empty
		        })
		        .FirstOrDefault();

			if (model == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return View(model);
		}
        private string GetSellerId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
