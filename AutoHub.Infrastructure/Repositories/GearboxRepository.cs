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
    public class GearboxRepository : BaseRepository<Gearbox>, IGearboxRepository
    {
        public GearboxRepository(AutoHubDbContext dbContext) : base(dbContext) 
        {

        }

        public async Task<Gearbox?> GetByIdVerifyAsync(Guid id)
        {
           //#pragma warning disable CS8603 // Possible null reference return.
            return await _dbSet
                .Include(g => g.Model)
                .FirstOrDefaultAsync(g => g.Id == id);
          // #pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<IEnumerable<Gearbox>> GetByModelIdAsync(Guid modelId)
        {
            return await _dbContext.Gearboxes
                           .Where(g => g.Application == modelId)
                           .ToListAsync();
        }
    }
}
