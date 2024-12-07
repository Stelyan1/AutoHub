using AutoHub.Data.Models;
using AutoHub.Infrastructure.DTOs;
using AutoHub.Infrastructure.Repositories.Interfaces;
using AutoHub.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Infrastructure.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task AddBrandAsync(BrandDto brandDto)
        {
            var brand = new Brand
            {
                Id = Guid.NewGuid(),
                Name = brandDto.Name,
                FoundedBy = brandDto.FoundedBy,
                FoundedDate = brandDto.FoundedDate,
                Description = brandDto.Description,
                ImageUrl  = brandDto.ImageUrl
            };

            await _brandRepository.AddAsync(brand);
            await _brandRepository.SaveChangesAsync();
        }

        public async Task DeleteBrandAsync(Guid id)
        {
            var brand = await _brandRepository.GetIdAndVerifyAsync(id);

            if (brand != null) 
            {
                _brandRepository.Delete(brand);
                await _brandRepository.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Brand not found");
            }
        }

        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            var brands = await _brandRepository.GetAllAsync();

            return brands.Select(brand => new BrandDto
            {
                Id = brand.Id,
                Name = brand.Name,
                FoundedBy = brand.FoundedBy,
                FoundedDate= brand.FoundedDate,
                Description = brand.Description,
                ImageUrl = brand.ImageUrl
            });
        }

        public async Task<BrandDto?> GetBrandByIdAsync(Guid id)
        {
           var brand = await _brandRepository.GetIdAndVerifyAsync(id);

            if (brand == null) 
            {
                return null;
            }

            return new BrandDto
            {
                Id = brand.Id,
                Name = brand.Name,
                FoundedBy = brand.FoundedBy,
                FoundedDate = brand.FoundedDate,
                Description = brand.Description,
                ImageUrl = brand.ImageUrl
            };
        }
    }
}
