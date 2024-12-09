using AutoHub.Data;
using AutoHub.Data.Models;
using AutoHub.Infrastructure.DTOs;
using AutoHub.Infrastructure.Repositories.Interfaces;
using AutoHub.Infrastructure.Services.Interfaces;
using AutoHub.Web.ViewModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static AutoHub.Common.EntityValidationConstants;

namespace AutoHub.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductService productService, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productService = productService;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index() 
        {
            var products = await _productService.GetAllProductsAsync(GetSellerId());
            return View(products);
           
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create() 
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction(nameof(Index));
            }

            var categories = await _categoryRepository.GetAllAsync();

            var productViewModel = new ProductViewModel
            {
                Categories = categories.ToList()
            };
           
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

            var productDto = new ProductDto
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
               
            await _productService.AddProductAsync(productDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Details(Guid id) 
        {
            var productDto = await _productService.GetProductByIdAsync(id);

            if(productDto == null)
            {
                return NotFound();
            }

            var model = new ProductDetailsViewModel
            {
                Id = productDto.Id,
                ProductName = productDto.ProductName,
                Manufacturer = productDto.Manufacturer,
                CategoryId = productDto.CategoryId,
                CarsApplication = productDto.CarsApplication,
                Description = productDto.Description,
                Price = productDto.Price,
                ImageUrl = productDto.ImageUrl,
                AddedOn = productDto.AddedOn,
                SellerName = productDto.SellerName,
                CategoryName = productDto.CategoryName
         
            };

            return View(model);
          
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

            if (await _productService.ProductExistsAsync(guidId, GetSellerId()))
            {
                return RedirectToAction(nameof(Cart));
            }

            var productClient = new ProductClient
            {
                ProductId = guidId,
                ClientId = GetSellerId(),
            };

            await _productService.AddToCartAsync(productClient);
            await _productRepository.SaveChangesAsync();
               
            return RedirectToAction(nameof(Cart));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Cart() 
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction(nameof(Index));
            }

            var cartProducts = await _productService.GetCartProductsAsync(GetSellerId());
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

            await _productService.RemoveFromCartAsync(guidId, GetSellerId());
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

            var product = await _productService.GetProductByIdAsync(guidId);
            //Caution
            if (product == null || product.IsDeleted)
            {
                return RedirectToAction(nameof(Index));
            }

            var productDto = new ProductDto
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

            productDto.Categories = (await _categoryRepository.GetAllAsync()).ToList();

            return View(productDto);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(ProductViewModel model)  
        {
     
            if (ModelState.IsValid)
            {
                var productDtoUpdate = new ProductDto
                {
                    Id = model.Id,
                    ProductName = model.ProductName,
                    Manufacturer = model.Manufacturer,
                    CategoryId = model.CategoryId,
                    CarsApplication = model.CarsApplication,
                    Description = model.Description,
                    Price = model.Price,
                    ImageUrl = model.ImageUrl,
                    AddedOn = model.AddedOn
                };

                await _productService.UpdateProductAsync(productDtoUpdate);
                return RedirectToAction("Details", new { id = model.Id });
            }

            return View(model);
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

            var product = await _productService.GetByIdWithSellerAsync(guidId);

            if (product == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var productDto = new ProductDto
            {
                Id = product.Id,
                ProductName = product.ProductName,
                SellerId = product.SellerId,
                SellerName = product.Seller?.UserName ?? string.Empty
            };

            return View(productDto);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
          
            try
            {
                await _productService.DeleteProductsAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception) 
            {
                return NotFound();
            }
        }
        private string GetSellerId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
