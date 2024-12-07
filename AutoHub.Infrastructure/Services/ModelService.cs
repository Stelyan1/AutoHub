using AutoHub.Data.Models;
using AutoHub.Infrastructure.DTOs;
using AutoHub.Infrastructure.Repositories;
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
        private readonly IEngineRepository _engineRepository;
        private readonly IGearboxRepository _gearboxRepository;

        public ModelService(IModelRepository modelRepository, IBrandRepository brandRepository, IEngineRepository engineRepository, IGearboxRepository gearboxRepository)
        {
            _modelRepository = modelRepository;
            _brandRepository = brandRepository;
            _engineRepository = engineRepository;
            _gearboxRepository = gearboxRepository;
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

        public async Task DeleteModelAsync(Guid id)
        {
            var model = await _modelRepository.GetIdAndVerifyAsync(id);

            if (model != null)
            {
                _modelRepository.Delete(model);
                await _modelRepository.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Model not found");
            }
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

        public async Task DeleteEngineAsync(Engine engine)
        {
            _engineRepository.Delete(engine);
        }

        public async Task DeleteGearboxAsync(Gearbox gearbox)
        {
            _gearboxRepository.Delete(gearbox);
        }

        public async Task<IEnumerable<Engine>> GetEnginesByModelIdAsync(Guid modelId)
        {
            return await _engineRepository.GetByModelIdAsync(modelId);
        }

        public async Task<IEnumerable<Gearbox>> GetGearboxesByModelIdAsync(Guid modelId)
        {
            return await _gearboxRepository.GetByModelIdAsync(modelId);
        }

        public async Task UpdateModelAsync(ModelDto modelDto)
        {
            var model = await _modelRepository.GetByIdAsync(modelDto.Id);

            if (model == null)
            {
                throw new ArgumentException("Model not found");
            }

            model.Name = modelDto.Name;
            model.Year = modelDto.Year;
            model.HorsePower = modelDto.HorsePower;
            model.FuelType = modelDto.FuelType;
            model.GasConsumption = modelDto.GasConsumption;
            model.Description = modelDto.Description;
            model.ImageUrl = modelDto.ImageUrl;
            model.BrandId = modelDto.BrandId;

            await _modelRepository.UpdateModelAsync(model);
            await _modelRepository.SaveChangesAsync();
        }
    }
}
