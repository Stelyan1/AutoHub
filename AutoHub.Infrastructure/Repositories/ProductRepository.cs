using AutoHub.Data;
using AutoHub.Data.Models;
using AutoHub.Infrastructure.Repositories.Interfaces;
using AutoHub.Web.ViewModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly AutoHubDbContext _dbContext;

        public ProductRepository(AutoHubDbContext dbContext) : base (dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddToCartAsync(ProductClient productClient)
        {
            await _dbContext.ProductClients.AddAsync(productClient);
        }

        public async Task CreateProductAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
        }

        public async Task DeleteProductAsync(Guid productId)
        {
            var product = await _dbContext.Products.FindAsync(productId);

            if (product != null) 
            {
                product.IsDeleted = true;
                _dbContext.Products.Update(product);
            }
        }

        public async Task<Product?> GetByIdWithSellerAsync(Guid id)
        {
            return await _dbSet
                .Include(p => p.Seller)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
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

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(Guid id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
        }

        public async Task<Product?> GetProductDetailsAsync(Guid id)
        {
            return await _dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Seller)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ProductDeleteViewModel?> GetProductForDeleteAsync(Guid productId)
        {
            return await _dbContext.Products
                .Where(p => p.Id == productId)
                .Select(p => new ProductDeleteViewModel
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    SellerId = p.SellerId,
                    Seller = p.Seller.UserName ?? string.Empty
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProductIndexViewModel>> GetProductsAsync(string sellerId)
        {
            return await _dbContext.Products
                .Select(p => new ProductIndexViewModel
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    HasBought = _dbContext.ProductClients.Any(pc => pc.ClientId == sellerId && pc.ProductId == p.Id),
                    IsSeller = p.SellerId == sellerId
                })
                .ToListAsync();
        }

        public async Task<bool> ProductExistsAsync(Guid productId, string clientId)
        {
            return await _dbContext.ProductClients.AnyAsync(pc => pc.ClientId == clientId && pc.ProductId == productId);
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

        public async Task<Product?> GetIdAndVerifyAsync(Guid id)
        {
            return await _dbSet
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateProductAsync(Product product)
        {
            _dbContext.Products.Update(product);
        }
    }
}
