using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Web.ViewModels.Models
{
    using static AutoHub.Common.EntityValidationConstants.Brand;
    using static AutoHub.Common.BrandModelErrorMessages.Brand;
    public class BrandViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = BrandNameIsRequired)]
        [MinLength(BrandNameMinLength)]
        [MaxLength(BrandNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = FounderIsRequired)]
        [MinLength(FounderMinLength)]
        [MaxLength(FounderMaxLength)]
        public string FoundedBy { get; set; } = null!;

        [Required(ErrorMessage = FoundedDateIsRequired)]
        public string FoundedDate { get; set; } = null!;

        [Required(ErrorMessage = DescriptionIsRequired)]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = ImageIsRequired)]
        public string ImageUrl  { get; set; } = null!;
    }
}
