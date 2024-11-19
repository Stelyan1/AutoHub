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
    public class ModelRepository : BaseRepository<Model>, IModelRepository
    {
        public ModelRepository(AutoHubDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Model?> GetIdAndVerifyAsync(Guid id)
        {
            return await _dbSet
                .Include(m => m.Brand)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
