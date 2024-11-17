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
    public class ModelRepository : BaseRepository<Model>, IBaseRepository<Model>
    {
        public ModelRepository(AutoHubDbContext dbContext) : base(dbContext)
        {
        }
    }
}
