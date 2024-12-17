using AutoHub.Data.Models;
using AutoHub.Infrastructure.Repositories.Interfaces;
using Moq;

namespace AutoHub.Services.Tests
{
    using AutoHub.Infrastructure.DTOs;
    using AutoHub.Infrastructure.Repositories.Interfaces;
    using AutoHub.Infrastructure.Services;
    using AutoHub.Infrastructure.Services.Interfaces;

    [TestFixture]
    public class BrandServiceTests
    {
        private Mock<IBrandRepository> brandRepositoryMock;
        private IBrandService brandService;

        [SetUp]
        public void Setup()
        {
            this.brandRepositoryMock = new Mock<IBrandRepository>();
            this.brandService = new BrandService(brandRepositoryMock.Object);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public async Task AddBrandAsync_ValidBrandDto_AddsBrandAndSaveChanges()
        {
            var brandDto = new BrandDto
            {
                Name = "New Brand",
                FoundedBy = "John Doe",
                FoundedDate = new DateTime(2020, 1, 1),
                Description = "This is a test brand.",
                ImageUrl = "https://example.com/newbrand.jpg"
            };

            
            await brandService.AddBrandAsync(brandDto);

           
            brandRepositoryMock.Verify(repo => repo.AddAsync(It.Is<Brand>(b =>
                b.Id != Guid.Empty &&
                b.Name == brandDto.Name &&
                b.FoundedBy == brandDto.FoundedBy &&
                b.FoundedDate == brandDto.FoundedDate &&
                b.Description == brandDto.Description &&
                b.ImageUrl == brandDto.ImageUrl
            )), Times.Once);

            
            brandRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task DeleteBrandAsync_BrandExists_DeleteBrandAndSaveChanges()
        {
            
            var brandId = Guid.NewGuid();
            var brand = new Brand
            {
                Id = brandId,
                Name = "Test Brand",
                FoundedBy = "Tester",
                FoundedDate = DateTime.UtcNow,
                Description = "A test brand",
                ImageUrl = "https://example.com/image.jpg"
            };

            
            brandRepositoryMock
                .Setup(repo => repo.GetIdAndVerifyAsync(brandId))
                .ReturnsAsync(brand);

           
            await brandService.DeleteBrandAsync(brandId);

            
            brandRepositoryMock.Verify(repo => repo.Delete(It.Is<Brand>(b => b.Id == brandId)), Times.Once);
            brandRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public void DeleteBrandAsync_BrandDoesNotExist_ThrowsArgumentException()
        {
            
            var brandId = Guid.NewGuid();

            
            brandRepositoryMock
                .Setup(repo => repo.GetIdAndVerifyAsync(brandId))
                .ReturnsAsync((Brand)null);

            
            var exception = Assert.ThrowsAsync<ArgumentException>(
                async () => await brandService.DeleteBrandAsync(brandId)
            );

            Assert.AreEqual("Brand not found", exception.Message);

            brandRepositoryMock.Verify(repo => repo.Delete(It.IsAny<Brand>()), Times.Never);
            brandRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Never);
        }

        [Test]
        public async Task GetAllBrandsAsync_WhenCalled_ReturnsMappedBrandDtos()
        {
            var brands = new List<Brand>
        {
            new Brand
            {
                Id = Guid.NewGuid(),
                Name = "Brand A",
                FoundedBy = "Founder A",
                FoundedDate = new DateTime(2000, 1, 1),
                Description = "Description A",
                ImageUrl = "https://example.com/imageA.jpg"
            },
            new Brand
            {
                Id = Guid.NewGuid(),
                Name = "Brand B",
                FoundedBy = "Founder B",
                FoundedDate = new DateTime(2010, 2, 2),
                Description = "Description B",
                ImageUrl = "https://example.com/imageB.jpg"
            }
        };

            
            brandRepositoryMock
                .Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(brands);

            
            var result = await brandService.GetAllBrandsAsync();

            Assert.IsNotNull(result);
            Assert.AreEqual(brands.Count, result.Count());

            
            var resultList = result.ToList();
            for (int i = 0; i < brands.Count; i++)
            {
                Assert.AreEqual(brands[i].Id, resultList[i].Id);
                Assert.AreEqual(brands[i].Name, resultList[i].Name);
                Assert.AreEqual(brands[i].FoundedBy, resultList[i].FoundedBy);
                Assert.AreEqual(brands[i].FoundedDate, resultList[i].FoundedDate);
                Assert.AreEqual(brands[i].Description, resultList[i].Description);
                Assert.AreEqual(brands[i].ImageUrl, resultList[i].ImageUrl);
            }

            brandRepositoryMock.Verify(repo => repo.GetAllAsync(), Times.Once);
        }

        [Test]
        public async Task GetBrandByIdAsync_BrandExists_ReturnsMappedBrandDto()
        {
            var brandId = Guid.NewGuid();
            var brand = new Brand
            {
                Id = brandId,
                Name = "Brand A",
                FoundedBy = "Founder A",
                FoundedDate = new DateTime(2000, 1, 1),
                Description = "Description A",
                ImageUrl = "https://example.com/imageA.jpg"
            };

            
            brandRepositoryMock
                .Setup(repo => repo.GetIdAndVerifyAsync(brandId))
                .ReturnsAsync(brand);

          
            var result = await brandService.GetBrandByIdAsync(brandId);

            Assert.IsNotNull(result);
            Assert.AreEqual(brand.Id, result?.Id);
            Assert.AreEqual(brand.Name, result?.Name);
            Assert.AreEqual(brand.FoundedBy, result?.FoundedBy);
            Assert.AreEqual(brand.FoundedDate, result?.FoundedDate);
            Assert.AreEqual(brand.Description, result?.Description);
            Assert.AreEqual(brand.ImageUrl, result?.ImageUrl);

            brandRepositoryMock.Verify(repo => repo.GetIdAndVerifyAsync(brandId), Times.Once);
        }

        [Test]
        public async Task GetBrandByIdAsync_BrandDoesNotExist_ReturnsNull()
        {
            var brandId = Guid.NewGuid();

            brandRepositoryMock
                .Setup(repo => repo.GetIdAndVerifyAsync(brandId))
                .ReturnsAsync((Brand)null);

            var result = await brandService.GetBrandByIdAsync(brandId);

            Assert.IsNull(result);

            brandRepositoryMock.Verify(repo => repo.GetIdAndVerifyAsync(brandId), Times.Once);
        }

        [Test]
        public async Task UpdateBrandAsync_BrandExists_UpdatesBrandAndSavesChanges()
        {
            
            var brandId = Guid.NewGuid();
            var existingBrand = new Brand
            {
                Id = brandId,
                Name = "Old Brand",
                FoundedBy = "Old Founder",
                FoundedDate = new DateTime(2000, 1, 1),
                Description = "Old Description",
                ImageUrl = "https://example.com/old.jpg"
            };

            var brandDto = new BrandDto
            {
                Id = brandId,
                Name = "Updated Brand",
                FoundedBy = "Updated Founder",
                FoundedDate = new DateTime(2010, 2, 2),
                Description = "Updated Description",
                ImageUrl = "https://example.com/updated.jpg"
            };

           
            brandRepositoryMock
                .Setup(repo => repo.GetByIdAsync(brandId))
                .ReturnsAsync(existingBrand);

            
            await brandService.UpdateBrandAsync(brandDto);

           
            Assert.AreEqual(brandDto.Name, existingBrand.Name);
            Assert.AreEqual(brandDto.FoundedBy, existingBrand.FoundedBy);
            Assert.AreEqual(brandDto.FoundedDate, existingBrand.FoundedDate);
            Assert.AreEqual(brandDto.Description, existingBrand.Description);
            Assert.AreEqual(brandDto.ImageUrl, existingBrand.ImageUrl);

            
            brandRepositoryMock.Verify(repo => repo.UpdateBrandAsync(existingBrand), Times.Once);
            brandRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);

            
            brandRepositoryMock.Verify(repo => repo.GetByIdAsync(brandId), Times.Once);
        }

        [Test]
        public void UpdateBrandAsync_BrandDoesNotExist_ThrowsArgumentException()
        {
           
            var brandId = Guid.NewGuid();
            var brandDto = new BrandDto
            {
                Id = brandId,
                Name = "Non-Existent Brand",
                FoundedBy = "Non-Existent Founder",
                FoundedDate = new DateTime(2010, 2, 2),
                Description = "Non-Existent Description",
                ImageUrl = "https://example.com/nonexistent.jpg"
            };

           
            brandRepositoryMock
                .Setup(repo => repo.GetByIdAsync(brandId))
                .ReturnsAsync((Brand)null);

            var exception = Assert.ThrowsAsync<ArgumentException>(async () =>
                await brandService.UpdateBrandAsync(brandDto));

            Assert.AreEqual("Brand not found", exception.Message);

           
            brandRepositoryMock.Verify(repo => repo.UpdateBrandAsync(It.IsAny<Brand>()), Times.Never);
            brandRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Never);

            brandRepositoryMock.Verify(repo => repo.GetByIdAsync(brandId), Times.Once);
        }
    }
}
