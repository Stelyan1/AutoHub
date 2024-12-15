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
    public class HydraulicSystemRepository : BaseRepository<HydraulicSystem>, IHydraulicSystemRepository
    {
        private readonly AutoHubDbContext _dbContext;
        public HydraulicSystemRepository(AutoHubDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<HydraulicSystem?> GetIdAndVerifyAsync(Guid id)
        {
            return await _dbSet
                 .FirstOrDefaultAsync(hs => hs.Id == id);
        }

        public async Task UpdateHydraulicSystemAsync(HydraulicSystem hydraulicSystem)
        {
            _dbContext.HydraulicSystemParts.Update(hydraulicSystem);
        }
    }
}
