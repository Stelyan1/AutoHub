using AutoHub.Data;
using AutoHub.Data.Models;
using AutoHub.Infrastructure.Repositories.Interfaces;
using AutoHub.Web.ViewModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AutoHub.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IBaseRepository<Category> _categoryRepository;
        private readonly AutoHubDbContext dbContext;

        public ProductController(IProductRepository productRepository, IBaseRepository<Category> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetProductsAsync(GetSellerId());
            return View(products);
           
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create() 
        {
            var categories = await _productRepository.GetCategoriesAsync();

            var productViewModel = new ProductViewModel { Categories = (ICollection<Category>)categories };

            return View(productViewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = (await _categoryRepository.GetAllAsync()).ToList();
                return View(model);
            }

            
                var product = new Product
                {
                    ProductName = model.ProductName,
                    Manufacturer = model.Manufacturer,
                    CategoryId = model.CategoryId,
                    CarsApplication = model.CarsApplication,
                    Description = model.Description,
                    Price = model.Price,
                    ImageUrl = model.ImageUrl,
                    SellerId = GetSellerId(),
                    AddedOn = model.AddedOn
                };

                await _productRepository.CreateProductAsync(product);
                await _productRepository.SaveChangesAsync();

           return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Details(string id) 
        {
            bool isValid = Guid.TryParse(id, out Guid guidId);
            if (!isValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            var product = await _productRepository.GetProductDetailsAsync(guidId);

            if (product == null) 
            {
                return RedirectToAction(nameof(Index));
            }
                
          return View(product);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Buy(string id)
        {
            bool isValid = Guid.TryParse(id, out Guid guidId);
            if (!isValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            if (await _productRepository.ProductExistsAsync(guidId, GetSellerId()))
            {
                return RedirectToAction(nameof(Cart));
            }

            var productClient = new ProductClient
            {
                ProductId = guidId,
                ClientId = GetSellerId(),
            };

            await _productRepository.AddToCartAsync(productClient);
            await _productRepository.SaveChangesAsync();

            return RedirectToAction(nameof(Cart));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Cart() 
        {
            var cartProducts = await _productRepository.GetCartProductsAsync(GetSellerId());
            return View(cartProducts);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RemoveFromCart(string id)
        {
            bool isValid = Guid.TryParse(id, out Guid guidId);

            if (!isValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            await _productRepository.RemoveFromCartAsync(guidId, GetSellerId());
            await _productRepository.SaveChangesAsync();

            return RedirectToAction(nameof(Cart));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(string id) 
        {

            bool isValid = Guid.TryParse(id, out Guid guidId);
            if (!isValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            var product = await _productRepository.GetProductByIdAsync(guidId);
            //Caution
            if (product == null || product.IsDeleted)
            {
                return RedirectToAction(nameof(Index));
            }

            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Manufacturer = product.Manufacturer,
                CategoryId = product.CategoryId,
                CarsApplication = product.CarsApplication,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                AddedOn = product.AddedOn
            };

            productViewModel.Categories = (await _categoryRepository.GetAllAsync()).ToList();

            return View(productViewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(ProductViewModel model) 
        {
            if (!ModelState.IsValid)
            {
                model.Categories = (ICollection<Category>)await _categoryRepository.GetAllAsync();

                return View(model);
            }

            var product = await _productRepository.GetByIdAsync(model.Id);
            if (product == null || product.IsDeleted)
            {
                return RedirectToAction(nameof(Index));
            }

            product.ProductName = model.ProductName;
            product.Manufacturer = model.Manufacturer;
            product.CategoryId = model.CategoryId;
            product.CarsApplication = model.CarsApplication;
            product.Description = model.Description;
            product.Price = model.Price;
            product.ImageUrl = model.ImageUrl;
            product.AddedOn = model.AddedOn;

            _productRepository.Update(product);
            await _productRepository.SaveChangesAsync();

            return RedirectToAction("Details", new { id = product.Id });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(string id) 
        {
            bool isValid = Guid.TryParse(id, out Guid guidId);
            if (!isValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            var product = await _productRepository.GetByIdWithSellerAsync(guidId);

            if (product == null) 
            {
                return RedirectToAction(nameof(Index));
            }

            var productDeleteViewModel = new ProductDeleteViewModel
            {
                Id = product.Id,
                ProductName = product.ProductName,
                SellerId = product.SellerId,
                Seller = product.Seller?.UserName ?? string.Empty
            };

            return View(productDeleteViewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete (ProductDeleteViewModel model)
        {
            var product = await _productRepository.GetByIdAsync(model.Id);

            if (product != null)
            {
                product.IsDeleted = true;
                _productRepository.Delete(product);
                await _productRepository.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        private string GetSellerId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
