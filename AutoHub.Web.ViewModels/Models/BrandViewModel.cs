using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Web.ViewModels.Models
{
    using static AutoHub.Common.EntityValidationConstants.Brand;
    public class BrandViewModel
    {
        [Required]
        [MinLength(BrandNameMinLength)]
        [MaxLength(BrandNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(FounderMinLength)]
        [MaxLength(FounderMaxLength)]
        public string FoundedBy { get; set; } = null!;

        [Required]
        public string FoundedDate { get; set; } = null!;

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl  { get; set; } = null!;
    }
}
