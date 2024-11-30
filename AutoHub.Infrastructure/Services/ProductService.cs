using AutoHub.Data;
using AutoHub.Data.Models;
using AutoHub.Infrastructure.DTOs;
using AutoHub.Infrastructure.Repositories.Interfaces;
using AutoHub.Infrastructure.Services.Interfaces;
using AutoHub.Web.ViewModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AutoHub.Common.EntityValidationConstants;
using Category = AutoHub.Data.Models.Category;
using Product = AutoHub.Data.Models.Product;

namespace AutoHub.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IBaseRepository<Category> _categoryRepository;
        private readonly AutoHubDbContext _dbContext;
        public ProductService(IProductRepository productRepository, IBaseRepository<Category> categoryRepository, AutoHubDbContext dbContext)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _dbContext = dbContext;
        }

        public async Task AddProductAsync(ProductDto productDto) 
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                ProductName = productDto.ProductName,
                Manufacturer = productDto.Manufacturer,
                CategoryId = productDto.CategoryId,
                CarsApplication = productDto.CarsApplication,
                Description = productDto.Description,
                Price = productDto.Price,
                ImageUrl = productDto.ImageUrl,
                SellerId = productDto.SellerId,
                AddedOn = productDto.AddedOn
            };

            await _productRepository.AddAsync(product);
            await _productRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(string sellerId) 
        {
            var products = await _productRepository.GetAllAsync();

            return products.Select(product => new ProductDto
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Manufacturer = product.Manufacturer,
                CategoryId = product.CategoryId,
                CarsApplication = product.CarsApplication,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                SellerId = product.SellerId,
                HasBought = _dbContext.ProductClients.Any(pc => pc.ClientId == sellerId && pc.ProductId == product.Id),
                IsSeller = product.SellerId == sellerId,
                AddedOn = product.AddedOn
            });
        }

        public async Task<ProductDto?> GetProductByIdAsync(Guid id)  
        {
            var product = await _productRepository.GetByIdWithSellerAsync(id);

            if (product == null) 
            {
                return null;
            }

            var category = await _categoryRepository.GetByIdAsync(product.CategoryId);

            var sellerName = product.Seller?.UserName ?? string.Empty;

            return new ProductDto
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Manufacturer = product.Manufacturer,
                CategoryId = product.CategoryId,
                CategoryName = category?.Name ?? string.Empty,
                CarsApplication = product.CarsApplication,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                SellerId = product.SellerId,
                SellerName = sellerName,
                AddedOn = product.AddedOn,
            };
        }

        public async Task<bool> ProductExistsAsync(Guid productId, string clientId)
        {
            return await _dbContext.ProductClients.AnyAsync(pc => pc.ClientId == clientId && pc.ProductId == productId);
        }

        public async Task AddToCartAsync(ProductClient productClient)
        {
            await _dbContext.ProductClients.AddAsync(productClient);
        }

        public async Task<IEnumerable<ProductViewModel>> GetCartProductsAsync(string clientId)
        {
            return await _dbContext.ProductClients
                .Include(pc => pc.Product)
                .Where(pc => pc.ClientId == clientId)
                .Select(pc => new ProductViewModel
                {
                    Id = pc.ProductId,
                    ProductName = pc.Product.ProductName,
                    Price = pc.Product.Price,
                    ImageUrl = pc.Product.ImageUrl
                })
                .ToListAsync();
        }

        public async Task RemoveFromCartAsync(Guid productId, string clientId)
        {
            var productClient = await _dbContext.ProductClients
                .FirstOrDefaultAsync(pc => pc.ClientId == clientId && pc.ProductId == productId);

            if (productClient != null)
            {
                _dbContext.ProductClients.Remove(productClient);
            }
        }

        public async Task UpdateProductAsync(ProductDto productDto)
        {
            var product = await _productRepository.GetByIdAsync(productDto.Id);
            
            if (product == null)
            {
                throw new ArgumentException("Product not found");
            }

            product.ProductName = productDto.ProductName;
            product.Manufacturer = productDto.Manufacturer;
            product.CategoryId = productDto.CategoryId;
            product.CarsApplication = productDto.CarsApplication;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.ImageUrl = productDto.ImageUrl;
            product.AddedOn = productDto.AddedOn;

            await _productRepository.UpdateProductAsync(product);
            await _productRepository.SaveChangesAsync();
        }

        public async Task<Product?> GetByIdWithSellerAsync(Guid Id)
        {
            return await _productRepository.GetByIdWithSellerAsync(Id);
        }

        public async Task DeleteProductsAsync(Guid productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);

            if (product == null)
            {
                throw new ArgumentException("Product not found");
            }

            if(product != null)
            {
                product.IsDeleted = true;
                _productRepository.Delete(product);
                await _productRepository.SaveChangesAsync();
            }
        }
    }
}
