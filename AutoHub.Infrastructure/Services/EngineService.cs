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
    public class EngineService : IEngineService
    {
        private readonly IEngineRepository _engineRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IModelRepository _modelRepository;

        public EngineService(IEngineRepository engineRepository, IBrandRepository brandRepository, IModelRepository modelRepository)
        {
            _engineRepository = engineRepository;
            _brandRepository = brandRepository;
            _modelRepository = modelRepository;
        }
        public async Task AddEngineAsync(EngineDto engineDto)
        {
            var engine = new Engine
            {
                Id = Guid.NewGuid(),
                Name = engineDto.Name,
                BrandId = engineDto.BrandId,
                ModelId = engineDto.ModelId,
                Cylinders = engineDto.Cylinders,
                ValvetrainDriveSystem = engineDto.ValveTrainDriveSystem,
                PowerOutput = engineDto.PowerOutput,
                Torque = engineDto.Torque,
                Rpm = engineDto.Rpm,
                ImageUrl = engineDto.ImageUrl,
                YearsProduction = engineDto.YearsProduction
            };

            await _engineRepository.AddAsync(engine);
            await _engineRepository.SaveChangesAsync();
        }

        public async Task DeleteEngineAsync(Guid id)
        {
            var engine = await _engineRepository.GetIdAndVerifyAsync(id);

            if (engine != null) 
            {
                _engineRepository.Delete(engine);
                await _engineRepository.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Engine not found");
            }
        }

        public async Task<IEnumerable<EngineDto>> GetAllEnginesAsync()
        {
            var engines = await _engineRepository.GetAllAsync();

            return engines.Select(engines => new EngineDto
            {
                Id = engines.Id,
                Name = engines.Name,
                BrandId = engines.BrandId,
                ModelId = engines.ModelId,
                Cylinders = engines.Cylinders,
                ValveTrainDriveSystem = engines.ValvetrainDriveSystem,
                PowerOutput = engines.PowerOutput,
                Torque = engines.Torque,
                Rpm = engines.Rpm,
                ImageUrl = engines.ImageUrl,
                YearsProduction = engines.YearsProduction
            });
        }

        public async Task<EngineDto?> GetEngineByIdAsync(Guid id)
        {
           var engine = await _engineRepository.GetIdAndVerifyAsync(id);

           if (engine ==  null)
           {
                return null;
           }
           
           var brand = await _brandRepository.GetByIdAsync(engine.BrandId);
           var model = await _modelRepository.GetByIdAsync(engine.ModelId);

            return new EngineDto
            {
                Id = engine.Id,
                Name = engine.Name,
                BrandId = engine.BrandId,
                BrandName = brand.Name,
                ModelId = engine.ModelId,
                ModelName = model.Name,
                Cylinders = engine.Cylinders,
                ValveTrainDriveSystem = engine.ValvetrainDriveSystem,
                PowerOutput = engine.PowerOutput,
                Torque = engine.Torque,
                Rpm = engine.Rpm,
                ImageUrl = engine.ImageUrl,
                YearsProduction = engine.YearsProduction
            };
        }

        public async Task UpdateEngineAsync(EngineDto engineDto)
        {
            var engine = await _engineRepository.GetByIdAsync(engineDto.Id);

            if (engine == null) 
            {
                throw new ArgumentException("Engine not found");
            }

            engine.Id = engineDto.Id;
            engine.Name = engineDto.Name;
            engine.BrandId = engineDto.BrandId;
            engine.ModelId = engineDto.ModelId;
            engine.Cylinders = engineDto.Cylinders;
            engine.ValvetrainDriveSystem = engineDto.ValveTrainDriveSystem;
            engine.PowerOutput = engineDto.PowerOutput;
            engine.Torque = engineDto.Torque;
            engine.Rpm = engineDto.Rpm;
            engine.ImageUrl = engineDto.ImageUrl;
            engine.YearsProduction = engineDto.YearsProduction;

            _engineRepository.Update(engine);
            await _engineRepository.SaveChangesAsync();
        }
    }
}
