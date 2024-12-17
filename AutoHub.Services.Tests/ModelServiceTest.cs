using AutoHub.Data.Models;
using AutoHub.Infrastructure.DTOs;
using AutoHub.Infrastructure.Repositories.Interfaces;
using AutoHub.Infrastructure.Services;
using AutoHub.Infrastructure.Services.Interfaces;
using Microsoft.Build.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Services.Tests
{
    [TestFixture]
    public class ModelServiceTest
    {
        private Mock<IModelRepository> modelRepositoryMock;
        private Mock<IBrandRepository> brandRepositoryMock;
        private Mock<IEngineRepository> engineRepositoryMock;
        private Mock<IGearboxRepository> gearboxRepositoryMock;

        private ModelService modelService;
        

        [SetUp]
        public void Setup()
        {
           
            modelRepositoryMock = new Mock<IModelRepository>();
            brandRepositoryMock = new Mock<IBrandRepository>();
            engineRepositoryMock = new Mock<IEngineRepository>();
            gearboxRepositoryMock = new Mock<IGearboxRepository>();

            
            modelService = new ModelService(
                modelRepositoryMock.Object,
                brandRepositoryMock.Object,
                engineRepositoryMock.Object,
                gearboxRepositoryMock.Object
            );
        }

        [Test]
        public async Task AddModelAsync_ValidModelDto_CallsAddAndSaveChanges()
        {
           
            var modelDto = new ModelDto
            {
                Name = "Test Model",
                Year = 2023,
                HorsePower = 300,
                FuelType = "Petrol",
                GasConsumption = 7.5,
                Description = "Test Description",
                ImageUrl = "http://test-image.com",
                BrandId = Guid.NewGuid()
            };

            
            await modelService.AddModelAsync(modelDto);

           
            modelRepositoryMock.Verify(repo => repo.AddAsync(It.Is<Model>(
                m => m.Name == modelDto.Name &&
                     m.Year == modelDto.Year &&
                     m.HorsePower == modelDto.HorsePower &&
                     m.FuelType == modelDto.FuelType &&
                     m.GasConsumption == modelDto.GasConsumption &&
                     m.Description == modelDto.Description &&
                     m.ImageUrl == modelDto.ImageUrl &&
                     m.BrandId == modelDto.BrandId
            )), Times.Once);

           
            modelRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task DeleteModelAsync_ModelExists_DeletesModelAndSavesChanges()
        {
           
            var modelId = Guid.NewGuid();
            var model = new Model
            {
                Id = modelId,
                Name = "Test Model",
                Year = 2023
            };

            modelRepositoryMock
                .Setup(repo => repo.GetIdAndVerifyAsync(modelId))
                .ReturnsAsync(model);

            await modelService.DeleteModelAsync(modelId);

           
            modelRepositoryMock.Verify(repo => repo.GetIdAndVerifyAsync(modelId), Times.Once);
            modelRepositoryMock.Verify(repo => repo.Delete(It.Is<Model>(m => m.Id == modelId)), Times.Once);
            modelRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public void DeleteModelAsync_ModelNotFound_ThrowsArgumentException()
        {
            
            var modelId = Guid.NewGuid();

            modelRepositoryMock
                .Setup(repo => repo.GetIdAndVerifyAsync(modelId))
                .ReturnsAsync((Model)null); 

            
            var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
                await modelService.DeleteModelAsync(modelId));

            Assert.That(ex.Message, Is.EqualTo("Model not found"));

            modelRepositoryMock.Verify(repo => repo.GetIdAndVerifyAsync(modelId), Times.Once);
            modelRepositoryMock.Verify(repo => repo.Delete(It.IsAny<Model>()), Times.Never);
            modelRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Never);
        }

        [Test]
        public async Task GetAllModelsAsync_ReturnsModelDtos()
        {
            
            var models = new List<Model>
            {
            new Model
            {
                Id = Guid.NewGuid(),
                Name = "Model A",
                Year = 2020,
                HorsePower = 200,
                FuelType = "Petrol",
                GasConsumption = 6.5,
                Description = "A reliable model",
                ImageUrl = "https://example.com/modelA.jpg",
                BrandId = Guid.NewGuid()
            },
            new Model
            {
                Id = Guid.NewGuid(),
                Name = "Model B",
                Year = 2021,
                HorsePower = 250,
                FuelType = "Diesel",
                GasConsumption = 7.5,
                Description = "A powerful model",
                ImageUrl = "https://example.com/modelB.jpg",
                BrandId = Guid.NewGuid()
            }
            };

            
            modelRepositoryMock
                .Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(models);

            
            var result = await modelService.GetAllModelsAsync();

            
            Assert.IsNotNull(result);
            Assert.AreEqual(models.Count, result.Count());

            
            var resultList = result.ToList();
            for (int i = 0; i < models.Count; i++)
            {
                Assert.AreEqual(models[i].Id, resultList[i].Id);
                Assert.AreEqual(models[i].Name, resultList[i].Name);
                Assert.AreEqual(models[i].Year, resultList[i].Year);
                Assert.AreEqual(models[i].HorsePower, resultList[i].HorsePower);
                Assert.AreEqual(models[i].FuelType, resultList[i].FuelType);
                Assert.AreEqual(models[i].GasConsumption, resultList[i].GasConsumption);
                Assert.AreEqual(models[i].Description, resultList[i].Description);
                Assert.AreEqual(models[i].ImageUrl, resultList[i].ImageUrl);
                Assert.AreEqual(models[i].BrandId, resultList[i].BrandId);
            }

            
            modelRepositoryMock.Verify(repo => repo.GetAllAsync(), Times.Once);
        }

        [Test]
        public async Task GetAllModelsAsync_EmptyList_ReturnsEmptyList()
        {
            
            modelRepositoryMock
                .Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(new List<Model>());

            
            var result = await modelService.GetAllModelsAsync();

           
            Assert.IsNotNull(result);
            Assert.IsEmpty(result);

            
            modelRepositoryMock.Verify(repo => repo.GetAllAsync(), Times.Once);
        }

        [Test]
        public async Task GetModelByIdAsync_ModelExists_ReturnsModelDtoWithBrandName()
        {
            
            var modelId = Guid.NewGuid();
            var brandId = Guid.NewGuid();

            var model = new Model
            {
                Id = modelId,
                Name = "Model X",
                Year = 2022,
                HorsePower = 300,
                FuelType = "Electric",
                GasConsumption = 0,
                Description = "Electric model",
                ImageUrl = "https://example.com/modelx.jpg",
                BrandId = brandId
            };

            var brand = new Brand
            {
                Id = brandId,
                Name = "Tesla"
            };

            
            modelRepositoryMock
                .Setup(repo => repo.GetIdAndVerifyAsync(modelId))
                .ReturnsAsync(model);

            brandRepositoryMock
                .Setup(repo => repo.GetByIdAsync(brandId))
                .ReturnsAsync(brand);

          
            var result = await modelService.GetModelByIdAsync(modelId);

           
            Assert.IsNotNull(result);
            Assert.AreEqual(model.Id, result.Id);
            Assert.AreEqual(model.Name, result.Name);
            Assert.AreEqual(model.Year, result.Year);
            Assert.AreEqual(model.HorsePower, result.HorsePower);
            Assert.AreEqual(model.FuelType, result.FuelType);
            Assert.AreEqual(model.GasConsumption, result.GasConsumption);
            Assert.AreEqual(model.Description, result.Description);
            Assert.AreEqual(model.ImageUrl, result.ImageUrl);
            Assert.AreEqual(model.BrandId, result.BrandId);
            Assert.AreEqual(brand.Name, result.BrandName);

           
            modelRepositoryMock.Verify(repo => repo.GetIdAndVerifyAsync(modelId), Times.Once);
            brandRepositoryMock.Verify(repo => repo.GetByIdAsync(brandId), Times.Once);
        }

        [Test]
        public async Task GetModelByIdAsync_ModelDoesNotExist_ReturnsNull()
        {
            
            var modelId = Guid.NewGuid();

            
            modelRepositoryMock
                .Setup(repo => repo.GetIdAndVerifyAsync(modelId))
                .ReturnsAsync((Model)null);

           
            var result = await modelService.GetModelByIdAsync(modelId);

            
            Assert.IsNull(result);

            
            modelRepositoryMock.Verify(repo => repo.GetIdAndVerifyAsync(modelId), Times.Once);
            brandRepositoryMock.Verify(repo => repo.GetByIdAsync(It.IsAny<Guid>()), Times.Never);
        }

        [Test]
        public async Task GetModelByIdAsync_ModelExists_BrandDoesNotExist_ReturnsModelDtoWithoutBrandName()
        {
            
            var modelId = Guid.NewGuid();
            var brandId = Guid.NewGuid();

            var model = new Model
            {
                Id = modelId,
                Name = "Model X",
                Year = 2022,
                HorsePower = 300,
                FuelType = "Electric",
                GasConsumption = 0,
                Description = "Electric model",
                ImageUrl = "https://example.com/modelx.jpg",
                BrandId = brandId
            };

            
            modelRepositoryMock
                .Setup(repo => repo.GetIdAndVerifyAsync(modelId))
                .ReturnsAsync(model);

            brandRepositoryMock
                .Setup(repo => repo.GetByIdAsync(brandId))
                .ReturnsAsync((Brand)null);

            
            var result = await modelService.GetModelByIdAsync(modelId);

            
            Assert.IsNotNull(result);
            Assert.AreEqual(model.Id, result.Id);
            Assert.AreEqual(model.Name, result.Name);
            Assert.AreEqual(model.Year, result.Year);
            Assert.AreEqual(model.HorsePower, result.HorsePower);
            Assert.AreEqual(model.FuelType, result.FuelType);
            Assert.AreEqual(model.GasConsumption, result.GasConsumption);
            Assert.AreEqual(model.Description, result.Description);
            Assert.AreEqual(model.ImageUrl, result.ImageUrl);
            Assert.AreEqual(model.BrandId, result.BrandId);
            Assert.IsNull(result.BrandName);

            
            modelRepositoryMock.Verify(repo => repo.GetIdAndVerifyAsync(modelId), Times.Once);
            brandRepositoryMock.Verify(repo => repo.GetByIdAsync(brandId), Times.Once);
        }

        [Test]
        public async Task DeleteEngineAsync_ValidEngine_CallsRepositoryDeleteOnce()
        {
            
            var engine = new Engine
            {
                Id = Guid.NewGuid(),
                Name = "V8 Engine"
            };

            
            await modelService.DeleteEngineAsync(engine);

         
            engineRepositoryMock.Verify(
                repo => repo.Delete(engine), Times.Once,
                "Delete method should be called once with the provided engine."
            );
        }

        [Test]
        public async Task DeleteGearboxAsync_ValidGearbox_CallsRepositoryDeleteOnce()
        {
            var gearbox = new Gearbox
            {
                Id = Guid.NewGuid(),
                Name = "SF8 Tronic"
            };

            await modelService.DeleteGearboxAsync(gearbox);

            gearboxRepositoryMock.Verify(
                repo => repo.Delete(gearbox), Times.Once,
                "Delete method should be called once with the provided engine"
            );
        }

        [Test]
        public async Task GetEnginesByModelIdAsync_ValidModelId_ReturnsEngines()
        {
            
            var modelId = Guid.NewGuid();

            var engines = new List<Engine>
        {
            new Engine
            {
                Id = Guid.NewGuid(),
                Name = "V8 Engine",
                ModelId = modelId
            },
            new Engine
            {
                Id = Guid.NewGuid(),
                Name = "V6 Engine",
                ModelId = modelId
            }
        };

            
            engineRepositoryMock
                .Setup(repo => repo.GetByModelIdAsync(modelId))
                .ReturnsAsync(engines);

           
            var result = await modelService.GetEnginesByModelIdAsync(modelId);

          
            Assert.IsNotNull(result, "Result should not be null.");
            Assert.AreEqual(engines.Count, result.Count(), "Engine count should match the expected count.");

            
            engineRepositoryMock.Verify(
                repo => repo.GetByModelIdAsync(modelId), Times.Once,
                "GetByModelIdAsync should be called exactly once with the provided modelId."
            );
        }

        [Test]
        public async Task GetEnginesByModelIdAsync_NoEngines_ReturnsEmptyList()
        {
           
            var modelId = Guid.NewGuid();

            
            engineRepositoryMock
                .Setup(repo => repo.GetByModelIdAsync(modelId))
                .ReturnsAsync(new List<Engine>());

           
            var result = await modelService.GetEnginesByModelIdAsync(modelId);

           
            Assert.IsNotNull(result, "Result should not be null.");
            Assert.IsEmpty(result, "Result should be an empty list when no engines exist for the given modelId.");

            
            engineRepositoryMock.Verify(
                repo => repo.GetByModelIdAsync(modelId), Times.Once,
                "GetByModelIdAsync should be called exactly once with the provided modelId."
            );
        }

        [Test]
        public async Task GetGearboxesByModelIdAsync_ValidModelId_ReturnsGearboxes()
        {
           
            var modelId = Guid.NewGuid();

            var gearboxes = new List<Gearbox>
        {
            new Gearbox
            {
                Id = Guid.NewGuid(),
            },
            new Gearbox
            {
                Id = Guid.NewGuid(),
            }
        };

            
            gearboxRepositoryMock
                .Setup(repo => repo.GetByModelIdAsync(modelId))
                .ReturnsAsync(gearboxes);

           
            var result = await modelService.GetGearboxesByModelIdAsync(modelId);

            
            Assert.IsNotNull(result, "Result should not be null.");
            Assert.AreEqual(gearboxes.Count, result.Count(), "Gearbox count should match the expected count.");

            
            gearboxRepositoryMock.Verify(
                repo => repo.GetByModelIdAsync(modelId), Times.Once,
                "GetByModelIdAsync should be called exactly once with the provided modelId."
            );
        }

        [Test]
        public async Task GetGearboxesByModelIdAsync_NoGearboxes_ReturnsEmptyList()
        {
          
            var modelId = Guid.NewGuid();

            
            gearboxRepositoryMock
                .Setup(repo => repo.GetByModelIdAsync(modelId))
                .ReturnsAsync(new List<Gearbox>());

          
            var result = await modelService.GetGearboxesByModelIdAsync(modelId);

        
            Assert.IsNotNull(result, "Result should not be null.");
            Assert.IsEmpty(result, "Result should be an empty list when no gearboxes exist for the given modelId.");

            
            gearboxRepositoryMock.Verify(
                repo => repo.GetByModelIdAsync(modelId), Times.Once,
                "GetByModelIdAsync should be called exactly once with the provided modelId."
            );
        }

        [Test]
        public async Task UpdateModelAsync_ModelExists_UpdatesModel()
        {
           
            var modelId = Guid.NewGuid();
            var modelDto = new ModelDto
            {
                Id = modelId,
                Name = "Updated Model",
                Year = 2025,
                HorsePower = 350,
                FuelType = "Diesel",
                GasConsumption = 10.5f,
                Description = "Updated description",
                ImageUrl = "http://new-image-url.com",
                BrandId = Guid.NewGuid()
            };

            var existingModel = new Model
            {
                Id = modelId,
                Name = "Old Model",
                Year = 2020,
                HorsePower = 250,
                FuelType = "Petrol",
                GasConsumption = 8.5f,
                Description = "Old description",
                ImageUrl = "http://old-image-url.com",
                BrandId = Guid.NewGuid()
            };

           
            modelRepositoryMock
                .Setup(repo => repo.GetByIdAsync(modelId))
                .ReturnsAsync(existingModel);

         
            await modelService.UpdateModelAsync(modelDto);

          
            modelRepositoryMock.Verify(
                repo => repo.UpdateModelAsync(It.Is<Model>(m =>
                    m.Name == modelDto.Name &&
                    m.Year == modelDto.Year &&
                    m.HorsePower == modelDto.HorsePower &&
                    m.FuelType == modelDto.FuelType &&
                    m.GasConsumption == modelDto.GasConsumption &&
                    m.Description == modelDto.Description &&
                    m.ImageUrl == modelDto.ImageUrl &&
                    m.BrandId == modelDto.BrandId
                )), Times.Once);

            modelRepositoryMock.Verify(
                repo => repo.SaveChangesAsync(), Times.Once,
                "SaveChangesAsync should be called after the update"
            );
        }

        [Test]
        public void UpdateModelAsync_ModelNotFound_ThrowsArgumentException()
        {
            
            var modelDto = new ModelDto
            {
                Id = Guid.NewGuid(),
                Name = "Non-existent Model",
                Year = 2025,
                HorsePower = 350,
                FuelType = "Diesel",
                GasConsumption = 10.5f,
                Description = "This model does not exist",
                ImageUrl = "http://image-url.com",
                BrandId = Guid.NewGuid()
            };

            
            modelRepositoryMock
                .Setup(repo => repo.GetByIdAsync(modelDto.Id))
                .ReturnsAsync((Model)null);

         
            var exception = Assert.ThrowsAsync<ArgumentException>(async () =>
                await modelService.UpdateModelAsync(modelDto)
            );

            Assert.AreEqual("Model not found", exception.Message);
            modelRepositoryMock.Verify(
                repo => repo.UpdateModelAsync(It.IsAny<Model>()), Times.Never,
                "UpdateModelAsync should not be called if the model does not exist"
            );
        }
    }
}



