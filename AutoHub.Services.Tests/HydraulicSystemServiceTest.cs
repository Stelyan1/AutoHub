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
    public class HydraulicSystemServiceTest
    {
        private Mock<IHydraulicSystemRepository> hydraulicSystemRepositoryMock;

        private HydraulicSystemService hydraulicSystemService;

        [SetUp]
        public void Setup()
        {

            hydraulicSystemRepositoryMock = new Mock<IHydraulicSystemRepository>();

            hydraulicSystemService = new HydraulicSystemService(
                hydraulicSystemRepositoryMock.Object
            );
        }

        [Test]
        public async Task AddHydraulicPartAsync_AddsNewPart_WhenValidDto()
        {
            
            var hydraulicSystemDto = new HydraulicSystemDto
            {
                partName = "Hydraulic Pump",
                Description = "A hydraulic pump used for pumping fluid",
                ImageUrl = "someimageurl.com"
            };

            
            await hydraulicSystemService.AddHydarulicPartAsync(hydraulicSystemDto);

            
            hydraulicSystemRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<HydraulicSystem>()), Times.Once);
            hydraulicSystemRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task DeleteHydraulicPartAsync_DeletesPart_WhenFound()
        {
            
            var partId = Guid.NewGuid();
            var hydraulicPart = new HydraulicSystem { Id = partId, partName = "Hydraulic Pump" };
            hydraulicSystemRepositoryMock
                .Setup(repo => repo.GetIdAndVerifyAsync(partId))
                .ReturnsAsync(hydraulicPart);  

            
            await hydraulicSystemService.DeleteHydraulicPartAsync(partId);

            
            hydraulicSystemRepositoryMock.Verify(repo => repo.Delete(hydraulicPart), Times.Once);
            hydraulicSystemRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public void DeleteHydraulicPartAsync_ThrowsArgumentException_WhenPartNotFound()
        {
            
            var partId = Guid.NewGuid();
            hydraulicSystemRepositoryMock
                .Setup(repo => repo.GetIdAndVerifyAsync(partId))
                .ReturnsAsync((HydraulicSystem)null);  

            
            var ex = Assert.ThrowsAsync<ArgumentException>(() => hydraulicSystemService.DeleteHydraulicPartAsync(partId));
            Assert.That(ex.Message, Is.EqualTo("Hydraulic part not found"));
        }

        [Test]
        public async Task GetAllHydraulicPartsAsync_ReturnsCorrectParts()
        {
           
            var hydraulicParts = new List<HydraulicSystem>
            {
               new HydraulicSystem { Id = Guid.NewGuid(), partName = "Pump", Description = "Hydraulic pump" },
               new HydraulicSystem { Id = Guid.NewGuid(), partName = "Valve", Description = "Hydraulic valve" }
            };

            hydraulicSystemRepositoryMock
                .Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(hydraulicParts);

            
            var result = await hydraulicSystemService.GetAllHydraulicPartsAsync();

           
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Pump", result.First().partName);
        }

        [Test]
        public async Task GetHydraulicPartByIdAsync_ReturnsCorrectPart_WhenFound()
        {
            
            var partId = Guid.NewGuid();
            var hydraulicPart = new HydraulicSystem { Id = partId, partName = "Pump", Description = "Hydraulic pump" };
            hydraulicSystemRepositoryMock
                .Setup(repo => repo.GetIdAndVerifyAsync(partId))
                .ReturnsAsync(hydraulicPart);

            
            var result = await hydraulicSystemService.GetHydraulicPartByIdAsync(partId);

            
            Assert.IsNotNull(result);
            Assert.AreEqual("Pump", result.partName);
        }

        [Test]
        public async Task GetHydraulicPartByIdAsync_ReturnsNull_WhenPartNotFound()
        {
            
            var partId = Guid.NewGuid();
            hydraulicSystemRepositoryMock
                .Setup(repo => repo.GetIdAndVerifyAsync(partId))
                .ReturnsAsync((HydraulicSystem)null); 

            
            var result = await hydraulicSystemService.GetHydraulicPartByIdAsync(partId);

            
            Assert.IsNull(result);
        }

        [Test]
        public async Task UpdateHydraulicPartAsync_UpdatesPart_WhenFound()
        {
            
            var partId = Guid.NewGuid();
            var hydraulicSystemDto = new HydraulicSystemDto
            {
                Id = partId,
                partName = "Updated Pump",
                Description = "Updated description",
                ImageUrl = "updatedUrl"
            };

            var existingPart = new HydraulicSystem { Id = partId, partName = "Old Pump", Description = "Old description" };

            hydraulicSystemRepositoryMock
                .Setup(repo => repo.GetByIdAsync(partId))
                .ReturnsAsync(existingPart);

            
            await hydraulicSystemService.UpdateHydraulicPartAsync(hydraulicSystemDto);

            
            Assert.AreEqual("Updated Pump", existingPart.partName);
            Assert.AreEqual("Updated description", existingPart.Description);
            hydraulicSystemRepositoryMock.Verify(repo => repo.UpdateHydraulicSystemAsync(existingPart), Times.Once);
            hydraulicSystemRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }
    }
}

