using AutoHub.Data.Models;
using AutoHub.Infrastructure.DTOs;
using AutoHub.Infrastructure.Repositories.Interfaces;
using AutoHub.Infrastructure.Services.Interfaces;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Infrastructure.Services
{
    public class ModelService : IModelService
    {
        private readonly IModelRepository _modelRepository;
        private readonly IBrandRepository _brandRepository;

        public ModelService(IModelRepository modelRepository, IBrandRepository brandRepository)
        {
            _modelRepository = modelRepository;
            _brandRepository = brandRepository;
        }

        public async Task AddModelAsync(ModelDto modelDto)
        {
            var model = new Model
            {
                Id = Guid.NewGuid(),
                Name = modelDto.Name,
                Year = modelDto.Year,
                HorsePower = modelDto.HorsePower,
                FuelType = modelDto.FuelType,
                GasConsumption = modelDto.GasConsumption,
                Description = modelDto.Description,
                ImageUrl = modelDto.ImageUrl,
                BrandId = modelDto.BrandId
            };

            await _modelRepository.AddAsync(model);
            await _modelRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ModelDto>> GetAllModelsAsync()
        {
            var models = await _modelRepository.GetAllAsync();

            return models.Select(model => new ModelDto
            {
                Id = model.Id,
                Name = model.Name,
                Year = model.Year,
                HorsePower = model.HorsePower,
                FuelType = model.FuelType,
                GasConsumption= model.GasConsumption,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                BrandId = model.BrandId
            });
        }

        public async Task<ModelDto?> GetModelByIdAsync(Guid id)
        {
            var model = await _modelRepository.GetIdAndVerifyAsync(id);

            if (model == null)
            {
                return null;
            }

            var brand = await _brandRepository.GetByIdAsync(model.BrandId);

            return new ModelDto
            {
                Id = model.Id,
                Name = model.Name,
                Year = model.Year,
                HorsePower = model.HorsePower,
                FuelType = model.FuelType,
                GasConsumption = model.GasConsumption,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                BrandId = model.BrandId,
                BrandName = brand?.Name
            };
        }
    }
}
