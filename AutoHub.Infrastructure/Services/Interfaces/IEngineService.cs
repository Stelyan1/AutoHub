using AutoHub.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Infrastructure.Services.Interfaces
{
    public interface IEngineService
    {
        Task<IEnumerable<EngineDto>> GetAllEnginesAsync();
        Task<EngineDto?> GetEngineByIdAsync(Guid id);
        Task AddEngineAsync(EngineDto engineDto);
    }
}
