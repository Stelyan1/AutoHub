using AutoHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Infrastructure.Repositories.Interfaces
{
    public interface IModelRepository : IBaseRepository<Model>
    {
        Task<Model?> GetIdAndVerifyAsync(Guid id);
    }
}
