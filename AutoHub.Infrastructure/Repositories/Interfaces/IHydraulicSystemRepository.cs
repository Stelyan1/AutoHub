using AutoHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Infrastructure.Repositories.Interfaces
{
    public interface IHydraulicSystemRepository : IBaseRepository<HydraulicSystem>
    {
        Task<HydraulicSystem?> GetIdAndVerifyAsync (Guid id);
        Task UpdateHydraulicSystemAsync (HydraulicSystem hydraulicSystem);
    }
}
