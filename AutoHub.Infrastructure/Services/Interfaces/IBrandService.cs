using AutoHub.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Infrastructure.Services.Interfaces
{
    public interface IBrandService
    {
       Task<IEnumerable<BrandDto>> GetAllBrandsAsync();
       Task<BrandDto?> GetBrandByIdAsync(Guid id);
       Task AddBrandAsync(BrandDto brandDto);
       Task DeleteBrandAsync (Guid id);
    }
}
