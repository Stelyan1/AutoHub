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
    public class GearboxRepository : BaseRepository<Gearbox>, IBaseRepository<Gearbox>
    {
        public GearboxRepository(AutoHubDbContext dbContext) : base(dbContext) 
        {

        }
    }
}
