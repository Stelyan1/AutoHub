using AutoHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Infrastructure.Repositories.Interfaces
{
    public interface IEngineRepository : IBaseRepository<Engine>
    {
        Task<IEnumerable<Engine>> GetByModelIdAsync(Guid modelId);
        Task<Engine?> GetIdAndVerifyAsync(Guid id);
    }
}
