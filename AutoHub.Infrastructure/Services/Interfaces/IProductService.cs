using AutoHub.Data.Models;
using AutoHub.Infrastructure.DTOs;
using AutoHub.Web.ViewModels.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Infrastructure.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync(string sellerId);
        Task<ProductDto?> GetProductByIdAsync(Guid id);
        Task AddProductAsync(ProductDto productDto);
        Task<bool> ProductExistsAsync(Guid productId, string clientId);
        Task AddToCartAsync(ProductClient productClient);
        Task<IEnumerable<ProductViewModel>> GetCartProductsAsync(string clientId);
        Task RemoveFromCartAsync(Guid productId, string clientId);
        Task UpdateProductAsync(ProductDto? productDto);
        Task<Product?> GetByIdWithSellerAsync(Guid id);
        Task DeleteProductsAsync(Guid productId);
    }
}
