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
    public class HydraulicSystemService : IHydraulicSystemService
    {
        private readonly IHydraulicSystemRepository _hydraulicSystemRepository;

        public HydraulicSystemService(IHydraulicSystemRepository hydraulicSystemRepository)
        {
            _hydraulicSystemRepository = hydraulicSystemRepository;
        }
        public async Task AddHydarulicPartAsync(HydraulicSystemDto hydraulicSystemDto)
        {
            var hydraulicPart = new HydraulicSystem
            {
                Id = Guid.NewGuid(),
                partName = hydraulicSystemDto.partName,
                Description = hydraulicSystemDto.Description,
                ImageUrl = hydraulicSystemDto.ImageUrl
            };

            await _hydraulicSystemRepository.AddAsync(hydraulicPart);
            await _hydraulicSystemRepository.SaveChangesAsync();
        }

        public async Task DeleteHydraulicPartAsync(Guid id)
        {
            var hydraulicPart = await _hydraulicSystemRepository.GetIdAndVerifyAsync(id);

            if (hydraulicPart != null) 
            {
                _hydraulicSystemRepository.Delete(hydraulicPart);
                await _hydraulicSystemRepository.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Hydraulic part not found");
            }
        }

        public async Task<IEnumerable<HydraulicSystemDto>> GetAllHydraulicPartsAsync()
        {
            var hydarulicParts = await _hydraulicSystemRepository.GetAllAsync();

            return hydarulicParts.Select(hydarulicPart => new HydraulicSystemDto
            {
                Id = hydarulicPart.Id,
                partName = hydarulicPart.partName,
                Description = hydarulicPart.Description,
                ImageUrl = hydarulicPart.ImageUrl
            });
        }

        public async Task<HydraulicSystemDto?> GetHydraulicPartByIdAsync(Guid id)
        {
            var hydraulicPart = await _hydraulicSystemRepository.GetIdAndVerifyAsync(id);

            if (hydraulicPart == null) 
            {
                return null;
            }

            return new HydraulicSystemDto
            {
                Id = hydraulicPart.Id,
                partName = hydraulicPart.partName,
                Description = hydraulicPart.Description,
                ImageUrl = hydraulicPart.ImageUrl
            };
        }

        public async Task UpdateHydraulicPartAsync(HydraulicSystemDto hydraulicSystemDto)
        {
            var hydraulicPart = await _hydraulicSystemRepository.GetByIdAsync(hydraulicSystemDto.Id);

            if (hydraulicPart == null) 
            {
                throw new ArgumentException("Hydraulic part not found");
            }

            hydraulicPart.partName = hydraulicSystemDto.partName;
            hydraulicPart.Description = hydraulicSystemDto.Description;
            hydraulicPart.ImageUrl = hydraulicSystemDto.ImageUrl;

            await _hydraulicSystemRepository.UpdateHydraulicSystemAsync(hydraulicPart);
            await _hydraulicSystemRepository.SaveChangesAsync();
        }
    }
}
