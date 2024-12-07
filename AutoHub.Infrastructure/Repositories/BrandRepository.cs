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
    public class BrandRepository : BaseRepository<Brand>, IBrandRepository
    {
        private readonly AutoHubDbContext _dbContext;
        public BrandRepository(AutoHubDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<Brand?> GetIdAndVerifyAsync(Guid id)
        {
            return await _dbSet
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task UpdateBrandAsync(Brand brand)
        {
            _dbContext.Brands.Update(brand);
        }
    }
}
