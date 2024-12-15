using AutoHub.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Infrastructure.Services.Interfaces
{
    public interface IHydraulicSystemService
    {
        Task<IEnumerable<HydraulicSystemDto>> GetAllHydraulicPartsAsync();
        Task<HydraulicSystemDto?> GetHydraulicPartByIdAsync (Guid id);
        Task AddHydarulicPartAsync (HydraulicSystemDto hydraulicSystemDto);
        Task DeleteHydraulicPartAsync(Guid id);
        Task UpdateHydraulicPartAsync(HydraulicSystemDto hydraulicSystemDto);
    }
}
