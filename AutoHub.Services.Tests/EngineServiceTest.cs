using AutoHub.Data.Models;
using AutoHub.Infrastructure.DTOs;
using AutoHub.Infrastructure.Repositories.Interfaces;
using AutoHub.Infrastructure.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Services.Tests
{
    [TestFixture]
    public class EngineServiceTest
    {
        private Mock<IEngineRepository> engineRepositoryMock;
        private Mock<IModelRepository> modelRepositoryMock;  
        private Mock<IBrandRepository> brandRepositoryMock;  
        private EngineService engineService;

        [SetUp]
        public void Setup()
        {
            
            engineRepositoryMock = new Mock<IEngineRepository>();
            modelRepositoryMock = new Mock<IModelRepository>(); 
            brandRepositoryMock = new Mock<IBrandRepository>(); 

            
            engineService = new EngineService(
                engineRepositoryMock.Object,  
                brandRepositoryMock.Object,   
                modelRepositoryMock.Object    
            );
        }

        [Test]
        public async Task AddEngineAsync_ValidEngineDto_AddsEngineAndSaves()
        {
            
            var engineDto = new EngineDto
            {
                Name = "V8 Engine",
                BrandId = Guid.NewGuid(),
                ModelId = Guid.NewGuid(),
                Cylinders = 8,
                ValveTrainDriveSystem = "DOHC",
                PowerOutput = "400hp",
                Torque = "500Nm",
                Rpm = "7000Rpm",
                ImageUrl = "http://image-url.com",
                YearsProduction = "2019-Present"
            };

           
            engineRepositoryMock
                .Setup(repo => repo.AddAsync(It.IsAny<Engine>()))
                .Returns(Task.CompletedTask);
            engineRepositoryMock
                .Setup(repo => repo.SaveChangesAsync())
                .Returns(Task.CompletedTask);

           
            await engineService.AddEngineAsync(engineDto);

           
            engineRepositoryMock.Verify(
                repo => repo.AddAsync(It.Is<Engine>(e =>
                    e.Name == engineDto.Name &&
                    e.BrandId == engineDto.BrandId &&
                    e.ModelId == engineDto.ModelId &&
                    e.Cylinders == engineDto.Cylinders &&
                    e.ValvetrainDriveSystem == engineDto.ValveTrainDriveSystem &&
                    e.PowerOutput == engineDto.PowerOutput &&
                    e.Torque == engineDto.Torque &&
                    e.Rpm == engineDto.Rpm &&
                    e.ImageUrl == engineDto.ImageUrl &&
                    e.YearsProduction == engineDto.YearsProduction
                )), Times.Once, "AddAsync should be called with the correct engine data");

            engineRepositoryMock.Verify(
                repo => repo.SaveChangesAsync(), Times.Once,
                "SaveChangesAsync should be called after adding the engine"
            );
        }

        [Test]
        public async Task DeleteEngineAsync_EngineExists_DeletesEngine()
        {
           
            var engineId = Guid.NewGuid();
            var engine = new Engine { Id = engineId, Name = "Test Engine" };

           
            engineRepositoryMock.Setup(r => r.GetIdAndVerifyAsync(engineId))
                                 .ReturnsAsync(engine);
            engineRepositoryMock.Setup(r => r.Delete(engine));

           
            await engineService.DeleteEngineAsync(engineId);

            
            engineRepositoryMock.Verify(r => r.Delete(engine), Times.Once);
            engineRepositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public void DeleteEngineAsync_EngineNotFound_ThrowsArgumentException()
        {
            
            var engineId = Guid.NewGuid();

            
            engineRepositoryMock.Setup(r => r.GetIdAndVerifyAsync(engineId))
                                 .ReturnsAsync((Engine)null);

           
            var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
                await engineService.DeleteEngineAsync(engineId)
            );

            Assert.That(ex.Message, Is.EqualTo("Engine not found"));
        }

        [Test]
        public async Task GetAllEnginesAsync_EnginesExist_ReturnsEngineDtosWithParsedValues()
        {
            
            var engineList = new List<Engine>
            {
              new Engine
              {  
               Id = Guid.NewGuid(),
               Name = "Engine 1",
               BrandId = Guid.NewGuid(),
               ModelId = Guid.NewGuid(),
               Cylinders = 4,
               ValvetrainDriveSystem = "DOHC",
               PowerOutput = "200-250",  
               Torque = "300-350",       
               Rpm = "6000-6500",        
               ImageUrl = "image1.jpg",
               YearsProduction = "2019-2021"
            },
            new Engine
            {
             Id = Guid.NewGuid(),
             Name = "Engine 2",
             BrandId = Guid.NewGuid(),
             ModelId = Guid.NewGuid(),
             Cylinders = 6,
             ValvetrainDriveSystem = "SOHC",
             PowerOutput = "250-300",  
             Torque = "350-400",       
             Rpm = "6500-7000",        
             ImageUrl = "image2.jpg",
             YearsProduction = "2019-2021"
            }
            };

            
            engineRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(engineList);

           
            var result = await engineService.GetAllEnginesAsync();

            
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());

            var firstEngine = result.First();
            var secondEngine = result.Last();

            
            Assert.AreEqual("200-250", firstEngine.PowerOutput);  
            Assert.AreEqual("300-350", firstEngine.Torque);       
            Assert.AreEqual("6000-6500", firstEngine.Rpm);         

            Assert.AreEqual("250-300", secondEngine.PowerOutput); 
            Assert.AreEqual("350-400", secondEngine.Torque);      
            Assert.AreEqual("6500-7000", secondEngine.Rpm);        
        }

        [Test]
        public async Task GetEngineByIdAsync_EngineExists_ReturnsEngineDtoWithStringValues()
        {
            
            var engine = new Engine
            {
                Id = Guid.NewGuid(),
                Name = "Engine 1",
                BrandId = Guid.NewGuid(),
                ModelId = Guid.NewGuid(),
                Cylinders = 4,
                ValvetrainDriveSystem = "DOHC",
                PowerOutput = "200-250",  
                Torque = "300-350",       
                Rpm = "6000-6500",        
                ImageUrl = "image1.jpg",
                YearsProduction = "2019-Present"
            };

            var brand = new Brand { Id = engine.BrandId, Name = "Brand 1" };
            var model = new Model { Id = engine.ModelId, Name = "Model 1" };

            
            engineRepositoryMock.Setup(r => r.GetIdAndVerifyAsync(engine.Id)).ReturnsAsync(engine);
            brandRepositoryMock.Setup(r => r.GetByIdAsync(engine.BrandId)).ReturnsAsync(brand);
            modelRepositoryMock.Setup(r => r.GetByIdAsync(engine.ModelId)).ReturnsAsync(model);

            
            var result = await engineService.GetEngineByIdAsync(engine.Id);

            
            Assert.IsNotNull(result);
            Assert.AreEqual("200-250", result.PowerOutput); 
            Assert.AreEqual("300-350", result.Torque);       
        }

        [Test]
        public async Task UpdateEngineAsync_EngineExists_UpdatesEngineFields()
        {
           
            var engineDto = new EngineDto
            {
                Id = Guid.NewGuid(),
                Name = "Updated Engine",
                BrandId = Guid.NewGuid(),
                ModelId = Guid.NewGuid(),
                Cylinders = 6,
                ValveTrainDriveSystem = "DOHC",
                PowerOutput = "250-300",
                Torque = "400-450",
                Rpm = "7000-7500",
                ImageUrl = "updatedImage.jpg",
                YearsProduction = "2019-Present"
            };

            var existingEngine = new Engine
            {
                Id = engineDto.Id,
                Name = "Old Engine",
                BrandId = Guid.NewGuid(),
                ModelId = Guid.NewGuid(),
                Cylinders = 4,
                ValvetrainDriveSystem = "SOHC",
                PowerOutput = "150-200",
                Torque = "250-300",
                Rpm = "5000-5500",
                ImageUrl = "oldImage.jpg",
                YearsProduction = "2019-Present"
            };

            
            engineRepositoryMock.Setup(r => r.GetByIdAsync(engineDto.Id)).ReturnsAsync(existingEngine);

            
            await engineService.UpdateEngineAsync(engineDto);

           
            engineRepositoryMock.Verify(r => r.Update(It.Is<Engine>(e =>
                e.Id == engineDto.Id &&
                e.Name == engineDto.Name &&
                e.BrandId == engineDto.BrandId &&
                e.ModelId == engineDto.ModelId &&
                e.Cylinders == engineDto.Cylinders &&
                e.ValvetrainDriveSystem == engineDto.ValveTrainDriveSystem &&
                e.PowerOutput == engineDto.PowerOutput &&
                e.Torque == engineDto.Torque &&
                e.Rpm == engineDto.Rpm &&
                e.ImageUrl == engineDto.ImageUrl &&
                e.YearsProduction == engineDto.YearsProduction
            )), Times.Once);

            
            engineRepositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }
    }
}
