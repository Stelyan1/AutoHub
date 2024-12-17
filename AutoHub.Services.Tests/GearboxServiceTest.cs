using AutoHub.Data.Models;
using AutoHub.Infrastructure.DTOs;
using AutoHub.Infrastructure.Repositories.Interfaces;
using AutoHub.Infrastructure.Services;
using AutoHub.Infrastructure.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Services.Tests
{
    [TestFixture]
    public class GearboxServiceTest
    {
        private Mock<IGearboxRepository> gearboxRepositoryMock;
        private Mock<IModelRepository> modelRepositoryMock;

        private GearboxService gearboxService;

        [SetUp]
        public void Setup()
        {
            gearboxRepositoryMock = new Mock<IGearboxRepository>();
            modelRepositoryMock = new Mock<IModelRepository>();

            gearboxService = new GearboxService(
                gearboxRepositoryMock.Object,
                modelRepositoryMock.Object
            );
        }

        [Test]
        public async Task AddGearboxAsync_AddsGearboxSuccessfully()
        {
            
            var gearboxDto = new GearboxDto
            {
                Name = "New Gearbox",
                TransmissionType = "Manual",
                Speeds = 6,
                YearsProduced = "2019-Present",
                Manufacturer = "Gearbox Manufacturer",
                Description = "A top-class manual gearbox",
                ImageUrl = "gearboxImage.jpg",
                Application = Guid.NewGuid()
            };

            
            await gearboxService.AddGearboxAsync(gearboxDto);

            
            gearboxRepositoryMock.Verify(r => r.AddAsync(It.Is<Gearbox>(g =>
                g.Name == gearboxDto.Name &&
                g.TransmissionType == gearboxDto.TransmissionType &&
                g.Speeds == gearboxDto.Speeds &&
                g.YearsProduced == gearboxDto.YearsProduced &&
                g.Manufacturer == gearboxDto.Manufacturer &&
                g.Description == gearboxDto.Description &&
                g.ImageUrl == gearboxDto.ImageUrl &&
                g.Application == gearboxDto.Application
            )), Times.Once);

            gearboxRepositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task DeleteGearboxAsync_GearboxFound_DeletesAndSavesChanges()
        {
            
            var gearboxId = Guid.NewGuid();
            var gearbox = new Gearbox { Id = gearboxId }; 
            gearboxRepositoryMock
                .Setup(repo => repo.GetByIdVerifyAsync(gearboxId))
                .ReturnsAsync(gearbox); 

            
            await gearboxService.DeleteGearboxAsync(gearboxId);

            
            gearboxRepositoryMock.Verify(repo => repo.Delete(It.IsAny<Gearbox>()), Times.Once);
            gearboxRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public void DeleteGearboxAsync_GearboxNotFound_ThrowsArgumentException()
        {
            
            var gearboxId = Guid.NewGuid();
            gearboxRepositoryMock
                .Setup(repo => repo.GetByIdVerifyAsync(gearboxId))
                .ReturnsAsync((Gearbox)null);

            
            var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
                await gearboxService.DeleteGearboxAsync(gearboxId)
            );
            Assert.AreEqual("Gearbox not found", ex.Message);
        }

        [Test]
        public async Task GetAllGearboxesAsync_ReturnsCorrectDtos()
        {
           
            var gearboxes = new List<Gearbox>
            {
              new Gearbox
              {
                Id = Guid.NewGuid(),
                Name = "Gearbox 1",
                TransmissionType = "Manual",
                Speeds = 5,
                YearsProduced = "2015-2020",
                Manufacturer = "Manufacturer 1",
                Description = "Description 1",
                ImageUrl = "url1",
                Application = Guid.NewGuid()
              },
              new Gearbox
              {
                Id = Guid.NewGuid(),
                Name = "Gearbox 2",
                TransmissionType = "Automatic",
                Speeds = 6,
                YearsProduced = "2018-2022",
                Manufacturer = "Manufacturer 2",
                Description = "Description 2",
                ImageUrl = "url2",
                Application = Guid.NewGuid()
              }
            };

            gearboxRepositoryMock
                .Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(gearboxes); 

            
            var result = await gearboxService.GetAllGearboxesAsync();

            
            Assert.AreEqual(2, result.Count()); 
            Assert.AreEqual("Gearbox 1", result.First().Name); 
            Assert.AreEqual("Manual", result.First().TransmissionType); 
            Assert.AreEqual("Gearbox 2", result.Last().Name); 
            Assert.AreEqual("Automatic", result.Last().TransmissionType); 
        }

        [Test]
        public async Task GetAllGearboxesAsync_ReturnsEmpty_WhenNoGearboxes()
        {
            
            var gearboxes = new List<Gearbox>();

            gearboxRepositoryMock
                .Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(gearboxes); 

           
            var result = await gearboxService.GetAllGearboxesAsync();

            
            Assert.AreEqual(0, result.Count()); 
        }

        [Test]
        public async Task GetGearboxById_ReturnsCorrectGearbox_WhenFound()
        {
            
            var gearboxId = Guid.NewGuid();
            var gearbox = new Gearbox
            {
                Id = gearboxId,
                Name = "Gearbox 1",
                TransmissionType = "Manual",
                Speeds = 5,
                YearsProduced = "2015-2020",
                Manufacturer = "Manufacturer 1",
                Description = "Description 1",
                ImageUrl = "url1",
                Application = Guid.NewGuid()
            };

            gearboxRepositoryMock
                .Setup(repo => repo.GetByIdAsync(gearboxId))
                .ReturnsAsync(gearbox); 

            
            await gearboxService.GetGearboxById(gearboxId); 

            
            gearboxRepositoryMock.Verify(repo => repo.GetByIdAsync(gearboxId), Times.Once); 
        }

        [Test]
        public void GetGearboxById_ThrowsArgumentException_WhenNotFound()
        {
            
            var gearboxId = Guid.NewGuid();

            gearboxRepositoryMock
                .Setup(repo => repo.GetByIdAsync(gearboxId))
                .ReturnsAsync((Gearbox)null); 

            
            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await gearboxService.GetGearboxById(gearboxId));
            Assert.AreEqual("Gearbox not found", ex.Message); 
        }

        [Test]
        public async Task GetGearboxesByIdAsync_ReturnsCorrectGearbox_WhenFound()
        {
           
            var gearboxId = Guid.NewGuid();
            var gearbox = new Gearbox
            {
                Id = gearboxId,
                Name = "Gearbox 1",
                TransmissionType = "Manual",
                Speeds = 6,
                YearsProduced = "2015-2020",
                Manufacturer = "Manufacturer 1",
                Description = "Description 1",
                ImageUrl = "url1",
                Application = Guid.NewGuid()
            };

            var model = new Model
            {
                Id = Guid.NewGuid(),
                Name = "Model 1"
            };

            gearboxRepositoryMock
                .Setup(repo => repo.GetByIdVerifyAsync(gearboxId))
                .ReturnsAsync(gearbox); 

            modelRepositoryMock
                .Setup(repo => repo.GetByIdAsync(gearbox.Application))
                .ReturnsAsync(model); 

            
            var result = await gearboxService.GetGearboxesByIdAsync(gearboxId);

            
            Assert.IsNotNull(result);
            Assert.AreEqual(gearboxId, result.Id);
            Assert.AreEqual("Gearbox 1", result.Name);
            Assert.AreEqual("Model 1", result.ApplicationName); 
        }

        [Test]
        public async Task GetGearboxesByIdAsync_ReturnsNull_WhenGearboxNotFound()
        {
            
            var gearboxId = Guid.NewGuid();

            gearboxRepositoryMock
                .Setup(repo => repo.GetByIdVerifyAsync(gearboxId))
                .ReturnsAsync((Gearbox)null); 

            
            var result = await gearboxService.GetGearboxesByIdAsync(gearboxId);

           
            Assert.IsNull(result); 
        }

        [Test]
        public async Task UpdateGearboxAsync_UpdatesGearbox_WhenFound()
        {
            
            var gearboxId = Guid.NewGuid();
            var gearboxDto = new GearboxDto
            {
                Id = gearboxId,
                Name = "Updated Gearbox",
                Manufacturer = "Updated Manufacturer",
                Application = Guid.NewGuid(),
                TransmissionType = "Automatic",
                Speeds = 6,
                YearsProduced = "2020-2025",
                Description = "Updated Description",
                ImageUrl = "updatedUrl"
            };

            var existingGearbox = new Gearbox
            {
                Id = gearboxId,
                Name = "Old Gearbox",
                Manufacturer = "Old Manufacturer",
                Application = Guid.NewGuid(),
                TransmissionType = "Manual",
                Speeds = 5,
                YearsProduced = "2015-2020",
                Description = "Old Description",
                ImageUrl = "oldUrl"
            };

            gearboxRepositoryMock
                .Setup(repo => repo.GetByIdAsync(gearboxId))
                .ReturnsAsync(existingGearbox);

            
            await gearboxService.UpdateGearboxAsync(gearboxDto);

           
            gearboxRepositoryMock.Verify(repo => repo.Update(It.Is<Gearbox>(g => g.Id == gearboxId && g.Name == "Updated Gearbox" && g.Manufacturer == "Updated Manufacturer")), Times.Once);
            gearboxRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }
    }
}

