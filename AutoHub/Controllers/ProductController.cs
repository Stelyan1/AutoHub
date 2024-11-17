﻿using AutoHub.Data;
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
         
            var products = dbContext.Products
               .Select(p => new ProductIndexViewModel()
               {
                   Id = p.Id,
                   ImageUrl = p.ImageUrl,
                   ProductName = p.ProductName,
                   Price = p.Price,
                   HasBought = dbContext.ProductClients.Any(pc => pc.ClientId == GetSellerId() &&
                   pc.ProductId == p.Id),
                   IsSeller = p.SellerId == GetSellerId()
               })
               .ToList();

            return View(products);
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

        [HttpGet]
        [Authorize]
        public IActionResult Details(string id) 
        {
            bool isValid = Guid.TryParse(id, out Guid guidId);
            if (!isValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            Product? product = this.dbContext
                .Products
                .Include(p => p.Category)
                .Include(p => p.Seller)
                .FirstOrDefault(p => p.Id == guidId);

            if (product == null) 
            {
                return RedirectToAction(nameof(Index));
            }
                
          return View(product);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Buy(string id)
        {
            bool isValid = Guid.TryParse(id, out Guid guidId);
            if (!isValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            var userId = GetSellerId();

            var productInCartCheck = dbContext.ProductClients
                .Any(pc => pc.ClientId == userId && pc.ProductId == guidId);

            var productClient = new ProductClient
            {
                ProductId = guidId,
                ClientId = userId,
            };

            dbContext.ProductClients.Add(productClient);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Cart));
        }

        [HttpGet]
        [Authorize]
        public IActionResult Cart() 
        {
            var userId = GetSellerId();

            var product = dbContext.ProductClients
               .Include(pc => pc.Product)
               .Where(pc => pc.ClientId == userId)
               .Select(pc => new ProductViewModel
               {
                   Id = pc.ProductId,
                   ProductName = pc.Product.ProductName,
                   Price = pc.Product.Price,
                   ImageUrl = pc.Product.ImageUrl
               })
               .ToList();

            return View(product);
        }

        [HttpPost]
        [Authorize]
        public IActionResult RemoveFromCart(string id)
        {
            bool isValid = Guid.TryParse(id, out Guid guidId);

            if (!isValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            var userId = GetSellerId();

            var productInCartCheckRemove = dbContext.ProductClients
                .FirstOrDefault(pc => pc.ClientId == userId && pc.ProductId == guidId);

            if (productInCartCheckRemove != null)
            {
                dbContext.ProductClients.Remove(productInCartCheckRemove);
                dbContext.SaveChanges();
            }

            return RedirectToAction(nameof(Cart));
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(string id) 
        {

            bool isValid = Guid.TryParse(id, out Guid guidId);
            if (!isValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            var product = dbContext.Products
                .Where(p => p.Id == guidId && p.IsDeleted == false)
                .Select(p => new ProductViewModel
                {
                    ProductName = p.ProductName,
                    Manufacturer = p.Manufacturer,
                    CategoryId = p.CategoryId,
                    CarsApplication = p.CarsApplication,
                    Description = p.Description,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    AddedOn = p.AddedOn
                })
                .FirstOrDefault();

            product.Categories = dbContext.Categories.ToList();

            return View(product);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(ProductViewModel model) 
        {
            if (!ModelState.IsValid)
            {
                model.Categories = dbContext.Categories.ToList();

                return View(model);
            }

            var productEntity = dbContext.Products
                .FirstOrDefault(p => p.Id == model.Id && p.IsDeleted == false);

            productEntity.ProductName = model.ProductName;
            productEntity.Manufacturer = model.Manufacturer;
            productEntity.CategoryId = model.CategoryId;
            productEntity.CarsApplication = model.CarsApplication;
            productEntity.Description = model.Description;
            productEntity.Price = model.Price;
            productEntity.ImageUrl = model.ImageUrl;
            productEntity.AddedOn = model.AddedOn;

            dbContext.SaveChanges();

            return RedirectToAction("Details", new { id = productEntity.Id });
        }

        [HttpGet]
        [Authorize]
        public IActionResult Delete(string id) 
        {
            bool isValid = Guid.TryParse(id, out Guid guidId);
            if (!isValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            var product = dbContext.Products
                .Where(p => p.Id == guidId)
                .Select(p => new ProductDeleteViewModel
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    SellerId = p.SellerId,
                    Seller = p.Seller.UserName ?? string.Empty
                })
                .FirstOrDefault();

            return View(product);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete (ProductDeleteViewModel model)
        {
            var productEntity = dbContext.Products.Find(model.Id);

            if (productEntity != null)
            {
                dbContext.Products.Remove(productEntity);
                productEntity.IsDeleted = true;
                dbContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        private string GetSellerId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}