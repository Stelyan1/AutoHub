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
    }
}
