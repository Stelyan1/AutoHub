using AutoHub.Data;
using AutoHub.Data.Models;
using AutoHub.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Infrastructure.Repositories
{
    public class EngineRepository : BaseRepository<Engine>, IBaseRepository<Engine>
    {
        public EngineRepository(AutoHubDbContext dbContext) : base(dbContext)
        {
        }
    }
}
