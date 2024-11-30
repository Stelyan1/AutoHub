using AutoHub.Data.Models;
using AutoHub.Infrastructure.DTOs;
using AutoHub.Infrastructure.Repositories.Interfaces;
using AutoHub.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Infrastructure.Services
{
    public class GearboxService : IGearboxService
    {
        private readonly IGearboxRepository _gearboxRepository;
        private readonly IModelRepository _modelRepository;

        public GearboxService(IGearboxRepository gearboxRepository, IModelRepository modelRepository)
        {
            _gearboxRepository = gearboxRepository;
            _modelRepository = modelRepository;
        }
        public async Task AddGearboxAsync(GearboxDto gearboxDto)
        {
            var gearbox = new Gearbox
            {
                Id = Guid.NewGuid(),
                Name = gearboxDto.Name,
                TransmissionType = gearboxDto.TransmissionType,
                Speeds = gearboxDto.Speeds,
                YearsProduced = gearboxDto.YearsProduced,
                Manufacturer = gearboxDto.Manufacturer,
                Description = gearboxDto.Description,
                ImageUrl = gearboxDto.ImageUrl,
                Application = gearboxDto.Application
            };

            await _gearboxRepository.AddAsync(gearbox);
            await _gearboxRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<GearboxDto>> GetAllGearboxesAsync()
        {
            var gearboxes = await _gearboxRepository.GetAllAsync();

            return gearboxes.Select(gearbox => new GearboxDto
            {
                Id = gearbox.Id,
                Name = gearbox.Name,
                TransmissionType= gearbox.TransmissionType,
                Speeds = gearbox.Speeds,
                YearsProduced= gearbox.YearsProduced,
                Manufacturer = gearbox.Manufacturer,
                Description = gearbox.Description,
                ImageUrl = gearbox.ImageUrl,
                Application = gearbox.Application
            });
        }

        public async Task<GearboxDto?> GetGearboxesByIdAsync(Guid id)
        {
            var gearbox = await _gearboxRepository.GetByIdVerifyAsync(id);

            if (gearbox == null)
            {
                return null;
            }

            var model = await _modelRepository.GetByIdAsync(gearbox.Application);

            return new GearboxDto
            {
                Id = gearbox.Id,
                Name = gearbox.Name,
                TransmissionType = gearbox.TransmissionType,
                Speeds = gearbox.Speeds,
                YearsProduced = gearbox.YearsProduced,
                Manufacturer = gearbox.Manufacturer,
                Description = gearbox.Description,
                ImageUrl = gearbox.ImageUrl,
                Application = gearbox.Application,
                ApplicationName = model?.Name
            };
        }
    }
}
