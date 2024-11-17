using AutoHub.Data;
using AutoHub.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutoHub.Infrastructure
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly AutoHubDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(AutoHubDbContext dbContext)
        {
             _dbContext = dbContext;
             _dbSet = _dbContext.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
