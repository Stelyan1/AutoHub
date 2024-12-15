using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Web.ViewModels.Models
{
    using static Common.HydraulicSystemModelErrorMessages;
    using static Common.EntityValidationConstants.HydaraulicSystem;
    public class HydraulicSystemViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = partNameIsRequired)]
        [MinLength(PartNameMinLength)]
        [MaxLength(PartNameMaxLength)]
        public string partName { get; set; } = null!;

        [Required(ErrorMessage = DescriptionIsRequired)]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = ImageIsRequired)]
        public string ImageUrl { get; set; } = null!;
    }
}
