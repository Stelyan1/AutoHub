using AutoHub.Data.Models;
using AutoHub.Infrastructure.Repositories.Interfaces;
using AutoHub.Infrastructure.Services;
using AutoHub.Infrastructure.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoHub.Data;
using AutoHub.Infrastructure.DTOs;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace AutoHub.Services.Tests
{
    [TestFixture]
    public class ProductServiceTest
    {
        private Mock<IProductRepository> productRepositoryMock;
        private Mock<IBaseRepository<Category>> categoryRepositoryMock;
        private Mock<AutoHubDbContext> dbContextMock; 

        private ProductService productService;

        [SetUp]
        public void Setup()
        {
            
            productRepositoryMock = new Mock<IProductRepository>();
            categoryRepositoryMock = new Mock<IBaseRepository<Category>>();
            dbContextMock = new Mock<AutoHubDbContext>();  

            
            productService = new ProductService(
                productRepositoryMock.Object,
                categoryRepositoryMock.Object,
                dbContextMock.Object 
            );
        }

        [Test]
        public async Task AddProductAsync_ShouldAddProductToRepository()
        {
            
            var productDto = new ProductDto
            {
                ProductName = "Test Product",
                Manufacturer = "Test Manufacturer",
                CategoryId = Guid.NewGuid(),
                CarsApplication = "Test Cars",
                Description = "Test Description",
                Price = 100.00M,
                ImageUrl = "testimageurl.com",
                SellerId = "Seller1",
                AddedOn = DateTime.UtcNow
            };

            productRepositoryMock
                .Setup(repo => repo.AddAsync(It.IsAny<Product>()))
                .Returns(Task.CompletedTask);

            
            await productService.AddProductAsync(productDto);

            
            productRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Product>()), Times.Once);
            productRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task GetAllProductsAsync_ShouldReturnProductsWithFlags()
        {
            
            var sellerId = "Seller1";

            
            var productList = new List<Product>
            {
              new Product { Id = Guid.NewGuid(), ProductName = "Product 1", SellerId = sellerId },
              new Product { Id = Guid.NewGuid(), ProductName = "Product 2", SellerId = "Seller2" }
            };

            
            var productClientList = new List<ProductClient>
            {
              new ProductClient { ClientId = sellerId, ProductId = productList[0].Id } 
            };

            
            var productClientsMock = new Mock<DbSet<ProductClient>>();
            productClientsMock.As<IQueryable<ProductClient>>()
                .Setup(m => m.Provider).Returns(productClientList.AsQueryable().Provider);
            productClientsMock.As<IQueryable<ProductClient>>()
                .Setup(m => m.Expression).Returns(productClientList.AsQueryable().Expression);
            productClientsMock.As<IQueryable<ProductClient>>()
                .Setup(m => m.ElementType).Returns(productClientList.AsQueryable().ElementType);
            productClientsMock.As<IQueryable<ProductClient>>()
                .Setup(m => m.GetEnumerator()).Returns(productClientList.GetEnumerator());

            
            dbContextMock.Setup(db => db.ProductClients).Returns(productClientsMock.Object);

            
            productRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(productList);

            
            var result = await productService.GetAllProductsAsync(sellerId);

            
            Assert.AreEqual(2, result.Count()); 
            Assert.IsTrue(result.First().HasBought); 
            Assert.IsFalse(result.Last().HasBought); 
        }

        [Test]
        public async Task UpdateProductAsync_ShouldUpdateProduct()
        {
           
            var productDto = new ProductDto
            {
                Id = Guid.NewGuid(),
                ProductName = "Updated Product",
                Manufacturer = "Updated Manufacturer",
                CategoryId = Guid.NewGuid(),
                CarsApplication = "Updated Cars",
                Description = "Updated Description",
                Price = 150.00M,
                ImageUrl = "updatedimageurl.com",
                SellerId = "Seller1",
                AddedOn = DateTime.UtcNow
            };

            var existingProduct = new Product
            {
                Id = productDto.Id,
                ProductName = "Old Product",
                Manufacturer = "Old Manufacturer",
                CategoryId = productDto.CategoryId,
                CarsApplication = "Old Cars",
                Description = "Old Description",
                Price = 120.00M,
                ImageUrl = "oldimageurl.com",
                SellerId = "Seller1",
                AddedOn = DateTime.UtcNow
            };

            productRepositoryMock
                .Setup(repo => repo.GetByIdAsync(productDto.Id))
                .ReturnsAsync(existingProduct);

            productRepositoryMock
                .Setup(repo => repo.UpdateProductAsync(It.IsAny<Product>()))
                .Returns(Task.CompletedTask);

            
            await productService.UpdateProductAsync(productDto);

            
            productRepositoryMock.Verify(repo => repo.UpdateProductAsync(It.IsAny<Product>()), Times.Once);
            productRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task UpdateProductAsync_ShouldThrowExceptionIfProductNotFound()
        {
           
            var productDto = new ProductDto { Id = Guid.NewGuid() };

            productRepositoryMock
                .Setup(repo => repo.GetByIdAsync(productDto.Id))
                .ReturnsAsync((Product)null);  

            
            var exception = Assert.ThrowsAsync<ArgumentException>(async () => await productService.UpdateProductAsync(productDto));
            Assert.AreEqual("Product not found", exception.Message);
        }

        [Test]
        public async Task DeleteProductsAsync_ShouldMarkProductAsDeleted()
        {
            
            var productId = Guid.NewGuid();

            var product = new Product { Id = productId, IsDeleted = false };
            productRepositoryMock
                .Setup(repo => repo.GetByIdAsync(productId))
                .ReturnsAsync(product);

            productRepositoryMock
                .Setup(repo => repo.SaveChangesAsync())
                .Returns(Task.CompletedTask);

            
            await productService.DeleteProductsAsync(productId);

            
            Assert.IsTrue(product.IsDeleted);
            productRepositoryMock.Verify(repo => repo.Delete(It.IsAny<Product>()), Times.Once);
            productRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task DeleteProductsAsync_ShouldThrowExceptionIfProductNotFound()
        {
            
            var productId = Guid.NewGuid();

            productRepositoryMock
                .Setup(repo => repo.GetByIdAsync(productId))
                .ReturnsAsync((Product)null);  

            
            var exception = Assert.ThrowsAsync<ArgumentException>(async () => await productService.DeleteProductsAsync(productId));
            Assert.AreEqual("Product not found", exception.Message);
        }
    }
}
