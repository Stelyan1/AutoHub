using AutoHub.Data.Models;
using AutoHub.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Infrastructure.Services.Interfaces
{
    public interface IModelService
    {
        Task<IEnumerable<ModelDto>> GetAllModelsAsync();
        Task<ModelDto?> GetModelByIdAsync(Guid id);
        Task<IEnumerable<Engine>> GetEnginesByModelIdAsync(Guid modelId);
        Task<IEnumerable<Gearbox>> GetGearboxesByModelIdAsync(Guid modelId);
        Task AddModelAsync(ModelDto modelDto);
        Task UpdateModelAsync(ModelDto modelDto);
        Task DeleteModelAsync(Guid id);
        Task DeleteEngineAsync(Engine engine);
        Task DeleteGearboxAsync(Gearbox gearbox);
    }
}
