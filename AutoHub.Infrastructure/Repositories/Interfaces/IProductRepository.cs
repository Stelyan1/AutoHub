using AutoHub.Data.Models;
using AutoHub.Web.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Infrastructure.Repositories.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IEnumerable<ProductIndexViewModel>> GetProductsAsync(string sellerId);
        Task<Product?> GetProductDetailsAsync(Guid id);
        Task CreateProductAsync(Product product);
        Task<Product?> GetProductByIdAsync(Guid id);
        Task SaveChangesAsync();
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<bool> ProductExistsAsync(Guid productId, string clientId);
        Task AddToCartAsync(ProductClient productClient);
        Task<IEnumerable<ProductViewModel>> GetCartProductsAsync(string clientId);
        Task RemoveFromCartAsync(Guid productId, string clientId);
        Task UpdateProductAsync(Product product);
        Task<ProductDeleteViewModel?> GetProductForDeleteAsync(Guid productId);
        Task DeleteProductAsync(Guid productId);
        Task<Product?> GetByIdWithSellerAsync(Guid id);
    }
}
