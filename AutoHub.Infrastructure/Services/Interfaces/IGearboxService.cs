using AutoHub.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Infrastructure.Services.Interfaces
{
    public interface IGearboxService
    {
        Task<IEnumerable<GearboxDto>> GetAllGearboxesAsync();
        Task<GearboxDto?> GetGearboxesByIdAsync(Guid id);
        Task AddGearboxAsync(GearboxDto gearboxDto);
        Task GetGearboxById(Guid id);
        Task UpdateGearboxAsync(GearboxDto gearboxDto);
        Task DeleteGearboxAsync(Guid id);
    }
}
