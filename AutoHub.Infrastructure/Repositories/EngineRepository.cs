using AutoHub.Data;
using AutoHub.Data.Models;
using AutoHub.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Infrastructure.Repositories
{
    public class EngineRepository : BaseRepository<Engine>, IEngineRepository
    {
        public EngineRepository(AutoHubDbContext dbContext) : base(dbContext)
        {

        }

       

        public async Task<IEnumerable<Engine>> GetByModelIdAsync(Guid modelId)
        {
            return await _dbContext.Engines
                           .Where(e => e.ModelId == modelId)
                           .ToListAsync();
        }

        public async Task<Engine?> GetIdAndVerifyAsync(Guid id)
        {
            return await _dbSet
                .Include(e => e.Brand)
                .Include(e => e.Model)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
